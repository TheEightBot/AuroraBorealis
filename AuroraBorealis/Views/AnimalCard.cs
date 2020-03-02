using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Aurora.Controls;
using Xamarin.Forms;

namespace AuroraBorealis.Views
{
    public class AnimalCard : ContentView
    {
        Tile _tile;
        Color _backgroundColor, _fontColor, _selectedBackgroundColor, _selectedFontColor;

        public Tile Tile => _tile;
        public Color Color => _selectedBackgroundColor;
        public Color LightColor => _backgroundColor;

        public AnimalCard(
            string name, 
            string svg, 
            Color backgroundColor = default(Color), 
            Color fontColor = default(Color), 
            Color selectedBackgroundColor = default(Color), 
            Color selectedFontColor = default(Color))
        {
            _backgroundColor = backgroundColor == default(Color) ? Colors.LightPurple : backgroundColor;
            _fontColor = fontColor == default(Color) ? Colors.NearBlack : fontColor;
            _selectedBackgroundColor = selectedBackgroundColor == default(Color) ? Colors.Purple : selectedBackgroundColor;
            _selectedFontColor = selectedFontColor == default(Color) ? Colors.NearWhite : selectedFontColor;

            var mainLayout = new Grid();

            //var card =
            //    new CardViewLayout
            //    {
            //        CornerRadius = 28d,
            //        BackgroundColor = Colors.Accent,
            //        Content =
            //            new StackLayout
            //            {
            //                Padding = 24,
            //                Spacing = 16,
            //                BackgroundColor = Colors.Accent,
            //                Children =
            //                {
            //                    new Image
            //                    {
            //                        Margin = 8,
            //                        Aspect = Aspect.AspectFit,
            //                        Source = "monkey.png"
            //                    },
            //                    new Label
            //                    {
            //                        HorizontalTextAlignment = Xamarin.Forms.TextAlignment.Center,
            //                        TextColor = Colors.NearWhite,
            //                        FontAttributes = FontAttributes.Bold,
            //                        Text = "Monkey"
            //                    }
            //                }
            //            }
            //    };

            _tile =
                new Tile
                {
                    ContentPadding = 64,
                    MaxImageSize = new Size(52, 52),
                    Ripples = true,
                    CornerRadius = 28d,
                    WidthRequest = 96,
                    FontSize = 14,

                    OverlayColor = Colors.NearWhite,
                    EmbeddedImageName = svg,
                    Text = name
                };
            SetSelected(false);

            mainLayout.Children.Add(_tile, 0, 0);

            Content = mainLayout;
        }

        public void SetSelected(bool selected)
        {
            _tile.ButtonBackgroundColor = selected ? _selectedBackgroundColor : _backgroundColor;
            _tile.FontColor = selected ? _selectedFontColor : _fontColor;
        }
    }
}
