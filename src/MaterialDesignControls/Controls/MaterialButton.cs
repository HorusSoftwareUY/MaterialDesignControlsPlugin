using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Plugin.MaterialDesignControls.Animations;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls
{
    public class MaterialButton : ContentView, ITouchAndPressEffectConsumer
    {
        #region Constructors

        public MaterialButton()
        {
            if (!this.initialized)
            {
                this.Initialize();
            }
        }

        #endregion Constructors

        #region Attributes

        private bool initialized = false;

        protected Frame frmLayout;

        private StackLayout stcLayout;

        private Image imgIcon;

        private ContentView cntIcon;

        private MaterialLabel lblText;

        private ActivityIndicator actIndicator;

        private ContentView cntActivityIndicator;

        #endregion Attributes

        #region Properties

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(MaterialButton), defaultValue: null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(MaterialButton), defaultValue: null);

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly new BindableProperty IsEnabledProperty =
            BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(MaterialButton), defaultValue: true);

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public static readonly BindableProperty AnimationProperty =
            BindableProperty.Create(nameof(Animation), typeof(AnimationTypes), typeof(MaterialButton), defaultValue: AnimationTypes.None);

        public AnimationTypes Animation
        {
            get { return (AnimationTypes)GetValue(AnimationProperty); }
            set { SetValue(AnimationProperty, value); }
        }

        public static readonly BindableProperty AnimationParameterProperty =
            BindableProperty.Create(nameof(AnimationParameter), typeof(double?), typeof(MaterialButton), defaultValue: null);

        public double? AnimationParameter
        {
            get { return (double?)GetValue(AnimationParameterProperty); }
            set { SetValue(AnimationParameterProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialButton), defaultValue: null);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(MaterialButton), defaultValue: 4.0);

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty IsBusyProperty =
            BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(MaterialButton), defaultValue: false);

        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Black);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledTextColorProperty =
            BindableProperty.Create(nameof(DisabledTextColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Gray);

        public Color DisabledTextColor
        {
            get { return (Color)GetValue(DisabledTextColorProperty); }
            set { SetValue(DisabledTextColorProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Transparent);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty DisabledBackgroundColorProperty =
            BindableProperty.Create(nameof(DisabledBackgroundColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Transparent);

        public Color DisabledBackgroundColor
        {
            get { return (Color)GetValue(DisabledBackgroundColorProperty); }
            set { SetValue(DisabledBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty BusyColorProperty =
            BindableProperty.Create(nameof(BusyColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Black);

        public Color BusyColor
        {
            get { return (Color)GetValue(BusyColorProperty); }
            set { SetValue(BusyColorProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MaterialButton), defaultValue: Font.Default.FontSize);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(MaterialButton), defaultValue: null);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Transparent);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty DisabledBorderColorProperty =
            BindableProperty.Create(nameof(DisabledBorderColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Transparent);

        public Color DisabledBorderColor
        {
            get { return (Color)GetValue(DisabledBorderColorProperty); }
            set { SetValue(DisabledBorderColorProperty, value); }
        }

        public static readonly BindableProperty CustomIconProperty =
            BindableProperty.Create(nameof(CustomIcon), typeof(View), typeof(MaterialButton), defaultValue: null);

        public View CustomIcon
        {
            get { return (View)GetValue(CustomIconProperty); }
            set { SetValue(CustomIconProperty, value); }
        }

        public static readonly BindableProperty DisabledIconProperty =
            BindableProperty.Create(nameof(DisabledIcon), typeof(string), typeof(MaterialButton), defaultValue: null);

        public string DisabledIcon
        {
            get { return (string)GetValue(DisabledIconProperty); }
            set { SetValue(DisabledIconProperty, value); }
        }

        public static readonly BindableProperty IconProperty =
            BindableProperty.Create(nameof(Icon), typeof(string), typeof(MaterialButton), defaultValue: null);

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly BindableProperty IconSizeProperty =
            BindableProperty.Create(nameof(IconSize), typeof(double), typeof(BaseMaterialFieldControl), defaultValue: 24.0);

        public double IconSize
        {
            get { return (double)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }

        public static readonly BindableProperty ToUpperProperty =
            BindableProperty.Create(nameof(ToUpper), typeof(bool), typeof(MaterialButton), defaultValue: false);

        public bool ToUpper
        {
            get { return (bool)GetValue(ToUpperProperty); }
            set { SetValue(ToUpperProperty, value); }
        }

        public static readonly BindableProperty CustomActivityIndicatorProperty =
            BindableProperty.Create(nameof(CustomActivityIndicator), typeof(View), typeof(MaterialButton), defaultValue: null);

        public View CustomActivityIndicator
        {
            get { return (View)GetValue(CustomActivityIndicatorProperty); }
            set { SetValue(CustomActivityIndicatorProperty, value); }
        }

        public static readonly BindableProperty ActivityIndicatorSizeProperty =
            BindableProperty.Create(nameof(ActivityIndicatorSize), typeof(double), typeof(BaseMaterialFieldControl), defaultValue: 24.0);

        public double ActivityIndicatorSize
        {
            get { return (double)GetValue(ActivityIndicatorSizeProperty); }
            set { SetValue(ActivityIndicatorSizeProperty, value); }
        }

        #endregion Properties

        #region Methods

        private void Initialize()
        {
            initialized = true;

            frmLayout = new Frame
            {
                HasShadow = false,
                CornerRadius = 4,
                MinimumHeightRequest = 40,
                HeightRequest = 40,
                Padding = new Thickness(12, 0)
            };
            Content = frmLayout;

            stcLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 12,
                HorizontalOptions = LayoutOptions.Center,
            };
            frmLayout.Content = stcLayout;

            cntIcon = new ContentView
            {
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = IconSize,
                HeightRequest = IconSize,
                IsVisible = false
            };
            stcLayout.Children.Add(cntIcon);

            lblText = new MaterialLabel
            {
                LineBreakMode = LineBreakMode.NoWrap,
                VerticalOptions = LayoutOptions.Center
            };
            stcLayout.Children.Add(lblText);

            cntActivityIndicator = new ContentView
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = ActivityIndicatorSize,
                HeightRequest = ActivityIndicatorSize,
                IsVisible = false
            };
            stcLayout.Children.Add(cntActivityIndicator);

            Effects.Add(new TouchAndPressEffect());
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!this.initialized)
            {
                this.Initialize();
            }

            switch (propertyName)
            {
                case nameof(base.Opacity):
                case nameof(base.Scale):
                    base.OnPropertyChanged(propertyName);
                    break;
                case nameof(this.Text):
                case nameof(this.ToUpper):
                    this.lblText.Text = this.ToUpper ? this.Text?.ToUpper() : this.Text;
                    break;
                case nameof(this.TextColor):
                case nameof(this.DisabledTextColor):
                    this.lblText.TextColor = this.IsEnabled ? this.TextColor : this.DisabledTextColor;
                    break;
                case nameof(this.FontSize):
                    this.lblText.FontSize = this.FontSize;
                    break;
                case nameof(this.FontFamily):
                    this.lblText.FontFamily = this.FontFamily;
                    break;
                case nameof(this.CornerRadius):
                    this.frmLayout.CornerRadius = Convert.ToInt32(this.CornerRadius);
                    break;
                case nameof(this.BackgroundColor):
                case nameof(this.DisabledBackgroundColor):
                    this.frmLayout.BackgroundColor = this.IsEnabled ? this.BackgroundColor : this.DisabledBackgroundColor;
                    break;
                case nameof(this.BorderColor):
                case nameof(this.DisabledBorderColor):
                    this.frmLayout.BorderColor = this.IsEnabled ? this.BorderColor : this.DisabledBorderColor;
                    break;
                case nameof(this.Icon):
                case nameof(this.DisabledIcon):
                    if (!string.IsNullOrEmpty(this.Icon) || !string.IsNullOrEmpty(this.DisabledIcon))
                    {
                        if (imgIcon == null)
                        {
                            imgIcon = new Image();
                            cntIcon.Content = imgIcon;
                            cntIcon.IsVisible = true;
                        }

                        imgIcon.Source = this.IsEnabled ? this.Icon : this.DisabledIcon;
                    }
                    break;
                case nameof(CustomIcon):
                    if (CustomIcon != null)
                    {
                        cntIcon.Content = CustomIcon;
                        cntIcon.IsVisible = true;
                    }
                    break;
                case nameof(IconSize):
                    cntIcon.HeightRequest = IconSize;
                    cntIcon.WidthRequest = IconSize;
                    break;
                case nameof(this.IsEnabled):
                    this.lblText.TextColor = this.IsEnabled ? this.TextColor : this.DisabledTextColor;
                    this.frmLayout.BackgroundColor = this.IsEnabled ? this.BackgroundColor : this.DisabledBackgroundColor;
                    this.frmLayout.BorderColor = this.IsEnabled ? this.BorderColor : this.DisabledBorderColor;

                    if (imgIcon == null && (!string.IsNullOrEmpty(Icon) || !string.IsNullOrEmpty(DisabledIcon)))
                        imgIcon.Source = IsEnabled ? Icon : DisabledIcon;
                    break;
                case nameof(ActivityIndicatorSize):
                    cntActivityIndicator.HeightRequest = ActivityIndicatorSize;
                    cntActivityIndicator.WidthRequest = ActivityIndicatorSize;
                    break;
                case nameof(CustomActivityIndicator):
                    if (CustomActivityIndicator != null)
                    {
                        cntActivityIndicator.Content = CustomActivityIndicator;
                    }
                    break;
                case nameof(this.BusyColor):
                    if (CustomActivityIndicator == null)
                    {
                        if (actIndicator == null)
                        {
                            actIndicator = new ActivityIndicator();
                            cntActivityIndicator.Content = actIndicator;
                        }

                        actIndicator.Color = this.BusyColor;
                    }
                    break;
                case nameof(this.IsBusy):
                    if (this.IsBusy)
                    {
                        this.lblText.IsVisible = false;

                        if (imgIcon != null)
                            imgIcon.IsVisible = false;

                        cntIcon.IsVisible = false;

                        if (CustomActivityIndicator == null)
                        {
                            if (actIndicator == null)
                            {
                                actIndicator = new ActivityIndicator();
                                cntActivityIndicator.Content = actIndicator;
                            }

                            actIndicator.IsVisible = true;
                            actIndicator.IsRunning = true;
                        }

                        cntActivityIndicator.IsVisible = true;

                        this.frmLayout.BackgroundColor = Color.Transparent;
                        this.frmLayout.BorderColor = Color.Transparent;
                    }
                    else
                    {
                        this.lblText.IsVisible = true;

                        if (imgIcon != null)
                            imgIcon.IsVisible = !string.IsNullOrEmpty(Icon) || !string.IsNullOrEmpty(DisabledIcon);

                        cntIcon.IsVisible = cntIcon.Content != null;

                        if (CustomActivityIndicator == null)
                        {
                            if (actIndicator == null)
                            {
                                actIndicator = new ActivityIndicator();
                                cntActivityIndicator.Content = actIndicator;
                            }

                            actIndicator.IsVisible = false;
                            actIndicator.IsRunning = false;
                        }

                        cntActivityIndicator.IsVisible = false;

                        this.frmLayout.BackgroundColor = this.IsEnabled ? this.BackgroundColor : this.DisabledBackgroundColor;
                        this.frmLayout.BorderColor = this.IsEnabled ? this.BorderColor : this.DisabledBorderColor;
                    }
                    break;
            }
        }

        public void ConsumeEvent(EventType gestureType)
        {
            TouchAndPressAnimation.Animate(this, gestureType);
        }

        #endregion Methods
    }
}
