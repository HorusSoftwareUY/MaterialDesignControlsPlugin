using Plugin.MaterialDesignControls.Utils;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Plugin.MaterialDesignControls.Styles;

namespace Plugin.MaterialDesignControls.Material3
{
    public class MaterialCodeEntry : MaterialCustomControl
    {
        #region Constructors

        public MaterialCodeEntry()
        {
            grdContainer = new Grid()
            {
                ColumnSpacing = 8,
                RowDefinitions = new RowDefinitionCollection() { new RowDefinition() { Height = FieldHeightRequest } }
            };

            txtEntry = new CustomEntry()
            {
                IsCode = true,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.Transparent
            };

            grdContainer.Children.Add(txtEntry);

            txtEntry.Focused += HandleFocusChange;
            txtEntry.Unfocused += HandleFocusChange;
            txtEntry.TextChanged += TxtEntry_TextChanged;

            base.CustomControl = grdContainer;
        }

        #endregion Constructors

        #region Attributes

        private bool initialized = false;

        private Grid grdContainer;

        private CustomEntry txtEntry;

        private List<Frame> frmContainers;

        private List<Label> lblCodes;

        #endregion Attributes

        #region Properties

        public static readonly new BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(MaterialCodeEntry), defaultValue: new Thickness(12, 0));

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        public static readonly new BindableProperty IsEnabledProperty =
            BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(MaterialCodeEntry), defaultValue: true);

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public static readonly BindableProperty IsCodeProperty =
            BindableProperty.Create(nameof(IsCode), typeof(bool), typeof(MaterialCodeEntry), defaultValue: true);

        public bool IsCode
        {
            get { return (bool)GetValue(IsCodeProperty); }
            set { SetValue(IsCodeProperty, value); }
        }

        public static readonly BindableProperty FieldHeightRequestProperty =
            BindableProperty.Create(nameof(FieldHeightRequest), typeof(double), typeof(MaterialCodeEntry), defaultValue: 40.0);

        public double FieldHeightRequest
        {
            get { return (double)GetValue(FieldHeightRequestProperty); }
            set { SetValue(FieldHeightRequestProperty, value); }
        }

        public static readonly BindableProperty KeyboardProperty =
            BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(MaterialCodeEntry), defaultValue: Keyboard.Text);

        public Keyboard Keyboard
        {
            get { return (Keyboard)GetValue(KeyboardProperty); }
            set { SetValue(KeyboardProperty, value); }
        }

        public static readonly BindableProperty KeyboardFlagsProperty =
            BindableProperty.Create(nameof(KeyboardFlags), typeof(string), typeof(MaterialCodeEntry), defaultValue: null);

        public string KeyboardFlags
        {
            get { return (string)GetValue(KeyboardFlagsProperty); }
            set { SetValue(KeyboardFlagsProperty, value); }
        }

        public static readonly BindableProperty TextTransformProperty =
            BindableProperty.Create(nameof(TextTransform), typeof(TextTransforms), typeof(MaterialCodeEntry), defaultValue: TextTransforms.Default);

        public TextTransforms TextTransform
        {
            get { return (TextTransforms)GetValue(TextTransformProperty); }
            set { SetValue(TextTransformProperty, value); }
        }

        public static readonly BindableProperty ReturnTypeProperty =
            BindableProperty.Create(nameof(ReturnType), typeof(ReturnType), typeof(MaterialCodeEntry), defaultValue: null);

        public ReturnType ReturnType
        {
            get { return (ReturnType)GetValue(ReturnTypeProperty); }
            set { SetValue(ReturnTypeProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialCodeEntry), defaultValue: null, propertyChanged: OnTextChanged, defaultBindingMode: BindingMode.TwoWay);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialCodeEntry), defaultValue: DefaultStyles.SurfaceContainerHighestColor);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty LengthProperty =
            BindableProperty.Create(nameof(Length), typeof(int), typeof(MaterialCodeEntry), propertyChanged: OnLengthChanged, defaultValue: 0);

        public int Length
        {
            get { return (int)GetValue(LengthProperty); }
            set { SetValue(LengthProperty, value); }
        }

        public static readonly BindableProperty FieldWidthRequestProperty =
            BindableProperty.Create(nameof(FieldWidthRequest), typeof(double), typeof(MaterialCodeEntry), defaultValue: 0.0);

        public double FieldWidthRequest
        {
            get { return (double)GetValue(FieldWidthRequestProperty); }
            set { SetValue(FieldWidthRequestProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialCodeEntry), defaultValue: DefaultStyles.TextColor);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty FocusedTextColorProperty =
            BindableProperty.Create(nameof(FocusedTextColor), typeof(Color), typeof(MaterialCodeEntry), defaultValue: DefaultStyles.TextColor);

        public Color FocusedTextColor
        {
            get { return (Color)GetValue(FocusedTextColorProperty); }
            set { SetValue(FocusedTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledTextColorProperty =
            BindableProperty.Create(nameof(DisabledTextColor), typeof(Color), typeof(MaterialCodeEntry), defaultValue: DefaultStyles.DisableColor);

        public Color DisabledTextColor
        {
            get { return (Color)GetValue(DisabledTextColorProperty); }
            set { SetValue(DisabledTextColorProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MaterialCodeEntry), defaultValue: DefaultStyles.PhoneFontSizes.BodyLarge);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(MaterialCodeEntry), defaultValue: DefaultStyles.FontFamily);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(MaterialCodeEntry), defaultValue: 0f);

        public float CornerRadius
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty TypeProperty =
            BindableProperty.Create(nameof(Type), typeof(FieldTypes), typeof(MaterialCodeEntry), defaultValue: FieldTypes.Filled);

        public FieldTypes Type
        {
            get { return (FieldTypes)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(MaterialCodeEntry), defaultValue: DefaultStyles.OnSurfaceVariantColor);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty FocusedBorderColorProperty =
            BindableProperty.Create(nameof(FocusedBorderColor), typeof(Color), typeof(MaterialCodeEntry), defaultValue: DefaultStyles.PrimaryColor);

        public Color FocusedBorderColor
        {
            get { return (Color)GetValue(FocusedBorderColorProperty); }
            set { SetValue(FocusedBorderColorProperty, value); }
        }

        public static readonly BindableProperty DisabledBorderColorProperty =
            BindableProperty.Create(nameof(DisabledBorderColor), typeof(Color), typeof(MaterialCodeEntry), defaultValue: DefaultStyles.DisableColor);

        public Color DisabledBorderColor
        {
            get { return (Color)GetValue(DisabledBorderColorProperty); }
            set { SetValue(DisabledBorderColorProperty, value); }
        }

        public static readonly BindableProperty FocusedBackgroundColorProperty =
            BindableProperty.Create(nameof(FocusedBackgroundColor), typeof(Color), typeof(MaterialCodeEntry), defaultValue: DefaultStyles.SurfaceContainerHighestColor);

        public Color FocusedBackgroundColor
        {
            get { return (Color)GetValue(FocusedBackgroundColorProperty); }
            set { SetValue(FocusedBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty DisabledBackgroundColorProperty =
            BindableProperty.Create(nameof(DisabledBackgroundColor), typeof(Color), typeof(MaterialCodeEntry), defaultValue: DefaultStyles.DisableContainerColor);

        public Color DisabledBackgroundColor
        {
            get { return (Color)GetValue(DisabledBackgroundColorProperty); }
            set { SetValue(DisabledBackgroundColorProperty, value); }
        }

        #endregion Properties

        #region Events

        public event EventHandler TextChanged;

        public new event EventHandler<FocusEventArgs> Focused;

        public new event EventHandler<FocusEventArgs> Unfocused;

        #endregion Events

        #region Methods

        private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialCodeEntry)bindable;
            var newText = (string)newValue;
            control.txtEntry.Text = newText;
            var newTextArray = newText.ToCharArray();

            for (int index = 0; index < control.Length; index++)
                control.lblCodes[index].Text = newTextArray.Length >= (index + 1) ? newTextArray[index].ToString() : string.Empty;
        }

        private static void OnLengthChanged(BindableObject bindable, object oldValue, object newValue)
        {
            int length = (int)newValue;
            var control = (MaterialCodeEntry)bindable;

            control.grdContainer.ColumnDefinitions = new ColumnDefinitionCollection();

            control.frmContainers = new List<Frame>();
            control.lblCodes = new List<Label>();

            for (int i = 0; i < length; i++)
            {
                control.grdContainer.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

                var frmContainer = new Frame { HasShadow = false, Padding = new Thickness(0) };
                TapGestureRecognizer frameTapGestureRecognizer = new TapGestureRecognizer();
                frameTapGestureRecognizer.Tapped += (s, e) =>
                {
                    if (control.txtEntry.IsEnabled)
                        control.txtEntry.Focus();
                };
                frmContainer.GestureRecognizers.Add(frameTapGestureRecognizer);
                control.frmContainers.Add(frmContainer);

                var lblCode = new MaterialLabel
                {
                    HorizontalTextAlignment = TextAlignment.Center,
                    VerticalTextAlignment = TextAlignment.Center,
                    TextColor = control.TextColor,
                    FontSize = control.FontSize,
                    FontFamily = control.FontFamily,
                };
                control.lblCodes.Add(lblCode);

                frmContainer.Content = lblCode;
                control.grdContainer.Children.Add(frmContainer, i, 0);
            }

            control.SetTypeBackgroundAndBorderColor();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            switch (propertyName)
            {
                case nameof(this.IsEnabled):
                    SetIsEnabled();
                    break;
                case nameof(this.TextColor):
                    SetTextColor();
                    break;
                case nameof(this.FontSize):
                    SetFontSize();
                    break;
                case nameof(this.FontFamily):
                    SetFontFamily();
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

                case nameof(this.Length):
                    this.txtEntry.MaxLength = this.Length;
                    break;

                case nameof(this.Padding):
                    this.grdContainer.Padding = this.Padding;
                    break;

                case nameof(CornerRadius):
                    if (frmContainers != null)
                        foreach (var frmContainer in frmContainers)
                            frmContainer.CornerRadius = Convert.ToInt32(CornerRadius);
                    break;

                case nameof(this.Type):
                case nameof(this.BackgroundColor):
                case nameof(this.BorderColor):
                    SetTypeBackgroundAndBorderColor();
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

                case nameof(this.FieldHeightRequest):
                    grdContainer.RowDefinitions = new RowDefinitionCollection();
                    grdContainer.RowDefinitions.Add(new RowDefinition { Height = this.FieldHeightRequest });

                    if (frmContainers != null)
                        foreach (var frmContainer in frmContainers)
                            frmContainer.HeightRequest = this.FieldHeightRequest;
                    break;

                case nameof(this.FieldWidthRequest):
                    if (frmContainers != null)
                        foreach (var frmContainer in frmContainers)
                        {
                            frmContainer.HorizontalOptions = LayoutOptions.Center;
                            frmContainer.WidthRequest = this.FieldWidthRequest;
                        }
                    break;

                case nameof(this.IsCode):
                    this.txtEntry.IsCode = this.IsCode;
                    break;

                default:
                    base.OnPropertyChanged(propertyName);
                    break;
            }
        }

        protected void SetIsEnabled()
        {
            txtEntry.IsEnabled = IsEnabled;
            SetLabelTextColor();
            SetTextColor();
            SetTypeBackgroundAndBorderColor();
        }

        protected void SetPadding()
        {
            grdContainer.Padding = this.Padding;
        }

        protected void SetTextColor()
        {
            if (lblCodes != null)
            {
                foreach (var lblCode in lblCodes)
                {
                    if (this.IsEnabled)
                        lblCode.TextColor = txtEntry.IsFocused && FocusedTextColor != Color.Transparent ? FocusedTextColor : TextColor;
                    else
                        lblCode.TextColor = DisabledTextColor;
                }
            }
        }

        protected void SetFontSize()
        {
            if (lblCodes != null)
                foreach (var lblCode in lblCodes)
                    lblCode.FontSize = this.FontSize;
        }

        protected void SetFontFamily()
        {
            if (lblCodes != null)
                foreach (var lblCode in lblCodes)
                    lblCode.FontFamily = this.FontFamily;
        }

        private void SetTypeBackgroundAndBorderColor()
        {
            switch (this.Type)
            {
                case FieldTypes.Filled:
                case FieldTypes.Outlined:
                    if (frmContainers != null)
                    {
                        foreach (var frmContainer in frmContainers)
                        {
                            if (this.IsEnabled)
                                frmContainer.BackgroundColor = this.txtEntry.IsFocused && FocusedBackgroundColor != Color.Transparent ? FocusedBackgroundColor : this.BackgroundColor;
                            else
                                frmContainer.BackgroundColor = DisabledBackgroundColor;

                            if (this.IsEnabled)
                                frmContainer.BorderColor = this.txtEntry.IsFocused && FocusedBorderColor != Color.Transparent ? FocusedBorderColor : BorderColor;
                            else
                                frmContainer.BorderColor = DisabledBorderColor;
                        }
                    }
                    break;
                case FieldTypes.Lined:
                    if (frmContainers != null)
                    {
                        foreach (var frmContainer in frmContainers)
                        {
                            frmContainer.BackgroundColor = Color.Transparent;
                            frmContainer.BorderColor = Color.Transparent;
                        }
                    }

                    if (frmContainers != null)
                        foreach (var frmContainer in frmContainers)
                            frmContainer.HeightRequest = 30;
                    break;
            }
        }

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
            SetLabelTextColor();
            SetTextColor();
            SetTypeBackgroundAndBorderColor();

            if (txtEntry.IsFocused)
                Focused?.Invoke(this, e);
            else
                Unfocused?.Invoke(this, e);
        }

        private void TxtEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
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
