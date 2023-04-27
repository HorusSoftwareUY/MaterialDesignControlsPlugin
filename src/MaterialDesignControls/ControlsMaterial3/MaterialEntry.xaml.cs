using Plugin.MaterialDesignControls.Implementations;
using Plugin.MaterialDesignControls.Utils;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls.Material3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialEntry : ContentView
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

            //TODO: check for future
            //imgClearIcon.Command = new Command(() =>
            //{
            //    Text = string.Empty;
            //    txtEntry.Text = string.Empty;
            //});

            //imgShowPasswordIcon.Command = new Command(() =>
            //{
            //    if (passwordIsVisible)
            //    {
            //        txtEntry.IsPassword = true;
            //        passwordIsVisible = false;

            //        // Display the show password icon
            //        if (CustomShowPasswordIcon != null)
            //            imgShowPasswordIcon.SetCustomImage(CustomShowPasswordIcon);
            //        else if (!string.IsNullOrEmpty(ShowPasswordIcon))
            //            imgShowPasswordIcon.SetImage(ShowPasswordIcon);
            //    }
            //    else
            //    {
            //        txtEntry.IsPassword = false;
            //        passwordIsVisible = true;

            //        // Display the hide password icon
            //        if (CustomHidePasswordIcon != null)
            //            imgShowPasswordIcon.SetCustomImage(CustomHidePasswordIcon);
            //        else if (!string.IsNullOrEmpty(HidePasswordIcon))
            //            imgShowPasswordIcon.SetImage(HidePasswordIcon);
            //    }
            //});

            TapGestureRecognizer frameTapGestureRecognizer = new TapGestureRecognizer();
            frameTapGestureRecognizer.Tapped +=  (s, e) =>
            {
                this.txtEntry.Focus();
            };
            //this.GetFrameContainer.GestureRecognizers.Add(frameTapGestureRecognizer);
        }

        #endregion Constructors

        #region Attributes

        private bool initialized = false;

        //private bool passwordIsVisible = false;

        #endregion Attributes

        #region Properties

        public static readonly new BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(MaterialEntry), defaultValue: new Thickness(16, 0));

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

        public static readonly BindableProperty KeyboardFlagsProperty =
            BindableProperty.Create(nameof(KeyboardFlags), typeof(string), typeof(MaterialEntry), defaultValue: null);

        public string KeyboardFlags
        {
            get { return (string)GetValue(KeyboardFlagsProperty); }
            set { SetValue(KeyboardFlagsProperty, value); }
        }

        public static readonly BindableProperty TextTransformProperty =
            BindableProperty.Create(nameof(TextTransform), typeof(TextTransforms), typeof(MaterialEntry), defaultValue: TextTransforms.Default);

        public TextTransforms TextTransform
        {
            get { return (TextTransforms)GetValue(TextTransformProperty); }
            set { SetValue(TextTransformProperty, value); }
        }

        public static readonly BindableProperty ReturnTypeProperty =
            BindableProperty.Create(nameof(ReturnType), typeof(ReturnType), typeof(MaterialEntry), defaultValue: ReturnType.Default);

        public ReturnType ReturnType
        {
            get { return (ReturnType)GetValue(ReturnTypeProperty); }
            set { SetValue(ReturnTypeProperty, value); }
        }

        public static readonly BindableProperty ReturnCommandProperty =
            BindableProperty.Create(nameof(ReturnCommand), typeof(ICommand), typeof(MaterialEntry), defaultValue: null);

        public ICommand ReturnCommand
        {
            get { return (ICommand)GetValue(ReturnCommandProperty); }
            set { SetValue(ReturnCommandProperty, value); }
        }

        public static readonly BindableProperty ReturnCommandParameterProperty =
            BindableProperty.Create(nameof(ReturnCommandParameter), typeof(object), typeof(MaterialEntry), defaultValue: null);

        public object ReturnCommandParameter
        {
            get { return (object)GetValue(ReturnCommandParameterProperty); }
            set { SetValue(ReturnCommandParameterProperty, value); }
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

        public static readonly BindableProperty CustomClearIconProperty =
            BindableProperty.Create(nameof(CustomClearIcon), typeof(View), typeof(MaterialEntry), defaultValue: null);

        public View CustomClearIcon
        {
            get { return (View)GetValue(CustomClearIconProperty); }
            set { SetValue(CustomClearIconProperty, value); }
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

        public static readonly BindableProperty HidePasswordIconProperty =
            BindableProperty.Create(nameof(HidePasswordIcon), typeof(string), typeof(MaterialEntry), defaultValue: null);

        public string HidePasswordIcon
        {
            get { return (string)GetValue(HidePasswordIconProperty); }
            set { SetValue(HidePasswordIconProperty, value); }
        }

        public static readonly BindableProperty CustomShowPasswordIconProperty =
            BindableProperty.Create(nameof(CustomShowPasswordIcon), typeof(View), typeof(MaterialEntry), defaultValue: null);

        public View CustomShowPasswordIcon
        {
            get { return (View)GetValue(CustomShowPasswordIconProperty); }
            set { SetValue(CustomShowPasswordIconProperty, value); }
        }

        public static readonly BindableProperty CustomHidePasswordIconProperty =
            BindableProperty.Create(nameof(CustomHidePasswordIcon), typeof(View), typeof(MaterialEntry), defaultValue: null);

        public View CustomHidePasswordIcon
        {
            get { return (View)GetValue(CustomHidePasswordIconProperty); }
            set { SetValue(CustomHidePasswordIconProperty, value); }
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

        public static readonly BindableProperty CursorPositionProperty =
            BindableProperty.Create(nameof(CursorPosition), typeof(int), typeof(MaterialEntry), defaultValue: 0);

        public int CursorPosition
        {
            get { return (int)GetValue(CursorPositionProperty); }
            set { SetValue(CursorPositionProperty, value); }
        }

        //public override bool IsControlFocused
        //{
        //    get { return txtEntry.IsFocused; }
        //}

        //public override bool IsControlEnabled
        //{
        //    get { return this.IsEnabled; }
        //}

        //public override Color BackgroundColorControl
        //{
        //    get { return this.BackgroundColor; }
        //}

        #endregion Properties

        #region Events

        public event EventHandler TextChanged;

        public new event EventHandler<FocusEventArgs> Focused;

        public new event EventHandler<FocusEventArgs> Unfocused;

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

            //UpdateLayout(propertyName);

            switch (propertyName)
            {
                case nameof(base.TranslationX):
                    base.OnPropertyChanged(propertyName);
                    break;

                case nameof(this.Keyboard):
                    this.txtEntry.Keyboard = this.Keyboard;
                    break;
                case nameof(KeyboardFlags):
                    if (KeyboardFlags != null)
                    {
                        try
                        {
                            string[] flagNames = ((string)KeyboardFlags).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            KeyboardFlags allFlags = 0;
                            foreach (var flagName in flagNames)
                            {
                                KeyboardFlags flags = 0;
                                Enum.TryParse<KeyboardFlags>(flagName.Trim(), out flags);
                                if (flags != 0)
                                    allFlags |= flags;
                            }
                            txtEntry.Keyboard = Keyboard.Create(allFlags);
                        }
                        catch
                        {
                            throw new XamlParseException("The keyboard flags are invalid or have a wrong specification.");
                        }
                    }
                    break;
                case nameof(TextTransform):
                    ApplyTextTransform();
                    break;

                case nameof(this.MaxLength):
                    this.txtEntry.MaxLength = this.MaxLength;
                    break;

                case nameof(this.CursorPosition):
                    this.txtEntry.CursorPosition = this.CursorPosition;
                    break;

                //case nameof(IsPassword):
                //    this.txtEntry.IsPassword = IsPassword;
                //    SetShowPasswordIconIsVisible();
                //    break;
                //case nameof(ShowPasswordIcon):
                //    if (!string.IsNullOrEmpty(ShowPasswordIcon))
                //        imgShowPasswordIcon.SetImage(ShowPasswordIcon);

                //    SetShowPasswordIconIsVisible();
                //    break;
                //case nameof(CustomShowPasswordIcon):
                //    if (CustomShowPasswordIcon != null)
                //        imgShowPasswordIcon.SetCustomImage(CustomShowPasswordIcon);

                //    SetShowPasswordIconIsVisible();
                //    break;
                //case nameof(ShowPasswordIconIsVisible):
                //    SetShowPasswordIconIsVisible();
                //    break;
                
                //case nameof(this.ClearIcon):
                //    if (!string.IsNullOrEmpty(this.ClearIcon))
                //        imgClearIcon.SetImage(ClearIcon);

                //    SetClearIconIsVisible();
                //    break;
                //case nameof(CustomClearIcon):
                //    if (CustomClearIcon != null)
                //        imgClearIcon.SetCustomImage(CustomClearIcon);

                //    SetClearIconIsVisible();
                //    break;
                //case nameof(this.ClearIconIsVisible):
                //    SetClearIconIsVisible();
                //    break;

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

                    if (this.ReturnType.Equals(Xamarin.Forms.ReturnType.Next) && this.ReturnCommand == null)
                    {
                        this.txtEntry.ReturnCommand = new Command(() =>
                        {
                            var currentTabIndex = this.txtEntry.TabIndex;
                            this.FocusNextElement(currentTabIndex);
                        });
                    }
                    break;
                case nameof(this.ReturnCommand):
                    this.txtEntry.ReturnCommand = this.ReturnCommand;
                    break;
                case nameof(this.ReturnCommandParameter):
                    this.txtEntry.ReturnCommandParameter = this.ReturnCommandParameter;
                    break;
                case nameof(this.IsCode):
                    this.txtEntry.IsCode = this.IsCode;
                    break;
            }
        }

        //private void SetShowPasswordIconIsVisible()
        //{
        //    imgShowPasswordIcon.IsVisible = IsPassword && ShowPasswordIconIsVisible && IsEnabled
        //        && (!string.IsNullOrEmpty(ShowPasswordIcon) || CustomShowPasswordIcon != null);
        //}

        //private void SetClearIconIsVisible()
        //{
        //    imgClearIcon.IsVisible = ClearIconIsVisible && IsEnabled && !string.IsNullOrEmpty(Text)
        //        && (!string.IsNullOrEmpty(ClearIcon) || CustomClearIcon != null);
        //}

        //protected override void SetIsEnabled()
        //{
        //    if (Device.RuntimePlatform == Device.iOS)
        //        txtEntry.IsEnabled = IsEnabled;
        //    else
        //    {
        //        // Workaround to a disabled text color issue in Android
        //        txtEntry.IsReadOnly = !IsEnabled;
        //    }
        //}

        //protected override void SetPadding()
        //{
        //    this.GetFrameContainer.Padding = Padding;
        //}

        //protected override void SetTextColor()
        //{
        //    if (IsControlEnabled)
        //        txtEntry.TextColor = IsControlFocused && FocusedTextColor != Color.Transparent ? FocusedTextColor : TextColor;
        //    else
        //        txtEntry.TextColor = DisabledTextColor;
        //}

        //protected override void SetFontSize()
        //{
        //    txtEntry.FontSize = FontSize;
        //}

        //protected override void SetFontFamily()
        //{
        //    txtEntry.FontFamily = FontFamily;
        //}

        //protected override void SetPlaceholder()
        //{
        //    txtEntry.Placeholder = Placeholder;
        //}

        //protected override void SetPlaceholderColor()
        //{
        //    txtEntry.PlaceholderColor = PlaceholderColor;
        //}

        //protected override void SetHorizontalTextAlignment()
        //{
        //    txtEntry.HorizontalTextAlignment = HorizontalTextAlignment;
        //}

        public new bool Focus()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                txtEntry.Focus();
            });
            return true;
        }

        public new bool Unfocus()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                txtEntry.Unfocus();
            });
            return true;
        }

        private void HandleFocusChange(object sender, FocusEventArgs e)
        {
            //base.SetFocusChange();

            //if (IsControlFocused)
            //{
            //    Focused?.Invoke(this, e);

            //    var textInsideInput = txtEntry.Text;
            //    txtEntry.CursorPosition = string.IsNullOrEmpty(textInsideInput) ? 0 : textInsideInput.Length;
            //}
            //else
            //    Unfocused?.Invoke(this, e);
        }

        private void TxtEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (this.ClearIconIsVisible && this.IsControlEnabled)
            //{
            //    this.imgClearIcon.IsVisible = !string.IsNullOrEmpty(e.NewTextValue);
            //}

            var changedByTextTransform = Text != null && txtEntry.Text != null && Text.ToLower() == txtEntry.Text.ToLower();

            this.Text = this.txtEntry.Text;

            if (!changedByTextTransform)
                this.TextChanged?.Invoke(this, e);

            ApplyTextTransform();
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
                        if (nextElement is CustomEntry nextEntry && nextEntry.IsEnabled && !nextEntry.IsReadOnly)
                        {
                            nextEntry.Focus();
                            string textInsideInput = nextEntry.Text;
                            nextEntry.CursorPosition = string.IsNullOrEmpty(textInsideInput) ? 0 : textInsideInput.Length;
                        }
                        else if (nextElement is CustomEditor nextEditor && nextEditor.IsEnabled && !nextEditor.IsReadOnly)
                        {
                            nextEditor.Focus();
                        }
                        else
                        {
                            this.FocusNextElement(++currentTabIndex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(ex);
            }
        }

        private void ApplyTextTransform()
        {
            if (TextTransform == TextTransforms.Default || txtEntry.Text == null)
                return;
            else if (TextTransform == TextTransforms.Lowercase)
                txtEntry.Text = txtEntry.Text.ToLower();
            else if (TextTransform == TextTransforms.Uppercase)
                txtEntry.Text = txtEntry.Text.ToUpper();
        }

        #endregion Methods
    }
}