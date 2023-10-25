using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Styles;
using Xamarin.Forms;
using CustomImage = Plugin.MaterialDesignControls.Material3.Implementations.CustomImage;

namespace Plugin.MaterialDesignControls.Material3
{
    public enum MaterialFloatingButtonType
    {
        Regular, Small, Large
    }

    public partial class MaterialFloatingButton : ContentView, ITouchAndPressEffectConsumer
    {
        #region Attributes

        private bool _initialized = false;

        private MaterialCard _mainContainer;

        private StackLayout _container;

        private CustomImage _imgLeft;

        private CustomImage _imgRight;

        private MaterialLabel _lblText;

        public event EventHandler Clicked;

        #endregion Attributes

        #region Properties

        public static readonly BindableProperty IconProperty =
            BindableProperty.Create(nameof(Icon), typeof(string), typeof(MaterialFloatingButton), defaultValue: null);

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly BindableProperty DisabledIconProperty =
            BindableProperty.Create(nameof(DisabledIcon), typeof(string), typeof(MaterialFloatingButton), defaultValue: null);

        public string DisabledIcon
        {
            get { return (string)GetValue(DisabledIconProperty); }
            set { SetValue(DisabledIconProperty, value); }
        }

        public static readonly BindableProperty CustomIconProperty =
            BindableProperty.Create(nameof(CustomIcon), typeof(View), typeof(MaterialFloatingButton), defaultValue: null);

        public View CustomIcon
        {
            get { return (View)GetValue(CustomIconProperty); }
            set { SetValue(CustomIconProperty, value); }
        }

        public static readonly BindableProperty CustomDisabledIconProperty =
            BindableProperty.Create(nameof(CustomDisabledIcon), typeof(View), typeof(MaterialFloatingButton), defaultValue: null);

        public View CustomDisabledIcon
        {
            get { return (View)GetValue(CustomDisabledIconProperty); }
            set { SetValue(CustomDisabledIconProperty, value); }
        }

        public static readonly BindableProperty IconHeightRequestProperty =
            BindableProperty.Create(nameof(IconHeightRequest), typeof(double), typeof(MaterialFloatingButton), defaultValue: 24.0);

        public double IconHeightRequest
        {
            get { return (double)GetValue(IconHeightRequestProperty); }
            set { SetValue(IconHeightRequestProperty, value); }
        }

        public static readonly BindableProperty IconWidthRequestProperty =
            BindableProperty.Create(nameof(IconWidthRequest), typeof(double), typeof(MaterialFloatingButton), defaultValue: 24.0);

        public double IconWidthRequest
        {
            get { return (double)GetValue(IconWidthRequestProperty); }
            set { SetValue(IconWidthRequestProperty, value); }
        }

        public static readonly BindableProperty HasShadowProperty =
            BindableProperty.Create(nameof(HasShadow), typeof(bool), typeof(MaterialFloatingButton), defaultValue: true);

