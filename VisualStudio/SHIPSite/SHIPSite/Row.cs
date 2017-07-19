using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SHIPSite
{
    public class Row : IComparable
    {
        public string id {get;set;}
        public string title { get; set;}
        public string snippet { get; set; }
        public string url { get; set; }
        public int CompareTo(object obj)
        {
            return id.CompareTo(obj);
        }
    }
}