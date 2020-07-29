﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Plugin.MaterialDesignControls.Animations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialDoublePicker : ContentView
    {
        #region Constructors

        public MaterialDoublePicker()
        {
            if (!this.initialized)
            {
                this.initialized = true;
                this.InitializeComponent();
            }

            this.pckOptions.Focused += Handle_Focused;
            this.pckOptions.Unfocused += Handle_Unfocused;
            this.pckOptions.SelectedIndexesChanged += PckOptions_SelectedIndexesChanged;

            TapGestureRecognizer frameTapGestureRecognizer = new TapGestureRecognizer();
            frameTapGestureRecognizer.Tapped += (s, e) =>
            {
                this.pckOptions.Focus();
            };
            this.frmContainer.GestureRecognizers.Add(frameTapGestureRecognizer);
        }

        #endregion Constructors

        #region Attributes

        private bool initialized = false;

        #endregion Attributes

        #region Events

        public event EventHandler<SelectedIndexesEventArgs> SelectedIndexesChanged;

        #endregion Events

        #region Properties

        public static readonly BindableProperty TypeProperty =
            BindableProperty.Create(nameof(Type), typeof(FieldTypes), typeof(MaterialDoublePicker), defaultValue: FieldTypes.Filled);

        public FieldTypes Type
        {
            get { return (FieldTypes)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public static readonly new BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(MaterialDoublePicker), defaultValue: new Thickness(12, 0));

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        public static readonly new BindableProperty IsEnabledProperty =
            BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(MaterialDoublePicker), defaultValue: true);

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public static readonly BindableProperty LabelTextProperty =
            BindableProperty.Create(nameof(LabelText), typeof(string), typeof(MaterialDoublePicker), defaultValue: null);

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(MaterialDoublePicker), defaultValue: null, propertyChanged: OnItemsSourceChanged);

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty SecondaryItemsSourceProperty =
            BindableProperty.Create(nameof(SecondaryItemsSource), typeof(IEnumerable), typeof(MaterialDoublePicker), defaultValue: null, propertyChanged: OnSecondaryItemsSourceChanged);

        public IEnumerable SecondaryItemsSource
        {
            get { return (IEnumerable)GetValue(SecondaryItemsSourceProperty); }
            set { SetValue(SecondaryItemsSourceProperty, value); }
        }

        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(nameof(SelectedItem), typeof(string), typeof(MaterialDoublePicker), defaultValue: null, propertyChanged: OnSelectedItemChanged, defaultBindingMode: BindingMode.TwoWay);

        public string SelectedItem
        {
            get { return (string)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly BindableProperty SecondarySelectedItemProperty =
            BindableProperty.Create(nameof(SecondarySelectedItem), typeof(string), typeof(MaterialDoublePicker), defaultValue: null, propertyChanged: OnSecondarySelectedItemChanged, defaultBindingMode: BindingMode.TwoWay);

        public string SecondarySelectedItem
        {
            get { return (string)GetValue(SecondarySelectedItemProperty); }
            set { SetValue(SecondarySelectedItemProperty, value); }
        }

        public static readonly BindableProperty SeparatorProperty =
            BindableProperty.Create(nameof(Separator), typeof(string), typeof(MaterialDoublePicker), defaultValue: " ");

        public string Separator
        {
            get { return (string)GetValue(SeparatorProperty); }
            set { SetValue(SeparatorProperty, value); }
        }

        public static readonly BindableProperty AssistiveTextProperty =
            BindableProperty.Create(nameof(AssistiveText), typeof(string), typeof(MaterialDoublePicker), defaultValue: null);

        public string AssistiveText
        {
            get { return (string)GetValue(AssistiveTextProperty); }
            set { SetValue(AssistiveTextProperty, value); }
        }

        public static readonly BindableProperty LabelTextColorProperty =
            BindableProperty.Create(nameof(LabelTextColor), typeof(Color), typeof(MaterialDoublePicker), defaultValue: Color.Gray);

        public Color LabelTextColor
        {
            get { return (Color)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public static readonly BindableProperty FocusedLabelTextColorProperty =
            BindableProperty.Create(nameof(FocusedLabelTextColor), typeof(Color), typeof(MaterialDoublePicker), defaultValue: Color.Gray);

        public Color FocusedLabelTextColor
        {
            get { return (Color)GetValue(FocusedLabelTextColorProperty); }
            set { SetValue(FocusedLabelTextColorProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialDoublePicker), defaultValue: Color.Gray);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty AssistiveTextColorProperty =
            BindableProperty.Create(nameof(AssistiveTextColor), typeof(Color), typeof(MaterialDoublePicker), defaultValue: Color.Gray);

        public Color AssistiveTextColor
        {
            get { return (Color)GetValue(AssistiveTextColorProperty); }
            set { SetValue(AssistiveTextColorProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialDoublePicker), defaultValue: Color.LightGray);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty LabelSizeProperty =
            BindableProperty.Create(nameof(LabelSize), typeof(double), typeof(MaterialDoublePicker), defaultValue: Font.Default.FontSize);

        public double LabelSize
        {
            get { return (double)GetValue(LabelSizeProperty); }
            set { SetValue(LabelSizeProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MaterialDoublePicker), defaultValue: Font.Default.FontSize);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(MaterialDoublePicker), defaultValue: null);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public static readonly BindableProperty AssistiveSizeProperty =
            BindableProperty.Create(nameof(AssistiveSize), typeof(double), typeof(MaterialDoublePicker), defaultValue: Font.Default.FontSize);

        public double AssistiveSize
        {
            get { return (double)GetValue(AssistiveSizeProperty); }
            set { SetValue(AssistiveSizeProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(MaterialDoublePicker), defaultValue: Color.LightGray);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty FocusedBorderColorProperty =
            BindableProperty.Create(nameof(FocusedBorderColor), typeof(Color), typeof(MaterialDoublePicker), defaultValue: Color.LightGray);

        public Color FocusedBorderColor
        {
            get { return (Color)GetValue(FocusedBorderColorProperty); }
            set { SetValue(FocusedBorderColorProperty, value); }
        }

        public static readonly BindableProperty LeadingIconProperty =
            BindableProperty.Create(nameof(LeadingIcon), typeof(string), typeof(MaterialDoublePicker), defaultValue: null);

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
            BindableProperty.Create(nameof(TrailingIcon), typeof(string), typeof(MaterialDoublePicker), defaultValue: null);

        public string TrailingIcon
        {
            get { return (string)GetValue(TrailingIconProperty); }
            set { SetValue(TrailingIconProperty, value); }
        }

        public bool TrailingIconIsVisible
        {
            get { return !string.IsNullOrEmpty(this.TrailingIcon); }
        }

        public static readonly BindableProperty AnimateErrorProperty =
            BindableProperty.Create(nameof(AnimateError), typeof(bool), typeof(MaterialDoublePicker), defaultValue: false);

        public bool AnimateError
        {
            get { return (bool)GetValue(AnimateErrorProperty); }
            set { SetValue(AnimateErrorProperty, value); }
        }

        public int SelectedIndex
        {
            get
            {
                if (this.ItemsSource != null)
                {
                    var index = 0;
                    foreach (var item in this.ItemsSource)
                    {
                        if (index.Equals(this.pckOptions.SelectedIndexes[0]))
                        {
                            return index;
                        }
                        index++;
                    }
                }

                return -1;
            }
        }

        public int SecondarySelectedIndex
        {
            get
            {
                if (this.SecondaryItemsSource != null)
                {
                    var index = 0;
                    foreach (var item in this.SecondaryItemsSource)
                    {
                        if (index.Equals(this.pckOptions.SelectedIndexes[1]))
                        {
                            return index;
                        }
                        index++;
                    }
                }

                return -1;
            }
        }

        public static readonly BindableProperty HorizontalTextAlignmentProperty =
            BindableProperty.Create(nameof(HorizontalTextAlignment), typeof(TextAlignment), typeof(MaterialDoublePicker), defaultValue: TextAlignment.Start);

        public TextAlignment HorizontalTextAlignment
        {
            get { return (TextAlignment)GetValue(HorizontalTextAlignmentProperty); }
            set { SetValue(HorizontalTextAlignmentProperty, value); }
        }

        public static readonly BindableProperty PlaceholderProperty =
            BindableProperty.Create(nameof(Placeholder), typeof(string), typeof(MaterialDoublePicker), defaultValue: null);

        public string Placeholder
        {
            get { return (string)GetValue(PlaceholderProperty); }
            set { SetValue(PlaceholderProperty, value); }
        }

        public static readonly BindableProperty PlaceholderColorProperty =
            BindableProperty.Create(nameof(PlaceholderColor), typeof(Color), typeof(MaterialDoublePicker), defaultValue: Color.Gray);

        public Color PlaceholderColor
        {
            get { return (Color)GetValue(PlaceholderColorProperty); }
            set { SetValue(PlaceholderColorProperty, value); }
        }

        public static readonly BindableProperty FieldHeightRequestProperty =
            BindableProperty.Create(nameof(FieldHeightRequest), typeof(double), typeof(MaterialDoublePicker), defaultValue: 40.0);

        public double FieldHeightRequest
        {
            get { return (double)GetValue(FieldHeightRequestProperty); }
            set { SetValue(FieldHeightRequestProperty, value); }
        }

        public new bool IsFocused
        {
            get { return this.pckOptions.IsFocused; }
        }

        #endregion Properties

        #region Methods

        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialDoublePicker)bindable;
            //control.pckOptions.SelectedItem = (string)newValue;
            //control.pckOptions.SelectedIndexes = new int[] { control.SelectedIndex, control.SecondarySelectedIndex };

            control.InternalUpdateSelectedIndex();
        }

        private static void OnSecondarySelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialDoublePicker)bindable;
            //control.pckOptions.SelectedItem = (string)newValue;
            //control.pckOptions.SelectedIndexes = new int[] { control.SelectedIndex, control.SecondarySelectedIndex };

            control.InternalUpdateSelectedIndex();
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialDoublePicker)bindable;
            control.pckOptions.Items.Clear();
            if (!Equals(newValue, null) && newValue is IEnumerable)
            {
                foreach (var item in (IEnumerable)newValue)
                {
                    control.pckOptions.Items.Add(item.ToString());
                }
            }
            control.InternalUpdateSelectedIndex();
        }

        private static void OnSecondaryItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialDoublePicker)bindable;
            control.pckOptions.SecondaryItems.Clear();
            if (!Equals(newValue, null) && newValue is IEnumerable)
            {
                foreach (var item in (IEnumerable)newValue)
                {
                    control.pckOptions.SecondaryItems.Add(item.ToString());
                }
            }
            control.InternalUpdateSelectedIndex();
        }

        private void InternalUpdateSelectedIndex()
        {
            var selectedIndex = -1;
            if (this.ItemsSource != null)
            {
                var index = 0;
                foreach (var item in this.ItemsSource)
                {
                    if (item != null && item.Equals(this.SelectedItem))
                    {
                        selectedIndex = index;
                        break;
                    }
                    index++;
                }
            }

            var secondarySelectedIndex = -1;
            if (this.SecondaryItemsSource != null)
            {
                var index = 0;
                foreach (var item in this.SecondaryItemsSource)
                {
                    if (item != null && item.Equals(this.SecondarySelectedItem))
                    {
                        secondarySelectedIndex = index;
                        break;
                    }
                    index++;
                }
            }

            this.pckOptions.SelectedIndexes = new int[] { selectedIndex, secondarySelectedIndex };
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
                    this.pckOptions.IsEnabled = this.IsEnabled;
                    break;
                case nameof(this.TextColor):
                    this.pckOptions.TextColor = this.TextColor;
                    break;
                case nameof(this.FontSize):
                    this.pckOptions.FontSize = this.FontSize;
                    break;
                case nameof(this.FontFamily):
                    this.pckOptions.FontFamily = this.FontFamily;
                    this.lblLabel.FontFamily = this.FontFamily;
                    this.lblAssistive.FontFamily = this.FontFamily;
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

                case nameof(this.LeadingIcon):
                    if (!string.IsNullOrEmpty(this.LeadingIcon))
                    {
                        this.imgLeadingIcon.Image.Source = this.LeadingIcon;
                    }
                    this.imgLeadingIcon.IsVisible = this.LeadingIconIsVisible;
                    break;
                case nameof(this.TrailingIcon):
                    if (!string.IsNullOrEmpty(this.TrailingIcon))
                    {
                        this.imgTrailingIcon.Image.Source = this.TrailingIcon;
                    }
                    this.imgTrailingIcon.IsVisible = this.TrailingIconIsVisible && this.IsEnabled;
                    break;

                case nameof(this.HorizontalTextAlignment):
                    this.lblLabel.HorizontalTextAlignment = this.HorizontalTextAlignment;
                    this.pckOptions.HorizontalTextAlignment = this.HorizontalTextAlignment;
                    this.lblAssistive.HorizontalTextAlignment = this.HorizontalTextAlignment;
                    break;

                case nameof(this.Placeholder):
                    this.pckOptions.Placeholder = this.Placeholder;
                    break;
                case nameof(this.PlaceholderColor):
                    this.pckOptions.PlaceholderColor = this.PlaceholderColor;
                    break;

                case nameof(this.Separator):
                    this.pckOptions.Separator = this.Separator;
                    break;

                case nameof(this.FieldHeightRequest):
                    this.frmContainer.HeightRequest = this.FieldHeightRequest;
                    break;
                default:
                    base.OnPropertyChanged(propertyName);
                    break;
            }
        }

        public new bool Focus()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                this.pckOptions.Focus();
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

        private void PckOptions_SelectedIndexesChanged(object sender, SelectedIndexesEventArgs e)
        {
            if (this.ItemsSource != null)
            {
                var index = 0;
                foreach (var item in this.ItemsSource)
                {
                    if (index.Equals(e.SelectedIndexes[0]))
                    {
                        this.SelectedItem = item.ToString();
                        break;
                    }
                    index++;
                }
            }

            if (this.SecondaryItemsSource != null)
            {
                var index = 0;
                foreach (var item in this.SecondaryItemsSource)
                {
                    if (index.Equals(e.SelectedIndexes[1]))
                    {
                        this.SecondarySelectedItem = item.ToString();
                        break;
                    }
                    index++;
                }
            }

            if (this.SelectedIndexesChanged != null)
            {
                this.SelectedIndexesChanged.Invoke(this, e);
            }
        }

        #endregion Methods
    }

    public class SelectedIndexesEventArgs : EventArgs
    {
        public int[] SelectedIndexes { get; set; }
    }
}
