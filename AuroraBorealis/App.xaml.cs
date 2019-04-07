using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AuroraBorealis
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Aurora.EmbeddedResourceLoader.LoadAssembly(typeof(App).Assembly);

            MainPage = new NavigationPage(new MainMenu());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
