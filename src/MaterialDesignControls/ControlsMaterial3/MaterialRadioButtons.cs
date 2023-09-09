using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Plugin.MaterialDesignControls.Implementations;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Plugin.MaterialDesignControls.Styles;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls.Material3
{
    public partial class MaterialRadioButtons : BaseMaterialCheckBoxes
    {
        #region Attributes

        private bool _initialized = false;

        private StackLayout _container;
        private MaterialLabel _lblLabel;
        private MaterialLabel _lblSupporting;

        #endregion Attributes

        #region Constructors

        public MaterialRadioButtons()
        {
            if (!_initialized)
            {
                _initialized = true;
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
            BindableProperty.Create(nameof(LabelTextColor), typeof(Color), typeof(MaterialRadioButtons), defaultValue: DefaultStyles.TextColor);

        public Color LabelTextColor
        {
            get { return (Color)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledLabelTextColorProperty =
            BindableProperty.Create(nameof(DisabledLabelTextColor), typeof(Color), typeof(MaterialRadioButtons), defaultValue: DefaultStyles.DisableColor);

        public Color DisabledLabelTextColor
        {
            get { return (Color)GetValue(DisabledLabelTextColorProperty); }
            set { SetValue(DisabledLabelTextColorProperty, value); }
        }

        public static readonly BindableProperty LabelSizeProperty =
            BindableProperty.Create(nameof(LabelSize), typeof(double), typeof(MaterialRadioButtons), defaultValue: DefaultStyles.PhoneFontSizes.BodySmall);

        public double LabelSize
        {
            get { return (double)GetValue(LabelSizeProperty); }
            set { SetValue(LabelSizeProperty, value); }
        }

        public static readonly BindableProperty LabelFontFamilyProperty =
            BindableProperty.Create(nameof(LabelFontFamily), typeof(string), typeof(MaterialRadioButtons), defaultValue: DefaultStyles.FontFamily);

        public string LabelFontFamily
        {
            get { return (string)GetValue(LabelFontFamilyProperty); }
            set { SetValue(LabelFontFamilyProperty, value); }
        }

        public static readonly BindableProperty LabelMarginProperty =
            BindableProperty.Create(nameof(LabelMargin), typeof(Thickness), typeof(MaterialRadioButtons), defaultValue: new Thickness(16, 0, 16, 4));

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
            var mainContainer = new StackLayout();

            _lblLabel = new MaterialLabel()
            {
                IsVisible = false,
                LineBreakMode = LineBreakMode.NoWrap,
                Margin = new Thickness(14, 0, 14, 2),
                HorizontalTextAlignment = TextAlignment.Start,
                Text = Text
            };

            _container = new StackLayout();

            _lblSupporting = new MaterialLabel()
            {
                IsVisible = false,
                LineBreakMode = LineBreakMode.NoWrap,
                Margin = new Thickness(14, 2, 14, 0),
                HorizontalTextAlignment = TextAlignment.Start,
                Text = SupportingText
            };

            mainContainer.Children.Add(_lblLabel);
            mainContainer.Children.Add(_container);
            mainContainer.Children.Add(_lblSupporting);

            _lblLabel.TextColor = TextColor;
            _lblLabel.FontFamily = FontFamily;
            _lblLabel.FontSize = LabelSize;
            _lblLabel.Margin = LabelMargin;

            _lblSupporting.TextColor = SupportingTextColor;
            _lblSupporting.FontFamily = SupportingFontFamily;
            _lblSupporting.FontSize = SupportingSize;
            _lblSupporting.Margin = SupportingMargin;

            Content = mainContainer;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!_initialized)
            {
                _initialized = true;
                Initialize();
            }

            UpdateLayout(propertyName, _container, _lblSupporting);

            switch (propertyName)
            {
                case nameof(TranslationX):
                    base.OnPropertyChanged(propertyName);
                    break;
                case nameof(LabelText):
                    _lblLabel.Text = LabelText;
                    if (!string.IsNullOrEmpty(LabelText))
                        _lblLabel.IsVisible = true;
                    break;
                case nameof(LabelFontFamily):
                    _lblLabel.FontFamily = LabelFontFamily;
                    break;
                case nameof(LabelMargin):
                    _lblLabel.Margin = LabelMargin;
                    break;
                case nameof(LabelSize):
                    _lblLabel.FontSize = LabelSize;
                    break;
                case nameof(LabelTextColor):
                case nameof(DisabledLabelTextColor):
                    _lblLabel.TextColor = IsEnabled ? LabelTextColor : DisabledLabelTextColor;
                    break;
                case nameof(IsEnabled):
                    _lblLabel.TextColor = IsEnabled ? LabelTextColor : DisabledLabelTextColor;
                    break;
            }
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialRadioButtons)bindable;
            control._container.Children.Clear();
            if (!Equals(newValue, null) && newValue is IEnumerable)
            {
                foreach (var item in (IEnumerable)newValue)
                {
                    var materialCheckbox = new MaterialCheckbox();
                    materialCheckbox.IsRadioButtonStyle = true;
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

                    control._container.Children.Add(materialCheckbox);
                }
            }
        }

        private static void SelectionCommand(MaterialRadioButtons materialRadioButtons, MaterialCheckbox materialCheckbox)
        {
            if (!materialRadioButtons.IsEnabled)
                return;

            if (materialRadioButtons is MaterialRadioButtons)
            {
                foreach (var item in materialRadioButtons._container.Children)
                    ((MaterialCheckbox)item).IsChecked = false;

                materialCheckbox.IsChecked = !materialCheckbox.IsChecked;
                materialRadioButtons.SelectedItem = materialCheckbox.Text;
            }
        }

        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialRadioButtons)bindable;
            if (control._container.Children != null && control.SelectedItem != null)
            {
                foreach (var item in control._container.Children)
                    if (item != null && item is MaterialCheckbox)
                        ((MaterialCheckbox)item).IsChecked = ((MaterialCheckbox)item).Text.Equals(control.SelectedItem);
            }
        }

        protected override void SetIcon() { }

        protected override void SetIsChecked() { }

        protected override void SetIsEnabled() { }

        #endregion Methods
    }
}