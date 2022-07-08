using System;
using System.IO;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IT6035_Project.Supervisor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Todays_Stores : ContentPage
    {
        string database = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbpath.db3");
        public Todays_Stores()
        {
            InitializeComponent();
        }
        private async void Add_to_List(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(database);
            db.CreateTable<Class_models.Todays_Tickets>();

            var id = db.Table<Class_models.Todays_Tickets>().OrderByDescending(i => i.ID).FirstOrDefault();

            Class_models.Todays_Tickets today = new Class_models.Todays_Tickets
            {
                ID = id == null ? 0 : id.ID + 1,
                StoreName = SName.Text,
                StoreAddress = SAddress.Text,
            };
            db.Insert(today);
            await DisplayAlert(null, $"\"{today.StoreName}\" , \"{today.StoreAddress}\" has been added to Today's List", "OK");
            await Navigation.PopAsync();
        }
    }
}