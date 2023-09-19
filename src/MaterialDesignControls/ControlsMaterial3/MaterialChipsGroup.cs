using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Styles;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3
{
    public partial class MaterialChipsGroup : ContentView
    {
        #region Constructors

        public MaterialChipsGroup()
        {
            if (!this.initialized)
            {
                this.initialized = true;
                this.Initialize();
            }
        }

        #endregion Constructors

        #region Attributes

        private bool initialized = false;

        private MaterialLabel _lblLabel;

        private FlexLayout _flexContainer;

        private MaterialLabel _lblSupporting;

        #endregion Attributes

        #region Properties

        public static readonly BindableProperty ToUpperProperty =
            BindableProperty.Create(nameof(ToUpper), typeof(bool), typeof(MaterialChipsGroup), defaultValue: false);

        public bool ToUpper
        {
            get { return (bool)GetValue(ToUpperProperty); }
            set { SetValue(ToUpperProperty, value); }
        }

        public static readonly new BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(MaterialChipsGroup), defaultValue: new Thickness(12, 0));

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        public static readonly BindableProperty ChipsPaddingProperty =
            BindableProperty.Create(nameof(ChipsPadding), typeof(Thickness), typeof(MaterialChipsGroup), defaultValue: new Thickness(16, 0));

        public Thickness ChipsPadding
        {
            get { return (Thickness)GetValue(ChipsPaddingProperty); }
            set { SetValue(ChipsPaddingProperty, value); }
        }

        public static readonly BindableProperty ChipsMarginProperty =
            BindableProperty.Create(nameof(ChipsMargin), typeof(Thickness), typeof(MaterialChipsGroup), defaultValue: new Thickness(6));

        public Thickness ChipsMargin
        {
            get { return (Thickness)GetValue(ChipsMarginProperty); }
            set { SetValue(ChipsMarginProperty, value); }
        }

        public static readonly BindableProperty ChipsHeightRequestProperty =
            BindableProperty.Create(nameof(ChipsHeightRequest), typeof(double), typeof(MaterialChipsGroup), defaultValue: 32.0);

        public double ChipsHeightRequest
        {
            get { return (double)GetValue(ChipsHeightRequestProperty); }
            set { SetValue(ChipsHeightRequestProperty, value); }
        }

        public static readonly BindableProperty ChipsFlexLayoutBasisPercentageProperty =
            BindableProperty.Create(nameof(ChipsFlexLayoutPercentageBasis), typeof(double), typeof(MaterialChipsGroup), defaultValue: 0.0);

        public double ChipsFlexLayoutPercentageBasis
        {
            get { return (double)GetValue(ChipsFlexLayoutBasisPercentageProperty); }
            set { SetValue(ChipsFlexLayoutBasisPercentageProperty, value); }
        }

        public static readonly new BindableProperty IsEnabledProperty =
            BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(MaterialChipsGroup), defaultValue: true);

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public static readonly BindableProperty LabelTextProperty =
            BindableProperty.Create(nameof(LabelText), typeof(string), typeof(MaterialChipsGroup), defaultValue: null);

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<string>), typeof(MaterialChipsGroup), defaultValue: null, propertyChanged: OnItemsSourceChanged);

        public IEnumerable<string> ItemsSource
        {
            get { return (IEnumerable<string>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(nameof(SelectedItem), typeof(string), typeof(MaterialChipsGroup), defaultValue: null, propertyChanged: OnSelectedItemChanged, defaultBindingMode: BindingMode.TwoWay);

        public string SelectedItem
        {
            get { return (string)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly BindableProperty SelectedItemsProperty =
            BindableProperty.Create(nameof(SelectedItems), typeof(List<string>), typeof(MaterialChipsGroup), defaultValue: null, propertyChanged: OnSelectedItemsChanged, defaultBindingMode: BindingMode.TwoWay);

        public List<string> SelectedItems
        {
            get { return (List<string>)GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        public static readonly BindableProperty SupportingTextProperty =
            BindableProperty.Create(nameof(SupportingText), typeof(string), typeof(MaterialChipsGroup), defaultValue: null, validateValue: OnSupportingTextValidate);

        public string SupportingText
        {
            get { return (string)GetValue(SupportingTextProperty); }
            set { SetValue(SupportingTextProperty, value); }
        }

        public static readonly BindableProperty LabelTextColorProperty =
            BindableProperty.Create(nameof(LabelTextColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: DefaultStyles.TextColor);

        public Color LabelTextColor
        {
            get { return (Color)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public static readonly BindableProperty SupportingTextColorProperty =
            BindableProperty.Create(nameof(SupportingTextColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: DefaultStyles.ErrorColor);

        public Color SupportingTextColor
        {
            get { return (Color)GetValue(SupportingTextColorProperty); }
            set { SetValue(SupportingTextColorProperty, value); }
        }

        public static readonly BindableProperty LabelSizeProperty =
            BindableProperty.Create(nameof(LabelSize), typeof(double), typeof(MaterialChipsGroup), defaultValue: DefaultStyles.PhoneFontSizes.BodySmall);

        public double LabelSize
        {
            get { return (double)GetValue(LabelSizeProperty); }
            set { SetValue(LabelSizeProperty, value); }
        }

        public static readonly BindableProperty SupportingSizeProperty =
            BindableProperty.Create(nameof(SupportingSize), typeof(double), typeof(MaterialChipsGroup), defaultValue: DefaultStyles.PhoneFontSizes.BodySmall);

        public double SupportingSize
        {
            get { return (double)GetValue(SupportingSizeProperty); }
            set { SetValue(SupportingSizeProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: DefaultStyles.PrimaryColor);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty SelectedTextColorProperty =
            BindableProperty.Create(nameof(SelectedTextColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: DefaultStyles.OnPrimaryColor);

        public Color SelectedTextColor
        {
            get { return (Color)GetValue(SelectedTextColorProperty); }
            set { SetValue(SelectedTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledTextColorProperty =
            BindableProperty.Create(nameof(DisabledTextColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: DefaultStyles.DisableColor);

        public Color DisabledTextColor
        {
            get { return (Color)GetValue(DisabledTextColorProperty); }
            set { SetValue(DisabledTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledSelectedTextColorProperty =
            BindableProperty.Create(nameof(DisabledSelectedTextColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: DefaultStyles.TextColor);

        public Color DisabledSelectedTextColor
        {
            get { return (Color)GetValue(DisabledSelectedTextColorProperty); }
            set { SetValue(DisabledSelectedTextColorProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: DefaultStyles.PrimaryContainerColor);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty SelectedBackgroundColorProperty =
            BindableProperty.Create(nameof(SelectedBackgroundColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: DefaultStyles.PrimaryColor);

        public Color SelectedBackgroundColor
        {
            get { return (Color)GetValue(SelectedBackgroundColorProperty); }
            set { SetValue(SelectedBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty DisabledBackgroundColorProperty =
            BindableProperty.Create(nameof(DisabledBackgroundColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: DefaultStyles.DisableContainerColor);

        public Color DisabledBackgroundColor
        {
            get { return (Color)GetValue(DisabledBackgroundColorProperty); }
            set { SetValue(DisabledBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty DisabledSelectedBackgroundColorProperty =
            BindableProperty.Create(nameof(DisabledSelectedBackgroundColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: DefaultStyles.DisableColor);

        public Color DisabledSelectedBackgroundColor
        {
            get { return (Color)GetValue(DisabledSelectedBackgroundColorProperty); }
            set { SetValue(DisabledSelectedBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty =
           BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: DefaultStyles.PrimaryColor);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MaterialChipsGroup), defaultValue: DefaultStyles.PhoneFontSizes.LabelLarge);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(MaterialChipsGroup), defaultValue: DefaultStyles.FontFamily);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(MaterialChipsGroup), defaultValue: 16.0);

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty AnimateErrorProperty =
            BindableProperty.Create(nameof(AnimateError), typeof(bool), typeof(MaterialChipsGroup), defaultValue: DefaultStyles.AnimateError);

        public bool AnimateError
        {
            get { return (bool)GetValue(AnimateErrorProperty); }
            set { SetValue(AnimateErrorProperty, value); }
        }

        public static readonly BindableProperty IsMultipleSelectionProperty =
            BindableProperty.Create(nameof(IsMultipleSelection), typeof(bool), typeof(MaterialChipsGroup), defaultValue: false);

        public bool IsMultipleSelection
        {
            get { return (bool)GetValue(IsMultipleSelectionProperty); }
            set { SetValue(IsMultipleSelectionProperty, value); }
        }

        public static readonly BindableProperty AnimationProperty =
            BindableProperty.Create(nameof(Animation), typeof(AnimationTypes), typeof(MaterialChips), defaultValue: DefaultStyles.AnimationType);

        public AnimationTypes Animation
        {
            get { return (AnimationTypes)GetValue(AnimationProperty); }
            set { SetValue(AnimationProperty, value); }
        }

        public static readonly BindableProperty AnimationParameterProperty =
            BindableProperty.Create(nameof(AnimationParameter), typeof(double?), typeof(MaterialChips), defaultValue: DefaultStyles.AnimationParameter);

        public double? AnimationParameter
        {
            get { return (double?)GetValue(AnimationParameterProperty); }
            set { SetValue(AnimationParameterProperty, value); }
        }

        #endregion Properties

        #region Methods

        private static bool OnSupportingTextValidate(BindableObject bindable, object value)
        {
            var control = (MaterialChipsGroup)bindable;

            // Used to animate the error when the assistive text doesn't change
            if (control.AnimateError && !string.IsNullOrEmpty(control.SupportingText) && control.SupportingText == (string)value)
                ShakeAnimation.Animate(control);

            return true;
        }

        // Single selection
        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialChipsGroup)bindable;
            if (control._flexContainer.Children != null && control.SelectedItem != null)
            {
                foreach (var item in control._flexContainer.Children)
                {
                    if (item is MaterialChips itemMC)
                        itemMC.IsSelected = itemMC.Text.Equals(control.SelectedItem);
                }
            }
        }

        // Multiple selection
        private static void OnSelectedItemsChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialChipsGroup)bindable;
            if (control._flexContainer.Children != null && control.SelectedItems != null && control.SelectedItems.Any())
            {
                foreach (var item in control._flexContainer.Children)
                {
                    if (item is MaterialChips itemMC)
                        itemMC.IsSelected = control.SelectedItems.Contains((itemMC).Text);
                }
            }
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialChipsGroup)bindable;
            control._flexContainer.Children.Clear();
            if (!Equals(newValue, null) && newValue is IEnumerable)
            {
                foreach (var item in (IEnumerable)newValue)
                {
                    var materialChips = new MaterialChips
                    {
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
                        BorderColor = control.BorderColor,
                        IsEnabled = control.IsEnabled,
                        ToUpper = control.ToUpper,
                        Animation = control.Animation,
                        AnimationParameter = control.AnimationParameter
                    };

                    materialChips.HeightRequest = control.ChipsHeightRequest;

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

                    materialChips.Command = new Command(() => SelectionCommand(control, materialChips));

                    control._flexContainer.Children.Add(materialChips);

                    if (control.ChipsFlexLayoutPercentageBasis > 0 && control.ChipsFlexLayoutPercentageBasis <= 1)
                        FlexLayout.SetBasis(materialChips, new FlexBasis((float)control.ChipsFlexLayoutPercentageBasis, true));
                }
            }
        }

        private static void SelectionCommand(MaterialChipsGroup materialChipsGroup, MaterialChips materialChips)
        {
            if (!materialChipsGroup.IsEnabled)
                return;

            if (materialChips is MaterialChips)
            {
                if (materialChipsGroup.IsMultipleSelection)
                {
                    var selectedItems = materialChipsGroup.SelectedItems == null ? new List<string>() : materialChipsGroup.SelectedItems.Select(x => x).ToList();

                    materialChips.IsSelected = !materialChips.IsSelected;

                    if (materialChips.IsSelected && !selectedItems.Contains(materialChips.Text))
                        selectedItems.Add(materialChips.Text);
                    else if (selectedItems.Contains(materialChips.Text))
                        selectedItems.Remove(materialChips.Text);

                    materialChipsGroup.SelectedItems = selectedItems;
                }
                else
                {
                    foreach (var item in materialChipsGroup._flexContainer.Children)
                    {
                        ((MaterialChips)item).IsSelected = false;
                    }

                    materialChips.IsSelected = !materialChips.IsSelected;

                    materialChipsGroup.SelectedItem = materialChips.Text;
                }
            }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!this.initialized)
            {
                this.initialized = true;
                this.Initialize();
            }

            switch (propertyName)
            {
                case nameof(base.TranslationX):
                    base.OnPropertyChanged(propertyName);
                    break;
                case nameof(this.LabelText):
                    this._lblLabel.Text = this.LabelText;
                    this._lblLabel.IsVisible = !string.IsNullOrEmpty(this.LabelText);
                    break;
                case nameof(this.LabelTextColor):
                    this._lblLabel.TextColor = this.LabelTextColor;
                    break;
                case nameof(this.LabelSize):
                    this._lblLabel.FontSize = this.LabelSize;
                    break;

                case nameof(this.Padding):
                    this._flexContainer.Padding = this.Padding;
                    break;

                case nameof(this.SupportingText):
                    this._lblSupporting.Text = this.SupportingText;
                    this._lblSupporting.IsVisible = !string.IsNullOrEmpty(this.SupportingText);
                    if (this.AnimateError && !string.IsNullOrEmpty(this.SupportingText))
                    {
                        ShakeAnimation.Animate(this);
                    }
                    break;
                case nameof(this.SupportingTextColor):
                    this._lblSupporting.TextColor = this.SupportingTextColor;
                    break;
                case nameof(this.SupportingSize):
                    this._lblSupporting.FontSize = this.SupportingSize;
                    break;

                case nameof(IsEnabled):
                    foreach (var view in _flexContainer.Children)
                    {
                        if (view is MaterialChips materialChips)
                            materialChips.IsEnabled = IsEnabled;
                    }
                    break;
            }
        }

        private void Initialize()
        {
            var stackLayout = new StackLayout()
            {
                Spacing = 2
            };

            this._lblLabel = new MaterialLabel()
            {
                IsVisible = false,
                LineBreakMode = LineBreakMode.NoWrap,
                Margin = new Thickness(14, 0, 14, 2),
                HorizontalTextAlignment = TextAlignment.Start,
                TextColor = LabelTextColor,
                FontFamily = FontFamily,
                FontSize = LabelSize
            };

            this._flexContainer = new FlexLayout()
            {
                Wrap = FlexWrap.Wrap,
                Direction = FlexDirection.Row,
                JustifyContent = FlexJustify.Start
            };

            this._lblSupporting = new MaterialLabel()
            {
                IsVisible = false,
                LineBreakMode = LineBreakMode.NoWrap,
                Margin = new Thickness(14, 2, 14, 0),
                HorizontalTextAlignment = TextAlignment.Start,
                TextColor = SupportingTextColor,
                FontFamily = FontFamily,
                FontSize = SupportingSize
            };

            stackLayout.Children.Add(this._lblLabel);
            stackLayout.Children.Add(this._flexContainer);
            stackLayout.Children.Add(this._lblSupporting);

            this.Content = stackLayout;
        }

        #endregion Methods
    }
}