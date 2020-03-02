using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AuroraBorealis.Polaris
{
    public partial class AddObservationLoadingPage : ContentPage
    {
        public AddObservationLoadingPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            _loadingBackground.StartAnimating(length: 3000, easing: Easing.CubicInOut);
            _loading.Start();

            Device.StartTimer(TimeSpan.FromSeconds(8.5), () =>
            {
                Navigation.PopToRootAsync();

                return false;
            });
        }
    }
}
