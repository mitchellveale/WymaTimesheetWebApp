﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WymaTimesheetWebApp
{
    public partial class ViewScreen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDoneVSClick(object sender, EventArgs e)
        {
            Global.DictUsrData.Remove(Server.HtmlEncode(Request.Cookies["UsrName"].Value));
            Request.Cookies["UsrName"].Value = null;
            Server.Transfer("MainMenu.aspx", true);
        }
        protected void btnBackVSClick(object sender, EventArgs e)
        {
            Server.Transfer("Job-AssSelection.aspx", true);
        }
    }
}