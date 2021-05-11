using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Plugin.MaterialDesignControls.Animations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialPicker : BaseMaterialFieldControl
    {
        #region Constructors

        public MaterialPicker()
        {
            if (!this.initialized)
            {
                this.initialized = true;
                this.InitializeComponent();
            }

            this.pckOptions.Focused += HandleFocusChange;
            this.pckOptions.Unfocused += HandleFocusChange;
            this.pckOptions.SelectedIndexChanged += PckOptions_SelectedIndexChanged;

            TapGestureRecognizer frameTapGestureRecognizer = new TapGestureRecognizer();
            frameTapGestureRecognizer.Tapped += (s, e) =>
            {
                this.pckOptions.Focus();
            };
            this.frmContainer.GestureRecognizers.Add(frameTapGestureRecognizer);

            this.imgClearIcon.Tapped = () =>
            {
                this.pckOptions.SelectedIndex = -1;
                this.SelectedItem = null;
                SetClearIconIsVisible();
            };
        }

        #endregion Constructors

        #region Attributes

        private bool initialized = false;

        #endregion Attributes

        #region Events

        public event EventHandler SelectedIndexChanged;

        public new event EventHandler<FocusEventArgs> Focused;

        public new event EventHandler<FocusEventArgs> Unfocused;

        #endregion Events

        #region Properties

        public static readonly BindableProperty ClearIconProperty =
           BindableProperty.Create(nameof(ClearIcon), typeof(string), typeof(MaterialEntry), defaultValue: null);

        public string ClearIcon
        {
            get { return (string)GetValue(ClearIconProperty); }
            set { SetValue(ClearIconProperty, value); }
        }

        public static readonly BindableProperty CustomClearIconProperty =
            BindableProperty.Create(nameof(CustomClearIcon), typeof(View), typeof(MaterialEntry), defaultValue: null);

        public View CustomClearIcon
        {
            get { return (View)GetValue(CustomClearIconProperty); }
            set { SetValue(CustomClearIconProperty, value); }
        }

        public static readonly new BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(MaterialPicker), defaultValue: new Thickness(12, 0));

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        //public static readonly new BindableProperty IsEnabledProperty =
        //    BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(MaterialPicker), defaultValue: true);

        //public new bool IsEnabled
        //{
        //    get { return (bool)GetValue(IsEnabledProperty); }
        //    set { SetValue(IsEnabledProperty, value); }
        //}

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(MaterialPicker), defaultValue: null, propertyChanged: OnItemsSourceChanged);

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(nameof(SelectedItem), typeof(string), typeof(MaterialPicker), defaultValue: null, propertyChanged: OnSelectedItemChanged, defaultBindingMode: BindingMode.TwoWay);

        public string SelectedItem
        {
            get { return (string)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialPicker), defaultValue: Color.LightGray);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty LabelLineBreakModeProperty =
            BindableProperty.Create(nameof(LabelLineBreakMode), typeof(LineBreakMode), typeof(MaterialPicker), defaultValue: LineBreakMode.NoWrap);

        public LineBreakMode LabelLineBreakMode
        {
            get { return (LineBreakMode)GetValue(LabelLineBreakModeProperty); }
            set { SetValue(LabelLineBreakModeProperty, value); }
        }

        public static readonly BindableProperty AssistiveLineBreakModeProperty =
            BindableProperty.Create(nameof(AssistiveLineBreakMode), typeof(LineBreakMode), typeof(MaterialPicker), defaultValue: LineBreakMode.NoWrap);

        public LineBreakMode AssistiveLineBreakMode
        {
            get { return (LineBreakMode)GetValue(AssistiveLineBreakModeProperty); }
            set { SetValue(AssistiveLineBreakModeProperty, value); }
        }

        public static readonly BindableProperty MultilineEnabledProperty =
            BindableProperty.Create(nameof(MultilineEnabled), typeof(bool), typeof(MaterialPicker), defaultValue: false);

        public bool MultilineEnabled
        {
            get { return (bool)GetValue(MultilineEnabledProperty); }
            set { SetValue(MultilineEnabledProperty, value); }
        }

        public static readonly BindableProperty PickerRowHeightProperty =
            BindableProperty.Create(nameof(PickerRowHeight), typeof(int), typeof(MaterialPicker), defaultValue: 50);

        public int PickerRowHeight
        {
            get { return (int)GetValue(PickerRowHeightProperty); }
            set { SetValue(PickerRowHeightProperty, value); }
        }

        public static readonly BindableProperty SelectedIndexProperty = 
            BindableProperty.Create(nameof(SelectedIndex), typeof(int), typeof(MaterialPicker), defaultValue: 0);

        public int SelectedIndex
        {
            get
            {
                if (this.ItemsSource != null)
                {
                    var index = 0;
                    foreach (var item in this.ItemsSource)
                    {
                        if (index.Equals(this.pckOptions.SelectedIndex))
                        {
                            return index;
                        }
                        index++;
                    }
                }

                return -1;
            }
        }

        public override bool IsControlFocused
        {
            get { return pckOptions.IsFocused; }
        }

        public override bool IsControlEnabled
        {
            get { return this.IsEnabled; }
        }

        public override Color BackgroundColorControl
        {
            get { return this.BackgroundColor; }
        }

        #endregion Properties

        #region Methods

        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialPicker)bindable;
            control.pckOptions.SelectedItem = (string)newValue;
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialPicker)bindable;
            control.pckOptions.Items.Clear();
            if (!Equals(newValue, null) && newValue is IEnumerable)
            {
                foreach (var item in (IEnumerable)newValue)
                {
                    control.pckOptions.Items.Add(item.ToString());
                }
            }
            control.InternalUpdateSelectedIndex();
        }

        private void InternalUpdateSelectedIndex()
        {
            var selectedIndex = -1;
            if (this.ItemsSource != null)
            {
                var index = 0;
                foreach (var item in this.ItemsSource)
                {
                    if (item != null && item.Equals(this.SelectedItem))
                    {
                        selectedIndex = index;
                        break;
                    }
                    index++;
                }
            }
            this.pckOptions.SelectedIndex = selectedIndex;
            SetClearIconIsVisible();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!this.initialized)
            {
                this.initialized = true;
                this.InitializeComponent();
            }

            UpdateLayout(propertyName, lblLabel, lblAssistive, frmContainer, bxvLine, imgLeadingIcon, imgTrailingIcon);

            switch (propertyName)
            {
                case nameof(base.TranslationX):
                    base.OnPropertyChanged(propertyName);
                    break;
                case nameof(this.MultilineEnabled):
                    this.pckOptions.MultilineEnabled = this.MultilineEnabled;
                    break;
                case nameof(this.PickerRowHeight):
                    this.pckOptions.PickerRowHeight = this.PickerRowHeight;
                    break;
                case nameof(this.LabelLineBreakMode):
                    this.lblLabel.LineBreakMode = this.LabelLineBreakMode;
                    break;
                case nameof(this.AssistiveLineBreakMode):
                    this.lblAssistive.LineBreakMode = this.AssistiveLineBreakMode;
                    break;
                case nameof(this.ClearIcon):
                    if (!string.IsNullOrEmpty(this.ClearIcon))
                        imgClearIcon.SetImage(ClearIcon);
                    SetClearIconIsVisible();
                    break;
                case nameof(CustomClearIcon):
                    if (CustomClearIcon != null)
                        imgClearIcon.SetCustomImage(CustomClearIcon);
                    SetClearIconIsVisible();
                    break;
                case nameof(SelectedItem):
                    SetClearIconIsVisible();
                    break;

            }
        }

        private void SetClearIconIsVisible()
        {
            imgClearIcon.IsVisible = IsEnabled && this.pckOptions.SelectedItem != null
                && (!string.IsNullOrEmpty(ClearIcon) || CustomClearIcon != null);
        }

        protected override void SetIsEnabled()
        {
            pckOptions.IsEnabled = IsEnabled;
        }

        protected override void SetPadding()
        {
            frmContainer.Padding = Padding;
        }

        protected override void SetTextColor()
        {
            if (IsControlEnabled)
                pckOptions.TextColor = IsControlFocused ? FocusedTextColor : TextColor;
            else
                pckOptions.TextColor = DisabledTextColor;
        }

        protected override void SetFontSize()
        {
            pckOptions.FontSize = FontSize;
        }

        protected override void SetFontFamily()
        {
            pckOptions.FontFamily = FontFamily;
        }

        protected override void SetPlaceholder()
        {
            pckOptions.Placeholder = Placeholder;
        }

        protected override void SetPlaceholderColor()
        {
            pckOptions.PlaceholderColor = PlaceholderColor;
        }

        protected override void SetHorizontalTextAlignment()
        {
            pckOptions.HorizontalTextAlignment = HorizontalTextAlignment;
        }

        public new bool Focus()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                pckOptions.Focus();
            });
            return true;
        }

        public new bool Unfocus()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                pckOptions.Unfocus();
            });
            return true;
        }

        private void HandleFocusChange(object sender, FocusEventArgs e)
        {
            base.SetFocusChange(lblLabel, frmContainer, bxvLine);

            if (IsControlFocused)
                Focused?.Invoke(this, e);
            else
                Unfocused?.Invoke(this, e);
        }

        private void PckOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ItemsSource != null)
            {
                var index = 0;
                foreach (var item in this.ItemsSource)
                {
                    if (index.Equals(this.pckOptions.SelectedIndex))
                    {
                        this.SelectedItem = item.ToString();
                        if (this.SelectedIndexChanged != null)
                        {
                            this.SelectedIndexChanged.Invoke(this, e);
                        }
                        break;
                    }
                    index++;
                }
            }
        }

        #endregion Methods
    }
}