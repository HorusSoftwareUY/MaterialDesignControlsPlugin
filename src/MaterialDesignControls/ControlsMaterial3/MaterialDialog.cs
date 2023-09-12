using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Plugin.MaterialDesignControls.Styles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3
{
    public class MaterialDialog : ContentView
    {
        #region Attributes

        private bool initialized = false;

        private MaterialCard _contentLayout;

        private CustomImage _icon;

        private MaterialLabel _headlineLbl;

        private MaterialLabel _supportingLbl;

        private MaterialDivider _divider;

        private StackLayout _btnsContainer;

        private MaterialButton _cancelBtn;

        private MaterialButton _acceptBtn;

        private MaterialSearch _materialSearch;

        private MaterialCheckbox _materialCheckBox;

        #endregion Attributes

        #region Properties

        public static new readonly BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialDialog), defaultValue: DefaultStyles.PrimaryContainerColor);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(MaterialDialog), defaultValue: 28f);

        public float CornerRadius
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty IconProperty =
            BindableProperty.Create(nameof(Icon), typeof(string), typeof(MaterialDialog), defaultValue: null);

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly BindableProperty CustomIconProperty =
            BindableProperty.Create(nameof(CustomIcon), typeof(View), typeof(MaterialDialog), defaultValue: null);

        public View CustomIcon
        {
            get { return (View)GetValue(CustomIconProperty); }
            set { SetValue(CustomIconProperty, value); }
        }

        public bool IconIsVisible => !string.IsNullOrWhiteSpace(Icon) || CustomIcon != null;

        public static readonly BindableProperty IconSizeProperty =
            BindableProperty.Create(nameof(IconSize), typeof(double), typeof(MaterialDialog), defaultValue: 24.0);

        public double IconSize
        {
            get { return (double)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }

        public static readonly BindableProperty IconAlignmentProperty =
            BindableProperty.Create(nameof(IconAlignment), typeof(LayoutOptions), typeof(MaterialDialog), defaultValue: LayoutOptions.Center);

        public LayoutOptions IconAlignment
        {
            get { return (LayoutOptions)GetValue(IconAlignmentProperty); }
            set { SetValue(IconAlignmentProperty, value); }
        }

        #endregion Properties

        #region Headline

        public static readonly BindableProperty HeadlineTextProperty =
            BindableProperty.Create(nameof(HeadlineText), typeof(string), typeof(MaterialDialog), defaultValue: null);

        public string HeadlineText
        {
            get { return (string)GetValue(HeadlineTextProperty); }
            set { SetValue(HeadlineTextProperty, value); }
        }

        public static readonly BindableProperty HeadlineAlignmentProperty =
            BindableProperty.Create(nameof(HeadlineAlignment), typeof(LayoutOptions), typeof(MaterialDialog), defaultValue: LayoutOptions.Center);

        public LayoutOptions HeadlineAlignment
        {
            get { return (LayoutOptions)GetValue(HeadlineAlignmentProperty); }
            set { SetValue(HeadlineAlignmentProperty, value); }
        }

        public static readonly BindableProperty HeadlineColorProperty =
            BindableProperty.Create(nameof(HeadlineColor), typeof(Color), typeof(MaterialDialog), defaultValue: DefaultStyles.TextColor);

        public Color HeadlineColor
        {
            get { return (Color)GetValue(HeadlineColorProperty); }
            set { SetValue(HeadlineColorProperty, value); }
        }

        public static readonly BindableProperty HeadlineFontSizeProperty =
            BindableProperty.Create(nameof(HeadlineFontSize), typeof(double), typeof(MaterialDialog), defaultValue: DefaultStyles.PhoneFontSizes.HeadlineSmall);

        public double HeadlineFontSize
        {
            get { return (double)GetValue(HeadlineFontSizeProperty); }
            set { SetValue(HeadlineFontSizeProperty, value); }
        }

        public static readonly BindableProperty HeadlineFontFamilyProperty =
            BindableProperty.Create(nameof(HeadlineFontFamily), typeof(string), typeof(MaterialDialog), defaultValue: DefaultStyles.FontFamily);

        public string HeadlineFontFamily
        {
            get { return (string)GetValue(HeadlineFontFamilyProperty); }
            set { SetValue(HeadlineFontFamilyProperty, value); }
        }

        #endregion Headline

        #region SupportingText

        public static readonly BindableProperty SupportingTextProperty =
            BindableProperty.Create(nameof(SupportingText), typeof(string), typeof(MaterialDialog), defaultValue: null);

        public string SupportingText
        {
            get { return (string)GetValue(SupportingTextProperty); }
            set { SetValue(SupportingTextProperty, value); }
        }

        public static readonly BindableProperty SupportingTextAlignmentProperty =
            BindableProperty.Create(nameof(SupportingTextAlignment), typeof(TextAlignment), typeof(MaterialDialog), defaultValue: TextAlignment.Start);

        public TextAlignment SupportingTextAlignment
        {
            get { return (TextAlignment)GetValue(SupportingTextAlignmentProperty); }
            set { SetValue(SupportingTextAlignmentProperty, value); }
        }

        public static readonly BindableProperty SupportingTextColorProperty =
            BindableProperty.Create(nameof(SupportingTextColor), typeof(Color), typeof(MaterialDialog), defaultValue: DefaultStyles.TextColor);

        public Color SupportingTextColor
        {
            get { return (Color)GetValue(SupportingTextColorProperty); }
            set { SetValue(SupportingTextColorProperty, value); }
        }

        public static readonly BindableProperty SupportingTextFontSizeProperty =
            BindableProperty.Create(nameof(SupportingTextFontSize), typeof(double), typeof(MaterialDialog), defaultValue: DefaultStyles.PhoneFontSizes.BodyMedium);

        public double SupportingTextFontSize
        {
            get { return (double)GetValue(SupportingTextFontSizeProperty); }
            set { SetValue(SupportingTextFontSizeProperty, value); }
        }

        public static readonly BindableProperty SupportingTextFontFamilyProperty =
            BindableProperty.Create(nameof(SupportingTextFontFamily), typeof(string), typeof(MaterialDialog), defaultValue: DefaultStyles.FontFamily);

        public string SupportingTextFontFamily
        {
            get { return (string)GetValue(SupportingTextFontFamilyProperty); }
            set { SetValue(SupportingTextFontFamilyProperty, value); }
        }

        #endregion SupportingText

        #region Divider
        public static readonly BindableProperty ShowDividerProperty =
            BindableProperty.Create(nameof(ShowDivider), typeof(bool), typeof(MaterialDialog), defaultValue: false);

        public bool ShowDivider
        {
            get { return (bool)GetValue(ShowDividerProperty); }
            set { SetValue(ShowDividerProperty, value); }
        }

        public static readonly BindableProperty DividerColorProperty =
            BindableProperty.Create(nameof(DividerColor), typeof(Color), typeof(MaterialDialog), defaultValue: DefaultStyles.OnPrimaryContainerColor);

        public Color DividerColor
        {
            get { return (Color)GetValue(DividerColorProperty); }
            set { SetValue(DividerColorProperty, value); }
        }

        #endregion Divider

        #region CancelButton

        public static readonly BindableProperty CancelTextProperty =
            BindableProperty.Create(nameof(CancelText), typeof(string), typeof(MaterialDialog), defaultValue: null);

        public string CancelText
        {
            get { return (string)GetValue(CancelTextProperty); }
            set { SetValue(CancelTextProperty, value); }
        }

        //TODO: check this property. If it's flat/text button always background color is transparent in materialButton
        //public static readonly BindableProperty CancelBackgroundColorProperty =
        //    BindableProperty.Create(nameof(CancelBackgroundColor), typeof(Color), typeof(MaterialDialog), defaultValue: DefaultStyles.TextColor);

        //public Color CancelBackgroundColor
        //{
        //    get { return (Color)GetValue(CancelBackgroundColorProperty); }
        //    set { SetValue(CancelBackgroundColorProperty, value); }
        //}

        public static readonly BindableProperty CancelTextColorProperty =
            BindableProperty.Create(nameof(CancelTextColor), typeof(Color), typeof(MaterialDialog), defaultValue: DefaultStyles.OnPrimaryContainerColor);

        public Color CancelTextColor
        {
            get { return (Color)GetValue(CancelTextColorProperty); }
            set { SetValue(CancelTextColorProperty, value); }
        }

        public static readonly BindableProperty CancelFontSizeProperty =
            BindableProperty.Create(nameof(CancelFontSize), typeof(double), typeof(MaterialDialog), defaultValue: DefaultStyles.PhoneFontSizes.LabelLarge);

        public double CancelFontSize
        {
            get { return (double)GetValue(CancelFontSizeProperty); }
            set { SetValue(CancelFontSizeProperty, value); }
        }

        public static readonly BindableProperty CancelFontFamilyProperty =
            BindableProperty.Create(nameof(CancelFontFamily), typeof(string), typeof(MaterialDialog), defaultValue: DefaultStyles.FontFamily);

        public string CancelFontFamily
        {
            get { return (string)GetValue(CancelFontFamilyProperty); }
            set { SetValue(CancelFontFamilyProperty, value); }
        }

        public static readonly BindableProperty CancelCommandProperty =
            BindableProperty.Create(nameof(CancelCommand), typeof(ICommand), typeof(MaterialDialog), defaultValue: null);

        public ICommand CancelCommand
        {
            get { return (ICommand)GetValue(CancelCommandProperty); }
            set { SetValue(CancelCommandProperty, value); }
        }

        public static readonly BindableProperty CancelCommandParameterProperty =
            BindableProperty.Create(nameof(CancelCommandParameter), typeof(object), typeof(MaterialDialog), defaultValue: null);

        public object CancelCommandParameter
        {
            get { return (object)GetValue(CancelCommandParameterProperty); }
            set { SetValue(CancelCommandParameterProperty, value); }
        }

        #endregion CancelButton

        #region AcceptButton

        public static readonly BindableProperty AcceptTextProperty =
            BindableProperty.Create(nameof(AcceptText), typeof(string), typeof(MaterialDialog), defaultValue: null);

        public string AcceptText
        {
            get { return (string)GetValue(AcceptTextProperty); }
            set { SetValue(AcceptTextProperty, value); }
        }

        public static readonly BindableProperty AcceptBackgroundColorProperty =
            BindableProperty.Create(nameof(AcceptBackgroundColor), typeof(Color), typeof(MaterialDialog), defaultValue: DefaultStyles.OnPrimaryContainerColor);

        public Color AcceptBackgroundColor
        {
            get { return (Color)GetValue(AcceptBackgroundColorProperty); }
            set { SetValue(AcceptBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty AcceptTextColorProperty =
            BindableProperty.Create(nameof(AcceptTextColor), typeof(Color), typeof(MaterialDialog), defaultValue: DefaultStyles.OnPrimaryColor);

        public Color AcceptTextColor
        {
            get { return (Color)GetValue(AcceptTextColorProperty); }
            set { SetValue(AcceptTextColorProperty, value); }
        }

        public static readonly BindableProperty AcceptFontSizeProperty =
            BindableProperty.Create(nameof(AcceptFontSize), typeof(double), typeof(MaterialDialog), defaultValue: DefaultStyles.PhoneFontSizes.LabelLarge);

        public double AcceptFontSize
        {
            get { return (double)GetValue(AcceptFontSizeProperty); }
            set { SetValue(AcceptFontSizeProperty, value); }
        }

        public static readonly BindableProperty AcceptFontFamilyProperty =
            BindableProperty.Create(nameof(AcceptFontFamily), typeof(string), typeof(MaterialDialog), defaultValue: DefaultStyles.FontFamily);

        public string AcceptFontFamily
        {
            get { return (string)GetValue(AcceptFontFamilyProperty); }
            set { SetValue(AcceptFontFamilyProperty, value); }
        }

        public static readonly BindableProperty AcceptCommandProperty =
            BindableProperty.Create(nameof(AcceptCommand), typeof(ICommand), typeof(MaterialDialog), defaultValue: null);

        public ICommand AcceptCommand
        {
            get { return (ICommand)GetValue(AcceptCommandProperty); }
            set { SetValue(AcceptCommandProperty, value); }
        }

        public static readonly BindableProperty AcceptCommandParameterProperty =
            BindableProperty.Create(nameof(AcceptCommandParameter), typeof(object), typeof(MaterialDialog), defaultValue: null);

        public object AcceptCommandParameter
        {
            get { return (object)GetValue(AcceptCommandParameterProperty); }
            set { SetValue(AcceptCommandParameterProperty, value); }
        }
        #endregion AcceptButton


        public static readonly BindableProperty ButtonsAlignmentProperty =
            BindableProperty.Create(nameof(ButtonsAlignment), typeof(LayoutOptions), typeof(MaterialDialog), defaultValue: LayoutOptions.End);

        public LayoutOptions ButtonsAlignment
        {
            get { return (LayoutOptions)GetValue(ButtonsAlignmentProperty); }
            set { SetValue(ButtonsAlignmentProperty, value); }
        }

        #region Search
        public static readonly BindableProperty OptionsProperty =
            BindableProperty.Create(nameof(Options), typeof(IEnumerable<string>), typeof(MaterialChipsGroup), defaultValue: null, propertyChanged: OnOptionsChanged);

        public IEnumerable<string> Options
        {
            get { return (IEnumerable<string>)GetValue(OptionsProperty); }
            set { SetValue(OptionsProperty, value); }
        }

        public static readonly BindableProperty AllowMultiselectProperty =
            BindableProperty.Create(nameof(AllowMultiselect), typeof(bool), typeof(MaterialDialog), defaultValue: false);

        public bool AllowMultiselect
        {
            get { return (bool)GetValue(AllowMultiselectProperty); }
            set { SetValue(AllowMultiselectProperty, value); }
        }

        public static readonly BindableProperty ShowSearchProperty =
            BindableProperty.Create(nameof(ShowSearch), typeof(bool), typeof(MaterialDialog), defaultValue: false);

        public bool ShowSearch
        {
            get { return (bool)GetValue(ShowSearchProperty); }
            set { SetValue(ShowSearchProperty, value); }
        }

        public static readonly BindableProperty SearchPlaceholderProperty =
            BindableProperty.Create(nameof(SearchPlaceholder), typeof(string), typeof(MaterialDialog), defaultValue: null);

        public string SearchPlaceholder
        {
            get { return (string)GetValue(SearchPlaceholderProperty); }
            set { SetValue(SearchPlaceholderProperty, value); }
        }

        public static readonly BindableProperty SearchTextAlignmentProperty =
            BindableProperty.Create(nameof(SearchTextAlignment), typeof(LayoutOptions), typeof(MaterialDialog), defaultValue: LayoutOptions.Start);

        public LayoutOptions SearchTextAlignment
        {
            get { return (LayoutOptions)GetValue(SearchTextAlignmentProperty); }
            set { SetValue(SearchTextAlignmentProperty, value); }
        }

        public static readonly BindableProperty SearchTextColorProperty =
            BindableProperty.Create(nameof(SearchTextColor), typeof(Color), typeof(MaterialDialog), defaultValue: DefaultStyles.TextColor);

        public Color SearchTextColor
        {
            get { return (Color)GetValue(SearchTextColorProperty); }
            set { SetValue(SearchTextColorProperty, value); }
        }

        public static readonly BindableProperty SearchTextFontSizeProperty =
            BindableProperty.Create(nameof(SearchTextFontSize), typeof(double), typeof(MaterialDialog), defaultValue: DefaultStyles.PhoneFontSizes.BodyMedium);

        public double SearchTextFontSize
        {
            get { return (double)GetValue(SearchTextFontSizeProperty); }
            set { SetValue(SearchTextFontSizeProperty, value); }
        }

        public static readonly BindableProperty SearchTextFontFamilyProperty =
            BindableProperty.Create(nameof(SearchTextFontFamily), typeof(string), typeof(MaterialDialog), defaultValue: DefaultStyles.FontFamily);

        public string SearchTextFontFamily
        {
            get { return (string)GetValue(SearchTextFontFamilyProperty); }
            set { SetValue(SearchTextFontFamilyProperty, value); }
        }

        #endregion Search

        #region Items
        public static readonly BindableProperty ItemTextColorProperty =
            BindableProperty.Create(nameof(ItemTextColor), typeof(Color), typeof(MaterialDialog), defaultValue: DefaultStyles.TextColor);

        public Color ItemTextColor
        {
            get { return (Color)GetValue(ItemTextColorProperty); }
            set { SetValue(ItemTextColorProperty, value); }
        }

        public static readonly BindableProperty ItemTextFontSizeProperty =
            BindableProperty.Create(nameof(ItemTextFontSize), typeof(double), typeof(MaterialDialog), defaultValue: DefaultStyles.PhoneFontSizes.BodyMedium);

        public double ItemTextFontSize
        {
            get { return (double)GetValue(ItemTextFontSizeProperty); }
            set { SetValue(ItemTextFontSizeProperty, value); }
        }

        public static readonly BindableProperty ItemTextFontFamilyProperty =
            BindableProperty.Create(nameof(ItemTextFontFamily), typeof(string), typeof(MaterialDialog), defaultValue: DefaultStyles.FontFamily);

        public string ItemTextFontFamily
        {
            get { return (string)GetValue(ItemTextFontFamilyProperty); }
            set { SetValue(ItemTextFontFamilyProperty, value); }
        }

        public static readonly BindableProperty ItemCheckboxColorProperty =
            BindableProperty.Create(nameof(ItemCheckboxColor), typeof(Color), typeof(MaterialDialog), defaultValue: DefaultStyles.PrimaryColor);

        public Color ItemCheckboxColor
        {
            get { return (Color)GetValue(ItemCheckboxColorProperty); }
            set { SetValue(ItemCheckboxColorProperty, value); }
        }

        public static readonly BindableProperty ItemCheckboxUnselectedIconProperty =
            BindableProperty.Create(nameof(ItemCheckboxUnselectedIcon), typeof(string), typeof(MaterialDialog), defaultValue: null);

        public string ItemCheckboxUnselectedIcon
        {
            get { return (string)GetValue(ItemCheckboxUnselectedIconProperty); }
            set { SetValue(ItemCheckboxUnselectedIconProperty, value); }
        }

        public static readonly BindableProperty ItemCheckboxSelectedIconProperty =
            BindableProperty.Create(nameof(ItemCheckboxSelectedIcon), typeof(string), typeof(MaterialDialog), defaultValue: null);

        public string ItemCheckboxSelectedIcon
        {
            get { return (string)GetValue(ItemCheckboxSelectedIconProperty); }
            set { SetValue(ItemCheckboxSelectedIconProperty, value); }
        }

        public static readonly BindableProperty ItemCheckboxCustomUnselectedIconProperty =
            BindableProperty.Create(nameof(ItemCheckboxCustomUnselectedIcon), typeof(DataTemplate), typeof(MaterialDialog), defaultValue: null);

        public DataTemplate ItemCheckboxCustomUnselectedIcon
        {
            get { return (DataTemplate)GetValue(ItemCheckboxCustomUnselectedIconProperty); }
            set { SetValue(ItemCheckboxCustomUnselectedIconProperty, value); }
        }

        public static readonly BindableProperty ItemCheckboxCustomSelectedIconProperty =
            BindableProperty.Create(nameof(ItemCheckboxCustomSelectedIcon), typeof(DataTemplate), typeof(MaterialDialog), defaultValue: null);

        public DataTemplate ItemCheckboxCustomSelectedIcon
        {
            get { return (DataTemplate)GetValue(ItemCheckboxCustomSelectedIconProperty); }
            set { SetValue(ItemCheckboxCustomSelectedIconProperty, value); }
        }

        public static readonly BindableProperty ItemCheckboxSizeProperty =
            BindableProperty.Create(nameof(ItemCheckboxSize), typeof(double), typeof(MaterialDialog), defaultValue: 24.0);

        public double ItemCheckboxSize
        {
            get { return (double)GetValue(ItemCheckboxSizeProperty); }
            set { SetValue(ItemCheckboxSizeProperty, value); }
        }
        #endregion Items

        #region Constructor

        public MaterialDialog()
        {
            if (!this.initialized)
            {
                this.initialized = true;
                this.Initialize();
            }
        }

        #endregion Constructor

        #region Methods

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!this.initialized)
            {
                this.initialized = true;
                this.Initialize();
            }

            switch (propertyName)
            {
                case nameof(BackgroundColor):
                    _contentLayout.BackgroundColor = BackgroundColor;
                    break;

                case nameof(CornerRadius):
                    _contentLayout.CornerRadius = CornerRadius;
                    break;

                case nameof(Icon):
                case nameof(CustomIcon):
                case nameof(IconSize):
                case nameof(IconAlignment):
                    SetIcon();
                    break;

                case nameof(HeadlineText):
                    _headlineLbl.Text = HeadlineText;
                    break;

                case nameof(HeadlineAlignment):
                    _headlineLbl.HorizontalOptions = HeadlineAlignment;
                    break;

                case nameof(HeadlineColor):
                    _headlineLbl.TextColor = HeadlineColor;
                    break;

                case nameof(HeadlineFontSize):
                    _headlineLbl.FontSize = HeadlineFontSize;
                    break;

                case nameof(HeadlineFontFamily):
                    _headlineLbl.FontFamily = HeadlineFontFamily;
                    break;

                case nameof(SupportingText):
                    _supportingLbl.Text = SupportingText;
                    break;

                case nameof(SupportingTextAlignment):
                    _supportingLbl.HorizontalTextAlignment = SupportingTextAlignment;
                    break;

                case nameof(SupportingTextColor):
                    _supportingLbl.TextColor = SupportingTextColor;
                    break;

                case nameof(SupportingTextFontSize):
                    _supportingLbl.FontSize = SupportingTextFontSize;
                    break;

                case nameof(SupportingTextFontFamily):
                    _supportingLbl.FontFamily = SupportingTextFontFamily;
                    break;

                case nameof(ShowDivider):
                    _divider.IsVisible = ShowDivider;
                    break;

                case nameof(DividerColor):
                    _divider.Color = DividerColor;
                    break;               
                
                case nameof(ButtonsAlignment):
                    _btnsContainer.HorizontalOptions = ButtonsAlignment;
                    break;

                case nameof(CancelText):
                    _cancelBtn.Text = CancelText;
                    _cancelBtn.IsVisible = !String.IsNullOrWhiteSpace(CancelText);
                    break;

                case nameof(CancelTextColor):
                    _cancelBtn.TextColor = CancelTextColor;
                    break;

                case nameof(CancelFontSize):
                    _cancelBtn.FontSize = CancelFontSize;
                    break;

                case nameof(CancelFontFamily):
                    _cancelBtn.FontFamily = CancelFontFamily;
                    break;

                case nameof(AcceptText):
                    _acceptBtn.Text = AcceptText;
                    break;

                case nameof(AcceptTextColor):
                    _acceptBtn.TextColor = AcceptTextColor;
                    break;

                case nameof(AcceptBackgroundColor):
                    _acceptBtn.BackgroundColor = AcceptBackgroundColor;
                    break;

                case nameof(AcceptFontSize):
                    _acceptBtn.FontSize = AcceptFontSize;
                    break;

                case nameof(AcceptFontFamily):
                    _acceptBtn.FontFamily = AcceptFontFamily;
                    break;

                case nameof(CancelCommand):
                    _cancelBtn.Command = CancelCommand;
                    break;

                case nameof(CancelCommandParameter):
                    _cancelBtn.CommandParameter = CancelCommandParameter;
                    break;

                case nameof(AcceptCommand):
                    _acceptBtn.Command = AcceptCommand;
                    break;

                case nameof(AcceptCommandParameter):
                    _acceptBtn.CommandParameter = AcceptCommandParameter;
                    break;

                //case nameof(IsEnabled):
                //    CustomContent.SetIsEnabled(IsEnabled);

                //    if (!IsEnabled)
                //        CustomContent.SetTextColor(DisabledTextColor);
                //    else if (CustomContent.IsControlFocused())
                //        CustomContent.SetTextColor(FocusedTextColor);
                //    else
                //        CustomContent.SetTextColor(HeadlineColor);

                //    SetLabelTextColor();
                //    this._lblLabel.TextColor = LabelTextColor;
                //    SetBorderAndBackgroundColors();
                //    break;
                //case nameof(HeadlineColor):
                //    if (!IsEnabled)
                //        CustomContent.SetTextColor(DisabledTextColor);
                //    else if (CustomContent.IsControlFocused())
                //        CustomContent.SetTextColor(FocusedTextColor);
                //    else
                //        CustomContent.SetTextColor(HeadlineColor);
                //    break;
                //case nameof(HeadlineFontFamily):
                //    CustomContent.SetFontSize(HeadlineFontFamily);
                //    SetAnimatedLabel();
                //    break;
                //case nameof(HeadlineFontFamily):
                //case nameof(LabelFontFamily):
                //case nameof(SupportingTextFontFamily):
                //    CustomContent.SetFontFamily(HeadlineFontFamily);

                //    if (LabelFontFamily != null)
                //        this._lblLabel.FontFamily = LabelFontFamily;
                //    else if (LabelFontFamily == null && HeadlineFontFamily != null)
                //        this._lblLabel.FontFamily = HeadlineFontFamily;

                //    if (SupportingTextFontFamily != null)
                //        this._lblSupporting.FontFamily = SupportingTextFontFamily;
                //    else if (SupportingTextFontFamily == null && HeadlineFontFamily != null)
                //        this._lblSupporting.FontFamily = HeadlineFontFamily;
                //    break;
                //case nameof(Placeholder):
                //    CustomContent.SetPlaceholder(Placeholder);
                //    SetAnimatedLabel();
                //    break;
                //case nameof(PlaceholderColor):
                //    CustomContent.SetPlaceholderColor(PlaceholderColor);
                //    SetAnimatedLabel();
                //    break;
                //case nameof(LabelText):
                //    this._lblLabel.Text = LabelText;
                //    this._lblLabel.IsVisible = !AnimatePlaceHolderAsLabel;
                //    SetAnimatedLabel();
                //    break;
                //case nameof(LabelTextColor):
                //    SetLabelTextColor();
                //    break;
                //case nameof(LabelSize):
                //    this._lblLabel.FontSize = LabelSize;
                //    break;
                //case nameof(LabelMargin):
                //    this._lblLabel.Margin = LabelMargin;
                //    break;
                //case nameof(Padding):
                //    _frmContainer.Padding = this.Padding;
                //    break;
                //case nameof(CornerRadius):
                //    if (HasBorder)
                //    {
                //        this._frmContainer.CornerRadius = CornerRadius;
                //    }
                //    break;
                //case nameof(BackgroundColor):
                //case nameof(BorderColor):
                //case nameof(IndicatorColor):
                //    SetBorderAndBackgroundColors();
                //    break;
                //case nameof(SupportingText):
                //    this._lblSupporting.Text = SupportingText;
                //    this._lblSupporting.IsVisible = !string.IsNullOrEmpty(SupportingText);
                //    if (AnimateError && !string.IsNullOrEmpty(SupportingText))
                //        ShakeAnimation.Animate(this);
                //    break;
                //case nameof(SupportingTextColor):
                //    this._lblSupporting.TextColor = SupportingTextColor;
                //    break;
                //case nameof(SupportingTextFontSize):
                //    this._lblSupporting.FontSize = SupportingTextFontSize;
                //    break;
                //case nameof(SupportingMargin):
                //    this._lblSupporting.Margin = SupportingMargin;
                //    break;

                //case nameof(LeadingIcon):
                //    if (!string.IsNullOrEmpty(LeadingIcon))
                //        this._leadingIconButton.SetImage(LeadingIcon);

                //    this._leadingIconButton.IsVisible = LeadingIconIsVisible;
                //    break;
                //case nameof(CustomLeadingIcon):
                //    if (CustomLeadingIcon != null)
                //        this._leadingIconButton.SetCustomImage(CustomLeadingIcon);

                //    this._leadingIconButton.IsVisible = LeadingIconIsVisible;
                //    break;

                //case nameof(LeadingIconCommandParameter):
                //    if (LeadingIconCommandParameter != null)
                //    {
                //        this._leadingIconButton.CommandParameter = LeadingIconCommandParameter;
                //    }
                //    break;

                //case nameof(LeadingIconCommand):
                //    if (LeadingIconCommand != null)
                //    {
                //        this._leadingIconButton.Command = LeadingIconCommand;
                //    }
                //    break;

                //case nameof(Icon):
                //    if (!string.IsNullOrEmpty(Icon))
                //        this._trailingIconButton.SetImage(Icon);

                //    this._trailingIconButton.IsVisible = TrailingIconIsVisible;
                //    break;
                //case nameof(CustomIcon):
                //    if (CustomIcon != null)
                //        this._trailingIconButton.SetCustomImage(CustomIcon);

                //    this._trailingIconButton.IsVisible = TrailingIconIsVisible;
                //    break;
                //case nameof(TrailingIconCommand):
                //    if (TrailingIconCommand != null)
                //    {
                //        this._trailingIconButton.Command = TrailingIconCommand;
                //    }
                //    break;

                //case nameof(TrailingIconCommandParameter):
                //    if (TrailingIconCommandParameter != null)
                //    {
                //        this._trailingIconButton.CommandParameter = TrailingIconCommandParameter;
                //    }
                //    break;

                //case nameof(HorizontalTextAlignment):
                //    CustomContent.SetHorizontalTextAlignment(HorizontalTextAlignment);
                //    this._lblLabel.HorizontalTextAlignment = HorizontalTextAlignment;
                //    this._lblSupporting.HorizontalTextAlignment = HorizontalTextAlignment;
                //    break;

                //case nameof(HasBorder):
                //    SetHasBorder();
                //    break;

                //case nameof(iOSBorderWidth):
                //    this._frmContainer.iOSBorderWidth = HasBorder ? iOSBorderWidth : 0f;
                //    break;

                //case nameof(CornerRadiusBottomLeft):
                //    if (HasBorder)
                //    {
                //        this._frmContainer.CornerRadiusBottomLeft = CornerRadiusBottomLeft;
                //    }
                //    break;

                //case nameof(CornerRadiusBottomRight):
                //    if (HasBorder)
                //    {
                //        this._frmContainer.CornerRadiusBottomRight = CornerRadiusBottomRight;
                //    }
                //    break;

                //case nameof(CornerRadiusTopRight):
                //    if (HasBorder)
                //    {
                //        this._frmContainer.CornerRadiusTopRight = CornerRadiusTopRight;
                //    }
                //    break;

                //case nameof(CornerRadiusTopLeft):
                //    if (HasBorder)
                //    {
                //        this._frmContainer.CornerRadiusTopLeft = CornerRadiusTopLeft;
                //    }
                //    break;

                //case nameof(AnimatePlaceholder):
                //    this._lblLabel.IsVisible = !AnimatePlaceHolderAsLabel;
                //    SetAnimatedLabel();
                //    break;

                //case nameof(this.LabelLineBreakMode):
                //    this._lblLabel.LineBreakMode = this.LabelLineBreakMode;
                //    break;

                //case nameof(this.SupportingLineBreakMode):
                //    this._lblSupporting.LineBreakMode = this.SupportingLineBreakMode;
                //    break;

                default:
                    base.OnPropertyChanged(propertyName);
                    break;
            }
        }


        private void Initialize()
        {
            /*
                    private StackLayout _btnsContainer;

                    private MaterialButton _cancelBtn;

                    private MaterialButton _acceptBtn;

                    private MaterialSearch _materialSearch;

                    private MaterialCheckbox _materialCheckBox;
             
             */

            var mainContainer = new StackLayout()
            {
                Spacing = 0
            };

            _contentLayout = new MaterialCard()
            {
                BackgroundColor = this.BackgroundColor,
                CornerRadiusBottomLeft = true,
                CornerRadiusBottomRight = true,
                CornerRadiusTopLeft = true,
                CornerRadiusTopRight = true,
                CornerRadius = this.CornerRadius,
                Padding = new Thickness(24)
            };

            var container = new StackLayout()
            {
                Spacing = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            _contentLayout.Content = container;

            mainContainer.Children.Add(_contentLayout);

            _icon = new CustomImage()
            {
                IsVisible = IconIsVisible,
                WidthRequest = IconSize,
                HeightRequest = IconSize,
                HorizontalOptions = IconAlignment,
                Margin = new Thickness(0, 0, 0, 16)
            };

            if(IconIsVisible)
            {
                SetIcon();
            }

            container.Children.Add(_icon);

            _headlineLbl = new MaterialLabel()
            {
                FontFamily = HeadlineFontFamily,
                FontSize = HeadlineFontSize,
                Text = HeadlineText,
                HorizontalOptions = HeadlineAlignment,
                TextColor = HeadlineColor,
                Margin = new Thickness(0, 0, 0, 16),
            };

            container.Children.Add(_headlineLbl);

            _supportingLbl = new MaterialLabel()
            {
                FontFamily = SupportingTextFontFamily,
                FontSize = SupportingTextFontSize,
                Text = SupportingText,
                HorizontalTextAlignment = SupportingTextAlignment,
                TextColor = SupportingTextColor,
                Margin = new Thickness(0, 0, 0, 16),
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            container.Children.Add(_supportingLbl);

            _divider = new MaterialDivider()
            {
                IsVisible = ShowDivider,
                Color = DividerColor
            };

            container.Children.Add(_divider);

            //TODO: options logic

            _btnsContainer = new StackLayout()
            {
                Spacing = 0,
                HorizontalOptions = ButtonsAlignment,
                Orientation = StackOrientation.Horizontal,
                Margin = new Thickness(0, 16, 0, 0)
            };

            _cancelBtn = new MaterialButton()
            {
                ButtonType = MaterialButtonType.Text,
                Text = CancelText,
                TextColor = CancelTextColor,
                FontSize = CancelFontSize,
                FontFamily = CancelFontFamily,
                Command = CancelCommand,
                CommandParameter = CancelCommandParameter,
                IsVisible = !String.IsNullOrWhiteSpace(CancelText)
            };

            _acceptBtn = new MaterialButton()
            {
                ButtonType = MaterialButtonType.Filled,
                Text = AcceptText,
                TextColor = AcceptTextColor,
                FontSize = AcceptFontSize,
                FontFamily = AcceptFontFamily,
                BackgroundColor = AcceptBackgroundColor,
                Margin = new Thickness(16, 0, 0, 0),
                Command = AcceptCommand,
                CommandParameter = AcceptCommandParameter
            };

            _btnsContainer.Children.Add(_cancelBtn);
            _btnsContainer.Children.Add(_acceptBtn);

            container.Children.Add(_btnsContainer);

            this.Content = mainContainer;
        }


        private static void OnOptionsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialChipsGroup)bindable;
            //control.flexContainer.Children.Clear();
            if (!Equals(newValue, null) && newValue is IEnumerable)
            {
                foreach (var item in (IEnumerable)newValue)
                {
                    var materialChips = new MaterialChips
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Text = item.ToString(),
                        FontSize = control.FontSize,
                        FontFamily = control.FontFamily,
                        CornerRadius = control.CornerRadius,
                        Padding = control.ChipsPadding,
                        Margin = control.ChipsMargin,
                        BackgroundColor = control.BackgroundColor,
                        TextColor = control.TextColor,
                        SelectedBackgroundColor = control.SelectedBackgroundColor,
                        SelectedTextColor = control.SelectedTextColor,
                        DisabledBackgroundColor = control.DisabledBackgroundColor,
                        DisabledTextColor = control.DisabledTextColor,
                        DisabledSelectedBackgroundColor = control.DisabledSelectedBackgroundColor,
                        DisabledSelectedTextColor = control.DisabledSelectedTextColor,
                        IsEnabled = control.IsEnabled
                    };

                    //if (control.ChipsHeightRequest != (double)ChipsHeightRequestProperty.DefaultValue)
                    //    materialChips.HeightRequest = control.ChipsHeightRequest;

                    if (control.IsMultipleSelection)
                    {
                        if (control.SelectedItems != null && control.SelectedItems.Any())
                            materialChips.IsSelected = control.SelectedItems.Contains(materialChips.Text);
                    }
                    else
                    {
                        if (control.SelectedItem != null)
                            materialChips.IsSelected = materialChips.Text.Equals(control.SelectedItem);
                    }

                    //materialChips.Command = new Command(() => SelectionCommand(control, materialChips));

                    //control.flexContainer.Children.Add(materialChips);

                    if (control.ChipsFlexLayoutPercentageBasis > 0 && control.ChipsFlexLayoutPercentageBasis <= 1)
                        FlexLayout.SetBasis(materialChips, new FlexBasis((float)control.ChipsFlexLayoutPercentageBasis, true));
                }
            }
        }

        private void SetIcon()
        {
            _icon.IsVisible = IconIsVisible;
            _icon.WidthRequest = IconSize;
            _icon.HeightRequest = IconSize;
            _icon.HorizontalOptions = IconAlignment;

            if (CustomIcon != null)
                _icon.SetCustomImage(CustomIcon);
            else
                _icon.SetImage(Icon);
        }

        #endregion Methods
    }
}
