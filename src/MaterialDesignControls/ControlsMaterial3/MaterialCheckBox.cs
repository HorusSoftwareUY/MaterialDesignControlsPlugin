using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Material3.Implementations;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls.Material3
{
    public partial class MaterialCheckbox : BaseMaterialCheckBoxes, ITouchAndPressEffectConsumer
    {
        private bool Initialized = false;

        private StackLayout _container;
        private MaterialLabel _lblLeftText;
        private Grid _chkContainer;
        private CustomCheckBox _chk;
        private Grid _radioButtonContainer;
        private CustomRadioButton _radioButton;
        private Grid _imageContainer;
        private CustomImage _customIcon;
        private MaterialLabel _lblRightText;
        private MaterialLabel _lblSupporting;

        public MaterialCheckbox()
        {
            if (!Initialized)
            {
                Initialized = true;
                Initialize();
            }
        }

        #region Properties

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(MaterialCheckbox));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(MaterialCheckbox), defaultValue: null);

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly BindableProperty IsRadioButtonStyleProperty =
            BindableProperty.Create(nameof(IsRadioButtonStyle), typeof(bool), typeof(MaterialCheckbox), defaultValue: false, defaultBindingMode: BindingMode.OneWay);

        public bool IsRadioButtonStyle
        {
            get { return (bool)GetValue(IsRadioButtonStyleProperty); }
            set { SetValue(IsRadioButtonStyleProperty, value); }
        }

        #endregion Properties

        #region Methods

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!Initialized)
            {
                Initialized = true;
                Initialize();
            }

            UpdateLayout(propertyName, _container, _lblSupporting);

            switch (propertyName)
            {
                case nameof(TranslationX):
                case nameof(Scale):
                case nameof(Opacity):
                    base.OnPropertyChanged(propertyName);
                    break;
                case nameof(Text):
                    _lblRightText.Text = Text;
                    break;
                case nameof(TextColor):
                    _lblLeftText.TextColor = TextColor;
                    _lblRightText.TextColor = TextColor;
                    break;
                case nameof(DisabledTextColor):
                    if (!IsEnabled)
                    {
                        _lblLeftText.TextColor = DisabledTextColor;
                        _lblRightText.TextColor = DisabledTextColor;
                    }
                    break;
                case nameof(FontSize):
                    _lblLeftText.FontSize = FontSize;
                    _lblRightText.FontSize = FontSize;
                    break;
                case nameof(FontFamily):
                    _lblLeftText.FontFamily = FontFamily;
                    _lblRightText.FontFamily = FontFamily;
                    break;
                case nameof(TextSide):
                    if (TextSide == TextSide.Left)
                    {
                        _lblLeftText.Text = Text;
                        _lblLeftText.IsVisible = true;
                        _lblRightText.IsVisible = false;
                    }
                    break;
                case nameof(TextHorizontalOptions):
                    if (TextSide == TextSide.Left)
                        _lblLeftText.HorizontalOptions = TextHorizontalOptions;
                    else
                        _lblRightText.HorizontalOptions = TextHorizontalOptions;
                    break;
                case nameof(IconHeightRequest):
                    _customIcon.HeightRequest = IconHeightRequest;
                    break;
                case nameof(IconWidthRequest):
                    _customIcon.WidthRequest = IconWidthRequest;
                    break;
                case nameof(Color):
                case nameof(DisabledColor):
                    _chk.Color = IsEnabled ? Color : DisabledColor;
                    _radioButton.Color = IsEnabled ? Color : DisabledColor;
                    break;
                case nameof(SelectionHorizontalOptions):
                    _chkContainer.HorizontalOptions = SelectionHorizontalOptions;
                    _imageContainer.HorizontalOptions = SelectionHorizontalOptions;
                    _radioButtonContainer.HorizontalOptions = SelectionHorizontalOptions;
                    break;
                case nameof(IsEnabled):
                    SetIsEnabled();
                    break;
                case nameof(IsRadioButtonStyle):
                    _chkContainer.IsVisible = false;
                    _radioButtonContainer.IsVisible = true;
                    break;
            }
        }

        private void Initialize()
        {
            var mainContainer = new StackLayout()
            {
                Spacing = 0,
                VerticalOptions = LayoutOptions.Center
            };

            _container = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = Spacing
            };

            _lblLeftText = new MaterialLabel()
            {
                VerticalTextAlignment = TextAlignment.Center,
                IsVisible = TextSide == TextSide.Left ? true : false,
                TextColor = TextColor,
                FontFamily = FontFamily,
                FontSize = FontSize
            };

            _chkContainer = new Grid()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 40,
                HeightRequest = 40,
                MinimumWidthRequest = 40,
                MinimumHeightRequest = 40
            };

            _chk = new CustomCheckBox()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 25,
                HeightRequest = 25,
                IsEnabled = IsEnabled,
                Color = Color
            };

            // Workaround to fix an alingment issue on iOS devices
            _chk.Margin = Device.RuntimePlatform == Device.iOS ? new Thickness(0, 4, 0, 0) : new Thickness(0);

            var chkBoxView = new BoxView()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 25,
                HeightRequest = 25
            };

            _chkContainer.Children.Add(_chk);
            _chkContainer.Children.Add(chkBoxView);

            _radioButtonContainer = new Grid()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 40,
                HeightRequest = 40,
                MinimumWidthRequest = 40,
                MinimumHeightRequest = 40,
                IsVisible = false
            };

            _radioButton = new CustomRadioButton()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                IsEnabled = IsEnabled,
                Color = Color
            };

            var radioButtonBoxView = new BoxView()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 25,
                HeightRequest = 25
            };

            _radioButtonContainer.Children.Add(_radioButton);
            _radioButtonContainer.Children.Add(radioButtonBoxView);

            _imageContainer = new Grid()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 40,
                HeightRequest = 40,
                MinimumWidthRequest = 40,
                MinimumHeightRequest = 40,
                IsVisible = false
            };

            _customIcon = new CustomImage()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,
                HeightRequest = IconHeightRequest,
                WidthRequest = IconWidthRequest,
                Padding = 0
            };

            var iconBoxView = new BoxView()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 25,
                HeightRequest = 25,
                BackgroundColor = Color.Transparent
            };

            _imageContainer.Children.Add(_customIcon);
            _imageContainer.Children.Add(iconBoxView);

            _lblRightText = new MaterialLabel()
            {
                VerticalTextAlignment = TextAlignment.Center,
                TextColor = TextColor,
                FontFamily = FontFamily,
                FontSize = FontSize,
                IsVisible = TextSide == TextSide.Left ? false : true
            };

            _container.Children.Add(_lblLeftText);
            _container.Children.Add(_chkContainer);
            _container.Children.Add(_radioButtonContainer);
            _container.Children.Add(_imageContainer);
            _container.Children.Add(_lblRightText);

            _lblSupporting = new MaterialLabel()
            {
                IsVisible = false,
                LineBreakMode = LineBreakMode.NoWrap,
                Margin = SupportingMargin,
                HorizontalTextAlignment = TextAlignment.Start,
                TextColor = SupportingTextColor,
                FontFamily = SupportingFontFamily,
                FontSize = SupportingSize
            };

            mainContainer.Children.Add(_container);
            mainContainer.Children.Add(_lblSupporting);

            Effects.Add(new TouchAndPressEffect());

            Content = mainContainer;
        }

        private void SetCustomIcon()
        {
            if (!IsEnabled)
            {
                if (IsChecked)
                {
                    if (CustomDisabledSelectedIcon != null)
                        _customIcon.SetCustomImage(CustomDisabledSelectedIcon.CreateContent() as View);
                    else if (CustomSelectedIcon != null)
                        _customIcon.SetCustomImage(CustomSelectedIcon.CreateContent() as View);
                    else if (DisabledUnselectedIcon != null)
                        _customIcon.SetImage(DisabledSelectedIcon);
                    else
                        _customIcon.SetImage(SelectedIcon);
                }
                else
                {
                    if (CustomDisabledUnselectedIcon != null)
                        _customIcon.SetCustomImage(CustomDisabledUnselectedIcon.CreateContent() as View);
                    else if (CustomUnselectedIcon != null)
                        _customIcon.SetCustomImage(CustomUnselectedIcon.CreateContent() as View);
                    else if (DisabledUnselectedIcon != null)
                        _customIcon.SetImage(DisabledUnselectedIcon);
                    else
                        _customIcon.SetImage(UnselectedIcon);
                }
            }
            else
            {
                if (IsChecked)
                {
                    if (CustomSelectedIcon != null)
                        _customIcon.SetCustomImage(CustomSelectedIcon.CreateContent() as View);
                    else
                        _customIcon.SetImage(SelectedIcon);
                }
                else
                {
                    if (CustomUnselectedIcon != null)
                        _customIcon.SetCustomImage(CustomUnselectedIcon.CreateContent() as View);
                    else
                        _customIcon.SetImage(UnselectedIcon);
                }
            }
        }

        protected override void SetIcon()
        {
            _imageContainer.IsVisible = true;
            _chkContainer.IsVisible = false;
            _radioButtonContainer.IsVisible = false;
            SetCustomIcon();
        }

        protected override void SetIsChecked()
        {
            if (CustomSelectedIcon != null || SelectedIcon != null)
                SetIcon();

            _chk.IsChecked = IsChecked;
            _radioButton.IsChecked = IsChecked;
        }

        protected override void SetIsEnabled()
        {
            if (CustomSelectedIcon != null || SelectedIcon != null)
                SetIcon();

            _chk.IsEnabled = IsEnabled;
            _chk.Color = IsEnabled ? Color : DisabledColor;
            _radioButton.IsEnabled = IsEnabled;
            _radioButton.Color = IsEnabled ? Color : DisabledColor;
            _lblLeftText.TextColor = IsEnabled ? TextColor : DisabledTextColor;
            _lblRightText.TextColor = IsEnabled ? TextColor : DisabledTextColor;
        }

        public void ConsumeEvent(EventType gestureType)
        {
            TouchAndPressAnimation.Animate(this, gestureType);
        }

        public void ExecuteAction()
        {
            if (IsEnabled)
                IsChecked = !IsChecked;

            if (IsEnabled && Command != null && Command.CanExecute(CommandParameter))
                Command.Execute(CommandParameter);
        }

        #endregion Methods
    }
}