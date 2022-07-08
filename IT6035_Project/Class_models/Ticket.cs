using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace IT6035_Project.Class_models
{
    internal class Ticket
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string StoreN { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return this.StoreN + " " + this.Address + " ";
        }
    }
}
