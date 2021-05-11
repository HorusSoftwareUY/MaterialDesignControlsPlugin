using System;
using System.Runtime.CompilerServices;
using Plugin.MaterialDesignControls.Animations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialTimePicker : BaseMaterialFieldControl
    {
        #region Constructors

        public MaterialTimePicker()
        {
            if (!this.initialized)
            {
                this.initialized = true;
                this.InitializeComponent();
            }

            pckTime.Focused += HandleFocusChange;
            pckTime.Unfocused += HandleFocusChange;
            pckTime.SetBinding(TimePicker.TimeProperty, new Binding() { Source = this, Path = TimeProperty.PropertyName });

            TapGestureRecognizer frameTapGestureRecognizer = new TapGestureRecognizer();
            frameTapGestureRecognizer.Tapped += (s, e) =>
            {
                this.pckTime.Focus();
            };
            this.frmContainer.GestureRecognizers.Add(frameTapGestureRecognizer);

            this.imgClearIcon.Tapped = () =>
            {
                Time = null;
                pckTime.Time = null;
                SetClearIconIsVisible();
            };
        }

        #endregion Constructors

        #region Attributes

        private bool initialized = false;

        #endregion Attributes

        #region Properties

        public static readonly new BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(MaterialTimePicker), defaultValue: new Thickness(12, 0));

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        public static readonly BindableProperty ClearIconIsVisibleProperty =
                BindableProperty.Create(nameof(ClearIconIsVisible), typeof(bool), typeof(MaterialTimePicker), defaultValue: true);

        public bool ClearIconIsVisible
        {
            get { return (bool)GetValue(ClearIconIsVisibleProperty); }
            set { SetValue(ClearIconIsVisibleProperty, value); }
        }

        public static readonly BindableProperty TimeProperty =
            BindableProperty.Create(nameof(Time), typeof(TimeSpan?), typeof(MaterialTimePicker), defaultValue: null, propertyChanged: OnTimeChanged, defaultBindingMode: BindingMode.TwoWay);

        public TimeSpan? Time
        {
            get { return (TimeSpan?)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); SetClearIconIsVisible(); }
        }

        public static readonly BindableProperty FormatProperty =
            BindableProperty.Create(nameof(Format), typeof(string), typeof(MaterialTimePicker), defaultValue: null);

        public string Format
        {
            get { return (string)GetValue(FormatProperty); }
            set { SetValue(FormatProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialTimePicker), defaultValue: Color.LightGray);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty ClearIconProperty =
            BindableProperty.Create(nameof(ClearIcon), typeof(string), typeof(MaterialTimePicker), defaultValue: null);

        public string ClearIcon
        {
            get { return (string)GetValue(ClearIconProperty); }
            set { SetValue(ClearIconProperty, value); }
        }

        public static readonly BindableProperty CustomClearIconProperty =
            BindableProperty.Create(nameof(CustomClearIcon), typeof(View), typeof(MaterialTimePicker), defaultValue: null);

        public View CustomClearIcon
        {
            get { return (View)GetValue(CustomClearIconProperty); }
            set { SetValue(CustomClearIconProperty, value); }
        }

        public override bool IsControlFocused
        {
            get { return pckTime.IsFocused; }
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

        private static void OnTimeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialTimePicker)bindable;
            control.pckTime.Time = (TimeSpan?)newValue;
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
                case nameof(this.Format):
                    this.pckTime.Format = this.Format;
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
            }
        }

        private void SetClearIconIsVisible()
        {
            imgClearIcon.IsVisible = IsEnabled && ClearIconIsVisible &&  pckTime.Time.HasValue
                && (!string.IsNullOrEmpty(ClearIcon) || CustomClearIcon != null);
        }

        protected override void SetIsEnabled()
        {
            pckTime.IsEnabled = IsEnabled;
        }

        protected override void SetPadding()
        {
            frmContainer.Padding = Padding;
        }

        protected override void SetTextColor()
        {
            if (IsControlEnabled)
                pckTime.TextColor = IsControlFocused ? FocusedTextColor : TextColor;
            else
                pckTime.TextColor = DisabledTextColor;
        }

        protected override void SetFontSize()
        {
            pckTime.FontSize = FontSize;
        }

        protected override void SetFontFamily()
        {
            pckTime.FontFamily = FontFamily;
        }

        protected override void SetPlaceholder()
        {
            pckTime.Placeholder = Placeholder;
        }

        protected override void SetPlaceholderColor()
        {
            pckTime.PlaceholderColor = PlaceholderColor;
        }

        protected override void SetHorizontalTextAlignment()
        {
            pckTime.HorizontalTextAlignment = HorizontalTextAlignment;
        }

        public new bool Focus()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                pckTime.Focus();
            });
            return true;
        }

        public new bool Unfocus()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                pckTime.Unfocus();
            });
            return true;
        }

        private void HandleFocusChange(object sender, FocusEventArgs e)
        {
            base.SetFocusChange(lblLabel, frmContainer, bxvLine);

            // Set the default date if the user doesn't select anything
            if (!IsControlFocused && !pckTime.Time.HasValue)
                Time = pckTime.InternalTime;

            if (IsControlFocused)
                Focused?.Invoke(this, e);
            else
                Unfocused?.Invoke(this, e);
        }

        #endregion Methods
    }
}