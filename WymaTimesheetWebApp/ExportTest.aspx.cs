using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WymaTimesheetWebApp
{
    public partial class ExportTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                for (int i = 0; i < Global.UnapprovedFiles.Count; i++)
                {
                    Dropdown.Items.Add(i.ToString());
                }
            }
        }

        protected void ButtonBoi_Click(object sender, EventArgs e)
        {
            if (Dropdown.Visible == true)
            {
                int index = int.Parse(Dropdown.SelectedValue);
                Global.DataFileInfo dfi = Global.UnapprovedFiles[index];
                Name.Visible = true;
                Name.Text = dfi.name;
                Date.Visible = true;
                Date.Text = dfi.date;
                Manager.Visible = true;
                Manager.Text = dfi.manager;
                Dropdown.Visible = false;
                ButtonBoi.Text = "Export";
            }
            else
            {
                Global.DataFileInfo dfi = Global.UnapprovedFiles[int.Parse(Dropdown.SelectedValue)];
                DataFile df = new DataFile();
                df.Read($"{dfi.name} {dfi.date} {dfi.manager}");
                df.Export();
                Server.Transfer("MainMenu.aspx", true);
            }
        }
    }
}