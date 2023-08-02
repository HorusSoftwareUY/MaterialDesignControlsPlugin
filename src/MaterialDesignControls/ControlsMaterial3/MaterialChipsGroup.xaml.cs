﻿using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Styles;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls.Material3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialChipsGroup : ContentView
    {
        #region Constructors

        public MaterialChipsGroup()
        {
            if (!this.initialized)
            {
                this.initialized = true;
                this.InitializeComponent();
            }
        }

        #endregion Constructors

        #region Attributes

        private bool initialized = false;

        #endregion Attributes

        #region Properties

        public static readonly BindableProperty TypeProperty =
            BindableProperty.Create(nameof(Type), typeof(MaterialChipsType), typeof(MaterialChipsGroup), defaultValue: MaterialChipsType.Assist);

        public MaterialChipsType Type
        {
            get { return (MaterialChipsType)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

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
            BindableProperty.Create(nameof(ChipsHeightRequest), typeof(double), typeof(MaterialChipsGroup), defaultValue: 0.0);

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

        public static readonly BindableProperty AssistiveTextProperty =
            BindableProperty.Create(nameof(AssistiveText), typeof(string), typeof(MaterialChipsGroup), defaultValue: null, validateValue: OnAssistiveTextValidate);

        public string AssistiveText
        {
            get { return (string)GetValue(AssistiveTextProperty); }
            set { SetValue(AssistiveTextProperty, value); }
        }

        public static readonly BindableProperty LabelTextColorProperty =
            BindableProperty.Create(nameof(LabelTextColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: Color.Gray);

        public Color LabelTextColor
        {
            get { return (Color)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public static readonly BindableProperty AssistiveTextColorProperty =
            BindableProperty.Create(nameof(AssistiveTextColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: Color.Red);

        public Color AssistiveTextColor
        {
            get { return (Color)GetValue(AssistiveTextColorProperty); }
            set { SetValue(AssistiveTextColorProperty, value); }
        }

        public static readonly BindableProperty LabelSizeProperty =
            BindableProperty.Create(nameof(LabelSize), typeof(double), typeof(MaterialChipsGroup), defaultValue: Font.Default.FontSize);

        public double LabelSize
        {
            get { return (double)GetValue(LabelSizeProperty); }
            set { SetValue(LabelSizeProperty, value); }
        }

        public static readonly BindableProperty AssistiveSizeProperty =
            BindableProperty.Create(nameof(AssistiveSize), typeof(double), typeof(MaterialChipsGroup), defaultValue: Font.Default.FontSize);

        public double AssistiveSize
        {
            get { return (double)GetValue(AssistiveSizeProperty); }
            set { SetValue(AssistiveSizeProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: DefaultStyles.PrimaryColor);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty SelectedTextColorProperty =
            BindableProperty.Create(nameof(SelectedTextColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: Color.White);

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
            BindableProperty.Create(nameof(DisabledSelectedTextColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: Color.Black);

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
            BindableProperty.Create(nameof(DisabledBackgroundColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: Color.LightGray);

        public Color DisabledBackgroundColor
        {
            get { return (Color)GetValue(DisabledBackgroundColorProperty); }
            set { SetValue(DisabledBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty DisabledSelectedBackgroundColorProperty =
            BindableProperty.Create(nameof(DisabledSelectedBackgroundColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: Color.DarkGray);

        public Color DisabledSelectedBackgroundColor
        {
            get { return (Color)GetValue(DisabledSelectedBackgroundColorProperty); }
            set { SetValue(DisabledSelectedBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MaterialChipsGroup), defaultValue: Font.Default.FontSize);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(MaterialChipsGroup), defaultValue: null);

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
            BindableProperty.Create(nameof(AnimateError), typeof(bool), typeof(MaterialChipsGroup), defaultValue: false);

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

        #endregion Properties

        #region Methods

        private static bool OnAssistiveTextValidate(BindableObject bindable, object value)
        {
            var control = (MaterialChipsGroup)bindable;

            // Used to animate the error when the assistive text doesn't change
            if (control.AnimateError && !string.IsNullOrEmpty(control.AssistiveText) && control.AssistiveText == (string)value)
                ShakeAnimation.Animate(control);

            return true;
        }

        // Single selection
        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialChipsGroup)bindable;
            if (control.flexContainer.Children != null && control.SelectedItem != null)
            {
                foreach (var item in control.flexContainer.Children)
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
            if (control.flexContainer.Children != null && control.SelectedItems != null && control.SelectedItems.Any())
            {
                foreach (var item in control.flexContainer.Children)
                {
                    if (item is MaterialChips itemMC)
                        itemMC.IsSelected = control.SelectedItems.Contains((itemMC).Text);
                }
            }
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialChipsGroup)bindable;
            control.flexContainer.Children.Clear();
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
                        IsEnabled = control.IsEnabled,
                        ToUpper = control.ToUpper,
                        Type = control.Type
                    };

                    if (control.ChipsHeightRequest != (double)ChipsHeightRequestProperty.DefaultValue)
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

                    control.flexContainer.Children.Add(materialChips);

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
                    foreach (var item in materialChipsGroup.flexContainer.Children)
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
                this.InitializeComponent();
            }

            switch (propertyName)
            {
                case nameof(base.TranslationX):
                    base.OnPropertyChanged(propertyName);
                    break;
                case nameof(this.LabelText):
                    this.lblLabel.Text = this.LabelText;
                    this.lblLabel.IsVisible = !string.IsNullOrEmpty(this.LabelText);
                    break;
                case nameof(this.LabelTextColor):
                    this.lblLabel.TextColor = this.LabelTextColor;
                    break;
                case nameof(this.LabelSize):
                    this.lblLabel.FontSize = this.LabelSize;
                    break;

                case nameof(this.Padding):
                    this.flexContainer.Padding = this.Padding;
                    break;

                case nameof(this.AssistiveText):
                    this.lblAssistive.Text = this.AssistiveText;
                    this.lblAssistive.IsVisible = !string.IsNullOrEmpty(this.AssistiveText);
                    if (this.AnimateError && !string.IsNullOrEmpty(this.AssistiveText))
                    {
                        ShakeAnimation.Animate(this);
                    }
                    break;
                case nameof(this.AssistiveTextColor):
                    this.lblAssistive.TextColor = this.AssistiveTextColor;
                    break;
                case nameof(this.AssistiveSize):
                    this.lblAssistive.FontSize = this.AssistiveSize;
                    break;

                case nameof(IsEnabled):
                    foreach (var view in flexContainer.Children)
                    {
                        if (view is MaterialChips materialChips)
                            materialChips.IsEnabled = IsEnabled;
                    }
                    break;
            }
        }

        #endregion Methods
    }
}