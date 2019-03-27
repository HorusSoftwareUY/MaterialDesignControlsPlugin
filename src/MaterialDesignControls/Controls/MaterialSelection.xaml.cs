using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls
{
    public partial class MaterialSelection : ContentView
    {
        #region Constructors

        public MaterialSelection()
        {
            if (!this.initialized)
            {
                this.InitializeComponent();
                this.initialized = true;
            }
        }

        #endregion Constructors

        #region Attributes

        private bool initialized = false;

        #endregion Attributes

        #region Properties

        public static readonly BindableProperty TypeProperty =
            BindableProperty.Create(nameof(Type), typeof(FieldTypes), typeof(MaterialEntry), defaultValue: FieldTypes.Filled, propertyChanged: OnPropertyChanged);

        public FieldTypes Type
        {
            get { return (FieldTypes)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(MaterialSelection), defaultValue: null, propertyChanged: OnCommandChanged);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(MaterialSelection), defaultValue: null, propertyChanged: OnPropertyChanged);

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }


        public static readonly new BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(MaterialSelection), defaultValue: new Thickness(12, 0), propertyChanged: OnPropertyChanged);

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        public static readonly new BindableProperty IsEnabledProperty =
            BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(MaterialSelection), defaultValue: true, propertyChanged: OnPropertyChanged);

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public static readonly BindableProperty LabelTextProperty =
            BindableProperty.Create(nameof(LabelText), typeof(string), typeof(MaterialSelection), defaultValue: null, propertyChanged: OnPropertyChanged);

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialSelection), defaultValue: null, propertyChanged: OnTextChanged);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty PlaceholderProperty =
            BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(MaterialSelection), defaultValue: null, propertyChanged: OnPropertyChanged);

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public static readonly BindableProperty AssistiveTextProperty =
            BindableProperty.Create(nameof(AssistiveText), typeof(string), typeof(MaterialSelection), defaultValue: null, propertyChanged: OnPropertyChanged);

        public string AssistiveText
        {
            get { return (string)GetValue(AssistiveTextProperty); }
            set { SetValue(AssistiveTextProperty, value); }
        }

        public static readonly BindableProperty LabelTextColorProperty =
            BindableProperty.Create(nameof(LabelTextColor), typeof(Color), typeof(MaterialSelection), defaultValue: Color.Gray, propertyChanged: OnPropertyChanged);

        public Color LabelTextColor
        {
            get { return (Color)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialSelection), defaultValue: Color.Gray, propertyChanged: OnPropertyChanged);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty PlaceholderColorProperty =
            BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(MaterialSelection), defaultValue: Color.Gray, propertyChanged: OnPropertyChanged);

        public Color PlaceholderColor
        {
            get { return (Color)GetValue(PlaceholderColorProperty); }
            set { SetValue(PlaceholderColorProperty, value); }
        }

        public static readonly BindableProperty AssistiveTextColorProperty =
            BindableProperty.Create(nameof(AssistiveTextColor), typeof(Color), typeof(MaterialSelection), defaultValue: Color.Gray, propertyChanged: OnPropertyChanged);

        public Color AssistiveTextColor
        {
            get { return (Color)GetValue(AssistiveTextColorProperty); }
            set { SetValue(AssistiveTextColorProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialSelection), defaultValue: Color.LightGray, propertyChanged: OnPropertyChanged);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty LabelSizeProperty =
            BindableProperty.Create(nameof(LabelSize), typeof(double), typeof(MaterialSelection), defaultValue: Font.Default.FontSize, propertyChanged: OnPropertyChanged);

        public double LabelSize
        {
            get { return (double)GetValue(LabelSizeProperty); }
            set { SetValue(LabelSizeProperty, value); }
        }

        public static readonly BindableProperty TextSizeProperty =
            BindableProperty.Create(nameof(TextSize), typeof(double), typeof(MaterialSelection), defaultValue: Font.Default.FontSize, propertyChanged: OnPropertyChanged);

        public double TextSize
        {
            get { return (double)GetValue(TextSizeProperty); }
            set { SetValue(TextSizeProperty, value); }
        }

        public static readonly BindableProperty AssistiveSizeProperty =
            BindableProperty.Create(nameof(AssistiveSize), typeof(double), typeof(MaterialSelection), defaultValue: Font.Default.FontSize, propertyChanged: OnPropertyChanged);

        public double AssistiveSize
        {
            get { return (double)GetValue(AssistiveSizeProperty); }
            set { SetValue(AssistiveSizeProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(MaterialSelection), defaultValue: Color.LightGray, propertyChanged: OnPropertyChanged);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty LeadingIconProperty =
            BindableProperty.Create(nameof(LeadingIcon), typeof(string), typeof(MaterialSelection), defaultValue: null, propertyChanged: OnPropertyChanged);

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
            BindableProperty.Create(nameof(TrailingIcon), typeof(string), typeof(MaterialSelection), defaultValue: null, propertyChanged: OnPropertyChanged);

        public string TrailingIcon
        {
            get { return (string)GetValue(TrailingIconProperty); }
            set { SetValue(TrailingIconProperty, value); }
        }

        public bool TrailingIconIsVisible
        {
            get { return !string.IsNullOrEmpty(this.TrailingIcon); }
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
            selectionTapGestureRecognizer.Tapped += async (s, e) =>
            {
                if (control.IsEnabled && control.Command != null && control.Command.CanExecute(control.CommandParameter))
                {
                    control.Command.Execute(control.CommandParameter);
                }
            };
            control.frmContainer.GestureRecognizers.Clear();
            control.frmContainer.GestureRecognizers.Add(selectionTapGestureRecognizer);
        }

        private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialSelection)bindable;
            control.ApplyControlProperties();
        }

        private void ApplyControlProperties()
        {
            if (!this.initialized)
            {
                this.InitializeComponent();
                this.initialized = true;
            }

            this.lblText.FontSize = this.TextSize;
            this.lblLabel.Text = this.LabelText;
            this.lblLabel.TextColor = this.LabelTextColor;
            this.lblLabel.FontSize = this.LabelSize;

            if (string.IsNullOrEmpty(this.Text))
            {
                this.lblText.Text = this.Placeholder;
                this.lblText.TextColor = this.PlaceholderColor;
            }

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

            this.lblAssistive.Text = this.AssistiveText;
            this.lblAssistive.TextColor = this.AssistiveTextColor;
            this.lblAssistive.FontSize = this.AssistiveSize;

            if (!string.IsNullOrEmpty(this.LeadingIcon))
            {
                this.imgLeadingIcon.Source = this.LeadingIcon;
            }
            this.imgLeadingIcon.IsVisible = this.LeadingIconIsVisible;

            if (!string.IsNullOrEmpty(this.TrailingIcon))
            {
                this.imgTrailingIcon.Source = this.TrailingIcon;
            }
            this.imgTrailingIcon.IsVisible = this.TrailingIconIsVisible;
        }

        #endregion Methods
    }
}
