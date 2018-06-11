using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace WymaTimesheetWebApp
{
    public partial class Testing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonBoiClick(object sender, EventArgs e)
        {
            StringBuilder stringBuilder = new StringBuilder();

            string a = "thing,otherThing";
            string b = "thang,otherThang";

            stringBuilder.AppendLine(a);
            stringBuilder.AppendLine(b);

            if (Global.WriteCSV(stringBuilder, "fuccBoi"))
            {
                LabelBoi.Text = "Done";
            }
            else
            {
                LabelBoi.Text = Global.errorLog;
            }
        }

    }
}