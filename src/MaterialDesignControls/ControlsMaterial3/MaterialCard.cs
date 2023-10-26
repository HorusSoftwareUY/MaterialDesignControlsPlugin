using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Styles;
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
            Initialize();
        }

        #endregion Constructors

        #region Attributes

        protected bool _initialized = false;
        private event EventHandler _clickedEvent;

        public event EventHandler Clicked
        {
            add => _clickedEvent += value;
            remove => _clickedEvent -= value;
        }

        #endregion Attributes

        #region Properties

        public static readonly BindableProperty TypeProperty =
                BindableProperty.Create(nameof(Type), typeof(MaterialCardType), typeof(MaterialCard), defaultValue: MaterialCardType.Filled);

        public MaterialCardType Type
        {
            get => (MaterialCardType)GetValue(TypeProperty);
            set => SetValue(TypeProperty, value);
        }

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(MaterialCard), defaultValue: null);

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(MaterialCard), defaultValue: null);

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public static readonly BindableProperty AnimationProperty =
            BindableProperty.Create(nameof(Animation), typeof(AnimationTypes), typeof(MaterialCard), defaultValue: MaterialAnimation.Type);

        public AnimationTypes Animation
        {
            get => (AnimationTypes)GetValue(AnimationProperty);
            set => SetValue(AnimationProperty, value);
        }

        public static readonly BindableProperty AnimationParameterProperty =
            BindableProperty.Create(nameof(AnimationParameter), typeof(double?), typeof(MaterialCard), defaultValue: MaterialAnimation.Parameter);

        public double? AnimationParameter
        {
            get => (double?)GetValue(AnimationParameterProperty);
            set => SetValue(AnimationParameterProperty, value);
        }

        public static readonly BindableProperty CustomAnimationProperty =
            BindableProperty.Create(nameof(CustomAnimation), typeof(ICustomAnimation), typeof(MaterialCard), defaultValue: null);

        public ICustomAnimation CustomAnimation
        {
            get => (ICustomAnimation)GetValue(CustomAnimationProperty);
            set => SetValue(CustomAnimationProperty, value);
        }

        public static new readonly BindableProperty HasShadowProperty =
            BindableProperty.Create(nameof(HasShadow), typeof(bool), typeof(MaterialCard), defaultValue: true);

        public new bool HasShadow
        {
            get => (bool)GetValue(HasShadowProperty);
            set => SetValue(HasShadowProperty, value);
        }

        public static readonly BindableProperty ShadowColorProperty =
            BindableProperty.Create(nameof(ShadowColor), typeof(Color), typeof(MaterialCard), defaultValue: MaterialColor.Shadow);

        public Color ShadowColor
        {
            get => (Color)GetValue(ShadowColorProperty);
            set => SetValue(ShadowColorProperty, value);
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialCard), defaultValue: MaterialColor.SurfaceContainerLow);

        public new Color BackgroundColor
        {
            get => (Color)GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }

        public static new readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(MaterialCard), defaultValue: MaterialColor.Primary);

        public new Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        public static readonly BindableProperty HasBorderProperty =
            BindableProperty.Create(nameof(HasBorder), typeof(bool), typeof(MaterialCard), defaultValue: true);

        public bool HasBorder
        {
            get => (bool)GetValue(HasBorderProperty);
            set => SetValue(HasBorderProperty, value);
        }

        public static new readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(CornerRadius), typeof(MaterialCard), new CornerRadius(12));

        public new CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.Create(nameof(BorderWidth), typeof(float), typeof(MaterialCard), 1f);

        public float BorderWidth
        {
            get => (float)GetValue(BorderWidthProperty);
            set => SetValue(BorderWidthProperty, value);
        }

        #region iOS

        public static readonly BindableProperty iOSShadowRadiusProperty =
            BindableProperty.Create(nameof(iOSShadowRadius), typeof(float), typeof(MaterialCard), defaultValue: 4.0f);

        public float iOSShadowRadius
        {
            get => (float)GetValue(iOSShadowRadiusProperty);
            set => SetValue(iOSShadowRadiusProperty, value);
        }

        public static readonly BindableProperty iOSShadowOpacityProperty =
            BindableProperty.Create(nameof(iOSShadowOpacity), typeof(float), typeof(MaterialCard), defaultValue: 0.25f);

        public float iOSShadowOpacity
        {
            get => (float)GetValue(iOSShadowOpacityProperty);
            set => SetValue(iOSShadowOpacityProperty, value);
        }

        public static readonly BindableProperty iOSShadowOffsetProperty =
            BindableProperty.Create(nameof(iOSShadowOffset), typeof(Size), typeof(MaterialCard), defaultValue: new Size(0,4));

        public Size iOSShadowOffset
        {
            get => (Size)GetValue(iOSShadowOffsetProperty);
            set => SetValue(iOSShadowOffsetProperty, value);
        }

        #endregion iOS

        #region Android

        public static readonly BindableProperty AndroidElevationProperty =
            BindableProperty.Create(nameof(AndroidElevation), typeof(float), typeof(MaterialCard), defaultValue: 4.0f);

        public float AndroidElevation
        {
            get => (float)GetValue(AndroidElevationProperty);
            set => SetValue(AndroidElevationProperty, value);
        }

        #endregion Android

        #endregion Properties

        #region Methods

        protected virtual void Initialize()
        {
            if (!_initialized)
            {
                IsClippedToBounds = true;
                Padding = new Thickness(16);

                Effects.Add(new TouchAndPressEffect());
                Xamarin.Forms.PlatformConfiguration.AndroidSpecific.VisualElement.SetElevation(this, 0);
            }
            
            _initialized = true;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == nameof(IsEnabled))
            {
                VisualStateManager.GoToState(this, IsEnabled ? "Normal" : "Disabled");
            }
        }

        public virtual void ConsumeEvent(EventType gestureType)
        {
            if (IsEnabled && (_clickedEvent != null || (Command != null && Command.CanExecute(CommandParameter))))
                TouchAndPressAnimation.Animate(this, gestureType);
        }

        public virtual void ExecuteAction()
        {
            if (IsEnabled && Command != null && Command.CanExecute(CommandParameter))
                Command.Execute(CommandParameter);

            if (IsEnabled && _clickedEvent != null)
                _clickedEvent.Invoke(this, null);
        }

        #endregion Methods
    }
}