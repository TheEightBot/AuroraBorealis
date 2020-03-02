using System;
using System.Collections.Generic;
using Aurora.Extensions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AuroraBorealis.Polaris
{
    public partial class AustralisEmissionsPage : ContentPage
    {
        public AustralisEmissionsPage()
        {
            InitializeComponent();

            _emissionsBumper.Value = (int)_emissionChart.EndingDegree;
        }

        async void ChangeColors()
        {
            var _emissionsBumperButtonColor = new Color();
            _emissionsBumperButtonColor = _emissionsToggle.IsToggled ? Color.LawnGreen : Color.DarkBlue;

            var _computeButtonBackgroundColor = new Color();
            var _computeButtonFontColor = new Color();
            _computeButtonBackgroundColor = _emissionsToggle.IsToggled ? Color.LawnGreen : Color.DarkBlue;
            _computeButton.InkColor = _emissionsToggle.IsToggled ? Color.DarkBlue : Color.LawnGreen;
            _computeButtonFontColor = _emissionsToggle.IsToggled ? Color.Black : Color.White;

            var _emissionProgressColor = new Color();
            var _emissionProgressBackgroundColor = new Color();
            _emissionProgressColor = _emissionsToggle.IsToggled ? Color.LawnGreen : Color.DarkBlue;
            _emissionProgressBackgroundColor = _emissionsToggle.IsToggled ? Color.DarkBlue : Color.LawnGreen;

            await Task
                .WhenAll(
                    _emissionsBumper.ColorTo(c => c.ButtonColor, _emissionsBumperButtonColor, 16, 1000, Easing.CubicInOut),
                    _computeButton.ColorTo(c => c.BackgroundColor, _computeButtonBackgroundColor, 16, 1000, Easing.CubicInOut),
                    _computeButton.ColorTo(c => c.FontColor, _computeButtonFontColor, 16, 1000, Easing.CubicInOut),
                    _emissionChart.ColorTo(c => c.ProgressColor, _emissionProgressColor, 16, 1000, Easing.CubicInOut),
                    _emissionChart.ColorTo(c => c.ProgressBackgroundColor, _emissionProgressBackgroundColor, 16, 1000, Easing.CubicInOut));
        }

        void EmissionsToggle_Toggled(object sender, Aurora.ToggledEventArgs e)
        {
            ChangeColors();

            _emissionsLabel.Text = _emissionsToggle.IsToggled ? "Oxygen Emissions" : "Nitrogen Emissions";
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            await Task
                .WhenAll(
                    _emissionChart.TransitionTo(-90, _emissionsBumper.Value, length: 1000, easing: Easing.CubicInOut));
        }
    }
}
