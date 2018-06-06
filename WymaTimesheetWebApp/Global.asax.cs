using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using FirebirdSql.Data.FirebirdClient;

namespace WymaTimesheetWebApp
{

    public class Global : System.Web.HttpApplication
    {
<<<<<<< HEAD
        public static List<Row> ListRows = new List<Row>();
        public static Dictionary<string, List<Row>> DictRows = new Dictionary<string, List<Row>>();

        //public static List<UsrData> ListUsrData = new List<UsrData>();
        public static Dictionary<string, UsrData> DictUsrData = new Dictionary<string, UsrData>();




        protected void Application_Start(object sender, EventArgs e)
        {
            Global.DictUsrData.Clear();
=======
        public static string errorLog;

        protected void Application_Start(Object sender, EventArgs e)
        {
            //get the data.
        }


        public static bool FDBNonQuery(string serverIP, string command)
        {
            try
            {
                FbCommand cmd = new FbCommand(command);
                cmd.CommandType = CommandType.Text;

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

        public static List<string> ReadData(string serverIP, String command)
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
>>>>>>> master
        }





    }

    public class Row
    {


    }

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

        private string starttime;
        public string StartTime
        {
            get
            {
                return starttime;
            }
            set
            {
                starttime = value;
            }

        }

        private string lunchtime;
        public string LunchTime
        {
            get
            {
                return lunchtime;
            }
            set
            {
                lunchtime = value;
            }
        }

        private string endtime;
        public string EndTime
        {
            get
            {
                return endtime;
            }
            set
            {
                endtime = value;
            }
        }

        public UsrData(string name, string date, string starttime, string endtime, string lunchtime)
        {
            this.name = name;
            this.date = date;
            this.starttime = starttime;
            this.endtime = endtime;
            this.lunchtime = lunchtime;

        }
        

        
        

    }
<<<<<<< HEAD
        
    
=======


>>>>>>> master
}