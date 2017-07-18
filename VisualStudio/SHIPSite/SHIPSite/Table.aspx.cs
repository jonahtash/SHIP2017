using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebMatrix.Data;
using MySql.Data.MySqlClient;
namespace SHIPSite
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        public List<Row> GetTable()
        {
            List<Row> ret = new List<Row>();
            MySqlConnection conn = new MySqlConnection();
            string myConnectionString = "server=localhost;uid=user;pwd=Userp4ss;database=testdata;";
            conn.ConnectionString = myConnectionString;
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM testdata";
            try
            {
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Row addRow = new Row();
                    addRow.id = reader.GetString("ID");
                    addRow.title = reader.GetString("TITLE");
                    addRow.snippet = reader.GetString("SNIPPET");
                    ret.Add(addRow);
                }
            }
            catch (MySqlException ex)
            {
            }
            return ret;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            table.Attributes.Add("style", "word-break:break-all; word-wrap:break-word");
        }

        protected void table_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}