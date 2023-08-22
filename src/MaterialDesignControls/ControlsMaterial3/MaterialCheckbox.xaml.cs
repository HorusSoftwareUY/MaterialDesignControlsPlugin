using Plugin.MaterialDesignControls.Animations;
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

        public MaterialCheckbox()
        {
            if (!this.Initialized)
            {
                this.Initialized = true;
                this.InitializeComponent();
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

        #endregion Properties


        #region Methods

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!this.Initialized)
            {
                this.Initialized = true;
                this.InitializeComponent();
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
                    break;
                case nameof(TextHorizontalOptions):
                    if (TextSide == TextSide.Left)
                        lblLeftText.HorizontalOptions = TextHorizontalOptions;
                    else
                        lblRightText.HorizontalOptions = TextHorizontalOptions;
                    break;
                case nameof(IconHeightRequest):
                    imageContainer.HeightRequest = IconHeightRequest;
                    customIcon.HeightRequest = IconHeightRequest;
                    break;
                case nameof(IconWidthRequest):
                    imageContainer.HeightRequest = IconWidthRequest;
                    customIcon.HeightRequest = IconWidthRequest;
                    break;
                case nameof(Color):
                case nameof(DisabledColor):
                    chk.Color = IsEnabled ? Color : DisabledColor;
                    break;
                case nameof(SelectionHorizontalOptions):
                    chkContainer.HorizontalOptions = SelectionHorizontalOptions;
                    imageContainer.HorizontalOptions = SelectionHorizontalOptions;
                    break;
                case nameof(IsEnabled):
                    SetIsEnabled();
                    break;
            }
        }

        private void Initialize()
        {
            container.Spacing = Spacing;
            chk.IsEnabled = IsEnabled;
            chk.Color = Color;
            imageContainer.HeightRequest = IconHeightRequest;
            imageContainer.WidthRequest = IconWidthRequest;
            customIcon.ImageHeightRequest = IconHeightRequest;
            customIcon.ImageWidthRequest = IconWidthRequest;
            customIcon.Padding = 0;
            Effects.Add(new TouchAndPressEffect());
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
            SetCustomIcon();
        }

        protected override void SetIsChecked()
        {
            if (CustomSelectedIcon != null || SelectedIcon != null)
                SetIcon();

            chk.IsChecked = IsChecked;
        }

        protected override void SetIsEnabled()
        {
            if (CustomSelectedIcon != null || SelectedIcon != null)
                SetIcon();

            chk.IsEnabled = IsEnabled;
            chk.Color = IsEnabled ? Color : DisabledColor;
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