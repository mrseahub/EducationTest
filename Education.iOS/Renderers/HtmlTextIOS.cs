using System;
using Education.iOS.Renderers;
using Education.Views.Components;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(HtmlText), typeof(HtmlTextIOS))]
namespace Education.iOS.Renderers
{
    public class HtmlTextIOS : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            var view = (HtmlText)Element;
            if (view == null) return;

            var attr = new NSAttributedStringDocumentAttributes();
            var nsError = new NSError();
            attr.DocumentType = NSDocumentType.HTML;
            attr.StringEncoding = NSStringEncoding.UTF8;
            Control.AttributedText = new NSAttributedString(view.Text, attr, ref nsError);
        }
    }
}
