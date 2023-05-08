using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.ControlsMaterial3;
using Plugin.MaterialDesignControls.Material3.Implementations;
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

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: Color.Gray);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
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

        #region SupportingText

        public static readonly BindableProperty SupportingTextProperty =
            BindableProperty.Create(nameof(SupportingText), typeof(string), typeof(BaseMaterialFieldControl), defaultValue: null, validateValue: OnSupportingTextValidate);

        public string SupportingText
        {
            get { return (string)GetValue(SupportingTextProperty); }
            set { SetValue(SupportingTextProperty, value); }
        }

        public static readonly BindableProperty SupportingTextColorProperty =
            BindableProperty.Create(nameof(SupportingTextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: Color.Gray);

        public Color SupportingTextColor
        {
            get { return (Color)GetValue(SupportingTextColorProperty); }
            set { SetValue(SupportingTextColorProperty, value); }
        }

        public static readonly BindableProperty SupportingSizeProperty =
            BindableProperty.Create(nameof(SupportingSize), typeof(double), typeof(BaseMaterialFieldControl), defaultValue: Font.Default.FontSize);

        public double SupportingSize
        {
            get { return (double)GetValue(SupportingSizeProperty); }
            set { SetValue(SupportingSizeProperty, value); }
        }

        public static readonly BindableProperty SupportingFontFamilyProperty =
            BindableProperty.Create(nameof(SupportingFontFamily), typeof(string), typeof(BaseMaterialFieldControl), defaultValue: null);

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
        #endregion

        #region Border

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: Color.LightGray);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty HasBorderProperty =
            BindableProperty.Create(nameof(HasBorder), typeof(bool), typeof(BaseMaterialFieldControl), defaultValue: false);

        public bool HasBorder
        {
            get { return (bool)GetValue(HasBorderProperty); }
            set { SetValue(HasBorderProperty, value); }
        }

        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.Create(nameof(BorderWidth), typeof(float), typeof(ContentBox), 0f);

        public float BorderWidth
        {
            get { return (float)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }
        #endregion Border

        #region Indicator

        public static readonly BindableProperty IndicatorColorProperty =
            BindableProperty.Create(nameof(IndicatorColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: Color.LightGray);

        public Color IndicatorColor
        {
            get { return (Color)GetValue(IndicatorColorProperty); }
            set { SetValue(IndicatorColorProperty, value); }
        }

        #endregion Indicator

        #region Background

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialEntry), defaultValue: Color.LightGray);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
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

        public ContentBox FrameContainer => this.frmContainer;

        private static void OnCustomContentChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is BaseMaterialFieldControl control && control.contentLayout != null)
            {
                control.contentLayout.Children.Add((View)newValue);
            }
        }

        private static bool OnSupportingTextValidate(BindableObject bindable, object value)
        {
            var control = (BaseMaterialFieldControl)bindable;

            // Used to animate the error when the assistive text doesn't change
            if (control.AnimateError && !string.IsNullOrEmpty(control.SupportingText) && control.SupportingText == (string)value)
                ShakeAnimation.Animate(control);

            return true;
        }

        protected void SetLabelTextColor()
        {
            this.lblLabel.TextColor = LabelTextColor;
        }

        private void SetBorderAndBackgroundColors()
        {
            if (CustomContent == null) return;

            this.frmContainer.BackgroundColor = BackgroundColor;
            this.frmContainer.BorderColor = HasBorder ? BorderColor : Color.Transparent;
            this.indicator.Color = IndicatorColor;
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
                    CustomContent.SetIsEnabled(IsEnabled);
                    CustomContent.SetTextColor(TextColor);
                    SetLabelTextColor();
                    this.lblLabel.TextColor = LabelTextColor;
                    SetBorderAndBackgroundColors();
                    var state = IsEnabled ? "Normal" : "Disabled";
                    VisualStateManager.GoToState(this, state);
                    break;
                case nameof(TextColor):
                    CustomContent.SetTextColor(TextColor);
                    break;
                case nameof(FontSize):
                    CustomContent.SetFontSize(FontSize);
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
                    break;
                case nameof(PlaceholderColor):
                    CustomContent.SetPlaceholderColor(PlaceholderColor);
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
                    if (HasBorder)
                    {
                        this.frmContainer.CornerRadius = CornerRadius;
                    }
                    break;
                //case nameof(Type):
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

                case nameof(FieldHeightRequest):
                    this.frmContainer.HeightRequest = FieldHeightRequest;
                    break;

                case nameof(HorizontalTextAlignment):
                    CustomContent.SetHorizontalTextAlignment(HorizontalTextAlignment);
                    this.lblLabel.HorizontalTextAlignment = HorizontalTextAlignment;
                    this.lblSupporting.HorizontalTextAlignment = HorizontalTextAlignment;
                    break;

                case nameof(HasBorder):
                    SetHasBorder();
                    break;

                case nameof(BorderWidth):
                    this.frmContainer.BorderWidth = HasBorder ? BorderWidth : 0f;
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
            }
        }

        private void SetHasBorder()
        {
            indicator.IsVisible = !HasBorder;
            SetBorderAndBackgroundColors();
        }

        public void SetFocusChange()
        {
            var state = CustomContent.IsControlFocused() ? "Focused" : CustomContent.IsControlEnabled() ? "Normal" : "Disabled";
            VisualStateManager.GoToState(this, state);
            SetLabelTextColor();
            CustomContent.SetTextColor(TextColor);
            SetBorderAndBackgroundColors();
        }
        #endregion Methods
    }
}