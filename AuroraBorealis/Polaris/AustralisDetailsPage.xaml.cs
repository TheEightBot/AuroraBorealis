using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Aurora.Extensions;
using Xamarin.Forms;

namespace AuroraBorealis.Polaris
{
    public partial class AustralisDetailsPage : ContentPage
    {
        public AustralisDetailsPage()
        {
            InitializeComponent();

            _coverageGauge.ProgressColor = Color.LawnGreen;

            _redGauge.ProgressBackgroundColor = Color.GhostWhite;
            _redGauge.ProgressColor = Color.Red;

            _greenGauge.ProgressBackgroundColor = Color.GhostWhite;
            _greenGauge.ProgressColor = Color.ForestGreen;

            _blueGauge.ProgressBackgroundColor = Color.GhostWhite;
            _blueGauge.ProgressColor = Color.RoyalBlue;
        }

        async void Clock_Tapped(object sender, System.EventArgs e)
        {
            await UpdateGauges();
        }

        void Emissions_Tapped(object sender, System.EventArgs e)
        {
            this.Navigation.PushAsync(new AustralisEmissionsPage());
        }

        Task UpdateGauges()
        {
            var randomValue = new Random();

            var redProgressBackgroundColor = new Color();
            var blueProgressBackgroundColor = new Color();
            var greenProgressBackgroundColor = new Color();

            var progressValue = randomValue.Next(0, 100);
            var redValue = randomValue.Next(0, 100);
            var blueValue = randomValue.Next(0, 100);
            var greenValue = randomValue.Next(0, 100);

            // Set red progress background color based on degree
            if (redValue <= 45)
            {
                redProgressBackgroundColor = Color.GhostWhite;
            }
            else if (redValue >= 46 && redValue <= 90)
            {
                redProgressBackgroundColor = Color.MistyRose;
            }
            else if (redValue >= 91 && redValue <= 240)
            {
                redProgressBackgroundColor = Color.LightCoral;
            }
            else if (redValue >= 241 && redValue <= 361)
            {
                redProgressBackgroundColor = Color.DarkRed;
            }

            // Set blue progress background color based on degree
            if (blueValue <= 45)
            {
                blueProgressBackgroundColor = Color.GhostWhite;
            }
            else if (blueValue >= 46 && blueValue <= 90)
            {
                blueProgressBackgroundColor = Color.LightSkyBlue;
            }
            else if (blueValue >= 91 && blueValue <= 240)
            {
                blueProgressBackgroundColor = Color.SkyBlue;
            }
            else if (blueValue >= 241 && blueValue <= 361)
            {
                blueProgressBackgroundColor = Color.MidnightBlue;
            }

            // Set green progress background color based on degree
            if (greenValue <= 45)
            {
                greenProgressBackgroundColor = Color.GhostWhite;
            }
            else if (greenValue >= 46 && greenValue <= 90)
            {
                greenProgressBackgroundColor = Color.LightGreen;
            }
            else if (greenValue >= 91 && greenValue <= 240)
            {
                greenProgressBackgroundColor = Color.LawnGreen;
            }
            else if (greenValue >= 241 && greenValue <= 361)
            {
                greenProgressBackgroundColor = Color.YellowGreen;
            }

            return Task
                .WhenAll(
                    _coverageGauge.TransitionTo(progressValue, 32, 1200, Easing.CubicInOut),
                    _redGauge.TransitionTo(redValue, 32, 1200, Easing.CubicInOut),
                    _blueGauge.TransitionTo(blueValue, 32, 1200, Easing.CubicInOut),
                    _greenGauge.TransitionTo(greenValue, 32, 1200, Easing.CubicInOut),

                    _redGauge.ColorTo(c => c.ProgressBackgroundColor, redProgressBackgroundColor, easing: Easing.SinOut),
                    _blueGauge.ColorTo(c => c.ProgressBackgroundColor, blueProgressBackgroundColor, easing: Easing.SinOut),
                    _greenGauge.ColorTo(c => c.ProgressBackgroundColor, greenProgressBackgroundColor, easing: Easing.SinOut)
                );
        }
    }
}
