using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TuSalud.Models
{
    public class Data : IComparable<Data>
    {

        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string producer { get; set; }

        public double price { get; set; }

        public int stock { get; set; }
                     


        public int CompareTo(Data other)
        {
            if (this.name.CompareTo(other.name) > 0)
                return -1;
            else if (this.name.CompareTo(other.name) < 0)
                return 1;
            else
                return 0;
        }
    }
}