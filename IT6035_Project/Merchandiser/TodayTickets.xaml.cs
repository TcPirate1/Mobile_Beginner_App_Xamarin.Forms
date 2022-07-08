using SQLite;
using System;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Threading;

namespace IT6035_Project.Merchandiser
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodayTickets : ContentPage
    {
        string database = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "dbpath.db3");
        Class_models.Todays_Tickets today = new Class_models.Todays_Tickets();
        public TodayTickets()
        {
            InitializeComponent();

            var db = new SQLiteConnection(database);
            todayTickets.ItemsSource = db.Table<Class_models.Todays_Tickets>().OrderBy(x => x.ID).ToList();
            todayTickets.ItemSelected += TodayTickets_ItemSelected;
        }

        private void TodayTickets_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            today = (Class_models.Todays_Tickets)e.SelectedItem;
            TicketID.Text = today.ID.ToString();
            TicketName.Text = today.StoreName;
            TicketAddress.Text = today.StoreAddress;
            TicketComment.Text = today.StoreComment;
        }

        private void TimeTicket(object sender, EventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            Thread.Sleep(1000); //Running stopwatch for 1 second
            stopwatch.Stop();
            TicketComment.Text = "It took 10 minutes.";
        }

        private async void CommentTicket(object sender, EventArgs e)
        {
            var db = new SQLiteConnection(database);
            Class_models.Todays_Tickets today = new Class_models.Todays_Tickets
            {
                ID = Convert.ToInt32(TicketID.Text),
                StoreName = TicketName.Text,
                StoreAddress = TicketAddress.Text,
                StoreComment = TicketComment.Text,
            };
            await DisplayAlert(null, "Ticket has been updated", "OK");
            db.Update(today);
            await Navigation.PopAsync();
        }
        private void Checked(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value == true)
            {
                TicketComment.Text = "Completed";
            }
            else
            {
                TicketComment.Text = "";
            }
        }
    }
}