using System;
using System.Linq;
using System.Threading.Tasks;
using Aurora.Extensions;
using Aurora.Loading;
using Xamarin.Forms;

namespace AuroraBorealis.Polaris
{
    public partial class MainMenu : ContentPage
    {
        public MainMenu()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            _borealisBackground.GradientStartColor = Color.Green;
            _borealisBackground.GradientStopColor = Color.MidnightBlue;

            Device.StartTimer(TimeSpan.FromSeconds(5), () =>
            {
                ChangeColor();

                return true;
            });
        }

        async Task ChangeColor()
        {
            var randomAngle = new Random();
            var randomColor = new Random();

            Color[] start = new Color[] { Color.Green, Color.Blue, Color.DeepSkyBlue, Color.MidnightBlue, Color.Yellow, Color.YellowGreen, Color.Pink, Color.Indigo, Color.LightCyan, Color.Purple, Color.BlueViolet };
            Color[] stop = new Color[] { Color.SeaGreen, Color.SkyBlue, Color.GreenYellow, Color.LightSeaGreen, Color.LightYellow, Color.Cyan, Color.LightPink, Color.MistyRose, Color.PaleVioletRed, Color.DarkViolet, Color.PaleGreen};

            int colorStartElement = randomColor.Next(start.Length);
            int colorStopElement = randomColor.Next(stop.Length);

            await Task.WhenAll(
                _borealisBackground.TransitionTo(c => c.GradientRotationAngle, randomAngle.Next(-360, 360), length: 1000, easing: Easing.CubicInOut),
                _borealisBackground.ColorTo(x => x.GradientStartColor, start[colorStartElement], length: 1000, easing: Easing.CubicInOut),
                _borealisBackground.ColorTo(x => x.GradientStopColor, stop[colorStopElement], length: 1000, easing: Easing.CubicInOut)
                //_waves.ColorTo(x => x.ForegroundWaveColor, start[colorStartElement], length:1000, easing: Easing.CubicInOut),
                //_waves.ColorTo(x => x.BackgroundWaveColor, stop[colorStopElement], length: 1000, easing: Easing.CubicInOut)
            );
        }

        async Task ShowLoading()
        {
            //_waves.StartAnimating(16, 500);
            //_welcomeBanner.ToggleBannerVisibility();

            //await Task.Delay(2500);

            //_welcomeBanner.ToggleBannerVisibility();
            //_waves.StopAnimating();
        }

        async void Explore_Tapped(object sender, System.EventArgs e)
        {
            await ShowLoading();

            NavigationPage.SetHasNavigationBar(this, false);
            await this.Navigation.PushAsync(new ExploreAuroras());
        }

        void Log_Tapped(object sender, System.EventArgs e)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            this.Navigation.PushAsync(new LogTime());
        }
    }
}
