using System;
using System.Runtime.CompilerServices;
using Plugin.MaterialDesignControls.Implementations;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls
{
    public class MaterialField : ContentView
    {
        #region Constructors

        public MaterialField()
        {
            var mainStackLayout = new StackLayout { Spacing = 2 };

            this.lblLabel = new MaterialLabel
            {
                Margin = new Thickness(0),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Start,
                TextColor = this.LabelTextColor,
                FontSize = this.LabelSize
            };
            mainStackLayout.Children.Add(this.lblLabel);

            var secondStackLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            mainStackLayout.Children.Add(secondStackLayout);

            this.imgLeadingIcon = new CustomImageButton
            {
                HorizontalOptions = LayoutOptions.Start,
                IsVisible = false
            };
            if (this.LeadingIconIsVisible)
            {
                this.imgLeadingIcon.Image.Source = this.LeadingIcon;
                this.imgLeadingIcon.IsVisible = true;
            }
            secondStackLayout.Children.Add(this.imgLeadingIcon);

            this.lblText = new MaterialLabel
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Start,
                TextColor = this.TextColor,
                FontSize = this.TextSize,
            };
            secondStackLayout.Children.Add(this.lblText);

            this.imgTrailingIcon = new CustomImageButton
            {
                HorizontalOptions = LayoutOptions.End,
                IsVisible = false
            };
            if (this.TrailingIconIsVisible)
            {
                this.imgTrailingIcon.Image.Source = this.TrailingIcon;
                this.imgTrailingIcon.IsVisible = true;
            }
            secondStackLayout.Children.Add(this.imgTrailingIcon);

            this.lblAssistive = new MaterialLabel
            {
                Margin = new Thickness(0),
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Start,
                TextColor = this.AssistiveTextColor,
                FontSize = this.AssistiveSize
            };
            mainStackLayout.Children.Add(this.lblAssistive);

            if (this.LeadingIconIsVisible)
            {
                this.lblLabel.Margin = new Thickness(36, 0, 0, 0);
                this.lblAssistive.Margin = new Thickness(36, 0, 0, 0);
            }

            this.Content = mainStackLayout;

            this.initialized = true;
        }

        #endregion Constructors

        #region Attributes

        private bool initialized = false;

        private MaterialLabel lblLabel;

        private CustomImageButton imgLeadingIcon;

        private MaterialLabel lblText;

        private CustomImageButton imgTrailingIcon;

        private MaterialLabel lblAssistive;

        #endregion Attributes

        #region Properties

        public static readonly BindableProperty LabelTextProperty =
            BindableProperty.Create(nameof(LabelText), typeof(string), typeof(MaterialField), defaultValue: null);

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialField), defaultValue: null, defaultBindingMode: BindingMode.TwoWay);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty EmptyTextProperty =
            BindableProperty.Create(nameof(EmptyText), typeof(string), typeof(MaterialField), defaultValue: null, defaultBindingMode: BindingMode.TwoWay);

        public string EmptyText
        {
            get { return (string)GetValue(EmptyTextProperty); }
            set { SetValue(EmptyTextProperty, value); }
        }

        public static readonly BindableProperty AssistiveTextProperty =
            BindableProperty.Create(nameof(AssistiveText), typeof(string), typeof(MaterialField), defaultValue: null);

        public string AssistiveText
        {
            get { return (string)GetValue(AssistiveTextProperty); }
            set { SetValue(AssistiveTextProperty, value); }
        }

        public static readonly BindableProperty LabelTextColorProperty =
            BindableProperty.Create(nameof(LabelTextColor), typeof(Color), typeof(MaterialField), defaultValue: Color.Gray);

        public Color LabelTextColor
        {
            get { return (Color)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialField), defaultValue: Color.Gray);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty AssistiveTextColorProperty =
            BindableProperty.Create(nameof(AssistiveTextColor), typeof(Color), typeof(MaterialField), defaultValue: Color.Gray);

        public Color AssistiveTextColor
        {
            get { return (Color)GetValue(AssistiveTextColorProperty); }
            set { SetValue(AssistiveTextColorProperty, value); }
        }

        public static readonly BindableProperty LabelSizeProperty =
            BindableProperty.Create(nameof(LabelSize), typeof(double), typeof(MaterialField), defaultValue: Font.Default.FontSize);

        public double LabelSize
        {
            get { return (double)GetValue(LabelSizeProperty); }
            set { SetValue(LabelSizeProperty, value); }
        }

        public static readonly BindableProperty TextSizeProperty =
            BindableProperty.Create(nameof(TextSize), typeof(double), typeof(MaterialField), defaultValue: Font.Default.FontSize);

        public double TextSize
        {
            get { return (double)GetValue(TextSizeProperty); }
            set { SetValue(TextSizeProperty, value); }
        }

        public static readonly BindableProperty AssistiveSizeProperty =
            BindableProperty.Create(nameof(AssistiveSize), typeof(double), typeof(MaterialField), defaultValue: Font.Default.FontSize);

        public double AssistiveSize
        {
            get { return (double)GetValue(AssistiveSizeProperty); }
            set { SetValue(AssistiveSizeProperty, value); }
        }

        public static readonly BindableProperty LeadingIconProperty =
            BindableProperty.Create(nameof(LeadingIcon), typeof(string), typeof(MaterialField), defaultValue: null);

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
            BindableProperty.Create(nameof(TrailingIcon), typeof(string), typeof(MaterialField), defaultValue: null);

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

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.initialized)
            {
                switch (propertyName)
                {
                    case nameof(this.Text):
                    case nameof(this.EmptyText):
                        this.lblText.Text = !string.IsNullOrEmpty(this.Text) ? this.Text : this.EmptyText;
                        break;
                    case nameof(this.TextColor):
                        this.lblText.TextColor = this.TextColor;
                        break;
                    case nameof(this.TextSize):
                        this.lblText.FontSize = this.TextSize;
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
                    case nameof(this.AssistiveText):
                        this.lblAssistive.Text = this.AssistiveText;
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

                        if (this.LeadingIconIsVisible)
                        {
                            this.lblLabel.Margin = new Thickness(36, 0, 0, 0);
                            this.lblAssistive.Margin = new Thickness(36, 0, 0, 0);
                        }
                        break;
                    case nameof(this.TrailingIcon):
                        if (!string.IsNullOrEmpty(this.TrailingIcon))
                        {
                            this.imgTrailingIcon.Image.Source = this.TrailingIcon;
                        }
                        this.imgTrailingIcon.IsVisible = this.TrailingIconIsVisible;
                        break;
                }
            }
        }

        #endregion Methods
    }
}
