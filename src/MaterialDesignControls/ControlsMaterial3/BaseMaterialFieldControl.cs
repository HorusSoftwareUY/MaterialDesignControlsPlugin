using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Implementations;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Plugin.MaterialDesignControls.Styles;
using Plugin.MaterialDesignControls.Utils;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace Plugin.MaterialDesignControls.Material3
{
   
    public class BaseMaterialFieldControl : ContentView
    {
        #region Attributes

        private bool initialized = false;

        private MaterialCard frmContainer;

        private Grid contentLayout;

        private MaterialLabel lblLabel;

        private MaterialLabel lblAnimatedLabel;

        private CustomImageButton imgLeadingIcon;

        private CustomImageButton imgTrailingIcon;

        private BoxView indicator;

        private MaterialLabel lblSupporting;

        public MaterialCard FrameContainer => this.frmContainer;

        public IBaseMaterialFieldControl Control => this.CustomContent;

        public MaterialLabel Label => this.lblLabel;

        public MaterialLabel SupportingLabel => this.lblSupporting;

        public MaterialLabel AnimatedLabel => this.lblAnimatedLabel;

        public bool AnimatePlaceHolderAsLabel => this.AnimatePlaceholder && string.IsNullOrWhiteSpace(LabelText);

        public double PlaceHolderXPosition = 0;

        public double PlaceHolderYPosition = 0;

        #endregion Attributes

        #region Properties

        public static readonly BindableProperty CustomContentProperty =
            BindableProperty.Create(nameof(CustomContent), typeof(IBaseMaterialFieldControl), typeof(BaseMaterialFieldControl), defaultValue: new Implementations.CustomEntry(), propertyChanged: OnCustomContentChanged);

        public IBaseMaterialFieldControl CustomContent
        {
            get { return (IBaseMaterialFieldControl)GetValue(CustomContentProperty); }
            set { SetValue(CustomContentProperty, value); }
        }

        public static readonly BindableProperty AnimateErrorProperty =
            BindableProperty.Create(nameof(AnimateError), typeof(bool), typeof(BaseMaterialFieldControl), defaultValue: DefaultStyles.AnimateError);

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

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: DefaultStyles.TextColor);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty FocusedTextColorProperty =
            BindableProperty.Create(nameof(FocusedTextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: DefaultStyles.TextColor);

        public Color FocusedTextColor
        {
            get { return (Color)GetValue(FocusedTextColorProperty); }
            set { SetValue(FocusedTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledTextColorProperty =
            BindableProperty.Create(nameof(DisabledTextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: DefaultStyles.DisableColor);

        public Color DisabledTextColor
        {
            get { return (Color)GetValue(DisabledTextColorProperty); }
            set { SetValue(DisabledTextColorProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(BaseMaterialFieldControl), defaultValue: DefaultStyles.PhoneFontSizes.BodyLarge);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(BaseMaterialFieldControl), defaultValue: DefaultStyles.FontFamily);

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
            BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: DefaultStyles.OnSurfaceVariantColor);

        public Color PlaceholderColor
        {
            get { return (Color)GetValue(PlaceholderColorProperty); }
            set { SetValue(PlaceholderColorProperty, value); }
        }

        public static readonly BindableProperty AnimatePlaceholderProperty =
            BindableProperty.Create(nameof(AnimatePlaceholder), typeof(bool), typeof(BaseMaterialFieldControl), defaultValue: false);

        public bool AnimatePlaceholder
        {
            get { return (bool)GetValue(AnimatePlaceholderProperty); }
            set { SetValue(AnimatePlaceholderProperty, value); }
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
            BindableProperty.Create(nameof(LabelTextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: DefaultStyles.OnSurfaceVariantColor);

        public Color LabelTextColor
        {
            get { return (Color)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public static readonly BindableProperty FocusedLabelTextColorProperty =
            BindableProperty.Create(nameof(FocusedLabelTextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: DefaultStyles.PrimaryColor);

        public Color FocusedLabelTextColor
        {
            get { return (Color)GetValue(FocusedLabelTextColorProperty); }
            set { SetValue(FocusedLabelTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledLabelTextColorProperty =
            BindableProperty.Create(nameof(DisabledLabelTextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: DefaultStyles.OnSurfaceVariantColor);

        public Color DisabledLabelTextColor
        {
            get { return (Color)GetValue(DisabledLabelTextColorProperty); }
            set { SetValue(DisabledLabelTextColorProperty, value); }
        }

        public static readonly BindableProperty LabelSizeProperty =
            BindableProperty.Create(nameof(LabelSize), typeof(double), typeof(BaseMaterialFieldControl), defaultValue: DefaultStyles.PhoneFontSizes.BodySmall);

        public double LabelSize
        {
            get { return (double)GetValue(LabelSizeProperty); }
            set { SetValue(LabelSizeProperty, value); }
        }

        public static readonly BindableProperty LabelFontFamilyProperty =
            BindableProperty.Create(nameof(LabelFontFamily), typeof(string), typeof(BaseMaterialFieldControl), defaultValue: DefaultStyles.FontFamily);

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

        public static readonly BindableProperty LabelLineBreakModeProperty =
            BindableProperty.Create(nameof(LabelLineBreakMode), typeof(LineBreakMode), typeof(BaseMaterialFieldControl), defaultValue: LineBreakMode.NoWrap);

        public LineBreakMode LabelLineBreakMode
        {
            get { return (LineBreakMode)GetValue(LabelLineBreakModeProperty); }
            set { SetValue(LabelLineBreakModeProperty, value); }
        }

        #endregion LabelText

        #region SupportingText

        public static readonly BindableProperty SupportingTextProperty =
            BindableProperty.Create(nameof(SupportingText), typeof(string), typeof(BaseMaterialFieldControl), defaultValue: null, validateValue: OnSupportingTextValidate);

        public string SupportingText
        {
            get { return (string)GetValue(SupportingTextProperty); }
            set { SetValue(SupportingTextProperty, value); }
        }

        public static readonly BindableProperty SupportingTextColorProperty =
            BindableProperty.Create(nameof(SupportingTextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: DefaultStyles.ErrorColor);

        public Color SupportingTextColor
        {
            get { return (Color)GetValue(SupportingTextColorProperty); }
            set { SetValue(SupportingTextColorProperty, value); }
        }

        public static readonly BindableProperty SupportingSizeProperty =
            BindableProperty.Create(nameof(SupportingSize), typeof(double), typeof(BaseMaterialFieldControl), defaultValue: DefaultStyles.PhoneFontSizes.BodySmall);

        public double SupportingSize
        {
            get { return (double)GetValue(SupportingSizeProperty); }
            set { SetValue(SupportingSizeProperty, value); }
        }

        public static readonly BindableProperty SupportingFontFamilyProperty =
            BindableProperty.Create(nameof(SupportingFontFamily), typeof(string), typeof(BaseMaterialFieldControl), defaultValue: DefaultStyles.FontFamily);

        public string SupportingFontFamily
        {
            get { return (string)GetValue(SupportingFontFamilyProperty); }
            set { SetValue(SupportingFontFamilyProperty, value); }
        }

        public static readonly BindableProperty SupportingMarginProperty =
            BindableProperty.Create(nameof(SupportingMargin), typeof(Thickness), typeof(BaseMaterialFieldControl), defaultValue: new Thickness(16, 4, 16, 0));

        public Thickness SupportingMargin
        {
            get { return (Thickness)GetValue(SupportingMarginProperty); }
            set { SetValue(SupportingMarginProperty, value); }
        }

        public static readonly BindableProperty SupportingLineBreakModeProperty =
            BindableProperty.Create(nameof(SupportingLineBreakMode), typeof(LineBreakMode), typeof(BaseMaterialFieldControl), defaultValue: LineBreakMode.NoWrap);

        public LineBreakMode SupportingLineBreakMode
        {
            get { return (LineBreakMode)GetValue(SupportingLineBreakModeProperty); }
            set { SetValue(SupportingLineBreakModeProperty, value); }
        }

        #endregion SupportingText

        #region CornerRadius

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(BaseMaterialFieldControl), defaultValue: 0f);

        public float CornerRadius
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusTopLeftProperty =
            BindableProperty.Create(nameof(CornerRadiusTopLeft), typeof(bool), typeof(BaseMaterialFieldControl), false);

        public bool CornerRadiusTopLeft
        {
            get { return (bool)GetValue(CornerRadiusTopLeftProperty); }
            set { SetValue(CornerRadiusTopLeftProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusTopRightProperty =
            BindableProperty.Create(nameof(CornerRadiusTopRight), typeof(bool), typeof(BaseMaterialFieldControl), false);

        public bool CornerRadiusTopRight
        {
            get { return (bool)GetValue(CornerRadiusTopRightProperty); }
            set { SetValue(CornerRadiusTopRightProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusBottomRightProperty =
            BindableProperty.Create(nameof(CornerRadiusBottomRight), typeof(bool), typeof(BaseMaterialFieldControl), false);

        public bool CornerRadiusBottomRight
        {
            get { return (bool)GetValue(CornerRadiusBottomRightProperty); }
            set { SetValue(CornerRadiusBottomRightProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusBottomLeftProperty =
            BindableProperty.Create(nameof(CornerRadiusBottomLeft), typeof(bool), typeof(BaseMaterialFieldControl), false);

        public bool CornerRadiusBottomLeft
        {
            get { return (bool)GetValue(CornerRadiusBottomLeftProperty); }
            set { SetValue(CornerRadiusBottomLeftProperty, value); }
        }

        #endregion CornerRadius

        #region Border

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: DefaultStyles.OnSurfaceVariantColor);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty FocusedBorderColorProperty =
            BindableProperty.Create(nameof(FocusedBorderColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: DefaultStyles.PrimaryColor);

        public Color FocusedBorderColor
        {
            get { return (Color)GetValue(FocusedBorderColorProperty); }
            set { SetValue(FocusedBorderColorProperty, value); }
        }

        public static readonly BindableProperty DisabledBorderColorProperty =
            BindableProperty.Create(nameof(DisabledBorderColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: DefaultStyles.DisableColor);

        public Color DisabledBorderColor
        {
            get { return (Color)GetValue(DisabledBorderColorProperty); }
            set { SetValue(DisabledBorderColorProperty, value); }
        }

        public static readonly BindableProperty HasBorderProperty =
            BindableProperty.Create(nameof(HasBorder), typeof(bool), typeof(BaseMaterialFieldControl), defaultValue: false);

        public bool HasBorder
        {
            get { return (bool)GetValue(HasBorderProperty); }
            set { SetValue(HasBorderProperty, value); }
        }

        public static readonly BindableProperty iOSBorderWidthProperty =
            BindableProperty.Create(nameof(iOSBorderWidth), typeof(float), typeof(BaseMaterialFieldControl), 1f);

        public float iOSBorderWidth
        {
            get { return (float)GetValue(iOSBorderWidthProperty); }
            set { SetValue(iOSBorderWidthProperty, value); }
        }

        #endregion Border

        #region Indicator

        public static readonly BindableProperty IndicatorColorProperty =
            BindableProperty.Create(nameof(IndicatorColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: DefaultStyles.OnSurfaceVariantColor);

        public Color IndicatorColor
        {
            get { return (Color)GetValue(IndicatorColorProperty); }
            set { SetValue(IndicatorColorProperty, value); }
        }

        public static readonly BindableProperty FocusedIndicatorColorProperty =
            BindableProperty.Create(nameof(FocusedIndicatorColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: DefaultStyles.PrimaryColor);

        public Color FocusedIndicatorColor
        {
            get { return (Color)GetValue(FocusedIndicatorColorProperty); }
            set { SetValue(FocusedIndicatorColorProperty, value); }
        }

        public static readonly BindableProperty DisabledIndicatorColorProperty =
            BindableProperty.Create(nameof(DisabledIndicatorColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: DefaultStyles.DisableColor);

        public Color DisabledIndicatorColor
        {
            get { return (Color)GetValue(DisabledIndicatorColorProperty); }
            set { SetValue(DisabledIndicatorColorProperty, value); }
        }

        #endregion Indicator

        #region Background

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: DefaultStyles.SurfaceContainerHighestColor);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty FocusedBackgroundColorProperty =
            BindableProperty.Create(nameof(FocusedBackgroundColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: DefaultStyles.SurfaceContainerHighestColor);

        public Color FocusedBackgroundColor
        {
            get { return (Color)GetValue(FocusedBackgroundColorProperty); }
            set { SetValue(FocusedBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty DisabledBackgroundColorProperty =
            BindableProperty.Create(nameof(DisabledBackgroundColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: DefaultStyles.DisableContainerColor);

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

        private bool LeadingIconIsVisible
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

        private bool TrailingIconIsVisible
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

        #region Events

        public static readonly BindableProperty FocusedCommandProperty =
           BindableProperty.Create(nameof(FocusedCommand), typeof(ICommand), typeof(BaseMaterialFieldControl), defaultValue: null);

        public ICommand FocusedCommand
        {
            get { return (ICommand)GetValue(FocusedCommandProperty); }
            set { SetValue(FocusedCommandProperty, value); }
        }

        public static readonly BindableProperty UnfocusedCommandProperty =
            BindableProperty.Create(nameof(UnfocusedCommand), typeof(ICommand), typeof(BaseMaterialFieldControl), defaultValue: null);

        public ICommand UnfocusedCommand
        {
            get { return (ICommand)GetValue(UnfocusedCommandProperty); }
            set { SetValue(UnfocusedCommandProperty, value); }
        }

        #endregion Events

        #region Constructor

        public BaseMaterialFieldControl()
        {
            if (!this.initialized)
            {
                this.initialized = true;
                this.Initialize();
                InitializeDefaults();
            }

            //Set by default Trailing and Leading command to focus control
            this.imgLeadingIcon.Command = new Command(() =>
            {
                if (this is MaterialSelection materialSelection)
                {
                    if (materialSelection.IsEnabled && materialSelection.Command != null && materialSelection.Command.CanExecute(materialSelection.CommandParameter))
                    {
                        materialSelection.Command.Execute(materialSelection.CommandParameter);
                    }
                    return;
                }
                this.CustomContent.FocusControl();
            });

            this.imgTrailingIcon.Command = new Command(() =>
            {
                if (this is MaterialSelection materialSelection)
                {
                    if (materialSelection.IsEnabled && materialSelection.Command != null && materialSelection.Command.CanExecute(materialSelection.CommandParameter))
                    {
                        materialSelection.Command.Execute(materialSelection.CommandParameter);
                    }
                    return;
                }
                this.CustomContent.FocusControl();
            });
        }

        #endregion Constructor

        #region Methods

        private static void OnCustomContentChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is BaseMaterialFieldControl control && control.contentLayout != null)
            {
                control.contentLayout.Children.Add((View)newValue);

                if (control is MaterialEditor)
                {
                    control.contentLayout.RowDefinitions[1].Height = GridLength.Auto;
                }
            }
        }

        private static bool OnSupportingTextValidate(BindableObject bindable, object value)
        {
            var control = (BaseMaterialFieldControl)bindable;

            // Used to animate the error when the supporting text doesn't change
            if (control.AnimateError && !string.IsNullOrEmpty(control.SupportingText) && control.SupportingText == (string)value)
                ShakeAnimation.Animate(control);

            return true;
        }

        protected void SetLabelTextColor()
        {
            if (!IsEnabled)
                lblLabel.TextColor = DisabledLabelTextColor;
            else if (CustomContent.IsControlFocused())
                lblLabel.TextColor = FocusedLabelTextColor;
            else
                lblLabel.TextColor = LabelTextColor;
        }

        private void SetBorderAndBackgroundColors()
        {
            if (CustomContent == null) return;

            if (!IsEnabled)
            {
                frmContainer.BackgroundColor = DisabledBackgroundColor;
                frmContainer.BorderColor = HasBorder ? DisabledBorderColor : Color.Transparent;
                indicator.Color = DisabledIndicatorColor;
            }
            else if (CustomContent.IsControlFocused())
            {
                frmContainer.BackgroundColor = FocusedBackgroundColor;
                frmContainer.BorderColor = HasBorder ? FocusedBorderColor : Color.Transparent;
                indicator.Color = FocusedIndicatorColor;
            }
            else
            {
                frmContainer.BackgroundColor = BackgroundColor;
                frmContainer.BorderColor = HasBorder ? BorderColor : Color.Transparent;
                indicator.Color = IndicatorColor;
            }

            frmContainer.iOSBorderWidth = HasBorder ? iOSBorderWidth : 0f;
        }

        public void InitializeDefaults()
        {
            SetLabelTextColor();
            SetBorderAndBackgroundColors();

            if (!IsEnabled)
                CustomContent.SetTextColor(DisabledTextColor);
            else if (CustomContent.IsControlFocused())
                CustomContent.SetTextColor(FocusedTextColor);
            else
                CustomContent.SetTextColor(TextColor);

            CustomContent.SetFontSize(FontSize);
            CustomContent.SetPlaceholderColor(PlaceholderColor);
            CustomContent.SetFontFamily(FontFamily);
            SetAnimatedLabel();
            lblLabel.FontSize = LabelSize;
            lblLabel.FontFamily = FontFamily;
            lblSupporting.FontFamily = FontFamily;
            lblSupporting.TextColor = SupportingTextColor;
            lblSupporting.FontSize = SupportingSize;
        }

        public void UpdateLayout(string propertyName)
        {
            if (!this.initialized)
            {
                this.initialized = true;
                Initialize();
                InitializeDefaults();
            }

            switch (propertyName)
            {
                case nameof(IsEnabled):
                    CustomContent.SetIsEnabled(IsEnabled);

                    if (!IsEnabled)
                        CustomContent.SetTextColor(DisabledTextColor);
                    else if (CustomContent.IsControlFocused())
                        CustomContent.SetTextColor(FocusedTextColor);
                    else
                        CustomContent.SetTextColor(TextColor);

                    SetLabelTextColor();
                    this.lblLabel.TextColor = LabelTextColor;
                    SetBorderAndBackgroundColors();
                    break;
                case nameof(TextColor):
                    if (!IsEnabled)
                        CustomContent.SetTextColor(DisabledTextColor);
                    else if (CustomContent.IsControlFocused())
                        CustomContent.SetTextColor(FocusedTextColor);
                    else
                        CustomContent.SetTextColor(TextColor);
                    break;
                case nameof(FontSize):
                    CustomContent.SetFontSize(FontSize);
                    SetAnimatedLabel();
                    break;
                case nameof(FontFamily):
                case nameof(LabelFontFamily):
                case nameof(SupportingFontFamily):
                    CustomContent.SetFontFamily(FontFamily);

                    if (LabelFontFamily != null)
                        this.lblLabel.FontFamily = LabelFontFamily;
                    else if (LabelFontFamily == null && FontFamily != null)
                        this.lblLabel.FontFamily = FontFamily;

                    if (SupportingFontFamily != null)
                        this.lblSupporting.FontFamily = SupportingFontFamily;
                    else if (SupportingFontFamily == null && FontFamily != null)
                        this.lblSupporting.FontFamily = FontFamily;
                    break;
                case nameof(Placeholder):
                    CustomContent.SetPlaceholder(Placeholder);
                    SetAnimatedLabel();
                    break;
                case nameof(PlaceholderColor):
                    CustomContent.SetPlaceholderColor(PlaceholderColor);
                    SetAnimatedLabel();
                    break;
                case nameof(LabelText):
                    this.lblLabel.Text = LabelText;
                    this.lblLabel.IsVisible = !AnimatePlaceHolderAsLabel;
                    SetAnimatedLabel();
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
                    if (HasBorder)
                    {
                        this.frmContainer.CornerRadius = CornerRadius;
                    }
                    break;
                case nameof(BackgroundColor):
                case nameof(BorderColor):
                case nameof(IndicatorColor):
                    SetBorderAndBackgroundColors();
                    break;
                case nameof(SupportingText):
                    this.lblSupporting.Text = SupportingText;
                    this.lblSupporting.IsVisible = !string.IsNullOrEmpty(SupportingText);
                    if (AnimateError && !string.IsNullOrEmpty(SupportingText))
                        ShakeAnimation.Animate(this);
                    break;
                case nameof(SupportingTextColor):
                    this.lblSupporting.TextColor = SupportingTextColor;
                    break;
                case nameof(SupportingSize):
                    this.lblSupporting.FontSize = SupportingSize;
                    break;
                case nameof(SupportingMargin):
                    this.lblSupporting.Margin = SupportingMargin;
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

                case nameof(LeadingIconCommandParameter):
                    if (LeadingIconCommandParameter != null)
                    {
                        this.imgLeadingIcon.CommandParameter = LeadingIconCommandParameter;
                    }
                    break;

                case nameof(LeadingIconCommand):
                    if (LeadingIconCommand != null)
                    {
                        this.imgLeadingIcon.Command = LeadingIconCommand;
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
                        this.imgTrailingIcon.Command = TrailingIconCommand;
                    }
                    break;

                case nameof(TrailingIconCommandParameter):
                    if (TrailingIconCommandParameter != null)
                    {
                        this.imgTrailingIcon.CommandParameter = TrailingIconCommandParameter;
                    }
                    break;

                case nameof(HorizontalTextAlignment):
                    CustomContent.SetHorizontalTextAlignment(HorizontalTextAlignment);
                    this.lblLabel.HorizontalTextAlignment = HorizontalTextAlignment;
                    this.lblSupporting.HorizontalTextAlignment = HorizontalTextAlignment;
                    break;

                case nameof(HasBorder):
                    SetHasBorder();
                    break;

                case nameof(iOSBorderWidth):
                    this.frmContainer.iOSBorderWidth = HasBorder ? iOSBorderWidth : 0f;
                    break;

                case nameof(CornerRadiusBottomLeft):
                    if (HasBorder)
                    {
                        this.frmContainer.CornerRadiusBottomLeft = CornerRadiusBottomLeft;
                    }
                    break;

                case nameof(CornerRadiusBottomRight):
                    if (HasBorder)
                    {
                        this.frmContainer.CornerRadiusBottomRight = CornerRadiusBottomRight;
                    }
                    break;

                case nameof(CornerRadiusTopRight):
                    if (HasBorder)
                    {
                        this.frmContainer.CornerRadiusTopRight = CornerRadiusTopRight;
                    }
                    break;

                case nameof(CornerRadiusTopLeft):
                    if (HasBorder)
                    {
                        this.frmContainer.CornerRadiusTopLeft = CornerRadiusTopLeft;
                    }
                    break;

                case nameof(AnimatePlaceholder):
                    this.lblLabel.IsVisible = !AnimatePlaceHolderAsLabel;
                    SetAnimatedLabel();
                    break;

                case nameof(this.LabelLineBreakMode):
                    this.lblLabel.LineBreakMode = this.LabelLineBreakMode;
                    break;

                case nameof(this.SupportingLineBreakMode):
                    this.lblSupporting.LineBreakMode = this.SupportingLineBreakMode;
                    break;
            }
        }

        private void Initialize()
        {


            StackLayout mainContainer = new StackLayout()
            {
                Spacing = 0
            };

            frmContainer = new MaterialCard()
            {
                CornerRadius = 10,
                HasShadow = false,
                CornerRadiusTopLeft = true,
                CornerRadiusTopRight = true,
                Padding = new Thickness(16, 8, 16, 8)
            };

            contentLayout = new Grid()
            {
                ColumnSpacing = 0,
                RowSpacing = 0,
                RowDefinitions = new RowDefinitionCollection()
                {
                    new RowDefinition(){ Height = 16 },
                    new RowDefinition(){ Height = 24 }
                },
                ColumnDefinitions = new ColumnDefinitionCollection() 
                {
                    new ColumnDefinition(){Width = GridLength.Auto },
                    new ColumnDefinition(){Width = GridLength.Star },
                    new ColumnDefinition(){Width = GridLength.Auto }
                }
            };

            lblLabel = new MaterialLabel()
            {
                IsVisible = false,
                LineBreakMode = LineBreakMode.NoWrap,
                HorizontalTextAlignment = TextAlignment.Start                               
            };

            lblLabel.SetValue(Grid.RowProperty, 0);
            lblLabel.SetValue(Grid.ColumnProperty, 1);
            lblLabel.SetValue(Grid.ColumnSpanProperty, 2);

            lblAnimatedLabel = new MaterialLabel()
            {
                IsVisible = false,
                LineBreakMode = LineBreakMode.NoWrap,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            lblAnimatedLabel.SetValue(Grid.RowProperty, 0);
            lblAnimatedLabel.SetValue(Grid.ColumnProperty, 1);

            imgLeadingIcon = new CustomImageButton()
            {
                IsVisible = false,
                HorizontalOptions = LayoutOptions.Start,
                Margin = new Thickness( -4, 0, 16, 0),
                WidthRequest = 24,
                HeightRequest = 24
            };

            imgLeadingIcon.SetValue(Grid.RowProperty, 0);
            imgLeadingIcon.SetValue(Grid.ColumnProperty, 0);
            imgLeadingIcon.SetValue(Grid.RowSpanProperty, 2);

            imgTrailingIcon = new CustomImageButton()
            {
                IsVisible = false,
                HorizontalOptions = LayoutOptions.End,
                Margin = new Thickness(16, 0, -4, 0),
                WidthRequest = 24,
                HeightRequest = 24
            };

            imgTrailingIcon.SetValue(Grid.RowProperty, 0);
            imgTrailingIcon.SetValue(Grid.ColumnProperty, 2);
            imgTrailingIcon.SetValue(Grid.RowSpanProperty, 2);

            contentLayout.Children.Add(lblLabel);
            contentLayout.Children.Add(lblAnimatedLabel);
            contentLayout.Children.Add(imgLeadingIcon);
            contentLayout.Children.Add(imgTrailingIcon);

            indicator = new BoxView()
            {
                HeightRequest = 1
            };

            lblSupporting = new MaterialLabel()
            {
                IsVisible = false,
                LineBreakMode = LineBreakMode.NoWrap,
                Margin = new Thickness(16, 4, 16, 0),
                HorizontalTextAlignment = TextAlignment.Start
            };

            mainContainer.Children.Add(frmContainer);
            mainContainer.Children.Add(indicator);
            mainContainer.Children.Add(lblSupporting);

            this.Content = mainContainer;

        }

        private void SetHasBorder()
        {
            indicator.IsVisible = !HasBorder;
            SetBorderAndBackgroundColors();
        }

        public async Task SetFocusChange()
        {
            SetLabelTextColor();

            if (!IsEnabled)
                CustomContent.SetTextColor(DisabledTextColor);
            else if (CustomContent.IsControlFocused())
                CustomContent.SetTextColor(FocusedTextColor);
            else
                CustomContent.SetTextColor(TextColor);

            SetBorderAndBackgroundColors();

            if (CustomContent.IsControlFocused())
            {
                FocusedCommand?.Execute(null);
            }
            else
            {
                UnfocusedCommand?.Execute(null);
            }

            await AnimatePlaceholderAction();
        }

        public static string GetPropertyValue(object item, string propertyToSearch)
        {
            var properties = item.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.Name.Equals(propertyToSearch, StringComparison.InvariantCultureIgnoreCase))
                {
                    return property.GetValue(item, null).ToString();
                }
            }
            return item.ToString();
        }

        #endregion Methods

        #region AnimationPlaceHolder

        public async Task TransitionToTitle()
        {
            if (AnimatePlaceHolderAsLabel)
            {
                var t1 = AnimatedLabel.TranslateTo(Label.X, Label.Y, 200);
                var t2 = SizeTo(LabelSize);
                await Task.WhenAll(t1, t2);
                AnimatedLabel.TextColor = LabelTextColor;
                AnimatedLabel.SetValue(Grid.RowSpanProperty, 1);
            }
        }

        public async Task TransitionToPlaceholder()
        {
            if (AnimatePlaceHolderAsLabel)
            {
                AnimatedLabel.TextColor = PlaceholderColor;
                if (!IsFocused)
                {
                    AnimatedLabel.SetValue(Grid.RowSpanProperty, 2);
                }
                await SizeTo(FontSize);
            }
        }

        private Task SizeTo(double fontSize)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();

            Action<double> callback = input => { AnimatedLabel.FontSize = input; };
            double startingHeight = AnimatedLabel.FontSize;
            double endingHeight = fontSize;
            uint rate = 5;
            uint length = 200;
            Easing easing = Easing.Linear;

            AnimatedLabel.Animate("AnimateLabel", callback, startingHeight, endingHeight, rate, length, easing, (v, c) => taskCompletionSource.SetResult(c));

            return taskCompletionSource.Task;
        }

        public async Task AnimatePlaceholderAction()
        {
            bool validateIfAnimate = ValidateIfAnimatePlaceHolder();
            if (CustomContent.IsControlFocused())
            {
                if (AnimatePlaceholder && validateIfAnimate)
                {
                    await TransitionToTitle();
                }
            }
            else
            {
                if (AnimatePlaceholder && validateIfAnimate)
                {
                    await TransitionToPlaceholder();
                }
            }
        }

        private bool ValidateIfAnimatePlaceHolder()
        {
            if (CustomContent is IBaseMaterialFieldControl content)
            {
                return content.ValidateIfAnimatePlaceHolder();
            }

            return false;
        }

        public void SetAnimatedLabel()
        {
            try
            {
                if (AnimatePlaceHolderAsLabel)
                {
                    AnimatedLabel.Text = string.IsNullOrWhiteSpace(AnimatedLabel.Text) ? Placeholder : AnimatedLabel.Text;
                    AnimatedLabel.IsVisible = true;
                    AnimatedLabel.TextColor = PlaceholderColor;
                    AnimatedLabel.FontSize = FontSize;

                    AnimatedLabel.SetValue(Grid.RowSpanProperty, 2);

                    PlaceHolderXPosition = AnimatedLabel.X;
                    PlaceHolderYPosition = AnimatedLabel.Y;

                    CustomContent.SetPlaceholder("");
                    Placeholder = "";
                }
                else
                {
                    CustomContent.SetPlaceholder(Placeholder);
                    CustomContent.SetPlaceholderColor(PlaceholderColor);
                    AnimatedLabel.IsVisible = false;
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(ex);
            }
        }

        #endregion AnimationPlaceHolder
    }
}
