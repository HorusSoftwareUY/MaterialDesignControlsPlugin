using Plugin.MaterialDesignControls.Material3.Implementations;
using Plugin.MaterialDesignControls.Styles;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3
{
    public enum MaterialProgressIndicatorType
    {
        Circular, Linear
    }

    public class MaterialProgressIndicator : ContentView
    {
        #region Attributes and Properties

        private bool _initialized = false;

        private bool _rendered = false;

        private BoxView _progressBar;

        private CustomActivityIndicator _customActivityIndicator;

        #endregion Attributes and Properties

        #region Bindable properties

        public static readonly BindableProperty TypeProperty =
            BindableProperty.Create(nameof(Type), typeof(MaterialProgressIndicatorType), typeof(MaterialProgressIndicator), defaultValue: MaterialProgressIndicatorType.Circular);

        public MaterialProgressIndicatorType Type
        {
            get { return (MaterialProgressIndicatorType)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public static readonly BindableProperty IndicatorColorProperty =
            BindableProperty.Create(nameof(IndicatorColor), typeof(Color), typeof(MaterialProgressIndicator), defaultValue: DefaultStyles.PrimaryColor);

        public Color IndicatorColor
        {
            get { return (Color)GetValue(IndicatorColorProperty); }
            set { SetValue(IndicatorColorProperty, value); }
        }

        public static readonly BindableProperty TrackColorProperty =
            BindableProperty.Create(nameof(TrackColor), typeof(Color), typeof(MaterialProgressIndicator), defaultValue: DefaultStyles.SurfaceContainerHighestColor);

        public Color TrackColor
        {
            get { return (Color)GetValue(TrackColorProperty); }
            set { SetValue(TrackColorProperty, value); }
        }

        #endregion Bindable properties

        #region Constructors

        public MaterialProgressIndicator()
        {
            if (!_initialized)
                Initialize();
        }

        #endregion Constructors

        #region Methods

        private void Initialize()
        {
            _initialized = true;

            Padding = 0;

            SetProgressIndicatorType();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!_initialized)
                Initialize();

            switch (propertyName)
            {
                case nameof(Type):
                    SetProgressIndicatorType();
                    break;
                case nameof(TrackColor):
                    if (Type == MaterialProgressIndicatorType.Linear)
                        this.BackgroundColor = TrackColor;
                    break;
                case nameof(IndicatorColor):
                    if (Type == MaterialProgressIndicatorType.Circular && _customActivityIndicator != null)
                        _customActivityIndicator.Color = IndicatorColor;
                    else if (Type == MaterialProgressIndicatorType.Linear && _progressBar != null)
                        _progressBar.BackgroundColor = IndicatorColor;
                    break;
                case nameof(IsVisible):
                    base.OnPropertyChanged(propertyName);

                    if (Type == MaterialProgressIndicatorType.Circular)
                    {
                        // Handle circular animation
                        if (_customActivityIndicator != null)
                            _customActivityIndicator.IsRunning = IsVisible;
                    }
                    else
                    {
                        // Handle linear animation
                        if (IsVisible)
                            StartLinearAnimation();
                        else
                            this.AbortAnimation("LinearAnimation" + Id);
                    }
                    break;
                case "Renderer":
                    if (!_rendered)
                        _rendered = true;
                    else
                    {
                        // This property is setted on the view appearing and in the view dissapearing
                        // So we abort the linear animation here
                        if (Type == MaterialProgressIndicatorType.Linear)
                            this.AbortAnimation("LinearAnimation" + Id);
                    }
                    break;
            }
        }

        public void SetProgressIndicatorType()
        {
            switch (Type)
            {
                case MaterialProgressIndicatorType.Linear:
                    HeightRequest = 4;
                    WidthRequest = -1;
                    _progressBar = new BoxView()
                    {
                        BackgroundColor = IndicatorColor,
                        IsEnabled = this.IsEnabled,
                        Margin = new Thickness(0),
                    };
                    this.Content = _progressBar;
                    this.BackgroundColor = TrackColor;
                    StartLinearAnimation();
                    break;
                case MaterialProgressIndicatorType.Circular:
                    HeightRequest = 48;
                    WidthRequest = 48;
                    this.BackgroundColor = Color.Transparent;
                    _customActivityIndicator = new CustomActivityIndicator()
                    {
                        Color = IndicatorColor,
                        IsRunning = true
                    };
                    this.Content = _customActivityIndicator;
                    break;
            }
        }

        private void StartLinearAnimation()
        {
            var index = 1;
            var mainAnimation = new Animation();
            mainAnimation.Add(0, 1, new Animation(v =>
            {
                if (index % 2 != 0)
                    _progressBar.Margin = new Thickness(0, 0, Width - (Width * v), 0); // Expanding boxview
                else
                    _progressBar.Margin = new Thickness(Width * v, 0, 0, 0); // Collapsing boxview
            }, 0, 1, Easing.CubicOut));
            mainAnimation.Commit(this, "LinearAnimation" + Id, 16, 1500, Easing.Linear, (v, c) => ++index,
            () => Type == MaterialProgressIndicatorType.Linear && IsVisible);
        }

        #endregion Methods
    }
}