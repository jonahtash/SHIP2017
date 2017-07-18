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
            List<Row> ret = new List<Row>();
            MySqlConnection conn = new MySqlConnection();
            string myConnectionString = "server=localhost;uid=user;pwd=Userp4ss;database=testdata;";
            conn.ConnectionString = myConnectionString;
            foreach (string word in querySplit)
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("search", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("query", word);
                try
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read()){
                        var notIn = true;
                        string id = reader.GetString("id");
                        foreach (Row r in ret){
                            if (int.Parse(id) >= int.Parse(r.id))
                            {
                                if (int.Parse(id) == int.Parse(r.id)) { notIn = false; }
                                break;
                            }
                        }
                        if (notIn){
                            Row addRow = new Row();
                            addRow.id = id;
                            addRow.title = reader.GetString("title");
                            addRow.snippet = reader.GetString("snippet");
                            ret.Add(addRow);
                        }
                    }
                }
                catch (MySqlException ex)
                {
                }
                conn.Close();
            }
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
    }
}