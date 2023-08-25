using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Implementations;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3
{
    public class MaterialSlider : MaterialCustomControl
    {
        #region Constructors

        public MaterialSlider() : base()
        {
            StackLayout mainContainer = new StackLayout()
            {
                Spacing = 2
            };

            StackLayout headerContainer = new StackLayout()
            {
                Margin = new Thickness(0, 0, 14, 2),
                Orientation = StackOrientation.Horizontal
            };

            //lblLabel = new MaterialLabel()
            //{
            //    IsVisible = false,
            //    LineBreakMode = LineBreakMode.NoWrap,
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    HorizontalTextAlignment = TextAlignment.End,
            //    VerticalTextAlignment = TextAlignment.Center
            //};

            lblValue = new MaterialLabel()
            {
                IsVisible = false,
                LineBreakMode = LineBreakMode.NoWrap,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center
            };

            //headerContainer.Children.Add(lblLabel);
            headerContainer.Children.Add(lblValue);

            mainContainer.Children.Add(headerContainer);

            Grid grid = new Grid()
            {
                Padding = new Thickness(0),
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 50,
                Margin = new Thickness(0),
            };

            bckgImage = new CustomImage()
            {
                IsVisible = false,
                Padding = new Thickness(10, 0)
            };

            bckgImage.SetValue(Grid.RowProperty, 0);

            grid.Children.Add(bckgImage);

            StackLayout sliderContainer = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            sliderContainer.SetValue(Grid.RowProperty, 0);

            imgMinimum = new CustomImageButton()
            {
                IsVisible = false,
                HorizontalOptions = LayoutOptions.Start
            };

            lblMinimum = new MaterialLabel()
            {
                IsVisible = false,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            };

            slider = new CustomSlider()
            {
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 10, 0, 10),
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            slider.ValueChanged += OnValueChanged;

            lblMaximum = new MaterialLabel()
            {
                IsVisible = false,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center
            };

            imgMaximum = new CustomImageButton()
            {
                IsVisible = false,
                HorizontalOptions = LayoutOptions.End
            };

            sliderContainer.Children.Add(imgMinimum);
            sliderContainer.Children.Add(lblMinimum);
            sliderContainer.Children.Add(slider);
            sliderContainer.Children.Add(lblMaximum);
            sliderContainer.Children.Add(imgMaximum);

            grid.Children.Add(sliderContainer);

            mainContainer.Children.Add(grid);

            base.CustomControl = mainContainer;
        }

        #endregion Constructors

        #region Attributes

        //private MaterialLabel lblLabel;
        private MaterialLabel lblValue;
        private CustomImage bckgImage;
        private CustomImageButton imgMinimum;
        private MaterialLabel lblMinimum;
        private CustomSlider slider;
        private MaterialLabel lblMaximum;
        private CustomImageButton imgMaximum;


        private bool initialized = false;
        public double OldValue;

        #endregion Attributes

        #region Properties

        public event EventHandler<ValueChangedEventArgs> ValueChanged;

        #region LabelValue

        public static readonly BindableProperty LabelValueFormatProperty =
            BindableProperty.Create(nameof(LabelValueFormat), typeof(string), typeof(MaterialSlider), defaultValue: null);

        public string LabelValueFormat
        {
            get { return (string)GetValue(LabelValueFormatProperty); }
            set { SetValue(LabelValueFormatProperty, value); }
        }

        public static readonly BindableProperty LabelValueColorProperty =
            BindableProperty.Create(nameof(LabelValueColor), typeof(Color), typeof(MaterialSlider), defaultValue: Color.Gray);

        public Color LabelValueColor
        {
            get { return (Color)GetValue(LabelValueColorProperty); }
            set { SetValue(LabelValueColorProperty, value); }
        }

        public static readonly BindableProperty DisabledLabelValueColorProperty =
            BindableProperty.Create(nameof(DisabledLabelValueColor), typeof(Color), typeof(MaterialSlider), defaultValue: Color.Gray);

        public Color DisabledLabelValueColor
        {
            get { return (Color)GetValue(DisabledLabelValueColorProperty); }
            set { SetValue(DisabledLabelValueColorProperty, value); }
        }

        public static readonly BindableProperty LabelValueSizeProperty =
            BindableProperty.Create(nameof(LabelValueSize), typeof(double), typeof(MaterialSlider), defaultValue: Font.Default.FontSize);

        public double LabelValueSize
        {
            get { return (double)GetValue(LabelValueSizeProperty); }
            set { SetValue(LabelValueSizeProperty, value); }
        }

        public static readonly BindableProperty LabelValueIsVisibleProperty =
            BindableProperty.Create(nameof(LabelValueIsVisible), typeof(bool), typeof(MaterialSlider), defaultValue: false);

        public bool LabelValueIsVisible
        {
            get { return (bool)GetValue(LabelValueIsVisibleProperty); }
            set { SetValue(LabelValueIsVisibleProperty, value); }
        }

        #endregion LabelValue

        #region LabelMinimum

        public static readonly BindableProperty LabelMinimumTextProperty =
            BindableProperty.Create(nameof(LabelMinimumText), typeof(string), typeof(MaterialSlider), defaultValue: null);

        public string LabelMinimumText
        {
            get { return (string)GetValue(LabelMinimumTextProperty); }
            set { SetValue(LabelMinimumTextProperty, value); }
        }

        public static readonly BindableProperty LabelMinimumTextColorProperty =
            BindableProperty.Create(nameof(LabelMinimumTextColor), typeof(Color), typeof(MaterialSlider), defaultValue: Color.Gray);

        public Color LabelMinimumTextColor
        {
            get { return (Color)GetValue(LabelMinimumTextColorProperty); }
            set { SetValue(LabelMinimumTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledLabelMinimumTextColorProperty =
            BindableProperty.Create(nameof(DisabledLabelMinimumTextColor), typeof(Color), typeof(MaterialSlider), defaultValue: Color.Gray);

        public Color DisabledLabelMinimumTextColor
        {
            get { return (Color)GetValue(DisabledLabelMinimumTextColorProperty); }
            set { SetValue(DisabledLabelMinimumTextColorProperty, value); }
        }

        public static readonly BindableProperty LabelMinimumSizeProperty =
            BindableProperty.Create(nameof(LabelMinimumSize), typeof(double), typeof(MaterialSlider), defaultValue: Font.Default.FontSize);

        public double LabelMinimumSize
        {
            get { return (double)GetValue(LabelMinimumSizeProperty); }
            set { SetValue(LabelMinimumSizeProperty, value); }
        }

        #endregion LabelMinimumText

        #region LabelMaximum

        public static readonly BindableProperty LabelMaximumTextProperty =
            BindableProperty.Create(nameof(LabelMaximumText), typeof(string), typeof(MaterialSlider), defaultValue: null);

        public string LabelMaximumText
        {
            get { return (string)GetValue(LabelMaximumTextProperty); }
            set { SetValue(LabelMaximumTextProperty, value); }
        }

        public static readonly BindableProperty LabelMaximumTextColorProperty =
            BindableProperty.Create(nameof(LabelMaximumTextColor), typeof(Color), typeof(MaterialSlider), defaultValue: Color.Gray);

        public Color LabelMaximumTextColor
        {
            get { return (Color)GetValue(LabelMaximumTextColorProperty); }
            set { SetValue(LabelMaximumTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledLabelMaximumTextColorProperty =
            BindableProperty.Create(nameof(DisabledLabelMaximumTextColor), typeof(Color), typeof(MaterialSlider), defaultValue: Color.Gray);

        public Color DisabledLabelMaximumTextColor
        {
            get { return (Color)GetValue(DisabledLabelMaximumTextColorProperty); }
            set { SetValue(DisabledLabelMaximumTextColorProperty, value); }
        }

        public static readonly BindableProperty LabelMaximumSizeProperty =
            BindableProperty.Create(nameof(LabelMaximumSize), typeof(double), typeof(MaterialSlider), defaultValue: Font.Default.FontSize);

        public double LabelMaximumSize
        {
            get { return (double)GetValue(LabelMaximumSizeProperty); }
            set { SetValue(LabelMaximumSizeProperty, value); }
        }

        #endregion LabelMaximumText

        #region ImageMinimum

        public static readonly BindableProperty MinimumIconProperty =
            BindableProperty.Create(nameof(MinimumIcon), typeof(string), typeof(MaterialSlider), defaultValue: null);

        public string MinimumIcon
        {
            get { return (string)GetValue(MinimumIconProperty); }
            set { SetValue(MinimumIconProperty, value); }
        }

        public static readonly BindableProperty CustomMinimumIconProperty =
            BindableProperty.Create(nameof(CustomMinimumIcon), typeof(View), typeof(MaterialSlider), defaultValue: null);

        public View CustomMinimumIcon
        {
            get { return (View)GetValue(CustomMinimumIconProperty); }
            set { SetValue(CustomMinimumIconProperty, value); }
        }

        public bool MinimumIconIsVisible
        {
            get { return !string.IsNullOrEmpty(this.MinimumIcon) || CustomMinimumIcon != null; }
        }

        #endregion ImageMinimum

        #region ImageMaximum

        public static readonly BindableProperty MaximumIconProperty =
            BindableProperty.Create(nameof(MaximumIcon), typeof(string), typeof(MaterialSlider), defaultValue: null);

        public string MaximumIcon
        {
            get { return (string)GetValue(MaximumIconProperty); }
            set { SetValue(MaximumIconProperty, value); }
        }

        public static readonly BindableProperty CustomMaximumIconProperty =
            BindableProperty.Create(nameof(CustomMaximumIcon), typeof(View), typeof(MaterialSlider), defaultValue: null);

        public View CustomMaximumIcon
        {
            get { return (View)GetValue(CustomMaximumIconProperty); }
            set { SetValue(CustomMaximumIconProperty, value); }
        }

        public bool MaximumIconIsVisible
        {
            get { return !string.IsNullOrEmpty(this.MaximumIcon) || CustomMaximumIcon != null; }
        }

        #endregion ImageMaximum

        #region BackGroundImage

        public static readonly BindableProperty BackgroundImageProperty =
           BindableProperty.Create(nameof(BackgroundImage), typeof(string), typeof(MaterialSlider), defaultValue: null);

        public string BackgroundImage
        {
            get { return (string)GetValue(BackgroundImageProperty); }
            set { SetValue(BackgroundImageProperty, value); }
        }

        public static readonly BindableProperty CustomBackgroundImageProperty =
            BindableProperty.Create(nameof(CustomBackgroundImage), typeof(View), typeof(MaterialSlider), defaultValue: null);

        public View CustomBackgroundImage
        {
            get { return (View)GetValue(CustomBackgroundImageProperty); }
            set { SetValue(CustomBackgroundImageProperty, value); }
        }

        #endregion BackGroundImage

        #region ThumbImage

        public static readonly BindableProperty ThumbImageProperty =
            BindableProperty.Create(nameof(ThumbImage), typeof(string), typeof(MaterialSlider), defaultValue: null);

        public string ThumbImage
        {
            get { return (string)GetValue(ThumbImageProperty); }
            set { SetValue(ThumbImageProperty, value); }
        }

        #endregion ThumbImage

        #region Values

        public static readonly BindableProperty ValueProperty =
            BindableProperty.Create(nameof(Value), typeof(double), typeof(MaterialSlider), defaultValue: 0.0, defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnValuePropertyChanged);

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly BindableProperty MinimumValueProperty =
            BindableProperty.Create(nameof(MinimumValue), typeof(double), typeof(MaterialSlider), defaultValue: 0.0);

        public double MinimumValue
        {
            get { return (double)GetValue(MinimumValueProperty); }
            set { SetValue(MinimumValueProperty, value); }
        }

        public static readonly BindableProperty MaximumValueProperty =
            BindableProperty.Create(nameof(MaximumValue), typeof(double), typeof(MaterialSlider), defaultValue: 1.0);

        public double MaximumValue
        {
            get { return (double)GetValue(MaximumValueProperty); }
            set { SetValue(MaximumValueProperty, value); }
        }

        #endregion Values

        public static readonly BindableProperty ActiveTrackColorProperty =
            BindableProperty.Create(nameof(ActiveTrackColor), typeof(Color), typeof(MaterialSlider), defaultValue: Color.Black);

        public Color ActiveTrackColor
        {
            get { return (Color)GetValue(ActiveTrackColorProperty); }
            set { SetValue(ActiveTrackColorProperty, value); }
        }

        public static readonly BindableProperty InactiveTrackColorProperty =
            BindableProperty.Create(nameof(InactiveTrackColor), typeof(Color), typeof(MaterialSlider), defaultValue: Color.Gray);

        public Color InactiveTrackColor
        {
            get { return (Color)GetValue(InactiveTrackColorProperty); }
            set { SetValue(InactiveTrackColorProperty, value); }
        }

        public static readonly BindableProperty ThumbColorProperty =
            BindableProperty.Create(nameof(ThumbColor), typeof(Color), typeof(MaterialSlider), defaultValue: Color.Black);

        public Color ThumbColor
        {
            get { return (Color)GetValue(ThumbColorProperty); }
            set { SetValue(ThumbColorProperty, value); }
        }

        public static readonly BindableProperty TrackHeightProperty =
            BindableProperty.Create(nameof(TrackHeight), typeof(int), typeof(MaterialSlider), defaultValue: 6);

        public int TrackHeight
        {
            get { return (int)GetValue(TrackHeightProperty); }
            set { SetValue(TrackHeightProperty, value); }
        }

        public static readonly BindableProperty TrackCornerRadiusProperty =
            BindableProperty.Create(nameof(TrackCornerRadius), typeof(int), typeof(MaterialSlider), defaultValue: 3);

        public int TrackCornerRadius
        {
            get { return (int)GetValue(TrackCornerRadiusProperty); }
            set { SetValue(TrackCornerRadiusProperty, value); }
        }

        public static readonly BindableProperty UserInteractionEnabledProperty =
            BindableProperty.Create(nameof(UserInteractionEnabled), typeof(bool), typeof(MaterialSlider), defaultValue: true);

        public bool UserInteractionEnabled
        {
            get { return (bool)GetValue(UserInteractionEnabledProperty); }
            set { SetValue(UserInteractionEnabledProperty, value); }
        }

        public static readonly BindableProperty ShowIconsProperty =
                BindableProperty.Create(nameof(ShowIcons), typeof(bool), typeof(MaterialSlider), defaultValue: false);

        public bool ShowIcons
        {
            get { return (bool)GetValue(ShowIconsProperty); }
            set { SetValue(ShowIconsProperty, value); }
        }


        public static readonly BindableProperty DisabledActiveTrackColorProperty =
            BindableProperty.Create(nameof(DisabledActiveTrackColor), typeof(Color), typeof(MaterialSlider), defaultValue: Color.Gray);

        public Color DisabledActiveTrackColor
        {
            get { return (Color)GetValue(DisabledActiveTrackColorProperty); }
            set { SetValue(DisabledActiveTrackColorProperty, value); }
        }

        public static readonly BindableProperty DisabledInactiveTrackColorProperty =
            BindableProperty.Create(nameof(DisabledInactiveTrackColor), typeof(Color), typeof(MaterialSlider), defaultValue: Color.LightGray);

        public Color DisabledInactiveTrackColor
        {
            get { return (Color)GetValue(DisabledInactiveTrackColorProperty); }
            set { SetValue(DisabledInactiveTrackColorProperty, value); }
        }

        public static readonly BindableProperty DisabledThumbColorProperty =
            BindableProperty.Create(nameof(DisabledThumbColor), typeof(Color), typeof(MaterialSlider), defaultValue: Color.Gray);

        public Color DisabledThumbColor
        {
            get { return (Color)GetValue(DisabledThumbColorProperty); }
            set { SetValue(DisabledThumbColorProperty, value); }
        }

        #endregion Properties

        #region Methods

        public void ExecuteChanged()
        {
            ValueChangedEventArgs args = new ValueChangedEventArgs(OldValue, Value);
            ValueChanged?.Invoke(this, args);
        }

        private void OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            this.Value = e.NewValue;
            this.OldValue = e.OldValue;

            if (LabelValueIsVisible)
                lblValue.Text = Value.ToString(LabelValueFormat);

            ExecuteChanged();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            switch (propertyName)
            {
                //case nameof(LabelText):
                //    lb.Text = LabelText;
                //    lblLabel.IsVisible = !string.IsNullOrEmpty(LabelText);
                //    break;
                //case nameof(LabelTextColor):
                //    lblLabel.TextColor = LabelTextColor;
                //    break;
                //case nameof(DisabledLabelTextColor):
                //    if (IsEnabled)
                //        lblLabel.TextColor = LabelTextColor;
                //    else
                //        lblLabel.TextColor = DisabledLabelTextColor;
                //    break;
                //case nameof(LabelSize):
                //    lblLabel.FontSize = LabelSize;
                //    break;

                case nameof(LabelValueFormat):
                    lblValue.Text = Value.ToString(LabelValueFormat);
                    break;
                case nameof(LabelValueColor):
                    lblValue.TextColor = LabelValueColor;
                    break;
                case nameof(DisabledLabelValueColor):
                    lblValue.TextColor = IsEnabled ? LabelValueColor : DisabledLabelValueColor;
                    break;
                case nameof(LabelValueSize):
                    lblValue.FontSize = LabelValueSize;
                    break;
                case nameof(LabelValueIsVisible):
                    lblValue.IsVisible = LabelValueIsVisible;
                    lblValue.Text = Value.ToString(LabelValueFormat);
                    break;

                case nameof(LabelMinimumText):
                    lblMinimum.Text = LabelMinimumText;
                    lblMinimum.IsVisible = !string.IsNullOrEmpty(LabelMinimumText) && (!ShowIcons || !MinimumIconIsVisible);
                    break;
                case nameof(LabelMinimumTextColor):
                    lblMinimum.TextColor = LabelMinimumTextColor;
                    break;
                case nameof(DisabledLabelMinimumTextColor):
                    if (IsEnabled)
                        lblMinimum.TextColor = LabelMinimumTextColor;
                    else
                        lblMinimum.TextColor = DisabledLabelMinimumTextColor;
                    break;
                case nameof(LabelMinimumSize):
                    lblMinimum.FontSize = LabelMinimumSize;
                    break;
                case nameof(LabelMaximumText):
                    lblMaximum.Text = LabelMaximumText;
                    lblMaximum.IsVisible = !string.IsNullOrEmpty(LabelMaximumText) && (!ShowIcons || !MaximumIconIsVisible);
                    break;
                case nameof(LabelMaximumTextColor):
                    lblMaximum.TextColor = LabelMaximumTextColor;
                    break;
                case nameof(DisabledLabelMaximumTextColor):
                    if (IsEnabled)
                        lblMaximum.TextColor = LabelMaximumTextColor;
                    else
                        lblMaximum.TextColor = DisabledLabelMaximumTextColor;
                    break;
                case nameof(LabelMaximumSize):
                    lblMaximum.FontSize = LabelMaximumSize;
                    break;
                case nameof(MinimumIcon):
                    if (!string.IsNullOrEmpty(this.MinimumIcon))
                        imgMinimum.SetImage(MinimumIcon);

                    SetMinimumIconIsVisible();
                    break;
                case nameof(CustomMinimumIcon):
                    if (CustomMinimumIcon != null)
                        imgMinimum.SetCustomImage(CustomMinimumIcon);

                    SetMinimumIconIsVisible();
                    break;
                case nameof(MaximumIcon):
                    if (!string.IsNullOrEmpty(this.MaximumIcon))
                        imgMaximum.SetImage(MaximumIcon);

                    SetMaximumIconIsVisible();
                    break;
                case nameof(CustomMaximumIcon):
                    if (CustomMaximumIcon != null)
                        imgMaximum.SetCustomImage(CustomMaximumIcon);

                    SetMaximumIconIsVisible();
                    break;
                case nameof(BackgroundImage):
                    if (!string.IsNullOrEmpty(this.BackgroundImage))
                    {
                        bckgImage.SetImage(BackgroundImage);
                        bckgImage.IsVisible = true;
                    }
                    else
                        bckgImage.IsVisible = false;

                    break;
                case nameof(CustomBackgroundImage):
                    if (CustomBackgroundImage != null)
                    {
                        bckgImage.SetCustomImage(CustomBackgroundImage);
                        bckgImage.IsVisible = true;
                    }
                    else
                        bckgImage.IsVisible = false;

                    break;
                case nameof(ThumbImage):
                    if (!string.IsNullOrEmpty(this.ThumbImage))
                    {
                        slider.ThumbImageSource = ThumbImage;
                    }
                    break;
                case nameof(MinimumValue):
                    slider.Minimum = MinimumValue;
                    break;
                case nameof(MaximumValue):
                    slider.Maximum = MaximumValue;
                    break;
                case nameof(ActiveTrackColor):
                    slider.ActiveTrackColor = ActiveTrackColor;
                    break;
                case nameof(InactiveTrackColor):
                    slider.InactiveTrackColor = InactiveTrackColor;
                    break;
                case nameof(ThumbColor):
                    slider.ThumbColor = ThumbColor;
                    break;
                case nameof(TrackHeight):
                    slider.TrackHeight = TrackHeight;
                    break;
                case nameof(TrackCornerRadius):
                    slider.TrackCornerRadius = TrackCornerRadius;
                    break;
                case nameof(UserInteractionEnabled):
                    slider.UserInteractionEnabled = UserInteractionEnabled;
                    break;
                case nameof(IsEnabled):
                    this.IsEnabled = IsEnabled;
                    SetEnable();
                    break;
                case nameof(ShowIcons):
                    SetMinimumIconIsVisible();
                    SetMaximumIconIsVisible();
                    break;
            }

            base.OnPropertyChanged(propertyName);
        }

        private void SetMinimumIconIsVisible()
        {
            imgMinimum.IsVisible = ShowIcons && MinimumIconIsVisible;
        }

        private void SetMaximumIconIsVisible()
        {
            imgMaximum.IsVisible = ShowIcons && MaximumIconIsVisible;
        }

        public static void OnValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is MaterialSlider control && newValue != null && newValue is double value)
            {
                if (value >= control.MinimumValue && value <= control.MaximumValue)
                    control.slider.Value = value;
                else
                    control.Value = control.MinimumValue;
            }
        }

        public void SetEnable()
        {
            if (!IsEnabled)
            {
                //lblLabel.TextColor = DisabledLabelTextColor;
                lblValue.TextColor = DisabledLabelValueColor;
                lblMinimum.TextColor = DisabledLabelMinimumTextColor;
                lblMaximum.TextColor = DisabledLabelMaximumTextColor;

                slider.ActiveTrackColor = DisabledActiveTrackColor;
                slider.InactiveTrackColor = DisabledInactiveTrackColor;
                slider.ThumbColor = DisabledThumbColor;
            }
            else
            {
                //lblLabel.TextColor = LabelTextColor;
                lblValue.TextColor = LabelValueColor;
                lblMinimum.TextColor = LabelMinimumTextColor;
                lblMaximum.TextColor = LabelMaximumTextColor;

                slider.ActiveTrackColor = ActiveTrackColor;
                slider.InactiveTrackColor = InactiveTrackColor;
                slider.ThumbColor = ThumbColor;
            }
        }

        #endregion Methods
    }
}
