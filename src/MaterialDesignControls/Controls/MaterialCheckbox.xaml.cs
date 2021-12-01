using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Plugin.MaterialDesignControls.Animations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialCheckbox : BaseMaterialCheckboxes, ITouchAndPressEffectConsumer
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

        #region Events

        public event EventHandler IsCheckedChanged;

        #endregion Events

        #region Methods

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!this.Initialized)
            {
                this.Initialized = true;
                this.InitializeComponent();
                Initialize();
            }

            UpdateLayout(propertyName, container, lblAssistive);

            switch (propertyName)
            {
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
                    customIcon.ImageHeightRequest = IconHeightRequest;
                    break;
                case nameof(IconWidthRequest):
                    customIcon.ImageWidthRequest = IconWidthRequest;
                    break;
                case nameof(Color):
                case nameof(DisabledColor):
                    chk.Color = IsEnabled ? Color : DisabledColor;
                    break;
                case nameof(SelectionHorizontalOptions):
                    chkContainer.HorizontalOptions = SelectionHorizontalOptions;
                    customIcon.HorizontalOptions = SelectionHorizontalOptions;
                    break;
                case nameof(IsEnabled):
                    SetIsEnabled();
                    break;
            }
        }

        private void Initialize()
        {
            container.Spacing = Spacing;
            //TextSide = TextSide;
            //SelectionHorizontalOptions = SelectionHorizontalOptions;
            chk.IsEnabled = IsEnabled;
            chk.Color = Color;
            customIcon.ImageHeightRequest = IconHeightRequest;
            customIcon.ImageWidthRequest = IconWidthRequest;
            customIcon.BackgroundColor = Color.Green;
            customIcon.Padding = 0;
            Effects.Add(new TouchAndPressEffect());
        }

        private void SetCustomIcon()
        {
            var text = Text;
            if (!IsEnabled)
            { 
                if (IsChecked)
                {
                    if (CustomDisabledSelectedIcon != null)
                        customIcon.SetCustomImage(CustomDisabledSelectedIcon);
                    else if (CustomSelectedIcon != null)
                        customIcon.SetCustomImage(CustomSelectedIcon);
                    else if (DisabledUnselectedIcon != null)
                        customIcon.SetImage(DisabledSelectedIcon);
                    else
                        customIcon.SetImage(SelectedIcon);
		        }
                else 
		        {
                    if (CustomDisabledUnselectedIcon != null)
                        customIcon.SetCustomImage(CustomDisabledUnselectedIcon);
                    else if (CustomUnselectedIcon != null)
                        customIcon.SetCustomImage(CustomUnselectedIcon);
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
                        customIcon.SetCustomImage(CustomSelectedIcon);
                    else
                        customIcon.SetImage(SelectedIcon);
                }
                else 
		        {
                    if (CustomUnselectedIcon != null)
                        customIcon.SetCustomImage(CustomUnselectedIcon);
                    else
                        customIcon.SetImage(UnselectedIcon);
                }
            }
	    }

        protected override void SetIcon()
        {
            customIcon.IsVisible = true;
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
            {
                IsCheckedChanged?.Invoke(this, null);
                IsChecked = !IsChecked;
            }

            if (IsEnabled && Command != null && Command.CanExecute(CommandParameter))
                Command.Execute(CommandParameter);
	    }

        #endregion Methods
    }
}
