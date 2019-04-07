using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AuroraBorealis
{
    public partial class RainbowRingLoading : ContentPage
    {
        public RainbowRingLoading()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            rainbow.Start();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            rainbow.Stop();
        }
    }
}
