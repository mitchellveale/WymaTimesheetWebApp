using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using FirebirdSql.Data.FirebirdClient;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Configuration;

namespace WymaTimesheetWebApp
{
    public enum JobType { Assembly, Job, NonCharge };

    public class Global : System.Web.HttpApplication
    {
        public struct DataFileInfo
        {
            public string name;
            public String date;
            public string manager;
        }

        #region  Ya'll want some dictionaries?
        public static Dictionary<string, DataTable> CHDATA  = new Dictionary<string, DataTable>();
        public static Dictionary<string, DataTable> NCDATA = new Dictionary<string, DataTable>();

        public static Dictionary<string, UsrData> DictUsrData = new Dictionary<string, UsrData>();

        public static Dictionary<string, DataFile> UserData = new Dictionary<string, DataFile>();

        public static Dictionary<string, string> signatureData = new Dictionary<string, string>();
        #endregion

        public static List<DataFileInfo> UnapprovedFiles = new List<DataFileInfo>();

        public static string errorLog;
        private static string outputPath;
        public static string OutputPath
        {
            get
            {
                return outputPath;
            }
        }
        private static string exportPath;
        public static string ExportPath
        {
            get
            {
                return exportPath;
            }
        }
        private static string DBConnection;

        protected void Application_Start(object sender, EventArgs e)
        {
            Global.DictUsrData.Clear();

            //get all application configuration data
            DBConnection = ConfigurationManager.AppSettings["DBConnection"];
            outputPath = ConfigurationManager.AppSettings["OutputPath"];
            exportPath = ConfigurationManager.AppSettings["ExportPath"];

            string ServerIP = ConfigurationManager.AppSettings["ServerIP"];
            DBConnection = DBConnection.Replace("$$serverIP$$", ServerIP);

            RefreshFiles();
        }

        public static float TimeToFloat(string Time)
        {
            int Hours = 0;
            int Mins = 0;
            float fTime = 0f;
            string[] time = Time.Split(' ');

            int.TryParse(Regex.Replace(time[0], "[^0-9]+", string.Empty), out Hours);
            int.TryParse(Regex.Replace(time[1], "[^0-9]+", string.Empty), out Mins);

            fTime += Hours;
            fTime += ((float)Mins / 60);

            return fTime;
        }

        public static string TimeToString(float Time)
        {
            //5.50 (float) to 5h:30m
            string Hours = "";

            Hours += Math.Floor(Time).ToString() + "h ";
            if (Time % 1 == 0)
                Hours += "00m";
            else
                Hours += ((Time % 1) * 60).ToString() + "m";
            return Hours;

        }

        public static void RefreshFiles()
        {
            DirectoryInfo d = new DirectoryInfo(outputPath);
            FileInfo[] Files = d.GetFiles("*.Wyma");

            foreach (FileInfo file in Files) 
            {
                string fName = file.Name.Split('.')[0];
                bool alreadyExists = false;
                foreach (DataFileInfo dfi in UnapprovedFiles)
                {
                    if (fName == $"{dfi.name} {dfi.date} {dfi.manager}")
                        alreadyExists = true;
                }
                if (!alreadyExists)
                {
                    string[] fileName = fName.Split(' ');

                    UnapprovedFiles.Add(new DataFileInfo
                    {
                        //FIXME: In production these spaces will break everything.
                        name = " " + fileName[1],
                        date = fileName[2],
                        manager = " " + fileName[4]
                    });
                }
            }
        }

        public static DateTime EndOfWeekDate(DateTime date)
        {
            DayOfWeek day = date.DayOfWeek;

            //If not Sunday, make 'date' the date for the next coming sunday.
            //otherwise return the same value that has been passed into the method
            if (day != DayOfWeek.Sunday)
            {
                int intDayOfWeek = day.GetHashCode();
                int DaysFromSunday = 7 - intDayOfWeek;

                DateTime endDate = date.AddDays(DaysFromSunday);
                return endDate;
            }
            else
            {
                return date;
            }
        }

    #region DBConn
    public static bool FDBNonQuery(string command)
        {
            try
            {
                FbCommand cmd = new FbCommand(command)
                {
                    CommandType = CommandType.Text
                };

                using (cmd.Connection = new FbConnection(DBConnection))
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                errorLog += (e.ToString() + ";");
                return false;
            }
        }


        public static List<string> ReadDataList(String command)
        {
            List<string> data = new List<string>();

            FbConnection con = new FbConnection(DBConnection);
            try
            {
                con.Open();

                FbCommand cmd = new FbCommand(command, con);

                FbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    data.Add(reader[0].ToString());
                }
                return data;

            }
            catch (Exception e)
            {
                data.Add("!ERROR!");
                data.Add(e.ToString());
                return data;
            }
            finally
            {
                con.Close();
            }

        }

