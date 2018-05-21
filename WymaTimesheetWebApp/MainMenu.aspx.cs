using System;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace WymaTimesheetWebApp
{
    public partial class MainMenu : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }
<<<<<<< HEAD

        protected void Buttion_Employee_Click(object sender, EventArgs e)
        {
            
            Server.Transfer("DateAndTime.aspx", true);
        }
     }
=======
        protected void ButtonEmployeeClick(object sender, EventArgs e)
        {
            Server.Transfer("DateAndTime.aspx", true);
        }

        protected void ButtonManagerClick(object sender, EventArgs e)
        {
            string ManagerIDInput = Microsoft.VisualBasic.Interaction.InputBox("Please Input Manager ID Code.", "Manager Input");
            


        }
    }
>>>>>>> Main-Menu
}