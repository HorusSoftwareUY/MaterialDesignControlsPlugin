using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Plugin.MaterialDesignControls.Material3.Android;
using Android.OS;
using Plugin.MaterialDesignControls.Material3;
using AndroidX.Core.View;
using Android.Util;
using Android.Animation;

[assembly: ExportRenderer(typeof(MaterialCard), typeof(MaterialCardRenderer))]
namespace Plugin.MaterialDesignControls.Material3.Android
{
    public class MaterialCardRenderer : Xamarin.Forms.Platform.Android.FastRenderers.FrameRenderer
    {
        public MaterialCardRenderer(Context context)
            : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null && Control != null)
            {
                UpdateCornerRadius();
                DrawShadow();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(MaterialCard.CornerRadius) ||
                e.PropertyName == nameof(MaterialCard))
            {
                UpdateCornerRadius();
            }
        }

        private void UpdateCornerRadius()
        {
            if (Control.Background is GradientDrawable backgroundGradient)
            {
                var cornerRadius = (Element as MaterialCard)?.CornerRadius;
                if (!cornerRadius.HasValue)
                {
                    return;
                }

                if (!(Element is MaterialCard element))
                {
                    return;
                }

                double topLeft = element.CornerRadiusTopLeft ? cornerRadius.Value : 0;
                double topRight = element.CornerRadiusTopRight ? cornerRadius.Value : 0;
                double bottomLeft = element.CornerRadiusBottomLeft ? cornerRadius.Value : 0;
                double bottomRight = element.CornerRadiusBottomRight ? cornerRadius.Value : 0;

                var topLeftCorner = Context.ToPixels(topLeft);
                var topRightCorner = Context.ToPixels(topRight);
                var bottomLeftCorner = Context.ToPixels(bottomLeft);
                var bottomRightCorner = Context.ToPixels(bottomRight);

                var cornerRadii = new[]
                {
                    topLeftCorner,
                    topLeftCorner,

                    topRightCorner,
                    topRightCorner,

                    bottomRightCorner,
                    bottomRightCorner,

                    bottomLeftCorner,
                    bottomLeftCorner,
                };
                backgroundGradient.SetCornerRadii(cornerRadii);
            }
        }

        public void DrawShadow()
        {
            var customFrame = (MaterialCard)Element;
            if (customFrame != null)
            {
                if (customFrame.HasShadow)
                {

                    if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                    {
                        Control.StateListAnimator = new StateListAnimator();

                        SetOutlineSpotShadowColor(customFrame.ShadowColor.ToAndroid());
                        SetOutlineAmbientShadowColor(customFrame.ShadowColor.ToAndroid());
                        float elevation = ConvertDpToPixels(customFrame.AndroidElevation);
                        Control.SetElevation(elevation);
                    }
                    else
                    {
                        var borderColor = customFrame.ShadowColor.MultiplyAlpha(customFrame.AndroidBorderAlpha);
                        Element.BorderColor = borderColor;
                    }
                }
            }
        }

        private float ConvertDpToPixels(float dpValue)
        {
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, dpValue, Context.Resources.DisplayMetrics);
        }


    }
}