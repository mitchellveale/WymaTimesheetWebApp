using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;

namespace WymaTimesheetWebApp
{
    public partial class ViewScreen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DataFile dataFile = new DataFile();
                string userName = Session["UsrName"].ToString();
                //Gets data to show on View Screen and loads it onto the page.
<<<<<<< HEAD
                EmployeeNameData.Text = Global.ReadDataString($"SELECT EMPNAME FROM EMPLOYEES WHERE RESOURCENAME ='{Session["UsrName"].ToString()}';");
                TimeWorkedData.Text = Global.DictUsrData[Session["UsrName"].ToString()].StartTime + " - " + Global.DictUsrData[Session["UsrName"].ToString()].EndTime;
                BreakTimeData.Text = Global.DictUsrData[Session["UsrName"].ToString()].LunchTime;
                TotalTimeWorkedData.Text = Global.TimeToString(Global.DictUsrData[Session["UsrName"].ToString()].TotalHours);
                //
=======
                EmployeeNameData.Text = Global.ReadDataString($"SELECT EMPNAME FROM EMPLOYEES WHERE RESOURCENAME ='{userName}';");
                TimeWorkedData.Text = Global.DictUsrData[userName].StartTime + " - " + Global.DictUsrData[userName].EndTime;
                BreakTimeData.Text = Global.DictUsrData[userName].LunchTime;
                TotalTimeWorkedData.Text = Global.DictUsrData[userName].TotalHours;

                //FIXME: Find where sam is storing the date that the user entered
                dataFile.CreateHeader(userName, Global.DictUsrData[userName].Date);

>>>>>>> 024357bc13e26f08fd106aa7634778008f1bd03d

                //Takes Edited Data and Pastes in tables on screen
                DataTable CHTable = Session["CHtab"] as DataTable;
                DataTable NCTable = Session["NCtab"] as DataTable;

                foreach (DataRow row in CHTable.Rows)
                {
                    JobType jobType = (JobType)Enum.Parse(typeof(JobType), row["Job/Assy"].ToString());
                    string orderNumber = row["Number"].ToString();
                    string task = row["Step/Task"].ToString();

                    //Calculate 'time' in a float format
                    string[] strSplit = row["Hours:Mins"].ToString().Split(':');
                   
                    float time = 0f;
                    //I'm parsing as an int because doing it as a float would mean potentially having to
                    //deal with the value being +/- phi
                    time += int.Parse(strSplit[0]);
                    time += (float)(int.Parse(strSplit[1])) / 60;

                    string customer = row["Customer"].ToString();

                    dataFile.AddData(jobType, orderNumber, task, time, customer);
                }

                JobsAssembliesViewGrid.DataSource = CHTable;
                JobsAssembliesViewGrid.DataBind();



                NonChargeViewGrid.DataSource = NCTable;
                NonChargeViewGrid.DataBind();
                //
                Global.UserData.Add(userName, dataFile);
            }
            


            
                
            
            
        }

 
        

        protected void btnDoneVSClick(object sender, EventArgs e)
        {
            //Write data file and delete it from Global's dictionary
            string userName = Session["UsrName"].ToString();
            Global.UserData[userName].Write();
            Global.UserData[userName].Export();
            Global.UserData.Remove(userName);

            Global.DictUsrData.Remove(Session["UsrName"].ToString());
            Global.CHDATA.Remove(Session["UsrName"].ToString());
            Global.NCDATA.Remove(Session["UsrName"].ToString());
            Server.Transfer("MainMenu.aspx", true);
        }
        protected void btnBackVSClick(object sender, EventArgs e)
        {
            Global.CHDATA.Remove(Session["UsrName"].ToString());
            Global.NCDATA.Remove(Session["UsrName"].ToString());
            Server.Transfer("Job-AssSelection.aspx", true);
        }
    }
}