using System.Collections;
using System.Collections.Generic;
using Plugin.MaterialDesignControls.Animations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialRadioButtons : ContentView
    {
        #region Attributes

        private bool initialized = false;

        #endregion Attributes

        #region Constructors

        public MaterialRadioButtons()
        {
            if (!this.initialized)
            {
                this.initialized = true;
                this.InitializeComponent();
            }
        }

        #endregion Constructors

        #region Properties

        public static readonly new BindableProperty IsEnabledProperty =
            BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(MaterialRadioButtons), defaultValue: true);

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public static readonly BindableProperty LabelTextProperty =
            BindableProperty.Create(nameof(LabelText), typeof(string), typeof(MaterialRadioButtons), defaultValue: null);

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<string>), typeof(MaterialRadioButtons), defaultValue: null, propertyChanged: OnItemsSourceChanged);

        public IEnumerable<string> ItemsSource
        {
            get { return (IEnumerable<string>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(nameof(SelectedItem), typeof(string), typeof(MaterialRadioButtons), defaultValue: null, propertyChanged: OnSelectedItemChanged, defaultBindingMode: BindingMode.TwoWay);

        public string SelectedItem
        {
            get { return (string)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly BindableProperty AssistiveTextProperty =
            BindableProperty.Create(nameof(AssistiveText), typeof(string), typeof(MaterialRadioButtons), defaultValue: null, validateValue: OnAssistiveTextValidate);

        public string AssistiveText
        {
            get { return (string)GetValue(AssistiveTextProperty); }
            set { SetValue(AssistiveTextProperty, value); }
        }

        public static readonly BindableProperty LabelTextColorProperty =
            BindableProperty.Create(nameof(LabelTextColor), typeof(Color), typeof(MaterialRadioButtons), defaultValue: Color.Gray);

        public Color LabelTextColor
        {
            get { return (Color)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public static readonly BindableProperty AssistiveTextColorProperty =
            BindableProperty.Create(nameof(AssistiveTextColor), typeof(Color), typeof(MaterialRadioButtons), defaultValue: Color.Gray);

        public Color AssistiveTextColor
        {
            get { return (Color)GetValue(AssistiveTextColorProperty); }
            set { SetValue(AssistiveTextColorProperty, value); }
        }

        public static readonly BindableProperty LabelSizeProperty =
            BindableProperty.Create(nameof(LabelSize), typeof(double), typeof(MaterialRadioButtons), defaultValue: Font.Default.FontSize);

        public double LabelSize
        {
            get { return (double)GetValue(LabelSizeProperty); }
            set { SetValue(LabelSizeProperty, value); }
        }

        public static readonly BindableProperty AssistiveSizeProperty =
            BindableProperty.Create(nameof(AssistiveSize), typeof(double), typeof(MaterialRadioButtons), defaultValue: Font.Default.FontSize);

        public double AssistiveSize
        {
            get { return (double)GetValue(AssistiveSizeProperty); }
            set { SetValue(AssistiveSizeProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialRadioButtons), defaultValue: Color.Gray);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty SelectedTextColorProperty =
            BindableProperty.Create(nameof(SelectedTextColor), typeof(Color), typeof(MaterialRadioButtons), defaultValue: Color.Black);

        public Color SelectedTextColor
        {
            get { return (Color)GetValue(SelectedTextColorProperty); }
            set { SetValue(SelectedTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledTextColorProperty =
            BindableProperty.Create(nameof(DisabledTextColor), typeof(Color), typeof(MaterialRadioButtons), defaultValue: Color.LightGray);

        public Color DisabledTextColor
        {
            get { return (Color)GetValue(DisabledTextColorProperty); }
            set { SetValue(DisabledTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledSelectedTextColorProperty =
            BindableProperty.Create(nameof(DisabledSelectedTextColor), typeof(Color), typeof(MaterialRadioButtons), defaultValue: Color.White);

        public Color DisabledSelectedTextColor
        {
            get { return (Color)GetValue(DisabledSelectedTextColorProperty); }
            set { SetValue(DisabledSelectedTextColorProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MaterialRadioButtons), defaultValue: Font.Default.FontSize);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(MaterialRadioButtons), defaultValue: null);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public static readonly BindableProperty AnimateErrorProperty =
            BindableProperty.Create(nameof(AnimateError), typeof(bool), typeof(MaterialRadioButtons), defaultValue: false);

        public bool AnimateError
        {
            get { return (bool)GetValue(AnimateErrorProperty); }
            set { SetValue(AnimateErrorProperty, value); }
        }

        public static readonly BindableProperty IsMultipleSelectionProperty =
            BindableProperty.Create(nameof(IsMultipleSelection), typeof(bool), typeof(MaterialRadioButtons), defaultValue: false);

        public bool IsMultipleSelection
        {
            get { return (bool)GetValue(IsMultipleSelectionProperty); }
            set { SetValue(IsMultipleSelectionProperty, value); }
        }

        #endregion Properties

        #region Methods

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialRadioButtons)bindable;
            control.container.Children.Clear();
            if (!Equals(newValue, null) && newValue is IEnumerable)
            {
                foreach (var item in (IEnumerable)newValue)
                {
                    var materialCheckbox = new MaterialChips
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Text = item.ToString(),
                        FontSize = control.FontSize,
                        FontFamily = control.FontFamily,
                        //CornerRadius = control.CornerRadius,
                        //Padding = control.ChipsPadding,
                        //Margin = control.ChipsMargin,
                        BackgroundColor = control.BackgroundColor,
                        TextColor = control.TextColor,
                        //SelectedBackgroundColor = control.SelectedBackgroundColor,
                        SelectedTextColor = control.SelectedTextColor,
                        //DisabledBackgroundColor = control.DisabledBackgroundColor,
                        DisabledTextColor = control.DisabledTextColor,
                        //DisabledSelectedBackgroundColor = control.DisabledSelectedBackgroundColor,
                        DisabledSelectedTextColor = control.DisabledSelectedTextColor,
                        IsEnabled = control.IsEnabled
                    };

                    if (control.SelectedItem != null)
                        materialCheckbox.IsSelected = materialCheckbox.Text.Equals(control.SelectedItem);

                    materialChips.Command = new Command(() => SelectionCommand(control, materialChips));

                    control.container.Children.Add(materialChips);

                    if (control.ChipsFlexLayoutPercentageBasis > 0 && control.ChipsFlexLayoutPercentageBasis <= 1)
                        FlexLayout.SetBasis(materialChips, new FlexBasis((float)control.ChipsFlexLayoutPercentageBasis, true));
                }
            }
        }

        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialRadioButtons)bindable;
            if (control.container.Children != null && control.SelectedItem != null)
            {
                foreach (var item in control.container.Children)
                {
                    if (item != null && item is MaterialChips)
                        ((MaterialChips)item).IsSelected = ((MaterialChips)item).Text.Equals(control.SelectedItem);
                }
            }
        }

        private static bool OnAssistiveTextValidate(BindableObject bindable, object value)
        {
            var control = (MaterialChipsGroup)bindable;

            // Used to animate the error when the assistive text doesn't change
            if (control.AnimateError && !string.IsNullOrEmpty(control.AssistiveText) && control.AssistiveText == (string)value)
                ShakeAnimation.Animate(control);

            return true;
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

        #endregion Methods
    }
}
