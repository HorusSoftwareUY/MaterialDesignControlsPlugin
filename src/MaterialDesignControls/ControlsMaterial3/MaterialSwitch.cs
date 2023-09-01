using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Implementations;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Plugin.MaterialDesignControls.Styles;
using Plugin.MaterialDesignControls.Utils;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
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

        private SwitchStateEnum _currentState { get; set; }
        private double _xRef;

        private readonly int _toggleAnimationDuration = 100;
        private readonly double _reduceTo = 0.85;
        private readonly double _increazeTo = 1.15;

        private bool _reduceThumbSize => CustomUnselectedIcon == null && string.IsNullOrWhiteSpace(UnselectedIcon);

        private bool _initialized = false;


        private StackLayout _container;
        private MaterialLabel lblLeft;
        private Grid sw;
        private MaterialCard BackgroundFrame;
        private MaterialCard ThumbFrame;
        private CustomImage imgIcon;
        private MaterialLabel lblRight;
        private MaterialLabel lblSupportingText;

        #endregion Attributes

        #region Properties

        #region Background

        public new static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialSwitch), Color.Default);

        public new Color BackgroundColor
        {
            get => (Color)GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }

        public static readonly BindableProperty BackgroundOnUnselectedColorProperty = BindableProperty.Create(nameof(BackgroundOnUnselectedColor), typeof(Color), typeof(MaterialSwitch), DefaultStyles.SurfaceContainerHighestColor);

        public Color BackgroundOnUnselectedColor
        {
            get => (Color)GetValue(BackgroundOnUnselectedColorProperty);
            set => SetValue(BackgroundOnUnselectedColorProperty, value);
        }

        public static readonly BindableProperty DisabledBackgroundOnUnselectedColorProperty = BindableProperty.Create(nameof(DisabledBackgroundOnUnselectedColor), typeof(Color), typeof(MaterialSwitch), DefaultStyles.DisableContainerColor);

        public Color DisabledBackgroundOnUnselectedColor
        {
            get => (Color)GetValue(DisabledBackgroundOnUnselectedColorProperty);
            set => SetValue(DisabledBackgroundOnUnselectedColorProperty, value);
        }

        public static readonly BindableProperty BackgroundOnSelectedColorProperty = BindableProperty.Create(nameof(BackgroundOnSelectedColor), typeof(Color), typeof(MaterialSwitch), DefaultStyles.PrimaryColor);

        public Color BackgroundOnSelectedColor
        {
            get => (Color)GetValue(BackgroundOnSelectedColorProperty);
            set => SetValue(BackgroundOnSelectedColorProperty, value);
        }

        public static readonly BindableProperty DisabledBackgroundOnSelectedColorProperty = BindableProperty.Create(nameof(DisabledBackgroundOnSelectedColor), typeof(Color), typeof(MaterialSwitch), DefaultStyles.DisableColor);

        public Color DisabledBackgroundOnSelectedColor
        {
            get => (Color)GetValue(DisabledBackgroundOnSelectedColorProperty);
            set => SetValue(DisabledBackgroundOnSelectedColorProperty, value);
        }

        #endregion BackgroundColor

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

        public static readonly BindableProperty ThumbUnselectedColorProperty = BindableProperty.Create(nameof(ThumbUnselectedColor), typeof(Color), typeof(MaterialSwitch), DefaultStyles.OutlineColor);

        public Color ThumbUnselectedColor
        {
            get => (Color)GetValue(ThumbUnselectedColorProperty);
            set => SetValue(ThumbUnselectedColorProperty, value);
        }

        public static readonly BindableProperty DisabledThumbUnselectedColorProperty = BindableProperty.Create(nameof(DisabledThumbUnselectedColor), typeof(Color), typeof(MaterialSwitch), DefaultStyles.DisableColor);

        public Color DisabledThumbUnselectedColor
        {
            get => (Color)GetValue(DisabledThumbUnselectedColorProperty);
            set => SetValue(DisabledThumbUnselectedColorProperty, value);
        }

        public static readonly BindableProperty ThumbSelectedColorProperty = BindableProperty.Create(nameof(ThumbSelectedColor), typeof(Color), typeof(MaterialSwitch), DefaultStyles.OnPrimaryColor);

        public Color ThumbSelectedColor
        {
            get => (Color)GetValue(ThumbSelectedColorProperty);
            set => SetValue(ThumbSelectedColorProperty, value);
        }

        public static readonly BindableProperty DisabledThumbSelectedColorProperty = BindableProperty.Create(nameof(DisabledThumbSelectedColor), typeof(Color), typeof(MaterialSwitch), DefaultStyles.DisableContainerColor);

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
            BindableProperty.Create(nameof(CustomSelectedIcon), typeof(View), typeof(BaseMaterialFieldControl), defaultValue: null);

        public View CustomSelectedIcon
        {
            get { return (View)GetValue(CustomSelectedIconProperty); }
            set { SetValue(CustomSelectedIconProperty, value); }
        }

        public static readonly BindableProperty UnselectedIconProperty =
            BindableProperty.Create(nameof(UnselectedIcon), typeof(string), typeof(BaseMaterialFieldControl), defaultValue: null);

        public string UnselectedIcon
        {
            get { return (string)GetValue(UnselectedIconProperty); }
            set { SetValue(UnselectedIconProperty, value); }
        }

        public static readonly BindableProperty CustomUnselectedIconProperty =
            BindableProperty.Create(nameof(CustomUnselectedIcon), typeof(View), typeof(BaseMaterialFieldControl), defaultValue: null);

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
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialSwitch), defaultValue: DefaultStyles.TextColor);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledTextColorProperty =
            BindableProperty.Create(nameof(DisabledTextColor), typeof(Color), typeof(MaterialSwitch), defaultValue: DefaultStyles.TextColor);

        public Color DisabledTextColor
        {
            get { return (Color)GetValue(DisabledTextColorProperty); }
            set { SetValue(DisabledTextColorProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MaterialSwitch), defaultValue: DefaultStyles.PhoneFontSizes.BodyLarge);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(MaterialSwitch), defaultValue: DefaultStyles.FontFamily);

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
            BindableProperty.Create(nameof(SupportingTextColor), typeof(Color), typeof(MaterialSwitch), defaultValue: DefaultStyles.ErrorColor);

        public Color SupportingTextColor
        {
            get { return (Color)GetValue(SupportingTextColorProperty); }
            set { SetValue(SupportingTextColorProperty, value); }
        }

        public static readonly BindableProperty SupportingSizeProperty =
            BindableProperty.Create(nameof(SupportingSize), typeof(double), typeof(MaterialSwitch), defaultValue: DefaultStyles.PhoneFontSizes.BodySmall);

        public double SupportingSize
        {
            get { return (double)GetValue(SupportingSizeProperty); }
            set { SetValue(SupportingSizeProperty, value); }
        }

        public static readonly BindableProperty SupportingFontFamilyProperty =
            BindableProperty.Create(nameof(SupportingFontFamily), typeof(string), typeof(MaterialSwitch), defaultValue: DefaultStyles.FontFamily);

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

        public static readonly BindableProperty AnimateErrorProperty =
            BindableProperty.Create(nameof(AnimateError), typeof(bool), typeof(MaterialSwitch), defaultValue: DefaultStyles.AnimateError);

        public bool AnimateError
        {
            get { return (bool)GetValue(AnimateErrorProperty); }
            set { SetValue(AnimateErrorProperty, value); }
        }

        #endregion SupportingText

        public static readonly BindableProperty TextHorizontalOptionsProperty =
            BindableProperty.Create(nameof(TextHorizontalOptions), typeof(LayoutOptions), typeof(MaterialSwitch), defaultValue: LayoutOptions.Start);

        public LayoutOptions TextHorizontalOptions
        {
            get { return (LayoutOptions)GetValue(TextHorizontalOptionsProperty); }
            set { SetValue(TextHorizontalOptionsProperty, value); }
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
            StackLayout mainContainer = new StackLayout()
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

            lblLeft = new MaterialLabel()
            {
                IsVisible = TextSide == TextSide.Left,
                TextColor = TextColor,
                FontFamily = FontFamily,
                FontSize = FontSize,
                HorizontalOptions = TextHorizontalOptions
            };

            sw = new Grid();

            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                Console.WriteLine("tapped");
                SendSwitchPanUpdatedEventArgs(PanStatusEnum.Started);
                if (_currentState == SwitchStateEnum.Right)
                    GoToLeft();
                else
                    GoToRight();

                Toggled?.Invoke(this, new ToggledEventArgs((bool)IsToggled));
                ToggledCommand?.Execute((bool)IsToggled);
            };

            sw.GestureRecognizers.Add(tapGestureRecognizer);

            BackgroundFrame = new MaterialCard()
            {
                Padding = new Thickness(0),
                CornerRadius = 15,
                CornerRadiusBottomLeft = true,
                CornerRadiusTopLeft = true,
                CornerRadiusBottomRight = true,
                CornerRadiusTopRight = true,
                HasShadow = false,
                HeightRequest = 32,
                HorizontalOptions = LayoutOptions.Center,
                IsClippedToBounds = true,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 52,
                BackgroundColor = BackgroundColor
            };

            this.BackgroundFrame.GestureRecognizers.Add(tapGestureRecognizer);

            ThumbFrame = new MaterialCard()
            {
                Padding = new Thickness(0),
                CornerRadius = 12,
                CornerRadiusBottomLeft = true,
                CornerRadiusTopLeft = true,
                CornerRadiusBottomRight = true,
                CornerRadiusTopRight = true,
                HasShadow = false,
                HeightRequest = 24,
                HorizontalOptions = LayoutOptions.Center,
                IsClippedToBounds = true,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 24,
                Margin = new Thickness(1, 0, 1, 0)
            };

            ThumbFrame.GestureRecognizers.Add(tapGestureRecognizer);

            imgIcon = new CustomImage()
            {
                IsVisible = false,
                WidthRequest = 22,
                HeightRequest = 22,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            this.ThumbFrame.Content = imgIcon;

            sw.Children.Add(BackgroundFrame);
            sw.Children.Add(ThumbFrame);

            lblRight = new MaterialLabel()
            {
                IsVisible = TextSide == TextSide.Right,
                TextColor = TextColor,
                FontFamily = FontFamily,
                FontSize = FontSize,
                HorizontalOptions = TextHorizontalOptions
            };

            _container.Children.Add(lblLeft);
            _container.Children.Add(sw);
            _container.Children.Add(lblRight);

            lblSupportingText = new MaterialLabel()
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
            mainContainer.Children.Add(lblSupportingText);

            SwitchPanUpdate += (sender, e) =>
            {
                //Color Animation
                Color fromColor = IsToggled ? (IsEnabled ? BackgroundOnSelectedColor : DisabledBackgroundOnSelectedColor) : (IsEnabled ? BackgroundOnUnselectedColor : DisabledBackgroundOnUnselectedColor);
                Color toColor = IsToggled ? (IsEnabled ? BackgroundOnUnselectedColor : DisabledBackgroundOnUnselectedColor) : (IsEnabled ? BackgroundOnSelectedColor : DisabledBackgroundOnSelectedColor);

                double t = e.Percentage * 0.01;

                BackgroundColor = ColorAnimationUtil.ColorAnimation(fromColor, toColor, t);
            };

            lblLeft.VerticalOptions = TextVerticalOptions;
            lblRight.VerticalOptions = TextVerticalOptions;
            _container.Spacing = Spacing;

            // View
            this.SetBaseWidthRequest(Math.Max(this.BackgroundFrame.WidthRequest, this.ThumbFrame.WidthRequest * 2));
            this._xRef = ((this.BackgroundFrame.WidthRequest - this.ThumbFrame.WidthRequest) / 2) - 5;
            this.ThumbFrame.TranslationX = this._currentState == SwitchStateEnum.Left ? -this._xRef : this._xRef;

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
            if (Math.Abs(ThumbFrame.TranslationX + _xRef) > 0.0)
            {
                this.AbortAnimation("SwitchAnimation");
                new Animation
                {
                    {0, 1, new Animation(v => ThumbFrame.TranslationX = v, ThumbFrame.TranslationX, -_xRef)},
                    {0, 1, new Animation(_ => SendSwitchPanUpdatedEventArgs(PanStatusEnum.Running))}
                }.Commit(this, "SwitchAnimation", 16, Convert.ToUInt32(_toggleAnimationDuration - (_toggleAnimationDuration * percentage / 100)), null, (_, __) =>
                {
                    this.AbortAnimation("SwitchAnimation");
                    _currentState = SwitchStateEnum.Left;
                    IsToggled = false;
                    ThumbFrame.BackgroundColor = IsEnabled ? ThumbUnselectedColor : DisabledThumbUnselectedColor;
                    SendSwitchPanUpdatedEventArgs(PanStatusEnum.Completed);
                });
            }
            else
            {
                this.AbortAnimation("SwitchAnimation");
                _currentState = SwitchStateEnum.Left;
                IsToggled = false;
                ThumbFrame.BackgroundColor = IsEnabled ? ThumbUnselectedColor : DisabledThumbUnselectedColor;
                SendSwitchPanUpdatedEventArgs(PanStatusEnum.Completed);
            }

            if (_reduceThumbSize)
            {
                this.imgIcon.IsVisible = false;
                Device.InvokeOnMainThreadAsync(async () =>
                {
                    await SizeTo(_reduceTo);
                });
            }
            else
            {
                SetUnselectedIconSource();
            }
        }

        private void SetUnselectedIconSource()
        {
            if (CustomUnselectedIcon != null)
            {
                this.imgIcon.SetCustomImage(CustomUnselectedIcon);
            }
            else if (!string.IsNullOrWhiteSpace(UnselectedIcon))
            {
                this.imgIcon.SetImage(UnselectedIcon);
            }
        }

        private void GoToRight(double percentage = 0.0)
        {
            if (Math.Abs(ThumbFrame.TranslationX - _xRef) > 0.0)
            {
                this.AbortAnimation("SwitchAnimation");

                IsToggled = true;
                new Animation
                {
                    {0, 1, new Animation(v => ThumbFrame.TranslationX = v, ThumbFrame.TranslationX, _xRef)},
                    {0, 1, new Animation(_ => SendSwitchPanUpdatedEventArgs(PanStatusEnum.Running))}
                }.Commit(this, "SwitchAnimation", 16, Convert.ToUInt32(_toggleAnimationDuration - (_toggleAnimationDuration * percentage / 100)), null, (_, __) =>
                {
                    this.AbortAnimation("SwitchAnimation");
                    _currentState = SwitchStateEnum.Right;
                    IsToggled = true;
                    ThumbFrame.BackgroundColor = IsEnabled ? ThumbSelectedColor : DisabledThumbSelectedColor;
                    SendSwitchPanUpdatedEventArgs(PanStatusEnum.Completed);
                });
            }
            else
            {
                this.AbortAnimation("SwitchAnimation");
                _currentState = SwitchStateEnum.Right;
                IsToggled = true;
                ThumbFrame.BackgroundColor = IsEnabled ? ThumbSelectedColor : DisabledThumbSelectedColor;
                SendSwitchPanUpdatedEventArgs(PanStatusEnum.Completed);
            }

            if (_reduceThumbSize)
            {
                Device.InvokeOnMainThreadAsync(async () =>
                {
                    await SizeTo(_increazeTo);
                    this.imgIcon.IsVisible = true;
                    SetSelectedIconSource();
                });
            }
            else
            {
                SetSelectedIconSource();
            }
        }

        private void SetSelectedIconSource()
        {
            if (CustomSelectedIcon != null)
            {
                this.imgIcon.SetCustomImage(CustomSelectedIcon);
            }
            else if (!string.IsNullOrWhiteSpace(SelectedIcon))
            {
                this.imgIcon.SetImage(SelectedIcon);
            }
        }

        private void SendSwitchPanUpdatedEventArgs(PanStatusEnum status)
        {
            SwitchPanUpdatedEventArgs ev = new SwitchPanUpdatedEventArgs
            {
                XRef = _xRef,
                IsToggled = IsToggled,
                TranslateX = ThumbFrame.TranslationX,
                Status = status,
                Percentage = IsToggled
                    ? Math.Abs(ThumbFrame.TranslationX - _xRef) / (2 * _xRef) * 100
                    : Math.Abs(ThumbFrame.TranslationX + _xRef) / (2 * _xRef) * 100
            };

            if (!double.IsNaN(ev.Percentage))
            {
                SwitchPanUpdate?.Invoke(this, ev);
            }
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
                    lblLeft.Text = Text;
                    lblRight.Text = Text;
                    break;

                case nameof(TextColor):
                case nameof(DisabledTextColor):
                    SetTextColor();
                    LoadControl();
                    break;

                case nameof(FontSize):
                    lblLeft.FontSize = FontSize;
                    lblRight.FontSize = FontSize;
                    break;

                case nameof(FontFamily):
                    lblLeft.FontFamily = FontFamily;
                    lblRight.FontFamily = FontFamily;
                    break;

                case nameof(TextVerticalOptions):
                    lblLeft.VerticalOptions = TextVerticalOptions;
                    lblRight.VerticalOptions = TextVerticalOptions;
                    break;

                case nameof(TextSide):
                    if (TextSide == TextSide.Right)
                    {
                        lblLeft.IsVisible = false;
                        lblRight.Text = Text;
                        lblRight.IsVisible = true;
                    }
                    else
                    {
                        lblRight.IsVisible = false;
                        lblLeft.Text = Text;
                        lblLeft.IsVisible = true;
                    }
                    break;

                case nameof(IsEnabled):
                    sw.IsEnabled = IsEnabled;
                    SetTextColor();
                    LoadControl();
                    break;

                case nameof(SupportingText):
                    lblSupportingText.Text = SupportingText;
                    lblSupportingText.IsVisible = !string.IsNullOrEmpty(SupportingText);
                    if (AnimateError && !string.IsNullOrEmpty(SupportingText))
                        ShakeAnimation.Animate(this);
                    break;

                case nameof(SupportingTextColor):
                    lblSupportingText.TextColor = SupportingTextColor;
                    break;

                case nameof(SupportingSize):
                    lblSupportingText.FontSize = SupportingSize;
                    break;

                case nameof(SupportingFontFamily):
                    lblSupportingText.FontFamily = SupportingFontFamily;
                    break;

                case nameof(SupportingMargin):
                    lblSupportingText.Margin = SupportingMargin;
                    break;

                case nameof(TextHorizontalOptions):
                    if (TextSide == TextSide.Left)
                        lblLeft.HorizontalOptions = TextHorizontalOptions;
                    else
                        lblRight.HorizontalOptions = TextHorizontalOptions;
                    break;

                case nameof(SwitchHorizontalOptions):
                    sw.HorizontalOptions = SwitchHorizontalOptions;
                    break;

                case nameof(Spacing):
                    _container.Spacing = Spacing;
                    break;

                case nameof(BackgroundColor):
                    BackgroundFrame.BackgroundColor = BackgroundColor;
                    break;

                case nameof(UnselectedIcon):
                    if (!string.IsNullOrEmpty(UnselectedIcon))
                        this.imgIcon.SetImage(UnselectedIcon);

                    this.imgIcon.IsVisible = !_reduceThumbSize && !IsToggled;
                    break;
                case nameof(CustomUnselectedIcon):
                    if (CustomUnselectedIcon != null)
                        this.imgIcon.SetCustomImage(CustomUnselectedIcon);

                    this.imgIcon.IsVisible = !_reduceThumbSize && !IsToggled;
                    break;

                case nameof(SelectedIcon):
                    if (!string.IsNullOrEmpty(SelectedIcon))
                        this.imgIcon.SetImage(SelectedIcon);

                    this.imgIcon.IsVisible = IsToggled;
                    break;
                case nameof(CustomSelectedIcon):
                    if (CustomSelectedIcon != null)
                        this.imgIcon.SetCustomImage(CustomSelectedIcon);

                    this.imgIcon.IsVisible = IsToggled;
                    break;
            }
        }

        private void SetTextColor()
        {
            lblLeft.TextColor = IsEnabled ? TextColor : DisabledTextColor;
            lblRight.TextColor = IsEnabled ? TextColor : DisabledTextColor;
        }

        private async Task SizeTo(double scale)
        {
            uint length = 200;
            Easing easing = Easing.Linear;

            await ThumbFrame.ScaleTo(scale, length, easing);
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