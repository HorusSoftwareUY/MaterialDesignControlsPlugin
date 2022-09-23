using System.Runtime.CompilerServices;
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

        public static readonly BindableProperty AnimationProperty =
            BindableProperty.Create(nameof(Animation), typeof(AnimationTypes), typeof(MaterialTopAppBar), defaultValue: DefaultStyles.ButtonAnimation);

        public AnimationTypes Animation
        {
            get { return (AnimationTypes)GetValue(AnimationProperty); }
            set { SetValue(AnimationProperty, value); }
        }

        public static readonly BindableProperty AnimationParameterProperty =
            BindableProperty.Create(nameof(AnimationParameter), typeof(double?), typeof(MaterialTopAppBar), defaultValue: DefaultStyles.ButtonAnimationParameter);

        public double? AnimationParameter
        {
            get { return (double?)GetValue(AnimationParameterProperty); }
            set { SetValue(AnimationParameterProperty, value); }
        }

        public static readonly BindableProperty CustomAnimationProperty =
            BindableProperty.Create(nameof(CustomAnimation), typeof(ICustomAnimation), typeof(MaterialTopAppBar), defaultValue: null);

        public ICustomAnimation CustomAnimation
        {
            get { return (ICustomAnimation)GetValue(CustomAnimationProperty); }
            set { SetValue(CustomAnimationProperty, value); }
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

            _leadingIconContentView = new ContentViewButton
            {
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = IconSize,
                HeightRequest = IconSize,
                AnimationParameter = AnimationParameter,
                Animation = Animation,
                IsVisible = false
            };
            Children.Add(_leadingIconContentView, 0, 0);

            _headlineLabel = new MaterialLabel
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = HeadlineColor,
                FontSize = HeadlineFontSize,
                FontFamily = HeadlineFontFamily
            };
            Children.Add(_headlineLabel, 1, 0);

            _trailingIconContentView = new ContentViewButton
            {
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = IconSize,
                HeightRequest = IconSize,
                AnimationParameter = AnimationParameter,
                Animation = Animation,
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
                        _leadingIconContentView.Content = LeadingIcon;
                        _leadingIconContentView.IsVisible = true;
                    }
                    break;
                case nameof(TrailingIcon):
                    if (TrailingIcon != null)
                    {
                        _trailingIconContentView.Content = TrailingIcon;
                        _trailingIconContentView.IsVisible = true;
                    }
                    break;
                case nameof(IconSize):
                    _leadingIconContentView.HeightRequest = IconSize;
                    _leadingIconContentView.WidthRequest = IconSize;
                    _trailingIconContentView.HeightRequest = IconSize;
                    _trailingIconContentView.WidthRequest = IconSize;
                    break;

                case nameof(Animation):
                    _leadingIconContentView.Animation = Animation;
                    _trailingIconContentView.Animation = Animation;
                    break;
                case nameof(AnimationParameter):
                    _leadingIconContentView.AnimationParameter = AnimationParameter;
                    _trailingIconContentView.AnimationParameter = AnimationParameter;
                    break;
                case nameof(CustomAnimation):
                    _leadingIconContentView.CustomAnimation = CustomAnimation;
                    _trailingIconContentView.CustomAnimation = CustomAnimation;
                    break;

                default:
                    base.OnPropertyChanged(propertyName);
                    break;
            }
        }

        public void SetType()
        {
            switch (Type)
            {
                case MaterialTopAppBarType.Small:
                    _headlineLabel.HorizontalTextAlignment = Xamarin.Forms.TextAlignment.Start;
                    break;
                case MaterialTopAppBarType.Medium:
                    RowDefinitions.Add(new RowDefinition() { Height = new GridLength(48) });
                    Grid.SetRow(_headlineLabel, 1);
                    Grid.SetColumn(_headlineLabel, 0);
                    Grid.SetColumnSpan(_headlineLabel, 3);
                    _headlineLabel.HorizontalTextAlignment = Xamarin.Forms.TextAlignment.Start;
                    _headlineLabel.Margin = new Thickness(10, 0);
                    _headlineLabel.FontSize = 28;
                    RowSpacing = 10;
                    break;
                case MaterialTopAppBarType.Large:
                    RowDefinitions.Add(new RowDefinition() { Height = new GridLength(48) });
                    Grid.SetRow(_headlineLabel, 1);
                    Grid.SetColumn(_headlineLabel, 0);
                    Grid.SetColumnSpan(_headlineLabel, 3);
                    _headlineLabel.HorizontalTextAlignment = Xamarin.Forms.TextAlignment.Start;
                    _headlineLabel.Margin = new Thickness(10, 0);
                    _headlineLabel.FontSize = 32;
                    RowSpacing = 10;
                    break;
            }
        }

        #endregion Methods
    }
}