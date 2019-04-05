using System;
using System.Collections.Generic;
using Education.Models;
using Education.Services;
using Education.Views;
using Xamarin.Forms;

namespace Education.ViewModels
{
    public class NewsListViewModel : TappedListViewModel
    {

        List<NewsSingleModel> _news;
        public List<NewsSingleModel> News
        {
            get => _news ?? (_news = new List<NewsSingleModel>());
            set
            {
                if (_news != value)
                {
                    _news = value;
                    OnPropertyChanged("News");
                }
            }
        }

        public NewsListViewModel()
        {
            NewsLoad();
            ItemTapped = new Command((object item) => TapNavigation(new NewsSinglePage(item as NewsSingleModel)));
            RefreshCommand = new Command(NewsRefreshing);
        }

        public async void NewsLoad()
        {
            IsLoading = true;
            News = await Api.Get<List<NewsSingleModel>>(Api.NEWS_URL);
            IsLoading = false;
        }

        public async void NewsRefreshing()
        {
            IsRefreshing = true;
            News = await Api.Get<List<NewsSingleModel>>(Api.NEWS_URL);
            IsRefreshing = false;
        }
    }
}
