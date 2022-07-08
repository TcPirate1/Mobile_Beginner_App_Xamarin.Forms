using System;
using System.IO;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IT6035_Project.Supervisor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddMerchandiser : ContentPage
    {
        string database = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbpath.db3");
        public AddMerchandiser()
        {
            InitializeComponent();
        }
        private async void AddMerchandiserF(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(database);

            db.CreateTable<Class_models.Merchandiser>();

            var id = db.Table<Class_models.Merchandiser>().OrderByDescending(i => i.Id).FirstOrDefault();

            Class_models.Merchandiser merchant = new Class_models.Merchandiser
            {
                Id = id == null ? 0 : id.Id + 1,
                First = FirstName.Text,
                Last = LastName.Text,
                Contact = MerchandiserContact.Text,
            };
            db.Insert(merchant);
            await DisplayAlert("Merchandiser added.", $"{merchant.First} {merchant.Last}, {merchant.Contact} has been added to the database", "OK");
            await Navigation.PopAsync();
        }
    }
}