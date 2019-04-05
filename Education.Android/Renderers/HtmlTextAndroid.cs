using System;
using Android.Content;
using Android.Support.V4.Text;
using Android.Widget;
using Education.Droid.Renderers;
using Education.Views.Components;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HtmlText), typeof(HtmlTextAndroid))]
namespace Education.Droid.Renderers
{
    public class HtmlTextAndroid : LabelRenderer
    {
        public HtmlTextAndroid(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var view = (HtmlText)Element;
            if (view == null) return;

            Control.SetText(HtmlCompat.FromHtml(view.Text, HtmlCompat.FromHtmlModeCompact), TextView.BufferType.Spannable);
        }
    }
}
