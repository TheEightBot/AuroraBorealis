using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aurora.Controls;
using Aurora.Extensions;
using AuroraBorealis.Views;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace AuroraBorealis.Polaris
{
    public class Home : ContentPage
    {
        List<ExhibitCard> _exhibits =
            new List<ExhibitCard>
            {
                new ExhibitCard("African Journey"),
                new ExhibitCard("Amazonia"),
                new ExhibitCard("American Trail"),
                new ExhibitCard("Arctic Tundra"),
                new ExhibitCard("Bird House"),
                new ExhibitCard("Great Cats"),
                new ExhibitCard("Nature Boardwalk"),
                new ExhibitCard("Penguin Cove"),
                new ExhibitCard("Seal Pool"),
                new ExhibitCard("Waterfowl Lagoon")
            };

        List<AnimalCard> _animals =
            new List<AnimalCard>
            {
                new AnimalCard("Monkeys", "monkey.svg", backgroundColor: Colors.LightBlue, selectedBackgroundColor: Colors.DarkBlue),
                new AnimalCard("Tigers", "tiger.svg", backgroundColor: Colors.LightOrange, selectedBackgroundColor: Colors.DarkOrange),
                new AnimalCard("Dragons", "dragon.svg", backgroundColor: Colors.LightRed, selectedBackgroundColor: Colors.DarkRed),
                new AnimalCard("Rabbits", "rabbit.svg", backgroundColor: Colors.LightPurple, selectedBackgroundColor: Colors.DarkPurple),
                new AnimalCard("Chickens", "rooster.svg", backgroundColor: Colors.LightPink, selectedBackgroundColor: Colors.DarkPink),
                new AnimalCard("Dogs", "dog.svg", backgroundColor: Colors.LightGreen, selectedBackgroundColor: Colors.DarkGreen)
            };

        public Home()
        {
            On<iOS>().SetUseSafeArea(true);

            var mainLayout =
                new Grid
                {
                    Padding = new Thickness(0, 16, 0, 0),
                    RowSpacing = 0,
                    BackgroundColor = Colors.NearWhite,

                    RowDefinitions =
                        new RowDefinitionCollection
                        {
                            new RowDefinition { Height = GridLength.Auto },
                            new RowDefinition { Height = GridLength.Auto },

                            new RowDefinition { Height = GridLength.Auto },
                            new RowDefinition { Height = 150 },

                            new RowDefinition { Height = GridLength.Auto },
                            new RowDefinition { Height = GridLength.Star }
                        }
                };

            var title
                = new Label
                {
                    Margin = new Thickness(16, 0),
                    VerticalTextAlignment = Xamarin.Forms.TextAlignment.End,
                    TextColor = Colors.Primary,
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 32,
                    Text = "Hi Susan"
                };

            var subTitle
                = new Label
                {
                    Margin = new Thickness(16, 0),
                    VerticalTextAlignment = Xamarin.Forms.TextAlignment.Start,
                    TextColor = Colors.Gray,
                    FontSize = 18,
                    Text = "Select an animal to get started!"
                };

            var animalsHeader
                = new Label
                {
                    Margin = new Thickness(16, 24, 0, 0),
                    VerticalTextAlignment = Xamarin.Forms.TextAlignment.End,
                    TextColor = Colors.NearBlack,
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 22,
                    Text = "Animals"
                };

            var animalsLayout =
                new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Spacing = 16
                };

            foreach (var animal in _animals)
            {
                animal.Tile.Clicked += 
                    (e, s) =>
                    {
                        _animals.ForEach(x => x.SetSelected(false));
                        animal.SetSelected(true);

                        Task.Run(async () =>
                        {
                            List<Task> anims = new List<Task>();

                            anims.Add(FlyAwayExhibitCards());
                            await Task.Delay(1000);
                            anims.Add(FlyInExhibitCards(animal.Color, animal.LightColor));

                            await Task.WhenAll(anims);
                        });
                    };

                animalsLayout.Children.Add(animal);
            }

            var animalScroll =
                new Xamarin.Forms.ScrollView
                {
                    Padding = new Thickness(16, 0, 16, 16),
                    Orientation = ScrollOrientation.Horizontal,
                    HorizontalScrollBarVisibility = ScrollBarVisibility.Never,
                    Content = animalsLayout
                };

            var exhibitsHeader
                = new Label
                {
                    Margin = new Thickness(16, 24, 0, 0),
                    VerticalTextAlignment = Xamarin.Forms.TextAlignment.End,
                    TextColor = Colors.NearBlack,
                    FontAttributes = FontAttributes.Bold,
                    FontSize = 22,
                    Text = "Exhibits"
                };

            var exhibitLayout =
                new StackLayout
                {
                    Spacing = 18,
                    Margin = new Thickness(0, 8)
                };

            var exhibitScroll =
                new Xamarin.Forms.ScrollView
                {
                    VerticalScrollBarVisibility = ScrollBarVisibility.Never,
                    Content = exhibitLayout
                };

            foreach (var card in _exhibits)
            {
                card.TapGestureRecognizer.Tapped +=
                    async (s, e) => await this.Navigation.PushAsync(new ExploreAuroras());
                card.Opacity = 0;
                card.TranslationY = -32;
                exhibitLayout.Children.Add(card);
            }

            int row = 0;

            mainLayout.Children.Add(title, 0, row);
            ++row;
            mainLayout.Children.Add(subTitle, 0, row);

            ++row;
            mainLayout.Children.Add(animalsHeader, 0, row);
            ++row;
            mainLayout.Children.Add(animalScroll, 0, row);

            ++row;
            mainLayout.Children.Add(exhibitsHeader, 0, row);
            ++row;
            mainLayout.Children.Add(exhibitScroll, 0, row);

            Content = mainLayout;

            _animals[0].SetSelected(true);

            Task.Run(async () => await FadeInCards());            
        }

        async Task FadeInCards()
        {
            List<Task> fadeInAnimations = new List<Task>();
            foreach (var card in _exhibits)
            {
                await Task.Delay(200);

                card.TranslationY = -32;
                fadeInAnimations.Add(card.TransitionTo(x => x.Opacity, 1d, length: 400, easing: Easing.CubicOut));
                fadeInAnimations.Add(card.TransitionTo(x => x.TranslationY, 0d, length: 400, easing: Easing.CubicOut));
            }

            await Task.WhenAll(fadeInAnimations);
        }

        async Task FlyInExhibitCards(Color color, Color lightColor)
        {
            List<Task> flyInAnimations = new List<Task>();

            foreach (var card in _exhibits)
            {
                await Task.Delay(200);

                card.TranslationX = -400;
                card.SetColor(color, lightColor);
                card.ClearDonut();
                flyInAnimations.Add(card.TransitionTo(x => x.Opacity, 1d, length: 600, easing: Easing.CubicIn));
                flyInAnimations.Add(card.TransitionTo(x => x.TranslationX, 0d, length: 600, easing: Easing.CubicIn));
                
                card.AnimateDonut();
            }

            await Task.WhenAll(flyInAnimations);
        }

        async Task FlyAwayExhibitCards()
        {
            List<Task> flyAwayAnimations = new List<Task>();

            foreach (var card in _exhibits)
            {
                await Task.Delay(200);

                flyAwayAnimations.Add(card.TransitionTo(x => x.Opacity, 0d, length: 600, easing: Easing.CubicIn));
                flyAwayAnimations.Add(card.TransitionTo(x => x.TranslationX, 400d, length: 600, easing: Easing.CubicIn));
            }

            await Task.WhenAll(flyAwayAnimations);
        }
    }
}
