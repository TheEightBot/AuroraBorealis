using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AuroraBorealis
{
    public partial class MainMenu : ContentPage
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            if (sender == polaris)
            {
                await this.Navigation.PushAsync(new Polaris.Login());
            }
            else if (sender == cupertino)
            {
                await this.Navigation.PushAsync(new Cupertino());
            }
            else if (sender == material)
            {
                await this.Navigation.PushAsync(new Material());
            }
            else if (sender == auroraControlsSample1)
            {
                await this.Navigation.PushAsync(new Controls());
            }
            else if (sender == auroraControlsSample2)
            {
                await this.Navigation.PushAsync(new OtherControls());
            }
            else if (sender == floatLabelControls)
            {
                await this.Navigation.PushAsync(new FloatLabelSamples());
            }
            else if (sender == loading)
            {
                await this.Navigation.PushAsync(new Loading());
            }
            else if (sender == gauges)
            {
                await this.Navigation.PushAsync(new Gauges());
            }
        }
    }
}
