using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.Data.Entity;

namespace SHIPSite.Models
{
    public class PersonDatabaseInitializer : DropCreateDatabaseIfModelChanges<PersonContext>
    {
        protected override void Seed(PersonContext context)
        {
            GetPeople().ForEach(c => context.Persons.Add(c));

        }

        private static List<Person> GetPeople()
        {
            var persons = new List<Person> {
                new Person
                {
                    name = "Jim",
                    visits=0
                },
                new Person
                {
                    name = "Fred",
                    visits=0
                },
                new Person
                {
                    name = "Bob",
                    visits=0
                },
                new Person
                {
                    name = "Lary",
                    visits=0
                },
                new Person
                {
                    name = "Moe",
                    visits=0
                },
            };

            return persons;
        }
    }
}