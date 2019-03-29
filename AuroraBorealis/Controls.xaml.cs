using System;
using System.Collections.Generic;
using Aurora.Extensions;
using Xamarin.Forms;
using System.Linq;

namespace AuroraBorealis
{
    public partial class Controls : ContentPage
    {
        List<Aurora.ImageProcessing.ImageProcessingBase> imageProcessing = new List<Aurora.ImageProcessing.ImageProcessingBase>();

        Aurora.ImageProcessing.Blur _blur;
        Aurora.ImageProcessing.Grayscale _grayscale;
        Aurora.ImageProcessing.Sepia _sepia;
        Aurora.ImageProcessing.Circular _circular;

        int _counter = -1;

        bool _isShown = false;

        bool _hasPartied = false;
        
        Random _rng = new Random(Guid.NewGuid().GetHashCode());

        public Controls()
        {
            InitializeComponent();

            _blur = new Aurora.ImageProcessing.Blur { BlurAmount = 40 };
            _grayscale = new Aurora.ImageProcessing.Grayscale();
            _sepia = new Aurora.ImageProcessing.Sepia();
            _circular = new Aurora.ImageProcessing.Circular();

            imageProcessing.AddRange(new Aurora.ImageProcessing.ImageProcessingBase[] { _blur, _sepia, _grayscale });
            
            imageProcessingEffect.ImageProcessingEffects.Add(_circular);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            _isShown = true;
            
            while(_isShown)
            {
                var newAngle = _rng.Next(-360, 360);
                        
                await cgv.TransitionTo(x => x.GradientRotationAngle, newAngle, length: 4000, easing: Easing.CubicInOut);
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            _isShown = false;
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            ++_counter;

            if (_counter >= imageProcessing.Count)
                _counter = 0;

            var processingEffect = imageProcessing.ElementAt(_counter);


            if(!_hasPartied)
            {
                _hasPartied = true;
                confetti.Start();
                
                imageProcessingEffect.ImageProcessingEffects.Add(_grayscale);
                
                while(_isShown)
                {
                    var percent = _rng.NextDouble();
                    var length = (uint)_rng.Next(200, 2000);
                            
                    await cfg1.TransitionTo(x => x.ProgressPercentage, percent, length: length, easing: Easing.CubicInOut);
                }
            }
        }

        int counter = 0;

        void Tile_Clicked(object sender, System.EventArgs e)
        {
            tile.VisualEffects.Clear();

            switch (counter)
            {
                case 0:
                    tile.VisualEffects.Add(new Aurora.VisualEffects.Pixelate { PixelSize = _rng.Next(10, 25) });
                    break;
                case 1:
                    tile.VisualEffects.Add(new Aurora.VisualEffects.Sepia());
                    break;
                case 2:
                    tile.VisualEffects.Add(new Aurora.VisualEffects.Grayscale());
                    break;
                case 3:
                    tile.VisualEffects.Add(new Aurora.VisualEffects.BlackAndWhite());
                    break;
                case 4:
                    tile.VisualEffects.Add(new Aurora.VisualEffects.Invert());
                    break;
                case 5:
                    tile.VisualEffects.Add(new Aurora.VisualEffects.HighContrast());
                    break;
                case 6:
                    var gradient = new Aurora.VisualEffects.Gradient
                    {
                        GradientStartColor = Color.FromRgba(_rng.Next(0, 255), _rng.Next(0, 255), _rng.Next(0, 255), _rng.Next(0, 255)),
                        GradientStopColor = Color.FromRgba(_rng.Next(0, 255), _rng.Next(0, 255), _rng.Next(0, 255), _rng.Next(0, 255)),
                        GradientRotationAngle = _rng.Next(-360, 360)
                    };
                    tile.VisualEffects.Add(gradient);
                    break;
            }

            counter++;

            if (counter > 8)
                counter = -1;
        }
    }
}
