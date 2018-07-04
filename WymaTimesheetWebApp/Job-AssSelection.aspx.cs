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
                //Provides Inital data for Infolist beside forms 

                string Name = Global.ReadDataString($"SELECT EMPNAME FROM EMPLOYEES WHERE RESOURCENAME='{Session["UsrName"].ToString()}';");
                Ordernumbers = Global.ReadDataList("SELECT DISTINCT ORDERNUMBER FROM ORDERS;");

                NameViewLabel.Text = Name;
                DateViewLabel.Text = Global.DictUsrData[Session["UsrName"].ToString()].Date;
                TotalHoursLabel.Text = Global.DictUsrData[Session["UsrName"].ToString()].TotalHours;
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
            

            if (TotalHoursLabel.Text != TotalHoursAppLabel.Text)
            {
                Response.Write("<script>alert('Please make sure the total hours you have applied equals the total hours you worked before submiting.');</script>");
            }
            else
            {
                DataTable CHTable = Session["CHtab"] as DataTable;
                DataTable NCTable = Session["NCtab"] as DataTable;

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
                string[] Tothours = TotalHoursAppLabel.Text.Split(' ');

                string[] HoursNum = Tothours[0].Split('h');
                string[] MinNum = Tothours[1].Split('m');

                int Hours = (int.Parse(HoursNum[0]) + int.Parse(CHHoursHSelection.Text));
                int Mins = (int.Parse(MinNum[0]) + int.Parse(CHHoursMSelection.Text));

                
                TotalHoursAppLabel.Text = $"{Hours.ToString()}h {Mins.ToString()}m"; 
            }
           




        }

        protected void BtnCHTableRemoveClick(object sender, EventArgs e)
        {
            //Removes a row from the table.
            DataTable CHTable = Session["CHtab"] as DataTable;
            if (CHTable.Rows.Count != 0)
            {
                //Updates the amount of hours applied (Subtraction)
                string[] Tothours = TotalHoursAppLabel.Text.Split(' ');

                string[] HoursNum = Tothours[0].Split('h');
                string[] MinNum = Tothours[1].Split('m');

                string[] HourMinRemove = CHTable.Rows[CHTable.Rows.Count - 1]["Hours:Mins"].ToString().Split(':');
                int Hours = (int.Parse(HoursNum[0]) - int.Parse(HourMinRemove[0]));
                int Mins = (int.Parse(MinNum[0]) - int.Parse(HourMinRemove[1]));


                TotalHoursAppLabel.Text = $"{Hours.ToString()}h {Mins.ToString()}m";

                //Deletes a row from table
                CHTable.Rows[CHTable.Rows.Count - 1].Delete();
                DataCHView.DataSource = CHTable;
                DataCHView.DataBind();
                Session["CHtab"] = CHTable;

                
            }
            
               

        }

        protected void BtnNCTableADDClick(object sender, EventArgs e)
        {
            if (NCCodeData.SelectedValue == "" || NCHoursMSelection.SelectedValue == "00" && NCHoursHSelection.SelectedValue == "00" || NCCommentBox.Text == "")
                Response.Write("<script>alert('Some fields do not have data please make sure that all fields are filled before adding a row.');</script>");
            else
            {
                //Updates the amount of hours applied(Addition)
                string[] Tothours = TotalHoursAppLabel.Text.Split(' ');

                string[] HoursNum = Tothours[0].Split('h');
                string[] MinNum = Tothours[1].Split('m');

                int Hours = (int.Parse(HoursNum[0]) + int.Parse(NCHoursHSelection.Text));
                int Mins = (int.Parse(MinNum[0]) + int.Parse(NCHoursMSelection.Text));


                TotalHoursAppLabel.Text = $"{Hours.ToString()}h {Mins.ToString()}m";

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

        protected void BtnNCTableRemoveClick(object sender, EventArgs e)
        {
            DataTable NCTable = Session["NCtab"] as DataTable;
            if (NCTable.Rows.Count != 0)
            {
                //Updates the amount of hours applied(Subtraction)
                string[] Tothours = TotalHoursAppLabel.Text.Split(' ');

                string[] HoursNum = Tothours[0].Split('h');
                string[] MinNum = Tothours[1].Split('m');

                string[] HourMinRemove = NCTable.Rows[NCTable.Rows.Count - 1]["Hours:Mins"].ToString().Split(':');
                int Hours = (int.Parse(HoursNum[0]) - int.Parse(HourMinRemove[0]));
                int Mins = (int.Parse(MinNum[0]) - int.Parse(HourMinRemove[1]));


                TotalHoursAppLabel.Text = $"{Hours.ToString()}h {Mins.ToString()}m";

                //Removes final row from Non-Charge Table
                NCTable.Rows[NCTable.Rows.Count - 1].Delete();
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

    }
}