        public bool HasShadow
        {
            get { return (bool)GetValue(HasShadowProperty); }
            set { SetValue(HasShadowProperty, value); }
        }

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(MaterialFloatingButton), defaultValue: null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(MaterialFloatingButton), defaultValue: null);

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialFloatingButton), defaultValue: string.Empty);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MaterialFloatingButton), defaultValue: MaterialFontSize.TitleSmall);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(MaterialFloatingButton), defaultValue: MaterialFontFamily.Default);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialFloatingButton), defaultValue: MaterialColor.Text);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty FontAttributesProperty =
            BindableProperty.Create(nameof(FontAttributes), typeof(FontAttributes), typeof(MaterialFloatingButton), defaultValue: FontAttributes.None);

        public FontAttributes FontAttributes
        {
            get { return (FontAttributes)GetValue(FontAttributesProperty); }
            set { SetValue(FontAttributesProperty, value); }
        }

        public static readonly BindableProperty DisabledTextColorProperty =
            BindableProperty.Create(nameof(DisabledTextColor), typeof(Color), typeof(MaterialFloatingButton), defaultValue: MaterialColor.Disable);

        public Color DisabledTextColor
        {
            get { return (Color)GetValue(DisabledTextColorProperty); }
            set { SetValue(DisabledTextColorProperty, value); }
        }

        public static readonly BindableProperty ToUpperProperty =
            BindableProperty.Create(nameof(ToUpper), typeof(bool), typeof(MaterialFloatingButton), defaultValue: false);

        public bool ToUpper
        {
            get { return (bool)GetValue(ToUpperProperty); }
            set { SetValue(ToUpperProperty, value); }
        }

        public static new readonly BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(MaterialFloatingButton), defaultValue: new Thickness(0));

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        public static readonly BindableProperty ButtonTypeProperty =
            BindableProperty.Create(nameof(ButtonType), typeof(MaterialFloatingButtonType), typeof(MaterialFloatingButton), defaultValue: MaterialFloatingButtonType.Regular);

        public MaterialFloatingButtonType ButtonType
        {
            get { return (MaterialFloatingButtonType)GetValue(ButtonTypeProperty); }
            set { SetValue(ButtonTypeProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(MaterialFloatingButton), defaultValue: 16.0F);

        public float CornerRadius
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty IconSideProperty =
            BindableProperty.Create(nameof(IconSide), typeof(IconSide), typeof(MaterialFloatingButton), defaultValue: IconSide.Left);

        public IconSide IconSide
        {
            get { return (IconSide)GetValue(IconSideProperty); }
            set { SetValue(IconSideProperty, value); }
        }

        public static readonly BindableProperty AnimationProperty =
            BindableProperty.Create(nameof(Animation), typeof(AnimationTypes), typeof(MaterialFloatingButton), defaultValue: MaterialAnimation.Type);

        public AnimationTypes Animation
        {
            get { return (AnimationTypes)GetValue(AnimationProperty); }
            set { SetValue(AnimationProperty, value); }
        }

        public static readonly BindableProperty AnimationParameterProperty =
            BindableProperty.Create(nameof(AnimationParameter), typeof(double?), typeof(MaterialFloatingButton), defaultValue: MaterialAnimation.Parameter);

        public double? AnimationParameter
        {
            get { return (double?)GetValue(AnimationParameterProperty); }
            set { SetValue(AnimationParameterProperty, value); }
        }

        public static readonly BindableProperty CustomAnimationProperty =
            BindableProperty.Create(nameof(CustomAnimation), typeof(ICustomAnimation), typeof(MaterialFloatingButton), defaultValue: null);

        public ICustomAnimation CustomAnimation
        {
            get { return (ICustomAnimation)GetValue(CustomAnimationProperty); }
            set { SetValue(CustomAnimationProperty, value); }
        }

        public static new readonly BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialFloatingButton), defaultValue: MaterialColor.Primary);


        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty DisabledBackgroundColorProperty =
            BindableProperty.Create(nameof(DisabledBackgroundColor), typeof(Color), typeof(MaterialFloatingButton), defaultValue: MaterialColor.Disable);

        public Color DisabledBackgroundColor
        {
            get { return (Color)GetValue(DisabledBackgroundColorProperty); }
            set { SetValue(DisabledBackgroundColorProperty, value); }
        }

        public static readonly new BindableProperty IsEnabledProperty =
            BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(MaterialFloatingButton), defaultValue: true, BindingMode.TwoWay);

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        #endregion Properties

        #region Constructors

        public MaterialFloatingButton()
        {
            Initialize();
        }

        #endregion Constructors

        #region Methods

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            switch (propertyName)
            {
                case nameof(Text):
                case nameof(ToUpper):
                    _lblText.Text = ToUpper ? Text?.ToUpper() : Text;
                    _lblText.IsVisible = !string.IsNullOrWhiteSpace(Text);
                    if (_lblText.IsVisible)
                    {
                        WidthRequest = -1;
                    }
                    break;
                case nameof(HasShadow):
                    _mainContainer.HasShadow = HasShadow;
                    break;
                case nameof(Padding):
                    _mainContainer.Padding = Padding;
                    break;
                case nameof(FontSize):
                    _lblText.FontSize = FontSize;
                    break;
                case nameof(FontFamily):
                    _lblText.FontFamily = FontFamily;
                    break;
                case nameof(FontAttributes):
                    _lblText.FontAttributes = FontAttributes;
                    break;
                case nameof(TextColor):
                case nameof(DisabledTextColor):
                    _lblText.TextColor = IsEnabled ? TextColor : DisabledTextColor;
                    break;
                case nameof(ButtonType):
                    SetButtonType();
                    break;
                case nameof(Icon):
                case nameof(DisabledIcon):
                case nameof(CustomIcon):
                case nameof(CustomDisabledIcon):
                case nameof(IconSide):
                    SetIcon();
                    break;
                case nameof(CornerRadius):
                    _mainContainer.CornerRadius = CornerRadius;
                    break;
                case nameof(IconHeightRequest):
                    _imgLeft.HeightRequest = IconHeightRequest;
                    _imgRight.HeightRequest = IconHeightRequest;
                    break;
                case nameof(IconWidthRequest):
                    _imgLeft.WidthRequest = IconWidthRequest;
                    _imgRight.WidthRequest = IconWidthRequest;
                    break;
                case nameof(BackgroundColor):
                case nameof(DisabledBackgroundColor):
                case nameof(IsEnabled):
                    _mainContainer.BackgroundColor = IsEnabled ? BackgroundColor : DisabledBackgroundColor;
                    _lblText.TextColor = IsEnabled ? TextColor : DisabledTextColor;
                    SetIcon();
                    break;
                default:
                    base.OnPropertyChanged(propertyName);
                    break;
            }
        }

        private void SetIcon()
        {
            if (string.IsNullOrEmpty(Icon) && CustomIcon == null)
            {
                _imgLeft.IsVisible = false;
                _imgRight.IsVisible = false;
                return;
            }
            else
            {
                _imgLeft.IsVisible = IconSide == IconSide.Left;
                _imgRight.IsVisible = !_imgLeft.IsVisible;
            }

            if (IsEnabled)
            {
                if (CustomIcon != null)
                {
                    if (IconSide == IconSide.Left)
                        _imgLeft.SetCustomImage(CustomIcon);
                    else
                        _imgRight.SetCustomImage(CustomIcon);
                }
                else
                {
                    if (IconSide == IconSide.Left)
                        _imgLeft.SetImage(Icon);
                    else
                        _imgRight.SetImage(Icon);
                }
            }
            else
            {
                if (CustomDisabledIcon != null)
                {
                    if (IconSide == IconSide.Left)
                        _imgLeft.SetCustomImage(CustomDisabledIcon);
                    else
                        _imgRight.SetCustomImage(CustomDisabledIcon);
                }
                else if (CustomIcon != null)
                {
                    if (IconSide == IconSide.Left)
                        _imgLeft.SetCustomImage(CustomIcon);
                    else
                        _imgRight.SetCustomImage(CustomIcon);
                }
                else if (DisabledIcon != null)
                {
                    if (IconSide == IconSide.Left)
                        _imgLeft.SetImage(DisabledIcon);
                    else
                        _imgRight.SetImage(DisabledIcon);
                }
                else
                {
                    if (IconSide == IconSide.Left)
                        _imgLeft.SetImage(Icon);
                    else
                        _imgRight.SetImage(Icon);
                }
            }
        }

        private void SetButtonType()
        {
            if (ButtonType == MaterialFloatingButtonType.Small)
            {
                HeightRequest = 40;
                WidthRequest = _lblText.IsVisible ? -1 : 40;
                CornerRadius = 12;
                Padding = new Thickness(8);

                _imgLeft.HeightRequest = 24;
                _imgLeft.WidthRequest = 24;
                _imgRight.HeightRequest = 24;
                _imgRight.WidthRequest = 24;
            }
            else if (ButtonType == MaterialFloatingButtonType.Regular)
            {
                HeightRequest = 56;
                WidthRequest = _lblText.IsVisible ? -1 : 56;
                CornerRadius = 16;
                Padding = new Thickness(16);

                _imgLeft.HeightRequest = 24;
                _imgLeft.WidthRequest = 24;
                _imgRight.HeightRequest = 24;
                _imgRight.WidthRequest = 24;
            }
            else
            {
                HeightRequest = 96;
                WidthRequest = _lblText.IsVisible ? -1 : 96;
                CornerRadius = 28;
                Padding = new Thickness(30);

                _imgLeft.HeightRequest = 36;
                _imgLeft.WidthRequest = 36;
                _imgRight.HeightRequest = 36;
                _imgRight.WidthRequest = 36;
            }
        }

        private void Initialize()
        {
            if (!_initialized)
            {
                _container = new StackLayout
                {
                    Spacing = 6,
                    Orientation = StackOrientation.Horizontal,
                    Padding = 0,
                    BackgroundColor = Color.Transparent
                };

                _imgLeft = new CustomImage
                {
                    IsVisible = false,
                    VerticalOptions = LayoutOptions.Center,
                    Padding = 0,
                    HeightRequest = IconHeightRequest,
                    WidthRequest = IconWidthRequest
                };
                _container.Children.Add(_imgLeft);

                _lblText = new MaterialLabel
                {
                    IsVisible = false,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center
                };
                _container.Children.Add(_lblText);

                _imgRight = new CustomImage
                {
                    IsVisible = false,
                    VerticalOptions = LayoutOptions.Center,
                    Padding = 0,
                    HeightRequest = IconHeightRequest,
                    WidthRequest = IconWidthRequest
                };
                _container.Children.Add(_imgRight);

                _mainContainer = new MaterialCard
                {
                    Type = MaterialCardType.Custom,
                    IsClippedToBounds = true,
                    Padding = Padding,
                    BackgroundColor = BackgroundColor,
                    Content = _container,
                    HasBorder = false,
                    AndroidElevation = 6f,
                    iOSShadowRadius = 5f,
                    iOSShadowOffset = new Size(2, 6)
            };
                
                Content = _mainContainer;
                Effects.Add(new TouchAndPressEffect());

                SetButtonType();
                _initialized = true;
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

            if (IsEnabled && Clicked != null)
                Clicked.Invoke(this, null);
        }

        #endregion Methods
    }
}