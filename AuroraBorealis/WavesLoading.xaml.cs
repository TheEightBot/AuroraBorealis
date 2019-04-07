using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AuroraBorealis
{
    public partial class WavesLoading : ContentPage
    {
        public WavesLoading()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            waves.StartAnimating(16, 500);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            waves.StopAnimating();
        }
    }
}
