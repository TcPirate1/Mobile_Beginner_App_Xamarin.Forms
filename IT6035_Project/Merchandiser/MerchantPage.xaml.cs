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
    public partial class MerchantPage : ContentPage
    {
        public MerchantPage()
        {
            InitializeComponent();
        }

        private async void TicketList(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Merchandiser.TicketList());
        }

        private async void TodayTickets(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Merchandiser.TodayTickets());
        }
    }
}