using System;
using System.Diagnostics;
using System.IO;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IT6035_Project.Supervisor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateStorePage : ContentPage
    {
        string database = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbpath.db3");
        Class_models.Ticket Store = new Class_models.Ticket();
        public UpdateStorePage()
        {
            InitializeComponent();

            var db = new SQLiteConnection(database);
            StoreList.ItemsSource = db.Table<Class_models.Ticket>().ToList();
            StoreList.ItemSelected += SelectStore;
        }

        private void SelectStore(object sender, SelectedItemChangedEventArgs e)
        {
            Store = (Class_models.Ticket)e.SelectedItem;
            StoreID.Text = Store.Id.ToString();
            StoreName.Text = Store.StoreN;
            StoreAddress.Text = Store.Address;
        }

        private async void UpdateStore(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(database);
            Class_models.Ticket Store = new Class_models.Ticket
            {
                Id = Convert.ToInt32(StoreID.Text),
                StoreN = StoreName.Text,
                Address = StoreAddress.Text,
            };
            db.Update(Store);

            await DisplayAlert("Store Updated", $"\"{Store.Id}\" , \"{Store.StoreN}\" and \"{Store.Address}\" has been updated", "OK");
            await Navigation.PopAsync();
        }

        private async void DeleteStore(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(database);
            Class_models.Ticket Store = new Class_models.Ticket
            {
                Id = Convert.ToInt32(StoreID.Text),
                StoreN = StoreName.Text,
                Address = StoreAddress.Text,
            };
            bool answer = await DisplayAlert("Warning!", $"{Store.Id} , \"{Store.StoreN}\" at \"{Store.Address}\" will be deleted, are you sure?", "Yes", "No");
            if (answer == true)
            {
                db.Delete(Store);
            }
            await Navigation.PopAsync();
        }
    }
}