using System;

using Xamarin.Forms;

namespace Education.Views.Components
{
    public class PreloaderListFooter : AbsoluteLayout
    {
        public PreloaderListFooter()
        {
            var layout = new AbsoluteLayout();
            var activity = new ActivityIndicator();

            activity.SetBinding(ActivityIndicator.IsRunningProperty, new Binding("IsLoading"));
            layout.SetBinding(IsVisibleProperty, new Binding("IsLoading"));

            layout.Children.Add(activity, new Rectangle(.5, .5, 45, 45), AbsoluteLayoutFlags.PositionProportional);
            Children.Add(layout, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.SizeProportional);
        }
    }
}

