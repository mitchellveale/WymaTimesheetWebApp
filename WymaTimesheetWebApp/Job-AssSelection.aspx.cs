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

        private int TotRows;
        private string TotCookieRows;

        protected void Page_Load(object sender, EventArgs e)
        {
            //For Safety Reasons provents Malisous Code from running on cookie
            if(Request.Cookies["TotRows"] != null)
            {
                TotRows = Int32.Parse(Server.HtmlEncode(Request.Cookies["TotRows"].Value));        
            }
            
        }

        

        


        protected void BtnSubmitHSClick(object sender, EventArgs e)
        {
            Server.Transfer("ViewScreen.aspx", true);
        }

        protected void BtnBackHSClick(object sender, EventArgs e)
        {
            Server.Transfer("DateAndTime.aspx", true);
        }

       

       protected void BtnJATableClick(object sender, EventArgs e)
        {

            if(Request.Cookies["TotRows"] != null)
            {
                HttpCookie aCookie = Request.Cookies["TotRows"];
                TotRows = Int32.Parse(Server.HtmlEncode(aCookie.Value));
            }

            for (int i = 2 ; i <= TotRows; i++)
            {
                JobsAssembliesTable.Rows.AddAt(i - 1,GenerateJARow());
            }

            TotRows++;

            TotCookieRows = TotRows.ToString();
            
            HttpCookie ROWCookie = new HttpCookie("TotRows");
            ROWCookie.Value = TotCookieRows;
            Response.Cookies.Add(ROWCookie);


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
                    c.Controls.Add(new DropDownList());
                }
                r.Cells.Add(c);


            }
            r.Attributes.Add("Visable", "false");
            return r;
        }
    }
}