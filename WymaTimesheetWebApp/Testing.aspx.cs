using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WymaTimesheetWebApp
{
    public partial class Testing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DataTable table = new DataTable();
                table.Columns.Add("Number");
                DataJAView.DataSource = table;
                DataJAView.DataBind();
                Session["tab"] = table;
            }
            
        }

        protected void BtnJATableClick(object sender, EventArgs e)
        {
            
            DataTable table = Session["tab"] as DataTable;
            DataRow dr = table.NewRow();
            dr["Number"] = NumberData.SelectedValue;
            table.Rows.Add(dr);
            DataJAView.DataSource = table;
            DataJAView.DataBind();
            Session["tab"] = table;
        }

        
                    
               
        

    }
}