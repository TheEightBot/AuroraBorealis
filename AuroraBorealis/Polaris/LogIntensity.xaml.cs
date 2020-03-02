using Aurora;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AuroraBorealis.Polaris
{
    public partial class LogIntensity : ContentPage
    {
        public LogIntensity()
        {
            InitializeComponent();
        }

        void Intensity_ValueChanged(object sender, ValueChangedEventArgs<double> e)
        {
            var normalizedValue = e.Value / 100f;
            var inverseValue = 1 - normalizedValue;

            if(normalizedValue <= .3)
                _intensityLabel.Text = "Weak";
            else if(normalizedValue > .3 && normalizedValue < .6)
                _intensityLabel.Text = "Moderate";
            else if(normalizedValue >= .6)
                _intensityLabel.Text = "Strong";

            _intensity.EmbeddedImageOverlayColor = Color.FromRgb(inverseValue, inverseValue, inverseValue);
            _intensity.ProgressColor = Color.FromRgb(normalizedValue, .9d, inverseValue);
        }

        void Next_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new LogColors());
        }
    }
}
