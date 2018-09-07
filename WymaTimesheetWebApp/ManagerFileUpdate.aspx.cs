using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WymaTimesheetWebApp
{
    public partial class ManagerFileUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void OrderNumberUpdate(object sender, EventArgs e)
        {
            //Gets the list of Steps and/or tasks for selected Order number when selected.
            List<string> OrderStepsTasks;
            StepTaskData.Items.Clear();
            StepTaskData.Items.Add("Please Select a Step or Task");
            StepTaskData.Enabled = true;

            OrderStepsTasks = Global.ReadDataList($"SELECT TASKNAME FROM ORDERS WHERE ORDERNUMBER = '{JobNumberData.SelectedValue}' ;");

            foreach (string str in OrderStepsTasks)
            {
                StepTaskData.Items.Add(str);

            }

            
        }

        protected void BtnTableUpdateClick(object sender, EventArgs e)
        {

        }

        protected void BtnDoneMUClick(object sender, EventArgs e)
        {

        }

        protected void BtnBackMUClick(object sender, EventArgs e)
        {

        }

        protected void Update_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}