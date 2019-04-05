using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AuroraBorealis
{
    public partial class WavesLoading : ContentPage
    {
        public WavesLoading()
        {
            InitializeComponent();
            _waves.StartAnimating(16, 500);
        }
    }
}
