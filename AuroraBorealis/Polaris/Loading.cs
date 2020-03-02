//using Aurora.Controls;
//using Aurora.Gauges;
//using Aurora.Loading;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xamarin.Forms;

//namespace AuroraBorealis.Polaris
//{
//    public class Loading : ContentPage
//    {
//        public Loading()
//        {
//            this.BackgroundColor = Color.Transparent;

//            var mainLayout =
//                new Grid()
//                {
//                    BackgroundColor = Color.Transparent,

//                    RowDefinitions =
//                        new RowDefinitionCollection
//                        {
//                            new RowDefinition { Height = GridLength.Star },
//                            new RowDefinition { Height = GridLength.Star },
//                            new RowDefinition { Height = GridLength.Star },
//                            new RowDefinition { Height = GridLength.Star }
//                        }
//                };

//            var logo =
//                new Image
//                {
//                    HorizontalOptions = LayoutOptions.CenterAndExpand,
//                    Margin = 64,
//                    Aspect = Aspect.AspectFit,
//                    Source = "logo.jpg"
//                };

//            var waves =
//                new Waves
//                {
//                    ForegroundWaveColor = Colors.Primary,
//                    BackgroundWaveColor = Colors.Disabled,
//                    BackgroundColor = Color.Transparent,
//                    WaveStacks = 3,
//                    WaveHeight = 64
//                };

//            var loading =
//                new Label
//                {
//                    HorizontalTextAlignment = Xamarin.Forms.TextAlignment.Center,
//                    VerticalTextAlignment = Xamarin.Forms.TextAlignment.End,
//                    TextColor = Colors.NearWhite,
//                    FontSize = 24,
//                    Text = "Loading"
//                };

//            var bar =
//                new LinearGauge
//                {
//                    Margin = new Thickness(24, 0),
//                    VerticalOptions = LayoutOptions.StartAndExpand,
//                    ProgressBackgroundColor = Colors.Disabled,
//                    ProgressColor = Colors.Accent,
//                    ProgressThickness = 16,
//                    StartingPercent = 0, 
//                    EndingPercent = 0,
//                    EndCapType = Aurora.EndCapType.Rounded
//                };

//            waves.StartAnimating(16, 1000);

//            Task.Run(
//                async () =>
//                {
//                    await bar.TransitionTo(0, 100, 16, 6000, Easing.SinInOut);
//                    await Navigation.PopModalAsync();
//                });

//            //mainLayout.Children.Add(logo, 0, 0);
//            //Grid.SetRowSpan(logo, 2);

//            mainLayout.Children.Add(waves, 0, 0);
//            Grid.SetRowSpan(waves, 4);

//            mainLayout.Children.Add(loading, 0, 2);
//            mainLayout.Children.Add(bar, 0, 3);

//            Content = mainLayout;

//            //for(int i = 0; i < 100; i++)
//            //{
//            //    bar.
//            //}
//        }
//    }
//}
