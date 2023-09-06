using Plugin.MaterialDesignControls.Styles;
using Xamarin.Forms;
using Plugin.MaterialDesignControls.Animations;
using System.Runtime.CompilerServices;

namespace Plugin.MaterialDesignControls.Material3
{
    public class MaterialCustomControl : ContentView
    {
        #region Attributes

        private Plugin.MaterialDesignControls.MaterialLabel lblLabel;

        private Plugin.MaterialDesignControls.MaterialLabel lblLabelSecondary;

        private Plugin.MaterialDesignControls.MaterialLabel lblSupporting;

        private ContentView cntCustomControl;

        #endregion Attributes

        #region Properties

        public static readonly BindableProperty CustomControlProperty =
            BindableProperty.Create(nameof(CustomControl), typeof(View), typeof(MaterialCustomControl), defaultValue: null, propertyChanged: OnCustomControlChanged);

        public View CustomControl
        {
            get { return (View)GetValue(CustomControlProperty); }
            set { SetValue(CustomControlProperty, value); }
        }

        public static readonly BindableProperty AnimateErrorProperty =
            BindableProperty.Create(nameof(AnimateError), typeof(bool), typeof(MaterialCustomControl), defaultValue: DefaultStyles.AnimateError);

        public bool AnimateError
        {
            get { return (bool)GetValue(AnimateErrorProperty); }
            set { SetValue(AnimateErrorProperty, value); }
        }

        public static readonly BindableProperty HorizontalTextAlignmentProperty =
            BindableProperty.Create(nameof(HorizontalTextAlignment), typeof(TextAlignment), typeof(MaterialCustomControl), defaultValue: TextAlignment.Start);

        public TextAlignment HorizontalTextAlignment
        {
            get { return (TextAlignment)GetValue(HorizontalTextAlignmentProperty); }
            set { SetValue(HorizontalTextAlignmentProperty, value); }
        }

        #endregion Properties

        #region LabelText

        public static readonly BindableProperty LabelTextProperty =
            BindableProperty.Create(nameof(LabelText), typeof(string), typeof(MaterialCustomControl), defaultValue: null);

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public static readonly BindableProperty LabelTextColorProperty =
            BindableProperty.Create(nameof(LabelTextColor), typeof(Color), typeof(MaterialCustomControl), defaultValue: DefaultStyles.OnSurfaceVariantColor);

