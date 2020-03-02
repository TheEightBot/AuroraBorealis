using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AuroraBorealis.Polaris
{
    public partial class LogColors : ContentPage
    {
        public LogColors()
        {
            InitializeComponent();
        }

        void Next_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new LogSignature());
        }
    }
}
