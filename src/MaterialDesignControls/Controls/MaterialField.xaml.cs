using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls
{
    public partial class MaterialField : ContentView
    {
        #region Constructors

        public MaterialField()
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

        public static readonly BindableProperty LabelTextProperty =
            BindableProperty.Create(nameof(LabelText), typeof(string), typeof(MaterialField), defaultValue: null, propertyChanged: OnPropertyChanged);

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialField), defaultValue: null, propertyChanged: OnPropertyChanged, defaultBindingMode: BindingMode.TwoWay);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty AssistiveTextProperty =
            BindableProperty.Create(nameof(AssistiveText), typeof(string), typeof(MaterialField), defaultValue: null, propertyChanged: OnPropertyChanged);

        public string AssistiveText
        {
            get { return (string)GetValue(AssistiveTextProperty); }
            set { SetValue(AssistiveTextProperty, value); }
        }

        public static readonly BindableProperty LabelTextColorProperty =
            BindableProperty.Create(nameof(LabelTextColor), typeof(Color), typeof(MaterialField), defaultValue: Color.Gray, propertyChanged: OnPropertyChanged);

        public Color LabelTextColor
        {
            get { return (Color)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialField), defaultValue: Color.Gray, propertyChanged: OnPropertyChanged);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty AssistiveTextColorProperty =
            BindableProperty.Create(nameof(AssistiveTextColor), typeof(Color), typeof(MaterialField), defaultValue: Color.Gray, propertyChanged: OnPropertyChanged);

        public Color AssistiveTextColor
        {
            get { return (Color)GetValue(AssistiveTextColorProperty); }
            set { SetValue(AssistiveTextColorProperty, value); }
        }

        public static readonly BindableProperty LabelScaleProperty =
            BindableProperty.Create(nameof(LabelScale), typeof(ScaleTypes), typeof(MaterialField), defaultValue: ScaleTypes.Body3, propertyChanged: OnPropertyChanged);

        public ScaleTypes LabelScale
        {
            get { return (ScaleTypes)GetValue(LabelScaleProperty); }
            set { SetValue(LabelScaleProperty, value); }
        }

        public static readonly BindableProperty TextScaleProperty =
            BindableProperty.Create(nameof(TextScale), typeof(ScaleTypes), typeof(MaterialField), defaultValue: ScaleTypes.Body2, propertyChanged: OnPropertyChanged);

        public ScaleTypes TextScale
        {
            get { return (ScaleTypes)GetValue(TextScaleProperty); }
            set { SetValue(TextScaleProperty, value); }
        }

        public static readonly BindableProperty AssistiveScaleProperty =
            BindableProperty.Create(nameof(AssistiveScale), typeof(ScaleTypes), typeof(MaterialField), defaultValue: ScaleTypes.Body3, propertyChanged: OnPropertyChanged);

        public ScaleTypes AssistiveScale
        {
            get { return (ScaleTypes)GetValue(AssistiveScaleProperty); }
            set { SetValue(AssistiveScaleProperty, value); }
        }

        public static readonly BindableProperty LeadingIconProperty =
            BindableProperty.Create(nameof(LeadingIcon), typeof(string), typeof(MaterialField), defaultValue: null, propertyChanged: OnPropertyChanged);

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
            BindableProperty.Create(nameof(TrailingIcon), typeof(string), typeof(MaterialField), defaultValue: null, propertyChanged: OnPropertyChanged);

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

        private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialField)bindable;
            control.ApplyControlProperties();
        }

        private void ApplyControlProperties()
        {
            if (!this.initialized)
            {
                this.InitializeComponent();
                this.initialized = true;
            }

            this.lblText.Text = this.Text;
            this.lblText.TextColor = this.TextColor;
            this.lblText.Scale = this.TextScale;

            this.lblLabel.Text = this.LabelText;
            this.lblLabel.TextColor = this.LabelTextColor;
            this.lblLabel.Scale = this.LabelScale;

            if (this.LeadingIconIsVisible)
            {
                this.lblLabel.Margin = new Thickness(36, this.lblLabel.Margin.Top,
                                                    this.lblLabel.Margin.Right, 0);
                this.lblAssistive.Margin = new Thickness(36, this.lblAssistive.Margin.Top,
                                                    this.lblAssistive.Margin.Right, this.lblAssistive.Margin.Bottom);
            }
            else
            {
                this.lblLabel.Margin = new Thickness(0, this.lblLabel.Margin.Top, 0, 0);
                this.lblAssistive.Margin = new Thickness(0, this.lblAssistive.Margin.Top, 0, this.lblAssistive.Margin.Bottom);
            }

            this.lblAssistive.Text = this.AssistiveText;
            this.lblAssistive.TextColor = this.AssistiveTextColor;
            this.lblAssistive.Scale = this.AssistiveScale;

            this.imgLeadingIcon.Source = this.LeadingIcon;
            this.imgLeadingIcon.IsVisible = this.LeadingIconIsVisible;

            this.imgTrailingIcon.Source = this.TrailingIcon;
            this.imgTrailingIcon.IsVisible = this.TrailingIconIsVisible;
        }

        #endregion Methods
    }
}
