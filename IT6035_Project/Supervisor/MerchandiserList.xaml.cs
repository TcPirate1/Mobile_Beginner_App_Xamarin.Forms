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
    public partial class MerchandiserList : ContentPage
    {
        string database = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbpath.db3");
        public MerchandiserList()
        {
            InitializeComponent();

            var db = new SQLiteConnection(database);
            merchList.ItemsSource = db.Table<Class_models.Merchandiser>().OrderBy(x => x.Id).ToList();
        }
    }
}