using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace IT6035_Project.Class_models
{
    internal class Todays_Tickets
    {
        [PrimaryKey]
        public int ID { get; set; }
        public string StoreName { get; set; }
        public string StoreAddress { get; set; }
        public string StoreComment { get; set; }

        public override string ToString()
        {
            return this.StoreName + " " + this.StoreAddress + " " + this.StoreComment;
        }
    }
}
