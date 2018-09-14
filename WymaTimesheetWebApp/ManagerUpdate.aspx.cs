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
        // List of Ordernumbers to allow order numbers to be stored from Database
        private List<string> Ordernumbers;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
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

        protected void OrderNumberUpdate(object sender, EventArgs e)
        {
            string inputData = OrderNumberInput.Text;
            //Gets the list of Steps and/or tasks for selected Order number when selected.

            inputData = inputData.Replace(" ", string.Empty);
            inputData = inputData.Replace("'", string.Empty);
            inputData = inputData.Replace(";", string.Empty);

            inputData = inputData.ToUpper();
            string result = Global.ReadDataString("SELECT FIRST 1 ORDERNUMBER FROM ORDERS WHERE ORDERNUMBER='" + inputData + "';");
            if (result == "")
            {
                Response.Write("<script>alert('Entered Order number is invalid. Please review what you have entered and try again.');</script>");
                StepTaskData.Items.Clear();
                StepTaskData.Items.Add("Please Select a Step or Task");
                StepTaskData.Enabled = false;
                return;
            }

            List<string> OrderStepsTasks;
            StepTaskData.Items.Clear();
            StepTaskData.Items.Add("Please Select a Step or Task");
            StepTaskData.Enabled = true;
            OrderStepsTasks = Global.ReadDataList($"SELECT TASKNAME FROM ORDERS WHERE ORDERNUMBER = '{inputData}' ;");

            foreach (string str in OrderStepsTasks)
            {
                StepTaskData.Items.Add(str);

            }

            JobAssyData.Text = Global.ReadDataString($"SELECT DISTINCT TYPE FROM ORDERS WHERE ORDERNUMBER = '{inputData}' ;");
            CustData.Text = Global.ReadDataString($"SELECT DISTINCT CUSTOMER FROM ORDERS WHERE ORDERNUMBER = '{inputData}' ;");
        }


        protected void EditRow_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            List<string> OrderStepsTasks;
            if (e.CommandName == "EditTimeSheet")
            {
                UpdateSelection.Visible = true;
                int index = Convert.ToInt32(e.CommandArgument);

                JobNumberData.SelectedValue = UpdateView.Rows[index].Cells[2].Text;

                OrderStepsTasks = Global.ReadDataList($"SELECT TASKNAME FROM ORDERS WHERE ORDERNUMBER = '{JobNumberData.SelectedValue}' ;");
                foreach (string str in OrderStepsTasks)
                {
                    StepTaskData.Items.Add(str);

                }

                StepTaskData.SelectedValue = UpdateView.Rows[index].Cells[3].Text;

                CustData.Text = UpdateView.Rows[index].Cells[8].Text;

                Session["EditedRow"] = index;

            }

        }

        protected void BtnBackMU(object sender, EventArgs e)
        {
            Server.Transfer("ManagerViewScreen.aspx");
        }

        protected void BtnAcceptMU(object sender, EventArgs e)
        {

        }

        protected void BtnEdit(object sender, EventArgs e)
        {
            
            int index = int.Parse(Session["EditedRow"].ToString());

            //edit row with row number of index
            UpdateView.Rows[index].Cells[1].Text = JobAssyData.Text;
            UpdateView.Rows[index].Cells[2].Text = JobNumberData.SelectedValue;
            UpdateView.Rows[index].Cells[3].Text = StepTaskData.SelectedValue;
            UpdateView.Rows[index].Cells[5].Text = WyEUrefData.Text;
            UpdateView.Rows[index].Cells[6].Text = EUStepData.Text;
            UpdateView.Rows[index].Cells[7].Text = EUCustData.Text;
            UpdateView.Rows[index].Cells[8].Text = CustData.Text;



        }
    }
}