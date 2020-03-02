using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AuroraBorealis.Polaris
{
    public partial class ExploreAuroras : ContentPage
    {
        public ExploreAuroras()
        {
            InitializeComponent();
        }

        void Borealis_Tapped(object sender, System.EventArgs e)
        {
            this.Navigation.PushAsync(new AuroraDetailsPage());
        }

        void Australis_Tapped(object sender, System.EventArgs e)
        {
            this.Navigation.PushAsync(new AustralisDetailsPage());
        }
    }
}
