using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Styles;
using Plugin.MaterialDesignControls.Utils;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3
{
    public abstract class BaseMaterialFieldControl : ContentView
    {
        #region Attributes

        private bool initialized = false;

        private MaterialCard _frmContainer;

        private Grid _contentLayout;

        private MaterialLabel _lblLabel;

        private MaterialLabel _lblAnimatedLabel;

        private MaterialIconButton _leadingIconButton;

        private MaterialIconButton _trailingIconButton;

        private BoxView _indicator;

        private MaterialLabel _lblSupporting;

        public MaterialCard FrameContainer => this._frmContainer;

        public IBaseMaterialFieldControl Control => this.CustomContent;

        public MaterialLabel Label => this._lblLabel;

        public MaterialLabel SupportingLabel => this._lblSupporting;

        public MaterialLabel AnimatedLabel => this._lblAnimatedLabel;

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
            BindableProperty.Create(nameof(AnimateError), typeof(bool), typeof(BaseMaterialFieldControl), defaultValue: MaterialAnimation.AnimateOnError);

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
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: MaterialColor.Text);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty FocusedTextColorProperty =
            BindableProperty.Create(nameof(FocusedTextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: MaterialColor.Text);

        public Color FocusedTextColor
        {
            get { return (Color)GetValue(FocusedTextColorProperty); }
            set { SetValue(FocusedTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledTextColorProperty =
            BindableProperty.Create(nameof(DisabledTextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: MaterialColor.Disable);

        public Color DisabledTextColor
        {
            get { return (Color)GetValue(DisabledTextColorProperty); }
            set { SetValue(DisabledTextColorProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(BaseMaterialFieldControl), defaultValue: MaterialFontSize.BodyLarge);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(BaseMaterialFieldControl), defaultValue: MaterialFontFamily.Default);

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
            BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: MaterialColor.OnSurfaceVariant);

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
            BindableProperty.Create(nameof(LabelTextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: MaterialColor.OnSurfaceVariant);

        public Color LabelTextColor
        {
            get { return (Color)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public static readonly BindableProperty FocusedLabelTextColorProperty =
            BindableProperty.Create(nameof(FocusedLabelTextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: MaterialColor.Primary);

        public Color FocusedLabelTextColor
        {
            get { return (Color)GetValue(FocusedLabelTextColorProperty); }
            set { SetValue(FocusedLabelTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledLabelTextColorProperty =
            BindableProperty.Create(nameof(DisabledLabelTextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: MaterialColor.OnSurfaceVariant);

        public Color DisabledLabelTextColor
        {
            get { return (Color)GetValue(DisabledLabelTextColorProperty); }
            set { SetValue(DisabledLabelTextColorProperty, value); }
        }

        public static readonly BindableProperty LabelSizeProperty =
            BindableProperty.Create(nameof(LabelSize), typeof(double), typeof(BaseMaterialFieldControl), defaultValue: MaterialFontSize.BodySmall);

        public double LabelSize
        {
            get { return (double)GetValue(LabelSizeProperty); }
            set { SetValue(LabelSizeProperty, value); }
        }

        public static readonly BindableProperty LabelFontFamilyProperty =
            BindableProperty.Create(nameof(LabelFontFamily), typeof(string), typeof(BaseMaterialFieldControl), defaultValue: MaterialFontFamily.Default);

        public string LabelFontFamily
        {
            get { return (string)GetValue(LabelFontFamilyProperty); }
            set { SetValue(LabelFontFamilyProperty, value); }
        }

        public static readonly BindableProperty LabelMarginProperty =
            BindableProperty.Create(nameof(LabelMargin), typeof(Thickness), typeof(BaseMaterialFieldControl), defaultValue: new Thickness(0));

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
            BindableProperty.Create(nameof(SupportingTextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: MaterialColor.Error);

        public Color SupportingTextColor
        {
            get { return (Color)GetValue(SupportingTextColorProperty); }
            set { SetValue(SupportingTextColorProperty, value); }
        }

        public static readonly BindableProperty SupportingSizeProperty =
            BindableProperty.Create(nameof(SupportingSize), typeof(double), typeof(BaseMaterialFieldControl), defaultValue: MaterialFontSize.BodySmall);

        public double SupportingSize
        {
            get { return (double)GetValue(SupportingSizeProperty); }
            set { SetValue(SupportingSizeProperty, value); }
        }

        public static readonly BindableProperty SupportingFontFamilyProperty =
            BindableProperty.Create(nameof(SupportingFontFamily), typeof(string), typeof(BaseMaterialFieldControl), defaultValue: MaterialFontFamily.Default);

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
            BindableProperty.Create(nameof(CornerRadius), typeof(CornerRadius), typeof(BaseMaterialFieldControl), defaultValue: new CornerRadius(0));

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        #endregion CornerRadius

        #region Border

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: MaterialColor.OnSurfaceVariant);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty FocusedBorderColorProperty =
            BindableProperty.Create(nameof(FocusedBorderColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: MaterialColor.Primary);

        public Color FocusedBorderColor
        {
            get { return (Color)GetValue(FocusedBorderColorProperty); }
            set { SetValue(FocusedBorderColorProperty, value); }
        }

        public static readonly BindableProperty DisabledBorderColorProperty =
            BindableProperty.Create(nameof(DisabledBorderColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: MaterialColor.Disable);

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

        public static readonly BindableProperty BorderWidthProperty =
            BindableProperty.Create(nameof(BorderWidth), typeof(float), typeof(BaseMaterialFieldControl), 1f);

        public float BorderWidth
        {
            get { return (float)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        #endregion Border

        #region Indicator

        public static readonly BindableProperty IndicatorColorProperty =
            BindableProperty.Create(nameof(IndicatorColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: MaterialColor.OnSurfaceVariant);

        public Color IndicatorColor
        {
            get { return (Color)GetValue(IndicatorColorProperty); }
            set { SetValue(IndicatorColorProperty, value); }
        }

        public static readonly BindableProperty FocusedIndicatorColorProperty =
            BindableProperty.Create(nameof(FocusedIndicatorColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: MaterialColor.Primary);

        public Color FocusedIndicatorColor
        {
            get { return (Color)GetValue(FocusedIndicatorColorProperty); }
            set { SetValue(FocusedIndicatorColorProperty, value); }
        }

        public static readonly BindableProperty DisabledIndicatorColorProperty =
            BindableProperty.Create(nameof(DisabledIndicatorColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: MaterialColor.Disable);

        public Color DisabledIndicatorColor
        {
            get { return (Color)GetValue(DisabledIndicatorColorProperty); }
            set { SetValue(DisabledIndicatorColorProperty, value); }
        }

        #endregion Indicator

        #region Background

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: MaterialColor.SurfaceContainerHighest);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty FocusedBackgroundColorProperty =
            BindableProperty.Create(nameof(FocusedBackgroundColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: MaterialColor.SurfaceContainerHighest);

        public Color FocusedBackgroundColor
        {
            get { return (Color)GetValue(FocusedBackgroundColorProperty); }
            set { SetValue(FocusedBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty DisabledBackgroundColorProperty =
            BindableProperty.Create(nameof(DisabledBackgroundColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: MaterialColor.DisableContainer);

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
            }

            //Set by default Trailing and Leading command to focus control
            this._leadingIconButton.Command = new Command(() =>
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

            this._trailingIconButton.Command = new Command(() =>
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
            if (bindable is BaseMaterialFieldControl control && control._contentLayout != null)
            {
                control._contentLayout.Children.Add((View)newValue);

                if (control is MaterialEditor)
                {
                    control._contentLayout.RowDefinitions[1].Height = GridLength.Auto;
                }

                control.InitializeDefaults();
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
                _lblLabel.TextColor = DisabledLabelTextColor;
            else if (CustomContent.IsControlFocused())
                _lblLabel.TextColor = FocusedLabelTextColor;
            else
                _lblLabel.TextColor = LabelTextColor;
        }

        private void SetBorderAndBackgroundColors()
        {
            if (CustomContent == null) return;

            if (!IsEnabled)
            {
                _frmContainer.BackgroundColor = DisabledBackgroundColor;
                _frmContainer.BorderColor = HasBorder ? DisabledBorderColor : Color.Transparent;
                _indicator.Color = DisabledIndicatorColor;
            }
            else if (CustomContent.IsControlFocused())
            {
                _frmContainer.BackgroundColor = FocusedBackgroundColor;
                _frmContainer.BorderColor = HasBorder ? FocusedBorderColor : Color.Transparent;
                _indicator.Color = FocusedIndicatorColor;
            }
            else
            {
                _frmContainer.BackgroundColor = BackgroundColor;
                _frmContainer.BorderColor = HasBorder ? BorderColor : Color.Transparent;
                _indicator.Color = IndicatorColor;
            }

            _frmContainer.HasBorder = HasBorder;
            _frmContainer.BorderWidth = HasBorder ? BorderWidth : 0f;
        }

        public void UpdateLayout(string propertyName)
        {
            if (!this.initialized)
            {
                this.initialized = true;
                this.Initialize();
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
                    this._lblLabel.TextColor = LabelTextColor;
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
                        this._lblLabel.FontFamily = LabelFontFamily;
                    else if (LabelFontFamily == null && FontFamily != null)
                        this._lblLabel.FontFamily = FontFamily;

                    if (SupportingFontFamily != null)
                        this._lblSupporting.FontFamily = SupportingFontFamily;
                    else if (SupportingFontFamily == null && FontFamily != null)
                        this._lblSupporting.FontFamily = FontFamily;
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
                    this._lblLabel.Text = LabelText;
                    this._lblLabel.IsVisible = !AnimatePlaceHolderAsLabel;
                    SetAnimatedLabel();
                    break;
                case nameof(LabelTextColor):
                    SetLabelTextColor();
                    break;
                case nameof(LabelSize):
                    this._lblLabel.FontSize = LabelSize;
                    break;
                case nameof(LabelMargin):
                    this._lblLabel.Margin = LabelMargin;
                    break;
                case nameof(Padding):
                    _frmContainer.Padding = this.Padding;
                    break;
                case nameof(CornerRadius):
                    this._frmContainer.CornerRadius = CornerRadius;
                    break;
                case nameof(BackgroundColor):
                case nameof(BorderColor):
                case nameof(IndicatorColor):
                    SetBorderAndBackgroundColors();
                    break;
                case nameof(SupportingText):
                    this._lblSupporting.Text = SupportingText;
                    this._lblSupporting.IsVisible = !string.IsNullOrEmpty(SupportingText);
                    if (AnimateError && !string.IsNullOrEmpty(SupportingText))
                        ShakeAnimation.Animate(this);
                    break;
                case nameof(SupportingTextColor):
                    this._lblSupporting.TextColor = SupportingTextColor;
                    break;
                case nameof(SupportingSize):
                    this._lblSupporting.FontSize = SupportingSize;
                    break;
                case nameof(SupportingMargin):
                    this._lblSupporting.Margin = SupportingMargin;
                    break;

                case nameof(LeadingIcon):
                    if (!string.IsNullOrEmpty(LeadingIcon))
                        this._leadingIconButton.SetImage(LeadingIcon);

                    this._leadingIconButton.IsVisible = LeadingIconIsVisible;
                    break;
                case nameof(CustomLeadingIcon):
                    if (CustomLeadingIcon != null)
                        this._leadingIconButton.SetCustomImage(CustomLeadingIcon);

                    this._leadingIconButton.IsVisible = LeadingIconIsVisible;
                    break;

                case nameof(LeadingIconCommandParameter):
                    if (LeadingIconCommandParameter != null)
                    {
                        this._leadingIconButton.CommandParameter = LeadingIconCommandParameter;
                    }
                    break;

                case nameof(LeadingIconCommand):
                    if (LeadingIconCommand != null)
                    {
                        this._leadingIconButton.Command = LeadingIconCommand;
                    }
                    break;

                case nameof(TrailingIcon):
                    if (!string.IsNullOrEmpty(TrailingIcon))
                        this._trailingIconButton.SetImage(TrailingIcon);

                    this._trailingIconButton.IsVisible = TrailingIconIsVisible;
                    break;
                case nameof(CustomTrailingIcon):
                    if (CustomTrailingIcon != null)
                        this._trailingIconButton.SetCustomImage(CustomTrailingIcon);

                    this._trailingIconButton.IsVisible = TrailingIconIsVisible;
                    break;
                case nameof(TrailingIconCommand):
                    if (TrailingIconCommand != null)
                    {
                        this._trailingIconButton.Command = TrailingIconCommand;
                    }
                    break;

                case nameof(TrailingIconCommandParameter):
                    if (TrailingIconCommandParameter != null)
                    {
                        this._trailingIconButton.CommandParameter = TrailingIconCommandParameter;
                    }
                    break;

                case nameof(HorizontalTextAlignment):
                    CustomContent.SetHorizontalTextAlignment(HorizontalTextAlignment);
                    this._lblLabel.HorizontalTextAlignment = HorizontalTextAlignment;
                    this._lblSupporting.HorizontalTextAlignment = HorizontalTextAlignment;
                    break;

                case nameof(HasBorder):
                    SetHasBorder();
                    break;

                case nameof(BorderWidth):
                    this._frmContainer.BorderWidth = HasBorder ? BorderWidth : 0f;
                    break;

                case nameof(AnimatePlaceholder):
                    this._lblLabel.IsVisible = !AnimatePlaceHolderAsLabel;
                    SetAnimatedLabel();
                    break;

                case nameof(this.LabelLineBreakMode):
                    this._lblLabel.LineBreakMode = this.LabelLineBreakMode;
                    break;

                case nameof(this.SupportingLineBreakMode):
                    this._lblSupporting.LineBreakMode = this.SupportingLineBreakMode;
                    break;
            }
        }

        protected virtual void Initialize()
        {
            var mainContainer = new StackLayout()
            {
                Spacing = 0
            };

            _frmContainer = new MaterialCard
            {
                CornerRadius = new CornerRadius(10, 10, 0, 0),
                HasShadow = false,
                Padding = new Thickness(16, 8),
                Type = MaterialCardType.Custom
            };

            _contentLayout = new Grid()
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

            _lblLabel = new MaterialLabel()
            {
                IsVisible = false,
                LineBreakMode = LineBreakMode.NoWrap,
                HorizontalTextAlignment = TextAlignment.Start
            };

            _lblLabel.SetValue(Grid.RowProperty, 0);
            _lblLabel.SetValue(Grid.ColumnProperty, 1);
            _lblLabel.SetValue(Grid.ColumnSpanProperty, 2);

            _lblAnimatedLabel = new MaterialLabel()
            {
                IsVisible = false,
                LineBreakMode = LineBreakMode.NoWrap,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            _lblAnimatedLabel.SetValue(Grid.RowProperty, 0);
            _lblAnimatedLabel.SetValue(Grid.ColumnProperty, 1);

            _leadingIconButton = new MaterialIconButton()
            {
                IsVisible = false,
                HorizontalOptions = LayoutOptions.Start,
                Margin = new Thickness( -4, 0, 2, 0),
                PaddingIcon = 4,
                ButtonType = MaterialIconButtonType.Standard
            };

            _leadingIconButton.SetValue(Grid.RowProperty, 0);
            _leadingIconButton.SetValue(Grid.ColumnProperty, 0);
            _leadingIconButton.SetValue(Grid.RowSpanProperty, 2);

            _trailingIconButton = new MaterialIconButton()
            {
                IsVisible = false,
                HorizontalOptions = LayoutOptions.End,
                Margin = new Thickness(2, 0, -4, 0),
                PaddingIcon = 4,
                ButtonType = MaterialIconButtonType.Standard
            };

            _trailingIconButton.SetValue(Grid.RowProperty, 0);
            _trailingIconButton.SetValue(Grid.ColumnProperty, 2);
            _trailingIconButton.SetValue(Grid.RowSpanProperty, 2);

            _contentLayout.Children.Add(_lblLabel);
            _contentLayout.Children.Add(_lblAnimatedLabel);
            _contentLayout.Children.Add(_leadingIconButton);
            _contentLayout.Children.Add(_trailingIconButton);

            _indicator = new BoxView()
            {
                HeightRequest = 1
            };

            _lblSupporting = new MaterialLabel()
            {
                IsVisible = false,
                LineBreakMode = LineBreakMode.NoWrap,
                Margin = new Thickness(16, 4, 16, 0),
                HorizontalTextAlignment = TextAlignment.Start
            };

            _frmContainer.Content = _contentLayout;

            mainContainer.Children.Add(_frmContainer);
            mainContainer.Children.Add(_indicator);
            mainContainer.Children.Add(_lblSupporting);

            InitializeDefaults();

            this.Content = mainContainer;
        }

        protected virtual void InitializeDefaults()
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
            _lblLabel.FontSize = LabelSize;
            _lblLabel.FontFamily = FontFamily;
            _lblLabel.Margin = LabelMargin;
            _lblSupporting.FontFamily = FontFamily;
            _lblSupporting.TextColor = SupportingTextColor;
            _lblSupporting.FontSize = SupportingSize;
            _lblSupporting.Margin = SupportingMargin;
        }

        private void SetHasBorder()
        {
            _indicator.IsVisible = !HasBorder;
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
