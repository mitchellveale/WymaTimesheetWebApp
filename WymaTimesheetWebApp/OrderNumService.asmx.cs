using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Configuration;
using System.Diagnostics;

namespace WymaTimesheetWebApp
{
    /// <summary>
    /// Summary description for OrderNumService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class OrderNumService : System.Web.Services.WebService
    {

        [WebMethod]
        public List<string> GetOrderNumbers(string inputData)
        {
            inputData = inputData.Replace(" ", string.Empty);
            inputData = inputData.Replace("'", string.Empty);
            inputData = inputData.Replace(";", string.Empty);
            inputData = inputData.ToUpper();

            string query = "%";
            char[] charInput = inputData.ToCharArray();

            foreach (char ch in charInput)
            {
                query += ch.ToString() + "%";
            }

            Debug.WriteLine(query);

            List<string> data;
            data = Global.ReadDataList("SELECT FIRST 10 DISTINCT ORDERNUMBER FROM ORDERS WHERE ORDERNUMBER LIKE '" + query + "';" );
            return data;
        }
    }
}
