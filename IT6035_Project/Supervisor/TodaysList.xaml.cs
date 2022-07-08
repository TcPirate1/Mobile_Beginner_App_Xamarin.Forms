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
    public partial class TodaysList : ContentPage
    {
        string database = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbpath.db3");
        public TodaysList()
        {
            InitializeComponent();

            var db = new SQLiteConnection(database);
            TList.ItemsSource = db.Table<Class_models.Todays_Tickets>().OrderBy(x => x.ID).ToList();
        }
    }
}