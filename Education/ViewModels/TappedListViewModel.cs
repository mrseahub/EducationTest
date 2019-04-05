using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace Education.ViewModels
{
    public class TappedListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ItemTapped { get; set; }
        public INavigation navigation { get; set; }
        public ICommand RefreshCommand { get; set; }

        bool _isLoading;
        public bool IsLoading
        {
            get => _isLoading;
            set
            {
                if (_isLoading != value)
                {
                    _isLoading = value;
                    OnPropertyChanged("IsLoading");
                }
            }
        }

        bool _isRefreshing;
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                if (_isRefreshing != value)
                {
                    _isRefreshing = value;
                    OnPropertyChanged("IsRefreshing");
                }
            }
        }

        public TappedListViewModel()
        {
        }

        public async void TapNavigation(Page page)
        {
            var stack = navigation.NavigationStack;
            if (stack[stack.Count - 1].GetType() != page.GetType()
                || (!string.IsNullOrEmpty(stack[stack.Count - 1].Title)
                    && !string.IsNullOrEmpty(page.Title)
                    && stack[stack.Count - 1].Title != page.Title))
            {
                await navigation.PushAsync(page);
            }

        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
