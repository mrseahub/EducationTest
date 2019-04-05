using System;
using Education.Models;
using Education.Views.Components;
using Xamarin.Forms;

namespace Education.Views
{
    public class NewsSinglePage : ContentPage
    {
        public NewsSinglePage(NewsSingleModel data)
        {
            var scroll = new ScrollView { Padding = new Thickness(0, 0, 0, 60)};
            var layout = new AbsoluteLayout { HeightRequest = App.ScreenHeight };
            var frame = new Frame { Padding = 0, BorderColor = Color.White };
            var grid = new Grid {
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition{ Height = GridLength.Auto },
                    new RowDefinition{ Height = GridLength.Auto }
                }
            };

            var image = new Image { Source = data.MainImagePath, Aspect = Aspect.AspectFill };
            var text = new HtmlText { Margin = 6, FontSize = 11, TextColor = Color.Black, Text = data.Text };
            var date = new Label { Margin = 6, FontSize = 11, MaxLines = 1, TextColor = Color.Gray, Text = data.Date.ToString() };

            grid.Children.Add(text);
            grid.Children.Add(date, 0, 1);

            scroll.Content = layout;
            frame.Content = grid;
            layout.Children.Add(image, new Rectangle(0, 0, 1, 100), AbsoluteLayoutFlags.WidthProportional);
            layout.Children.Add(frame, new Rectangle(.5, 84, 0.96, AbsoluteLayout.AutoSize), AbsoluteLayoutFlags.WidthProportional | AbsoluteLayoutFlags.XProportional);

            Title = data.Title;
            Content = scroll;
        }
    }
}