        public Color LabelTextColor
        {
            get { return (Color)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledLabelTextColorProperty =
            BindableProperty.Create(nameof(DisabledLabelTextColor), typeof(Color), typeof(MaterialCustomControl), defaultValue: DefaultStyles.OnSurfaceVariantColor);

        public Color DisabledLabelTextColor
        {
            get { return (Color)GetValue(DisabledLabelTextColorProperty); }
            set { SetValue(DisabledLabelTextColorProperty, value); }
        }

        public static readonly BindableProperty LabelSizeProperty =
            BindableProperty.Create(nameof(LabelSize), typeof(double), typeof(MaterialCustomControl), defaultValue: DefaultStyles.PhoneFontSizes.BodySmall);

        public double LabelSize
        {
            get { return (double)GetValue(LabelSizeProperty); }
            set { SetValue(LabelSizeProperty, value); }
        }

        public static readonly BindableProperty LabelFontFamilyProperty =
            BindableProperty.Create(nameof(LabelFontFamily), typeof(string), typeof(MaterialCustomControl), defaultValue: DefaultStyles.FontFamily);

        public string LabelFontFamily
        {
            get { return (string)GetValue(LabelFontFamilyProperty); }
            set { SetValue(LabelFontFamilyProperty, value); }
        }

        public static readonly BindableProperty LabelMarginProperty =
            BindableProperty.Create(nameof(LabelMargin), typeof(Thickness), typeof(MaterialCustomControl), defaultValue: new Thickness(16, 0, 16, 4));

        public Thickness LabelMargin
        {
            get { return (Thickness)GetValue(LabelMarginProperty); }
            set { SetValue(LabelMarginProperty, value); }
        }

        public static readonly BindableProperty LabelLineBreakModeProperty =
            BindableProperty.Create(nameof(LabelLineBreakMode), typeof(LineBreakMode), typeof(MaterialCustomControl), defaultValue: LineBreakMode.NoWrap);

        public LineBreakMode LabelLineBreakMode
        {
            get { return (LineBreakMode)GetValue(LabelLineBreakModeProperty); }
            set { SetValue(LabelLineBreakModeProperty, value); }
        }

        #endregion LabelText

        #region SupportingText

        public static readonly BindableProperty SupportingTextProperty =
            BindableProperty.Create(nameof(SupportingText), typeof(string), typeof(MaterialCustomControl), defaultValue: null, validateValue: OnSupportingTextValidate);

        public string SupportingText
        {
            get { return (string)GetValue(SupportingTextProperty); }
            set { SetValue(SupportingTextProperty, value); }
        }

        public static readonly BindableProperty SupportingTextColorProperty =
            BindableProperty.Create(nameof(SupportingTextColor), typeof(Color), typeof(MaterialCustomControl), defaultValue: DefaultStyles.ErrorColor);

        public Color SupportingTextColor
        {
            get { return (Color)GetValue(SupportingTextColorProperty); }
            set { SetValue(SupportingTextColorProperty, value); }
        }

        public static readonly BindableProperty SupportingSizeProperty =
            BindableProperty.Create(nameof(SupportingSize), typeof(double), typeof(MaterialCustomControl), defaultValue: DefaultStyles.PhoneFontSizes.BodySmall);

        public double SupportingSize
        {
            get { return (double)GetValue(SupportingSizeProperty); }
            set { SetValue(SupportingSizeProperty, value); }
        }

        public static readonly BindableProperty SupportingFontFamilyProperty =
            BindableProperty.Create(nameof(SupportingFontFamily), typeof(string), typeof(MaterialCustomControl), defaultValue: DefaultStyles.FontFamily);

        public string SupportingFontFamily
        {
            get { return (string)GetValue(SupportingFontFamilyProperty); }
            set { SetValue(SupportingFontFamilyProperty, value); }
        }

        public static readonly BindableProperty SupportingMarginProperty =
            BindableProperty.Create(nameof(SupportingMargin), typeof(Thickness), typeof(MaterialCustomControl), defaultValue: new Thickness(16, 4, 16, 0));

        public Thickness SupportingMargin
        {
            get { return (Thickness)GetValue(SupportingMarginProperty); }
            set { SetValue(SupportingMarginProperty, value); }
        }

        public static readonly BindableProperty SupportingLineBreakModeProperty =
            BindableProperty.Create(nameof(SupportingLineBreakMode), typeof(LineBreakMode), typeof(MaterialCustomControl), defaultValue: LineBreakMode.NoWrap);

        public LineBreakMode SupportingLineBreakMode
        {
            get { return (LineBreakMode)GetValue(SupportingLineBreakModeProperty); }
            set { SetValue(SupportingLineBreakModeProperty, value); }
        }

        #endregion SupportingText

        #region SecondaryLabelText

        public static readonly BindableProperty SecondaryLabelTextProperty =
            BindableProperty.Create(nameof(SecondaryLabelText), typeof(string), typeof(MaterialCustomControl), defaultValue: null);

        public string SecondaryLabelText
        {
            get { return (string)GetValue(SecondaryLabelTextProperty); }
            set { SetValue(SecondaryLabelTextProperty, value); }
        }

        public static readonly BindableProperty SecondaryLabelTextColorProperty =
            BindableProperty.Create(nameof(SecondaryLabelTextColor), typeof(Color), typeof(MaterialCustomControl), defaultValue: DefaultStyles.OnSurfaceVariantColor);

        public Color SecondaryLabelTextColor
        {
            get { return (Color)GetValue(SecondaryLabelTextColorProperty); }
            set { SetValue(SecondaryLabelTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledSecondaryLabelTextColorProperty =
            BindableProperty.Create(nameof(DisabledSecondaryLabelTextColor), typeof(Color), typeof(MaterialCustomControl), defaultValue: DefaultStyles.OnSurfaceVariantColor);

        public Color DisabledSecondaryLabelTextColor
        {
            get { return (Color)GetValue(DisabledSecondaryLabelTextColorProperty); }
            set { SetValue(DisabledSecondaryLabelTextColorProperty, value); }
        }

        public static readonly BindableProperty SecondaryLabelFontSizeProperty =
            BindableProperty.Create(nameof(SecondaryLabelFontSize), typeof(double), typeof(MaterialCustomControl), defaultValue: DefaultStyles.PhoneFontSizes.BodySmall);

        public double SecondaryLabelFontSize
        {
            get { return (double)GetValue(SecondaryLabelFontSizeProperty); }
            set { SetValue(SecondaryLabelFontSizeProperty, value); }
        }

        public static readonly BindableProperty SecondaryLabelFontFamilyProperty =
            BindableProperty.Create(nameof(SecondaryLabelFontFamily), typeof(string), typeof(MaterialCustomControl), defaultValue: DefaultStyles.FontFamily);

        public string SecondaryLabelFontFamily
        {
            get { return (string)GetValue(SecondaryLabelFontFamilyProperty); }
            set { SetValue(SecondaryLabelFontFamilyProperty, value); }
        }

        public static readonly BindableProperty SecondaryLabelMarginProperty =
            BindableProperty.Create(nameof(SecondaryLabelMargin), typeof(Thickness), typeof(MaterialCustomControl), defaultValue: new Thickness(16, 0, 16, 4));

        public Thickness SecondaryLabelMargin
        {
            get { return (Thickness)GetValue(SecondaryLabelMarginProperty); }
            set { SetValue(SecondaryLabelMarginProperty, value); }
        }

        public static readonly BindableProperty SecondaryLabelLineBreakModeProperty =
            BindableProperty.Create(nameof(SecondaryLabelLineBreakMode), typeof(LineBreakMode), typeof(MaterialCustomControl), defaultValue: LineBreakMode.NoWrap);

        public LineBreakMode SecondaryLabelLineBreakMode
        {
            get { return (LineBreakMode)GetValue(SecondaryLabelLineBreakModeProperty); }
            set { SetValue(SecondaryLabelLineBreakModeProperty, value); }
        }

        #endregion SecondaryLabelText

        #region Constructor

        public MaterialCustomControl()
        {
            var stackLayout = new StackLayout { Spacing = 0 };

            lblLabel = new Plugin.MaterialDesignControls.MaterialLabel
            {
                IsVisible = false,
                LineBreakMode = LabelLineBreakMode,
                Margin = LabelMargin,
                HorizontalTextAlignment = HorizontalTextAlignment,
                FontSize = LabelSize,
                FontFamily = LabelFontFamily
            };

            lblLabelSecondary = new Plugin.MaterialDesignControls.MaterialLabel
            {
                IsVisible = false,
                LineBreakMode = SecondaryLabelLineBreakMode,
                Margin = SecondaryLabelMargin,
                HorizontalTextAlignment = TextAlignment.End,
                FontSize = SecondaryLabelFontSize,
                FontFamily = SecondaryLabelFontFamily
            };

            var gridTexts = new Grid();
            gridTexts.Children.Add(lblLabel, 0, 0);
            gridTexts.Children.Add(lblLabelSecondary, 1, 0);

            SetLabelTextColor();
            SetLabelSecondaryTextColor();

            stackLayout.Children.Add(gridTexts);

            cntCustomControl = new ContentView();

            stackLayout.Children.Add(cntCustomControl);

            lblSupporting = new Plugin.MaterialDesignControls.MaterialLabel
            {
                IsVisible = false,
                LineBreakMode = SupportingLineBreakMode,
                Margin = SupportingMargin,
                HorizontalTextAlignment = HorizontalTextAlignment,
                FontFamily = SupportingFontFamily,
                TextColor = SupportingTextColor,
                FontSize = SupportingSize
            };

            stackLayout.Children.Add(lblSupporting);
            SecondaryLabelText = "";
            Content = stackLayout;
        }

        #endregion Constructor

        #region Methods

        private static void OnCustomControlChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is MaterialCustomControl control && control.cntCustomControl != null)
                control.cntCustomControl.Content = (View)newValue;
        }

        private static bool OnSupportingTextValidate(BindableObject bindable, object value)
        {
            var control = (MaterialCustomControl)bindable;

            // Used to animate the error when the supporting text doesn't change
            if (control.AnimateError && !string.IsNullOrEmpty(control.SupportingText) && control.SupportingText == (string)value)
                ShakeAnimation.Animate(control);

            return true;
        }

        protected void SetLabelTextColor()
            => lblLabel.TextColor = !IsEnabled ? DisabledLabelTextColor : LabelTextColor;

        protected void SetLabelSecondaryTextColor()
            => lblLabelSecondary.TextColor = !IsEnabled ? DisabledSecondaryLabelTextColor : SecondaryLabelTextColor;

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            switch (propertyName)
            {
                case nameof(IsEnabled):
                    SetLabelTextColor();
                    SetLabelSecondaryTextColor();
                    break;
                case nameof(LabelFontFamily):
                    lblLabel.FontFamily = LabelFontFamily;
                    break;
                case nameof(SupportingFontFamily):
                    lblSupporting.FontFamily = SupportingFontFamily;
                    break;
                case nameof(LabelText):
                    lblLabel.Text = LabelText;
                    lblLabel.IsVisible = true;
                    break;
                case nameof(LabelTextColor):
                    SetLabelTextColor();
                    break;
                case nameof(LabelSize):
                    lblLabel.FontSize = LabelSize;
                    break;
                case nameof(LabelMargin):
                    lblLabel.Margin = LabelMargin;
                    break;
                case nameof(SupportingText):
                    lblSupporting.Text = SupportingText;
                    lblSupporting.IsVisible = !string.IsNullOrEmpty(SupportingText);
                    if (AnimateError && !string.IsNullOrEmpty(SupportingText))
                        ShakeAnimation.Animate(this);
                    break;
                case nameof(SupportingTextColor):
                    lblSupporting.TextColor = SupportingTextColor;
                    break;
                case nameof(SupportingSize):
                    lblSupporting.FontSize = SupportingSize;
                    break;
                case nameof(SupportingMargin):
                    lblSupporting.Margin = SupportingMargin;
                    break;
                case nameof(HorizontalTextAlignment):
                    lblLabel.HorizontalTextAlignment = HorizontalTextAlignment;
                    lblSupporting.HorizontalTextAlignment = HorizontalTextAlignment;
                    break;
                case nameof(LabelLineBreakMode):
                    lblLabel.LineBreakMode = LabelLineBreakMode;
                    break;
                case nameof(SupportingLineBreakMode):
                    lblSupporting.LineBreakMode = SupportingLineBreakMode;
                    break;
                case nameof(SecondaryLabelText):
                    lblLabelSecondary.Text = SecondaryLabelText;
                    lblLabelSecondary.IsVisible = true;
                    break;
                case nameof(SecondaryLabelTextColor):
                    SetLabelSecondaryTextColor();
                    break;
                case nameof(SecondaryLabelFontSize):
                    lblLabelSecondary.FontSize = SecondaryLabelFontSize;
                    break;
                case nameof(SecondaryLabelFontFamily):
                    lblLabelSecondary.FontFamily = SecondaryLabelFontFamily;
                    break;
                case nameof(SecondaryLabelMargin):
                    lblLabelSecondary.Margin = SecondaryLabelMargin;
                    break;
                case nameof(SecondaryLabelLineBreakMode):
                    lblLabelSecondary.LineBreakMode = SecondaryLabelLineBreakMode;
                    break;
                default:
                    base.OnPropertyChanged(propertyName);
                    break;
            }
        }

        #endregion Methods
    }
}