using System;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.OS;
using Android.Views;
using Android.Widget;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomSlider), typeof(Plugin.MaterialDesignControls.Material3.Android.MaterialSliderRenderer))]
namespace Plugin.MaterialDesignControls.Material3.Android
{
    public class MaterialSliderRenderer : SliderRenderer
    {
        public static void Init() { }

        public MaterialSliderRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var customSlider = (CustomSlider)Element;
                
                var activeTrackColor = customSlider.ActiveTrackColor.ToAndroid();
                var inactiveTrackColor = customSlider.InactiveTrackColor.ToAndroid();

                Control.SetPadding(0, 0, Control.Thumb.IntrinsicWidth, 0);

                BuildVersionCodes androidVersion = Build.VERSION.SdkInt;
                if (androidVersion >= BuildVersionCodes.M)
                {
                    var trackCornerRadius = customSlider.TrackCornerRadius.DpToPixels(Context);
                    var trackHeight = customSlider.TrackHeight.DpToPixels(Context);

                    var radius = new float[] { trackCornerRadius, trackCornerRadius, trackCornerRadius, trackCornerRadius, trackCornerRadius, trackCornerRadius, trackCornerRadius, trackCornerRadius };
                    var trackShape = new RoundRectShape(radius, new RectF(), radius);
                    
                    var background = new ShapeDrawable(trackShape);
                    background.SetColorFilter(new PorterDuffColorFilter(inactiveTrackColor, PorterDuff.Mode.SrcIn));

                    var progress = new ShapeDrawable(trackShape);
                    progress.SetColorFilter(new PorterDuffColorFilter(activeTrackColor, PorterDuff.Mode.SrcIn));
                    var clippedProgress = new ClipDrawable(progress, GravityFlags.Start, ClipDrawableOrientation.Horizontal);

                    var progressDrawable = new LayerDrawable(new Drawable[] { background, clippedProgress });
                    progressDrawable.SetLayerHeight(0, trackHeight);
                    progressDrawable.SetLayerGravity(0, GravityFlags.CenterVertical);
                    progressDrawable.SetLayerHeight(1, trackHeight);
                    progressDrawable.SetLayerGravity(1, GravityFlags.CenterVertical);
                    Control.ProgressDrawable = progressDrawable;

                    var progressToLevel = ((double)Control.Progress / (double)Control.Max) * 10000;
                    Control.ProgressDrawable.SetLevel(Convert.ToInt32(progressToLevel));
                }
                else
                {
                    Control.ProgressTintList = ColorStateList.ValueOf(activeTrackColor);
                    Control.ProgressTintMode = PorterDuff.Mode.SrcIn;

                    Control.ProgressBackgroundTintList = ColorStateList.ValueOf(inactiveTrackColor);
                    Control.ProgressBackgroundTintMode = PorterDuff.Mode.SrcIn;
                }

                if (customSlider.ThumbImageSource == null && customSlider.ThumbColor != Xamarin.Forms.Color.Transparent)
                {
                    Control.Thumb.SetColorFilter(new PorterDuffColorFilter(customSlider.ThumbColor.ToAndroid(), PorterDuff.Mode.SrcIn));
                }

                if (customSlider.UserInteractionEnabled)
                {
                    Control.SplitTrack = true;
                    Control.Thumb.Mutate().SetAlpha(255);
                }
                else
                {
                    Control.SplitTrack = false;
                    Control.Thumb.Mutate().SetAlpha(0);
                    Control.Enabled = false;
                }
            }
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);

            BuildVersionCodes androidVersion = Build.VERSION.SdkInt;
            if (androidVersion < BuildVersionCodes.JellyBean)
                return;

            if (Control == null)
                return;

            SeekBar seekbar = Control;

            Drawable thumb = seekbar.Thumb;
            int thumbTop = (seekbar.Height / 2 - thumb.IntrinsicHeight / 2);

            thumb.SetBounds(thumb.Bounds.Left, thumbTop, thumb.Bounds.Left + thumb.IntrinsicWidth, thumbTop + thumb.IntrinsicHeight);
            Control.SetPadding(thumb.IntrinsicWidth / 2, 0, thumb.IntrinsicWidth / 2, 0);
        }
    }
}