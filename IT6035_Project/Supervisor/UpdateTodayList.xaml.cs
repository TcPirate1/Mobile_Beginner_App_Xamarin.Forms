using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IT6035_Project.Supervisor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateTodayList : ContentPage
    {
        string database = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbpath.db3");
        Class_models.Todays_Tickets today = new Class_models.Todays_Tickets();
        public UpdateTodayList()
        {
            InitializeComponent();

            var db = new SQLiteConnection(database);
            UpdateDelete.ItemsSource = db.Table<Class_models.Todays_Tickets>().ToList();
            UpdateDelete.ItemSelected += TList;
        }

        private void TList(object sender, SelectedItemChangedEventArgs e)
        {
            today = (Class_models.Todays_Tickets)e.SelectedItem;
            Sid.Text = today.ID.ToString();
            SName.Text = today.StoreName;
            SAddress.Text = today.StoreAddress;
        }
        private async void UpdateList(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(database);
            Class_models.Todays_Tickets today = new Class_models.Todays_Tickets
            {
                ID = Convert.ToInt32(Sid.Text),
                StoreName = SName.Text,
                StoreAddress = SAddress.Text,
            };
            db.Update(today);
            await DisplayAlert(null, "Ticket updated", "OK");
            await Navigation.PopAsync();
        }
        private async void DeleteFromList(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(database);
            Class_models.Todays_Tickets today = new Class_models.Todays_Tickets
            {
                ID = Convert.ToInt32(Sid.Text),
                StoreName = SName.Text,
                StoreAddress = SAddress.Text,
            };
            db.Delete(today);
            await DisplayAlert("Warning!", $"You are about to delete \"{today.StoreName}\" at \"{today.StoreAddress}\" from the list, are you sure?", "Yes", "No");
            await Navigation.PopAsync();
        }
    }
}