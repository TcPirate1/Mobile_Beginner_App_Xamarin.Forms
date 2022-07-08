using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IT6035_Project.Merchandiser
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TicketList : ContentPage
    {
        string database = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbpath.db3");
        public TicketList()
        {
            InitializeComponent();

            var db = new SQLiteConnection(database);
            ListOfTickets.ItemsSource = db.Table<Class_models.Ticket>().OrderBy(x => x.Id).ToList();
        }
    }
}