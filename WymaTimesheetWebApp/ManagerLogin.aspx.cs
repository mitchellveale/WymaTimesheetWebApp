using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WymaTimesheetWebApp
{
    public partial class ManagerLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmitMLClick(object sender, EventArgs e)
        {
            if (ManagerInput.Value.ToString() == "42069")
                Server.Transfer("ManagerViewScreen.aspx", true);
        }

        protected void BtnBackMLClick(object sender, EventArgs e)
        {
            Server.Transfer("MainMenu.aspx", true);
        }
    }
}