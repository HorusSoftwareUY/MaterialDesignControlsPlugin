using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Plugin.MaterialDesignControls.Styles;
using Plugin.MaterialDesignControls.Utils;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3
{
    public partial class MaterialSwitch : ContentView
    {
        #region Constructors

        public MaterialSwitch()
        {
            if (!_initialized)
            {
                _initialized = true;
                Initialize();
            }
        }

        #endregion Constructors

        #region Attributes

        private SwitchStateEnum _currentState;
        private double _xRef;

        private readonly int _toggleAnimationDuration = 100;

        private readonly double _trackHeight = 32;
        private readonly double _trackWidth = 52;

        private readonly double _thumbSelectedSize = 24;
        private readonly double _thumbUnselectedWithIconSize = 24;
        private readonly double _thumbUnselectedWithoutIconSize = 16;

        private bool _reduceThumbSize => CustomUnselectedIcon == null && string.IsNullOrWhiteSpace(UnselectedIcon);

        private bool _initialized = false;

        private StackLayout _container;
        private MaterialLabel _lblLeft;
        private Grid _switch;
        private Frame _track;
        private Frame _trackInner;
        private Frame _thumb;
        private CustomImage _icon;
        private MaterialLabel _lblRight;
        private MaterialLabel _lblSupportingText;

        #endregion Attributes

        #region Properties

        #region Background

        public new static readonly BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialSwitch), Color.Default);

        public new Color BackgroundColor
        {
            get => (Color)GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }

        public static readonly BindableProperty BackgroundOnUnselectedColorProperty =
            BindableProperty.Create(nameof(BackgroundOnUnselectedColor), typeof(Color), typeof(MaterialSwitch), MaterialColor.SurfaceContainerHighest);

        public Color BackgroundOnUnselectedColor
        {
            get => (Color)GetValue(BackgroundOnUnselectedColorProperty);
            set => SetValue(BackgroundOnUnselectedColorProperty, value);
        }

        public static readonly BindableProperty DisabledBackgroundOnUnselectedColorProperty =
            BindableProperty.Create(nameof(DisabledBackgroundOnUnselectedColor), typeof(Color), typeof(MaterialSwitch), MaterialColor.DisableContainer);

        public Color DisabledBackgroundOnUnselectedColor
        {
            get => (Color)GetValue(DisabledBackgroundOnUnselectedColorProperty);
            set => SetValue(DisabledBackgroundOnUnselectedColorProperty, value);
        }

        public static readonly BindableProperty BackgroundOnSelectedColorProperty =
            BindableProperty.Create(nameof(BackgroundOnSelectedColor), typeof(Color), typeof(MaterialSwitch), MaterialColor.Primary);

        public Color BackgroundOnSelectedColor
        {
            get => (Color)GetValue(BackgroundOnSelectedColorProperty);
            set => SetValue(BackgroundOnSelectedColorProperty, value);
        }

        public static readonly BindableProperty DisabledBackgroundOnSelectedColorProperty =
            BindableProperty.Create(nameof(DisabledBackgroundOnSelectedColor), typeof(Color), typeof(MaterialSwitch), MaterialColor.Disable);

        public Color DisabledBackgroundOnSelectedColor
        {
            get => (Color)GetValue(DisabledBackgroundOnSelectedColorProperty);
            set => SetValue(DisabledBackgroundOnSelectedColorProperty, value);
        }

        #endregion BackgroundColor

        #region Border

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(MaterialSwitch), Color.Default);

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.Create(nameof(BorderWidth), typeof(double), typeof(MaterialSwitch), 2d);

        public double BorderWidth
        {
            get => (double)GetValue(BorderWidthProperty);
            set => SetValue(BorderWidthProperty, value);
        }

        public static readonly BindableProperty BorderOnUnselectedColorProperty =
            BindableProperty.Create(nameof(BorderOnUnselectedColor), typeof(Color), typeof(MaterialSwitch), MaterialColor.Outline);

        public Color BorderOnUnselectedColor
        {
            get => (Color)GetValue(BorderOnUnselectedColorProperty);
            set => SetValue(BorderOnUnselectedColorProperty, value);
        }

        public static readonly BindableProperty DisabledBorderOnUnselectedColorProperty =
            BindableProperty.Create(nameof(DisabledBorderOnUnselectedColor), typeof(Color), typeof(MaterialSwitch), MaterialColor.Disable);

        public Color DisabledBorderOnUnselectedColor
        {
            get => (Color)GetValue(DisabledBorderOnUnselectedColorProperty);
            set => SetValue(DisabledBorderOnUnselectedColorProperty, value);
        }

        public static readonly BindableProperty BorderOnSelectedColorProperty =
            BindableProperty.Create(nameof(BorderOnSelectedColor), typeof(Color), typeof(MaterialSwitch), MaterialColor.Primary);

        public Color BorderOnSelectedColor
        {
            get => (Color)GetValue(BorderOnSelectedColorProperty);
            set => SetValue(BorderOnSelectedColorProperty, value);
        }

        public static readonly BindableProperty DisabledBorderOnSelectedColorProperty =
            BindableProperty.Create(nameof(DisabledBorderOnSelectedColor), typeof(Color), typeof(MaterialSwitch), MaterialColor.Disable);

        public Color DisabledBorderOnSelectedColor
        {
            get => (Color)GetValue(DisabledBorderOnSelectedColorProperty);
            set => SetValue(DisabledBorderOnSelectedColorProperty, value);
        }

        #endregion Border

        #region Toggled

        public static readonly BindableProperty IsToggledProperty
            = BindableProperty.Create(nameof(IsToggled), typeof(bool), typeof(MaterialSwitch), false, BindingMode.TwoWay, propertyChanged: IsToggledChanged);

        public bool IsToggled
        {
            get => (bool)GetValue(IsToggledProperty);
            set => SetValue(IsToggledProperty, value);
        }

        public static readonly BindableProperty ToggledCommandProperty = BindableProperty.Create(nameof(ToggledCommand), typeof(ICommand), typeof(MaterialSwitch));

        public ICommand ToggledCommand
        {
            get => (ICommand)GetValue(ToggledCommandProperty);
            set => SetValue(ToggledCommandProperty, value);
        }

        #endregion Toggled

        #region Thumb

        public static readonly BindableProperty ThumbUnselectedColorProperty =
            BindableProperty.Create(nameof(ThumbUnselectedColor), typeof(Color), typeof(MaterialSwitch), MaterialColor.Outline);

        public Color ThumbUnselectedColor
        {
            get => (Color)GetValue(ThumbUnselectedColorProperty);
            set => SetValue(ThumbUnselectedColorProperty, value);
        }

        public static readonly BindableProperty DisabledThumbUnselectedColorProperty =
            BindableProperty.Create(nameof(DisabledThumbUnselectedColor), typeof(Color), typeof(MaterialSwitch), MaterialColor.Disable);

        public Color DisabledThumbUnselectedColor
        {
            get => (Color)GetValue(DisabledThumbUnselectedColorProperty);
            set => SetValue(DisabledThumbUnselectedColorProperty, value);
        }

        public static readonly BindableProperty ThumbSelectedColorProperty =
            BindableProperty.Create(nameof(ThumbSelectedColor), typeof(Color), typeof(MaterialSwitch), MaterialColor.OnPrimary);

        public Color ThumbSelectedColor
        {
            get => (Color)GetValue(ThumbSelectedColorProperty);
            set => SetValue(ThumbSelectedColorProperty, value);
        }

        public static readonly BindableProperty DisabledThumbSelectedColorProperty =
            BindableProperty.Create(nameof(DisabledThumbSelectedColor), typeof(Color), typeof(MaterialSwitch), MaterialColor.DisableContainer);

        public Color DisabledThumbSelectedColor
        {
            get => (Color)GetValue(DisabledThumbSelectedColorProperty);
            set => SetValue(DisabledThumbSelectedColorProperty, value);
        }

        public static readonly BindableProperty SelectedIconProperty =
            BindableProperty.Create(nameof(SelectedIcon), typeof(string), typeof(MaterialSwitch), defaultValue: null);

        public string SelectedIcon
        {
            get { return (string)GetValue(SelectedIconProperty); }
            set { SetValue(SelectedIconProperty, value); }
        }

        public static readonly BindableProperty CustomSelectedIconProperty =
            BindableProperty.Create(nameof(CustomSelectedIcon), typeof(View), typeof(MaterialSwitch), defaultValue: null);

        public View CustomSelectedIcon
        {
            get { return (View)GetValue(CustomSelectedIconProperty); }
            set { SetValue(CustomSelectedIconProperty, value); }
        }

        public static readonly BindableProperty UnselectedIconProperty =
            BindableProperty.Create(nameof(UnselectedIcon), typeof(string), typeof(MaterialSwitch), defaultValue: null);

        public string UnselectedIcon
        {
            get { return (string)GetValue(UnselectedIconProperty); }
            set { SetValue(UnselectedIconProperty, value); }
        }

        public static readonly BindableProperty CustomUnselectedIconProperty =
            BindableProperty.Create(nameof(CustomUnselectedIcon), typeof(View), typeof(MaterialSwitch), defaultValue: null);

        public View CustomUnselectedIcon
        {
            get { return (View)GetValue(CustomUnselectedIconProperty); }
            set { SetValue(CustomUnselectedIconProperty, value); }
        }

        #endregion Thumb

        #region Text

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialSwitch), defaultValue: string.Empty);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialSwitch), defaultValue: MaterialColor.Text);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledTextColorProperty =
            BindableProperty.Create(nameof(DisabledTextColor), typeof(Color), typeof(MaterialSwitch), defaultValue: MaterialColor.Text);

        public Color DisabledTextColor
        {
            get { return (Color)GetValue(DisabledTextColorProperty); }
            set { SetValue(DisabledTextColorProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MaterialSwitch), defaultValue: MaterialFontSize.BodyLarge);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(MaterialSwitch), defaultValue: MaterialFontFamily.Default);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public static readonly BindableProperty TextSideProperty =
            BindableProperty.Create(nameof(TextSide), typeof(TextSide), typeof(MaterialSwitch), defaultValue: TextSide.Right);

        public TextSide TextSide
        {
            get { return (TextSide)GetValue(TextSideProperty); }
            set { SetValue(TextSideProperty, value); }
        }

        public static readonly BindableProperty TextHorizontalOptionsProperty =
            BindableProperty.Create(nameof(TextHorizontalOptions), typeof(LayoutOptions), typeof(MaterialSwitch), defaultValue: LayoutOptions.Start);

        public LayoutOptions TextHorizontalOptions
        {
            get { return (LayoutOptions)GetValue(TextHorizontalOptionsProperty); }
            set { SetValue(TextHorizontalOptionsProperty, value); }
        }

        public static readonly BindableProperty TextVerticalOptionsProperty =
            BindableProperty.Create(nameof(TextVerticalOptions), typeof(LayoutOptions), typeof(MaterialSwitch), defaultValue: LayoutOptions.Center);

        public LayoutOptions TextVerticalOptions
        {
            get { return (LayoutOptions)GetValue(TextVerticalOptionsProperty); }
            set { SetValue(TextVerticalOptionsProperty, value); }
        }

        #endregion Text

        #region SupportingText

        public static readonly BindableProperty SupportingTextProperty =
            BindableProperty.Create(nameof(SupportingText), typeof(string), typeof(MaterialSwitch), defaultValue: null, validateValue: OnSupportingTextValidate);

        public string SupportingText
        {
            get { return (string)GetValue(SupportingTextProperty); }
            set { SetValue(SupportingTextProperty, value); }
        }

        public static readonly BindableProperty SupportingTextColorProperty =
            BindableProperty.Create(nameof(SupportingTextColor), typeof(Color), typeof(MaterialSwitch), defaultValue: MaterialColor.Error);

        public Color SupportingTextColor
        {
            get { return (Color)GetValue(SupportingTextColorProperty); }
            set { SetValue(SupportingTextColorProperty, value); }
        }

        public static readonly BindableProperty SupportingSizeProperty =
            BindableProperty.Create(nameof(SupportingSize), typeof(double), typeof(MaterialSwitch), defaultValue: MaterialFontSize.BodySmall);

        public double SupportingSize
        {
            get { return (double)GetValue(SupportingSizeProperty); }
            set { SetValue(SupportingSizeProperty, value); }
        }

        public static readonly BindableProperty SupportingFontFamilyProperty =
            BindableProperty.Create(nameof(SupportingFontFamily), typeof(string), typeof(MaterialSwitch), defaultValue: MaterialFontFamily.Default);

        public string SupportingFontFamily
        {
            get { return (string)GetValue(SupportingFontFamilyProperty); }
            set { SetValue(SupportingFontFamilyProperty, value); }
        }

        public static readonly BindableProperty SupportingMarginProperty =
            BindableProperty.Create(nameof(SupportingMargin), typeof(Thickness), typeof(MaterialSwitch), defaultValue: new Thickness(14, 2, 14, 0));

        public Thickness SupportingMargin
        {
            get { return (Thickness)GetValue(SupportingMarginProperty); }
            set { SetValue(SupportingMarginProperty, value); }
        }

        #endregion SupportingText

        public static readonly BindableProperty AnimateErrorProperty =
            BindableProperty.Create(nameof(AnimateError), typeof(bool), typeof(MaterialSwitch), defaultValue: MaterialAnimation.AnimateOnError);

        public bool AnimateError
        {
            get { return (bool)GetValue(AnimateErrorProperty); }
            set { SetValue(AnimateErrorProperty, value); }
        }

        public static readonly BindableProperty SwitchHorizontalOptionsProperty =
            BindableProperty.Create(nameof(SwitchHorizontalOptions), typeof(LayoutOptions), typeof(MaterialSwitch), defaultValue: LayoutOptions.Start);

        public LayoutOptions SwitchHorizontalOptions
        {
            get { return (LayoutOptions)GetValue(SwitchHorizontalOptionsProperty); }
            set { SetValue(SwitchHorizontalOptionsProperty, value); }
        }

        public static readonly BindableProperty SpacingProperty =
            BindableProperty.Create(nameof(Spacing), typeof(double), typeof(MaterialSwitch), defaultValue: 10.0);

        public double Spacing
        {
            get { return (double)GetValue(SpacingProperty); }
            set { SetValue(SpacingProperty, value); }
        }

        public new static readonly BindableProperty IsEnabledProperty =
            BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(VisualElement), defaultValue: true, defaultBindingMode: BindingMode.TwoWay);

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        #endregion Properties

        #region Events

        public event EventHandler<ToggledEventArgs> Toggled;

        private event EventHandler<SwitchPanUpdatedEventArgs> SwitchPanUpdate;

        #endregion Events

        #region Methods

        private static bool OnSupportingTextValidate(BindableObject bindable, object value)
        {
            var control = (MaterialSwitch)bindable;

            // Used to animate the error when the assistive text doesn't change
            if (control.AnimateError && !string.IsNullOrEmpty(control.SupportingText) && control.SupportingText == (string)value)
                ShakeAnimation.Animate(control);

            return true;
        }

        private void Initialize()
        {
            var mainContainer = new StackLayout()
            {
                Spacing = 0,
                Margin = 0,
                Padding = 0
            };

            _container = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = Spacing
            };

            _switch = new Grid();

            _trackInner = new Frame
            {
                Padding = 0,
                CornerRadius = (float)(_trackHeight / 2 - BorderWidth),
                HeightRequest = _trackHeight - 2* BorderWidth,
                WidthRequest = _trackWidth - 2* BorderWidth,
                BackgroundColor = BackgroundColor,
                HasShadow = false,
                IsClippedToBounds = true,
                Margin = BorderWidth
            };

            _track = new Frame
            {
                Padding = 0,
                CornerRadius = (float)(_trackHeight / 2),
                HeightRequest = _trackHeight,
                WidthRequest = _trackWidth,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                BackgroundColor = BorderColor,
                HasShadow = false,
                IsClippedToBounds = true,
                Content = _trackInner
            };

            _thumb = new Frame
            {
                Padding = 0,
                CornerRadius = (float)(_thumbSelectedSize / 2),
                HeightRequest = _thumbSelectedSize,
                WidthRequest = _thumbSelectedSize,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HasShadow = false,
                IsClippedToBounds = true
            };

            _icon = new CustomImage
            {
                IsVisible = false,
                WidthRequest = 16,
                HeightRequest = 16,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            _thumb.Content = _icon;

            _switch.Children.Add(_track);
            _switch.Children.Add(_thumb);

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                SendSwitchPanUpdatedEventArgs(PanStatusEnum.Started);
                IsToggled = !IsToggled;
                Toggled?.Invoke(this, new ToggledEventArgs(IsToggled));
                ToggledCommand?.Execute(IsToggled);
            };

            var contentViewGesture = new ContentView();
            contentViewGesture.GestureRecognizers.Add(tapGestureRecognizer);
            _switch.Children.Add(contentViewGesture);

            _lblLeft = new MaterialLabel()
            {
                IsVisible = TextSide == TextSide.Left,
                TextColor = TextColor,
                FontFamily = FontFamily,
                FontSize = FontSize,
                HorizontalOptions = TextHorizontalOptions,
                VerticalOptions = TextVerticalOptions
            };

            _lblRight = new MaterialLabel()
            {
                IsVisible = TextSide == TextSide.Right,
                TextColor = TextColor,
                FontFamily = FontFamily,
                FontSize = FontSize,
                HorizontalOptions = TextHorizontalOptions,
                VerticalOptions = TextVerticalOptions
            };

            _container.Children.Add(_lblLeft);
            _container.Children.Add(_switch);
            _container.Children.Add(_lblRight);

            _lblSupportingText = new MaterialLabel()
            {
                IsVisible = false,
                LineBreakMode = LineBreakMode.NoWrap,
                HorizontalTextAlignment = TextAlignment.Start,
                TextColor = SupportingTextColor,
                FontSize = SupportingSize,
                FontFamily = SupportingFontFamily,
                Margin = SupportingMargin
            };

            mainContainer.Children.Add(_container);
            mainContainer.Children.Add(_lblSupportingText);

            SwitchPanUpdate += (sender, e) =>
            {
                var t = e.Percentage * 0.01;

                //Color background with Animation
                var backgroundFromColor = IsToggled ? (IsEnabled ? BackgroundOnSelectedColor : DisabledBackgroundOnSelectedColor) : (IsEnabled ? BackgroundOnUnselectedColor : DisabledBackgroundOnUnselectedColor);
                var backgroundToColor = IsToggled ? (IsEnabled ? BackgroundOnUnselectedColor : DisabledBackgroundOnUnselectedColor) : (IsEnabled ? BackgroundOnSelectedColor : DisabledBackgroundOnSelectedColor);
                BackgroundColor = ColorAnimationUtil.ColorAnimation(backgroundFromColor, backgroundToColor, t);

                //Color border with Animation
                var borderFromColor = IsToggled ? (IsEnabled ? BorderOnSelectedColor : DisabledBorderOnSelectedColor) : (IsEnabled ? BorderOnUnselectedColor : DisabledBorderOnUnselectedColor);
                var borderToColor = IsToggled ? (IsEnabled ? BorderOnUnselectedColor : DisabledBorderOnUnselectedColor) : (IsEnabled ? BorderOnSelectedColor : DisabledBorderOnSelectedColor);
                BorderColor = ColorAnimationUtil.ColorAnimation(borderFromColor, borderToColor, t);
            };

            // View
            this.SetBaseWidthRequest(Math.Max(this._track.WidthRequest, this._thumb.WidthRequest * 2));
            this._xRef = ((this._track.WidthRequest - this._thumb.WidthRequest) / 2) - 5;
            this._thumb.TranslationX = this._currentState == SwitchStateEnum.Left ? -this._xRef : this._xRef;

            this.Content = mainContainer;
        }

        private static void IsToggledChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is not MaterialSwitch view)
                return;

            if ((bool)newValue && view._currentState != SwitchStateEnum.Right)
                view.GoToRight();
            else if (!(bool)newValue && view._currentState != SwitchStateEnum.Left)
                view.GoToLeft();
        }

        private void GoToLeft(double percentage = 0.0)
        {
            if (Math.Abs(_thumb.TranslationX + _xRef) > 0.0)
            {
                this.AbortAnimation("SwitchAnimation");
                new Animation
                {
                    {0, 1, new Animation(v => _thumb.TranslationX = v, _thumb.TranslationX, -_xRef)},
                    {0, 1, new Animation(_ => SendSwitchPanUpdatedEventArgs(PanStatusEnum.Running))}
                }.Commit(this, "SwitchAnimation", 16, Convert.ToUInt32(_toggleAnimationDuration - (_toggleAnimationDuration * percentage / 100)), null, (_, __) =>
                {
                    this.AbortAnimation("SwitchAnimation");
                    _currentState = SwitchStateEnum.Left;
                    IsToggled = false;
                    _thumb.BackgroundColor = IsEnabled ? ThumbUnselectedColor : DisabledThumbUnselectedColor;
                    SendSwitchPanUpdatedEventArgs(PanStatusEnum.Completed);
                });
            }
            else
            {
                this.AbortAnimation("SwitchAnimation");
                _currentState = SwitchStateEnum.Left;
                IsToggled = false;
                _thumb.BackgroundColor = IsEnabled ? ThumbUnselectedColor : DisabledThumbUnselectedColor;
                SendSwitchPanUpdatedEventArgs(PanStatusEnum.Completed);
            }

            if (_reduceThumbSize)
            {
                this._icon.IsVisible = false;
                Device.InvokeOnMainThreadAsync(async () =>
                {
                    await SizeTo(_thumbUnselectedWithoutIconSize);
                });
            }
            else
                SetUnselectedIconSource();
        }

        private void SetUnselectedIconSource()
        {
            if (CustomUnselectedIcon != null)
                _icon.SetCustomImage(CustomUnselectedIcon);
            else if (!string.IsNullOrWhiteSpace(UnselectedIcon))
                _icon.SetImage(UnselectedIcon);
        }

        private void GoToRight(double percentage = 0.0)
        {
            if (Math.Abs(_thumb.TranslationX - _xRef) > 0.0)
            {
                this.AbortAnimation("SwitchAnimation");

                IsToggled = true;
                new Animation
                {
                    {0, 1, new Animation(v => _thumb.TranslationX = v, _thumb.TranslationX, _xRef)},
                    {0, 1, new Animation(_ => SendSwitchPanUpdatedEventArgs(PanStatusEnum.Running))}
                }.Commit(this, "SwitchAnimation", 16, Convert.ToUInt32(_toggleAnimationDuration - (_toggleAnimationDuration * percentage / 100)), null, (_, __) =>
                {
                    this.AbortAnimation("SwitchAnimation");
                    _currentState = SwitchStateEnum.Right;
                    IsToggled = true;
                    _thumb.BackgroundColor = IsEnabled ? ThumbSelectedColor : DisabledThumbSelectedColor;
                    SendSwitchPanUpdatedEventArgs(PanStatusEnum.Completed);
                });
            }
            else
            {
                this.AbortAnimation("SwitchAnimation");
                _currentState = SwitchStateEnum.Right;
                IsToggled = true;
                _thumb.BackgroundColor = IsEnabled ? ThumbSelectedColor : DisabledThumbSelectedColor;
                SendSwitchPanUpdatedEventArgs(PanStatusEnum.Completed);
            }

            if (_reduceThumbSize)
            {
                Device.InvokeOnMainThreadAsync(async () =>
                {
                    await SizeTo(_thumbSelectedSize);
                    this._icon.IsVisible = true;
                    SetSelectedIconSource();
                });
            }
            else
                SetSelectedIconSource();
        }

        private void SetSelectedIconSource()
        {
            if (CustomSelectedIcon != null)
                _icon.SetCustomImage(CustomSelectedIcon);
            else if (!string.IsNullOrWhiteSpace(SelectedIcon))
                _icon.SetImage(SelectedIcon);
        }

        private void SendSwitchPanUpdatedEventArgs(PanStatusEnum status)
        {
            var eventArgs = new SwitchPanUpdatedEventArgs
            {
                XRef = _xRef,
                IsToggled = IsToggled,
                TranslateX = _thumb.TranslationX,
                Status = status,
                Percentage = IsToggled
                    ? Math.Abs(_thumb.TranslationX - _xRef) / (2 * _xRef) * 100
                    : Math.Abs(_thumb.TranslationX + _xRef) / (2 * _xRef) * 100
            };

            if (!double.IsNaN(eventArgs.Percentage))
                SwitchPanUpdate?.Invoke(this, eventArgs);
        }

        private void SetBaseWidthRequest(double widthRequest)
        {
            base.WidthRequest = widthRequest;
        }

        private void LoadControl()
        {
            if (IsToggled)
                GoToRight(100);
            else
                GoToLeft(100);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!_initialized)
            {
                _initialized = true;
                Initialize();
            }

            switch (propertyName)
            {
                case "Renderer":
                    LoadControl();
                    break;

                case nameof(base.TranslationX):
                    base.OnPropertyChanged(propertyName);
                    break;

                case nameof(Text):
                    _lblLeft.Text = Text;
                    _lblRight.Text = Text;
                    break;

                case nameof(TextColor):
                case nameof(DisabledTextColor):
                    SetTextColor();
                    LoadControl();
                    break;

                case nameof(FontSize):
                    _lblLeft.FontSize = FontSize;
                    _lblRight.FontSize = FontSize;
                    break;

                case nameof(FontFamily):
                    _lblLeft.FontFamily = FontFamily;
                    _lblRight.FontFamily = FontFamily;
                    break;

                case nameof(TextVerticalOptions):
                    _lblLeft.VerticalOptions = TextVerticalOptions;
                    _lblRight.VerticalOptions = TextVerticalOptions;
                    break;

                case nameof(TextSide):
                    if (TextSide == TextSide.Right)
                    {
                        _lblLeft.IsVisible = false;
                        _lblRight.Text = Text;
                        _lblRight.IsVisible = true;
                    }
                    else
                    {
                        _lblRight.IsVisible = false;
                        _lblLeft.Text = Text;
                        _lblLeft.IsVisible = true;
                    }
                    break;

                case nameof(IsEnabled):
                    _switch.IsEnabled = IsEnabled;
                    SetTextColor();
                    LoadControl();
                    break;

                case nameof(SupportingText):
                    _lblSupportingText.Text = SupportingText;
                    _lblSupportingText.IsVisible = !string.IsNullOrEmpty(SupportingText);
                    if (AnimateError && !string.IsNullOrEmpty(SupportingText))
                        ShakeAnimation.Animate(this);
                    break;

                case nameof(SupportingTextColor):
                    _lblSupportingText.TextColor = SupportingTextColor;
                    break;

                case nameof(SupportingSize):
                    _lblSupportingText.FontSize = SupportingSize;
                    break;

                case nameof(SupportingFontFamily):
                    _lblSupportingText.FontFamily = SupportingFontFamily;
                    break;

                case nameof(SupportingMargin):
                    _lblSupportingText.Margin = SupportingMargin;
                    break;

                case nameof(TextHorizontalOptions):
                    if (TextSide == TextSide.Left)
                        _lblLeft.HorizontalOptions = TextHorizontalOptions;
                    else
                        _lblRight.HorizontalOptions = TextHorizontalOptions;
                    break;

                case nameof(SwitchHorizontalOptions):
                    _switch.HorizontalOptions = SwitchHorizontalOptions;
                    break;

                case nameof(Spacing):
                    _container.Spacing = Spacing;
                    break;

                case nameof(BackgroundColor):
                    _trackInner.BackgroundColor = BackgroundColor;
                    break;

                case nameof(BorderWidth):
                    _trackInner.Margin = BorderWidth;
                    _trackInner.HeightRequest = _trackHeight - 2 * BorderWidth;
                    _trackInner.WidthRequest = _trackWidth - 2 * BorderWidth;
                    _trackInner.CornerRadius = (float)(_trackHeight / 2 - BorderWidth);
                    break;

                case nameof(BorderColor):
                    _track.BackgroundColor = BorderColor;
                    break;

                case nameof(UnselectedIcon):
                    if (!string.IsNullOrEmpty(UnselectedIcon))
                        this._icon.SetImage(UnselectedIcon);

                    this._icon.IsVisible = !_reduceThumbSize && !IsToggled;
                    break;
                case nameof(CustomUnselectedIcon):
                    if (CustomUnselectedIcon != null)
                        this._icon.SetCustomImage(CustomUnselectedIcon);

                    this._icon.IsVisible = !_reduceThumbSize && !IsToggled;
                    break;

                case nameof(SelectedIcon):
                    if (!string.IsNullOrEmpty(SelectedIcon))
                        this._icon.SetImage(SelectedIcon);

                    this._icon.IsVisible = IsToggled;
                    break;
                case nameof(CustomSelectedIcon):
                    if (CustomSelectedIcon != null)
                        this._icon.SetCustomImage(CustomSelectedIcon);

                    this._icon.IsVisible = IsToggled;
                    break;
            }
        }

        private void SetTextColor()
        {
            _lblLeft.TextColor = IsEnabled ? TextColor : DisabledTextColor;
            _lblRight.TextColor = IsEnabled ? TextColor : DisabledTextColor;
        }

        private async Task SizeTo(double newSize)
        {
            var scale = newSize / _thumb.Height;

            uint length = 200;
            var easing = Easing.Linear;
            await _thumb.ScaleTo(scale, length, easing);
            _thumb.CornerRadius = (float)(_thumb.Height / 2);
        }

        #endregion Methods
    }

    public enum SwitchStateEnum
    {
        Left,
        Right
    }

    public class SwitchPanUpdatedEventArgs : EventArgs
    {
        public double XRef { get; set; }
        public bool IsToggled { get; set; }
        public double TranslateX { get; set; }
        public double Percentage { get; set; }
        public PanStatusEnum Status { get; set; }
    }

    public enum PanStatusEnum
    {
        Started,
        Running,
        Completed,
        Canceled
    }
}