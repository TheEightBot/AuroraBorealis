using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AuroraBorealis.Polaris
{
    public partial class LogCoverage : ContentPage
    {
        public LogCoverage()
        {
            InitializeComponent();
        }

        void Next_Tapped(object sender, System.EventArgs e)
        {
            this.Navigation.PushAsync(new LogColors());
        }
    }
}
