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
    public partial class UpdateMerchandiserPage : ContentPage
    {
        string database = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbpath.db3");
        Class_models.Merchandiser merchandiser = new Class_models.Merchandiser();
        public UpdateMerchandiserPage()
        {
            InitializeComponent();

            var db = new SQLiteConnection(database);
            MerchandiserList.ItemsSource = db.Table<Class_models.Merchandiser>().ToList();
            MerchandiserList.ItemSelected += SelectMerchandiser;
        }

        private void SelectMerchandiser(object sender, SelectedItemChangedEventArgs e)
        {
            merchandiser = (Class_models.Merchandiser)e.SelectedItem;
            MerchantID.Text = merchandiser.Id.ToString();
            MerchantFirst.Text = merchandiser.First;
            MerchantLast.Text = merchandiser.Last;
            MerchantContact.Text = merchandiser.Contact;
        }

        private async void UpdateMerchandiser(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(database);
            Class_models.Merchandiser merchandiser = new Class_models.Merchandiser
            {
                Id = Convert.ToInt32(MerchantID.Text),
                First = MerchantFirst.Text,
                Last = MerchantLast.Text,
                Contact = MerchantContact.Text,
            };
            db.Update(merchandiser);

            await DisplayAlert("Merchandiser Updated", $"{merchandiser.Id} , \"{merchandiser.First} {merchandiser.Last}\", \"{merchandiser.Contact}\" has been updated", "OK");
            await Navigation.PopAsync();
        }
        private async void DeleteMerchandiser(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(database);
            Class_models.Merchandiser merchandiser = new Class_models.Merchandiser
            {
                Id = Convert.ToInt32(MerchantID.Text),
                First = MerchantFirst.Text,
                Last = MerchantLast.Text,
                Contact = MerchantContact.Text,
            };
            bool answer = await DisplayAlert("Warning!", $"{merchandiser.Id}, \"{merchandiser.First} {merchandiser.Last}\", \"{merchandiser.Contact}\" will be deleted, are you sure?", "Yes", "No");
            if (answer == true)
            {
                db.Delete(merchandiser);
            }
            await Navigation.PopAsync();
        }
    }
}