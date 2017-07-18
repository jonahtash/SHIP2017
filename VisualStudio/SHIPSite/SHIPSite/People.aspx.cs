using SHIPSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SHIPSite
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static List<Person> GetPeople()
        {
            var persons = new List<Person> {
                new Person
                { name = "Jim",visits=0},
                new Person
                {name = "Fred",visits=0},
                new Person
                {name = "Bob",visits=0},
                new Person
                {name = "Lary",visits=0},
                new Person
                {name = "Moe",visits=0},};
            return persons;
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}