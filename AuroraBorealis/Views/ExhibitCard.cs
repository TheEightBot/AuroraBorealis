using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Aurora;
using Aurora.Charts;
using Aurora.Controls;
using Aurora.Extensions;
using Xamarin.Forms;

namespace AuroraBorealis.Views
{
    public class ExhibitCard : ContentView
    {
        CardViewLayout _cardViewLayout;
        Grid _mainLayout;
        Label _name;
        Image _syncStatusIcon;
        DonutChart _percentCompleteChart;
        Label _percentComplete;
        IIconCache _iconCache;

        public TapGestureRecognizer TapGestureRecognizer = new TapGestureRecognizer();

        public ExhibitCard(string name)
        {
            _iconCache = DependencyService.Get<IIconCache>();

            _mainLayout = new Grid
            {
                RowSpacing = 4,
                Padding = new Thickness(16, 8),

                ColumnDefinitions = new ColumnDefinitionCollection 
                {
                    new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) }
                },
                RowDefinitions = new RowDefinitionCollection 
                {
                    new RowDefinition { Height = 44 }
                },

                BackgroundColor = Color.Transparent
            };

            _name = new Label
            {
                HorizontalTextAlignment = Xamarin.Forms.TextAlignment.Start,
                VerticalTextAlignment = Xamarin.Forms.TextAlignment.Center,
                FontSize = 18,
                TextColor = Colors.NearWhite,
                FontAttributes = FontAttributes.Bold,
                LineBreakMode = LineBreakMode.NoWrap,
                Text = name
            };

            _percentCompleteChart = new DonutChart
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                ProgressColor = Colors.NearWhite,
                ProgressBackgroundColor = Colors.LightBlue,
                StartingDegree = 0d,
                EndingDegree = 0d,
                RingThickness = 8d,
                Opacity = 0d
            };

            _percentComplete = new Label
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                VerticalTextAlignment = Xamarin.Forms.TextAlignment.Center,
                HorizontalTextAlignment = Xamarin.Forms.TextAlignment.Center,
                FontSize = 12d,
                TextColor = Colors.NearWhite,
                Opacity = 0,
                TranslationX = 2
            };

            _syncStatusIcon = new Image
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Source = _iconCache.FileImageSourceFromSvg("ok.svg", 42d, colorOverride: Colors.NearWhite).AsAsyncFileImageSource()
            };

            _mainLayout.Children.Add(_name, 0, 0);
            _mainLayout.Children.Add(_percentCompleteChart, 2, 0);
            _mainLayout.Children.Add(_percentComplete, 2, 0);
            _mainLayout.Children.Add(_syncStatusIcon, 2, 0);

            _cardViewLayout = new CardViewLayout
            {
                Margin = new Thickness(8, 0d),
                CornerRadius = 18d,
                BackgroundColor = Colors.Blue,
                Content = _mainLayout
            };

            Content = _cardViewLayout;

            _cardViewLayout.GestureRecognizers.Add(TapGestureRecognizer);

            ClearDonut();
            AnimateDonut();
        }

        public void ClearDonut()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                _syncStatusIcon.Opacity = 0;

                _percentComplete.Text = "0%";
                _percentComplete.Opacity = 0;

                _percentCompleteChart.StartingDegree = 0;
                _percentCompleteChart.EndingDegree = 0;
                _percentCompleteChart.Opacity = 0;                
            });
        }

        public void AnimateDonut()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Task.Delay(1500);
                var percent = (double)Values.Rng.Next(0, 99) / 100d;
                _percentComplete.Text = $"{(percent * 100d).ToString("F0")}%";
                await Task.Run(async () =>
                {
                    List<Task> anims = new List<Task>();
                    var isCompleted = Values.Rng.Next(0, 5) == 0;
                    if (isCompleted)
                        anims.Add(_syncStatusIcon.TransitionTo(x => x.Opacity, 1d, 16, 500, easing: Easing.CubicOut));
                    else
                    {
                        anims.Add(_percentCompleteChart.TransitionTo(startingDegree: 0d, endingDegree: percent * 360d, length: 4000, easing: Easing.CubicOut));
                        anims.Add(_percentCompleteChart.TransitionTo(x => x.Opacity, 1d, 16, 500, easing: Easing.CubicOut));
                        anims.Add(_percentComplete.TransitionTo(x => x.Opacity, 1d, 16, 500, easing: Easing.CubicOut));
                    }

                    await Task.WhenAll(anims);
                });
            });
        }

        public void SetColor(Color color, Color lightColor)
        {
            _cardViewLayout.BackgroundColor = color;
            _percentCompleteChart.ProgressBackgroundColor = lightColor;
        }
    }
}
