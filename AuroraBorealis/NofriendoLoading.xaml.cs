using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace AuroraBorealis
{
    public partial class NofriendoLoading : ContentPage
    {
        public NofriendoLoading()
        {
            InitializeComponent();
            _nofriendo.StartAnimating(length: 3000, easing: Easing.CubicInOut);
        }
    }
}
