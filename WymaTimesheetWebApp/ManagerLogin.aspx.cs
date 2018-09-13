using System;
using System.Collections.Generic;
using System.Diagnostics;
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
           
            string ManagerName = Global.ReadDataString("SELECT RESOURCENAME FROM EMPLOYEES WHERE CODE = '" + ManagerInput.Text + "';");
           

            if (ManagerName == "")
                Response.Write(@"<script>alert('That is not a valid manager number.\nPlease Try Again.')</script>");
            else
            {
                if (ManagerName == "!ERROR!")
                    Response.Write(@"<script>alert('Login information cannot be validated.\nPlease Try Again.\nIf this problem persists, please contact your network administrator.')</script>");
                else
                {
                    Session["ManagerName"] = ManagerName;
                    Debug.WriteLine("Checking If signature exists");
                    if (Global.signatureData.ContainsKey(Session["ManagerName"].ToString()))
                    {
                        Debug.WriteLine("Signature exists, Removing...");
                        Global.signatureData.Remove(Session["ManagerName"].ToString());
                    }
                    Server.Transfer("ManagerViewScreen.aspx", true);
                }
                
            }
        }
            
            
        

        protected void BtnBackMLClick(object sender, EventArgs e)
        {
            Server.Transfer("MainMenu.aspx", true);
        }
    }
}