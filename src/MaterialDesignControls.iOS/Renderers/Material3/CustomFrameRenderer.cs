using System.ComponentModel;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Plugin.MaterialDesignControls.Material3.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]

namespace Plugin.MaterialDesignControls.Material3.iOS
{
    public class CustomFrameRenderer : FrameRenderer
    {
        public override void LayoutSubviews()
        {
            base.LayoutSubviews();

            UpdateCornerRadius();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(CustomFrame.CornerRadius) ||
                e.PropertyName == nameof(CustomFrame))
            {
                UpdateCornerRadius();
            }
        }

        //protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        //{
        //    base.OnElementChanged(e);
        //    var elem = (CustomFrame)this.Element;
        //    if (elem != null)
        //    {

        //        // Border
        //        //this.Layer.CornerRadius = (float)elem.CornerRadius;
        //        this.Layer.Bounds.Inset(1, 1);
        //        Layer.BorderColor = elem.BorderColor.ToCGColor();
        //        Layer.BorderWidth = 1;
        //    }
        //}

        // A very basic way of retrieving same one value for all of the corners
        private double RetrieveCommonCornerRadius(CornerRadius cornerRadius)
        {
            var commonCornerRadius = cornerRadius.TopLeft;
            if (commonCornerRadius <= 0)
            {
                commonCornerRadius = cornerRadius.TopRight;
                if (commonCornerRadius <= 0)
                {
                    commonCornerRadius = cornerRadius.BottomLeft;
                    if (commonCornerRadius <= 0)
                    {
                        commonCornerRadius = cornerRadius.BottomRight;
                    }
                }
            }

            return commonCornerRadius;
        }

        private UIRectCorner RetrieveRoundedCorners(CornerRadius cornerRadius)
        {
            var roundedCorners = default(UIRectCorner);

            if (cornerRadius.TopLeft > 0)
            {
                roundedCorners |= UIRectCorner.TopLeft;
            }

            if (cornerRadius.TopRight > 0)
            {
                roundedCorners |= UIRectCorner.TopRight;
            }

            if (cornerRadius.BottomLeft > 0)
            {
                roundedCorners |= UIRectCorner.BottomLeft;
            }

            if (cornerRadius.BottomRight > 0)
            {
                roundedCorners |= UIRectCorner.BottomRight;
            }

            return roundedCorners;
        }

        private void UpdateCornerRadius()
        {
            var element = Element as CustomFrame;
            var cornerRadius = element?.CornerRadius;
            if (!cornerRadius.HasValue)
            {
                return;
            }

            var roundedCornerRadius = RetrieveCommonCornerRadius(cornerRadius.Value);
            if (roundedCornerRadius <= 0)
            {
                return;
            }

            //var roundedCorners = RetrieveRoundedCorners(cornerRadius.Value);

            //var path = UIBezierPath.FromRoundedRect(Bounds, roundedCorners, new CGSize(roundedCornerRadius, roundedCornerRadius));
            //var mask = new CAShapeLayer { Path = path.CGPath };


            var roundedCorners = RetrieveRoundedCorners(cornerRadius.Value);

            NativeView.Layer.MasksToBounds = true;
            var path = UIBezierPath.FromRoundedRect(Bounds, roundedCorners, new CGSize(roundedCornerRadius, roundedCornerRadius));
            var mask = new CAShapeLayer { Path = path.CGPath };
            mask.Frame = Bounds;
            mask.LineWidth = 1;
            mask.StrokeColor = UIColor.SystemBlueColor.CGColor;  // border color
            mask.FillColor = UIColor.Clear.CGColor;  // bg color , you need to set it as clear otherwise it will cover its child element
            mask.ShadowRadius = 0;
            //Element.pa

            Element.BorderColor = Color.Transparent;
            NativeView.Layer.Mask = mask;
            NativeView.Layer.AddSublayer(mask);
        }


        //public override void LayoutSubviews()
        //{
        //    base.LayoutSubviews();

        //    CAShapeLayer viewBorder = new CAShapeLayer();
        //    viewBorder.StrokeColor = UIColor.Blue.CGColor;
        //    viewBorder.FillColor = null;
        //    viewBorder.LineDashPattern = new NSNumber[] { new NSNumber(5), new NSNumber(2) };
        //    viewBorder.Frame = NativeView.Bounds;
        //    viewBorder.Path = UIBezierPath.FromRect(NativeView.Bounds).CGPath;
        //    Layer.AddSublayer(viewBorder);

        //    // If you don't want the shadow effect
        //    Element.HasShadow = false;
        //}
    }
}