using System;
using System.Runtime.CompilerServices;
using Plugin.MaterialDesignControls.Animations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialSwitch : ContentView
    {
        #region Attributes

        private bool Initialized = false;

        private bool swIsClicked = false;

        #endregion Attributes

        #region Constructors

        public MaterialSwitch()
        {
            if (!Initialized)
            {
                Initialized = true;
                InitializeComponent();
                Initialize();
            }
            sw.Toggled += (s, e) => 
	        {
                if (IsEnabled)
                {
                    swIsClicked = true;
                    Toggled?.Invoke(this, null);
                    IsToggled = !IsToggled;
		        }
	        };
        }

        #endregion Constructors

        #region Properties

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialSwitch), defaultValue: string.Empty);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialSwitch), defaultValue: Color.Gray);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledTextColorProperty =
            BindableProperty.Create(nameof(DisabledTextColor), typeof(Color), typeof(MaterialSwitch), defaultValue: Color.LightGray);

        public Color DisabledTextColor
        {
            get { return (Color)GetValue(DisabledTextColorProperty); }
            set { SetValue(DisabledTextColorProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MaterialSwitch), defaultValue: Font.Default.FontSize);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(MaterialSwitch), defaultValue: null);

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

        public static readonly BindableProperty AssistiveTextProperty =
            BindableProperty.Create(nameof(AssistiveText), typeof(string), typeof(MaterialSwitch), defaultValue: null, validateValue: OnAssistiveTextValidate);

        public string AssistiveText
        {
            get { return (string)GetValue(AssistiveTextProperty); }
            set { SetValue(AssistiveTextProperty, value); }
        }

        public static readonly BindableProperty AssistiveTextColorProperty =
            BindableProperty.Create(nameof(AssistiveTextColor), typeof(Color), typeof(MaterialSwitch), defaultValue: Color.Gray);

        public Color AssistiveTextColor
        {
            get { return (Color)GetValue(AssistiveTextColorProperty); }
            set { SetValue(AssistiveTextColorProperty, value); }
        }

        public static readonly BindableProperty AssistiveSizeProperty =
            BindableProperty.Create(nameof(AssistiveSize), typeof(double), typeof(MaterialSwitch), defaultValue: Font.Default.FontSize);

        public double AssistiveSize
        {
            get { return (double)GetValue(AssistiveSizeProperty); }
            set { SetValue(AssistiveSizeProperty, value); }
        }

        public static readonly BindableProperty AssistiveFontFamilyProperty =
            BindableProperty.Create(nameof(AssistiveFontFamily), typeof(string), typeof(MaterialSwitch), defaultValue: null);

        public string AssistiveFontFamily
        {
            get { return (string)GetValue(AssistiveFontFamilyProperty); }
            set { SetValue(AssistiveFontFamilyProperty, value); }
        }

        public static readonly BindableProperty AssistiveMarginProperty =
            BindableProperty.Create(nameof(AssistiveMargin), typeof(Thickness), typeof(MaterialSwitch), defaultValue: new Thickness(14, 2, 14, 0));

        public Thickness AssistiveMargin
        {
            get { return (Thickness)GetValue(AssistiveMarginProperty); }
            set { SetValue(AssistiveMarginProperty, value); }
        }

        public static readonly BindableProperty AnimateErrorProperty =
            BindableProperty.Create(nameof(AnimateError), typeof(bool), typeof(MaterialSwitch), defaultValue: false);

        public bool AnimateError
        {
            get { return (bool)GetValue(AnimateErrorProperty); }
            set { SetValue(AnimateErrorProperty, value); }
        }

        public static readonly BindableProperty OnColorProperty =
            BindableProperty.Create(nameof(OnColor), typeof(Color), typeof(MaterialSwitch), defaultValue: Color.FromHex("#2e85cc"));

        public Color OnColor
	    {
            get { return (Color)GetValue(OnColorProperty); }
            set { SetValue(OnColorProperty, value); }
        }

        public static readonly BindableProperty ThumbColorProperty =
            BindableProperty.Create(nameof(ThumbColor), typeof(Color), typeof(MaterialSwitch), defaultValue: Color.White);

        public Color ThumbColor
	    {
            get { return (Color)GetValue(ThumbColorProperty); }
            set { SetValue(ThumbColorProperty, value); }
        }

        public static readonly BindableProperty IsToggledProperty =
            BindableProperty.Create(nameof(IsToggled), typeof(bool), typeof(MaterialSwitch), defaultValue: false, BindingMode.TwoWay);

        public bool IsToggled
	    {
            get { return (bool)GetValue(IsToggledProperty); }
            set { SetValue(IsToggledProperty, value); }
        }

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

        #endregion Properties

        #region Events

        public event EventHandler Toggled;

        #endregion Events

        #region Methods

        private void Initialize()
        {
            lblLeft.VerticalOptions = TextVerticalOptions;
            lblRight.VerticalOptions = TextVerticalOptions;
            sw.OnColor = OnColor;
            sw.ThumbColor = ThumbColor;
            container.Spacing = Spacing;
	    }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!Initialized)
            {
                Initialized = true;
                InitializeComponent();
                Initialize();
            }

            switch (propertyName) 
	        {
                case nameof(TranslationX):
                    base.OnPropertyChanged(propertyName);
                    break;
                case nameof(Text):
                    lblLeft.Text = Text;
                    lblRight.Text = Text;
                    break;
                case nameof(TextColor):
                case nameof(DisabledTextColor):
                    lblLeft.TextColor = IsEnabled ? TextColor : DisabledTextColor;
                    lblRight.TextColor = IsEnabled? TextColor : DisabledTextColor;
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
                case nameof(OnColor):
                    sw.OnColor = OnColor;
                    break;
                case nameof(ThumbColor):
                    sw.ThumbColor = ThumbColor;
                    break;
                case nameof(IsEnabled):
                    if (!IsEnabled)
                    {
                        sw.IsEnabled = IsEnabled;
                        TextColor = DisabledTextColor;
		            }
                    break;
                case nameof(IsToggled):
                    if (!swIsClicked)
                        sw.IsToggled = IsToggled;
                    else
                        swIsClicked = false;
                    break;
                case nameof(AssistiveText):
                    lblAssistive.Text = AssistiveText;
                    lblAssistive.IsVisible = !string.IsNullOrEmpty(AssistiveText);
                    if (AnimateError && !string.IsNullOrEmpty(AssistiveText))
                        ShakeAnimation.Animate(this);
                    break;
                case nameof(AssistiveTextColor):
                    lblAssistive.TextColor = AssistiveTextColor;
                    break;
                case nameof(AssistiveSize):
                    lblAssistive.FontSize = AssistiveSize;
                    break;
                case nameof(AssistiveFontFamily):
                    lblAssistive.FontFamily = AssistiveFontFamily;
                    break;
                case nameof(AssistiveMargin):
                    lblAssistive.Margin = AssistiveMargin;
                    break;
                case nameof(TextHorizontalOptions):
                    if (TextSide == TextSide.Left)
                        lblLeft.HorizontalOptions = TextHorizontalOptions;
                    else
                        lblRight.HorizontalOptions = TextHorizontalOptions;
                    break;
                case nameof(SwitchHorizontalOptions):
                    sw.HorizontalOptions = SwitchHorizontalOptions;
                    sw.HorizontalOptions = SwitchHorizontalOptions;
                    break;
                case nameof(Spacing):
                    container.Spacing = Spacing;
                    break;
	        }
        }
        private static bool OnAssistiveTextValidate(BindableObject bindable, object value)
        {
            var control = (MaterialSwitch)bindable;

            // Used to animate the error when the assistive text doesn't change
            if (control.AnimateError && !string.IsNullOrEmpty(control.AssistiveText) && control.AssistiveText == (string)value)
                ShakeAnimation.Animate(control);

            return true;
        }

        #endregion Methods
    }
}
