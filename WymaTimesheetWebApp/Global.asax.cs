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

namespace WymaTimesheetWebApp
{

    public class Global : System.Web.HttpApplication
    {


        


        public static Dictionary<string, List<Row>> DictRows = new Dictionary<string, List<Row>>();

        public static Dictionary<string, UsrData> DictUsrData = new Dictionary<string, UsrData>();

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
        //Instead of a 'finally' use a 'using' statement.
        public static List<string> ReadDataList(String command, string serverIP = "10.1.119.252")
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
        #endregion


        public static string ReadDataString(String command, string serverIP = "10.1.119.252")
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

        public static bool WriteCSV(StringBuilder values, string fileName)
        {
            //maybe have this function also create and save the QR code too??
            //There will have to be check to see if the file name already exists.
            try
            {
                File.WriteAllText($@"C:\Users\mitch\Desktop\CSV Files\Output\{fileName}.csv", values.ToString());
                return true;
            }
            catch (Exception e)
            {
                errorLog += $"{e.ToString()};";
                return false;
            }
        }

    }

    #region Sam's Trash
    public class Row
    {
        
        
    
    }
    
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

        private string totalHours;
        public string TotalHours
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

        public UsrData(string name, string date, string startTime, string endTime, string lunchTime, string totalHours)
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