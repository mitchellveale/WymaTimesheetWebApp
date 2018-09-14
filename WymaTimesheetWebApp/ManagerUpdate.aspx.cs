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


                //Sets inital data in forms for users to select from. 
                Ordernumbers = Global.ReadDataList("SELECT DISTINCT ORDERNUMBER FROM ORDERS;");
                JobNumberData.Items.Add("Please Select an Order Number");
                foreach (string str in Ordernumbers)
                {
                    JobNumberData.Items.Add(str);
                }

                UpdateView.DataSource = df;
                UpdateView.DataBind();



            }
        }


       


        protected void OrderNumberUpdate(object sender, EventArgs e)
        {
            //Gets the list of Steps and/or tasks for selected Order number when selected.
            List<string> OrderStepsTasks;
            StepTaskData.Items.Clear();
            StepTaskData.Items.Add("Please Select a Step or Task");
            StepTaskData.Enabled = true;

            OrderStepsTasks = Global.ReadDataList($"SELECT TASKNAME FROM ORDERS WHERE ORDERNUMBER = '{JobNumberData.SelectedValue}' ;");

            foreach (string str in OrderStepsTasks)
            {
                StepTaskData.Items.Add(str);

            }

            JobAssyData.Text = Global.ReadDataString($"SELECT TYPE FROM ORDERS WHERE ORDERNUMBER = '{JobNumberData.SelectedValue}' ;");
            CustData.Text = Global.ReadDataString($"SELECT CUSTOMER FROM ORDERS WHERE ORDERNUMBER = '{JobNumberData.SelectedValue}' ;");
        }


        protected void EditRow_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            List<string> OrderStepsTasks;
            if (e.CommandName == "EditTimeSheet")
            {
                int index = Convert.ToInt32(e.CommandArgument);

                if (UpdateView.Rows[index].Cells[1].Text == "NonCharge")
                {
                    Response.Write("<script>alert('You Cannot Edit this Row at the given time.');</script>");
                }
                else
                {

                    UpdateSelection.Visible = true;


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

        protected void BtnAcceptMUClick(object sender, EventArgs e)
        {
            if (sigPad.Visible == false)
            {

                btnAccept1MU.Visible = false;
                btnAccept2MU.Visible = true;
                signLabel.Visible = true;
                sigPad.Visible = true;
                clearBtn.Visible = true;

            }
            else if (sigPad.Visible == true)
            {
                List<string> empData = Session["empData"] as List<string>;

                DataFile OldData = Session["DataFile"] as DataFile;
                DataFile dataFile = new DataFile();
                dataFile.CreateHeader( Global.ReadDataString($"SELECT RESOURCENAME FROM EMPLOYEES WHERE EMPNAME='{empData[0]}';"), empData[1], Session["ManagerName"].ToString());

                DataTable dt = new DataTable();

               

                foreach (GridViewRow row in UpdateView.Rows)
                {
                    JobType jobType = (JobType)Enum.Parse(typeof(JobType), row.Cells[1].Text);
                    string orderNumber = row.Cells[2].Text;
                    string task = row.Cells[3].Text;

                    //Calculate 'time' in a float format


                    float time = Global.TimeToFloat(row.Cells[4].Text);




                    string customer = row.Cells[8].Text;

                    dataFile.AddData(jobType, orderNumber, task, time, customer);
                }

                
                dataFile.Export();
                Server.Transfer("ManagerViewScreen.aspx");

            }

           
        }


    }
}