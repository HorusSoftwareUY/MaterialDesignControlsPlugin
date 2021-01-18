using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialCodeEntry : ContentView
    {
        #region Constructors

        public MaterialCodeEntry()
        {
            if (!this.initialized)
            {
                this.initialized = true;
                this.InitializeComponent();
            }

            txtEntry.Focused += Handle_Focused;
            txtEntry.Unfocused += Handle_Unfocused;
            txtEntry.TextChanged += TxtEntry_TextChanged;
        }

        #endregion Constructors

        #region Attributes

        private bool initialized = false;

        private List<Frame> frmContainers;

        private List<Label> lblCodes;

        #endregion Attributes

        #region Properties

        public static readonly BindableProperty TypeProperty =
            BindableProperty.Create(nameof(Type), typeof(FieldTypes), typeof(MaterialCodeEntry), defaultValue: FieldTypes.Filled);

        public FieldTypes Type
        {
            get { return (FieldTypes)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

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

        public static readonly BindableProperty KeyboardProperty =
            BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(MaterialCodeEntry), defaultValue: Keyboard.Text);

        public Keyboard Keyboard
        {
            get { return (Keyboard)GetValue(KeyboardProperty); }
            set { SetValue(KeyboardProperty, value); }
        }

        public static readonly BindableProperty ReturnTypeProperty =
            BindableProperty.Create(nameof(ReturnType), typeof(ReturnType), typeof(MaterialCodeEntry), defaultValue: null);

        public ReturnType ReturnType
        {
            get { return (ReturnType)GetValue(ReturnTypeProperty); }
            set { SetValue(ReturnTypeProperty, value); }
        }

        public static readonly BindableProperty LabelTextProperty =
            BindableProperty.Create(nameof(LabelText), typeof(string), typeof(MaterialCodeEntry), defaultValue: null);

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialCodeEntry), defaultValue: null, propertyChanged: OnTextChanged, defaultBindingMode: BindingMode.TwoWay);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty AssistiveTextProperty =
            BindableProperty.Create(nameof(AssistiveText), typeof(string), typeof(MaterialCodeEntry), defaultValue: null);

        public string AssistiveText
        {
            get { return (string)GetValue(AssistiveTextProperty); }
            set { SetValue(AssistiveTextProperty, value); }
        }

        public static readonly BindableProperty LabelTextColorProperty =
            BindableProperty.Create(nameof(LabelTextColor), typeof(Color), typeof(MaterialCodeEntry), defaultValue: Color.Gray);

        public Color LabelTextColor
        {
            get { return (Color)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public static readonly BindableProperty FocusedLabelTextColorProperty =
            BindableProperty.Create(nameof(FocusedLabelTextColor), typeof(Color), typeof(MaterialCodeEntry), defaultValue: Color.Gray);

        public Color FocusedLabelTextColor
        {
            get { return (Color)GetValue(FocusedLabelTextColorProperty); }
            set { SetValue(FocusedLabelTextColorProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialCodeEntry), defaultValue: Color.Gray);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty AssistiveTextColorProperty =
            BindableProperty.Create(nameof(AssistiveTextColor), typeof(Color), typeof(MaterialCodeEntry), defaultValue: Color.Gray);

        public Color AssistiveTextColor
        {
            get { return (Color)GetValue(AssistiveTextColorProperty); }
            set { SetValue(AssistiveTextColorProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialCodeEntry), defaultValue: Color.LightGray);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty LabelSizeProperty =
            BindableProperty.Create(nameof(LabelSize), typeof(double), typeof(MaterialCodeEntry), defaultValue: Font.Default.FontSize);

        public double LabelSize
        {
            get { return (double)GetValue(LabelSizeProperty); }
            set { SetValue(LabelSizeProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MaterialCodeEntry), defaultValue: Font.Default.FontSize);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(MaterialCodeEntry), defaultValue: null);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public static readonly BindableProperty AssistiveSizeProperty =
            BindableProperty.Create(nameof(AssistiveSize), typeof(double), typeof(MaterialCodeEntry), defaultValue: Font.Default.FontSize);

        public double AssistiveSize
        {
            get { return (double)GetValue(AssistiveSizeProperty); }
            set { SetValue(AssistiveSizeProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(MaterialCodeEntry), defaultValue: Color.LightGray);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty FocusedBorderColorProperty =
            BindableProperty.Create(nameof(FocusedBorderColor), typeof(Color), typeof(MaterialCodeEntry), defaultValue: Color.LightGray);

        public Color FocusedBorderColor
        {
            get { return (Color)GetValue(FocusedBorderColorProperty); }
            set { SetValue(FocusedBorderColorProperty, value); }
        }

        public static readonly BindableProperty LengthProperty =
            BindableProperty.Create(nameof(Length), typeof(int), typeof(MaterialCodeEntry), propertyChanged: OnLengthChanged, defaultValue: 0);

        public int Length
        {
            get { return (int)GetValue(LengthProperty); }
            set { SetValue(LengthProperty, value); }
        }

        public static readonly BindableProperty AnimateErrorProperty =
            BindableProperty.Create(nameof(AnimateError), typeof(bool), typeof(MaterialCodeEntry), defaultValue: false);

        public bool AnimateError
        {
            get { return (bool)GetValue(AnimateErrorProperty); }
            set { SetValue(AnimateErrorProperty, value); }
        }

        public static readonly BindableProperty FieldHeightRequestProperty =
            BindableProperty.Create(nameof(FieldHeightRequest), typeof(double), typeof(MaterialCodeEntry), defaultValue: 40.0);

        public double FieldHeightRequest
        {
            get { return (double)GetValue(FieldHeightRequestProperty); }
            set { SetValue(FieldHeightRequestProperty, value); }
        }

        public static readonly BindableProperty FieldWidthRequestProperty =
            BindableProperty.Create(nameof(FieldWidthRequest), typeof(double), typeof(MaterialCodeEntry), defaultValue: 0.0);

        public double FieldWidthRequest
        {
            get { return (double)GetValue(FieldWidthRequestProperty); }
            set { SetValue(FieldWidthRequestProperty, value); }
        }

        public new bool IsFocused
        {
            get
            {
                return this.txtEntry.IsFocused;
            }
        }

        #endregion Properties

        #region Events

        public event EventHandler TextChanged;

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
            if (!this.initialized)
            {
                this.initialized = true;
                this.InitializeComponent();
            }

            // TODO: Check if you can take out the strong password.

            switch (propertyName)
            {
                case nameof(base.TranslationX):
                    base.OnPropertyChanged(propertyName);
                    break;
                case nameof(this.IsEnabled):
                    this.txtEntry.IsEnabled = this.IsEnabled;
                    break;
                case nameof(this.TextColor):
                    if (lblCodes != null)
                        foreach (var lblCode in lblCodes)
                            lblCode.TextColor = this.TextColor;
                    break;
                case nameof(this.FontSize):
                    if (lblCodes != null)
                        foreach (var lblCode in lblCodes)
                            lblCode.FontSize = this.FontSize;
                    break;
                case nameof(this.FontFamily):
                    if (lblCodes != null)
                        foreach (var lblCode in lblCodes)
                            lblCode.FontFamily = this.FontFamily;

                    this.lblLabel.FontFamily = this.FontFamily;
                    this.lblAssistive.FontFamily = this.FontFamily;
                    break;
                case nameof(this.Keyboard):
                    this.txtEntry.Keyboard = this.Keyboard;
                    break;
                case nameof(this.Length):
                    this.txtEntry.MaxLength = this.Length;
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
                    this.grdContainer.Padding = this.Padding;
                    break;

                case nameof(this.Type):
                case nameof(this.BackgroundColor):
                case nameof(this.BorderColor):
                    SetTypeBackgroundAndBorderColor();
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
            }
        }

        private void SetTypeBackgroundAndBorderColor()
        {
            switch (this.Type)
            {
                case FieldTypes.Filled:
                    if (frmContainers != null)
                    {
                        foreach (var frmContainer in frmContainers)
                        {
                            frmContainer.BackgroundColor = this.BackgroundColor;
                            frmContainer.BorderColor = this.BorderColor;
                            frmContainer.CornerRadius = 20;
                        }
                    }
                    this.bxvLine.IsVisible = false;
                    break;
                case FieldTypes.Outlined:
                    if (frmContainers != null)
                    {
                        foreach (var frmContainer in frmContainers)
                        {
                            frmContainer.BackgroundColor = this.BackgroundColor;
                            frmContainer.BorderColor = this.BorderColor;
                            frmContainer.CornerRadius = 4;
                        }
                    }
                    this.bxvLine.IsVisible = false;
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
                    this.bxvLine.IsVisible = true;
                    this.bxvLine.Color = this.BorderColor;

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
                this.txtEntry.Focus();
            });
            return true;
        }

        private void Handle_Focused(object sender, FocusEventArgs e)
        {
            this.lblLabel.TextColor = this.FocusedLabelTextColor;

            switch (this.Type)
            {
                case FieldTypes.Filled:
                case FieldTypes.Outlined:
                    foreach (var frmContainer in frmContainers)
                        frmContainer.BorderColor = this.FocusedBorderColor;
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
                    foreach (var frmContainer in frmContainers)
                        frmContainer.BorderColor = this.BorderColor;
                    break;
                case FieldTypes.Lined:
                    this.bxvLine.Color = this.BorderColor;
                    break;
            }
        }

        private void TxtEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
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