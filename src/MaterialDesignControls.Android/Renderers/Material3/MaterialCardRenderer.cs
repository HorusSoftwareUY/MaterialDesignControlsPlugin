using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
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

        public MaterialCardRenderer(Context context)
            : base(context)
        {
        }

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
        }

        public void DrawShadow()
        {
            Elevation = 0;
            TranslationZ = 0;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop && Element is MaterialCard card &&
                (card.Type == MaterialCardType.Elevated || card.Type == MaterialCardType.Custom))
            {
                bool hasShadowOrElevation = card.HasShadow && card.AndroidElevation > 0;
                if (hasShadowOrElevation)
                {
                    ViewCompat.SetElevation(this, card.AndroidElevation);

                    // Color only exists on Pie and beyond.
                    if (Build.VERSION.SdkInt >= BuildVersionCodes.P)
                    {
                        SetOutlineAmbientShadowColor(card.ShadowColor.ToAndroid());
                        SetOutlineSpotShadowColor(card.ShadowColor.ToAndroid());
                    }

                    // To have shadow show up, we need to clip.
                    OutlineProvider = new RoundedCornerOutlineProvider(card, Context.ToPixels);
                    ClipToOutline = true;
                }
                else
                {
                    OutlineProvider = null;
                    ClipToOutline = false;
                }
            }
            else
            {
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

                if (card.Type == MaterialCardType.Custom)
                {
                    // Background that overrides native border to handle it ourselves
                    var backgroundShape = new RoundRectShape(cornerRadii, new RectF(), null);
                    var background = new ShapeDrawable(backgroundShape);
                    background.SetColorFilter(new PorterDuffColorFilter(card.BackgroundColor.ToAndroid(), PorterDuff.Mode.SrcIn));

                    var borderOffset = card.HasBorder ? Convert.ToInt32(Context.ToPixels(card.BorderWidth)) : 0;
                    if (borderOffset > 0 && Build.VERSION.SdkInt >= BuildVersionCodes.M)
                    {
                        var borderShape = new RoundRectShape(cornerRadii, new RectF(), null);
                        var border = new ShapeDrawable(borderShape);
                        border.SetColorFilter(new PorterDuffColorFilter(card.BorderColor.ToAndroid(), PorterDuff.Mode.SrcIn));

                        var layerDrawable = new LayerDrawable(new Drawable[] { border, background });
                        layerDrawable.SetLayerInset(1, borderOffset, borderOffset, borderOffset, borderOffset);
                        Control.Background = layerDrawable;
                    }
                }

                // If it's not custom card, just round corners and let background and border to be handled by default
                if (Control.Background is GradientDrawable backgroundGradient)
                {
                    backgroundGradient.SetCornerRadii(cornerRadii);
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