        public static string ReadDataString(String command)
        {

            string data = "";

            FbConnection con = new FbConnection(DBConnection);
            try
            {
                con.Open();

                FbCommand cmd = new FbCommand(command, con);

                FbDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    data = reader[0].ToString();
                }
                return data;


            }
            catch (Exception e)
            {
                data = ("!ERROR!");
                errorLog += (e.ToString() + ";");
                return data;
            }
            finally
            {
                con.Close();
            }

        }
        #endregion

 
    }
    #region DataFile
    public class DataFile
    {
        public struct Header
        {
            public bool Accepted;
            public string EmployeeCode;
            public string Date;
            public string Manager;
        }

        public struct DataEntry
        {
            public JobType JobType;
            public string OrderNum;
            public string Task;
            public float Time;
            public string Customer;
        }

        private Header header;
        private List<DataEntry> data;
        public List<DataEntry> Data
        {
            get
            {
                return data;
            }
        }

        private string signature;
        public string Signature
        {
            get
            {
                return signature;
            }
            set
            {
                signature = value;
            }
        }

        private string managerSignature;
        public string ManagerSignature
        {
            set
            {
                managerSignature = value;
            }
        }

        public DataFile()
        {
            header = new Header();
            data = new List<DataEntry>();
        }

        public void CreateHeader(string EmployeeCode, string Date, string Manager = "")
        {
            header.Accepted = false;
            header.EmployeeCode = EmployeeCode;
            header.Date = Date;
            header.Manager = Manager;
        }
        //this isnt so much "add data" as it is initialize data
        public void AddData(JobType JobType, string OrderNum, string Task, float Time, string Customer)
        {
            DataEntry newEntry = new DataEntry
            {
                JobType = JobType,
                OrderNum = OrderNum,
                Task = Task,
                Time = Time,
                Customer = Customer
            };
            data.Add(newEntry);
        }

        public void AssignManager(string Manager)
        {
            header.Manager = Manager;
        }

        public void Write(bool AddToUnacceptedFiles = true, bool move = false)
        {
            StringBuilder builder = new StringBuilder();
            string writePath = $@"{Global.OutputPath}{header.EmployeeCode} {header.Date} {header.Manager}";
            int accepted = header.Accepted ? 1 : 0;
            string headerInput = string.Format($"{accepted.ToString()},{header.EmployeeCode},{header.Date},{header.Manager};");
            builder.AppendFormat(headerInput);
            string sig = string.Format($"{signature};");
            builder.AppendFormat(sig);
            if (managerSignature != "")
            {
                string manSig = string.Format($"{managerSignature};");
                builder.AppendFormat(manSig);
                writePath = $@"{Global.OutputPath}Accepted Files\{header.EmployeeCode} {header.Date} FINAL";
            }
            string dataInput;
            foreach (DataEntry de in data)
            {
                int jobTypeInt = (int)de.JobType;
                dataInput = string.Format($"{jobTypeInt.ToString()},{de.OrderNum},{de.Task},{de.Time.ToString()},{de.Customer};");
                builder.AppendFormat(dataInput);
            }
            if (move)
            {
                writePath = $@"{Global.OutputPath}Accepted Files\{header.EmployeeCode} {header.Date} INITIAL";
                File.Delete($@"{Global.OutputPath}{header.EmployeeCode} {header.Date} {header.Manager}.Wyma");
            }
            string filePath = $@"{writePath}.Wyma";
            //We *MAY* want a simple encryption algorithm to make the file unreadable to anybody that may accidentally encounter it.
            File.WriteAllText(filePath, builder.ToString());
            if (AddToUnacceptedFiles)
            { 
                Global.UnapprovedFiles.Add(new Global.DataFileInfo
                {
                    name = header.EmployeeCode,
                    date = header.Date,
                    manager = header.Manager
                });
            }
        }

        public void Read(string FileName)
        {
            string rawInput = File.ReadAllText($@"{Global.OutputPath}{FileName}.Wyma");
            List<string> rows = rawInput.Split(';').ToList<string>();

            //Adding header data
            string[] headerData = rows[0].Split(',');
            header.Accepted = int.Parse(headerData[0]) != 0;
            header.EmployeeCode = headerData[1];
            header.Date = headerData[2];
            header.Manager = headerData[3];
            rows.RemoveAt(0);
            //get signature data
            signature = rows[0];
            rows.RemoveAt(0);
            //Add TimeSheet Data
            rows.RemoveAt(rows.Count - 1);
            foreach (string str in rows)
            {
                string[] rowData = str.Split(',');
                JobType jobType = (JobType) int.Parse(rowData[0]);
                float time = float.Parse(rowData[3]);

                AddData(jobType, rowData[1], rowData[2], time, rowData[4]);
            }
        }

        public void Export(bool fixedVersion = false)
        {
            StringBuilder builder = new StringBuilder();

            string endDate = Global.EndOfWeekDate(Convert.ToDateTime(header.Date)).ToString("yyyy-MM-dd");
            string initialLine = string.Format($"InProgress,,Employee,{header.EmployeeCode},FALSE,{header.Date},Approved,,,Made by a super amazing WebApp,{header.Date}");
            builder.AppendLine(initialLine);
            foreach (DataEntry de in data)
            {
                string str = string.Format($"{header.Date},{de.JobType.ToString()},{de.OrderNum},,{header.EmployeeCode},STD,{de.Task},FALSE,,,{de.Time.ToString()},0,,Chargeable,,-,TRUE,TRUE,FALSE,InProgress");
                builder.AppendLine(str);
            }
            //generate a unique 14-digit QR code for the file.
            Random random = new Random();
            int QRCode = random.Next(100000, 999999);
            int date = int.Parse(Regex.Replace(header.Date, "[^0-9]+", string.Empty));
            //name the file
            string fileName = $"{header.EmployeeCode} {date.ToString()}{QRCode.ToString()}";
            File.WriteAllText($@"{Global.ExportPath}{fileName}.csv", builder.ToString());
            //remove from unapproved files
            for (int i = 0; i < Global.UnapprovedFiles.Count; i++)
            {
                Global.DataFileInfo dfi = Global.UnapprovedFiles[i];
                if (dfi.name == header.EmployeeCode && dfi.date == header.Date)
                {
                    Global.UnapprovedFiles.RemoveAt(i);
                }
            }
            if (!fixedVersion)
            {
                //move datafile to 'accepted' folder
                header.Accepted = true;
                //Write file but do not add it to the unapproved files list.
                Write(false);
                string path = $@"{Global.OutputPath}{header.EmployeeCode} {header.Date} {header.Manager}.Wyma";
                //string to = $@"{Global.OutputPath}Accepted Files\{header.EmployeeCode} {header.Date} INITIAL.Wyma";
                //File.Move(from, to);
                File.Delete(path);
            }
            else
            {
                Write(false);
            }
        }

        public static implicit operator DataTable(DataFile df)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Job/Assy");
            dt.Columns.Add("Number");
            dt.Columns.Add("Step/Task");
            dt.Columns.Add("Hours:Mins");
            dt.Columns.Add("WyEU REF");
            dt.Columns.Add("EU Step/Task");
            dt.Columns.Add("EU Cust");
            dt.Columns.Add("Customer/NC Comment");

            foreach (DataEntry de in df.data)
            {
                DataRow dr = dt.NewRow();
                dr["Job/Assy"] = de.JobType.ToString();
                dr["Number"] = de.OrderNum;
                dr["Step/Task"] = de.Task;
                dr["Hours:Mins"] = Math.Floor(de.Time).ToString() + "h " + ((de.Time % 1) * 60).ToString() + "m";
                dr["WyEU REF"] = "";
                dr["EU Step/Task"] = "";
                dr["EU Cust"] = "";
                dr["Customer/NC Comment"] = de.Customer;
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public static implicit operator DataFile(DataTable dt)
        {
            DataFile df = new DataFile();

            foreach (DataRow dr in dt.Rows)
            {
                df.AddData(
                    (JobType)dr["Job/Assy"],
                    dr["Number"].ToString(),
                    dr["Step/Task"].ToString(),
                    Global.TimeToFloat(dr["Hours:Mins"].ToString()),
                    dr["Customer/NC Comment"].ToString()
                    );
            }

            return df;
        }

        public Tuple<string, float> GetDateAndTime()
        {
            float totalTime = 0;
            foreach (DataEntry de in data)
            {
                totalTime += de.Time;
            }
            Tuple<string, float> retData = new Tuple<string, float>(header.Date, totalTime);
            return retData;
        }
    }
    #endregion
    #region Sam's Trash
    //Class that that takes and stores userdata
    public class UsrData
    {

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        private string date;
        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
               
        }

        private string startTime;
        public string StartTime
        {
            get
            {
                return startTime;
            }
            set
            {
                startTime = value;
            }

        }

        private string lunchTime;
        public string LunchTime
        {
            get
            {
                return lunchTime;
            }
            set
            {
                lunchTime = value;
            }
        }

        private string endTime;
        public string EndTime
        {
            get
            {
                return endTime;
            }
            set
            {
                endTime = value;
            }
        }

        private float totalHours;
        public float TotalHours
        {

            get
            {
                return totalHours;
            }
            
            set
            {
                totalHours = value;
            }
        }

        public UsrData(string name, string date, string startTime, string endTime, string lunchTime, float totalHours)
        {
            this.name = name;
            this.date = date;
            this.startTime = startTime;
            this.endTime = endTime;
            this.lunchTime = lunchTime;
            this.totalHours = totalHours;

        }
      
    }
    #endregion
}