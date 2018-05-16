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
                cmd.Parameters.Add("@id", 5);
                cmd.Parameters.Add("@fName", "Brayden");
                cmd.Parameters.Add("@lName", "Charleston");
                cmd.Parameters.Add("@Age", 18);

                using (cmd.Connection = new FbConnection(@"Server=10.1.119.94;User=SYSDBA;Password=masterkey;Database=10.1.119.94:D:\fdb\testdb.fdb;ServerType=0;"))
                {
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                }
                    TitleLabel.Text = "Data Uploaded.";

            }
            catch (Exception e)
            {
                TitleLabel.Text = e.ToString();
            }
        }

    }
}