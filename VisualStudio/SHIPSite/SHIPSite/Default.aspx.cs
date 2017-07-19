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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SearchText.Attributes.Add("style", "display: inline;");
            Submit.Attributes.Add("style", "border-top-right-radius: 50px;border-bottom-right-radius: 50px;");
            this.SearchText.Attributes.Add("onkeyup", "button_click(this,'" + this.Submit.ClientID + "')");
            if(SearchText.Text.Equals("Search...") || SearchText.Text.Equals(""))
            {
                Submit.Enabled = false;
            }else
            {
                Submit.Enabled = true;
            }
        }
        protected void SearchText_Click(object sender, EventArgs e)
        {
            if (SearchText.Text.Equals("Search..."))
            {
                SearchText.Text = "";
            }
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Search.aspx?q=" + SearchText.Text);
        }
        public List<string> GetCompletionList()
        {
            List<string> ret = new List<string>();
            MySqlConnection conn = new MySqlConnection();
            string myConnectionString = "server=localhost;uid=user;pwd=Userp4ss;database=testdata;";
            conn.ConnectionString = myConnectionString;
            MySqlCommand cmd = new MySqlCommand("search", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("query", SearchText.Text);
            try{
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                int c = 0;
                while (reader.Read() && c < 10){
                    ret.Add(reader.GetString("title"));
                    c++;
                }
            }
            catch (MySqlException ex){}
            return ret;
        }
    }
}