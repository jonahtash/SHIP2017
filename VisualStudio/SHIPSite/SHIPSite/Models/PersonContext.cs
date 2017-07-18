using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SHIPSite.Models
{
    public class PersonContext : DbContext
    {
        public PersonContext() : base("Person")
        {
        }
        public DbSet<Person> Persons { get; set; }
    }
}