using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace IT6035_Project
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Merchandiser(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MerchantPage());
        }

        private async void Supervisor(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SupervisorPage());
        }
    }
}
