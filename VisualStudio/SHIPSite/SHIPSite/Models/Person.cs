using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHIPSite.Models
{
    public class Person
    {
        public string name { get; set; }
        public int visits { get; set; }
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
    }
}