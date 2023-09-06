using System;
using CoreGraphics;
using System.ComponentModel;
using Plugin.MaterialDesignControls.iOS.Renderers.Material3;
using Plugin.MaterialDesignControls.Material3.Implementations;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomCheckBox), typeof(MaterialCheckBoxRenderer))]
namespace Plugin.MaterialDesignControls.iOS.Renderers.Material3
{
	public class MaterialCheckBoxRenderer : ViewRenderer<CustomCheckBox, UIView>
    {
        private const float SideLength = 18f;
        private bool firstTime = true;

        protected override void OnElementChanged(ElementChangedEventArgs<CustomCheckBox> e)
        {
            base.OnElementChanged(e);
            if (Control == null)
            {
                var checkBox = new UIView();
                SetNativeControl(checkBox);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == CustomCheckBox.IsCheckedProperty.PropertyName || firstTime)
            {
                SetNeedsDisplay();
            }
        }

        public override void Draw(CGRect rect)
        {
            var boxPath = UIBezierPath.FromRoundedRect(new CGRect(1f, 1f, SideLength, SideLength), UIRectCorner.AllCorners, new CGSize(2, 2));

            Element.Color.ToUIColor().SetStroke();
            boxPath.LineWidth = 2f;
            boxPath.Stroke();

            if (Element.IsChecked)
            {
                Element.Color.ToUIColor().SetFill();
                boxPath.Fill(CGBlendMode.Normal, 1f);

                Xamarin.Forms.Color.White.ToUIColor().SetStroke();
                var checkPath = new UIBezierPath();
                checkPath.MoveTo(new CGPoint(1 + .2 * SideLength, 1 + .475 * SideLength));
                checkPath.AddLineTo(new CGPoint(1 + .45 * SideLength, 1 + .675 * SideLength));
                checkPath.AddLineTo(new CGPoint(1 + .8 * SideLength, 1 + .275 * SideLength));
                checkPath.LineWidth = 3f;
                checkPath.Stroke();
            }

            firstTime = false;
        }

        public override CGSize SizeThatFits(CGSize size)
        {
            return new CGSize(SideLength + 2, SideLength + 2);
        }
    }
}