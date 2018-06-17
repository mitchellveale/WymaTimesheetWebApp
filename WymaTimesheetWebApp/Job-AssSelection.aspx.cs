using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WymaTimesheetWebApp
{
    public partial class Job_AssSelection : System.Web.UI.Page
    {
        public List<Row> listRows;
        private List<Row> ListRows
        {
            set
            {
                if (Global.DictRows.ContainsKey(Session["UsrName"].ToString()))
                {
                    Global.DictRows[Session["UsrName"].ToString()] = listRows;
                }

            }
            get
            {
                return listRows;
            }
        }

        private List<string> Ordernumbers;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Provides Inital data for Infolist beside tables

                string Name = Global.ReadDataString($"SELECT EMPNAME FROM EMPLOYEES WHERE RESOURCENAME='{Session["UsrName"].ToString()}';");
                Ordernumbers = Global.ReadDataList("SELECT ORDERNUMBER FROM ORDERS;");

                NameViewLabel.Text = Session["UsrName"].ToString();
                DateViewLabel.Text = Global.DictUsrData[Session["UsrName"].ToString()].Date;
                TotalHoursLabel.Text = Global.DictUsrData[Session["UsrName"].ToString()].TotalHours;
                TotalHoursAppLabel.Text = "0h 0m";

                JobNumberData.Items.Add("Please Select an Order Number");
                foreach (string str in Ordernumbers)
                {
                    if (JobNumberData.Items.FindByText(str) == null)
                    {
                        JobNumberData.Items.Add(str);
                    }

                }

                StepTaskData.Items.Add("Please Select a Step or Task");

                
                    for (int i = 0; i <= 10; i++)
                    {
                        if (i >=0 && i <= 9)
                        {
                            CHHoursHSelection.Items.Add("0" + Convert.ToString(i));
                            NCHoursHSelection.Items.Add("0" + Convert.ToString(i));
                        }
                        else
                        {
                            CHHoursHSelection.Items.Add(Convert.ToString(i));
                            NCHoursHSelection.Items.Add(Convert.ToString(i));
                        }
                            

                    }
                        
                    for (int i = 0; i <= 3; i++)
                    {
                        CHHoursMSelection.Items.Add(Convert.ToString(i * 15));
                        NCHoursMSelection.Items.Add(Convert.ToString(i * 15));
                    }
                        
               

                DataTable CHTable = new DataTable();
                CHTable.Columns.Add("Job/Assy");
                CHTable.Columns.Add("Number");
                CHTable.Columns.Add("Step/Task");
                CHTable.Columns.Add("Hours:Mins");
                CHTable.Columns.Add("WyEU REF");
                CHTable.Columns.Add("EU Step/Task");
                CHTable.Columns.Add("EU Cust");
                CHTable.Columns.Add("Customer");
                DataCHView.DataSource = CHTable;
                DataCHView.DataBind();
                Session["CHtab"] = CHTable;

                DataTable NCTable = new DataTable();
                NCTable.Columns.Add("NC Code");
                NCTable.Columns.Add("Hours:Mins");
                NCTable.Columns.Add("Non-Charge Comment");
                DataNCView.DataSource = NCTable;
                DataNCView.DataBind();
                Session["NCtab"] = NCTable;


            }

            


        }






        protected void BtnSubmitHSClick(object sender, EventArgs e)
        {
            Server.Transfer("ViewScreen.aspx", true);
        }

        protected void BtnBackHSClick(object sender, EventArgs e)
        {
            Global.DictUsrData.Remove(Session["UsrName"].ToString());
            Server.Transfer("DateAndTime.aspx", true);
        }



        protected void BtnCHTableADDClick(object sender, EventArgs e)
        {
            if (JobNumberData.SelectedValue == "Please Select an Order Number" || StepTaskData.SelectedValue == "Please Select a Step or Task" || CHHoursHSelection.SelectedValue == "00")
                Response.Write("<script>alert('Some fields do not have data please make sure that all fields are filled before adding a row.');</script>");
            else
            {
                DataTable CHTable = Session["CHtab"] as DataTable;
                DataRow dr = CHTable.NewRow();
                dr["Job/Assy"] = JobAssyData.Text;
                dr["Number"] = JobNumberData.SelectedValue;
                dr["Step/Task"] = StepTaskData.SelectedValue;
                dr["Hours:Mins"] = CHHoursHSelection.SelectedValue + ":" + CHHoursMSelection.SelectedValue;
                dr["WyEU REF"] = WyEUrefData.Text;
                dr["EU Step/Task"] = EUStepData.Text;
                dr["EU Cust"] = EUCustData.Text;
                dr["Customer"] = CustData.Text;
                CHTable.Rows.Add(dr);
                DataCHView.DataSource = CHTable;
                DataCHView.DataBind();
                Session["CHtab"] = CHTable;
            }
           




        }

        protected void BtnCHTableRemoveClick(object sender, EventArgs e)
        {
            DataTable JATable = Session["CHtab"] as DataTable;
            if (JATable.Rows.Count != 0)
            {
                JATable.Rows[JATable.Rows.Count - 1].Delete();
                DataCHView.DataSource = JATable;
                DataCHView.DataBind();
                Session["CHtab"] = JATable;
            }
            
               

        }

        protected void NCTableAddClick(object sender, EventArgs e)
        {
            if (NCCodeData.SelectedValue == "" || NCHoursHSelection.SelectedValue == "00" || NCCommentBox.Text == "")
                Response.Write("<script>alert('Some fields do not have data please make sure that all fields are filled before adding a row.');</script>");
            else
            {
                DataTable NCTable = Session["NCtab"] as DataTable;
                DataRow dr = NCTable.NewRow();
                dr["NC Code"] = NCCodeData.SelectedValue;
                dr["Hours:Mins"] = NCHoursHSelection.SelectedValue + ":" + NCHoursMSelection.SelectedValue;
                dr["Non-Charge Comment"] = NCCommentBox.Text;
                NCTable.Rows.Add(dr);
                DataNCView.DataSource = NCTable;
                DataNCView.DataBind();
                Session["NCtab"] = NCTable;
            }
        }

        protected void NCTableRemoveClick(object sender, EventArgs e)
        {
            DataTable NCTable = Session["NCtab"] as DataTable;
            if (NCTable.Rows.Count != 0)
            {
                NCTable.Rows[NCTable.Rows.Count - 1].Delete();
                DataNCView.DataSource = NCTable;
                DataNCView.DataBind();
                Session["NCtab"] = NCTable;
            }
        }

        protected void OrderNumberUpdate(object sender, EventArgs e)
        {
            List<string> OrderStepsTasks;
            StepTaskData.Items.Clear();
            StepTaskData.Items.Add("Please Select a Step or Task");
            StepTaskData.Enabled = true;

            OrderStepsTasks = Global.ReadDataList($"SELECT TASKNAME FROM ORDERS WHERE ORDERNUMBER = '{JobNumberData.SelectedValue}' ;");

            foreach (string str in OrderStepsTasks)
            {        
                    StepTaskData.Items.Add(str);
               
            }

        }

    }
}