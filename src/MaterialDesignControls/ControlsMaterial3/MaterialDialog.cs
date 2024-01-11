using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Plugin.MaterialDesignControls.Styles;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3
{
    public class MaterialDialog : ContentView
    {
        #region Attributes

        private bool initialized = false;

        private MaterialCard _mainContainer;

        private CustomImage _icon;

        private MaterialLabel _headlineLbl;

        private MaterialLabel _supportingLbl;

        private MaterialDivider _topDivider;

        private MaterialDivider _bottomDivider;

        private StackLayout _btnsContainer;

        private MaterialButton _cancelBtn;

        private MaterialButton _acceptBtn;

        private MaterialSearch _materialSearch;

        private IEnumerable<MaterialDialogItem> _fullItems;

        private StackLayout _optionsContainer;

        #endregion Attributes

        #region Properties

        public static new readonly BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialDialog), defaultValue: MaterialColor.SurfaceContainerHighest);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty ShadowColorProperty =
            BindableProperty.Create(nameof(ShadowColor), typeof(Color), typeof(MaterialDialog), defaultValue: MaterialColor.Shadow);

        public Color ShadowColor
        {
            get { return (Color)GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }

        public static readonly BindableProperty HasShadowProperty =
            BindableProperty.Create(nameof(HasShadow), typeof(bool), typeof(MaterialDialog), defaultValue: false);

        public bool HasShadow
        {
            get { return (bool)GetValue(HasShadowProperty); }
            set { SetValue(HasShadowProperty, value); }
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

        public static readonly BindableProperty ButtonsAlignmentProperty =
            BindableProperty.Create(nameof(ButtonsAlignment), typeof(LayoutOptions), typeof(MaterialDialog), defaultValue: LayoutOptions.End);

        public LayoutOptions ButtonsAlignment
        {
            get { return (LayoutOptions)GetValue(ButtonsAlignmentProperty); }
            set { SetValue(ButtonsAlignmentProperty, value); }
        }

        #endregion Properties

        #region Headline

        public static readonly BindableProperty HeadlineTextProperty =
            BindableProperty.Create(nameof(HeadlineText), typeof(string), typeof(MaterialDialog), defaultValue: "HeadlineText");

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
            BindableProperty.Create(nameof(HeadlineColor), typeof(Color), typeof(MaterialDialog), defaultValue: MaterialColor.OnSurface);

        public Color HeadlineColor
        {
            get { return (Color)GetValue(HeadlineColorProperty); }
            set { SetValue(HeadlineColorProperty, value); }
        }

        public static readonly BindableProperty HeadlineFontSizeProperty =
            BindableProperty.Create(nameof(HeadlineFontSize), typeof(double), typeof(MaterialDialog), defaultValue: MaterialFontSize.HeadlineSmall);

        public double HeadlineFontSize
        {
            get { return (double)GetValue(HeadlineFontSizeProperty); }
            set { SetValue(HeadlineFontSizeProperty, value); }
        }

        public static readonly BindableProperty HeadlineFontFamilyProperty =
            BindableProperty.Create(nameof(HeadlineFontFamily), typeof(string), typeof(MaterialDialog), defaultValue: MaterialFontFamily.Default);

        public string HeadlineFontFamily
        {
            get { return (string)GetValue(HeadlineFontFamilyProperty); }
            set { SetValue(HeadlineFontFamilyProperty, value); }
        }

        #endregion Headline

        #region SupportingText

        public static readonly BindableProperty SupportingTextProperty =
            BindableProperty.Create(nameof(SupportingText), typeof(string), typeof(MaterialDialog), defaultValue: "SupportingText");

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
            BindableProperty.Create(nameof(SupportingTextColor), typeof(Color), typeof(MaterialDialog), defaultValue: MaterialColor.OnSurfaceVariant);

        public Color SupportingTextColor
        {
            get { return (Color)GetValue(SupportingTextColorProperty); }
            set { SetValue(SupportingTextColorProperty, value); }
        }

        public static readonly BindableProperty SupportingTextFontSizeProperty =
            BindableProperty.Create(nameof(SupportingTextFontSize), typeof(double), typeof(MaterialDialog), defaultValue: MaterialFontSize.BodyMedium);

        public double SupportingTextFontSize
        {
            get { return (double)GetValue(SupportingTextFontSizeProperty); }
            set { SetValue(SupportingTextFontSizeProperty, value); }
        }

        public static readonly BindableProperty SupportingTextFontFamilyProperty =
            BindableProperty.Create(nameof(SupportingTextFontFamily), typeof(string), typeof(MaterialDialog), defaultValue: MaterialFontFamily.Default);

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
            BindableProperty.Create(nameof(DividerColor), typeof(Color), typeof(MaterialDialog), defaultValue: MaterialColor.OutlineVariant);

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

        public static readonly BindableProperty CancelBackgroundColorProperty =
            BindableProperty.Create(nameof(CancelBackgroundColor), typeof(Color), typeof(MaterialDialog), defaultValue: Color.Transparent);

        public Color CancelBackgroundColor
        {
            get { return (Color)GetValue(CancelBackgroundColorProperty); }
            set { SetValue(CancelBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty CancelTextColorProperty =
            BindableProperty.Create(nameof(CancelTextColor), typeof(Color), typeof(MaterialDialog), defaultValue: MaterialColor.Primary);

        public Color CancelTextColor
        {
            get { return (Color)GetValue(CancelTextColorProperty); }
            set { SetValue(CancelTextColorProperty, value); }
        }

        public static readonly BindableProperty CancelFontSizeProperty =
            BindableProperty.Create(nameof(CancelFontSize), typeof(double), typeof(MaterialDialog), defaultValue: MaterialFontSize.LabelLarge);

        public double CancelFontSize
        {
            get { return (double)GetValue(CancelFontSizeProperty); }
            set { SetValue(CancelFontSizeProperty, value); }
        }

        public static readonly BindableProperty CancelFontFamilyProperty =
            BindableProperty.Create(nameof(CancelFontFamily), typeof(string), typeof(MaterialDialog), defaultValue: MaterialFontFamily.Default);

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

        public static readonly BindableProperty CancelIsVisibleProperty =
            BindableProperty.Create(nameof(CancelIsVisible), typeof(bool), typeof(MaterialDialog), defaultValue: true);

        public bool CancelIsVisible
        {
            get { return (bool)GetValue(CancelIsVisibleProperty); }
            set { SetValue(CancelIsVisibleProperty, value); }
        }

        public static readonly BindableProperty CancelIsEnabledProperty =
            BindableProperty.Create(nameof(CancelIsEnabled), typeof(bool), typeof(MaterialDialog), defaultValue: true);

        public bool CancelIsEnabled
        {
            get { return (bool)GetValue(CancelIsEnabledProperty); }
            set { SetValue(CancelIsEnabledProperty, value); }
        }

        public static readonly BindableProperty CancelIsBusyProperty =
            BindableProperty.Create(nameof(CancelIsBusy), typeof(bool), typeof(MaterialDialog), defaultValue: false);

        public bool CancelIsBusy
        {
            get { return (bool)GetValue(CancelIsBusyProperty); }
            set { SetValue(CancelIsBusyProperty, value); }
        }

        public static readonly BindableProperty CancelCornerRadiusProperty =
            BindableProperty.Create(nameof(CancelCornerRadius), typeof(float), typeof(MaterialDialog), defaultValue: 20f);

        public float CancelCornerRadius
        {
            get { return (float)GetValue(CancelCornerRadiusProperty); }
            set { SetValue(CancelCornerRadiusProperty, value); }
        }

        #endregion CancelButton

        #region AcceptButton

        public static readonly BindableProperty AcceptTextProperty =
            BindableProperty.Create(nameof(AcceptText), typeof(string), typeof(MaterialDialog), defaultValue: "OK");

        public string AcceptText
        {
            get { return (string)GetValue(AcceptTextProperty); }
            set { SetValue(AcceptTextProperty, value); }
        }

        public static readonly BindableProperty AcceptBackgroundColorProperty =
            BindableProperty.Create(nameof(AcceptBackgroundColor), typeof(Color), typeof(MaterialDialog), defaultValue: MaterialColor.Primary);

        public Color AcceptBackgroundColor
        {
            get { return (Color)GetValue(AcceptBackgroundColorProperty); }
            set { SetValue(AcceptBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty AcceptTextColorProperty =
            BindableProperty.Create(nameof(AcceptTextColor), typeof(Color), typeof(MaterialDialog), defaultValue: MaterialColor.OnPrimary);

        public Color AcceptTextColor
        {
            get { return (Color)GetValue(AcceptTextColorProperty); }
            set { SetValue(AcceptTextColorProperty, value); }
        }

        public static readonly BindableProperty AcceptFontSizeProperty =
            BindableProperty.Create(nameof(AcceptFontSize), typeof(double), typeof(MaterialDialog), defaultValue: MaterialFontSize.LabelLarge);

        public double AcceptFontSize
        {
            get { return (double)GetValue(AcceptFontSizeProperty); }
            set { SetValue(AcceptFontSizeProperty, value); }
        }

        public static readonly BindableProperty AcceptFontFamilyProperty =
            BindableProperty.Create(nameof(AcceptFontFamily), typeof(string), typeof(MaterialDialog), defaultValue: MaterialFontFamily.Default);

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

        public static readonly BindableProperty AcceptIsVisibleProperty =
            BindableProperty.Create(nameof(AcceptIsVisible), typeof(bool), typeof(MaterialDialog), defaultValue: true);

        public bool AcceptIsVisible
        {
            get { return (bool)GetValue(AcceptIsVisibleProperty); }
            set { SetValue(AcceptIsVisibleProperty, value); }
        }

        public static readonly BindableProperty AcceptIsEnabledProperty =
            BindableProperty.Create(nameof(AcceptIsEnabled), typeof(bool), typeof(MaterialDialog), defaultValue: true);

        public bool AcceptIsEnabled
        {
            get { return (bool)GetValue(AcceptIsEnabledProperty); }
            set { SetValue(AcceptIsEnabledProperty, value); }
        }

        public static readonly BindableProperty AcceptIsBusyProperty =
            BindableProperty.Create(nameof(AcceptIsBusy), typeof(bool), typeof(MaterialDialog), defaultValue: false);

        public bool AcceptIsBusy
        {
            get { return (bool)GetValue(AcceptIsBusyProperty); }
            set { SetValue(AcceptIsBusyProperty, value); }
        }

        public static readonly BindableProperty AcceptCornerRadiusProperty =
            BindableProperty.Create(nameof(AcceptCornerRadius), typeof(float), typeof(MaterialDialog), defaultValue: 20f);

        public float AcceptCornerRadius
        {
            get { return (float)GetValue(AcceptCornerRadiusProperty); }
            set { SetValue(AcceptCornerRadiusProperty, value); }
        }

        #endregion AcceptButton

        #region Search

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
            BindableProperty.Create(nameof(SearchTextAlignment), typeof(TextAlignment), typeof(MaterialDialog), defaultValue: TextAlignment.Start);

        public TextAlignment SearchTextAlignment
        {
            get { return (TextAlignment)GetValue(SearchTextAlignmentProperty); }
            set { SetValue(SearchTextAlignmentProperty, value); }
        }

        public static readonly BindableProperty SearchTextColorProperty =
            BindableProperty.Create(nameof(SearchTextColor), typeof(Color), typeof(MaterialDialog), defaultValue: MaterialColor.Text);

        public Color SearchTextColor
        {
            get { return (Color)GetValue(SearchTextColorProperty); }
            set { SetValue(SearchTextColorProperty, value); }
        }

        public static readonly BindableProperty SearchBackgroundColorProperty =
            BindableProperty.Create(nameof(SearchBackgroundColor), typeof(Color), typeof(MaterialDialog), defaultValue: MaterialColor.SurfaceContainerHighest);

        public Color SearchBackgroundColor
        {
            get { return (Color)GetValue(SearchBackgroundColorProperty); }
            set { SetValue(SearchBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty SearchTextFontSizeProperty =
            BindableProperty.Create(nameof(SearchTextFontSize), typeof(double), typeof(MaterialDialog), defaultValue: MaterialFontSize.BodyMedium);

        public double SearchTextFontSize
        {
            get { return (double)GetValue(SearchTextFontSizeProperty); }
            set { SetValue(SearchTextFontSizeProperty, value); }
        }

        public static readonly BindableProperty SearchTextFontFamilyProperty =
            BindableProperty.Create(nameof(SearchTextFontFamily), typeof(string), typeof(MaterialDialog), defaultValue: MaterialFontFamily.Default);

        public string SearchTextFontFamily
        {
            get { return (string)GetValue(SearchTextFontFamilyProperty); }
            set { SetValue(SearchTextFontFamilyProperty, value); }
        }

        #endregion Search

        #region Items

        public static readonly BindableProperty QuickSelectionCommandProperty =
            BindableProperty.Create(nameof(QuickSelectionCommand), typeof(ICommand), typeof(MaterialDialog), defaultValue: null);

        public ICommand QuickSelectionCommand
        {
            get { return (ICommand)GetValue(QuickSelectionCommandProperty); }
            set { SetValue(QuickSelectionCommandProperty, value); }
        }

        public static readonly BindableProperty AllowMultiselectProperty =
            BindableProperty.Create(nameof(AllowMultiselect), typeof(bool), typeof(MaterialDialog), defaultValue: false);

        public bool AllowMultiselect
        {
            get { return (bool)GetValue(AllowMultiselectProperty); }
            set { SetValue(AllowMultiselectProperty, value); }
        }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<MaterialDialogItem>), typeof(MaterialDialog), defaultValue: null, propertyChanged: OnItemsSourceChanged);

        public IEnumerable<MaterialDialogItem> ItemsSource
        {
            get { return (IEnumerable<MaterialDialogItem>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty ItemTextColorProperty =
            BindableProperty.Create(nameof(ItemTextColor), typeof(Color), typeof(MaterialDialog), defaultValue: MaterialColor.OnSurface);

        public Color ItemTextColor
        {
            get { return (Color)GetValue(ItemTextColorProperty); }
            set { SetValue(ItemTextColorProperty, value); }
        }

        public static readonly BindableProperty ItemTextFontSizeProperty =
            BindableProperty.Create(nameof(ItemTextFontSize), typeof(double), typeof(MaterialDialog), defaultValue: MaterialFontSize.BodyMedium);

        public double ItemTextFontSize
        {
            get { return (double)GetValue(ItemTextFontSizeProperty); }
            set { SetValue(ItemTextFontSizeProperty, value); }
        }

        public static readonly BindableProperty ItemTextFontFamilyProperty =
            BindableProperty.Create(nameof(ItemTextFontFamily), typeof(string), typeof(MaterialDialog), defaultValue: MaterialFontFamily.Default);

        public string ItemTextFontFamily
        {
            get { return (string)GetValue(ItemTextFontFamilyProperty); }
            set { SetValue(ItemTextFontFamilyProperty, value); }
        }

        public static readonly BindableProperty ItemCheckboxColorProperty =
            BindableProperty.Create(nameof(ItemCheckboxColor), typeof(Color), typeof(MaterialDialog), defaultValue: MaterialColor.Primary);

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

        public static readonly BindableProperty ItemCheckboxSpacingProperty =
            BindableProperty.Create(nameof(ItemCheckboxSpacing), typeof(double), typeof(MaterialDialog), defaultValue: 10.0);

        public double ItemCheckboxSpacing
        {
            get { return (double)GetValue(ItemCheckboxSpacingProperty); }
            set { SetValue(ItemCheckboxSpacingProperty, value); }
        }

        #endregion Items

        #region Constructor

        public MaterialDialog()
        {
            Initialize();
        }

        #endregion Constructor

        #region Methods

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            switch (propertyName)
            {
                case nameof(BackgroundColor):
                    _mainContainer.BackgroundColor = BackgroundColor;
                    break;

                case nameof(ShadowColor):
                    _mainContainer.ShadowColor = ShadowColor;
                    break;

                case nameof(HasShadow):
                    _mainContainer.HasShadow = HasShadow;
                    break;

                case nameof(CornerRadius):
                    _mainContainer.CornerRadius = CornerRadius;
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
                    _topDivider.IsVisible = ShowDivider;
                    _bottomDivider.IsVisible = ShowDivider && ItemsSource != null && ItemsSource.Any();
                    break;

                case nameof(DividerColor):
                    _topDivider.Color = DividerColor;
                    _bottomDivider.Color = DividerColor;
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

                case nameof(CancelBackgroundColor):
                    _cancelBtn.BackgroundColor = CancelBackgroundColor;
                    break;

                case nameof(CancelFontSize):
                    _cancelBtn.FontSize = CancelFontSize;
                    break;

                case nameof(CancelFontFamily):
                    _cancelBtn.FontFamily = CancelFontFamily;
                    break;

                case nameof(CancelIsVisible):
                    _cancelBtn.IsVisible = CancelIsVisible;
                    break;

                case nameof(CancelIsEnabled):
                    _cancelBtn.IsEnabled = CancelIsEnabled;
                    break;

                case nameof(CancelIsBusy):
                    _cancelBtn.IsBusy = CancelIsBusy;
                    break;

                case nameof(CancelCornerRadius):
                    _cancelBtn.CornerRadius = CancelCornerRadius;
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

                case nameof(AcceptIsVisible):
                    _acceptBtn.IsVisible = AcceptIsVisible;
                    break;

                case nameof(AcceptIsEnabled):
                    _acceptBtn.IsEnabled = AcceptIsEnabled;
                    break;

                case nameof(AcceptIsBusy):
                    _acceptBtn.IsBusy = AcceptIsBusy;
                    break;

                case nameof(AcceptCornerRadius):
                    _acceptBtn.CornerRadius = AcceptCornerRadius;
                    break;

                case nameof(CancelCommand):
                    _cancelBtn.Command = CancelCommand;
                    break;

                case nameof(AcceptCommand):
                    _acceptBtn.Command = AcceptCommand;
                    break;

                case nameof(ShowSearch):
                    _materialSearch.IsVisible = ShowSearch;
                    break;

                case nameof(SearchPlaceholder):
                    _materialSearch.Placeholder = SearchPlaceholder;
                    break;

                case nameof(SearchTextAlignment):
                    _materialSearch.HorizontalTextAlignment = SearchTextAlignment;
                    break;

                case nameof(SearchTextColor):
                    _materialSearch.TextColor = SearchTextColor;
                    break;

                case nameof(SearchBackgroundColor):
                    _materialSearch.BackgroundColor = SearchBackgroundColor;
                    break;

                case nameof(SearchTextFontSize):
                    _materialSearch.FontSize = SearchTextFontSize;
                    break;

                case nameof(SearchTextFontFamily):
                    _materialSearch.FontFamily = SearchTextFontFamily;
                    break;

                default:
                    base.OnPropertyChanged(propertyName);
                    break;
            }
        }

        private void Initialize()
        {
            if (!initialized)
            {
                var container = new StackLayout
                {
                    Spacing = 16,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };

                _mainContainer = new MaterialCard
                {
                    Type = MaterialCardType.Custom,
                    BackgroundColor = BackgroundColor,
                    CornerRadius = CornerRadius,
                    Padding = new Thickness(24),
                    IsClippedToBounds = true,
                    HasBorder = false,
                    HasShadow = HasShadow,
                    ShadowColor = ShadowColor,
                    AndroidElevation = 8f,
                    iOSShadowRadius = 5f,
                    iOSShadowOffset = new Size(4, 8),
                    Content = container
                };

                _icon = new CustomImage
                {
                    IsVisible = IconIsVisible,
                    WidthRequest = IconSize,
                    HeightRequest = IconSize,
                    HorizontalOptions = IconAlignment
                };

                if (IconIsVisible)
                    SetIcon();

                container.Children.Add(_icon);

                _headlineLbl = new MaterialLabel
                {
                    FontFamily = HeadlineFontFamily,
                    FontSize = HeadlineFontSize,
                    Text = HeadlineText,
                    HorizontalOptions = HeadlineAlignment,
                    TextColor = HeadlineColor
                };
                container.Children.Add(_headlineLbl);

                _supportingLbl = new MaterialLabel
                {
                    FontFamily = SupportingTextFontFamily,
                    FontSize = SupportingTextFontSize,
                    Text = SupportingText,
                    HorizontalTextAlignment = SupportingTextAlignment,
                    TextColor = SupportingTextColor,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                container.Children.Add(_supportingLbl);

                var stackLayoutOptions = new StackLayout
                {
                    Spacing = 0,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };

                _topDivider = new MaterialDivider
                {
                    IsVisible = ShowDivider,
                    Color = DividerColor
                };
                stackLayoutOptions.Children.Add(_topDivider);

                _materialSearch = new MaterialSearch
                {
                    IsVisible = ShowSearch,
                    Placeholder = SearchPlaceholder,
                    HorizontalTextAlignment = SearchTextAlignment,
                    TextColor = SearchTextColor,
                    BackgroundColor = SearchBackgroundColor,
                    FontSize = SearchTextFontSize,
                    FontFamily = SearchTextFontFamily,
                    Margin = new Thickness(0, 8),
                    SearchOnEveryTextChange = true,
                    SearchCommand = new Command(OnSearchCommand)
                };

                stackLayoutOptions.Children.Add(_materialSearch);

                _optionsContainer = new StackLayout
                {
                    IsVisible = false,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
                var scrollViewOptions = new ScrollView
                {
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
                scrollViewOptions.Content = _optionsContainer;
                stackLayoutOptions.Children.Add(scrollViewOptions);

                _bottomDivider = new MaterialDivider
                {
                    IsVisible = ShowDivider && ItemsSource != null && ItemsSource.Any(),
                    Color = DividerColor
                };
                stackLayoutOptions.Children.Add(_bottomDivider);

                container.Children.Add(stackLayoutOptions);

                _btnsContainer = new StackLayout
                {
                    Spacing = 8,
                    HorizontalOptions = ButtonsAlignment,
                    Orientation = StackOrientation.Horizontal,
                    Margin = new Thickness(0)
                };

                _cancelBtn = new MaterialButton
                {
                    ButtonType = MaterialButtonType.Text,
                    Text = CancelText,
                    TextColor = CancelTextColor,
                    FontSize = CancelFontSize,
                    FontFamily = CancelFontFamily,
                    BackgroundColor = CancelBackgroundColor,
                    Command = CancelCommand,
                    MinimumWidthRequest = 80,
                    CornerRadius = CancelCornerRadius,
                    IsVisible = CancelIsVisible,
                    IsEnabled = CancelIsEnabled
                };

                _acceptBtn = new MaterialButton
                {
                    ButtonType = MaterialButtonType.Filled,
                    Text = AcceptText,
                    TextColor = AcceptTextColor,
                    FontSize = AcceptFontSize,
                    FontFamily = AcceptFontFamily,
                    BackgroundColor = AcceptBackgroundColor,
                    Margin = new Thickness(0),
                    Command = AcceptCommand,
                    MinimumWidthRequest = 80,
                    CornerRadius = AcceptCornerRadius,
                    IsVisible = AcceptIsVisible,
                    IsEnabled = AcceptIsEnabled
                };

                _btnsContainer.Children.Add(_cancelBtn);
                _btnsContainer.Children.Add(_acceptBtn);

                container.Children.Add(_btnsContainer);

                Content = _mainContainer;

                initialized = true;
            }
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialDialog)bindable;
            if (!Equals(newValue, null) && newValue is IEnumerable<MaterialDialogItem> list)
                control._fullItems = new List<MaterialDialogItem>(list);
            else
                control._fullItems = null;

            control.RefreshItemList(control._fullItems);
        }

        private void RefreshItemList(IEnumerable<MaterialDialogItem> list)
        {
            _optionsContainer.Children.Clear();

            if (list != null)
            {
                foreach (var item in list)
                {
                    var materialCheckbox = new MaterialCheckbox();
                    materialCheckbox.Text = item.Text;
                    materialCheckbox.Command = new Command(() => SelectionCommand(this, materialCheckbox));
                    materialCheckbox.Color = ItemCheckboxColor;
                    materialCheckbox.TextColor = ItemTextColor;
                    materialCheckbox.FontSize = ItemTextFontSize;
                    materialCheckbox.FontFamily = ItemTextFontFamily;
                    materialCheckbox.IsEnabled = IsEnabled;
                    materialCheckbox.IconHeightRequest = ItemCheckboxSize;
                    materialCheckbox.IconWidthRequest = ItemCheckboxSize;
                    materialCheckbox.SelectedIcon = ItemCheckboxSelectedIcon;
                    materialCheckbox.UnselectedIcon = ItemCheckboxUnselectedIcon;
                    materialCheckbox.CustomSelectedIcon = ItemCheckboxCustomSelectedIcon;
                    materialCheckbox.CustomUnselectedIcon = ItemCheckboxCustomUnselectedIcon;
                    materialCheckbox.IsChecked = item.IsSelected;
                    materialCheckbox.Spacing = ItemCheckboxSpacing;
                    materialCheckbox.IsRadioButtonStyle = !AllowMultiselect;
                    _optionsContainer.Children.Add(materialCheckbox);
                }

                if (AllowMultiselect && QuickSelectionCommand == null)
                    _acceptBtn.CommandParameter = ItemsSource.Where(x => x.IsSelected).ToList();
                else
                    _acceptBtn.CommandParameter = ItemsSource.FirstOrDefault(x => x.IsSelected);
            }

            _optionsContainer.IsVisible = list != null && list.Any();
            _bottomDivider.IsVisible = ShowDivider && list != null && list.Any();
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

        private static void SelectionCommand(MaterialDialog materialDialog, MaterialCheckbox materialCheckbox)
        {
            if (materialDialog.AllowMultiselect)
            {
                var item = materialDialog.ItemsSource.FirstOrDefault(x => x.Text == materialCheckbox.Text);
                if (item != null)
                    item.IsSelected = materialCheckbox.IsChecked;

                materialDialog._acceptBtn.CommandParameter = materialDialog.ItemsSource.Where(x => x.IsSelected).ToList();
            }
            else
            {
                foreach (var checkbox in materialDialog._optionsContainer.Children)
                    ((MaterialCheckbox)checkbox).IsChecked = false;

                foreach (var item in materialDialog.ItemsSource)
                    item.IsSelected = false;

                materialCheckbox.IsChecked = true;

                var selectedItem = materialDialog.ItemsSource.FirstOrDefault(x => x.Text == materialCheckbox.Text);
                if (selectedItem != null)
                {
                    selectedItem.IsSelected = true;
                    materialDialog._acceptBtn.CommandParameter = selectedItem;

                    if (materialDialog.QuickSelectionCommand != null)
                        materialDialog.QuickSelectionCommand.Execute(selectedItem);
                }
                else
                    materialDialog._acceptBtn.CommandParameter = null;
            }
        }

        private void OnSearchCommand()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (string.IsNullOrWhiteSpace(_materialSearch.Text))
                    RefreshItemList(new List<MaterialDialogItem>(_fullItems));
                else
                {
                    var search = _fullItems.Where(x => x.Text.ToLower().Contains(_materialSearch.Text.ToLower()));
                    RefreshItemList(new List<MaterialDialogItem>(search));
                }
            });
        }

        #endregion Methods
    }
}