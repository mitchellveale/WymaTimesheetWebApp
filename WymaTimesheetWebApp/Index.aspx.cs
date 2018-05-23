using System;
using System.Data;
using System.IO;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FirebirdSql.Data.FirebirdClient;

namespace WymaTimesheetWebApp
{
    public partial class Index : System.Web.UI.Page
    {
        private Global global = new Global();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void MainButton_Click(object sender, EventArgs e)
        {
            ConnectFDB();
        }
        public void ConnectFDB()
        {
            try
            {
                FbCommand cmd = new FbCommand("insert into Details(id, fName, lName, Age) values (@id, @fName, @lName, @Age);");
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@id", 6);
                cmd.Parameters.Add("@fName", "Testy");
                cmd.Parameters.Add("@lName", "McTestFace");
                cmd.Parameters.Add("@Age", 69);

                String serverIP = IPInput.Text;
                IPInput.Visible = false;
                IPLabel.Visible = false;
                MainButton.Visible = false;


                using (cmd.Connection = new FbConnection($@"Server={serverIP};User=SYSDBA;Password=masterkey;Database={serverIP}:D:\fdb\testdb.fdb;ServerType=0;Port=3050;"))
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
                    TitleLabel.Text = "Connection Successful And Data Uploaded.";

            }
            catch (Exception e)
            {
                TitleLabel.Text = e.ToString();
            }
        }

    }
}