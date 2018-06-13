using System;
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

                }
            }

            TableRow NewRow = GenerateJARow();
            JobsAssembliesTable.Rows.AddAt(JobsAssembliesTable.Rows.Count - 1, NewRow);


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



        protected void BtnJATableClick(object sender, EventArgs e)
        {

            //ListRows.Add(new Row());
           



        }

       
          
           

        

        


        //Generates a row for data to be inputed into
        private TableRow GenerateJARow()
        {
            
            TableRow r = new TableRow();
            for (int i = 0; i < 8; i++)
            {
                TableCell c = new TableCell();
                if (i == 3)
                {
                    c.Controls.Add(new TextBox());
                }
                else
                {
                    
                }
                r.Cells.Add(c);


            }
            r.Attributes.Add("Visable", "false");
            return r;
        }
    }
}