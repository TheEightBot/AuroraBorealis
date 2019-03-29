using System;
using System.Collections.Generic;
using Aurora.Controls;
using Xamarin.Forms;

namespace AuroraBorealis
{
    public partial class Material : ContentPage
    {
        public Material()
        {
            InitializeComponent();
            
            loadingIndicator.Start();

            var cbg = new CheckBoxGroup
            {
                AllowEmptySelection = false,
                Children = { cb1, cb2, cb3 }
            };

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            loadingIndicator.Start();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            loadingIndicator.Stop();
        }
    }
}
