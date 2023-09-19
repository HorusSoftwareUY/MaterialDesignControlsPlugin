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
using Android.Graphics;
using Android.Views;
using Android.Graphics.Drawables.Shapes;
using Xamarin.Forms.Shapes;
using System;
using AndroidGraphics = Android.Graphics;

[assembly: ExportRenderer(typeof(MaterialCard), typeof(MaterialCardRenderer))]
namespace Plugin.MaterialDesignControls.Material3.Android
{
    public class MaterialCardRenderer : Xamarin.Forms.Platform.Android.FastRenderers.FrameRenderer
    {
        public static void Init() { }

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
                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                {
                    this.Elevation = 0;
                    this.TranslationZ = 0;

                    bool hasShadowOrElevation = customFrame.HasShadow;

                    if (hasShadowOrElevation)
                    {
                        ViewCompat.SetElevation(this, Context.ToPixels(customFrame.AndroidElevation));

                        // Color only exists on Pie and beyond.
                        if (Build.VERSION.SdkInt >= BuildVersionCodes.P)
                        {
                            this.SetOutlineAmbientShadowColor(customFrame.ShadowColor.ToAndroid());
                            this.SetOutlineSpotShadowColor(customFrame.ShadowColor.ToAndroid());
                        }
                    }

                    if (hasShadowOrElevation)
                    {
                        // To have shadow show up, we need to clip.
                        this.OutlineProvider = new RoundedCornerOutlineProvider(customFrame, Context.ToPixels);
                        this.ClipToOutline = true;
                    }
                    else
                    {
                        this.OutlineProvider = null;
                        this.ClipToOutline = false;
                    }
                }
            }
        }
    }

    public class RoundedCornerOutlineProvider : ViewOutlineProvider
    {
        private readonly MaterialCard _pancake;
        private readonly Func<double, float> _convertToPixels;

        public RoundedCornerOutlineProvider(MaterialCard pancake, Func<double, float> convertToPixels)
        {
            _pancake = pancake;
            _convertToPixels = convertToPixels;
        }

        public override void GetOutline(global::Android.Views.View view, Outline outline)
        {
            var path = CreateRoundedRectPath(view.Width, view.Height,
                    _convertToPixels(_pancake.CornerRadius),
                    _convertToPixels(_pancake.CornerRadius),
                    _convertToPixels(_pancake.CornerRadius),
                    _convertToPixels(_pancake.CornerRadius));
            if (path.IsConvex)
                outline.SetConvexPath(path);
        }

        public AndroidGraphics.Path CreateRoundedRectPath(float rectWidth, float rectHeight, float topLeft, float topRight, float bottomRight, float bottomLeft)
        {
            var path = new AndroidGraphics.Path();
            var radii = new[] { topLeft, topLeft,
                                topRight, topRight,
                                bottomRight, bottomRight,
                                bottomLeft, bottomLeft };
            path.AddRoundRect(new RectF(0, 0, rectWidth, rectHeight), radii, AndroidGraphics.Path.Direction.Ccw);
            path.Close();
            return path;
        }
    }
}