using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WymaTimesheetWebApp
{
    public partial class ManagerUpdate : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                List<string> empData = Session["empData"] as List<string>;
                ManagerName.InnerText = Global.ReadDataString($"SELECT EMPNAME FROM EMPLOYEES WHERE RESOURCENAME='{Session["ManagerName"].ToString()}';");
                NameViewLabel.Text = "Employee Name: " + empData[0];
                DateViewLabel.Text = "Date Submited: " + empData[1];
                TotalHoursLabel.Text = "Total Hours Worked: " + empData[2];
                TotalAppLabel.Text = " Total Hours Applied: " + empData[2];

                DataTable df = Session["DataFile"] as DataFile;


                UpdateView.DataSource = df;
                UpdateView.DataBind();
            }
        }

        protected void EditRow_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void BtnBackMU(object sender, EventArgs e)
        {
            Server.Transfer("ManagerViewScreen.aspx");
        }

        protected void BtnAcceptMU(object sender, EventArgs e)
        {

        }
    }
}