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

                EmployeeNameData.Text = Global.ReadDataString($"SELECT EMPNAME FROM EMPLOYEES WHERE RESOURCENAME ='{userName}';");
                TimeWorkedData.Text = Global.DictUsrData[userName].StartTime + " - " + Global.DictUsrData[userName].EndTime;
                BreakTimeData.Text = Global.DictUsrData[userName].LunchTime;
                TotalTimeWorkedData.Text = Global.TimeToString(Global.DictUsrData[userName].TotalHours);

               
                dataFile.CreateHeader(userName, Global.DictUsrData[userName].Date);
             
                
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

                if (CHTable.Rows.Count != 0)
                {
                    JobsAssembliesViewGrid.DataSource = CHTable;
                    JobsAssembliesViewGrid.DataBind();
                }
                else
                    viewJALabel.Visible = false;

                if (NCTable.Rows.Count != 0)
                {
                    NonChargeViewGrid.DataSource = NCTable;
                    NonChargeViewGrid.DataBind();
                }
                else
                    viewNCLabel.Visible = false;


                



                //
                Global.UserData.Add(userName, dataFile);
            }
            


            
          
            
            
        }

        
        

        protected void btnDoneVSClick(object sender, EventArgs e)
        {
            Response.Write("<script>alert('" + hiddenfield.Value + "')</script>");

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
            Global.UserData.Remove(Session["UsrName"].ToString());
            Server.Transfer("Job-AssSelection.aspx", true);
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}