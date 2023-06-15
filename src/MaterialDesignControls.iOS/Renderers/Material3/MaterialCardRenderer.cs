using CoreAnimation;
using CoreGraphics;
using Plugin.MaterialDesignControls.Material3;
using Plugin.MaterialDesignControls.Material3.iOS;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MaterialCard), typeof(MaterialCardRenderer))]
namespace Plugin.MaterialDesignControls.Material3.iOS
{
    public class MaterialCardRenderer : ViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

            Draw();
            SetNeedsDisplay();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (new string[] { "BackgroundColor", "BorderColor", "iOSBorderWidth", "CornerRadius", "Height", "Width", "CornerRadiusTopLeft", "CornerRadiusTopRight", "CornerRadiusBottomLeft", "CornerRadiusBottomRight", "iOSShadowOffset", "iOSShadowOpacity", "iOSShadowRadius", "ShadowColor" }.Contains(e.PropertyName))
            {
                Draw();
                SetNeedsDisplay();
            }
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            Draw();
        }

        private void Draw()
        {
            var element = (MaterialCard)Element;
            Layer.BackgroundColor = element.BackgroundColor.ToCGColor();
            DrawBorder(element);
            DrawShadow(element);
        }

        private void DrawBorder(MaterialCard element)
        {
            try
            {
                Layer.MaskedCorners = GetMaskCorner(element);
            }
            catch
            {
            };

            Layer.CornerRadius = element.CornerRadius;
            if (element.HasBorder)
            {
                Layer.BorderColor = element.BorderColor.ToCGColor();
                Layer.BorderWidth = element.iOSBorderWidth;
            }

        }

        private CACornerMask GetMaskCorner(MaterialCard element)
        {

            if (!element.CornerRadiusTopLeft && !element.CornerRadiusTopRight && !element.CornerRadiusBottomLeft && !element.CornerRadiusBottomRight)
                return (CACornerMask)0;
            else if (element.CornerRadiusTopLeft && !element.CornerRadiusTopRight && !element.CornerRadiusBottomLeft && !element.CornerRadiusBottomRight)
                return (CACornerMask)1;
            else if (!element.CornerRadiusTopLeft && element.CornerRadiusTopRight && !element.CornerRadiusBottomLeft && !element.CornerRadiusBottomRight)
                return (CACornerMask)2;
            else if (element.CornerRadiusTopLeft && element.CornerRadiusTopRight && !element.CornerRadiusBottomLeft && !element.CornerRadiusBottomRight)
                return (CACornerMask)3;
            else if (!element.CornerRadiusTopLeft && !element.CornerRadiusTopRight && element.CornerRadiusBottomLeft && !element.CornerRadiusBottomRight)
                return (CACornerMask)4;
            else if (element.CornerRadiusTopLeft && !element.CornerRadiusTopRight && element.CornerRadiusBottomLeft && !element.CornerRadiusBottomRight)
                return (CACornerMask)5;
            else if (!element.CornerRadiusTopLeft && element.CornerRadiusTopRight && element.CornerRadiusBottomLeft && !element.CornerRadiusBottomRight)
                return (CACornerMask)6;
            else if (element.CornerRadiusTopLeft && element.CornerRadiusTopRight && element.CornerRadiusBottomLeft && !element.CornerRadiusBottomRight)
                return (CACornerMask)7;
            else if (!element.CornerRadiusTopLeft && !element.CornerRadiusTopRight && !element.CornerRadiusBottomLeft && element.CornerRadiusBottomRight)
                return (CACornerMask)8;
            else if (element.CornerRadiusTopLeft && !element.CornerRadiusTopRight && !element.CornerRadiusBottomLeft && element.CornerRadiusBottomRight)
                return (CACornerMask)9;
            else if (!element.CornerRadiusTopLeft && element.CornerRadiusTopRight && !element.CornerRadiusBottomLeft && element.CornerRadiusBottomRight)
                return (CACornerMask)10;
            else if (element.CornerRadiusTopLeft && element.CornerRadiusTopRight && !element.CornerRadiusBottomLeft && element.CornerRadiusBottomRight)
                return (CACornerMask)11;
            else if (!element.CornerRadiusTopLeft && !element.CornerRadiusTopRight && element.CornerRadiusBottomLeft && element.CornerRadiusBottomRight)
                return (CACornerMask)12;
            else if (element.CornerRadiusTopLeft && !element.CornerRadiusTopRight && element.CornerRadiusBottomLeft && element.CornerRadiusBottomRight)
                return (CACornerMask)13;
            else if (!element.CornerRadiusTopLeft && element.CornerRadiusTopRight && element.CornerRadiusBottomLeft && element.CornerRadiusBottomRight)
                return (CACornerMask)14;
            else if (element.CornerRadiusTopLeft && element.CornerRadiusTopRight && element.CornerRadiusBottomLeft && element.CornerRadiusBottomRight)
                return (CACornerMask)15;

            //0: no rounded corners
            // 1: top left
            //2: top right
            //3: top left &right(both top corners)
            //4: bottom left
            //5: top & bottom left(both left corners)
            //6: top right &bottom left
            //7: top left &right, bottom left(all corners except bottom right)
            //8: bottom right
            //9: top left, bottom right
            //10: top & bottom right(both right corners)
            //11: both top corners, bottom right(all corners except bottom left)
            //12: bottom left &right(both bottom corners)
            //13: bottom left &right, top left(all corners except top right)
            //14: bottom left &right, top right(all corners except top left)
            //15: all corners rounded

            return 0;
        }

        public void DrawShadow(MaterialCard customFrame)
        {
            if (customFrame != null)
            {
                if (customFrame.HasShadow)
                {
                    Layer.ShadowColor = customFrame.ShadowColor.ToCGColor();
                    Layer.ShadowRadius = (float)customFrame.iOSShadowRadius;
                    Layer.ShadowOpacity = (float)customFrame.iOSShadowOpacity;
                    Layer.ShadowOffset = new SizeF((float)customFrame.iOSShadowOffset.Width, (float)customFrame.iOSShadowOffset.Height);
                }
            }
        }
    }
}