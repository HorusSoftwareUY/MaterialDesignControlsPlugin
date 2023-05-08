using CoreAnimation;
using CoreGraphics;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Plugin.MaterialDesignControls.Material3.iOS;
using System;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ContentBox), typeof(ContentBoxRenderer))]
namespace Plugin.MaterialDesignControls.Material3.iOS
{
    public class ContentBoxRenderer : ViewRenderer
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

            if (new string[] { "BackgroundColor", "BorderColor", "BorderWidth", "CornerRadius", "Height", "Width", "CornerRadiusTopLeft", "CornerRadiusTopRight", "CornerRadiusBottomLeft", "CornerRadiusBottomRight" }.Contains(e.PropertyName))
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
            var element = (ContentBox)Element;
            Layer.BackgroundColor = element.BackgroundColor.ToCGColor();
            DrawBorder(element);
            //DrawShadow(element.ShadowColor, element.CornerRadius, element.ShadowOpacity);
        }

        private void DrawBorder(ContentBox element)
        {
            try
            {
                Layer.MaskedCorners = GetMaskCorner(element);
            }
            catch
            {
            };

            Layer.CornerRadius = element.CornerRadius;
            Layer.BorderColor = element.BorderColor.ToCGColor();
            Layer.BorderWidth = element.BorderWidth;
        }

        private CACornerMask GetMaskCorner(ContentBox element)
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
    }
}