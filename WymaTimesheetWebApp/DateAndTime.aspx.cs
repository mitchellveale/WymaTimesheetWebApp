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
        private List<string> DBDataNames;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                //adds times to lunchbreak selection box.
                for (int i = 0; i <= 4; i++)
                {
                    if (i == 0)
                        SelMin.Items.Add("Please Select a Time");
                    else
                        SelMin.Items.Add(i * 15 + " mins");
                }
                //Sets Start time to 7am and end time to 3:30
                TimeStartINP.Text = "07:00";
                TimeEndINP.Text = "15:30";


                //Sets Lunch Break time by defult to 30mins 
                SelMin.SelectedValue = "30 mins";

                //Sets date by defult today
                DateBox.Text = DateTime.Today.ToString("yyyy-MM-dd");


                //Takes data from database and places a list of the names in this varible. 
                DBDataNames = Global.ReadDataList("SELECT resourceName FROM Employees;");

                //Adds names to Name Selection Box.
                NamePicker.Items.Add("Please Select a Name");
              
                //If there is an error connecting to database the only namw will be john this is for testing purposes. Bellow here is where names are added.
                if (DBDataNames[0] == "!ERROR!")
                {
                    Response.Write("<script>alert('Database Connection Failed. Please Contact your System Administrator.');</script>");
                    Server.Transfer("MainMenu.aspx");
                }
                else
                {
                    foreach (string str in DBDataNames)
                    {
                        NamePicker.Items.Add(str);
                    }
                }

            }
            

        }

        protected void BtnSubmitDTClick(object sender, EventArgs e)
        {
            float timeFloat;
            
            try
            {
                //Changes the two set hours to work between and selected lunch break time and converts it to usable data.
                string totalHours = (Convert.ToDateTime(TimeEndINP.Text).Subtract(Convert.ToDateTime(TimeStartINP.Text).AddMinutes(((int.Parse(SelMin.SelectedValue.Substring(0, 2))))))).ToString();

                //Time looks like this 09:00:00
                timeFloat = Global.TimeToFloat(totalHours.Replace(':', ' '));
              
            }
            catch
            {
                Response.Write("<script>alert('Please Select Valid Start and End Times.');</script>");
                return;
            }

            //Checks weather all forms are filled before continuing. This is to make sure not only that the user does not miss anything but to stop errors from occuring with the data.
            if (DateBox.Text == "" || TimeStartINP.Text == "" || TimeEndINP.Text == "" || SelMin.SelectedValue == "Please Select a Time" || NamePicker.SelectedValue == "Please Select a Name")
                //Alerts the user if they are missing data
                Response.Write("<script>alert('Some fields are missing data. Please make sure all fields have data in them.');</script>");
            //Checks weather or not the user has inputed a valid time.
            else if (timeFloat > 24.00)
            {
                //Alerts the user that their times are invalid
                Response.Write("<script>alert('Your time at work is not valid. Please review and try again.');</script>");
                NameLable.Text = "Name: ";
            }

            else
            {
                

                //Saves user localy to use for other things within the app such as taking data out of Usr Dictonary
                Session["UsrName"] = null;
                Session["UsrName"] = NamePicker.SelectedValue;


                if (Global.DictUsrData.ContainsKey(NamePicker.SelectedValue))
                    Global.DictUsrData.Remove(NamePicker.SelectedValue);
               

                //Creates a NewUsr using the data provided. This will be used later in the program and when making the "" file
                UsrData NewUsr = new UsrData(NamePicker.SelectedValue, DateBox.Text, TimeStartINP.Text, TimeEndINP.Text, SelMin.SelectedValue, timeFloat);

                //Adds new user to a Usr Dictonary 
                Global.DictUsrData.Add(NamePicker.SelectedValue, NewUsr);
            
                if (Global.CHDATA.ContainsKey(NamePicker.SelectedValue))
                    Global.CHDATA.Remove(NamePicker.SelectedValue);

                if (Global.NCDATA.ContainsKey(NamePicker.SelectedValue))
                    Global.NCDATA.Remove(NamePicker.SelectedValue);

                //Takes Usr to next page.
                Server.Transfer("Job-AssSelection.aspx", true);
                



            }
            

        }
        
        //Checks whether text has changed within the page.
        protected void TextChanged(object sender, EventArgs e)
        { 

            string Name = Global.ReadDataString($"SELECT EMPNAME FROM EMPLOYEES WHERE RESOURCENAME='{NamePicker.SelectedValue}';");
            NameLable.Text = $"Name: {Name}";

        }

        protected void BtnCancelDTClick(object sender, EventArgs e)
        { 

            //Retuns user to prevous page.
            Server.Transfer("MainMenu.aspx");
        }

        
    }

}