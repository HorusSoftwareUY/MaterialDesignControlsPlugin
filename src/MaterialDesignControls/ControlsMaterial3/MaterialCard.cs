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
            BindableProperty.Create(nameof(Animation), typeof(AnimationTypes), typeof(MaterialCard), defaultValue: DefaultStyles.AnimationType);

        public AnimationTypes Animation
        {
            get { return (AnimationTypes)GetValue(AnimationProperty); }
            set { SetValue(AnimationProperty, value); }
        }

        public static readonly BindableProperty AnimationParameterProperty =
            BindableProperty.Create(nameof(AnimationParameter), typeof(double?), typeof(MaterialCard), defaultValue: DefaultStyles.AnimationParameter);

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

        public static readonly BindableProperty ShadowColorProperty =
            BindableProperty.Create(nameof(ShadowColor), typeof(Color), typeof(MaterialCard), defaultValue: Color.Default);

        public Color ShadowColor
        {
            get => (Color)GetValue(ShadowColorProperty);
            set => SetValue(ShadowColorProperty, value);
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialCard), defaultValue: Color.Default);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly new BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(MaterialCard), defaultValue: Color.Default);

        public new Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty HasBorderProperty =
            BindableProperty.Create(nameof(HasBorder), typeof(bool), typeof(MaterialCard), defaultValue: true);

        public bool HasBorder
        {
            get { return (bool)GetValue(HasBorderProperty); }
            set { SetValue(HasBorderProperty, value); }
        }

        public static new readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(CornerRadius), typeof(MaterialCard), new CornerRadius(12));

        public new CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.Create(nameof(BorderWidth), typeof(float), typeof(MaterialCard), 1f);

        public float BorderWidth
        {
            get { return (float)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        #region iOS

        public static readonly BindableProperty iOSShadowRadiusProperty =
            BindableProperty.Create(nameof(iOSShadowRadius), typeof(float), typeof(MaterialCard), defaultValue: 2.0f);

        public float iOSShadowRadius
        {
            get => (float)GetValue(iOSShadowRadiusProperty);
            set => SetValue(iOSShadowRadiusProperty, value);
        }

        public static readonly BindableProperty iOSShadowOpacityProperty =
            BindableProperty.Create(nameof(iOSShadowOpacity), typeof(float), typeof(MaterialCard), defaultValue: 0.5f);

        public float iOSShadowOpacity
        {
            get => (float)GetValue(iOSShadowOpacityProperty);
            set => SetValue(iOSShadowOpacityProperty, value);
        }

        public static readonly BindableProperty iOSShadowOffsetProperty =
            BindableProperty.Create(nameof(iOSShadowOffset), typeof(Size), typeof(MaterialCard), defaultValue: new Size(0,5));

        public Size iOSShadowOffset
        {
            get => (Size)GetValue(iOSShadowOffsetProperty);
            set => SetValue(iOSShadowOffsetProperty, value);
        }

        #endregion iOS

        #region Android

        public static readonly BindableProperty AndroidElevationProperty =
            BindableProperty.Create(nameof(AndroidElevation), typeof(float), typeof(MaterialCard), defaultValue: 8.0f);

        public float AndroidElevation
        {
            get => (float)GetValue(AndroidElevationProperty);
            set => SetValue(AndroidElevationProperty, value);
        }

        #endregion Android

        #endregion Properties

        #region Methods

        private void Initialize()
        {
            _initialized = true;

            this.IsClippedToBounds = true;
            this.Padding = new Thickness(16);

            Effects.Add(new TouchAndPressEffect());
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            switch (propertyName)
            {
                case "Renderer":
                    base.OnPropertyChanged(propertyName);
                    SetCardType();
                    break;

                case nameof(Type):
                case nameof(BackgroundColor):
                case nameof(HasBorder):
                case nameof(BorderColor):
                case nameof(BorderWidth):
                case nameof(HasShadow):
                    SetCardType();
                    break;

                case nameof(ShadowColor):
                    SetShadowColor();
                    break;

                case nameof(IsEnabled):
                    VisualStateManager.GoToState(this, IsEnabled ? "Normal" : "Disabled");
                    break;

                default:
                    base.OnPropertyChanged(propertyName);
                    break;
            }
        }

        public void SetCardType()
        {
            switch (Type)
            {
                case MaterialCardType.Outlined:
                    HasShadow = false;
                    HasBorder = true;
                    base.BorderColor = BorderColor != Color.Default ? BorderColor : DefaultStyles.PrimaryColor;
                    base.BackgroundColor = Color.Transparent;
                    BorderColor = base.BorderColor;
                    BackgroundColor = base.BackgroundColor;
                    break;
                case MaterialCardType.Filled:
                    HasShadow = false;
                    HasBorder = false;
                    base.BackgroundColor = BackgroundColor != Color.Default ? BackgroundColor : DefaultStyles.SurfaceContainerLowColor;
                    BackgroundColor = base.BackgroundColor;
                    break;
                case MaterialCardType.Elevated:
                    HasBorder = false;
                    HasShadow = true;
                    ShadowColor = ShadowColor != Color.Default ? ShadowColor : DefaultStyles.ShadowColor;
                    SetShadowColor();
                    base.BackgroundColor = BackgroundColor != Color.Default ? BackgroundColor : DefaultStyles.SurfaceContainerLowColor;
                    BackgroundColor = base.BackgroundColor;
                    break;
                case MaterialCardType.Custom:
                    SetShadowColor();
                    base.BorderColor = BorderColor != Color.Default ? BorderColor : DefaultStyles.PrimaryColor;
                    base.BackgroundColor = BackgroundColor != Color.Default ? BackgroundColor : DefaultStyles.SurfaceContainerLowColor;
                    BorderColor = base.BorderColor;
                    BackgroundColor = base.BackgroundColor;
                    break;
            }
        }

        private void SetShadowColor()
        {
            if (ShadowColor != Color.Transparent)
            {
                if (ShadowColor.A == 1)
                {
                    ShadowColor = ShadowColor != Color.Default ?
                        Color.FromRgba(ShadowColor.R, ShadowColor.G, ShadowColor.B, 0.5) :
                        Color.FromRgba(DefaultStyles.ShadowColor.R, DefaultStyles.ShadowColor.G, DefaultStyles.ShadowColor.B, 0.5);
                }
                else
                {
                    ShadowColor = ShadowColor != Color.Default ? ShadowColor : DefaultStyles.ShadowColor;
                }
            }
        }

        public void ConsumeEvent(EventType gestureType)
        {
            if (IsEnabled && Command != null && Command.CanExecute(CommandParameter))
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