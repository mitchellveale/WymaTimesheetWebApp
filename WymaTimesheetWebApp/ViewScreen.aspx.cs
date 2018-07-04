using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WymaTimesheetWebApp
{
    public partial class ViewScreen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //Gets data to show on View Screen and loads it onto the page.
                EmployeeNameData.Text = Global.ReadDataString($"SELECT EMPNAME FROM EMPLOYEES WHERE RESOURCENAME ='{Session["UsrName"].ToString()}';");
                TimeWorkedData.Text = Global.DictUsrData[Session["UsrName"].ToString()].StartTime + " - " + Global.DictUsrData[Session["UsrName"].ToString()].EndTime;
                BreakTimeData.Text = Global.DictUsrData[Session["UsrName"].ToString()].LunchTime;
                TotalTimeWorkedData.Text = Global.DictUsrData[Session["UsrName"].ToString()].TotalHours;
                //

                //Takes Edited Data and Pastes in tables on screen
                DataTable CHTable = Session["CHtab"] as DataTable;
                DataTable NCTable = Session["NCtab"] as DataTable;

                JobsAssembliesViewGrid.DataSource = CHTable;
                JobsAssembliesViewGrid.DataBind();

                NonChargeViewGrid.DataSource = NCTable;
                NonChargeViewGrid.DataBind();
                //

            }
            


            
                
            
            
        }

        protected void btnDoneVSClick(object sender, EventArgs e)
        {
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