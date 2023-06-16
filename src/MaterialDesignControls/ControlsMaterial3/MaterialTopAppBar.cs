using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Implementations;
using Plugin.MaterialDesignControls.Styles;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3
{
    public enum MaterialTopAppBarType
    {
        CenterAligned, Small, Medium, Large
    }

    public class MaterialTopAppBar : Grid
    {
        #region Attributes and Properties

        private bool _initialized = false;

        private MaterialLabel _headlineLabel;

        private ContentViewButton _leadingIconContentView;

        private ContentViewButton _trailingIconContentView;

        private double _mediumDefaultFontSize = 28;
        private double _largeDefaultFontSize = 32;

        private int _smallRowHeight = 48;
        private int _mediumRowHeight = 106;
        private int _largeRowHeight = 106;

        private int _smallLabelLateralMargin = 48;
        private int _mediumLabelLateralMargin = 10;
        private int _largeLabelLateralMargin = 10;

        private bool _isCollapsed = false;

        #endregion Attributes and Properties

        #region Bindable properties

        public static readonly BindableProperty TypeProperty =
           BindableProperty.Create(nameof(Type), typeof(MaterialTopAppBarType), typeof(MaterialTopAppBar), MaterialTopAppBarType.CenterAligned, BindingMode.OneTime);

        public MaterialTopAppBarType Type
        {
            get => (MaterialTopAppBarType)GetValue(TypeProperty);
            set => SetValue(TypeProperty, value);
        }

        public static readonly BindableProperty HeadlineProperty =
           BindableProperty.Create(nameof(Headline), typeof(string), typeof(MaterialTopAppBar), default(string), BindingMode.OneTime);

        public string Headline
        {
            get => (string)GetValue(HeadlineProperty);
            set => SetValue(HeadlineProperty, value);
        }

        public static readonly BindableProperty HeadlineColorProperty =
           BindableProperty.Create(nameof(HeadlineColor), typeof(Color), typeof(MaterialTopAppBar), DefaultStyles.TextColor, BindingMode.OneTime);

        public Color HeadlineColor
        {
            get => (Color)GetValue(HeadlineColorProperty);
            set => SetValue(HeadlineColorProperty, value);
        }

        public static readonly BindableProperty HeadlineFontSizeProperty =
            BindableProperty.Create(nameof(HeadlineFontSize), typeof(double), typeof(MaterialTopAppBar), defaultValue: 22.0);

        public double HeadlineFontSize
        {
            get { return (double)GetValue(HeadlineFontSizeProperty); }
            set { SetValue(HeadlineFontSizeProperty, value); }
        }

        public static readonly BindableProperty HeadlineFontFamilyProperty =
            BindableProperty.Create(nameof(HeadlineFontFamily), typeof(string), typeof(MaterialTopAppBar), defaultValue: null);

        public string HeadlineFontFamily
        {
            get { return (string)GetValue(HeadlineFontFamilyProperty); }
            set { SetValue(HeadlineFontFamilyProperty, value); }
        }

        public static readonly BindableProperty HeadlineMarginAdjustmentProperty =
           BindableProperty.Create(nameof(HeadlineMarginAdjustment), typeof(Thickness), typeof(MaterialTopAppBar), default(Thickness), BindingMode.OneTime);

        public Thickness HeadlineMarginAdjustment
        {
            get => (Thickness)GetValue(HeadlineMarginAdjustmentProperty);
            set => SetValue(HeadlineMarginAdjustmentProperty, value);
        }

        public static readonly BindableProperty LeadingIconProperty =
            BindableProperty.Create(nameof(LeadingIcon), typeof(View), typeof(MaterialTopAppBar), defaultValue: null);

        public View LeadingIcon
        {
            get { return (View)GetValue(LeadingIconProperty); }
            set { SetValue(LeadingIconProperty, value); }
        }

        public static readonly BindableProperty TrailingIconProperty =
            BindableProperty.Create(nameof(TrailingIcon), typeof(View), typeof(MaterialTopAppBar), defaultValue: null);

        public View TrailingIcon
        {
            get { return (View)GetValue(TrailingIconProperty); }
            set { SetValue(TrailingIconProperty, value); }
        }

        public static readonly BindableProperty IconSizeProperty =
            BindableProperty.Create(nameof(IconSize), typeof(double), typeof(MaterialTopAppBar), defaultValue: 24.0);

        public double IconSize
        {
            get { return (double)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }

        public static readonly BindableProperty LeadingIconCommandProperty =
           BindableProperty.Create(nameof(LeadingIconCommand), typeof(ICommand), typeof(MaterialTopAppBar), null, BindingMode.OneTime);

        public ICommand LeadingIconCommand
        {
            get => (ICommand)GetValue(LeadingIconCommandProperty);
            set => SetValue(LeadingIconCommandProperty, value);
        }

        public static readonly BindableProperty TrailingIconCommandProperty =
           BindableProperty.Create(nameof(TrailingIconCommand), typeof(ICommand), typeof(MaterialTopAppBar), null, BindingMode.OneTime);

        public ICommand TrailingIconCommand
        {
            get => (ICommand)GetValue(TrailingIconCommandProperty);
            set => SetValue(TrailingIconCommandProperty, value);
        }

        public static readonly BindableProperty ButtonAnimationProperty =
            BindableProperty.Create(nameof(ButtonAnimation), typeof(AnimationTypes), typeof(MaterialTopAppBar), defaultValue: DefaultStyles.TapAnimation);

        public AnimationTypes ButtonAnimation
        {
            get { return (AnimationTypes)GetValue(ButtonAnimationProperty); }
            set { SetValue(ButtonAnimationProperty, value); }
        }

        public static readonly BindableProperty ButtonAnimationParameterProperty =
            BindableProperty.Create(nameof(ButtonAnimationParameter), typeof(double?), typeof(MaterialTopAppBar), defaultValue: DefaultStyles.TapAnimationParameter);

        public double? ButtonAnimationParameter
        {
            get { return (double?)GetValue(ButtonAnimationParameterProperty); }
            set { SetValue(ButtonAnimationParameterProperty, value); }
        }

        public static readonly BindableProperty ButtonCustomAnimationProperty =
            BindableProperty.Create(nameof(ButtonCustomAnimation), typeof(ICustomAnimation), typeof(MaterialTopAppBar), defaultValue: null);

        public ICustomAnimation ButtonCustomAnimation
        {
            get { return (ICustomAnimation)GetValue(ButtonCustomAnimationProperty); }
            set { SetValue(ButtonCustomAnimationProperty, value); }
        }

        public static readonly BindableProperty ScrollViewNameProperty =
           BindableProperty.Create(nameof(ScrollViewName), typeof(string), typeof(MaterialTopAppBar), default(string), BindingMode.OneTime);

        public string ScrollViewName
        {
            get => (string)GetValue(ScrollViewNameProperty);
            set => SetValue(ScrollViewNameProperty, value);
        }

        public static readonly BindableProperty ScrollViewAnimationLengthProperty =
            BindableProperty.Create(nameof(ScrollViewAnimationLength), typeof(int), typeof(MaterialTopAppBar), defaultValue: 250);

        public int ScrollViewAnimationLength
        {
            get { return (int)GetValue(ScrollViewAnimationLengthProperty); }
            set { SetValue(ScrollViewAnimationLengthProperty, value); }
        }

        #endregion Bindable properties

        #region Constructors

        public MaterialTopAppBar()
        {
            if (Children == null)
                return;

            if (!_initialized)
                Initialize();
        }

        #endregion Constructors

        #region Methods

        private void Initialize()
        {
            _initialized = true;

            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.Start;
            Padding = new Thickness(4, 8);
            RowSpacing = 0;
            ColumnSpacing = 0;

            RowDefinitions.Add(new RowDefinition { Height = 48 });

            ColumnDefinitions.Add(new ColumnDefinition { Width = 48 });
            ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            ColumnDefinitions.Add(new ColumnDefinition { Width = 48 });

            _headlineLabel = new MaterialLabel
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                HeightRequest = 48,
                TextColor = HeadlineColor,
                FontSize = HeadlineFontSize,
                FontFamily = HeadlineFontFamily
            };
            Children.Add(_headlineLabel, 0, 0);
            Grid.SetColumnSpan(_headlineLabel, 3);

            _leadingIconContentView = new ContentViewButton
            {
                VerticalOptions = LayoutOptions.Start,
                WidthRequest = 48,
                HeightRequest = 48,
                AnimationParameter = ButtonAnimationParameter,
                Animation = ButtonAnimation,
                IsVisible = false
            };
            Children.Add(_leadingIconContentView, 0, 0);

            _trailingIconContentView = new ContentViewButton
            {
                VerticalOptions = LayoutOptions.Start,
                WidthRequest = 48,
                HeightRequest = 48,
                AnimationParameter = ButtonAnimationParameter,
                Animation = ButtonAnimation,
                IsVisible = false
            };
            Children.Add(_trailingIconContentView, 2, 0);

            SetType();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (Children == null)
                return;

            if (!_initialized)
                Initialize();

            switch (propertyName)
            {
                case nameof(Type):
                    SetType();
                    break;

                case nameof(Headline):
                    _headlineLabel.Text = Headline;
                    break;
                case nameof(HeadlineColor):
                    _headlineLabel.TextColor = HeadlineColor;
                    break;
                case nameof(HeadlineFontSize):
                    _headlineLabel.FontSize = HeadlineFontSize;
                    break;
                case nameof(HeadlineFontFamily):
                    _headlineLabel.FontFamily = HeadlineFontFamily;
                    break;
                case nameof(HeadlineMarginAdjustment):
                    _headlineLabel.Margin = HeadlineMarginAdjustment;
                    break;

                case nameof(LeadingIconCommand):
                    _leadingIconContentView.Command = LeadingIconCommand;
                    _leadingIconContentView.IsVisible = true;
                    break;
                case nameof(TrailingIconCommand):
                    _trailingIconContentView.Command = TrailingIconCommand;
                    _trailingIconContentView.IsVisible = true;
                    break;
                case nameof(LeadingIcon):
                    if (LeadingIcon != null)
                    {
                        LeadingIcon.WidthRequest = IconSize;
                        LeadingIcon.HeightRequest = IconSize;
                        LeadingIcon.HorizontalOptions = LayoutOptions.Center;
                        LeadingIcon.VerticalOptions = LayoutOptions.Center;
                        _leadingIconContentView.Content = LeadingIcon;
                        _leadingIconContentView.IsVisible = true;
                    }
                    break;
                case nameof(TrailingIcon):
                    if (TrailingIcon != null)
                    {
                        TrailingIcon.WidthRequest = IconSize;
                        TrailingIcon.HeightRequest = IconSize;
                        TrailingIcon.HorizontalOptions = LayoutOptions.Center;
                        TrailingIcon.VerticalOptions = LayoutOptions.Center;
                        _trailingIconContentView.Content = TrailingIcon;
                        _trailingIconContentView.IsVisible = true;
                    }
                    break;

                case nameof(ButtonAnimation):
                    _leadingIconContentView.Animation = ButtonAnimation;
                    _trailingIconContentView.Animation = ButtonAnimation;
                    break;
                case nameof(ButtonAnimationParameter):
                    _leadingIconContentView.AnimationParameter = ButtonAnimationParameter;
                    _trailingIconContentView.AnimationParameter = ButtonAnimationParameter;
                    break;
                case nameof(ButtonCustomAnimation):
                    _leadingIconContentView.CustomAnimation = ButtonCustomAnimation;
                    _trailingIconContentView.CustomAnimation = ButtonCustomAnimation;
                    break;

                case "Renderer":
                    base.OnPropertyChanged(propertyName);

                    if (!string.IsNullOrEmpty(ScrollViewName)
                        && (Type == MaterialTopAppBarType.Medium || Type == MaterialTopAppBarType.Large))
                        SetScrollViewAnimation();
                    break;

                default:
                    base.OnPropertyChanged(propertyName);
                    break;
            }
        }

        private void SetScrollViewAnimation()
        {
            try
            {
                var viewByName = Parent.FindByName(ScrollViewName);
                if (viewByName != null && viewByName is ScrollView scrollView)
                {
                    int maxHeight = Type == MaterialTopAppBarType.Large ? _largeRowHeight : _mediumRowHeight;
                    int minHeight = _smallRowHeight;

                    double maxFontSize = Type == MaterialTopAppBarType.Large ? _largeDefaultFontSize : _mediumDefaultFontSize;
                    double minFontSize = HeadlineFontSize;

                    int maxLabelLateralMargin = Type == MaterialTopAppBarType.Large ? _largeLabelLateralMargin : _mediumLabelLateralMargin;
                    int minLabelLateralMargin = _smallLabelLateralMargin;

                    if (Device.RuntimePlatform == Device.Android)
                    {
                        scrollView.Effects.Add(new TouchReleaseEffect(() =>
                        {
                            ScrollAnimation(scrollView.ScrollY, maxHeight, minHeight, maxFontSize, minFontSize, maxLabelLateralMargin, minLabelLateralMargin);

                            Task.Run(async () =>
                            {
                                await Task.Delay(500);
                                if (_isCollapsed && scrollView.ScrollY <= 0)
                                    ExpandTopAppBar(maxHeight, minHeight, maxFontSize, minFontSize, maxLabelLateralMargin, minLabelLateralMargin);
                            });
                        }));
                    }
                    else
                    {
                        scrollView.Scrolled += (s, e) =>
                        {
                            ScrollAnimation(e.ScrollY, maxHeight, minHeight, maxFontSize, minFontSize, maxLabelLateralMargin, minLabelLateralMargin);
                        };
                    }
                }
                else
                    System.Diagnostics.Debug.WriteLine($"The view with name '{ScrollViewName}' wasn't found or it isn't a ScrollView");
            }
            catch (System.Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

        private void ScrollAnimation(double scrollY, int maxHeight, int minHeight, double maxFontSize, double minFontSize, int maxLabelLateralMargin, int minLabelLateralMargin)
        {
            if (_isCollapsed && scrollY <= 0)
                ExpandTopAppBar(maxHeight, minHeight, maxFontSize, minFontSize, maxLabelLateralMargin, minLabelLateralMargin);
            else if (!_isCollapsed && scrollY >= 70)
                CollapseTopAppBar(maxHeight, minHeight, maxFontSize, minFontSize, maxLabelLateralMargin, minLabelLateralMargin);
        }

        private void ExpandTopAppBar(int maxHeight, int minHeight, double maxFontSize, double minFontSize, int maxLabelLateralMargin, int minLabelLateralMargin)
        {
            _isCollapsed = false;

            var mainAnimation = new Animation();
            mainAnimation.Add(0, 1, new Animation(v => RowDefinitions[0].Height = new GridLength(v), minHeight, maxHeight, Easing.Linear));
            mainAnimation.Add(0, 1, new Animation(v => _headlineLabel.FontSize = v, minFontSize, maxFontSize, Easing.Linear));
            mainAnimation.Add(0, 1, new Animation(v => _headlineLabel.Margin = new Thickness(v, HeadlineMarginAdjustment.Top, v, HeadlineMarginAdjustment.Bottom), minLabelLateralMargin, maxLabelLateralMargin, Easing.SinIn));
            mainAnimation.Commit(this, $"{nameof(MaterialTopAppBar)}{Id}", 16, (uint)ScrollViewAnimationLength, null);
        }

        private void CollapseTopAppBar(int maxHeight, int minHeight, double maxFontSize, double minFontSize, int maxLabelLateralMargin, int minLabelLateralMargin)
        {
            _isCollapsed = true;

            var mainAnimation = new Animation();
            mainAnimation.Add(0, 1, new Animation(v => RowDefinitions[0].Height = new GridLength(v), maxHeight, minHeight, Easing.Linear));
            mainAnimation.Add(0, 1, new Animation(v => _headlineLabel.FontSize = v, maxFontSize, minFontSize, Easing.Linear));
            mainAnimation.Add(0, 1, new Animation(v => _headlineLabel.Margin = new Thickness(v, HeadlineMarginAdjustment.Top, v, HeadlineMarginAdjustment.Bottom), maxLabelLateralMargin, minLabelLateralMargin, Easing.SinOut));
            mainAnimation.Commit(this, $"{nameof(MaterialTopAppBar)}{Id}", 16, (uint)ScrollViewAnimationLength, null);
        }

        private void SetType()
        {
            switch (Type)
            {
                case MaterialTopAppBarType.Small:
                    _headlineLabel.HorizontalTextAlignment = TextAlignment.Start;
                    _headlineLabel.Margin = new Thickness(_smallLabelLateralMargin, HeadlineMarginAdjustment.Top, _smallLabelLateralMargin, HeadlineMarginAdjustment.Bottom);
                    break;
                case MaterialTopAppBarType.Medium:
                    _headlineLabel.HorizontalTextAlignment = TextAlignment.Start;
                    _headlineLabel.VerticalOptions = LayoutOptions.End;
                    _headlineLabel.Margin = new Thickness(_mediumLabelLateralMargin, HeadlineMarginAdjustment.Top, _mediumLabelLateralMargin, HeadlineMarginAdjustment.Bottom);
                    _headlineLabel.FontSize = _mediumDefaultFontSize;
                    RowDefinitions[0].Height = new GridLength(_mediumRowHeight);
                    break;
                case MaterialTopAppBarType.Large:
                    _headlineLabel.HorizontalTextAlignment = TextAlignment.Start;
                    _headlineLabel.VerticalOptions = LayoutOptions.End;
                    _headlineLabel.Margin = new Thickness(_largeLabelLateralMargin, HeadlineMarginAdjustment.Top, _largeLabelLateralMargin, HeadlineMarginAdjustment.Bottom);
                    _headlineLabel.FontSize = _largeDefaultFontSize;
                    RowDefinitions[0].Height = new GridLength(_largeRowHeight);
                    break;
            }
        }

        #endregion Methods
    }
}