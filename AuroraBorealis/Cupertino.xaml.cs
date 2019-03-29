using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Threading.Tasks;

namespace AuroraBorealis
{
    public partial class Cupertino : ContentPage
    {
        public Cupertino()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await Task.Delay(40);
            loadingIndicator.Start();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            loadingIndicator.Stop();
        }
    }
}
