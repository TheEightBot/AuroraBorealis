using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AuroraBorealis
{
    public partial class NofriendoLoading : ContentPage
    {
        public NofriendoLoading()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            nofriendo.StartAnimating(length: 3000, easing: Easing.CubicInOut);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            nofriendo.StopAnimating();
        }
    }
}
