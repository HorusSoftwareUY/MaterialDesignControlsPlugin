﻿using System.Runtime.CompilerServices;
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
            InitializeComponent();
            if (!Initialized)
            {
                Initialized = true;
                Initialize();
            };
        }

        #region Properties

        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create(nameof(Color), typeof(Color), typeof(MaterialCheckbox), defaultValue: Color.FromHex("#2E85CC"));

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly BindableProperty DisabledColorProperty =
            BindableProperty.Create(nameof(DisabledColor), typeof(Color), typeof(MaterialCheckbox), defaultValue: Color.LightGray);

        public Color DisabledColor
        {
            get { return (Color)GetValue(DisabledColorProperty); }
            set { SetValue(DisabledColorProperty, value); }
        }

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(BaseMaterialCheckboxes));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(BaseMaterialCheckboxes), defaultValue: null);

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        #endregion Properties

        #region Methods

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

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
            Spacing = Spacing;
            TextSide = TextSide;
            SelectionHorizontalOptions = SelectionHorizontalOptions;
            chk.IsEnabled = IsEnabled;
            chk.Color = Color;
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
                        customIcon.SetCustomImage(CustomDisabledSelectedIcon);
                    else if (CustomSelectedIcon != null)
                        customIcon.SetCustomImage(CustomSelectedIcon);
                    else if (UnselectedIcon != null)
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
                    else
                        customIcon.SetImage(DisabledUnselectedIcon);
		        }
	        }
            else 
	        {
                if (IsChecked)
                {
                    if (CustomSelectedIcon != null)
                    {
                        customIcon.SetCustomImage(CustomSelectedIcon);
                        //Debug.WriteLine("----Custom selected icon");
                        //Debug.WriteLine($"Option: {Text}");
                        //Debug.WriteLine($"icon visible: {customIcon.IsVisible}");
                    }
                    else
                    { 
                        customIcon.SetImage(SelectedIcon);
                        //Debug.WriteLine("----selected icon}");
                        //Debug.WriteLine($"Option: {Text}");
                        //Debug.WriteLine($"icon visible: {customIcon.IsVisible}");
                    }
                }
                else 
		        {
                    if (CustomUnselectedIcon != null)
                    { 
                        customIcon.SetCustomImage(CustomUnselectedIcon);
                        //Debug.WriteLine("----custom unselected icon");
                        //Debug.WriteLine($"Option: {Text}");
                        //Debug.WriteLine($"icon visible: {customIcon.IsVisible}");

                    }
                    else
                    { 
                        customIcon.SetImage(UnselectedIcon);
                        //Debug.WriteLine($"----Unselected icon");
                        //Debug.WriteLine($"Option: {Text}");
                        //Debug.WriteLine($"icon visible: {customIcon.IsVisible}");
                    }
                }
            }
	    }

        protected override void SetIcon()
        {
            //var text = Text;
            //Debug.WriteLine($"SetIcon {text}");
            customIcon.IsVisible = true;
            chkContainer.IsVisible = false;
            SetCustomIcon();
        }

        protected override void SetIsChecked()
        {
            //var text = Text;
            //Debug.WriteLine($"SetIsChecked {text}");
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
