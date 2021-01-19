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
    public partial class MaterialCodeEntry : BaseMaterialFieldControl
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

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialCodeEntry), defaultValue: null, propertyChanged: OnTextChanged, defaultBindingMode: BindingMode.TwoWay);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialCodeEntry), defaultValue: Color.LightGray);

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

            switch (propertyName)
            {
                case nameof(base.TranslationX):
                    base.OnPropertyChanged(propertyName);
                    break;
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
                case nameof(this.Length):
                    this.txtEntry.MaxLength = this.Length;
                    break;

                case nameof(this.LabelText):
                    this.lblLabel.Text = this.LabelText;
                    this.lblLabel.IsVisible = !string.IsNullOrEmpty(this.LabelText);
                    break;
                case nameof(this.LabelTextColor):
                    SetLabelTextColor(lblLabel);
                    break;
                case nameof(this.LabelSize):
                    this.lblLabel.FontSize = this.LabelSize;
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

        protected override void SetIsEnabled()
        {
            txtEntry.IsEnabled = IsEnabled;
            SetLabelTextColor(lblLabel);
            SetTextColor();
            SetTypeBackgroundAndBorderColor();
        }

        protected override void SetPadding()
        {
            grdContainer.Padding = this.Padding;
        }

        protected override void SetTextColor()
        {
            if (lblCodes != null)
            {
                foreach (var lblCode in lblCodes)
                {
                    if (IsControlEnabled)
                        lblCode.TextColor = IsControlFocused ? FocusedTextColor : TextColor;
                    else
                        lblCode.TextColor = DisabledTextColor;
                }
            }
        }

        protected override void SetFontSize()
        {
            if (lblCodes != null)
                foreach (var lblCode in lblCodes)
                    lblCode.FontSize = this.FontSize;
        }

        protected override void SetFontFamily()
        {
            if (lblCodes != null)
                foreach (var lblCode in lblCodes)
                    lblCode.FontFamily = this.FontFamily;

            this.lblLabel.FontFamily = this.FontFamily;
            this.lblAssistive.FontFamily = this.FontFamily;
        }

        protected override void SetPlaceholder()
        {
            throw new NotSupportedException();
        }

        protected override void SetPlaceholderColor()
        {
            throw new NotSupportedException();
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
                            if (IsControlEnabled)
                                frmContainer.BackgroundColor = IsControlFocused ? FocusedBackgroundColor : BackgroundColorControl;
                            else
                                frmContainer.BackgroundColor = DisabledBackgroundColor;

                            if (IsControlEnabled)
                                frmContainer.BorderColor = IsControlFocused ? FocusedBorderColor : BorderColor;
                            else
                                frmContainer.BorderColor = DisabledBorderColor;
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

                    bxvLine.IsVisible = true;
                    
                    if (IsControlEnabled)
                        bxvLine.Color = IsControlFocused ? FocusedBorderColor : BorderColor;
                    else
                        bxvLine.Color = DisabledBorderColor;

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
            SetLabelTextColor(lblLabel);
            SetTextColor();
            SetTypeBackgroundAndBorderColor();
        }

        private void Handle_Unfocused(object sender, FocusEventArgs e)
        {
            SetLabelTextColor(lblLabel);
            SetTextColor();
            SetTypeBackgroundAndBorderColor();
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