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
                if (Global.DictRows.ContainsKey(Request.Cookies["UsrName"].Value))
                {
                    Global.DictRows[Request.Cookies["UsrName"].Value] = listRows;
                }

            }
            get
            {
                return listRows;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Provides Inital data for Infolist beside tables
                if (Request.Cookies["UsrName"] != null)
                {
                    NameViewLabel.Text = Request.Cookies["UsrName"].Value;
                    DateViewLabel.Text = Global.DictUsrData[Request.Cookies["UsrName"].Value].Date;
                    TotalHoursLabel.Text = Global.DictUsrData[Request.Cookies["UsrName"].Value].TotalHours;
                    TotalHoursAppLabel.Text = "0h 0m";

                    for (int i = 0; i <= 24; i++)
                    {
                        if (i >=0 && i <= 9)
                        {
                            HoursHSelection.Items.Add("0" + Convert.ToString(i));
                        }
                        else
                            HoursHSelection.Items.Add(Convert.ToString(i));

                    }
                        
                    for (int i = 0; i <= 59; i++)
                    {
                        if (i >= 0 && i <= 9)
                        {
                            HoursMSelection.Items.Add("0" + Convert.ToString(i));
                        }
                        else
                            HoursMSelection.Items.Add(Convert.ToString(i));

                    }
                        

                }

                DataTable JAtable = new DataTable();
                JAtable.Columns.Add("Job/Assy");
                JAtable.Columns.Add("Number");
                JAtable.Columns.Add("Step/Task");
                JAtable.Columns.Add("Hours:Min");
                JAtable.Columns.Add("WyEU REF");
                JAtable.Columns.Add("EU Step/Task");
                JAtable.Columns.Add("EU Cust");
                JAtable.Columns.Add("Customer");
                DataJAView.DataSource = JAtable;
                DataJAView.DataBind();
                Session["tab"] = JAtable;
            }

            


        }






        protected void BtnSubmitHSClick(object sender, EventArgs e)
        {
            Server.Transfer("ViewScreen.aspx", true);
        }

        protected void BtnBackHSClick(object sender, EventArgs e)
        {
            Global.DictUsrData.Remove(Server.HtmlEncode(Request.Cookies["UsrName"].Value));
            Server.Transfer("DateAndTime.aspx", true);
        }



        protected void BtnJATableADDClick(object sender, EventArgs e)
        {
            DataTable JAtable = Session["tab"] as DataTable;
            DataRow dr = JAtable.NewRow();
            dr["Job/Assy"] = JobAssyData.Text;
            dr["Number"] = JobNumberData.SelectedValue;
            dr["Step/Task"] = StepTaskData.SelectedValue;
            dr["Hours:Min"] = HoursHSelection.Text + ":" + HoursMSelection.Text;
            dr["WyEU REF"] = WyEUrefData.Text;
            dr["EU Step/Task"] = EUStepData.Text;
            dr["EU Cust"] = EUCustData.Text;
            dr["Customer"] = CustData.Text;
            JAtable.Rows.Add(dr);
            DataJAView.DataSource = JAtable;
            DataJAView.DataBind();
            Session["tab"] = JAtable;




        }

        protected void BtnJATableRemoveClick(object sender, EventArgs e)
        {
            DataTable JATable = Session["tab"] as DataTable;
            JATable.Rows[JATable.Rows.Count].Delete();
        }

       
    }
}