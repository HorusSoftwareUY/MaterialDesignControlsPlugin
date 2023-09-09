using System;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Util;
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

                if (customSlider.ThumbColor != Xamarin.Forms.Color.Transparent)
                    Control.Thumb.SetColorFilter(customSlider.ThumbColor.ToAndroid(), PorterDuff.Mode.SrcIn);

                BuildVersionCodes androidVersion = Build.VERSION.SdkInt;

                if (androidVersion >= BuildVersionCodes.M)
                {
                    var trackCornerRadius = DpToPixels(customSlider.TrackCornerRadius);
                    var trackHeight = DpToPixels(customSlider.TrackHeight);

                    var progressGradientDrawable = new GradientDrawable(GradientDrawable.Orientation.LeftRight, new int[] { customSlider.ActiveTrackColor.ToAndroid(), customSlider.ActiveTrackColor.ToAndroid() });
                    progressGradientDrawable.SetCornerRadius(trackCornerRadius);
                    var progress = new ClipDrawable(progressGradientDrawable, GravityFlags.Left, ClipDrawableOrientation.Horizontal);

                    var background = new GradientDrawable();
                    background.SetColor(customSlider.InactiveTrackColor.ToAndroid());
                    background.SetCornerRadius(trackCornerRadius);

                    var progressDrawable = new LayerDrawable(new Drawable[] { background, progress });

                    progressDrawable.SetLayerHeight(0, (int)trackHeight);
                    progressDrawable.SetLayerHeight(1, (int)trackHeight);
                    progressDrawable.SetLayerGravity(0, GravityFlags.CenterVertical);
                    progressDrawable.SetLayerGravity(1, GravityFlags.CenterVertical);
                    Control.ProgressDrawable = progressDrawable;
                }
                else
                {
                    Element.MinimumTrackColor = customSlider.ActiveTrackColor;

                    Control.SecondaryProgressTintList = ColorStateList.ValueOf(customSlider.InactiveTrackColor.ToAndroid());
                    Control.SecondaryProgressTintMode = PorterDuff.Mode.SrcIn;
                    Control.SecondaryProgress = int.MaxValue;
                }

                Control.SetPadding(52, Control.PaddingTop, 52, Control.PaddingBottom);

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
        }

        private float DpToPixels(float valueInDp)
        {
            DisplayMetrics metrics = Context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}