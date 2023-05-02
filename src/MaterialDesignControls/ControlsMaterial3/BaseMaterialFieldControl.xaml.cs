using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.ControlsMaterial3;
using Plugin.MaterialDesignControls.Material3.Implementations;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls.Material3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BaseMaterialFieldControl : ContentView
    {
        #region Constructor
        public BaseMaterialFieldControl()
        {
            if (!this.initialized)
            {
                this.initialized = true;
                this.InitializeComponent();
            }
        }
        #endregion

        #region Attributes

        private bool initialized = false;

        #endregion Attributes

        #region Properties

        //TODO: check this and think about future
        //public static readonly BindableProperty TypeProperty =
        //    BindableProperty.Create(nameof(Type), typeof(FieldTypes), typeof(BaseMaterialFieldControl), defaultValue: FieldTypes.Filled);

        //public FieldTypes Type
        //{
        //    get { return (FieldTypes)GetValue(TypeProperty); }
        //    set { SetValue(TypeProperty, value); }
        //}

        public static readonly BindableProperty CustomContentProperty =
            BindableProperty.Create(nameof(CustomContent), typeof(IBaseMaterialFieldControl), typeof(BaseMaterialFieldControl), defaultValue: new CustomEntry(), propertyChanged: OnCustomContentChanged);

        public IBaseMaterialFieldControl CustomContent
        {
            get { return (IBaseMaterialFieldControl)GetValue(CustomContentProperty); }
            set { SetValue(CustomContentProperty, value); }
        }

        public static readonly BindableProperty FieldHeightRequestProperty =
            BindableProperty.Create(nameof(FieldHeightRequest), typeof(double), typeof(BaseMaterialFieldControl), defaultValue: 56.0);

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
        #endregion Properties

        #region Text

        //Proposed States: Normal, Focused, Disabled, Error (Check for future)
        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: Color.Gray);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty FocusedTextColorProperty =
            BindableProperty.Create(nameof(FocusedTextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: Color.Transparent);

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
            BindableProperty.Create(nameof(FocusedLabelTextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: Color.Transparent);

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

        public static readonly BindableProperty LabelFontFamilyProperty =
            BindableProperty.Create(nameof(LabelFontFamily), typeof(string), typeof(BaseMaterialFieldControl), defaultValue: null);

        public string LabelFontFamily
        {
            get { return (string)GetValue(LabelFontFamilyProperty); }
            set { SetValue(LabelFontFamilyProperty, value); }
        }

        public static readonly BindableProperty LabelMarginProperty =
            BindableProperty.Create(nameof(LabelMargin), typeof(Thickness), typeof(BaseMaterialFieldControl), defaultValue: new Thickness(16, 0, 16, 0));

        public Thickness LabelMargin
        {
            get { return (Thickness)GetValue(LabelMarginProperty); }
            set { SetValue(LabelMarginProperty, value); }
        }

        #endregion LabelText

        #region AssistiveText

        public static readonly BindableProperty AssistiveTextProperty =
            BindableProperty.Create(nameof(AssistiveText), typeof(string), typeof(BaseMaterialFieldControl), defaultValue: null, validateValue: OnAssistiveTextValidate);

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

        public static readonly BindableProperty AssistiveFontFamilyProperty =
            BindableProperty.Create(nameof(AssistiveFontFamily), typeof(string), typeof(BaseMaterialFieldControl), defaultValue: null);

        public string AssistiveFontFamily
        {
            get { return (string)GetValue(AssistiveFontFamilyProperty); }
            set { SetValue(AssistiveFontFamilyProperty, value); }
        }

        public static readonly BindableProperty AssistiveMarginProperty =
            BindableProperty.Create(nameof(AssistiveMargin), typeof(Thickness), typeof(BaseMaterialFieldControl), defaultValue: new Thickness(16, 4, 16, 0));

        public Thickness AssistiveMargin
        {
            get { return (Thickness)GetValue(AssistiveMarginProperty); }
            set { SetValue(AssistiveMarginProperty, value); }
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
            BindableProperty.Create(nameof(FocusedBorderColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: Color.Transparent);

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

        public static readonly BindableProperty CustomLeadingIconProperty =
            BindableProperty.Create(nameof(CustomLeadingIcon), typeof(View), typeof(BaseMaterialFieldControl), defaultValue: null);

        public View CustomLeadingIcon
        {
            get { return (View)GetValue(CustomLeadingIconProperty); }
            set { SetValue(CustomLeadingIconProperty, value); }
        }

        public bool LeadingIconIsVisible
        {
            get { return !string.IsNullOrEmpty(LeadingIcon) || CustomLeadingIcon != null; }
        }

        public static readonly BindableProperty LeadingIconCommandProperty =
            BindableProperty.Create(nameof(LeadingIconCommand), typeof(ICommand), typeof(BaseMaterialFieldControl));

        public ICommand LeadingIconCommand
        {
            get { return (ICommand)GetValue(LeadingIconCommandProperty); }
            set { SetValue(LeadingIconCommandProperty, value); }
        }

        public static readonly BindableProperty LeadingIconCommandParameterProperty =
            BindableProperty.Create(nameof(LeadingIconCommandParameter), typeof(object), typeof(BaseMaterialFieldControl), defaultValue: null);

        public object LeadingIconCommandParameter
        {
            get { return GetValue(LeadingIconCommandParameterProperty); }
            set { SetValue(LeadingIconCommandParameterProperty, value); }
        }

        public static readonly BindableProperty TrailingIconProperty =
            BindableProperty.Create(nameof(TrailingIcon), typeof(string), typeof(BaseMaterialFieldControl), defaultValue: null);

        public string TrailingIcon
        {
            get { return (string)GetValue(TrailingIconProperty); }
            set { SetValue(TrailingIconProperty, value); }
        }

        public static readonly BindableProperty CustomTrailingIconProperty =
            BindableProperty.Create(nameof(CustomTrailingIcon), typeof(View), typeof(BaseMaterialFieldControl), defaultValue: null);

        public View CustomTrailingIcon
        {
            get { return (View)GetValue(CustomTrailingIconProperty); }
            set { SetValue(CustomTrailingIconProperty, value); }
        }

        public bool TrailingIconIsVisible
        {
            get { return !string.IsNullOrEmpty(TrailingIcon) || CustomTrailingIcon != null; }
        }

        public static readonly BindableProperty TrailingIconCommandProperty =
            BindableProperty.Create(nameof(TrailingIconCommand), typeof(ICommand), typeof(BaseMaterialFieldControl));

        public ICommand TrailingIconCommand
        {
            get { return (ICommand)GetValue(TrailingIconCommandProperty); }
            set { SetValue(TrailingIconCommandProperty, value); }
        }

        public static readonly BindableProperty TrailingIconCommandParameterProperty =
            BindableProperty.Create(nameof(TrailingIconCommandParameter), typeof(object), typeof(BaseMaterialFieldControl), defaultValue: null);

        public object TrailingIconCommandParameter
        {
            get { return GetValue(TrailingIconCommandParameterProperty); }
            set { SetValue(TrailingIconCommandParameterProperty, value); }
        }

        #endregion Icons

        #region Methods

        public Frame FrameContainer => this.frmContainer;
        
        private static void OnCustomContentChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is BaseMaterialFieldControl control && control.contentLayout != null)
            {
                control.contentLayout.Children.Add((View)newValue, 1, 0);
            }
        }

        private static bool OnAssistiveTextValidate(BindableObject bindable, object value)
        {
            var control = (BaseMaterialFieldControl)bindable;

            // Used to animate the error when the assistive text doesn't change
            if (control.AnimateError && !string.IsNullOrEmpty(control.AssistiveText) && control.AssistiveText == (string)value)
                ShakeAnimation.Animate(control);

            return true;
        }

        protected void SetLabelTextColor()
        {
            if (CustomContent == null) return;

            if (CustomContent.IsControlEnabled())
                this.lblLabel.TextColor = CustomContent.IsControlFocused() && FocusedLabelTextColor != Color.Transparent ? FocusedLabelTextColor : LabelTextColor;
            else
                this.lblLabel.TextColor = DisabledLabelTextColor;
        }

        private void SetBorderAndBackgroundColors()
        {
            if (CustomContent == null) return;

            if (CustomContent.IsControlEnabled())
                this.frmContainer.BackgroundColor = CustomContent.IsControlFocused() && FocusedBackgroundColor != Color.Transparent ? FocusedBackgroundColor : CustomContent.BackgroundColorControl();
            else
                this.frmContainer.BackgroundColor = DisabledBackgroundColor;

            if (CustomContent.IsControlEnabled())
                this.frmContainer.BorderColor = CustomContent.IsControlFocused() && FocusedBorderColor != Color.Transparent ? FocusedBorderColor : BorderColor;
            else
                this.frmContainer.BorderColor = DisabledBorderColor;

            if (CustomContent.IsControlEnabled())
                this.bxvLine.Color = CustomContent.IsControlFocused() && FocusedBorderColor != Color.Transparent ? FocusedBorderColor : BorderColor;
            else
                this.bxvLine.Color = DisabledBorderColor;
        }

        public void UpdateLayout(string propertyName)
        {
            if (!this.initialized)
            {
                this.initialized = true;
                InitializeComponent();
            }

            switch (propertyName)
            {
                case nameof(IsEnabled):
                    CustomContent.SetIsEnabled();
                    CustomContent.SetTextColor(FocusedTextColor, TextColor, DisabledTextColor);
                    SetLabelTextColor();
                    SetBorderAndBackgroundColors();
                    break;
                case nameof(TextColor):
                    CustomContent.SetTextColor(FocusedTextColor, TextColor, DisabledTextColor);
                    break;
                case nameof(FontSize):
                    CustomContent.SetFontSize();
                    break;
                case nameof(FontFamily):
                case nameof(LabelFontFamily):
                case nameof(AssistiveFontFamily):
                    CustomContent.SetFontFamily();

                    if (LabelFontFamily != null)
                        this.lblLabel.FontFamily = LabelFontFamily;
                    else if (LabelFontFamily == null && FontFamily != null)
                        this.lblLabel.FontFamily = FontFamily;

                    if (AssistiveFontFamily != null)
                        this.lblAssistive.FontFamily = AssistiveFontFamily;
                    else if (AssistiveFontFamily == null && FontFamily != null)
                        this.lblAssistive.FontFamily = FontFamily;
                    break;
                case nameof(Placeholder):
                    CustomContent.SetPlaceholder();
                    break;
                case nameof(PlaceholderColor):
                    CustomContent.SetPlaceholderColor();
                    break;
                case nameof(LabelText):
                    this.lblLabel.Text = LabelText;
                    this.lblLabel.IsVisible = !string.IsNullOrEmpty(LabelText);
                    break;
                case nameof(LabelTextColor):
                    SetLabelTextColor();
                    break;
                case nameof(LabelSize):
                    this.lblLabel.FontSize = LabelSize;
                    break;
                case nameof(LabelMargin):
                    this.lblLabel.Margin = LabelMargin;
                    break;
                case nameof(Padding):
                    frmContainer.Padding = this.Padding;
                    break;
                case nameof(CornerRadius):
                    this.frmContainer.CornerRadius = Convert.ToInt32(CornerRadius);
                    break;
                //case nameof(Type):
                case nameof(BackgroundColor):
                case nameof(BorderColor):
                    SetBorderAndBackgroundColors();
                    break;
                case nameof(AssistiveText):
                    this.lblAssistive.Text = AssistiveText;
                    this.lblAssistive.IsVisible = !string.IsNullOrEmpty(AssistiveText);
                    if (AnimateError && !string.IsNullOrEmpty(AssistiveText))
                        ShakeAnimation.Animate(this);
                    break;
                case nameof(AssistiveTextColor):
                    this.lblAssistive.TextColor = AssistiveTextColor;
                    break;
                case nameof(AssistiveSize):
                    this.lblAssistive.FontSize = AssistiveSize;
                    break;
                case nameof(AssistiveMargin):
                    this.lblAssistive.Margin = AssistiveMargin;
                    break;

                case nameof(LeadingIcon):
                    if (!string.IsNullOrEmpty(LeadingIcon))
                        this.imgLeadingIcon.SetImage(LeadingIcon);

                    this.imgLeadingIcon.IsVisible = LeadingIconIsVisible;
                    break;
                case nameof(CustomLeadingIcon):
                    if (CustomLeadingIcon != null)
                        this.imgLeadingIcon.SetCustomImage(CustomLeadingIcon);

                    this.imgLeadingIcon.IsVisible = LeadingIconIsVisible;
                    break;
                case nameof(LeadingIconCommand):
                    if (LeadingIconCommand != null)
                    {
                        this.imgLeadingIcon.Tapped = () =>
                        {
                            LeadingIconCommand?.Execute(LeadingIconCommandParameter);
                        };
                    }
                    break;

                case nameof(TrailingIcon):
                    if (!string.IsNullOrEmpty(TrailingIcon))
                        this.imgTrailingIcon.SetImage(TrailingIcon);

                    this.imgTrailingIcon.IsVisible = TrailingIconIsVisible;
                    break;
                case nameof(CustomTrailingIcon):
                    if (CustomTrailingIcon != null)
                        this.imgTrailingIcon.SetCustomImage(CustomTrailingIcon);

                    this.imgTrailingIcon.IsVisible = TrailingIconIsVisible;
                    break;
                case nameof(TrailingIconCommand):
                    if (TrailingIconCommand != null)
                    {
                        this.imgTrailingIcon.Tapped = () =>
                        {
                            TrailingIconCommand?.Execute(TrailingIconCommandParameter);
                        };
                    }
                    break;

                case nameof(FieldHeightRequest):
                    this.frmContainer.HeightRequest = FieldHeightRequest;
                    break;

                case nameof(HorizontalTextAlignment):
                    CustomContent.SetHorizontalTextAlignment();
                    this.lblLabel.HorizontalTextAlignment = HorizontalTextAlignment;
                    this.lblAssistive.HorizontalTextAlignment = HorizontalTextAlignment;
                    break;
            }
        }

        public void SetFocusChange()
        {
            SetLabelTextColor();
            CustomContent.SetTextColor(FocusedTextColor, TextColor, DisabledTextColor);
            SetBorderAndBackgroundColors();
        }

        #endregion Methods
    }
}