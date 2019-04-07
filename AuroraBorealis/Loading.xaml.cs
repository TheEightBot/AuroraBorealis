using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AuroraBorealis
{
    public partial class Loading : ContentPage
    {
        public Loading()
        {
            InitializeComponent();
        }

        void GoToNofriendo(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NofriendoLoading());
        }

        void GoToRainbowRing(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new RainbowRingLoading());
        }

        void GoToWaves(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new WavesLoading());
        }
    }
}
