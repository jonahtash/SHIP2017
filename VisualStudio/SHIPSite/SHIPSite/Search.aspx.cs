using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHIPSite
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        public List<Row> GetRows()
        {
            string query = Request.QueryString["q"];
            if (query==null||query.Equals(""))
            {
                return new List<Row>();
            }
            string[] querySplit = query.Split(' ');
            List<string> split = new List<string>();
            split = Enumerable.Repeat("", 15).ToList();
            for(int i = 0; i < querySplit.Length && i<15; i++){
                split[i] = querySplit[i];
            }
            List<Row> ret = new List<Row>();
            MySqlConnection conn = new MySqlConnection();
            string myConnectionString = "server=localhost;uid=user;pwd=Userp4ss;database=testdata;";
            conn.ConnectionString = myConnectionString;
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("search_15", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("a", split.ElementAtOrDefault(0)); cmd.Parameters.AddWithValue("b", split.ElementAtOrDefault(1)); cmd.Parameters.AddWithValue("c", split.ElementAtOrDefault(2));
            cmd.Parameters.AddWithValue("d", split.ElementAtOrDefault(3)); cmd.Parameters.AddWithValue("e", split.ElementAtOrDefault(4)); cmd.Parameters.AddWithValue("f", split.ElementAtOrDefault(5));
            cmd.Parameters.AddWithValue("g", split.ElementAtOrDefault(6)); cmd.Parameters.AddWithValue("h", split.ElementAtOrDefault(7)); cmd.Parameters.AddWithValue("i", split.ElementAtOrDefault(8));
            cmd.Parameters.AddWithValue("j", split.ElementAtOrDefault(9)); cmd.Parameters.AddWithValue("k", split.ElementAtOrDefault(10)); cmd.Parameters.AddWithValue("l", split.ElementAtOrDefault(11));
            cmd.Parameters.AddWithValue("m", split.ElementAtOrDefault(12)); cmd.Parameters.AddWithValue("n", split.ElementAtOrDefault(13)); cmd.Parameters.AddWithValue("o", split.ElementAtOrDefault(14));

            try
            {
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Row addRow = new Row();
                    string id = reader.GetString("id");
                    addRow.id = id;
                    addRow.title = reader.GetString("title");
                    addRow.snippet = reader.GetString("snippet");
                    addRow.url = reader.GetString("url");
                    ret.Add(addRow);
                }
            }
            catch (MySqlException ex)
            {
            }
            conn.Close();
            return ret;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[0].Attributes["width"] = "50px";
                e.Row.Cells[1].Attributes["width"] = "1000px";
                e.Row.Cells[2].Attributes["width"] = "3000px";
            }
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        public void insert(List<Row> l,Row r)
        {
            int last = l.Count;
            int first = 0;
            while (first < last)
            {
                int mid = (first + last) / 2;
                var compare = r.CompareTo(l.ElementAt(mid));
                if (compare< 0){last = mid;}else if(compare>0){first = mid;}
            }
            if (first == last)
            {
                return;
            }

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}