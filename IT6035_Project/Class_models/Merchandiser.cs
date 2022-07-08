using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace IT6035_Project.Class_models
{
    internal class Merchandiser
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
        public string Contact { get; set; }

        public override string ToString()
        {
            return this.First + " " + this.Last + " " + this.Contact;
        }
    }
}
