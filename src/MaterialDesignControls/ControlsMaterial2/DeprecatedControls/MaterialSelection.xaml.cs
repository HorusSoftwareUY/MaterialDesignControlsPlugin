using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [Obsolete("MaterialSelection is deprecated, please use MaterialSelection of Material 3 instead.")]

    public partial class MaterialSelection : BaseMaterialFieldControl
    {
        #region Constructors

        public MaterialSelection()
        {
            if (!this.initialized)
            {
                this.initialized = true;
                this.InitializeComponent();
            }
        }

        #endregion Constructors

        #region Attributes

        private bool initialized = false;

        #endregion Attributes

        #region Properties

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(MaterialSelection), defaultValue: null, propertyChanged: OnCommandChanged);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(MaterialSelection), defaultValue: null);

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }


        public static readonly new BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(MaterialSelection), defaultValue: new Thickness(12, 0));

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        public static readonly new BindableProperty IsEnabledProperty =
            BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(MaterialSelection), defaultValue: true);

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialSelection), defaultValue: null, propertyChanged: OnTextChanged);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialSelection), defaultValue: Color.LightGray);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public override bool IsControlFocused
        {
            get { return false; }
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

        private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialSelection)bindable;
            if (string.IsNullOrEmpty((string)newValue))
            {
                control.lblText.Text = control.Placeholder;
                control.lblText.TextColor = control.PlaceholderColor;
            }
            else
            {
                control.lblText.Text = (string)newValue;
                control.lblText.TextColor = control.TextColor;
            }
        }

        private static void OnCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialSelection)bindable;

            TapGestureRecognizer selectionTapGestureRecognizer = new TapGestureRecognizer();
            selectionTapGestureRecognizer.Tapped += (s, e) =>
            {
                if (control.IsEnabled && control.Command != null && control.Command.CanExecute(control.CommandParameter))
                {
                    control.Command.Execute(control.CommandParameter);
                }
            };
            control.frmContainer.GestureRecognizers.Clear();
            control.frmContainer.GestureRecognizers.Add(selectionTapGestureRecognizer);
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
                case nameof(this.Text):
                    SetPlaceHolderInTextControl();
                    break;
            }
        }

        protected override void SetIsEnabled()
        { }

        protected override void SetPadding()
        {
            frmContainer.Padding = Padding;
        }

        protected override void SetTextColor()
        {
            if (string.IsNullOrEmpty(this.Text))
                lblText.TextColor = PlaceholderColor;
            else
                lblText.TextColor = IsControlEnabled ? TextColor : DisabledTextColor;
        }

        protected override void SetFontSize()
        {
            lblText.FontSize = FontSize;
        }

        protected override void SetFontFamily()
        {
            lblText.FontFamily = FontFamily;
        }

        protected override void SetPlaceholder()
        {
            SetPlaceHolderInTextControl();
        }

        protected override void SetPlaceholderColor()
        {
            SetPlaceHolderInTextControl();
        }

        protected override void SetHorizontalTextAlignment()
        {
            lblText.HorizontalTextAlignment = HorizontalTextAlignment;
        }

        private void SetPlaceHolderInTextControl()
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                this.lblText.Text = this.Placeholder;
                this.lblText.TextColor = this.PlaceholderColor;
            }
        }

        #endregion Methods
    }
}