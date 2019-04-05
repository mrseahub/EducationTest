using System;

using Xamarin.Forms;

namespace Education.Views.Components
{
    public class NewsListItem : ViewCell
    {

        public static int RowHeight = 100;

        public NewsListItem()
        {
            var grid = new Grid { 
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width = 90 }
                },
                RowDefinitions = new RowDefinitionCollection
                {
                    new RowDefinition{ Height = GridLength.Auto }
                }
            };
            var image = new Image { Margin = 6 };
            var title = new Label { Margin = new Thickness(0, 6, 6, 0), FontSize = 12, MaxLines = 2, TextColor = Color.Black };
            var text = new Label { Margin = new Thickness(0, 0, 6, 0), FontSize = 11, MaxLines = 2, TextColor = Color.Gray };
            var date = new Label { FontSize = 11, MaxLines = 1, TextColor = Color.Gray };

            Grid.SetRowSpan(image, 3);

            image.SetBinding(Image.SourceProperty, "PreviewPath", mode: BindingMode.OneTime);
            title.SetBinding(Label.TextProperty, "Title", mode: BindingMode.OneTime);
            text.SetBinding(Label.TextProperty, "ShortText", mode: BindingMode.OneTime);
            date.SetBinding(Label.TextProperty, "Date", mode: BindingMode.OneTime);

            grid.Children.Add(image);
            grid.Children.Add(title, 1,0);
            grid.Children.Add(text, 1, 1);
            grid.Children.Add(date, 1, 2);

            View = grid;
        }
    }
}

