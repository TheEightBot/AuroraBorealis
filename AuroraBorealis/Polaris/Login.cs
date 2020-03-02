using Aurora.Controls;
using Aurora.Gauges;
using Aurora.Loading;
using AuroraBorealis.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AuroraBorealis.Polaris
{
    public class Login : ContentPage
    {
        static readonly double ScreenHeightDp = DeviceDisplay.MainDisplayInfo.Height;
        
        public Login()
        {
            var mainLayout = 
                new Grid
                {
                    BackgroundColor = Colors.NearWhite,

                    RowDefinitions =
                        new RowDefinitionCollection
                        {
                            new RowDefinition { Height = GridLength.Star },
                            new RowDefinition { Height = GridLength.Auto },
                            new RowDefinition { Height = GridLength.Auto },
                            new RowDefinition { Height = GridLength.Auto }
                        }
                };

            var background = 
                new Image
                {
                    Aspect = Aspect.AspectFill,
                    Source = "background.jpg"
                };

            var logo =
                new Image
                {
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    Margin = 64,
                    Aspect = Aspect.AspectFit,
                    Source = "logo.jpg"
                };

            var username = 
                new FloatLabelEntry
                {
                    Margin = new Thickness(16, 8),
                    Placeholder = "Username"
                };

            var password = 
                new FloatLabelEntry
                {
                    Margin = new Thickness(16, 8),
                    IsPassword = true,
                    Placeholder = "Password"
                };

            var login = 
                new Button
                {
                    Margin = 16,
                    Text = "Login"
                };

            var waveProgress =
                new WaveProgress()
                {
                    TranslationY = (ScreenHeightDp / 2d) + 8,
                    InputTransparent = true
                };

            var snow =
                new ConfettiView()
                {
                    Continuous = true,
                    MaxParticles = 8,
                    ConfettiShape = ConfettiShape.Circular
                };

            login.Clicked += 
                async (s, e) => 
                {
                    waveProgress.StartLoading();
                    await waveProgress.TranslateTo(0, 0, 500);
                };

            mainLayout.Children.Add(background, 0, 0);
            Grid.SetRowSpan(background, 4);

            mainLayout.Children.Add(snow, 0, 0);
            Grid.SetRowSpan(snow, 4);

            mainLayout.Children.Add(logo, 0, 0);

            mainLayout.Children.Add(username, 0, 1);
            mainLayout.Children.Add(password, 0, 2);
            mainLayout.Children.Add(login, 0, 3);

            mainLayout.Children.Add(waveProgress, 0, 0);
            Grid.SetRowSpan(waveProgress, 4);

            Content = mainLayout;

            snow.Start();
        }
    }
}
