using System;
using SQLite;
using System.IO;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IT6035_Project.Supervisor
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StoreList : ContentPage
    {
        string database = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbpath.db3");
        public StoreList()
        {
            InitializeComponent();

            var db = new SQLiteConnection(database);
            storeList.ItemsSource = db.Table<Class_models.Ticket>().OrderBy(x => x.Id).ToList();
        }
    }
}