using System;
using System.Runtime.CompilerServices;
using Plugin.MaterialDesignControls.Animations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialDatePicker : BaseMaterialFieldControl
    {
        #region Constructors

        public MaterialDatePicker()
        {
            if (!this.initialized)
            {
                this.initialized = true;
                this.InitializeComponent();
            }

            pckDate.Focused += HandleFocusChange;
            pckDate.Unfocused += HandleFocusChange;
            pckDate.SetBinding(DatePicker.DateProperty, new Binding() { Source = this, Path = DateProperty.PropertyName });

            TapGestureRecognizer frameTapGestureRecognizer = new TapGestureRecognizer();
            frameTapGestureRecognizer.Tapped += (s, e) =>
            {
                this.pckDate.Focus();
            };
            this.frmContainer.GestureRecognizers.Add(frameTapGestureRecognizer);
        }

        #endregion Constructors

        #region Attributes

        private bool initialized = false;

        #endregion Attributes

        #region Properties

        public static readonly new BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(MaterialDatePicker), defaultValue: new Thickness(12, 0));

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        public static readonly new BindableProperty IsEnabledProperty =
            BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(MaterialDatePicker), defaultValue: true);

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public static readonly BindableProperty DateProperty =
            BindableProperty.Create(nameof(Date), typeof(DateTime?), typeof(MaterialDatePicker), defaultValue: null, propertyChanged: OnDateChanged, defaultBindingMode: BindingMode.TwoWay);

        public DateTime? Date
        {
            get { return (DateTime?)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        public static readonly BindableProperty MinimumDateProperty =
            BindableProperty.Create(nameof(MinimumDate), typeof(DateTime), typeof(MaterialDatePicker), defaultValue: DateTime.MinValue);

        public DateTime MinimumDate
        {
            get { return (DateTime)GetValue(MinimumDateProperty); }
            set { SetValue(MinimumDateProperty, value); }
        }

        public static readonly BindableProperty MaximumDateProperty =
            BindableProperty.Create(nameof(MaximumDate), typeof(DateTime), typeof(MaterialDatePicker), defaultValue: DateTime.MaxValue);

        public DateTime MaximumDate
        {
            get { return (DateTime)GetValue(MaximumDateProperty); }
            set { SetValue(MaximumDateProperty, value); }
        }

        public static readonly BindableProperty FormatProperty =
            BindableProperty.Create(nameof(Format), typeof(string), typeof(MaterialDatePicker), defaultValue: null);

        public string Format
        {
            get { return (string)GetValue(FormatProperty); }
            set { SetValue(FormatProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialDatePicker), defaultValue: Color.LightGray);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public override bool IsControlFocused
        {
            get { return pckDate.IsFocused; }
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

        #region Events

        public new event EventHandler<FocusEventArgs> Focused;

        public new event EventHandler<FocusEventArgs> Unfocused;

        #endregion Events

        #region Methods

        private static void OnDateChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialDatePicker)bindable;
            control.pckDate.Date = (DateTime?)newValue;
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
                case nameof(this.MinimumDate):
                    this.pckDate.MinimumDate = this.MinimumDate;
                    break;
                case nameof(this.MaximumDate):
                    this.pckDate.MaximumDate = this.MaximumDate;
                    break;
                case nameof(this.Format):
                    this.pckDate.Format = this.Format;
                    break;
            }
        }

        protected override void SetIsEnabled()
        {
            pckDate.IsEnabled = IsEnabled;
        }

        protected override void SetPadding()
        {
            frmContainer.Padding = Padding;
        }

        protected override void SetTextColor()
        {
            if (IsControlEnabled)
                pckDate.TextColor = IsControlFocused ? FocusedTextColor == Color.Transparent ? TextColor : FocusedTextColor : TextColor;
            else
                pckDate.TextColor = DisabledTextColor;
        }

        protected override void SetFontSize()
        {
            pckDate.FontSize = FontSize;
        }

        protected override void SetFontFamily()
        {
            pckDate.FontFamily = FontFamily;
        }

        protected override void SetPlaceholder()
        {
            pckDate.Placeholder = Placeholder;
        }

        protected override void SetPlaceholderColor()
        {
            pckDate.PlaceholderColor = PlaceholderColor;
        }

        protected override void SetHorizontalTextAlignment()
        {
            pckDate.HorizontalTextAlignment = HorizontalTextAlignment;
        }

        public new bool Focus()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                pckDate.Focus();
            });
            return true;
        }

        public new bool Unfocus()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                pckDate.Unfocus();
            });
            return true;
        }

        private void HandleFocusChange(object sender, FocusEventArgs e)
        {
            base.SetFocusChange(lblLabel, frmContainer, bxvLine);

            // Set the default date if the user doesn't select anything
            if (!IsControlFocused && !pckDate.Date.HasValue)
                Date = pckDate.InternalDateTime;

            if (IsControlFocused)
                Focused?.Invoke(this, e);
            else
                Unfocused?.Invoke(this, e);
        }

        #endregion Methods
    }
}
