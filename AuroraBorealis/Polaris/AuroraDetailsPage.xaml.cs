using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Aurora.Extensions;
using Xamarin.Forms;

namespace AuroraBorealis.Polaris
{
    public partial class AuroraDetailsPage : ContentPage
    {
        public AuroraDetailsPage()
        {
            InitializeComponent();

            _durationGauge.ProgressColor = Color.SpringGreen;
            _coverageGauge.ProgressColor = Color.SpringGreen;
            _intensityGauge.ProgressColor = Color.SpringGreen;

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
            this.Navigation.PushAsync(new EmissionsPage());
        }

        Task UpdateGauges()
        {
            var randomValue = new Random();

            var intensityDegree = randomValue.Next(0, 360);
            var thickness = _intensityGauge.ProgressThickness;

            var redProgressBackgroundColor = new Color();
            var blueProgressBackgroundColor = new Color();
            var greenProgressBackgroundColor = new Color();

            var startDegree = -90;
            var redDegree = randomValue.Next(0, 360);
            var blueDegree = randomValue.Next(0, 360);
            var greenDegree = randomValue.Next(0, 360);

            // Set thickness of Intensity Gauge based on degree
            if(intensityDegree <= 45)
            {
                thickness = 12;
            }
            else if(intensityDegree >= 46 && intensityDegree <= 90)
            {
                thickness = 18;
            }
            else if (intensityDegree >= 91 && intensityDegree <= 180)
            {
                thickness = 24;
            }
            else if (intensityDegree >= 181 && intensityDegree <= 361)
            {
                thickness = 30;
            }

            // Set red progress background color based on degree
            if (redDegree <= 45)
            {
                redProgressBackgroundColor = Color.GhostWhite;
            }
            else if (redDegree >= 46 && redDegree <= 90)
            {
                redProgressBackgroundColor = Color.MistyRose;
            }
            else if (redDegree >= 91 && redDegree <= 240)
            {
                redProgressBackgroundColor = Color.LightCoral;
            }
            else if (redDegree >= 241 && redDegree <= 361)
            {
                redProgressBackgroundColor = Color.DarkRed;
            }

            // Set blue progress background color based on degree
            if (blueDegree <= 45)
            {
                blueProgressBackgroundColor = Color.GhostWhite;
            }
            else if (blueDegree >= 46 && blueDegree <= 90)
            {
                blueProgressBackgroundColor = Color.LightSkyBlue;
            }
            else if (blueDegree >= 91 && blueDegree <= 240)
            {
                blueProgressBackgroundColor = Color.SkyBlue;
            }
            else if (blueDegree >= 241 && blueDegree <= 361)
            {
                blueProgressBackgroundColor = Color.MidnightBlue;
            }

            // Set green progress background color based on degree
            if (greenDegree <= 45)
            {
                greenProgressBackgroundColor = Color.GhostWhite;
            }
            else if (greenDegree >= 46 && greenDegree <= 90)
            {
                greenProgressBackgroundColor = Color.LightGreen;
            }
            else if (greenDegree >= 91 && greenDegree <= 240)
            {
                greenProgressBackgroundColor = Color.LawnGreen;
            }
            else if (greenDegree >= 241 && greenDegree <= 361)
            {
                greenProgressBackgroundColor = Color.YellowGreen;
            }

            return Task
                .WhenAll(
                    _intensityGauge.TransitionTo(startDegree, intensityDegree, 16, 250, Easing.CubicOut),
                    _intensityGauge.TransitionTo(c => c.ProgressThickness, thickness, 1000, easing: Easing.CubicOut),

                    _redGauge.TransitionTo(startDegree, redDegree, 16, 250, Easing.CubicOut),
                    _blueGauge.TransitionTo(startDegree, blueDegree, 16, 250, Easing.CubicOut),
                    _greenGauge.TransitionTo(startDegree, greenDegree, 16, 250, Easing.CubicOut),

                    _redGauge.ColorTo(c => c.ProgressBackgroundColor, redProgressBackgroundColor, easing: Easing.CubicOut),
                    _blueGauge.ColorTo(c => c.ProgressBackgroundColor, blueProgressBackgroundColor, easing: Easing.CubicOut),
                    _greenGauge.ColorTo(c => c.ProgressBackgroundColor, greenProgressBackgroundColor, easing: Easing.CubicOut)
                );
        }
    }
}
