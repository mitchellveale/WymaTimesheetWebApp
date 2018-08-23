using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using FirebirdSql.Data.FirebirdClient;
using QRCoder;
using System.Drawing;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace WymaTimesheetWebApp
{
    public enum JobType { Assembly, Job, NonCharge };

    public class Global : System.Web.HttpApplication
    {

        public static Dictionary<string, DataTable> CHDATA  = new Dictionary<string, DataTable>();
        public static Dictionary<string, DataTable> NCDATA = new Dictionary<string, DataTable>();

        public static Dictionary<string, UsrData> DictUsrData = new Dictionary<string, UsrData>();

        public static Dictionary<string, DataFile> UserData = new Dictionary<string, DataFile>();
        public static string errorLog;



        protected void Application_Start(object sender, EventArgs e)
        {
            Global.DictUsrData.Clear();
           
        }



        public static Bitmap QRCode(string EncodeValue)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrData = qrGenerator.CreateQrCode(EncodeValue, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrData);
            return qrCode.GetGraphic(20);
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

    #region DBConn
    public static bool FDBNonQuery(string serverIP, string command)
        {
            try
            {
                FbCommand cmd = new FbCommand(command)
                {
                    CommandType = CommandType.Text
                };

                using (cmd.Connection = new FbConnection($@"Server={serverIP};User=SYSDBA;Password=masterkey;Database={serverIP}:D:\fdb\testdb.fdb;ServerType=0;Port=3050;"))
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

<<<<<<< HEAD
        public static List<string> ReadDataList(String command, string serverIP = "10.1.115.61")
=======
        public static List<string> ReadDataList(String command, string serverIP = "10.1.123.207")
>>>>>>> 874ffd9124a02eee07dbde897ac3628d263d4de4
        {
            List<string> data = new List<string>();

            FbConnection con = new FbConnection($@"Server={serverIP};User=SYSDBA;Password=masterkey;Database={serverIP}:D:\fdb\testdb.fdb;ServerType=0;Port=3050;");
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

<<<<<<< HEAD
        public static string ReadDataString(String command, string serverIP = "10.1.115.61")
=======
        public static string ReadDataString(String command, string serverIP = "10.1.123.207")
>>>>>>> 874ffd9124a02eee07dbde897ac3628d263d4de4
        {
            string data = "";

            FbConnection con = new FbConnection($@"Server={serverIP};User=SYSDBA;Password=masterkey;Database={serverIP}:D:\fdb\testdb.fdb;ServerType=0;Port=3050;");
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

        public DataFile()
        {
            header = new Header();
            data = new List<DataEntry>();
        }

        //FIXME: EmployeeCode is being passed in from the data in the session however it has a space at the start of the string
        //and this could break some stuff
        public void CreateHeader(string EmployeeCode, string Date)
        {
            header.Accepted = false;
            header.EmployeeCode = EmployeeCode;
            header.Date = Date;
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

        public void Write()
        {
            StringBuilder builder = new StringBuilder();
            int accepted = header.Accepted ? 1 : 0;
            string headerInput = string.Format($"{accepted.ToString()},{header.EmployeeCode},{header.Date};");
            builder.AppendFormat(headerInput);
            string dataInput;
            foreach (DataEntry de in data)
            {
                int jobTypeInt = (int)de.JobType;
                dataInput = string.Format($"{jobTypeInt.ToString()},{de.OrderNum},{de.Task},{de.Time.ToString()},{de.Customer};");
                builder.AppendFormat(dataInput);
            }
            string filePath = $@"D:\Output Data\{header.EmployeeCode} {header.Date}.Wyma";
            File.WriteAllText( filePath, builder.ToString());
            //We *MAY* want a simple encryption algorithm to make the file unreadable to anybody that may accidentally encounter it.
        }

        public void Read(string FileName)
        {
            string rawInput = File.ReadAllText($@"D:\Output Data\{FileName}.Wyma");
            List<string> rows = rawInput.Split(';').ToList<string>();

            //Adding header data
            string[] headerData = rows[0].Split(',');
            header.Accepted = int.Parse(headerData[0]) != 0;
            header.Date = headerData[1];
            header.EmployeeCode = headerData[2];
            rows.RemoveAt(0);
            //Add TimeSheet Data
            foreach (string str in rows)
            {
                string[] rowData = str.Split(',');
                JobType jobType = (JobType) int.Parse(rowData[0]);
                float time = float.Parse(rowData[3]);

                AddData(jobType, rowData[1], rowData[2], time, rowData[4]);
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
            dt.Columns.Add("Customer");

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
                dr["Customer"] = de.Customer;
                dt.Rows.Add(dr);
            }
            return dt;
        }


        public void Export()
        {
            StringBuilder builder = new StringBuilder();
            //this first "Date" needs to be the end of the week date
            string initialLine = string.Format($"InProgress,,Employee,{header.EmployeeCode},FALSE,{header.Date},Waiting Approval,,,Made by a super amazing WebApp,{header.Date}");
            builder.AppendLine(initialLine);
            foreach (DataEntry de in data)
            {
                string str = string.Format($"{header.Date},{de.JobType.ToString()},{de.OrderNum},,{header.EmployeeCode},STD,{de.Task},FALSE,,,{de.Time.ToString()},0,,Chargeable,,-,TRUE,TRUE,FALSE,InProgress");
                builder.AppendLine(str);
            }
            Random random = new Random();
            int QRCode = random.Next(100000, 999999);
            int date = int.Parse(Regex.Replace(header.Date, "[^0-9]+", string.Empty));
            //deal with naming the file here
            string fileName = $"{header.EmployeeCode} {date.ToString()}{QRCode.ToString()}";
            File.WriteAllText($@"D:\Output Data\CSV\{fileName}.csv", builder.ToString());
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