using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Views;
using AndroidX.Core.View;
using Plugin.MaterialDesignControls.Material3;
using Plugin.MaterialDesignControls.Material3.Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MaterialCard), typeof(MaterialCardRenderer))]
namespace Plugin.MaterialDesignControls.Material3.Android
{
    public class MaterialCardRenderer : Xamarin.Forms.Platform.Android.FastRenderers.FrameRenderer
    {
        public static void Init() { }

        public MaterialCardRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null && Control != null)
            {
                DrawBackgroundAndBorder();
                DrawShadow();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(MaterialCard) ||
                e.PropertyName == MaterialCard.CornerRadiusProperty.PropertyName ||
                e.PropertyName == MaterialCard.BackgroundColorProperty.PropertyName ||
                e.PropertyName == MaterialCard.HasBorderProperty.PropertyName ||
                e.PropertyName == MaterialCard.BorderColorProperty.PropertyName ||
                e.PropertyName == MaterialCard.BorderWidthProperty.PropertyName ||
                e.PropertyName == "OutlineColor")
            {
                DrawBackgroundAndBorder();
            }
            else if (e.PropertyName == MaterialCard.HasShadowProperty.PropertyName ||
                e.PropertyName == MaterialCard.ShadowColorProperty.PropertyName ||
                e.PropertyName == MaterialCard.AndroidElevationProperty.PropertyName)
            {
                DrawShadow();
            }
            else if (e.PropertyName == MaterialCard.TypeProperty.PropertyName)
            {
                DrawBackgroundAndBorder();
                DrawShadow();
            }
        }

        public void DrawShadow()
        {
            if (Element is MaterialCard card)
            {
                Elevation = 0;
                //TranslationZ = 0;

                var hasShadow = card.Type == MaterialCardType.Elevated || (card.Type == MaterialCardType.Custom && card.HasShadow);
                if (hasShadow)
                {
                    ViewCompat.SetElevation(this, Context.ToPixels(card.AndroidElevation));

                    // Shadow color only exists on Pie and newer
                    if (Build.VERSION.SdkInt >= BuildVersionCodes.P)
                    {
                        var shadowColor = card.ShadowColor.ToAndroid();
                        SetOutlineAmbientShadowColor(shadowColor);
                        SetOutlineSpotShadowColor(shadowColor);
                    }

                    // To show shadow we need to clip
                    OutlineProvider = new RoundedCornerOutlineProvider(card, Context.ToPixels);
                    ClipToOutline = true;

                    return;
                }

                OutlineProvider = null;
                ClipToOutline = false;
                ViewCompat.SetElevation(this, 0);
            }
        }

        private void DrawBackgroundAndBorder()
        {
            if (Element is MaterialCard card)
            {
                var topLeftCorner = Context.ToPixels(card.CornerRadius.TopLeft);
                var topRightCorner = Context.ToPixels(card.CornerRadius.TopRight);
                var bottomLeftCorner = Context.ToPixels(card.CornerRadius.BottomLeft);
                var bottomRightCorner = Context.ToPixels(card.CornerRadius.BottomRight);

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
                                
                var hasBorder = card.Type == MaterialCardType.Outlined || (card.Type == MaterialCardType.Custom && card.HasBorder);
                var borderWidth = hasBorder ? Convert.ToInt32(Context.ToPixels(card.BorderWidth)) : 0;
                var backgroundColor = card.Type == MaterialCardType.Outlined ? Xamarin.Forms.Color.Transparent : card.BackgroundColor;
                var borderColor = hasBorder ? card.BorderColor : card.BackgroundColor;

                if (Control.Background is GradientDrawable backgroundGradient)
                {
                    backgroundGradient.SetCornerRadii(cornerRadii);

                    if (card.Type != MaterialCardType.Outlined)
                    {
                        backgroundGradient.SetTint(backgroundColor.ToAndroid());
                        backgroundGradient.SetTintMode(PorterDuff.Mode.Multiply);
                    }
                  
                    if (hasBorder)
                    {
                        backgroundGradient.SetStroke(borderWidth, borderColor.ToAndroid());
                    }
                }
            }
        }
    }

    public class RoundedCornerOutlineProvider : ViewOutlineProvider
    {
        private readonly MaterialCard _card;
        private readonly Func<double, float> _convertToPixels;

        public RoundedCornerOutlineProvider(MaterialCard card, Func<double, float> convertToPixels)
        {
            _card = card;
            _convertToPixels = convertToPixels;
        }

        public override void GetOutline(global::Android.Views.View view, Outline outline)
        {
            var path = CreateRoundedRectPath(view.Width, view.Height,
                    _convertToPixels(_card.CornerRadius.TopLeft),
                    _convertToPixels(_card.CornerRadius.TopRight),
                    _convertToPixels(_card.CornerRadius.BottomRight),
                    _convertToPixels(_card.CornerRadius.BottomLeft));

            if (path.IsConvex)
                outline.SetConvexPath(path);
        }

        public Path CreateRoundedRectPath(float rectWidth, float rectHeight, float topLeft, float topRight, float bottomRight, float bottomLeft)
        {
            var path = new Path();

            var radii = new[] { topLeft, topLeft,
                                topRight, topRight,
                                bottomRight, bottomRight,
                                bottomLeft, bottomLeft };

            path.AddRoundRect(0, 0, rectWidth, rectHeight, radii, Path.Direction.Ccw);
            path.Close();

            return path;
        }
    }
}