using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WymaTimesheetWebApp
{
    public partial class ManagerUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void EditRow_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void BtnBackMU(object sender, EventArgs e)
        {
            Server.Transfer("ManagerViewScreen.aspx");
        }

        protected void BtnAcceptMU(object sender, EventArgs e)
        {

        }
    }
}