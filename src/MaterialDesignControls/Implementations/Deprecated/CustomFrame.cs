using System;
using Xamarin.Forms;
namespace Plugin.MaterialDesignControls.Implementations
{
    [Obsolete("CustomFrame is deprecated, please use MaterialCard of Material 3 instead.")]
    public class CustomFrame : Frame
    {
        #region Properties

        public static readonly BindableProperty ShadowColorProperty =
            BindableProperty.Create(nameof(ShadowColor), typeof(Color), typeof(CustomFrame), defaultValue: Color.LightGray);

        public Color ShadowColor
        {
            get => (Color)GetValue(ShadowColorProperty);
            set => SetValue(ShadowColorProperty, value);
        }

        public static readonly BindableProperty AndroidElevationProperty =
            BindableProperty.Create(nameof(AndroidElevation), typeof(double), typeof(CustomFrame), defaultValue: 30.0);

        public double AndroidElevation
        {
            get => (double)GetValue(AndroidElevationProperty);
            set => SetValue(AndroidElevationProperty, value);
        }

        public static readonly BindableProperty AndroidBorderAlphaProperty =
            BindableProperty.Create(nameof(AndroidBorderAlpha), typeof(double), typeof(CustomFrame), defaultValue: 0.1);

        public double AndroidBorderAlpha
        {
            get => (double)GetValue(AndroidBorderAlphaProperty);
            set => SetValue(AndroidBorderAlphaProperty, value);
        }

        public static readonly BindableProperty iOSShadowRadiusProperty =
            BindableProperty.Create(nameof(iOSShadowRadius), typeof(double), typeof(CustomFrame), defaultValue: 5.0);

        public double iOSShadowRadius
        {
            get => (double)GetValue(iOSShadowRadiusProperty);
            set => SetValue(iOSShadowRadiusProperty, value);
        }

        public static readonly BindableProperty iOSShadowOpacityProperty =
            BindableProperty.Create(nameof(iOSShadowOpacity), typeof(double), typeof(CustomFrame), defaultValue: 0.1);

        public double iOSShadowOpacity
        {
            get => (double)GetValue(iOSShadowOpacityProperty);
            set => SetValue(iOSShadowOpacityProperty, value);
        }

        public static readonly BindableProperty iOSShadowOffsetProperty =
            BindableProperty.Create(nameof(iOSShadowOffset), typeof(Size), typeof(CustomFrame), defaultValue: new Size(-1, 8));

        public Size iOSShadowOffset
        {
            get => (Size)GetValue(iOSShadowOffsetProperty);
            set => SetValue(iOSShadowOffsetProperty, value);
        }

        #endregion Properties
    }
}