using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Implementations;
using Plugin.MaterialDesignControls.Material3.Implementations;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls.Material3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialCheckbox : BaseMaterialCheckBoxes, ITouchAndPressEffectConsumer
    {
        private bool Initialized = false;

        private StackLayout container;
        private MaterialLabel lblLeftText;
        private Grid chkContainer;
        private CustomCheckBox chk;
        private Grid radioButtonContainer;
        private CustomRadioButton radioButton;
        private Grid imageContainer;
        private CustomImageButton customIcon;
        private MaterialLabel lblRightText;
        private MaterialLabel lblSupporting;


        public MaterialCheckbox()
        {
            if (!this.Initialized)
            {
                this.Initialized = true;
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
            if (!this.Initialized)
            {
                this.Initialized = true;
                Initialize();
            }

            UpdateLayout(propertyName, container, lblSupporting);

            switch (propertyName)
            {
                case nameof(TranslationX):
                case nameof(Scale):
                case nameof(Opacity):
                    base.OnPropertyChanged(propertyName);
                    break;
                case nameof(Text):
                    lblRightText.Text = Text;
                    break;
                case nameof(TextColor):
                    lblLeftText.TextColor = TextColor;
                    lblRightText.TextColor = TextColor;
                    break;
                case nameof(DisabledTextColor):
                    if (!IsEnabled)
                    {
                        lblLeftText.TextColor = DisabledTextColor;
                        lblRightText.TextColor = DisabledTextColor;
                    }
                    break;
                case nameof(FontSize):
                    lblLeftText.FontSize = FontSize;
                    lblRightText.FontSize = FontSize;
                    break;
                case nameof(FontFamily):
                    lblLeftText.FontFamily = FontFamily;
                    lblRightText.FontFamily = FontFamily;
                    break;
                case nameof(TextSide):
                    if (TextSide == TextSide.Left)
                    {
                        lblLeftText.Text = Text;
                        lblLeftText.IsVisible = true;
                        lblRightText.IsVisible = false;
                    }
                    else
                    {
                        lblRightText.Text = Text;
                        lblRightText.IsVisible = true;
                        lblLeftText.IsVisible = false;
                    }
                    break;
                case nameof(TextHorizontalOptions):
                    if (TextSide == TextSide.Left)
                        lblLeftText.HorizontalOptions = TextHorizontalOptions;
                    else
                        lblRightText.HorizontalOptions = TextHorizontalOptions;
                    break;
                case nameof(IconHeightRequest):
                    customIcon.HeightRequest = IconHeightRequest;
                    break;
                case nameof(IconWidthRequest):
                    customIcon.HeightRequest = IconWidthRequest;
                    break;
                case nameof(Color):
                case nameof(DisabledColor):
                    chk.Color = IsEnabled ? Color : DisabledColor;
                    radioButton.Color = IsEnabled ? Color : DisabledColor;
                    break;
                case nameof(SelectionHorizontalOptions):
                    chkContainer.HorizontalOptions = SelectionHorizontalOptions;
                    imageContainer.HorizontalOptions = SelectionHorizontalOptions;
                    radioButtonContainer.HorizontalOptions = SelectionHorizontalOptions;
                    break;
                case nameof(IsEnabled):
                    SetIsEnabled();
                    break;
                case nameof(IsRadioButtonStyle):
                    chkContainer.IsVisible = false;
                    radioButtonContainer.IsVisible = true;
                    break;
            }
        }

        private void Initialize()
        {
            StackLayout mainContainer = new StackLayout()
            {
                Spacing = 0,
                VerticalOptions = LayoutOptions.Center
            };

            container = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal
            };

            lblLeftText = new MaterialLabel()
            {
                VerticalTextAlignment = TextAlignment.Center,
                IsVisible = true
            };

            chkContainer = new Grid()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 40,
                HeightRequest = 40
            };

            chk = new CustomCheckBox()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 25,
                HeightRequest = 25
            };

            BoxView chkBoxView = new BoxView()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 25,
                HeightRequest = 25
            };

            chkContainer.Children.Add(chk);
            chkContainer.Children.Add(chkBoxView);

            radioButtonContainer = new Grid()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 40,
                HeightRequest = 40,
                IsVisible = false
            };

            radioButton = new CustomRadioButton()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            BoxView radioButtonBoxView = new BoxView()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 25,
                HeightRequest = 25
            };

            radioButtonContainer.Children.Add(radioButton);
            radioButtonContainer.Children.Add(radioButtonBoxView);

            imageContainer = new Grid()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 40,
                HeightRequest = 40,
                IsVisible = false
            };

            customIcon = new CustomImageButton()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start
            };

            BoxView iconBoxView = new BoxView()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 25,
                HeightRequest = 25,
                BackgroundColor = Color.Transparent
            };

            imageContainer.Children.Add(chk);
            imageContainer.Children.Add(iconBoxView);

            lblRightText = new MaterialLabel()
            {
                VerticalTextAlignment = TextAlignment.Center,
                IsVisible = true
            };

            container.Children.Add(lblLeftText);
            container.Children.Add(chkContainer);
            container.Children.Add(radioButtonContainer);
            container.Children.Add(imageContainer);
            container.Children.Add(lblRightText);

            lblSupporting = new MaterialLabel()
            {
                IsVisible = false,
                LineBreakMode = LineBreakMode.NoWrap,
                Margin = new Thickness(14, 2, 14, 0),
                HorizontalTextAlignment = TextAlignment.Start
            };

            mainContainer.Children.Add(container);
            mainContainer.Children.Add(lblSupporting);

            container.Spacing = Spacing;

            chk.IsEnabled = IsEnabled;
            chk.Color = Color;

            radioButton.IsEnabled = IsEnabled;
            radioButton.Color = Color;

            customIcon.ImageHeightRequest = IconHeightRequest;
            customIcon.ImageWidthRequest = IconWidthRequest;
            customIcon.Padding = 0;

            lblLeftText.TextColor = TextColor;
            lblLeftText.FontFamily = FontFamily;
            lblLeftText.FontSize = FontSize;

            lblRightText.TextColor = TextColor;
            lblRightText.FontFamily = FontFamily;
            lblRightText.FontSize = FontSize;

            lblSupporting.TextColor = SupportingTextColor;
            lblSupporting.FontFamily = SupportingFontFamily;
            lblSupporting.FontSize = SupportingSize;
            lblSupporting.Margin = SupportingMargin;

            Effects.Add(new TouchAndPressEffect());

            this.Content = mainContainer;
        }

        private void SetCustomIcon()
        {
            if (!IsEnabled)
            {
                if (IsChecked)
                {
                    if (CustomDisabledSelectedIcon != null)
                        customIcon.SetCustomImage(CustomDisabledSelectedIcon.CreateContent() as View);
                    else if (CustomSelectedIcon != null)
                        customIcon.SetCustomImage(CustomSelectedIcon.CreateContent() as View);
                    else if (DisabledUnselectedIcon != null)
                        customIcon.SetImage(DisabledSelectedIcon);
                    else
                        customIcon.SetImage(SelectedIcon);
                }
                else
                {
                    if (CustomDisabledUnselectedIcon != null)
                        customIcon.SetCustomImage(CustomDisabledUnselectedIcon.CreateContent() as View);
                    else if (CustomUnselectedIcon != null)
                        customIcon.SetCustomImage(CustomUnselectedIcon.CreateContent() as View);
                    else if (DisabledUnselectedIcon != null)
                        customIcon.SetImage(DisabledUnselectedIcon);
                    else
                        customIcon.SetImage(UnselectedIcon);
                }
            }
            else
            {
                if (IsChecked)
                {
                    if (CustomSelectedIcon != null)
                        customIcon.SetCustomImage(CustomSelectedIcon.CreateContent() as View);
                    else
                        customIcon.SetImage(SelectedIcon);
                }
                else
                {
                    if (CustomUnselectedIcon != null)
                        customIcon.SetCustomImage(CustomUnselectedIcon.CreateContent() as View);
                    else
                        customIcon.SetImage(UnselectedIcon);
                }
            }
        }

        protected override void SetIcon()
        {
            imageContainer.IsVisible = true;
            chkContainer.IsVisible = false;
            radioButtonContainer.IsVisible = false;
            SetCustomIcon();
        }

        protected override void SetIsChecked()
        {
            if (CustomSelectedIcon != null || SelectedIcon != null)
                SetIcon();

            chk.IsChecked = IsChecked;
            radioButton.IsChecked = IsChecked;
        }

        protected override void SetIsEnabled()
        {
            if (CustomSelectedIcon != null || SelectedIcon != null)
                SetIcon();

            chk.IsEnabled = IsEnabled;
            chk.Color = IsEnabled ? Color : DisabledColor;
            radioButton.IsEnabled = IsEnabled;
            radioButton.Color = IsEnabled ? Color : DisabledColor;
            lblLeftText.TextColor = IsEnabled ? TextColor : DisabledTextColor;
            lblRightText.TextColor = IsEnabled ? TextColor : DisabledTextColor;
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