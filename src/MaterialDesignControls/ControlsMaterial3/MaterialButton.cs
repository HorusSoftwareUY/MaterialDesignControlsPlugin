using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Plugin.MaterialDesignControls.Styles;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Plugin.MaterialDesignControls.Material3
{
    public enum MaterialButtonType
    {
        Elevated, Filled, Tonal, Outlined, Text
    }

    public class MaterialButton : Grid, ITouchAndPressEffectConsumer
    {
        #region Attributes and Properties

        private bool _initialized = false;

        private bool _minimumWidthRequestSetted = false;

        private StackLayout _stcLayout;

        private CustomImage _leadingIconCustomImage;

        private CustomImage _trailingIconCustomImage;

        private Plugin.MaterialDesignControls.MaterialLabel _textLabel;

        private MaterialProgressIndicator _activityIndicator;

        private ContentView _cntActivityIndicator;

        private Frame _frameLayout;

        #endregion Attributes and Properties

        #region Bindable properties

        public static readonly BindableProperty ButtonTypeProperty =
            BindableProperty.Create(nameof(ButtonType), typeof(MaterialButtonType), typeof(MaterialButton), defaultValue: MaterialButtonType.Filled);

        public MaterialButtonType ButtonType
        {
            get { return (MaterialButtonType)GetValue(ButtonTypeProperty); }
            set { SetValue(ButtonTypeProperty, value); }
        }

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(MaterialButton), defaultValue: null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(MaterialButton), defaultValue: null);

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly new BindableProperty IsEnabledProperty =
            BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(MaterialButton), defaultValue: true);

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public static readonly BindableProperty AnimationProperty =
            BindableProperty.Create(nameof(Animation), typeof(AnimationTypes), typeof(MaterialButton), defaultValue: MaterialAnimation.Type);

        public AnimationTypes Animation
        {
            get { return (AnimationTypes)GetValue(AnimationProperty); }
            set { SetValue(AnimationProperty, value); }
        }

        public static readonly BindableProperty AnimationParameterProperty =
            BindableProperty.Create(nameof(AnimationParameter), typeof(double?), typeof(MaterialButton), defaultValue: MaterialAnimation.Parameter);

        public double? AnimationParameter
        {
            get { return (double?)GetValue(AnimationParameterProperty); }
            set { SetValue(AnimationParameterProperty, value); }
        }

        public static readonly BindableProperty CustomAnimationProperty =
            BindableProperty.Create(nameof(CustomAnimation), typeof(ICustomAnimation), typeof(MaterialButton), defaultValue: null);

        public ICustomAnimation CustomAnimation
        {
            get { return (ICustomAnimation)GetValue(CustomAnimationProperty); }
            set { SetValue(CustomAnimationProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialButton), defaultValue: null);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty IsTextUnderlinedProperty =
            BindableProperty.Create(nameof(IsTextUnderlined), typeof(bool), typeof(MaterialButton), defaultValue: false);

        public bool IsTextUnderlined
        {
            get { return (bool)GetValue(IsTextUnderlinedProperty); }
            set { SetValue(IsTextUnderlinedProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(MaterialButton), defaultValue: 20.0);

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty IsBusyProperty =
            BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(MaterialButton), defaultValue: false);

        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Default);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledTextColorProperty =
            BindableProperty.Create(nameof(DisabledTextColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Default);

        public Color DisabledTextColor
        {
            get { return (Color)GetValue(DisabledTextColorProperty); }
            set { SetValue(DisabledTextColorProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Default);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty DisabledBackgroundColorProperty =
            BindableProperty.Create(nameof(DisabledBackgroundColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Default);

        public Color DisabledBackgroundColor
        {
            get { return (Color)GetValue(DisabledBackgroundColorProperty); }
            set { SetValue(DisabledBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Default);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty DisabledBorderColorProperty =
            BindableProperty.Create(nameof(DisabledBorderColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Default);

        public Color DisabledBorderColor
        {
            get { return (Color)GetValue(DisabledBorderColorProperty); }
            set { SetValue(DisabledBorderColorProperty, value); }
        }

        public static readonly BindableProperty BusyColorProperty =
            BindableProperty.Create(nameof(BusyColor), typeof(Color), typeof(MaterialButton), defaultValue: MaterialColor.Primary);

        public Color BusyColor
        {
            get { return (Color)GetValue(BusyColorProperty); }
            set { SetValue(BusyColorProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MaterialButton), defaultValue: MaterialFontSize.LabelLarge);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(MaterialButton), defaultValue: MaterialFontFamily.Default);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public static readonly BindableProperty LeadingIconProperty =
            BindableProperty.Create(nameof(LeadingIcon), typeof(string), typeof(MaterialButton), defaultValue: null);

        public string LeadingIcon
        {
            get { return (string)GetValue(LeadingIconProperty); }
            set { SetValue(LeadingIconProperty, value); }
        }

        public static readonly BindableProperty CustomLeadingIconProperty =
            BindableProperty.Create(nameof(CustomLeadingIcon), typeof(View), typeof(MaterialButton), defaultValue: null);

        public View CustomLeadingIcon
        {
            get { return (View)GetValue(CustomLeadingIconProperty); }
            set { SetValue(CustomLeadingIconProperty, value); }
        }

        private bool LeadingIconIsVisible
        {
            get { return !string.IsNullOrEmpty(LeadingIcon) || CustomLeadingIcon != null; }
        }

        public static readonly BindableProperty TrailingIconProperty =
            BindableProperty.Create(nameof(TrailingIcon), typeof(string), typeof(MaterialButton), defaultValue: null);

        public string TrailingIcon
        {
            get { return (string)GetValue(TrailingIconProperty); }
            set { SetValue(TrailingIconProperty, value); }
        }

        public static readonly BindableProperty CustomTrailingIconProperty =
            BindableProperty.Create(nameof(CustomTrailingIcon), typeof(View), typeof(MaterialButton), defaultValue: null);

        public View CustomTrailingIcon
        {
            get { return (View)GetValue(CustomTrailingIconProperty); }
            set { SetValue(CustomTrailingIconProperty, value); }
        }

        private bool TrailingIconIsVisible
        {
            get { return !string.IsNullOrEmpty(TrailingIcon) || CustomTrailingIcon != null; }
        }

        public static readonly BindableProperty IconSizeProperty =
            BindableProperty.Create(nameof(IconSize), typeof(double), typeof(MaterialButton), defaultValue: 24.0);

        public double IconSize
        {
            get { return (double)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }

        public static readonly BindableProperty ToUpperProperty =
            BindableProperty.Create(nameof(ToUpper), typeof(bool), typeof(MaterialButton), defaultValue: false);

        public bool ToUpper
        {
            get { return (bool)GetValue(ToUpperProperty); }
            set { SetValue(ToUpperProperty, value); }
        }

        public static readonly BindableProperty CustomActivityIndicatorProperty =
            BindableProperty.Create(nameof(CustomActivityIndicator), typeof(View), typeof(MaterialButton), defaultValue: null);

        public View CustomActivityIndicator
        {
            get { return (View)GetValue(CustomActivityIndicatorProperty); }
            set { SetValue(CustomActivityIndicatorProperty, value); }
        }

        public static readonly BindableProperty ActivityIndicatorSizeProperty =
            BindableProperty.Create(nameof(ActivityIndicatorSize), typeof(double), typeof(MaterialButton), defaultValue: 24.0);

        public double ActivityIndicatorSize
        {
            get { return (double)GetValue(ActivityIndicatorSizeProperty); }
            set { SetValue(ActivityIndicatorSizeProperty, value); }
        }

        public static readonly new BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(MaterialButton), defaultValue: new Thickness(12, 0));

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        public static readonly BindableProperty SpacingProperty =
            BindableProperty.Create(nameof(Spacing), typeof(int), typeof(MaterialButton), defaultValue: 12);

        public int Spacing
        {
            get { return (int)GetValue(SpacingProperty); }
            set { SetValue(SpacingProperty, value); }
        }

        public static readonly BindableProperty ContentIsExpandedProperty =
            BindableProperty.Create(nameof(ContentIsExpanded), typeof(bool), typeof(MaterialButton), defaultValue: false);

        public bool ContentIsExpanded
        {
            get { return (bool)GetValue(ContentIsExpandedProperty); }
            set { SetValue(ContentIsExpandedProperty, value); }
        }

        public static new readonly BindableProperty MinimumWidthRequestProperty =
            BindableProperty.Create(nameof(MinimumWidthRequest), typeof(double), typeof(MaterialButton), defaultValue: -1.0);

        public new double MinimumWidthRequest
        {
            get { return (double)GetValue(MinimumWidthRequestProperty); }
            set { SetValue(MinimumWidthRequestProperty, value); }
        }

        public event EventHandler Clicked;

        #endregion Bindable properties

        #region Constructors

        public MaterialButton()
        {
            if (Children == null)
                return;

            if (!_initialized)
                Initialize();
        }

        #endregion Constructors

        #region Methods

        private void Initialize()
        {
            _initialized = true;

            MinimumHeightRequest = 40;
            HeightRequest = 40;

            _frameLayout = new Frame
            {
                HasShadow = false,
                CornerRadius = Convert.ToInt32(CornerRadius),
                Padding = Padding
            };
            Children.Add(_frameLayout, 0, 0);

            _stcLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = Spacing,
                HorizontalOptions = ContentIsExpanded ? LayoutOptions.FillAndExpand : LayoutOptions.Center,
            };
            _frameLayout.Content = _stcLayout;

            _leadingIconCustomImage = new CustomImage
            {
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = IconSize,
                HeightRequest = IconSize,
                IsVisible = false
            };
            _stcLayout.Children.Add(_leadingIconCustomImage);

            _textLabel = new Plugin.MaterialDesignControls.MaterialLabel
            {
                LineBreakMode = LineBreakMode.NoWrap,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = ContentIsExpanded ? LayoutOptions.CenterAndExpand : LayoutOptions.Center,
                Text = ToUpper ? Text?.ToUpper() : Text,
                FontSize = FontSize,
                FontFamily = FontFamily,
                TextDecorations = IsTextUnderlined ? TextDecorations.Underline : TextDecorations.None
            };
            _stcLayout.Children.Add(_textLabel);

            _trailingIconCustomImage = new CustomImage
            {
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = IconSize,
                HeightRequest = IconSize,
                IsVisible = false
            };
            _stcLayout.Children.Add(_trailingIconCustomImage);

            _cntActivityIndicator = new ContentView
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = ActivityIndicatorSize,
                HeightRequest = ActivityIndicatorSize,
                IsVisible = false
            };
            Children.Add(_cntActivityIndicator, 0, 0);

            Effects.Add(new TouchAndPressEffect());

            SetButtonType();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (Children == null)
                return;

            if (!_initialized)
                Initialize();

            switch (propertyName)
            {
                case nameof(ButtonType):
                case nameof(TextColor):
                case nameof(BackgroundColor):
                case nameof(BorderColor):
                case nameof(IsTextUnderlined):
                    SetButtonType();
                    break;
                case nameof(base.Opacity):
                case nameof(base.Scale):
                case nameof(base.IsVisible):
                    base.OnPropertyChanged(propertyName);
                    break;
                case nameof(Text):
                case nameof(ToUpper):
                    _textLabel.Text = ToUpper ? Text?.ToUpper() : Text;
                    break;
                case nameof(FontSize):
                    _textLabel.FontSize = FontSize;
                    break;
                case nameof(FontFamily):
                    _textLabel.FontFamily = FontFamily;
                    break;
                case nameof(CornerRadius):
                    _frameLayout.CornerRadius = Convert.ToInt32(CornerRadius);
                    break;
                case nameof(LeadingIcon):
                    if (!string.IsNullOrEmpty(LeadingIcon))
                        this._leadingIconCustomImage.SetImage(LeadingIcon);

                    this._leadingIconCustomImage.IsVisible = LeadingIconIsVisible;
                    break;
                case nameof(CustomLeadingIcon):
                    if (CustomLeadingIcon != null)
                        this._leadingIconCustomImage.SetCustomImage(CustomLeadingIcon);

                    this._leadingIconCustomImage.IsVisible = LeadingIconIsVisible;
                    break;

                case nameof(TrailingIcon):
                    if (!string.IsNullOrEmpty(TrailingIcon))
                        this._trailingIconCustomImage.SetImage(TrailingIcon);

                    this._trailingIconCustomImage.IsVisible = TrailingIconIsVisible;
                    break;
                case nameof(CustomTrailingIcon):
                    if (CustomTrailingIcon != null)
                        this._trailingIconCustomImage.SetCustomImage(CustomTrailingIcon);

                    this._trailingIconCustomImage.IsVisible = TrailingIconIsVisible;
                    break;

                case nameof(IconSize):
                    _leadingIconCustomImage.HeightRequest = IconSize;
                    _leadingIconCustomImage.WidthRequest = IconSize;
                    _trailingIconCustomImage.HeightRequest = IconSize;
                    _trailingIconCustomImage.WidthRequest = IconSize;
                    break;
                case nameof(IsEnabled):
                    SetButtonType();
                    break;
                case nameof(ActivityIndicatorSize):
                    _cntActivityIndicator.HeightRequest = ActivityIndicatorSize;
                    _cntActivityIndicator.WidthRequest = ActivityIndicatorSize;
                    break;
                case nameof(CustomActivityIndicator):
                    if (CustomActivityIndicator != null)
                    {
                        _cntActivityIndicator.Content = CustomActivityIndicator;
                    }
                    break;
                case nameof(BusyColor):
                    if (CustomActivityIndicator == null)
                    {
                        if (_activityIndicator == null)
                        {
                            _activityIndicator = new MaterialProgressIndicator();
                            _cntActivityIndicator.Content = _activityIndicator;
                        }

                        _activityIndicator.IndicatorColor = BusyColor;
                    }
                    break;
                case nameof(IsBusy):
                    if (IsBusy)
                    {
                        if (CustomActivityIndicator == null)
                        {
                            if (_activityIndicator == null)
                            {
                                _activityIndicator = new MaterialProgressIndicator { IndicatorColor = BusyColor};
                                _cntActivityIndicator.Content = _activityIndicator;
                            }

                            _activityIndicator.IsVisible = true;
                        }

                        _cntActivityIndicator.IsVisible = true;

                        _frameLayout.IsVisible = false;
                    }
                    else
                    {
                        _frameLayout.IsVisible = true;

                        if (CustomActivityIndicator == null)
                        {
                            if (_activityIndicator == null)
                            {
                                _activityIndicator = new MaterialProgressIndicator();
                                _cntActivityIndicator.Content = _activityIndicator;
                            }

                            _activityIndicator.IsVisible = false;
                        }

                        _cntActivityIndicator.IsVisible = false;
                    }
                    break;

                case nameof(Padding):
                    _frameLayout.Padding = Padding;
                    break;
                case nameof(Spacing):
                    _stcLayout.Spacing = Spacing;
                    break;
                case nameof(ContentIsExpanded):
                    _stcLayout.HorizontalOptions = ContentIsExpanded ? LayoutOptions.FillAndExpand : LayoutOptions.Center;
                    _textLabel.HorizontalOptions = ContentIsExpanded ? LayoutOptions.CenterAndExpand : LayoutOptions.Center;
                    break;

                case nameof(Width):
                case nameof(MinimumWidthRequest):
                    if (!_minimumWidthRequestSetted && MinimumWidthRequest != -1 && Width != -1 && Width < MinimumWidthRequest)
                    {
                        _minimumWidthRequestSetted = true;
                        WidthRequest = MinimumWidthRequest;
                    }
                    break;
            }
        }

        public void SetButtonType()
        {
            switch (ButtonType)
            {
                case MaterialButtonType.Elevated:
                    _textLabel.TextColor = IsEnabled ? (TextColor != Color.Default ? TextColor : MaterialColor.Primary) : (DisabledTextColor != Color.Default ? DisabledTextColor : MaterialColor.Disable);
                    _textLabel.TextDecorations = TextDecorations.None;
                    _frameLayout.BackgroundColor = BackgroundColor != Color.Default ? BackgroundColor : MaterialColor.OnPrimary;
                    _frameLayout.BorderColor = BackgroundColor != Color.Default ? BackgroundColor : MaterialColor.OnPrimary;
                    _frameLayout.HasShadow = true;
                    break;
                case MaterialButtonType.Filled:
                    _textLabel.TextColor = IsEnabled ? (TextColor != Color.Default ? TextColor : MaterialColor.OnPrimary) : (DisabledTextColor != Color.Default ? DisabledTextColor : MaterialColor.OnPrimary);
                    _textLabel.TextDecorations = TextDecorations.None;
                    _frameLayout.BackgroundColor = IsEnabled ? (BackgroundColor != Color.Default ? BackgroundColor : MaterialColor.Primary) : (DisabledBackgroundColor != Color.Default ? DisabledBackgroundColor : MaterialColor.Disable);
                    _frameLayout.BorderColor = Color.Transparent;
                    _frameLayout.HasShadow = false;
                    break;
                case MaterialButtonType.Tonal:
                    _textLabel.TextColor = IsEnabled ? (TextColor != Color.Default ? TextColor : MaterialColor.Primary) : (DisabledTextColor != Color.Default ? DisabledTextColor : MaterialColor.Disable);
                    _textLabel.TextDecorations = TextDecorations.None;
                    var defaultBackgroundColor = Color.FromRgba(MaterialColor.Primary.R, MaterialColor.Primary.G, MaterialColor.Primary.B, 0.4);
                    _frameLayout.BackgroundColor = IsEnabled ? defaultBackgroundColor : (DisabledBackgroundColor != Color.Default ? DisabledBackgroundColor : MaterialColor.Disable);
                    _frameLayout.BorderColor = Color.Transparent;
                    _frameLayout.HasShadow = false;
                    break;
                case MaterialButtonType.Outlined:
                    _textLabel.TextColor = IsEnabled ? (TextColor != Color.Default ? TextColor : MaterialColor.Primary) : (DisabledTextColor != Color.Default ? DisabledTextColor : MaterialColor.Disable);
                    _textLabel.TextDecorations = TextDecorations.None;
                    _frameLayout.BackgroundColor = BackgroundColor != Color.Default ? BackgroundColor : MaterialColor.OnPrimary;
                    _frameLayout.BorderColor = IsEnabled ? (BorderColor != Color.Default ? BorderColor : MaterialColor.Primary) : (DisabledBorderColor != Color.Default ? DisabledBorderColor : MaterialColor.Disable);
                    _frameLayout.HasShadow = false;
                    break;
                case MaterialButtonType.Text:
                    _textLabel.TextColor = IsEnabled ? (TextColor != Color.Default ? TextColor : MaterialColor.Primary) : (DisabledTextColor != Color.Default ? DisabledTextColor : MaterialColor.Disable);
                    _textLabel.TextDecorations = IsTextUnderlined ? TextDecorations.Underline : TextDecorations.None;
                    _frameLayout.BackgroundColor = Color.Transparent;
                    _frameLayout.BorderColor = Color.Transparent;
                    _frameLayout.HasShadow = false;
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

            if (IsEnabled && Clicked != null)
                Clicked.Invoke(this, null);
        }

        #endregion Methods
    }
}