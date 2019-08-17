﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialTimePicker : ContentView
    {
        #region Constructors

        public MaterialTimePicker()
        {
            if (!this.initialized)
            {
                this.InitializeComponent();
                this.initialized = true;
            }

            this.pckTime.Focused += Handle_Focused;
            this.pckTime.Unfocused += Handle_Unfocused;
            this.pckTime.SetBinding(TimePicker.TimeProperty, new Binding() { Source = this, Path = TimeProperty.PropertyName });
        }

        #endregion Constructors

        #region Attributes

        private bool initialized = false;

        #endregion Attributes

        #region Properties

        public static readonly BindableProperty TypeProperty =
            BindableProperty.Create(nameof(Type), typeof(FieldTypes), typeof(MaterialTimePicker), defaultValue: FieldTypes.Filled, propertyChanged: OnPropertyChanged);

        public FieldTypes Type
        {
            get { return (FieldTypes)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public static readonly new BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(MaterialTimePicker), defaultValue: new Thickness(12, 0), propertyChanged: OnPropertyChanged);

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        public static readonly new BindableProperty IsEnabledProperty =
            BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(MaterialTimePicker), defaultValue: true, propertyChanged: OnPropertyChanged);

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public static readonly BindableProperty LabelTextProperty =
            BindableProperty.Create(nameof(LabelText), typeof(string), typeof(MaterialTimePicker), defaultValue: null, propertyChanged: OnPropertyChanged);

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public static readonly BindableProperty TimeProperty =
            BindableProperty.Create(nameof(Time), typeof(TimeSpan), typeof(MaterialTimePicker), defaultValue: null, propertyChanged: OnTimeChanged, defaultBindingMode: BindingMode.TwoWay);

        public TimeSpan Time
        {
            get { return (TimeSpan)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        public static readonly BindableProperty FormatProperty =
            BindableProperty.Create(nameof(Format), typeof(string), typeof(MaterialTimePicker), defaultValue: null, propertyChanged: OnPropertyChanged);

        public string Format
        {
            get { return (string)GetValue(FormatProperty); }
            set { SetValue(FormatProperty, value); }
        }

        public static readonly BindableProperty AssistiveTextProperty =
            BindableProperty.Create(nameof(AssistiveText), typeof(string), typeof(MaterialTimePicker), defaultValue: null, propertyChanged: OnPropertyChanged);

        public string AssistiveText
        {
            get { return (string)GetValue(AssistiveTextProperty); }
            set { SetValue(AssistiveTextProperty, value); }
        }

        public static readonly BindableProperty LabelTextColorProperty =
            BindableProperty.Create(nameof(LabelTextColor), typeof(Color), typeof(MaterialTimePicker), defaultValue: Color.Gray, propertyChanged: OnPropertyChanged);

        public Color LabelTextColor
        {
            get { return (Color)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public static readonly BindableProperty FocusedLabelTextColorProperty =
            BindableProperty.Create(nameof(FocusedLabelTextColor), typeof(Color), typeof(MaterialTimePicker), defaultValue: Color.Gray, propertyChanged: OnPropertyChanged);

        public Color FocusedLabelTextColor
        {
            get { return (Color)GetValue(FocusedLabelTextColorProperty); }
            set { SetValue(FocusedLabelTextColorProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialTimePicker), defaultValue: Color.Gray, propertyChanged: OnPropertyChanged);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty AssistiveTextColorProperty =
            BindableProperty.Create(nameof(AssistiveTextColor), typeof(Color), typeof(MaterialTimePicker), defaultValue: Color.Gray, propertyChanged: OnPropertyChanged);

        public Color AssistiveTextColor
        {
            get { return (Color)GetValue(AssistiveTextColorProperty); }
            set { SetValue(AssistiveTextColorProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialTimePicker), defaultValue: Color.LightGray, propertyChanged: OnPropertyChanged);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty LabelSizeProperty =
            BindableProperty.Create(nameof(LabelSize), typeof(double), typeof(MaterialTimePicker), defaultValue: Font.Default.FontSize, propertyChanged: OnPropertyChanged);

        public double LabelSize
        {
            get { return (double)GetValue(LabelSizeProperty); }
            set { SetValue(LabelSizeProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MaterialEntry), defaultValue: 14.0, propertyChanged: OnPropertyChanged);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty AssistiveSizeProperty =
            BindableProperty.Create(nameof(AssistiveSize), typeof(double), typeof(MaterialTimePicker), defaultValue: Font.Default.FontSize, propertyChanged: OnPropertyChanged);

        public double AssistiveSize
        {
            get { return (double)GetValue(AssistiveSizeProperty); }
            set { SetValue(AssistiveSizeProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(MaterialTimePicker), defaultValue: Color.LightGray, propertyChanged: OnPropertyChanged);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty FocusedBorderColorProperty =
            BindableProperty.Create(nameof(FocusedBorderColor), typeof(Color), typeof(MaterialTimePicker), defaultValue: Color.LightGray, propertyChanged: OnPropertyChanged);

        public Color FocusedBorderColor
        {
            get { return (Color)GetValue(FocusedBorderColorProperty); }
            set { SetValue(FocusedBorderColorProperty, value); }
        }

        public static readonly BindableProperty LeadingIconProperty =
            BindableProperty.Create(nameof(LeadingIcon), typeof(string), typeof(MaterialTimePicker), defaultValue: null, propertyChanged: OnPropertyChanged);

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
            BindableProperty.Create(nameof(TrailingIcon), typeof(string), typeof(MaterialTimePicker), defaultValue: null, propertyChanged: OnPropertyChanged);

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

        private static void OnTimeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialTimePicker)bindable;
            control.pckTime.Time = (TimeSpan)newValue;
        }

        private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialTimePicker)bindable;
            control.ApplyControlProperties();
        }

        private void ApplyControlProperties()
        {
            if (!this.initialized)
            {
                this.InitializeComponent();
                this.initialized = true;
            }

            this.pckTime.IsEnabled = this.IsEnabled;
            this.pckTime.TextColor = this.TextColor;
            this.pckTime.FontSize = this.FontSize;
            this.pckTime.Format = this.Format;

            this.lblLabel.Text = this.LabelText;
            this.lblLabel.TextColor = this.LabelTextColor;
            this.lblLabel.FontSize = this.LabelSize;

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
            this.imgTrailingIcon.IsVisible = this.TrailingIconIsVisible && this.IsEnabled;
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

        #endregion Methods
    }
}