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

        public static readonly BindableProperty SelectedTextColorProperty =
            BindableProperty.Create(nameof(SelectedTextColor), typeof(Color), typeof(MaterialRadioButtons), defaultValue: Color.Black);

        public Color SelectedTextColor
        {
            get { return (Color)GetValue(SelectedTextColorProperty); }
            set { SetValue(SelectedTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledSelectedTextColorProperty =
            BindableProperty.Create(nameof(DisabledSelectedTextColor), typeof(Color), typeof(MaterialRadioButtons), defaultValue: Color.White);

        public Color DisabledSelectedTextColor
        {
            get { return (Color)GetValue(DisabledSelectedTextColorProperty); }
            set { SetValue(DisabledSelectedTextColorProperty, value); }
        }

        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create(nameof(Color), typeof(Color), typeof(MaterialCheckbox), defaultValue: Color.Blue);

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly BindableProperty DisabledColorProperty =
            BindableProperty.Create(nameof(DisabledColor), typeof(Color), typeof(MaterialCheckbox), defaultValue: Color.LightGray);

        public Color DisabledColor
	    {
            get { return (Color)GetValue(DisabledColorProperty); }
            set { SetValue(DisabledColorProperty, value); }
        }

        #endregion Properties

        #region Methods

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
                case nameof(IsEnabled):
                    foreach (var view in container.Children)
                    {
                        if (view is MaterialCheckbox materialCheckbox)
                            materialCheckbox.IsEnabled = IsEnabled;
                    }
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
