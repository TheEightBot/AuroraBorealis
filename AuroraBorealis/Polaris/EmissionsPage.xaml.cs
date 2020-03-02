using System;
using System.Collections.Generic;
using Aurora.Extensions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AuroraBorealis.Polaris
{
    public partial class EmissionsPage : ContentPage
    {
        public EmissionsPage()
        {
            InitializeComponent();

            _oxygenEmissions.Value = (int)_emissionChart.EndingDegree;
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Task
                .WhenAll(
                    _emissionChart.TransitionTo(-90, _oxygenEmissions.Value, length: 1000, easing: Easing.CubicInOut));
        }
    }
}
