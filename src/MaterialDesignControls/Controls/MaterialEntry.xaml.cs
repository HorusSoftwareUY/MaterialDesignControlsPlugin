using System;
using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls
{
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
            clearTapGestureRecognizer.Tapped += async (s, e) =>
            {
                this.Text = string.Empty;
                this.txtEntry.Text = string.Empty;
            };
            this.imgClearIcon.GestureRecognizers.Add(clearTapGestureRecognizer);

            TapGestureRecognizer showPasswordTapGestureRecognizer = new TapGestureRecognizer();
            showPasswordTapGestureRecognizer.Tapped += async (s, e) =>
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
            BindableProperty.Create(nameof(Type), typeof(FieldTypes), typeof(MaterialEntry), defaultValue: FieldTypes.Filled, propertyChanged: OnPropertyChanged);

        public FieldTypes Type
        {
            get { return (FieldTypes)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public static readonly new BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(MaterialEntry), defaultValue: new Thickness(12, 0), propertyChanged: OnPropertyChanged);

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        public static readonly new BindableProperty IsEnabledProperty =
            BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(MaterialEntry), defaultValue: true, propertyChanged: OnPropertyChanged);

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public static readonly BindableProperty IsPasswordProperty =
            BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(MaterialEntry), defaultValue: false, propertyChanged: OnPropertyChanged);

        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
        }

        public static readonly BindableProperty KeyboardProperty =
            BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(MaterialEntry), defaultValue: Keyboard.Text, propertyChanged: OnPropertyChanged);

        public Keyboard Keyboard
        {
            get { return (Keyboard)GetValue(KeyboardProperty); }
            set { SetValue(KeyboardProperty, value); }
        }

        public static readonly BindableProperty LabelTextProperty =
            BindableProperty.Create(nameof(LabelText), typeof(string), typeof(MaterialEntry), defaultValue: null, propertyChanged: OnPropertyChanged);

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
            BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(MaterialEntry), defaultValue: null, propertyChanged: OnPropertyChanged);

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public static readonly BindableProperty AssistiveTextProperty =
            BindableProperty.Create(nameof(AssistiveText), typeof(string), typeof(MaterialEntry), defaultValue: null, propertyChanged: OnPropertyChanged);

        public string AssistiveText
        {
            get { return (string)GetValue(AssistiveTextProperty); }
            set { SetValue(AssistiveTextProperty, value); }
        }

        public static readonly BindableProperty LabelTextColorProperty =
            BindableProperty.Create(nameof(LabelTextColor), typeof(Color), typeof(MaterialEntry), defaultValue: Color.Gray, propertyChanged: OnPropertyChanged);

        public Color LabelTextColor
        {
            get { return (Color)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public static readonly BindableProperty FocusedLabelTextColorProperty =
            BindableProperty.Create(nameof(FocusedLabelTextColor), typeof(Color), typeof(MaterialEntry), defaultValue: Color.Gray, propertyChanged: OnPropertyChanged);

        public Color FocusedLabelTextColor
        {
            get { return (Color)GetValue(FocusedLabelTextColorProperty); }
            set { SetValue(FocusedLabelTextColorProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialEntry), defaultValue: Color.Gray, propertyChanged: OnPropertyChanged);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty PlaceholderColorProperty =
            BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(MaterialEntry), defaultValue: Color.Gray, propertyChanged: OnPropertyChanged);

        public Color PlaceholderColor
        {
            get { return (Color)GetValue(PlaceholderColorProperty); }
            set { SetValue(PlaceholderColorProperty, value); }
        }

        public static readonly BindableProperty AssistiveTextColorProperty =
            BindableProperty.Create(nameof(AssistiveTextColor), typeof(Color), typeof(MaterialEntry), defaultValue: Color.Gray, propertyChanged: OnPropertyChanged);

        public Color AssistiveTextColor
        {
            get { return (Color)GetValue(AssistiveTextColorProperty); }
            set { SetValue(AssistiveTextColorProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialEntry), defaultValue: Color.LightGray, propertyChanged: OnPropertyChanged);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty LabelFontSizeProperty = 
            BindableProperty.Create(nameof(LabelFontSize), typeof(double), typeof(MaterialEntry), defaultValue: 14.0, propertyChanged: OnPropertyChanged);

        public double LabelFontSize
        {
            get { return (double)GetValue(LabelFontSizeProperty); }
            set { SetValue(LabelFontSizeProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MaterialEntry), defaultValue: 14.0, propertyChanged: OnPropertyChanged);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty AssistiveFontSizeProperty =
            BindableProperty.Create(nameof(AssistiveFontSize), typeof(double), typeof(MaterialEntry), defaultValue: 14.0, propertyChanged: OnPropertyChanged);

        public double AssistiveFontSize
        {
            get { return (double)GetValue(AssistiveFontSizeProperty); }
            set { SetValue(AssistiveFontSizeProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(MaterialEntry), defaultValue: Color.LightGray, propertyChanged: OnPropertyChanged);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty FocusedBorderColorProperty =
            BindableProperty.Create(nameof(FocusedBorderColor), typeof(Color), typeof(MaterialEntry), defaultValue: Color.LightGray, propertyChanged: OnPropertyChanged);

        public Color FocusedBorderColor
        {
            get { return (Color)GetValue(FocusedBorderColorProperty); }
            set { SetValue(FocusedBorderColorProperty, value); }
        }

        public static readonly BindableProperty ClearIconProperty =
            BindableProperty.Create(nameof(ClearIcon), typeof(string), typeof(MaterialEntry), defaultValue: null, propertyChanged: OnPropertyChanged);

        public string ClearIcon
        {
            get { return (string)GetValue(ClearIconProperty); }
            set { SetValue(ClearIconProperty, value); }
        }

        public static readonly BindableProperty ClearIconIsVisibleProperty =
            BindableProperty.Create(nameof(ClearIconIsVisible), typeof(bool), typeof(MaterialEntry), defaultValue: true, propertyChanged: OnPropertyChanged);

        public bool ClearIconIsVisible
        {
            get { return (bool)GetValue(ClearIconIsVisibleProperty); }
            set { SetValue(ClearIconIsVisibleProperty, value); }
        }

        public static readonly BindableProperty ShowPasswordIconProperty =
            BindableProperty.Create(nameof(ShowPasswordIcon), typeof(string), typeof(MaterialEntry), defaultValue: null, propertyChanged: OnPropertyChanged);

        public string ShowPasswordIcon
        {
            get { return (string)GetValue(ShowPasswordIconProperty); }
            set { SetValue(ShowPasswordIconProperty, value); }
        }

        public static readonly BindableProperty ShowPasswordIconIsVisibleProperty =
            BindableProperty.Create(nameof(ShowPasswordIconIsVisible), typeof(bool), typeof(MaterialEntry), defaultValue: true, propertyChanged: OnPropertyChanged);

        public bool ShowPasswordIconIsVisible
        {
            get { return (bool)GetValue(ShowPasswordIconIsVisibleProperty); }
            set { SetValue(ShowPasswordIconIsVisibleProperty, value); }
        }

        public static readonly BindableProperty LeadingIconProperty =
            BindableProperty.Create(nameof(LeadingIcon), typeof(string), typeof(MaterialEntry), defaultValue: null, propertyChanged: OnPropertyChanged);

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
            BindableProperty.Create(nameof(TrailingIcon), typeof(string), typeof(MaterialEntry), defaultValue: null, propertyChanged: OnPropertyChanged);

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
            BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(MaterialEntry), defaultValue: Int32.MaxValue, propertyChanged: OnPropertyChanged);

        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }

        public static readonly BindableProperty RegexValidationProperty =
            BindableProperty.Create(nameof(RegexValidation), typeof(string), typeof(MaterialEntry), defaultValue: null, propertyChanged: OnPropertyChanged);

        public string RegexValidation
        {
            get { return (string)GetValue(RegexValidationProperty); }
            set { SetValue(RegexValidationProperty, value); }
        }

        public static readonly BindableProperty InvalidMessageProperty =
            BindableProperty.Create(nameof(InvalidMessage), typeof(string), typeof(MaterialEntry), defaultValue: null, propertyChanged: OnPropertyChanged);

        public string InvalidMessage
        {
            get { return (string)GetValue(InvalidMessageProperty); }
            set { SetValue(InvalidMessageProperty, value); }
        }

        public static readonly BindableProperty RequiredMessageProperty =
            BindableProperty.Create(nameof(RequiredMessage), typeof(string), typeof(MaterialEntry), defaultValue: null, propertyChanged: OnPropertyChanged);

        public string RequiredMessage
        {
            get { return (string)GetValue(RequiredMessageProperty); }
            set { SetValue(RequiredMessageProperty, value); }
        }

        public static readonly BindableProperty IsRequiredProperty =
            BindableProperty.Create(nameof(IsRequired), typeof(bool), typeof(MaterialEntry), defaultValue: false, propertyChanged: OnPropertyChanged);

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

        private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialEntry)bindable;
            control.ApplyControlProperties();
        }

        private void ApplyControlProperties()
        {
            if (!this.initialized)
            {
                this.InitializeComponent();
                this.initialized = true;
            }

            this.txtEntry.IsEnabled = this.IsEnabled;
            this.txtEntry.TextColor = this.TextColor;
            this.txtEntry.FontSize = this.FontSize;
            this.txtEntry.Placeholder = this.Placeholder;
            this.txtEntry.PlaceholderColor = this.PlaceholderColor;
            this.txtEntry.IsPassword = this.IsPassword;
            this.txtEntry.Keyboard = this.Keyboard;
            this.txtEntry.MaxLength = this.MaxLength;

            // TODO: Check if you can take out the strong password.

            this.lblLabel.Text = this.LabelText;
            this.lblLabel.TextColor = this.LabelTextColor;
            this.lblLabel.FontSize = this.LabelFontSize;

            this.frmContainer.Padding = this.Padding;
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

                    if (this.LeadingIconIsVisible)
                    {
                        this.lblLabel.Margin = new Thickness(36, this.lblLabel.Margin.Top, 
                                                            this.lblLabel.Margin.Right, this.lblLabel.Margin.Bottom);
                        this.frmContainer.Padding = new Thickness(0);
                        this.lblAssistive.Margin = new Thickness(36, this.lblAssistive.Margin.Top, 
                                                            this.lblAssistive.Margin.Right, this.lblAssistive.Margin.Bottom);
                        this.bxvLine.Margin = new Thickness(36, 0, 0, 0);
                    }
                    else
                    {
                        this.lblLabel.Margin = new Thickness(0, this.lblLabel.Margin.Top, 0, this.lblLabel.Margin.Bottom);
                        this.frmContainer.Padding = new Thickness(0);
                        this.lblAssistive.Margin = new Thickness(0, this.lblAssistive.Margin.Top, 0, this.lblAssistive.Margin.Bottom);
                    }
                    break;
            }

            this.lblAssistive.Text = this.AssistiveText;
            this.lblAssistive.TextColor = this.AssistiveTextColor;
            this.lblAssistive.FontSize = this.AssistiveFontSize;

            this.imgShowPasswordIcon.Source = this.ShowPasswordIcon;
            this.imgShowPasswordIcon.IsVisible = this.IsPassword && this.ShowPasswordIconIsVisible && !string.IsNullOrEmpty(this.ShowPasswordIcon);

            this.imgClearIcon.Source = this.ClearIcon;
            this.imgClearIcon.IsVisible = this.ClearIconIsVisible && this.IsEnabled && !string.IsNullOrEmpty(this.Text);

            this.imgLeadingIcon.Source = this.LeadingIcon;
            this.imgLeadingIcon.IsVisible = this.LeadingIconIsVisible;

            this.imgTrailingIcon.Source = this.TrailingIcon;
            this.imgTrailingIcon.IsVisible = this.TrailingIconIsVisible;

            if (!string.IsNullOrEmpty(this.RegexValidation) || this.IsRequired)
            {
                this.IsValid = false;
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
