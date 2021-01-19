using System;
using System.Runtime.CompilerServices;
using Plugin.MaterialDesignControls.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialEntry : BaseMaterialFieldControl
    {
        #region Constructors

        public MaterialEntry()
        {
            if (!this.initialized)
            {
                this.initialized = true;
                this.InitializeComponent();
            }

            this.txtEntry.Focused += HandleFocusChange;
            this.txtEntry.Unfocused += HandleFocusChange;
            this.txtEntry.TextChanged += TxtEntry_TextChanged;

            this.imgClearIcon.Tapped = () =>
            {
                this.Text = string.Empty;
                this.txtEntry.Text = string.Empty;
            };

            this.imgShowPasswordIcon.Tapped = () =>
            {
                if (this.passwordIsVisible)
                {
                    this.txtEntry.IsPassword = true;
                    this.passwordIsVisible = false;
                }
                else
                {
                    this.txtEntry.IsPassword = false;
                    this.passwordIsVisible = true;
                }
            };

            TapGestureRecognizer frameTapGestureRecognizer = new TapGestureRecognizer();
            frameTapGestureRecognizer.Tapped += (s, e) =>
            {
                this.txtEntry.Focus();
            };
            this.frmContainer.GestureRecognizers.Add(frameTapGestureRecognizer);
        }

        #endregion Constructors

        #region Attributes

        private bool initialized = false;

        private bool passwordIsVisible = false;

        #endregion Attributes

        #region Properties

        public static readonly new BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(MaterialEntry), defaultValue: new Thickness(12, 0));

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        public static readonly new BindableProperty IsEnabledProperty =
            BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(MaterialEntry), defaultValue: true);

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public static readonly BindableProperty IsPasswordProperty =
            BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(MaterialEntry), defaultValue: false);

        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
        }

        public static readonly BindableProperty IsCodeProperty =
            BindableProperty.Create(nameof(IsCode), typeof(bool), typeof(MaterialEntry), defaultValue: false);

        public bool IsCode
        {
            get { return (bool)GetValue(IsCodeProperty); }
            set { SetValue(IsCodeProperty, value); }
        }

        public static readonly BindableProperty KeyboardProperty =
            BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(MaterialEntry), defaultValue: Keyboard.Text);

        public Keyboard Keyboard
        {
            get { return (Keyboard)GetValue(KeyboardProperty); }
            set { SetValue(KeyboardProperty, value); }
        }

        public static readonly BindableProperty ReturnTypeProperty =
            BindableProperty.Create(nameof(ReturnType), typeof(ReturnType), typeof(MaterialEntry), defaultValue: null);

        public ReturnType ReturnType
        {
            get { return (ReturnType)GetValue(ReturnTypeProperty); }
            set { SetValue(ReturnTypeProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialEntry), defaultValue: null, propertyChanged: OnTextChanged, defaultBindingMode: BindingMode.TwoWay);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialEntry), defaultValue: Color.LightGray);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty ClearIconProperty =
            BindableProperty.Create(nameof(ClearIcon), typeof(string), typeof(MaterialEntry), defaultValue: null);

        public string ClearIcon
        {
            get { return (string)GetValue(ClearIconProperty); }
            set { SetValue(ClearIconProperty, value); }
        }

        public static readonly BindableProperty ClearIconIsVisibleProperty =
            BindableProperty.Create(nameof(ClearIconIsVisible), typeof(bool), typeof(MaterialEntry), defaultValue: true);

        public bool ClearIconIsVisible
        {
            get { return (bool)GetValue(ClearIconIsVisibleProperty); }
            set { SetValue(ClearIconIsVisibleProperty, value); }
        }

        public static readonly BindableProperty ShowPasswordIconProperty =
            BindableProperty.Create(nameof(ShowPasswordIcon), typeof(string), typeof(MaterialEntry), defaultValue: null);

        public string ShowPasswordIcon
        {
            get { return (string)GetValue(ShowPasswordIconProperty); }
            set { SetValue(ShowPasswordIconProperty, value); }
        }

        public static readonly BindableProperty ShowPasswordIconIsVisibleProperty =
            BindableProperty.Create(nameof(ShowPasswordIconIsVisible), typeof(bool), typeof(MaterialEntry), defaultValue: true);

        public bool ShowPasswordIconIsVisible
        {
            get { return (bool)GetValue(ShowPasswordIconIsVisibleProperty); }
            set { SetValue(ShowPasswordIconIsVisibleProperty, value); }
        }

        public static readonly BindableProperty MaxLengthProperty =
            BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(MaterialEntry), defaultValue: Int32.MaxValue);

        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }

        public override bool IsControlFocused
        {
            get { return txtEntry.IsFocused; }
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

        public event EventHandler TextChanged;

        #endregion Events

        #region Methods

        private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialEntry)bindable;
            control.txtEntry.Text = (string)newValue;
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
                case nameof(this.Keyboard):
                    this.txtEntry.Keyboard = this.Keyboard;
                    break;
                case nameof(this.MaxLength):
                    this.txtEntry.MaxLength = this.MaxLength;
                    break;
                case nameof(this.IsPassword):
                case nameof(this.ShowPasswordIcon):
                case nameof(this.ShowPasswordIconIsVisible):
                    this.txtEntry.IsPassword = this.IsPassword;
                    if (!string.IsNullOrEmpty(this.ShowPasswordIcon))
                    {
                        this.imgShowPasswordIcon.Image.Source = this.ShowPasswordIcon;
                    }
                    this.imgShowPasswordIcon.IsVisible = this.IsPassword && this.ShowPasswordIconIsVisible && !string.IsNullOrEmpty(this.ShowPasswordIcon);
                    break;
                case nameof(this.ClearIcon):
                case nameof(this.ClearIconIsVisible):
                    if (!string.IsNullOrEmpty(this.ClearIcon))
                    {
                        this.imgClearIcon.Image.Source = this.ClearIcon;
                    }
                    this.imgClearIcon.IsVisible = this.ClearIconIsVisible && this.IsControlEnabled && !string.IsNullOrEmpty(this.Text);
                    break;
                case nameof(this.TabIndex):
                    if (this.TabIndex != 0)
                    {
                        this.txtEntry.TabIndex = this.TabIndex;
                        this.TabIndex = 0;
                    }
                    break;
                case nameof(this.IsTabStop):
                    this.txtEntry.IsTabStop = this.IsTabStop;
                    break;
                case nameof(this.ReturnType):
                    this.txtEntry.ReturnType = this.ReturnType;

                    if (this.ReturnType.Equals(Xamarin.Forms.ReturnType.Next))
                    {
                        this.txtEntry.ReturnCommand = new Command(() =>
                        {
                            var currentTabIndex = this.txtEntry.TabIndex;
                            this.FocusNextElement(currentTabIndex);
                        });
                    }
                    break;
                case nameof(this.IsCode):
                    this.txtEntry.IsCode = this.IsCode;
                    break;
            }
        }

        protected override void SetIsEnabled()
        {
            txtEntry.IsEnabled = IsEnabled;
        }

        protected override void SetPadding()
        {
            frmContainer.Padding = Padding;
        }

        protected override void SetTextColor()
        {
            if (IsControlEnabled)
                txtEntry.TextColor = IsControlFocused ? FocusedTextColor : TextColor;
            else
                txtEntry.TextColor = DisabledTextColor;
        }

        protected override void SetFontSize()
        {
            txtEntry.FontSize = FontSize;
        }

        protected override void SetFontFamily()
        {
            txtEntry.FontFamily = FontFamily;
        }

        protected override void SetPlaceholder()
        {
            txtEntry.Placeholder = Placeholder;
        }

        protected override void SetPlaceholderColor()
        {
            txtEntry.PlaceholderColor = PlaceholderColor;
        }

        public new bool Focus()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                this.txtEntry.Focus();
            });
            return true;
        }

        private void HandleFocusChange(object sender, FocusEventArgs e)
        {
            base.SetFocusChange(lblLabel, frmContainer, bxvLine);
        }

        private void TxtEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.ClearIconIsVisible && this.IsControlEnabled)
            {
                this.imgClearIcon.IsVisible = !string.IsNullOrEmpty(e.NewTextValue);
            }

            this.Text = this.txtEntry.Text;
            this.TextChanged?.Invoke(this, e);
        }

        private void FocusNextElement(int currentTabIndex)
        {
            try
            {
                var tabIndexes = this.GetTabIndexesOnParentPage(out int count);

                if (tabIndexes != null)
                {
                    var nextElement = this.FindNextElement(true, tabIndexes, ref currentTabIndex);
                    if (nextElement != null)
                    {
                        if (nextElement is CustomEntry nextEntry && nextEntry.IsEnabled)
                        {
                            nextEntry.Focus();
                            string textInsideInput = nextEntry.Text;
                            nextEntry.CursorPosition = string.IsNullOrEmpty(textInsideInput) ? 0 : textInsideInput.Length;
                        }
                        else
                        {
                            this.FocusNextElement(currentTabIndex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        #endregion Methods
    }
}