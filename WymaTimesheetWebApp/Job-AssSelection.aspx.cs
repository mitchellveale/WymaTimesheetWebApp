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
        // List of Ordernumbers to allow order numbers to be stored from Database
        private List<string> Ordernumbers;


        protected void Page_Load(object sender, EventArgs e)
        {
            //will only run when the first instance of a page is loaded
            if (!IsPostBack)
            {
                string userName = Session["UsrName"].ToString();
                //Provides Inital data for Infolist beside forms

                string Name = Global.ReadDataString($"SELECT EMPNAME FROM EMPLOYEES WHERE RESOURCENAME='{Session["UsrName"].ToString()}';");
                Ordernumbers = Global.ReadDataList("SELECT DISTINCT ORDERNUMBER FROM ORDERS;");

                NameViewLabel.Text = Name;
                DateViewLabel.Text = Global.DictUsrData[userName].Date;

                TotalHoursLabel.Text = Global.TimeToString(Global.DictUsrData[userName].TotalHours);

                TotalHoursAppLabel.Text = "0h 0m";

                //Sets inital data in forms for users to select from. 
                JobNumberData.Items.Add("Please Select an Order Number");
                foreach (string str in Ordernumbers)
                {
                    JobNumberData.Items.Add(str);
                }


                NCCodeData.Items.Add("Please Select an Order Number");
                NCCodeData.Items.Add("TEST");


                StepTaskData.Items.Add("Please Select a Step or Task");


                for (int i = 0; i <= 10; i++)
                {
                    if (i >= 0 && i <= 9)
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
                    if (i == 0)
                    {
                        CHHoursMSelection.Items.Add("00");
                        NCHoursMSelection.Items.Add("00");
                    }
                    else
                    {
                        CHHoursMSelection.Items.Add(Convert.ToString(i * 15));
                        NCHoursMSelection.Items.Add(Convert.ToString(i * 15));
                    }

                }


                //Creates DataTables for data to be inputed into. This is for both Jobs and Assemblies and for Non-Charge Activities aswell.
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

            //Checks if total hours is accurate to hours appied and then saves data and sends user to next page.
            if (TotalHoursLabel.Text != TotalHoursAppLabel.Text)
            {
                Response.Write("<script>alert('Please make sure the total hours you have applied equals the total hours you worked before submiting.');</script>");
            }
            else
            {
                DataTable CHTable = Session["CHtab"] as DataTable;
                DataTable NCTable = Session["NCtab"] as DataTable;

                Global.UserData.Remove(Session["UsrName"].ToString());
                Global.CHDATA.Add(Session["UsrName"].ToString(), CHTable);
                Global.NCDATA.Add(Session["UsrName"].ToString(), NCTable);
                Server.Transfer("ViewScreen.aspx", true);
            }

        }

        protected void BtnBackHSClick(object sender, EventArgs e)
        {
            Global.DictUsrData.Remove(Session["UsrName"].ToString());
            Server.Transfer("DateAndTime.aspx", true);
        }



        protected void BtnCHTableADDClick(object sender, EventArgs e)
        {

            bool containsValue = false;
            DataTable CHTable = Session["CHtab"] as DataTable;

            //checks weather a step or task has already been inputed into the data table.
            foreach (DataRow dr in CHTable.Rows)
            {
                if (dr["Step/Task"].ToString() == StepTaskData.SelectedValue && dr["Number"].ToString() == JobNumberData.SelectedValue)
                {
                    containsValue = true;
                }

            }
            //Checks weather forms are filled in before allowing user to input data.
            if (JobNumberData.SelectedValue == "Please Select an Order Number" || StepTaskData.SelectedValue == "Please Select a Step or Task" || CHHoursHSelection.SelectedValue == "00" && CHHoursMSelection.SelectedValue == "00")
                Response.Write("<script>alert('Some fields do not have data please make sure that all fields are filled before adding a row.');</script>");
            else if (containsValue == true)
                Response.Write("<script>alert('You have already inputed this Step or Task for this Order Number please remove and try again.');</script>");
            else
            {



                //Adds data to tables and allows it to be viewed.

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

                //Updates the amount of hours applied(Addition)

                float Tothours = Global.TimeToFloat(TotalHoursAppLabel.Text);
                float Addedhours = Global.TimeToFloat(CHHoursHSelection.Text + " " + CHHoursMSelection.Text);

                TotalHoursAppLabel.Text = Global.TimeToString(Tothours + Addedhours);
            }
        }


        protected void BtnNCTableADDClick(object sender, EventArgs e)
        {
            if (NCCodeData.SelectedValue == "" || NCHoursMSelection.SelectedValue == "00" && NCHoursHSelection.SelectedValue == "00" || NCCommentBox.Text == "")
                Response.Write("<script>alert('Some fields do not have data please make sure that all fields are filled before adding a row.');</script>");
            else
            {
                //Updates the amount of hours applied(Addition)
                float Tothours = Global.TimeToFloat(TotalHoursAppLabel.Text);
                float Addedhours = Global.TimeToFloat(NCHoursHSelection.Text + " " + NCHoursMSelection.Text);

                TotalHoursAppLabel.Text = Global.TimeToString(Tothours + Addedhours);


                //Adds selected data to Non-Charge table
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


        protected void DataCHView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Removes Charge Hours Row from button
            DataTable CHTable = Session["CHtab"] as DataTable;
            if (e.CommandName == "RemoveRow")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                float Tothours = Global.TimeToFloat(TotalHoursAppLabel.Text);
                float Removedhours = Global.TimeToFloat(CHTable.Rows[index]["Hours:Mins"].ToString().Replace(':', ' '));

                TotalHoursAppLabel.Text = Global.TimeToString(Tothours - Removedhours);

                //Deletes a row from table
                CHTable.Rows[index].Delete();
                DataCHView.DataSource = CHTable;
                DataCHView.DataBind();
                Session["CHtab"] = CHTable;
            }
            
        }

        protected void DataNCView_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            DataTable NCTable = Session["NCtab"] as DataTable;
            if (e.CommandName == "RemoveRow")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                float Tothours = Global.TimeToFloat(TotalHoursAppLabel.Text);
                float Removedhours = Global.TimeToFloat(NCTable.Rows[index]["Hours:Mins"].ToString().Replace(':', ' '));

                TotalHoursAppLabel.Text = Global.TimeToString(Tothours - Removedhours);

                //Deletes a row from table
                NCTable.Rows[index].Delete();
                DataNCView.DataSource = NCTable;
                DataNCView.DataBind();
                Session["NCtab"] = NCTable;
            }
        }
    }
}