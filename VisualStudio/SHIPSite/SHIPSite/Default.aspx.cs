using System;
using System.Collections.Generic;
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
    }
}