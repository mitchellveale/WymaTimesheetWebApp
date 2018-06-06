using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WymaTimesheetWebApp
{

    public class Global : System.Web.HttpApplication
    {
        public static List<Row> ListRows = new List<Row>();
        public static Dictionary<string, List<Row>> DictRows = new Dictionary<string, List<Row>>();

        //public static List<UsrData> ListUsrData = new List<UsrData>();
        public static Dictionary<string, UsrData> DictUsrData = new Dictionary<string, UsrData>();




        protected void Application_Start(object sender, EventArgs e)
        {
            Global.DictUsrData.Clear();
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
        
    
}