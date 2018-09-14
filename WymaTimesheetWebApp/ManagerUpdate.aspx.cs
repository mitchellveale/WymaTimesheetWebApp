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
                int index = Convert.ToInt32(e.CommandArgument);

                if (UpdateView.Rows[index].Cells[1].Text == "NonCharge")
                {
                    Response.Write("<script>alert('You Cannot Edit this Row at the given time.');</script>");
                }
                else
                {

                    UpdateSelection.Visible = true;


                    OrderNumberInput.Text = UpdateView.Rows[index].Cells[2].Text;

                    OrderStepsTasks = Global.ReadDataList($"SELECT TASKNAME FROM ORDERS WHERE ORDERNUMBER = '{OrderNumberInput.Text}' ;");
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

            sigPad.Visible = false;
            signLabel.Visible = false;
            SigImg.Visible = false;
            clearBtn.Visible = false;
            imgbtn.Visible = false;
            int index = int.Parse(Session["EditedRow"].ToString());

            //edit row with row number of index
            UpdateView.Rows[index].Cells[1].Text = JobAssyData.Text;
            UpdateView.Rows[index].Cells[2].Text = OrderNumberInput.Text;
            UpdateView.Rows[index].Cells[3].Text = StepTaskData.SelectedValue;
            UpdateView.Rows[index].Cells[5].Text = WyEUrefData.Text;
            UpdateView.Rows[index].Cells[6].Text = EUStepData.Text;
            UpdateView.Rows[index].Cells[7].Text = EUCustData.Text;
            UpdateView.Rows[index].Cells[8].Text = CustData.Text;



        }

        protected void BtnAcceptMUClick(object sender, EventArgs e)
        {
            UpdateSelection.Visible = true;

            if (sigPad.Visible == false && SigImg.Visible == false)
            {
                if (Global.signatureData.ContainsKey(Session["ManagerName"].ToString()))
                {
                    //Set the image to the image data for the signature.
                    SigImg.Visible = true;
                    SigImg.Src = Global.signatureData[Session["ManagerName"].ToString()];


                    signLabel.Text = "Stored Signature:";
                    signLabel.Visible = true;
                    imgbtn.Visible = true;
                    return;
                }
                btnAccept1MU.Visible = false;
                btnAccept2MU.Visible = true;
                signLabel.Visible = true;
                sigPad.Visible = true;
                clearBtn.Visible = true;

            }
            else if (sigPad.Visible == false && SigImg.Visible == true)
            {
                List<string> empData = Session["empData"] as List<string>;

                DataFile OldData = Session["DataFile"] as DataFile;
                DataFile dataFile = new DataFile();
                dataFile.CreateHeader(Global.ReadDataString($"SELECT RESOURCENAME FROM EMPLOYEES WHERE EMPNAME='{empData[0]}';"), empData[1], Session["ManagerName"].ToString());

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
                string sig = Global.signatureData[Session["ManagerName"].ToString()].Split(';')[1];
                dataFile.ManagerSignature = sig;
                OldData.Write(false, true);
                dataFile.Export(true);
                Server.Transfer("ManagerViewScreen.aspx");
            }
            else
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

                string sig = hiddenfield.Value.Split(';')[1];
                dataFile.ManagerSignature = sig;
                OldData.Write(false, true);
                dataFile.Export(true);
                Server.Transfer("ManagerViewScreen.aspx");

            }

           
        }

        protected void imgbtn_Click(object sender, EventArgs e)
        {
            SigImg.Visible = false;
            sigPad.Visible = true;
            imgbtn.Visible = false;
            clearBtn.Visible = true;
            Global.signatureData.Remove(Session["ManagerName"].ToString());
            signLabel.Text = "Sign Here:";
            btnAccept1MU.Visible = false;
            btnAccept2MU.Visible = true;
        }
    }
}