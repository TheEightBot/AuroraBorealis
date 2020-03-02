using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AuroraBorealis.Polaris
{
    public partial class LogSignature : ContentPage
    {
        public LogSignature()
        {
            InitializeComponent();
        }

        void Next_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new AddObservationLoadingPage());
        }
    }
}
