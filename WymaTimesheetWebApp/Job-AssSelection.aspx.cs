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
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UsrName"] != null)
                DateViewLabel.Text = Global.DicUsrData[Server.HtmlEncode(Request.Cookies["UsrName"].Value)].Date;
            if (Request.Cookies["UsrName"] != null)
                DateViewLabel.Text = Global.DicUsrData[Server.HtmlEncode(Request.Cookies["UsrName"].Value)].Date;
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

           
            


        }

        public void CreateRow()
        {
            
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