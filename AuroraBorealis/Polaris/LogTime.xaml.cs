using Aurora;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AuroraBorealis.Polaris
{
    public partial class LogTime : ContentPage
    {
        public LogTime()
        {
            InitializeComponent();
        }

        void Temperature_ValueChanged(object sender, ValueChangedEventArgs<double> e)
        {
            _temperature.ThumbColor = Color.FromRgb(e.Value / 100, 0, 1 - (e.Value / 100));
        }

        void Next_Clicked(object sender, EventArgs e)
        {
            _duration.ErrorText = string.Empty;

            if (!_duration.HasValue)
                _duration.ErrorText = "Duration is a required field";
            else
                this.Navigation.PushAsync(new LogIntensity());
        }
    }
}
