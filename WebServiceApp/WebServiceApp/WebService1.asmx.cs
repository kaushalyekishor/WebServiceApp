using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using Newtonsoft.Json;

namespace WebServiceApp
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        DataTable dtCountries = new DataTable();

        string[,] stocks =
          {
             {"RELIND", "Reliance Industries", "1060.15"},
             {"ICICI", "ICICI Bank", "911.55"},
              {"JSW", "JSW Steel", "1201.25"},
             {"WIPRO", "Wipro Limited", "1194.65"},
             {"SATYAM", "Satyam Computers", "91.10"}
         };


        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public int Sum(int a, int b)
        {
            return a + b;
        }

        [WebMethod]
        public string State()
        {
            dtCountries.Columns.Add("CountyName");
            dtCountries.Columns.Add("Continent");

            dtCountries.Rows.Add("India", "Asia");
            dtCountries.Rows.Add("Pakistan", "Asia");
            dtCountries.Rows.Add("Germany", "Europe");
            dtCountries.Rows.Add("SriLanka", "Asia");
            dtCountries.Rows.Add("Australia", "Australia");
            dtCountries.Rows.Add("New Zealand", "Australia");

            return JsonConvert.SerializeObject(dtCountries);
        }

        [WebMethod]
        public double GetPrice(string symbol)
        {
            //it takes the symbol as parameter and returns price
            for (int i = 0; i < stocks.GetLength(0); i++)
            {
                if (String.Compare(symbol, stocks[i, 0], true) == 0)
                    return Convert.ToDouble(stocks[i, 2]);
            }
            return 0;
        }

        [WebMethod]
        public string GetName(string symbol)
        {
            // It takes the symbol as parameter and 
            // returns name of the stock
            for (int i = 0; i < stocks.GetLength(0); i++)
            {
                if (String.Compare(symbol, stocks[i, 0], true) == 0)
                    return stocks[i, 1];
            }

            return "Stock Not Found";
        }
    }
}
