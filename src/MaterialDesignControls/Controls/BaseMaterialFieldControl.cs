using System;
using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public abstract class BaseMaterialFieldControl : ContentView
    {
        #region Properties

        public static readonly BindableProperty TypeProperty =
            BindableProperty.Create(nameof(Type), typeof(FieldTypes), typeof(BaseMaterialFieldControl), defaultValue: FieldTypes.Filled);

        public FieldTypes Type
        {
            get { return (FieldTypes)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public static readonly BindableProperty FieldHeightRequestProperty =
            BindableProperty.Create(nameof(FieldHeightRequest), typeof(double), typeof(BaseMaterialFieldControl), defaultValue: 40.0);

        public double FieldHeightRequest
        {
            get { return (double)GetValue(FieldHeightRequestProperty); }
            set { SetValue(FieldHeightRequestProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(BaseMaterialFieldControl), defaultValue: 4.0);

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty AnimateErrorProperty =
            BindableProperty.Create(nameof(AnimateError), typeof(bool), typeof(BaseMaterialFieldControl), defaultValue: false);

        public bool AnimateError
        {
            get { return (bool)GetValue(AnimateErrorProperty); }
            set { SetValue(AnimateErrorProperty, value); }
        }

        public static readonly BindableProperty HorizontalTextAlignmentProperty =
            BindableProperty.Create(nameof(HorizontalTextAlignment), typeof(TextAlignment), typeof(BaseMaterialFieldControl), defaultValue: TextAlignment.Start);

        public TextAlignment HorizontalTextAlignment
        {
            get { return (TextAlignment)GetValue(HorizontalTextAlignmentProperty); }
            set { SetValue(HorizontalTextAlignmentProperty, value); }
        }

        public abstract bool IsControlFocused { get; }

        public abstract bool IsControlEnabled { get; }

        public abstract Color BackgroundColorControl { get; }

        #endregion Properties

        #region Text

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: Color.Gray);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty FocusedTextColorProperty =
            BindableProperty.Create(nameof(FocusedTextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: Color.Gray);

        public Color FocusedTextColor
        {
            get { return (Color)GetValue(FocusedTextColorProperty); }
            set { SetValue(FocusedTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledTextColorProperty =
            BindableProperty.Create(nameof(DisabledTextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: Color.LightGray);

        public Color DisabledTextColor
        {
            get { return (Color)GetValue(DisabledTextColorProperty); }
            set { SetValue(DisabledTextColorProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(BaseMaterialFieldControl), defaultValue: Font.Default.FontSize);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(BaseMaterialFieldControl), defaultValue: null);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        #endregion Text

        #region Placeholder

        public static readonly BindableProperty PlaceholderProperty =
            BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(BaseMaterialFieldControl), defaultValue: null);

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public static readonly BindableProperty PlaceholderColorProperty =
            BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: Color.Gray);

        public Color PlaceholderColor
        {
            get { return (Color)GetValue(PlaceholderColorProperty); }
            set { SetValue(PlaceholderColorProperty, value); }
        }

        #endregion Placeholder

        #region LabelText

        public static readonly BindableProperty LabelTextProperty =
            BindableProperty.Create(nameof(LabelText), typeof(string), typeof(BaseMaterialFieldControl), defaultValue: null);

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public static readonly BindableProperty LabelTextColorProperty =
            BindableProperty.Create(nameof(LabelTextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: Color.Gray);

        public Color LabelTextColor
        {
            get { return (Color)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public static readonly BindableProperty FocusedLabelTextColorProperty =
            BindableProperty.Create(nameof(FocusedLabelTextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: Color.Gray);

        public Color FocusedLabelTextColor
        {
            get { return (Color)GetValue(FocusedLabelTextColorProperty); }
            set { SetValue(FocusedLabelTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledLabelTextColorProperty =
            BindableProperty.Create(nameof(DisabledLabelTextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: Color.Gray);

        public Color DisabledLabelTextColor
        {
            get { return (Color)GetValue(DisabledLabelTextColorProperty); }
            set { SetValue(DisabledLabelTextColorProperty, value); }
        }

        public static readonly BindableProperty LabelSizeProperty =
            BindableProperty.Create(nameof(LabelSize), typeof(double), typeof(BaseMaterialFieldControl), defaultValue: Font.Default.FontSize);

        public double LabelSize
        {
            get { return (double)GetValue(LabelSizeProperty); }
            set { SetValue(LabelSizeProperty, value); }
        }

        #endregion LabelText

        #region AssistiveText

        public static readonly BindableProperty AssistiveTextProperty =
            BindableProperty.Create(nameof(AssistiveText), typeof(string), typeof(BaseMaterialFieldControl), defaultValue: null);

        public string AssistiveText
        {
            get { return (string)GetValue(AssistiveTextProperty); }
            set { SetValue(AssistiveTextProperty, value); }
        }

        public static readonly BindableProperty AssistiveTextColorProperty =
            BindableProperty.Create(nameof(AssistiveTextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: Color.Gray);

        public Color AssistiveTextColor
        {
            get { return (Color)GetValue(AssistiveTextColorProperty); }
            set { SetValue(AssistiveTextColorProperty, value); }
        }

        public static readonly BindableProperty AssistiveSizeProperty =
            BindableProperty.Create(nameof(AssistiveSize), typeof(double), typeof(BaseMaterialFieldControl), defaultValue: Font.Default.FontSize);

        public double AssistiveSize
        {
            get { return (double)GetValue(AssistiveSizeProperty); }
            set { SetValue(AssistiveSizeProperty, value); }
        }

        #endregion AssistiveText

        #region Border

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: Color.LightGray);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty FocusedBorderColorProperty =
            BindableProperty.Create(nameof(FocusedBorderColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: Color.LightGray);

        public Color FocusedBorderColor
        {
            get { return (Color)GetValue(FocusedBorderColorProperty); }
            set { SetValue(FocusedBorderColorProperty, value); }
        }

        public static readonly BindableProperty DisabledBorderColorProperty =
            BindableProperty.Create(nameof(DisabledBorderColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: Color.LightGray);

        public Color DisabledBorderColor
        {
            get { return (Color)GetValue(DisabledBorderColorProperty); }
            set { SetValue(DisabledBorderColorProperty, value); }
        }

        #endregion Border

        #region Background

        public static readonly BindableProperty FocusedBackgroundColorProperty =
            BindableProperty.Create(nameof(FocusedBackgroundColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: Color.Transparent);

        public Color FocusedBackgroundColor
        {
            get { return (Color)GetValue(FocusedBackgroundColorProperty); }
            set { SetValue(FocusedBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty DisabledBackgroundColorProperty =
            BindableProperty.Create(nameof(DisabledBackgroundColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: Color.LightGray);

        public Color DisabledBackgroundColor
        {
            get { return (Color)GetValue(DisabledBackgroundColorProperty); }
            set { SetValue(DisabledBackgroundColorProperty, value); }
        }

        #endregion Background

        #region Icons

        public static readonly BindableProperty LeadingIconProperty =
            BindableProperty.Create(nameof(LeadingIcon), typeof(string), typeof(BaseMaterialFieldControl), defaultValue: null);

        public string LeadingIcon
        {
            get { return (string)GetValue(LeadingIconProperty); }
            set { SetValue(LeadingIconProperty, value); }
        }

        public bool LeadingIconIsVisible
        {
            get { return !string.IsNullOrEmpty(this.LeadingIcon); }
        }

        public static readonly BindableProperty TrailingIconProperty =
            BindableProperty.Create(nameof(TrailingIcon), typeof(string), typeof(BaseMaterialFieldControl), defaultValue: null);

        public string TrailingIcon
        {
            get { return (string)GetValue(TrailingIconProperty); }
            set { SetValue(TrailingIconProperty, value); }
        }

        public bool TrailingIconIsVisible
        {
            get { return !string.IsNullOrEmpty(this.TrailingIcon); }
        }

        #endregion Icons

        #region Methods

        protected abstract void SetIsEnabled();

        protected abstract void SetPadding();

        protected abstract void SetTextColor();

        protected abstract void SetFontSize();

        protected abstract void SetFontFamily();

        protected abstract void SetPlaceholder();

        protected abstract void SetPlaceholderColor();

        protected abstract void SetHorizontalTextAlignment();

        protected void SetLabelTextColor(Label lblLabel)
        {
            if (IsControlEnabled)
                lblLabel.TextColor = IsControlFocused ? FocusedLabelTextColor : LabelTextColor;
            else
                lblLabel.TextColor = DisabledLabelTextColor;
        }

        private void SetBorderAndBackgroundColors(Frame frmContainer, BoxView bxvLine)
        {
            switch (Type)
            {
                case FieldTypes.Outlined:
                case FieldTypes.Filled:
                    if (IsControlEnabled)
                        frmContainer.BackgroundColor = IsControlFocused ? FocusedBackgroundColor : BackgroundColorControl;
                    else
                        frmContainer.BackgroundColor = DisabledBackgroundColor;

                    if (IsControlEnabled)
                        frmContainer.BorderColor = IsControlFocused ? FocusedBorderColor : BorderColor;
                    else
                        frmContainer.BorderColor = DisabledBorderColor;

                    bxvLine.IsVisible = false;
                    break;
                case FieldTypes.Lined:
                    frmContainer.BackgroundColor = Color.Transparent;
                    frmContainer.BorderColor = Color.Transparent;
                    bxvLine.IsVisible = true;

                    if (IsControlEnabled)
                        bxvLine.Color = IsControlFocused ? FocusedBorderColor : BorderColor;
                    else
                        bxvLine.Color = DisabledBorderColor;
                    break;
            }
        }

        protected void UpdateLayout(string propertyName, Label lblLabel, Label lblAssistive, Frame frmContainer, BoxView bxvLine, CustomImageButton imgLeadingIcon, CustomImageButton imgTrailingIcon)
        {
            switch (propertyName)
            {
                case nameof(IsEnabled):
                    SetIsEnabled();
                    SetTextColor();
                    SetLabelTextColor(lblLabel);
                    SetBorderAndBackgroundColors(frmContainer, bxvLine);
                    break;
                case nameof(TextColor):
                    SetTextColor();
                    break;
                case nameof(FontSize):
                    SetFontSize();
                    break;
                case nameof(FontFamily):
                    SetFontFamily();
                    lblLabel.FontFamily = FontFamily;
                    lblAssistive.FontFamily = FontFamily;
                    break;
                case nameof(Placeholder):
                    SetPlaceholder();
                    break;
                case nameof(PlaceholderColor):
                    SetPlaceholderColor();
                    break;
                case nameof(LabelText):
                    lblLabel.Text = LabelText;
                    lblLabel.IsVisible = !string.IsNullOrEmpty(LabelText);
                    break;
                case nameof(LabelTextColor):
                    SetLabelTextColor(lblLabel);
                    break;
                case nameof(LabelSize):
                    lblLabel.FontSize = LabelSize;
                    break;
                case nameof(Padding):
                    SetPadding();
                    break;
                case nameof(CornerRadius):
                    frmContainer.CornerRadius = Convert.ToInt32(CornerRadius);
                    break;
                case nameof(Type):
                case nameof(BackgroundColor):
                case nameof(BorderColor):
                    SetBorderAndBackgroundColors(frmContainer, bxvLine);

                    if (Type == FieldTypes.Lined)
                    {
                        frmContainer.HeightRequest = 30;

                        if (LeadingIconIsVisible)
                        {
                            lblLabel.Margin = new Thickness(36, lblLabel.Margin.Top, lblLabel.Margin.Right, 0);
                            frmContainer.Padding = new Thickness(0);
                            lblAssistive.Margin = new Thickness(36, lblAssistive.Margin.Top, lblAssistive.Margin.Right, lblAssistive.Margin.Bottom);
                            bxvLine.Margin = new Thickness(36, 0, 0, 0);
                        }
                        else
                        {
                            lblLabel.Margin = new Thickness(0, lblLabel.Margin.Top, 0, 0);
                            frmContainer.Padding = new Thickness(0);
                            lblAssistive.Margin = new Thickness(0, lblAssistive.Margin.Top, 0, lblAssistive.Margin.Bottom);
                        }
                    }
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
                case nameof(LeadingIcon):
                    if (!string.IsNullOrEmpty(LeadingIcon))
                        imgLeadingIcon.Image.Source = LeadingIcon;

                    imgLeadingIcon.IsVisible = LeadingIconIsVisible;
                    break;
                case nameof(TrailingIcon):
                    if (!string.IsNullOrEmpty(TrailingIcon))
                        imgTrailingIcon.Image.Source = TrailingIcon;

                    imgTrailingIcon.IsVisible = TrailingIconIsVisible;
                    break;

                case nameof(FieldHeightRequest):
                    frmContainer.HeightRequest = FieldHeightRequest;
                    break;

                case nameof(HorizontalTextAlignment):
                    SetHorizontalTextAlignment();
                    lblLabel.HorizontalTextAlignment = HorizontalTextAlignment;
                    lblAssistive.HorizontalTextAlignment = HorizontalTextAlignment;
                    break;
            }
        }

        protected void SetFocusChange(Label lblLabel, Frame frmContainer, BoxView bxvLine)
        {
            SetLabelTextColor(lblLabel);
            SetTextColor();
            SetBorderAndBackgroundColors(frmContainer, bxvLine);
        }

        #endregion Methods
    }
}