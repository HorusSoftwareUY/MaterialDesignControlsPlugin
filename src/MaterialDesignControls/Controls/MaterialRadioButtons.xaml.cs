using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialRadioButtons : BaseMaterialCheckboxes
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
                Initialize();
            }
        }

        #endregion Constructors

        #region Properties

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

        #region LabelText

        public static readonly BindableProperty LabelTextProperty =
            BindableProperty.Create(nameof(LabelText), typeof(string), typeof(MaterialRadioButtons), defaultValue: null);

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public static readonly BindableProperty LabelTextColorProperty =
            BindableProperty.Create(nameof(LabelTextColor), typeof(Color), typeof(MaterialRadioButtons), defaultValue: Color.Black);

        public Color LabelTextColor
        {
            get { return (Color)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledLabelTextColorProperty =
            BindableProperty.Create(nameof(DisabledLabelTextColor), typeof(Color), typeof(MaterialRadioButtons), defaultValue: Color.LightGray);

        public Color DisabledLabelTextColor
        {
            get { return (Color)GetValue(DisabledLabelTextColorProperty); }
            set { SetValue(DisabledLabelTextColorProperty, value); }
        }

        public static readonly BindableProperty LabelSizeProperty =
            BindableProperty.Create(nameof(LabelSize), typeof(double), typeof(MaterialRadioButtons), defaultValue: Font.Default.FontSize);

        public double LabelSize
        {
            get { return (double)GetValue(LabelSizeProperty); }
            set { SetValue(LabelSizeProperty, value); }
        }

        public static readonly BindableProperty LabelFontFamilyProperty =
            BindableProperty.Create(nameof(LabelFontFamily), typeof(string), typeof(MaterialRadioButtons), defaultValue: null);

        public string LabelFontFamily
        {
            get { return (string)GetValue(LabelFontFamilyProperty); }
            set { SetValue(LabelFontFamilyProperty, value); }
        }

        public static readonly BindableProperty LabelMarginProperty =
            BindableProperty.Create(nameof(LabelMargin), typeof(Thickness), typeof(MaterialRadioButtons), defaultValue: new Thickness(14, 0, 14, 2));

        public Thickness LabelMargin
        {
            get { return (Thickness)GetValue(LabelMarginProperty); }
            set { SetValue(LabelMarginProperty, value); }
        }

        #endregion LabelText

        #endregion Properties

        #region Methods

        private void Initialize()
        {
            lblLabel.TextColor = LabelTextColor;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            UpdateLayout(propertyName, container, lblAssistive);

            switch (propertyName) 
	        { 
                case nameof(LabelText):
                    lblLabel.Text = LabelText;
                    if (!string.IsNullOrEmpty(LabelText))
                        lblLabel.IsVisible = true;
                    break;
                case nameof(LabelFontFamily):
                    lblLabel.FontFamily = LabelFontFamily;
                    break;
                case nameof(LabelMargin):
                    lblLabel.Margin = LabelMargin;
                    break;
                case nameof(LabelSize):
                    lblLabel.FontSize = LabelSize;
                    break;
                case nameof(LabelTextColor):
                case nameof(DisabledLabelTextColor):
                    lblLabel.TextColor = IsEnabled ? LabelTextColor : DisabledLabelTextColor;
                    break;
                case nameof(IsEnabled):
                    lblLabel.TextColor = IsEnabled? LabelTextColor: DisabledLabelTextColor;
                    break;
            }

        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialRadioButtons)bindable;
            control.container.Children.Clear();
            if (!Equals(newValue, null) && newValue is IEnumerable)
            {
                foreach (var item in (IEnumerable)newValue)
                {
                    var materialCheckbox = new MaterialCheckbox();
                    materialCheckbox.Text = item.ToString();
                    materialCheckbox.Command = new Command(() => SelectionCommand(control, materialCheckbox));
                    materialCheckbox.Color = control.Color;
                    materialCheckbox.TextColor = control.TextColor;
                    materialCheckbox.FontSize = control.FontSize;
                    materialCheckbox.FontFamily = control.FontFamily;
                    materialCheckbox.BackgroundColor = control.BackgroundColor;
                    materialCheckbox.IsEnabled = control.IsEnabled;
		            materialCheckbox.DisabledColor = control.DisabledColor;
                    materialCheckbox.DisabledTextColor = control.DisabledTextColor;
                    materialCheckbox.TextSide = control.TextSide;
                    materialCheckbox.TextHorizontalOptions = control.TextHorizontalOptions;
                    materialCheckbox.SelectionHorizontalOptions = control.SelectionHorizontalOptions;
                    materialCheckbox.IconHeightRequest = control.IconHeightRequest;
                    materialCheckbox.IconWidthRequest = control.IconWidthRequest;
                    materialCheckbox.SelectedIcon = control.SelectedIcon;
                    materialCheckbox.UnselectedIcon = control.UnselectedIcon;
                    materialCheckbox.DisabledSelectedIcon = control.DisabledSelectedIcon;
                    materialCheckbox.DisabledUnselectedIcon = control.DisabledUnselectedIcon;
                    materialCheckbox.CustomSelectedIcon = control.CustomSelectedIcon;
                    materialCheckbox.CustomUnselectedIcon = control.CustomUnselectedIcon;
                    materialCheckbox.CustomDisabledSelectedIcon = control.CustomDisabledSelectedIcon;
                    materialCheckbox.CustomDisabledUnselectedIcon = control.CustomDisabledUnselectedIcon;
                    materialCheckbox.Animation = control.Animation;
                    materialCheckbox.AnimationParameter = control.AnimationParameter;

                    if (control.SelectedItem != null)
                        materialCheckbox.IsChecked = materialCheckbox.Text.Equals(control.SelectedItem);

                    control.container.Children.Add(materialCheckbox);
                }
            }
        }

        private static void SelectionCommand(MaterialRadioButtons materialRadioButtons, MaterialCheckbox materialCheckbox)
        {
            if (!materialRadioButtons.IsEnabled)
                return;

            if (materialRadioButtons is MaterialRadioButtons)
            {
		        //Debug.WriteLine("----SelectionCommand----");
                foreach (var item in materialRadioButtons.container.Children)
                    ((MaterialCheckbox)item).IsChecked = false;
                //{
                //    var text = ((MaterialCheckbox)item).Text;
                //    var ischecked =((MaterialCheckbox)item).IsChecked;
                //    Debug.WriteLine($"command Option: {text}");
                //    Debug.WriteLine($"command is checked: {ischecked}");
                //}

                materialCheckbox.IsChecked = !materialCheckbox.IsChecked;
                materialRadioButtons.SelectedItem = materialCheckbox.Text;
                //Debug.WriteLine($"materialCheckbox text: {materialCheckbox.Text}");
                //Debug.WriteLine($"materialCheckbox is checked: {materialCheckbox.IsChecked}");
            }
        }

        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialRadioButtons)bindable;
            if (control.container.Children != null && control.SelectedItem != null)
            {
                //Debug.WriteLine("----OnSelectedItemChanged----");
                foreach (var item in control.container.Children)
                    if (item != null && item is MaterialCheckbox)
                        ((MaterialCheckbox)item).IsChecked = ((MaterialCheckbox)item).Text.Equals(control.SelectedItem);
                //{
                //    var checkbox = ((MaterialCheckbox)item);
                //    var text = ((MaterialCheckbox)item).Text;
                //    var ischecked =((MaterialCheckbox)item).IsChecked;
                //    Debug.WriteLine($"itemchanged Option: {text}");
                //    Debug.WriteLine($"itemchanged Is checked: {ischecked}");
                //}
            }
        }

        protected override void SetIcon() { }

        protected override void SetIsChecked() { }

        protected override void SetIsEnabled() { }

        #endregion Methods
    }
}
