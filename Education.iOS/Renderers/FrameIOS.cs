using System;
using System.ComponentModel;
using System.Diagnostics;
using CoreAnimation;
using CoreGraphics;
using Semeiniy.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Frame), typeof(FrameIOS))]
namespace Semeiniy.iOS.Renderers
{
    public class FrameIOS : FrameRenderer
    {

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            Layer.BorderColor = UIColor.White.CGColor;
            Layer.MasksToBounds = false;
            Layer.ShadowOffset = new CGSize(2, 2);
            Layer.ShadowRadius = 4;
            Layer.ShadowOpacity = 0.6f;
            Layer.ShadowColor = UIColor.Gray.CGColor;
        }
    }
}
