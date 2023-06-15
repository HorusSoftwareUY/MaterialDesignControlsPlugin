using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3.Implementations
{
    public partial class MaterialCard : Frame
    {
        #region Attributes & Properties

        public static readonly BindableProperty iOSBorderWidthProperty =
            BindableProperty.Create(nameof(iOSBorderWidth), typeof(float), typeof(MaterialCard), 0f);

        public float iOSBorderWidth
        {
            get { return (float)GetValue(iOSBorderWidthProperty); }
            set { SetValue(iOSBorderWidthProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusTopLeftProperty =
            BindableProperty.Create(nameof(CornerRadiusTopLeft), typeof(bool), typeof(MaterialCard), false);

        public bool CornerRadiusTopLeft
        {
            get { return (bool)GetValue(CornerRadiusTopLeftProperty); }
            set { SetValue(CornerRadiusTopLeftProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusTopRightProperty =
            BindableProperty.Create(nameof(CornerRadiusTopRight), typeof(bool), typeof(MaterialCard), false);

        public bool CornerRadiusTopRight
        {
            get { return (bool)GetValue(CornerRadiusTopRightProperty); }
            set { SetValue(CornerRadiusTopRightProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusBottomRightProperty =
            BindableProperty.Create(nameof(CornerRadiusBottomRight), typeof(bool), typeof(MaterialCard), false);

        public bool CornerRadiusBottomRight
        {
            get { return (bool)GetValue(CornerRadiusBottomRightProperty); }
            set { SetValue(CornerRadiusBottomRightProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusBottomLeftProperty =
            BindableProperty.Create(nameof(CornerRadiusBottomLeft), typeof(bool), typeof(MaterialCard), false);

        public bool CornerRadiusBottomLeft
        {
            get { return (bool)GetValue(CornerRadiusBottomLeftProperty); }
            set { SetValue(CornerRadiusBottomLeftProperty, value); }
        }

        public static readonly BindableProperty ShadowColorProperty =
            BindableProperty.Create(nameof(ShadowColor), typeof(Color), typeof(MaterialCard), defaultValue: Color.Transparent);

        public Color ShadowColor
        {
            get => (Color)GetValue(ShadowColorProperty);
            set => SetValue(ShadowColorProperty, value);
        }

        public static readonly BindableProperty AndroidElevationProperty =
            BindableProperty.Create(nameof(AndroidElevation), typeof(double), typeof(MaterialCard), defaultValue: 0.0);

        public double AndroidElevation
        {
            get => (double)GetValue(AndroidElevationProperty);
            set => SetValue(AndroidElevationProperty, value);
        }

        public static readonly BindableProperty AndroidBorderAlphaProperty =
            BindableProperty.Create(nameof(AndroidBorderAlpha), typeof(double), typeof(MaterialCard), defaultValue: 0.0);

        public double AndroidBorderAlpha
        {
            get => (double)GetValue(AndroidBorderAlphaProperty);
            set => SetValue(AndroidBorderAlphaProperty, value);
        }

        public static readonly BindableProperty iOSShadowRadiusProperty =
            BindableProperty.Create(nameof(iOSShadowRadius), typeof(double), typeof(MaterialCard), defaultValue: 0.0);

        public double iOSShadowRadius
        {
            get => (double)GetValue(iOSShadowRadiusProperty);
            set => SetValue(iOSShadowRadiusProperty, value);
        }

        public static readonly BindableProperty iOSShadowOpacityProperty =
            BindableProperty.Create(nameof(iOSShadowOpacity), typeof(double), typeof(MaterialCard), defaultValue: 0.0);

        public double iOSShadowOpacity
        {
            get => (double)GetValue(iOSShadowOpacityProperty);
            set => SetValue(iOSShadowOpacityProperty, value);
        }

        public static readonly BindableProperty iOSShadowOffsetProperty =
            BindableProperty.Create(nameof(iOSShadowOffset), typeof(Size), typeof(MaterialCard), defaultValue: null);

        public Size iOSShadowOffset
        {
            get => (Size)GetValue(iOSShadowOffsetProperty);
            set => SetValue(iOSShadowOffsetProperty, value);
        }
        #endregion
    }
}
