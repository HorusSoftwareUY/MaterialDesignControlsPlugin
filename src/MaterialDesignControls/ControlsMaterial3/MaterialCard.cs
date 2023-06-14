using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Styles;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Plugin.MaterialDesignControls.Material3
{
    public enum MaterialCardType
    {
        Elevated, Filled, Outlined, Custom
    }

    public partial class MaterialCard : Frame, ITouchAndPressEffectConsumer
    {
        #region Constructors
        public MaterialCard()
        {
            if (!_initialized)
            {
                _initialized = true;
                Initialize();
            }
        }
        #endregion Constructors

        #region Attributes
        private bool _initialized = false;

        #endregion Attributes


        #region Properties

        public static readonly BindableProperty TypeProperty =
                BindableProperty.Create(nameof(Type), typeof(MaterialCardType), typeof(MaterialCard), defaultValue: MaterialCardType.Filled);

        public MaterialCardType Type
        {
            get { return (MaterialCardType)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(MaterialCard), defaultValue: null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(MaterialCard), defaultValue: null);

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly new BindableProperty IsEnabledProperty =
            BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(MaterialCard), defaultValue: true);

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }


        public static readonly BindableProperty AnimationProperty =
            BindableProperty.Create(nameof(Animation), typeof(AnimationTypes), typeof(MaterialCard), defaultValue: null);

        public AnimationTypes Animation
        {
            get { return (AnimationTypes)GetValue(AnimationProperty); }
            set { SetValue(AnimationProperty, value); }
        }

        public static readonly BindableProperty AnimationParameterProperty =
            BindableProperty.Create(nameof(AnimationParameter), typeof(double?), typeof(MaterialCard), defaultValue: null);

        public double? AnimationParameter
        {
            get { return (double?)GetValue(AnimationParameterProperty); }
            set { SetValue(AnimationParameterProperty, value); }
        }

        public static readonly BindableProperty CustomAnimationProperty =
            BindableProperty.Create(nameof(CustomAnimation), typeof(ICustomAnimation), typeof(MaterialCard), defaultValue: null);

        public ICustomAnimation CustomAnimation
        {
            get { return (ICustomAnimation)GetValue(CustomAnimationProperty); }
            set { SetValue(CustomAnimationProperty, value); }
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

        public static readonly BindableProperty HasBorderProperty =
            BindableProperty.Create(nameof(HasBorder), typeof(bool), typeof(MaterialCard), defaultValue: false);

        public bool HasBorder
        {
            get { return (bool)GetValue(HasBorderProperty); }
            set { SetValue(HasBorderProperty, value); }
        }

        #region iOS
        public static readonly BindableProperty iOSBorderWidthProperty =
            BindableProperty.Create(nameof(iOSBorderWidth), typeof(float), typeof(MaterialCard), 0f);

        public float iOSBorderWidth
        {
            get { return (float)GetValue(iOSBorderWidthProperty); }
            set { SetValue(iOSBorderWidthProperty, value); }
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
        #endregion iOS

        #region Android
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
        #endregion Android


        #endregion Properties


        #region Methods

        private void Initialize()
        {
            _initialized = true;

            //TODO: if I add this effect, materialswitch doesn't work on android
            //Effects.Add(new TouchAndPressEffect());


            SetCardType();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            switch (propertyName)
            {
                case nameof(Type):
                case nameof(ShadowColor):
                case nameof(base.HasShadow):
                case nameof(BackgroundColor):
                case nameof(base.BorderColor):
                case nameof(AndroidElevation):
                    SetCardType();
                    break;

                //case nameof(Text):
                //case nameof(ToUpper):
                //    _textLabel.Text = ToUpper ? Text?.ToUpper() : Text;
                //    break;
                //case nameof(FontSize):
                //    _textLabel.FontSize = FontSize;
                //    break;
                //case nameof(FontFamily):
                //    _textLabel.FontFamily = FontFamily;
                //    break;
                //case nameof(CornerRadius):
                //    _frameLayout.CornerRadius = Convert.ToInt32(CornerRadius);
                //    break;
                //case nameof(LeadingIcon):
                //    if (LeadingIcon != null)
                //    {
                //        _leadingIconContentView.Content = LeadingIcon;
                //        _leadingIconContentView.IsVisible = true;
                //    }
                //    break;
                //case nameof(TrailingIcon):
                //    if (TrailingIcon != null)
                //    {
                //        _trailingIconContentView.Content = TrailingIcon;
                //        _trailingIconContentView.IsVisible = true;
                //    }
                //    break;
                //case nameof(IconSize):
                //    _leadingIconContentView.HeightRequest = IconSize;
                //    _leadingIconContentView.WidthRequest = IconSize;
                //    _trailingIconContentView.HeightRequest = IconSize;
                //    _trailingIconContentView.WidthRequest = IconSize;
                //    break;
                case nameof(IsEnabled):
                    VisualStateManager.GoToState(this, IsEnabled ? "Normal" : "Disabled");
                    break;
                //case nameof(ActivityIndicatorSize):
                //    _cntActivityIndicator.HeightRequest = ActivityIndicatorSize;
                //    _cntActivityIndicator.WidthRequest = ActivityIndicatorSize;
                //    break;
                //case nameof(CustomActivityIndicator):
                //    if (CustomActivityIndicator != null)
                //    {
                //        _cntActivityIndicator.Content = CustomActivityIndicator;
                //    }
                //    break;
                //case nameof(BusyColor):
                //    if (CustomActivityIndicator == null)
                //    {
                //        if (_activityIndicator == null)
                //        {
                //            _activityIndicator = new ActivityIndicator();
                //            _cntActivityIndicator.Content = _activityIndicator;
                //        }

                //        _activityIndicator.Color = BusyColor;
                //    }
                //    break;
                //case nameof(IsBusy):
                //    if (IsBusy)
                //    {
                //        if (CustomActivityIndicator == null)
                //        {
                //            if (_activityIndicator == null)
                //            {
                //                _activityIndicator = new ActivityIndicator { Color = BusyColor };
                //                _cntActivityIndicator.Content = _activityIndicator;
                //            }

                //            _activityIndicator.IsVisible = true;
                //            _activityIndicator.IsRunning = true;
                //        }

                //        _cntActivityIndicator.IsVisible = true;

                //        _frameLayout.IsVisible = false;
                //    }
                //    else
                //    {
                //        _frameLayout.IsVisible = true;

                //        if (CustomActivityIndicator == null)
                //        {
                //            if (_activityIndicator == null)
                //            {
                //                _activityIndicator = new ActivityIndicator();
                //                _cntActivityIndicator.Content = _activityIndicator;
                //            }

                //            _activityIndicator.IsVisible = false;
                //            _activityIndicator.IsRunning = false;
                //        }

                //        _cntActivityIndicator.IsVisible = false;
                //    }
                //    break;

                default:
                    base.OnPropertyChanged(propertyName);
                    break;


            }

            base.OnPropertyChanged(propertyName);
        }

        public void SetCardType()
        {
            switch (Type)
            {
                case MaterialCardType.Elevated:
                    HasBorder = false;
                    HasShadow = true;
                    BorderColor = Color.Transparent;
                    BackgroundColor = BackgroundColor != Color.Default ? BackgroundColor : DefaultStyles.BackgroundColor;
                    ShadowColor = ShadowColor != Color.Default ? ShadowColor : DefaultStyles.ShadowColor;
                    AndroidElevation = AndroidElevation != 0.0 ? AndroidElevation : 10.0;
                    break;
                case MaterialCardType.Filled:
                    HasShadow = false;
                    HasBorder = false;
                    BorderColor = Color.Transparent;
                    BackgroundColor = BackgroundColor != Color.Default ? BackgroundColor : DefaultStyles.BackgroundColor;
                    ShadowColor = Color.Transparent;
                    break;
                case MaterialCardType.Outlined:
                    HasShadow = false;
                    BackgroundColor = Color.Transparent;
                    HasBorder = true;
                    BorderColor = BorderColor != Color.Default ? BorderColor : DefaultStyles.BorderColor;

                    break;
            }
        }

        public void ConsumeEvent(EventType gestureType)
        {
            TouchAndPressAnimation.Animate(this, gestureType);
        }

        public void ExecuteAction()
        {
            if (IsEnabled && Command != null && Command.CanExecute(CommandParameter))
                Command.Execute(CommandParameter);
        }
        #endregion Methods
    }
}
