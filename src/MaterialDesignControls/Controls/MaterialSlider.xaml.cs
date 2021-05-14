
using Plugin.MaterialDesignControls.Animations;
using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialSlider : ContentView
    {
        #region constructors
        public MaterialSlider()
        {

            if (!this.initialized)
            {
                this.initialized = true;
                this.InitializeComponent();
            }
        }
        #endregion constructors

        #region attributes
        private bool initialized = false;
        public double OldValue;
        #endregion attributes

        #region properties
        public event EventHandler<ValueChangedEventArgs> ValueChanged;

        #region LabelText
        public static readonly BindableProperty LabelTextProperty =
            BindableProperty.Create(nameof(LabelText), typeof(string), typeof(MaterialSlider), defaultValue: null);

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public static readonly BindableProperty LabelTextColorProperty =
            BindableProperty.Create(nameof(LabelTextColor), typeof(Color), typeof(MaterialSlider), defaultValue: Color.Gray);

        public Color LabelTextColor
        {
            get { return (Color)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledLabelTextColorProperty =
            BindableProperty.Create(nameof(DisabledLabelTextColor), typeof(Color), typeof(MaterialSlider), defaultValue: Color.Gray);

        public Color DisabledLabelTextColor
        {
            get { return (Color)GetValue(DisabledLabelTextColorProperty); }
            set { SetValue(DisabledLabelTextColorProperty, value); }
        }

        public static readonly BindableProperty LabelSizeProperty =
            BindableProperty.Create(nameof(LabelSize), typeof(double), typeof(MaterialSlider), defaultValue: Font.Default.FontSize);

        public double LabelSize
        {
            get { return (double)GetValue(LabelSizeProperty); }
            set { SetValue(LabelSizeProperty, value); }
        }
        #endregion LabelText

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

        #region AssistiveText

        public static readonly BindableProperty AssistiveTextProperty =
            BindableProperty.Create(nameof(AssistiveText), typeof(string), typeof(BaseMaterialFieldControl), defaultValue: null, validateValue: OnAssistiveTextValidate);

        public string AssistiveText
        {
            get { return (string)GetValue(AssistiveTextProperty); }
            set { SetValue(AssistiveTextProperty, value); }
        }

        public static readonly BindableProperty AssistiveTextColorProperty =
            BindableProperty.Create(nameof(AssistiveTextColor), typeof(Color), typeof(BaseMaterialFieldControl), defaultValue: Color.Gray);

        public Color AssistiveTextColor
        {
            get { return (Color)GetValue(AssistiveTextColorProperty); }
            set { SetValue(AssistiveTextColorProperty, value); }
        }

        public static readonly BindableProperty AssistiveSizeProperty =
            BindableProperty.Create(nameof(AssistiveSize), typeof(double), typeof(BaseMaterialFieldControl), defaultValue: Font.Default.FontSize);

        public double AssistiveSize
        {
            get { return (double)GetValue(AssistiveSizeProperty); }
            set { SetValue(AssistiveSizeProperty, value); }
        }

        public static readonly BindableProperty AnimateErrorProperty =
            BindableProperty.Create(nameof(AnimateError), typeof(bool), typeof(BaseMaterialFieldControl), defaultValue: false);

        public bool AnimateError
        {
            get { return (bool)GetValue(AnimateErrorProperty); }
            set { SetValue(AnimateErrorProperty, value); }
        }

        #endregion AssistiveText

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

        #endregion properties

        #region methods
        public void ExecuteChanged()
        {
            ValueChangedEventArgs args = new ValueChangedEventArgs(OldValue, Value);
            ValueChanged?.Invoke(this, args);
        }

        private static bool OnAssistiveTextValidate(BindableObject bindable, object value)
        {
            var control = (MaterialSlider)bindable;

            // Used to animate the error when the assistive text doesn't change
            if (control.AnimateError && !string.IsNullOrEmpty(control.AssistiveText) && control.AssistiveText == (string)value)
                ShakeAnimation.Animate(control);

            return true;
        }

        private void OnValueChanged(object sender, ValueChangedEventArgs e)
        {
            this.Value = e.NewValue;
            this.OldValue = e.OldValue;
            ExecuteChanged();
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
                case nameof(LabelText):
                    lblLabel.Text = LabelText;
                    lblLabel.IsVisible = !string.IsNullOrEmpty(LabelText);
                    break;
                case nameof(LabelTextColor):
                    lblLabel.TextColor = LabelTextColor;
                    break;
                case nameof(DisabledLabelTextColor):
                    if (IsEnabled)
                        lblLabel.TextColor = LabelTextColor;
                    else
                        lblLabel.TextColor = DisabledLabelTextColor;
                    break;
                case nameof(LabelSize):
                    lblLabel.FontSize = LabelSize;
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
                    lblMaximum.IsVisible = !string.IsNullOrEmpty(LabelMaximumText) && ( !ShowIcons || !MaximumIconIsVisible);
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
                case nameof(AssistiveText):
                    lblAssistive.Text = AssistiveText;
                    lblAssistive.IsVisible = !string.IsNullOrEmpty(AssistiveText);
                    if (AnimateError && !string.IsNullOrEmpty(AssistiveText))
                        ShakeAnimation.Animate(this);
                    break;
                case nameof(AssistiveTextColor):
                    lblAssistive.TextColor = AssistiveTextColor;
                    break; 
                case nameof(AssistiveSize):
                    lblAssistive.FontSize = AssistiveSize;
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
            //slider.IsEnabled = IsEnabled;
            if(!IsEnabled)
            {
                lblLabel.TextColor = DisabledLabelTextColor;
                lblMinimum.TextColor = DisabledLabelMinimumTextColor;
                lblMaximum.TextColor = DisabledLabelMaximumTextColor;

                slider.ActiveTrackColor = DisabledActiveTrackColor;
                slider.InactiveTrackColor = DisabledInactiveTrackColor;
                slider.ThumbColor = DisabledThumbColor;
            }
            else
            {
                lblLabel.TextColor = LabelTextColor;
                lblMinimum.TextColor = LabelMinimumTextColor;
                lblMaximum.TextColor = LabelMaximumTextColor;

                slider.ActiveTrackColor = ActiveTrackColor;
                slider.InactiveTrackColor = InactiveTrackColor;
                slider.ThumbColor = ThumbColor;
            }

        }

        #endregion methods
    }
}