using System;
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
            if(!IsPostBack)
            {

                for (int i = 0; i <= 59; i++)
                {
                    if (i == 0)
                        SelMin.Items.Add("Please Select a Time");
                    else if (i == 1)
                        SelMin.Items.Add(i + " min");
                    else
                        SelMin.Items.Add(i + " mins");
                }

                for (int i = 0; i <= 1; i++)
                {
                    if (i == 0)
                        NamePicker.Items.Add("Please Select a Name");
                    else
                    {
                        NamePicker.Items.Add("John");
                        NamePicker.Items.Add("Jack");
                    }

                }

            }
            
        }

        protected void BtnSubmitDTClick(object sender, EventArgs e)
        {
            if (DateBox.Value == "" || TimeStartINP.Value == "" || TimeEndINP.Value == "" || SelMin.SelectedValue == "Please Select a Time" || NamePicker.SelectedValue == "Please Select a Name")
                Response.Write("<script>alert('Some fields are missing data. Please make sure all fields have data in them.');</script>");
            else
            {
                UsrData NewUsr = new UsrData(NamePicker.SelectedValue, DateBox.Value, TimeStartINP.Value, TimeEndINP.Value, SelMin.SelectedValue);

    
                Global.DictUsrData.Add(NamePicker.SelectedValue, NewUsr);
                Response.Cookies["UsrName"].Value = NamePicker.SelectedValue;
                
                Server.Transfer("Job-AssSelection.aspx", true);

                //UsrData Data = Global.DicUsrData[NamePicker.SelectedValue];

                //Response.Write("<script>alert('" + Data.Name + Data.Date + "');</script>");
            }
            

            
            
            
           
            


        }

        protected void BtnCancelDTClick(object sender, EventArgs e)
        {
            Server.Transfer("MainMenu.aspx", true);
        }

    }
}