using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace IT6035_Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SupervisorPage : ContentPage
    {
        public SupervisorPage()
        {
            InitializeComponent();
        }
        //Merchandiser buttons
        private async void MerchList(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Supervisor.MerchandiserList());
        }

        private async void AddMerch(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Supervisor.AddMerchandiser());
        }

        private async void UpdateMerch(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Supervisor.UpdateMerchandiserPage());
        }
        //Retail store buttons
        private async void StoreList(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Supervisor.StoreList());
        }

        private async void AddStore(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Supervisor.AddStore());
        }

        private async void UpdateStore(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Supervisor.UpdateStorePage());
        }
        //Today's Ticket List
        private async void TodayList(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Supervisor.TodaysList());
        }

        private async void Add_Today(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Supervisor.Todays_Stores());
        }

        private async void Update_Today(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Supervisor.UpdateTodayList());
        }
    }
}