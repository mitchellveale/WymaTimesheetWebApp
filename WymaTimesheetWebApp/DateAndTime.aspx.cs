﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WymaTimesheetWebApp
{
    public partial class DateAndTime : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSubmitDTClick(object sender, EventArgs e)
        {
            Server.Transfer("Job-AssSelection.aspx", true);
        }

        protected void BtnCancelDTClick(object sender, EventArgs e)
        {
            Server.Transfer("MainMenu.aspx", true);
        }

    }
}