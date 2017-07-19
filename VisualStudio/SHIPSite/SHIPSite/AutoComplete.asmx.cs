using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace SHIPSite
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        [ScriptMethod]
        public string[] GetCompletionList(string prefixText, int count)
        {
            List<string> ret = new List<string>();
            MySqlConnection conn = new MySqlConnection();
            string myConnectionString = "server=localhost;uid=user;pwd=Userp4ss;database=testdata;";
            conn.ConnectionString = myConnectionString;
            MySqlCommand cmd = new MySqlCommand("search_autocomplete", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("query", prefixText);
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                int c = 0;
                while (reader.Read() && c < count)
                {
                    ret.Add(reader.GetString("title"));
                    c++;
                }
            }
            catch (MySqlException ex) { }
            return ret.ToArray();
        }
    }
}
