using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;


namespace WymaTimesheetWebApp
{
    [ScriptService]
    public partial class Testing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                DataTable table = new DataTable();
                table.Columns.Add("Column1");
                table.Columns.Add("Column2");
                table.Columns.Add("Column3");
                GridView1.DataSource = table;
                GridView1.DataBind();
                Session["tab"] = table;
            }
        }
        protected void AddButton_Click(object sender, EventArgs e)
        {
            DataTable table = Session["tab"] as DataTable;
            DataRow dr = table.NewRow();
            dr["Column1"] = TextBox1.Text;
            dr["Column2"] = TextBox2.Text;
            dr["Column3"] = TextBox3.Text;
            table.Rows.Add(dr);
            GridView1.DataSource = table;
            GridView1.DataBind();
            Session["tab"] = table;
        }
        [ScriptMethod()]
        [WebMethod]
        public static List<string> GetValues(string prefixText)
        {
            return new List<string>() { "suggestion1", "suggestion2", "suggestion3" };
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

 
                    
               
        

    }
}