using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialEntry : ContentView, IFieldControl
    {
        #region Constructors

        public MaterialEntry()
        {
            if (!this.initialized)
            {
                this.InitializeComponent();
                this.initialized = true;
            }

            this.txtEntry.Focused += Handle_Focused;
            this.txtEntry.Unfocused += Handle_Unfocused;
            this.txtEntry.TextChanged += TxtEntry_TextChanged;

            TapGestureRecognizer clearTapGestureRecognizer = new TapGestureRecognizer();
            clearTapGestureRecognizer.Tapped += (s, e) =>
            {
                this.Text = string.Empty;
                this.txtEntry.Text = string.Empty;
            };
            this.imgClearIcon.GestureRecognizers.Add(clearTapGestureRecognizer);

            TapGestureRecognizer showPasswordTapGestureRecognizer = new TapGestureRecognizer();
            showPasswordTapGestureRecognizer.Tapped += (s, e) =>
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
            this.imgShowPasswordIcon.GestureRecognizers.Add(showPasswordTapGestureRecognizer);
        }

        #endregion Constructors

        #region Attributes

        private bool initialized = false;

        private bool passwordIsVisible = false;

        #endregion Attributes

        #region Properties

        public static readonly BindableProperty TypeProperty =
            BindableProperty.Create(nameof(Type), typeof(FieldTypes), typeof(MaterialEntry), defaultValue: FieldTypes.Filled);

        public FieldTypes Type
        {
            get { return (FieldTypes)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

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

        public static readonly BindableProperty KeyboardProperty =
            BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(MaterialEntry), defaultValue: Keyboard.Text);

        public Keyboard Keyboard
        {
            get { return (Keyboard)GetValue(KeyboardProperty); }
            set { SetValue(KeyboardProperty, value); }
        }

        public static readonly BindableProperty LabelTextProperty =
            BindableProperty.Create(nameof(LabelText), typeof(string), typeof(MaterialEntry), defaultValue: null);

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialEntry), defaultValue: null, propertyChanged: OnTextChanged, defaultBindingMode: BindingMode.TwoWay);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty PlaceholderProperty =
            BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(MaterialEntry), defaultValue: null);

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public static readonly BindableProperty AssistiveTextProperty =
            BindableProperty.Create(nameof(AssistiveText), typeof(string), typeof(MaterialEntry), defaultValue: null);

        public string AssistiveText
        {
            get { return (string)GetValue(AssistiveTextProperty); }
            set { SetValue(AssistiveTextProperty, value); }
        }

        public static readonly BindableProperty LabelTextColorProperty =
            BindableProperty.Create(nameof(LabelTextColor), typeof(Color), typeof(MaterialEntry), defaultValue: Color.Gray);

        public Color LabelTextColor
        {
            get { return (Color)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public static readonly BindableProperty FocusedLabelTextColorProperty =
            BindableProperty.Create(nameof(FocusedLabelTextColor), typeof(Color), typeof(MaterialEntry), defaultValue: Color.Gray);

        public Color FocusedLabelTextColor
        {
            get { return (Color)GetValue(FocusedLabelTextColorProperty); }
            set { SetValue(FocusedLabelTextColorProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialEntry), defaultValue: Color.Gray);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty PlaceholderColorProperty =
            BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(MaterialEntry), defaultValue: Color.Gray);

        public Color PlaceholderColor
        {
            get { return (Color)GetValue(PlaceholderColorProperty); }
            set { SetValue(PlaceholderColorProperty, value); }
        }

        public static readonly BindableProperty AssistiveTextColorProperty =
            BindableProperty.Create(nameof(AssistiveTextColor), typeof(Color), typeof(MaterialEntry), defaultValue: Color.Gray);

        public Color AssistiveTextColor
        {
            get { return (Color)GetValue(AssistiveTextColorProperty); }
            set { SetValue(AssistiveTextColorProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialEntry), defaultValue: Color.LightGray);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty LabelSizeProperty =
            BindableProperty.Create(nameof(LabelSize), typeof(double), typeof(MaterialEntry), defaultValue: Font.Default.FontSize);

        public double LabelSize
        {
            get { return (double)GetValue(LabelSizeProperty); }
            set { SetValue(LabelSizeProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MaterialEntry), defaultValue: 14.0);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty AssistiveSizeProperty =
            BindableProperty.Create(nameof(AssistiveSize), typeof(double), typeof(MaterialEntry), defaultValue: Font.Default.FontSize);

        public double AssistiveSize
        {
            get { return (double)GetValue(AssistiveSizeProperty); }
            set { SetValue(AssistiveSizeProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(MaterialEntry), defaultValue: Color.LightGray);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty FocusedBorderColorProperty =
            BindableProperty.Create(nameof(FocusedBorderColor), typeof(Color), typeof(MaterialEntry), defaultValue: Color.LightGray);

        public Color FocusedBorderColor
        {
            get { return (Color)GetValue(FocusedBorderColorProperty); }
            set { SetValue(FocusedBorderColorProperty, value); }
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

        public static readonly BindableProperty LeadingIconProperty =
            BindableProperty.Create(nameof(LeadingIcon), typeof(string), typeof(MaterialEntry), defaultValue: null);

        public string LeadingIcon
        {
            get { return (string)GetValue(LeadingIconProperty); }
            set { SetValue(LeadingIconProperty, value); }
        }

        public bool LeadingIconIsVisible
        {
            get { return !string.IsNullOrEmpty(this.LeadingIcon); }
        }

        public static readonly BindableProperty TrailingIconProperty =
            BindableProperty.Create(nameof(TrailingIcon), typeof(string), typeof(MaterialEntry), defaultValue: null);

        public string TrailingIcon
        {
            get { return (string)GetValue(TrailingIconProperty); }
            set { SetValue(TrailingIconProperty, value); }
        }

        public bool TrailingIconIsVisible
        {
            get { return !string.IsNullOrEmpty(this.TrailingIcon); }
        }

        public static readonly BindableProperty MaxLengthProperty =
            BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(MaterialEntry), defaultValue: Int32.MaxValue);

        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }

        public static readonly BindableProperty RegexValidationProperty =
            BindableProperty.Create(nameof(RegexValidation), typeof(string), typeof(MaterialEntry), defaultValue: null);

        public string RegexValidation
        {
            get { return (string)GetValue(RegexValidationProperty); }
            set { SetValue(RegexValidationProperty, value); }
        }

        public static readonly BindableProperty InvalidMessageProperty =
            BindableProperty.Create(nameof(InvalidMessage), typeof(string), typeof(MaterialEntry), defaultValue: null);

        public string InvalidMessage
        {
            get { return (string)GetValue(InvalidMessageProperty); }
            set { SetValue(InvalidMessageProperty, value); }
        }

        public static readonly BindableProperty RequiredMessageProperty =
            BindableProperty.Create(nameof(RequiredMessage), typeof(string), typeof(MaterialEntry), defaultValue: null);

        public string RequiredMessage
        {
            get { return (string)GetValue(RequiredMessageProperty); }
            set { SetValue(RequiredMessageProperty, value); }
        }

        public static readonly BindableProperty IsRequiredProperty =
            BindableProperty.Create(nameof(IsRequired), typeof(bool), typeof(MaterialEntry), defaultValue: false);

        public bool IsRequired
        {
            get { return (bool)GetValue(IsRequiredProperty); }
            set { SetValue(IsRequiredProperty, value); }
        }

        public static readonly BindableProperty IsValidProperty =
            BindableProperty.Create(nameof(IsValid), typeof(bool), typeof(MaterialEntry), defaultValue: true, defaultBindingMode: BindingMode.OneWayToSource);

        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            set { SetValue(IsValidProperty, value); }
        }

        public static readonly BindableProperty FieldNameProperty =
            BindableProperty.Create(nameof(FieldName), typeof(string), typeof(MaterialEntry), defaultValue: null, propertyChanged: OnFieldNameChanged);

        public string FieldName
        {
            get { return (string)GetValue(FieldNameProperty); }
            set { SetValue(FieldNameProperty, value); }
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

        private static void OnFieldNameChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialEntry)bindable;
            FieldsValidator.RegisterControl(control);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!this.initialized)
            {
                this.InitializeComponent();
                this.initialized = true;
            }

            // TODO: Check if you can take out the strong password.

            switch (propertyName)
            {
                case nameof(this.IsEnabled):
                    this.txtEntry.IsEnabled = this.IsEnabled;
                    break;
                case nameof(this.TextColor):
                    this.txtEntry.TextColor = this.TextColor;
                    break;
                case nameof(this.FontSize):
                    this.txtEntry.FontSize = this.FontSize;
                    break;
                case nameof(this.Placeholder):
                    this.txtEntry.Placeholder = this.Placeholder;
                    break;
                case nameof(this.PlaceholderColor):
                    this.txtEntry.PlaceholderColor = this.PlaceholderColor;
                    break;
                case nameof(this.Keyboard):
                    this.txtEntry.Keyboard = this.Keyboard;
                    break;
                case nameof(this.MaxLength):
                    this.txtEntry.MaxLength = this.MaxLength;
                    break;

                case nameof(this.LabelText):
                    this.lblLabel.Text = this.LabelText;
                    break;
                case nameof(this.LabelTextColor):
                    this.lblLabel.TextColor = this.LabelTextColor;
                    break;
                case nameof(this.LabelSize):
                    this.lblLabel.FontSize = this.LabelSize;
                    break;

                case nameof(this.Padding):
                    this.frmContainer.Padding = this.Padding;
                    break;

                case nameof(this.Type):
                case nameof(this.BackgroundColor):
                case nameof(this.BorderColor):
                    switch (this.Type)
                    {
                        case FieldTypes.Filled:
                            this.frmContainer.BackgroundColor = this.BackgroundColor;
                            this.frmContainer.BorderColor = this.BorderColor;
                            this.frmContainer.CornerRadius = 20;
                            this.bxvLine.IsVisible = false;
                            break;
                        case FieldTypes.Outlined:
                            this.frmContainer.BackgroundColor = this.BackgroundColor;
                            this.frmContainer.BorderColor = this.BorderColor;
                            this.frmContainer.CornerRadius = 4;
                            this.bxvLine.IsVisible = false;
                            break;
                        case FieldTypes.Lined:
                            this.frmContainer.BackgroundColor = Color.Transparent;
                            this.frmContainer.BorderColor = Color.Transparent;
                            this.bxvLine.IsVisible = true;
                            this.bxvLine.Color = this.BorderColor;

                            this.frmContainer.HeightRequest = 30;

                            if (this.LeadingIconIsVisible)
                            {
                                this.lblLabel.Margin = new Thickness(36, this.lblLabel.Margin.Top,
                                                                    this.lblLabel.Margin.Right, 0);
                                this.frmContainer.Padding = new Thickness(0);
                                this.lblAssistive.Margin = new Thickness(36, this.lblAssistive.Margin.Top,
                                                                    this.lblAssistive.Margin.Right, this.lblAssistive.Margin.Bottom);
                                this.bxvLine.Margin = new Thickness(36, 0, 0, 0);
                            }
                            else
                            {
                                this.lblLabel.Margin = new Thickness(0, this.lblLabel.Margin.Top, 0, 0);
                                this.frmContainer.Padding = new Thickness(0);
                                this.lblAssistive.Margin = new Thickness(0, this.lblAssistive.Margin.Top, 0, this.lblAssistive.Margin.Bottom);
                            }
                            break;
                    }
                    break;

                case nameof(this.AssistiveText):
                    this.lblAssistive.Text = this.AssistiveText;
                    break;
                case nameof(this.AssistiveTextColor):
                    this.lblAssistive.TextColor = this.AssistiveTextColor;
                    break;
                case nameof(this.AssistiveSize):
                    this.lblAssistive.FontSize = this.AssistiveSize;
                    break;

                case nameof(this.IsPassword):
                case nameof(this.ShowPasswordIcon):
                case nameof(this.ShowPasswordIconIsVisible):
                    this.txtEntry.IsPassword = this.IsPassword;
                    if (!string.IsNullOrEmpty(this.ShowPasswordIcon))
                    {
                        this.imgShowPasswordIcon.Source = this.ShowPasswordIcon;
                    }
                    this.imgShowPasswordIcon.IsVisible = this.IsPassword && this.ShowPasswordIconIsVisible && !string.IsNullOrEmpty(this.ShowPasswordIcon);
                    break;
                case nameof(this.ClearIcon):
                case nameof(this.ClearIconIsVisible):
                    if (!string.IsNullOrEmpty(this.ClearIcon))
                    {
                        this.imgClearIcon.Source = this.ClearIcon;
                    }
                    this.imgClearIcon.IsVisible = this.ClearIconIsVisible && this.IsEnabled && !string.IsNullOrEmpty(this.Text);
                    break;
                case nameof(this.LeadingIcon):
                    if (!string.IsNullOrEmpty(this.LeadingIcon))
                    {
                        this.imgLeadingIcon.Source = this.LeadingIcon;
                    }
                    this.imgLeadingIcon.IsVisible = this.LeadingIconIsVisible;
                    break;
                case nameof(this.TrailingIcon):
                    if (!string.IsNullOrEmpty(this.TrailingIcon))
                    {
                        this.imgTrailingIcon.Source = this.TrailingIcon;
                    }
                    this.imgTrailingIcon.IsVisible = this.TrailingIconIsVisible;
                    break;

                case nameof(this.RegexValidation):
                case nameof(this.IsRequired):
                    if (!string.IsNullOrEmpty(this.RegexValidation) || this.IsRequired)
                    {
                        this.IsValid = false;
                    }
                    break;
            }
        }

        private void Handle_Focused(object sender, FocusEventArgs e)
        {
            this.lblLabel.TextColor = this.FocusedLabelTextColor;

            switch (this.Type)
            {
                case FieldTypes.Filled:
                case FieldTypes.Outlined:
                    this.frmContainer.BorderColor = this.FocusedBorderColor;
                    break;
                case FieldTypes.Lined:
                    this.bxvLine.Color = this.FocusedBorderColor;
                    break;
            }
        }

        private void Handle_Unfocused(object sender, FocusEventArgs e)
        {
            this.lblLabel.TextColor = this.LabelTextColor;

            switch (this.Type)
            {
                case FieldTypes.Filled:
                case FieldTypes.Outlined:
                    this.frmContainer.BorderColor = this.BorderColor;
                    break;
                case FieldTypes.Lined:
                    this.bxvLine.Color = this.BorderColor;
                    break;
            }
        }

        private void TxtEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.ClearIconIsVisible && this.IsEnabled)
            {
                this.imgClearIcon.IsVisible = !string.IsNullOrEmpty(e.NewTextValue);
            }

            this.Text = this.txtEntry.Text;

            this.Validate();

            this.TextChanged?.Invoke(this, e);
        }

        public bool Validate()
        {
            if (this.IsRequired && string.IsNullOrWhiteSpace(this.Text))
            {
                this.AssistiveText = this.RequiredMessage;
                this.IsValid = false;
            }
            else if (!string.IsNullOrEmpty(this.RegexValidation) && this.Text == null)
            {
                this.AssistiveText = this.InvalidMessage;
                this.IsValid = false;
            }
            else if (!string.IsNullOrEmpty(this.RegexValidation))
            {
                var match = Regex.Match(this.Text, this.RegexValidation, RegexOptions.IgnoreCase);
                this.AssistiveText = !match.Success ? this.InvalidMessage : string.Empty;
                this.IsValid = match.Success;
            }
            else
            {
                this.AssistiveText = string.Empty;
                this.IsValid = true;
            }
            return this.IsValid;
        }

        #endregion Methods
    }
}
