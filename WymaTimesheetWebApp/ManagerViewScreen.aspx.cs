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
            if (!IsPostBack)
            {

                //Functions that run on page load
                string ManagerNameData = Session["ManagerName"].ToString();
                ManagerName.InnerText = Global.ReadDataString($"SELECT EMPNAME FROM EMPLOYEES WHERE RESOURCENAME='{ManagerNameData}';");

                DataTable unsignedTimesheets = new DataTable();
                unsignedTimesheets.Columns.Add("Name");
                unsignedTimesheets.Columns.Add("Date Submitted");
                ManagerView.DataSource = unsignedTimesheets;
                ManagerView.DataBind();

                Session["MangV"] = unsignedTimesheets;

                ShowFiles(ManagerNameData);

            }
            
        }

        protected void viewTimeSheet_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Allow manager to select a timesheet and view selected 

            //Accesses Unsigned Timesheets
            btnUpdateMV.Visible = true;
            btnAcceptMV.Visible = true;
            NameViewLabel.Visible = true;
            DateViewLabel.Visible = true;
            TotalHoursLabel.Visible = true;

            DataTable unsignedTimesheets = Session["MangV"] as DataTable;
            List<Global.DataFileInfo> UnapprovedFiles = Global.UnapprovedFiles;


            if (e.CommandName == "ViewTimeSheet")
            {
                DataFile df = new DataFile();

                int index = Convert.ToInt32(e.CommandArgument);

                string usrName = Global.ReadDataString($"SELECT RESOURCENAME FROM EMPLOYEES WHERE EMPNAME='{unsignedTimesheets.Rows[index].Field<string>(0)}';");
                string date = unsignedTimesheets.Rows[index].Field<string>(1);
                string managerName = Session["ManagerName"].ToString();


                ManagerView.Columns[0].Visible = false;


                df.Read($"{usrName} {date} {managerName}");
                DataTable FileData = df;
                ManagerView.DataSource = FileData;
                ManagerView.DataBind();

                

                Tuple<string, float> DT = df.GetDateAndTime();

                NameViewLabel.Text = "Employee Name: " + unsignedTimesheets.Rows[index].Field<string>(0);
                DateViewLabel.Text = "Date Submited:" + DT.Item1;
                TotalHoursLabel.Text = "Total Time Worked: " + Global.TimeToString(DT.Item2);

                Session["DataFile"] = FileData;

                //Server.Transfer("ManagerFileUpdate.aspx", true);
               
                

            }

        }

        private void ShowFiles(string manager)
        {

            List<Global.DataFileInfo> UnapprovedFiles = Global.UnapprovedFiles;
            DataTable unsignedTimesheets = Session["MangV"] as DataTable;

            foreach (Global.DataFileInfo data in UnapprovedFiles)
            {
                if (data.manager == manager)
                {
                    DataRow dr = unsignedTimesheets.NewRow();

                    dr["Name"] = Global.ReadDataString($"SELECT EMPNAME FROM EMPLOYEES WHERE RESOURCENAME='{data.name}';");
                    dr["Date Submitted"] = data.date;

                    unsignedTimesheets.Rows.Add(dr);
                    ManagerView.DataSource = unsignedTimesheets;
                    ManagerView.DataBind();
                    Session["MangV"] = unsignedTimesheets;
                }
            }
        }

        protected void btnMVBack(object sender, EventArgs e)
        {
            if (btnAcceptMV.Visible != true)
                Server.Transfer("MainMenu.aspx", true);
            else 
                Server.Transfer("ManagerViewScreen.aspx");
        }

        protected void BtnUpdateMVClick(object sender, EventArgs e)
        {

        }

        protected void BtnAcceptMVClick(object sender, EventArgs e)
        {
            if (sigPad.Visible == false)
            {

                signLabel.Visible = true;
                sigPad.Visible = true;
                clearBtn.Visible = true;
            }
            else
            {

                Server.Transfer("ManagerViewScreen.aspx");
            }
        }
    }
}