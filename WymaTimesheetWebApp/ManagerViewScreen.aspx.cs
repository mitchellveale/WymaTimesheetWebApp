using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WymaTimesheetWebApp
{
    public partial class ManagerViewScreen : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
            
            string ManagerNameData = Session["ManagerName"].ToString();
            ManagerName.InnerText = Global.ReadDataString($"SELECT EMPNAME FROM EMPLOYEES WHERE RESOURCENAME='{ManagerNameData}';");

            DataTable unsignedTimesheets = new DataTable();
            unsignedTimesheets.Columns.Add("Name");
            unsignedTimesheets.Columns.Add("Date");
            ManagerView.DataSource = unsignedTimesheets;
            ManagerView.DataBind();

            Session["MangV"] = unsignedTimesheets;

            ShowFiles(ManagerNameData);
            
        }

        protected void viewTimeSheet_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        private void ShowFiles(string manager)
        {
            List<Global.DataFileInfo> UnapprovedFiles = new List<Global.DataFileInfo>();
            DataTable unsignedTimesheets = Session["MangV"] as DataTable;

            foreach (Global.DataFileInfo data in UnapprovedFiles)
            {
                if (data.manager == manager)
                {
                    DataRow dr = unsignedTimesheets.NewRow();

                    dr["Name"] = data.name;
                    dr["Date"] = data.date;

                    unsignedTimesheets.Rows.Add(dr);
                    ManagerView.DataSource = unsignedTimesheets;
                    ManagerView.DataBind();
                    Session["MangV"] = unsignedTimesheets;
                }
            }
        }

        protected void btnMVBack(object sender, EventArgs e)
        {
            Server.Transfer("MainMenu.aspx");
        }
    }
}