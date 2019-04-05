using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AuroraBorealis
{
    public partial class RainbowRingLoading : ContentPage
    {
        public RainbowRingLoading()
        {
            InitializeComponent();
            _rainbow.Start();
        }
    }
}
