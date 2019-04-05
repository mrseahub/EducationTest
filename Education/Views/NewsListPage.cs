using System;
using Education.ViewModels;
using Education.Views.Components;
using Xamarin.Forms;
using Education.Global;

namespace Education.Views
{
    public class NewsListPage : ContentPage
    {
        public NewsListPage()
        {
            var context = new NewsListViewModel
            {
                navigation = Navigation
            };

            BindingContext = context;

            var newsList = new ListView(ListViewCachingStrategy.RecycleElementAndDataTemplate)
            {
                ItemTemplate = new DataTemplate(typeof(NewsListItem)),
                Footer = new PreloaderListFooter { HeightRequest = NewsListItem.RowHeight },
                RowHeight = NewsListItem.RowHeight,
                IsPullToRefreshEnabled = true,
                RefreshCommand = context.RefreshCommand,
                SelectionMode = ListViewSelectionMode.None
            };

            newsList.ItemTapped += (sender, e) => {
                if (context.ItemTapped != null) context.ItemTapped.Execute(e.Item);
            };

            newsList.SetBinding(ItemsView<Cell>.ItemsSourceProperty, "News");
            newsList.SetBinding(ListView.IsRefreshingProperty, "IsRefreshing");

            Title = Constants.NEWS_LISTPAGE_TITLE;
            Content = newsList;
        }
    }
}

