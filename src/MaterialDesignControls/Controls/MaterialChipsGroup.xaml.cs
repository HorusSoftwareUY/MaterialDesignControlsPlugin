using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Plugin.MaterialDesignControls.Animations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialChipsGroup : ContentView
    {
        #region Constructors

        public MaterialChipsGroup()
        {
            if (!this.initialized)
            {
                this.InitializeComponent();
                this.initialized = true;
            }
        }

        #endregion Constructors

        #region Attributes

        private bool initialized = false;

        #endregion Attributes

        #region Properties

        public static readonly new BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(MaterialChipsGroup), defaultValue: new Thickness(12, 0));

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
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
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(MaterialChipsGroup), defaultValue: null, propertyChanged: OnItemsSourceChanged);

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(nameof(SelectedItem), typeof(string), typeof(MaterialChipsGroup), defaultValue: null, propertyChanged: OnSelectedItemChanged, defaultBindingMode: BindingMode.TwoWay);

        public string SelectedItem
        {
            get { return (string)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly BindableProperty AssistiveTextProperty =
            BindableProperty.Create(nameof(AssistiveText), typeof(string), typeof(MaterialChipsGroup), defaultValue: null);

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
            BindableProperty.Create(nameof(AssistiveTextColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: Color.Gray);

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
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: Color.Gray);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty SelectedTextColorProperty =
            BindableProperty.Create(nameof(SelectedTextColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: Color.Black);

        public Color SelectedTextColor
        {
            get { return (Color)GetValue(SelectedTextColorProperty); }
            set { SetValue(SelectedTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledTextColorProperty =
            BindableProperty.Create(nameof(DisabledTextColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: Color.LightGray);

        public Color DisabledTextColor
        {
            get { return (Color)GetValue(DisabledTextColorProperty); }
            set { SetValue(DisabledTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledSelectedTextColorProperty =
            BindableProperty.Create(nameof(DisabledSelectedTextColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: Color.White);

        public Color DisabledSelectedTextColor
        {
            get { return (Color)GetValue(DisabledSelectedTextColorProperty); }
            set { SetValue(DisabledSelectedTextColorProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: Color.LightGray);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty SelectedBackgroundColorProperty =
            BindableProperty.Create(nameof(SelectedBackgroundColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: Color.Gray);

        public Color SelectedBackgroundColor
        {
            get { return (Color)GetValue(SelectedBackgroundColorProperty); }
            set { SetValue(SelectedBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty DisabledBackgroundColorProperty =
            BindableProperty.Create(nameof(DisabledBackgroundColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: Color.White);

        public Color DisabledBackgroundColor
        {
            get { return (Color)GetValue(DisabledBackgroundColorProperty); }
            set { SetValue(DisabledBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty DisabledSelectedBackgroundColorProperty =
            BindableProperty.Create(nameof(DisabledSelectedBackgroundColor), typeof(Color), typeof(MaterialChipsGroup), defaultValue: Color.LightGray);

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

        #endregion Properties

        #region Methods

        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialChipsGroup)bindable;
            if (control.stcContainer.Children != null)
            {
                foreach (var item in control.stcContainer.Children)
                {
                    if (item != null && item is MaterialChips)
                    {
                        ((MaterialChips)item).IsSelected = ((MaterialChips)item).Text.Equals(control.SelectedItem);
                    }
                }
            }
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialChipsGroup)bindable;
            control.stcContainer.Children.Clear();
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
                        Padding = control.Padding,
                        BackgroundColor = control.BackgroundColor,
                        TextColor = control.TextColor,
                        SelectedBackgroundColor = control.SelectedBackgroundColor,
                        SelectedTextColor = control.SelectedTextColor,
                        DisabledBackgroundColor = control.DisabledBackgroundColor,
                        DisabledTextColor = control.DisabledTextColor,
                        DisabledSelectedBackgroundColor = control.DisabledSelectedBackgroundColor,
                        DisabledSelectedTextColor = control.DisabledSelectedTextColor
                    };
                    if (control.SelectedItem != null)
                    {
                        materialChips.IsSelected = materialChips.Text.Equals(control.SelectedItem);
                    }
                    materialChips.IsSelectedChanged  += control.MaterialChips_IsSelectedChanged;
                    control.stcContainer.Children.Add(materialChips);
                }
            }
        }

        private void MaterialChips_IsSelectedChanged(object sender, EventArgs e)
        {
            if (sender is MaterialChips)
            {
                if (((MaterialChips)sender).IsSelected)
                {
                    this.SelectedItem = ((MaterialChips)sender).Text;
                }

                bool hasSelected = false;
                if (this.stcContainer.Children != null)
                {
                    foreach (var item in this.stcContainer.Children)
                    {
                        if (item != null && item is MaterialChips && ((MaterialChips)item).IsSelected)
                        {
                            hasSelected = true;
                            break;
                        }
                    }
                }

                if (!hasSelected)
                {
                    ((MaterialChips)sender).IsSelected = true;
                }
            }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!this.initialized)
            {
                this.InitializeComponent();
                this.initialized = true;
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
                    this.stcContainer.Padding = this.Padding;
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

            }
        }

        #endregion Methods
    }
}
