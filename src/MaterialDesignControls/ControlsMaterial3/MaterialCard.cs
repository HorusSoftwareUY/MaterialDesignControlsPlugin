using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Styles;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

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
            BindableProperty.Create(nameof(Animation), typeof(AnimationTypes), typeof(MaterialCard), defaultValue: DefaultStyles.MaterialCardAnimation);

        public AnimationTypes Animation
        {
            get { return (AnimationTypes)GetValue(AnimationProperty); }
            set { SetValue(AnimationProperty, value); }
        }

        public static readonly BindableProperty AnimationParameterProperty =
            BindableProperty.Create(nameof(AnimationParameter), typeof(double?), typeof(MaterialCard), defaultValue: DefaultStyles.MaterialCardAnimationParameter);

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
            BindableProperty.Create(nameof(ShadowColor), typeof(Color), typeof(MaterialCard), defaultValue: Color.FromHex("#80000000"));

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
            BindableProperty.Create(nameof(iOSBorderWidth), typeof(float), typeof(MaterialCard), 1f);

        public float iOSBorderWidth
        {
            get { return (float)GetValue(iOSBorderWidthProperty); }
            set { SetValue(iOSBorderWidthProperty, value); }
        }

        public static readonly BindableProperty iOSShadowRadiusProperty =
            BindableProperty.Create(nameof(iOSShadowRadius), typeof(double), typeof(MaterialCard), defaultValue: 6.0);

        public double iOSShadowRadius
        {
            get => (double)GetValue(iOSShadowRadiusProperty);
            set => SetValue(iOSShadowRadiusProperty, value);
        }

        public static readonly BindableProperty iOSShadowOpacityProperty =
            BindableProperty.Create(nameof(iOSShadowOpacity), typeof(double), typeof(MaterialCard), defaultValue: 0.3);

        public double iOSShadowOpacity
        {
            get => (double)GetValue(iOSShadowOpacityProperty);
            set => SetValue(iOSShadowOpacityProperty, value);
        }

        public static readonly BindableProperty iOSShadowOffsetProperty =
            BindableProperty.Create(nameof(iOSShadowOffset), typeof(Size), typeof(MaterialCard), defaultValue: new Size());

        public Size iOSShadowOffset
        {
            get => (Size)GetValue(iOSShadowOffsetProperty);
            set => SetValue(iOSShadowOffsetProperty, value);
        }
        #endregion iOS

        #region Android
        public static readonly BindableProperty AndroidElevationProperty =
            BindableProperty.Create(nameof(AndroidElevation), typeof(double), typeof(MaterialCard), defaultValue: 10.0);

        public double AndroidElevation
        {
            get => (double)GetValue(AndroidElevationProperty);
            set => SetValue(AndroidElevationProperty, value);
        }

        public static readonly BindableProperty AndroidBorderAlphaProperty =
            BindableProperty.Create(nameof(AndroidBorderAlpha), typeof(double), typeof(MaterialCard), defaultValue: 1.0);

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

            this.IsClippedToBounds = true;

            Effects.Add(new TouchAndPressEffect());

            SetCardType();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            switch (propertyName)
            {
                case nameof(Type):
                    SetCardType();
                    break;

                //case nameof(ShadowColor):
                //    if (Type == MaterialCardType.Custom)
                //    {
                //        ShadowColor = ShadowColor;
                //    }
                //    break;

                //case nameof(base.BackgroundColor):
                //    if (Type == MaterialCardType.Custom)
                //    {
                //        BackgroundColor = BackgroundColor;
                //    }
                //    break;

                //case nameof(base.BorderColor):
                //    if (Type == MaterialCardType.Custom)
                //    {
                //        BorderColor = BorderColor;
                //    }
                //    break;


                //case nameof(HasShadow):
                //    if (Type == MaterialCardType.Custom)
                //    {
                //        HasShadow = HasShadow;
                //    }
                //    break;

                //case nameof(HasBorder):
                //    if (Type == MaterialCardType.Custom)
                //    {
                //        HasBorder = HasBorder;
                //    }
                //    break;

                //case nameof(iOSBorderWidth):
                //    if (Type == MaterialCardType.Custom)
                //    {
                //        iOSBorderWidth = iOSBorderWidth;
                //    }
                //    break;

                //case nameof(iOSShadowRadius):
                //    if (Type == MaterialCardType.Custom)
                //    {
                //        iOSShadowRadius = iOSShadowRadius;
                //    }
                //    break;

                //case nameof(iOSShadowOffset):
                //    if (Type == MaterialCardType.Custom)
                //    {
                //        iOSShadowOffset = iOSShadowOffset;
                //    }
                //    break;


                //case nameof(AndroidElevation):
                //    if (Type == MaterialCardType.Custom)
                //    {
                //        AndroidElevation = AndroidElevation;
                //    }
                //    break;

                //case nameof(AndroidBorderAlpha):
                //    if (Type == MaterialCardType.Custom)
                //    {
                //        AndroidBorderAlpha = AndroidBorderAlpha;
                //    }
                //    break;

                //case nameof(IsEnabled):
                //    VisualStateManager.GoToState(this, IsEnabled ? "Normal" : "Disabled");
                //    break;

                //default:
                //    base.OnPropertyChanged(propertyName);
                //    break;


            }

            //base.OnPropertyChanged(propertyName);
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
