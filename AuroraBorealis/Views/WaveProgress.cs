using Aurora.Gauges;
using Aurora.Loading;
using AuroraBorealis.Polaris;
using AuroraBorealis.Polaris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AuroraBorealis.Views
{
    public class WaveProgress : ContentView
    {
        Waves _waves;

        LinearGauge _bar;

        public WaveProgress()
        {
            var mainLayout =
                   new Grid()
                   {
                       BackgroundColor = Color.Transparent,

                       RowDefinitions =
                           new RowDefinitionCollection
                           {
                            new RowDefinition { Height = GridLength.Star },
                            new RowDefinition { Height = GridLength.Star },
                            new RowDefinition { Height = GridLength.Star },
                            new RowDefinition { Height = GridLength.Star }
                           }
                   };

            _waves =
                new Waves
                {
                    ForegroundWaveColor = Colors.Primary,
                    BackgroundWaveColor = Colors.Blue,
                    BackgroundColor = Color.Transparent,
                    WaveStacks = 3,
                    WaveHeight = 64
                };

            var loading =
                new Label
                {
                    HorizontalTextAlignment = Xamarin.Forms.TextAlignment.Center,
                    VerticalTextAlignment = Xamarin.Forms.TextAlignment.End,
                    TextColor = Colors.NearWhite,
                    FontSize = 32,
                    FontAttributes = FontAttributes.Bold,
                    Text = "Loading"
                };

            _bar =
                new LinearGauge
                {
                    Margin = new Thickness(24, 0),
                    VerticalOptions = LayoutOptions.StartAndExpand,
                    ProgressBackgroundColor = Colors.LightBlue,
                    ProgressColor = Colors.Blue,
                    ProgressThickness = 32,
                    StartingPercent = 0,
                    EndingPercent = 0,
                    EndCapType = Aurora.EndCapType.Rounded
                };

            mainLayout.Children.Add(_waves, 0, 0);
            Grid.SetRowSpan(_waves, 4);

            mainLayout.Children.Add(loading, 0, 2);
            mainLayout.Children.Add(_bar, 0, 3);

            Content = mainLayout;
        }

        public void StartLoading()
        {
            _waves.StartAnimating(16, 1000);

            Task.Run(
                async () =>
                {
                    await _bar.TransitionTo(0, 100, 16, 3500, Easing.SinInOut);

                    Device.BeginInvokeOnMainThread(async () =>
                        await Navigation.PushAsync(new Home()));
                });
        }
    }
}
