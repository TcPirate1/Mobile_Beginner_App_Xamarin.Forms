using System;
using System.IO;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IT6035_Project.Supervisor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddStore : ContentPage
    {
        string database = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbpath.db3");
        public AddStore()
        {
            InitializeComponent();
        }

        private async void StoreAdded(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(database);

            db.CreateTable<Class_models.Ticket>();

            var id = db.Table<Class_models.Ticket>().OrderByDescending(i => i.Id).FirstOrDefault(); //If no FirstOrDefault function then there is no null value to return

            Class_models.Ticket ticket = new Class_models.Ticket
            {
                Id = id == null ? 0 : id.Id + 1,
                StoreN = StoreName.Text,
                Address = StoreAddress.Text,
            };
            db.Insert(ticket);
            await DisplayAlert("Store added.", $"\"{ticket.StoreN}\", \"{ticket.Address}\" has been added to the database", "OK");
            await Navigation.PopAsync();
        }
    }
}