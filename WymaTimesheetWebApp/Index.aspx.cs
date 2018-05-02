using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WymaTimesheetWebApp
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void MainButton_Click(object sender, EventArgs e)
        {
            string name = RetrieveInputFieldData();
            if (name == "")
                return;
            GreetingLabel.Text = $"Hello {name}!";
            GreetingLabel.Visible = true;
        }

        private string RetrieveInputFieldData()
        {
            string data = InputField.Text;
            return data;
        }
    }
}