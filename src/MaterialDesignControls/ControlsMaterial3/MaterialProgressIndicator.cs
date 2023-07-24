using Plugin.MaterialDesignControls.Material3.Implementations;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3
{
    public enum MaterialProgressIndicatorType
    {
        Linear, Circular
    }

    public class MaterialProgressIndicator : Frame
    {
        #region Attributes and Properties

        private bool _initialized = false;

        private CustomActivityIndicator _activityIndicator;

        private static BoxView _progressBar;

        #endregion Attributes and Properties

        #region Bindable properties

        public static readonly BindableProperty ProgressIndicatorTypeProperty =
            BindableProperty.Create(nameof(ProgressIndicatorType), typeof(MaterialProgressIndicatorType), typeof(MaterialProgressIndicator), defaultValue: MaterialProgressIndicatorType.Linear);

        public MaterialProgressIndicatorType ProgressIndicatorType
        {
            get { return (MaterialProgressIndicatorType)GetValue(ProgressIndicatorTypeProperty); }
            set { SetValue(ProgressIndicatorTypeProperty, value); }
        }

        public static readonly BindableProperty IndicatorColorProperty =
            BindableProperty.Create(nameof(IndicatorColor), typeof(Color), typeof(MaterialProgressIndicator), defaultValue: Color.Purple);

        public Color IndicatorColor
        {
            get { return (Color)GetValue(IndicatorColorProperty); }
            set { SetValue(IndicatorColorProperty, value); }
        }

        public static readonly BindableProperty TrackColorProperty =
            BindableProperty.Create(nameof(TrackColor), typeof(Color), typeof(MaterialProgressIndicator), defaultValue: Color.DarkGray);

        public Color TrackColor
        {
            get { return (Color)GetValue(TrackColorProperty); }
            set { SetValue(TrackColorProperty, value); }
        }
        #endregion Bindable properties


        #region Constructors

        public MaterialProgressIndicator()
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

            this.Padding = 0;
            this.IsClippedToBounds = true;
            this.CornerRadius = 0;
            this.HasShadow = false;

            SetProgressIndicatorType();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (Children == null)
                return;

            if (!_initialized)
                Initialize();

            switch (propertyName)
            {
                case nameof(ProgressIndicatorType):
                case nameof(TrackColor):
                case nameof(IndicatorColor):
                    SetProgressIndicatorType();
                    break;
                case nameof(base.IsVisible):
                    base.OnPropertyChanged(propertyName);
                    break;
                case nameof(IsEnabled):
                    VisualStateManager.GoToState(this, IsEnabled ? "Normal" : "Disabled");
                    break;
            }
        }

        public void SetProgressIndicatorType()
        {
            switch (ProgressIndicatorType)
            {
                case MaterialProgressIndicatorType.Linear:
                    MinimumHeightRequest = 4;
                    HeightRequest = 4;
                    WidthRequest = -1;
                    MinimumWidthRequest = -1;
                    _progressBar = new BoxView()
                    {
                        BackgroundColor = IndicatorColor,
                        IsEnabled = this.IsEnabled,
                        Margin = new Thickness(0),
                    };
                    this.Content = _progressBar;
                    this.BackgroundColor = TrackColor;
                    StartProgressIndicatorLinearAnimation_iOS();
                    break;
                case MaterialProgressIndicatorType.Circular:
                    MinimumHeightRequest = 48;
                    HeightRequest = 48;
                    WidthRequest = 4;
                    MinimumWidthRequest = 4;

                    if (Device.RuntimePlatform == Device.iOS)
                    {
                        _activityIndicator = new CustomActivityIndicator()
                        {
                            IndicatorColor = this.IndicatorColor,
                            TrackColor = this.TrackColor,
                            IsIndeterminated = true,
                            IsEnabled = this.IsEnabled,
                            ValuesPerTurn = 100,
                            Value = 50
                        };
                        this.Content = _activityIndicator;
                        StartProgressIndicatorCircularAnimation_iOS();
                    }
                    else
                    {
                        var _activityIndicator = new ActivityIndicator()
                        {
                            Color = IndicatorColor,
                            IsRunning = true,
                            IsEnabled = this.IsEnabled
                        };
                        this.Content = _activityIndicator;
                    }
                    
                    this.BackgroundColor = Color.Transparent;
                    break;
            }
        }

        private void StartProgressIndicatorLinearAnimation_iOS()
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
            mainAnimation.Commit(this, "LinearAnimation" + Id, 16, 1500, Easing.Linear, (v, c) => ++index, () => true);
        }

        private void StartProgressIndicatorCircularAnimation_iOS()
        {
            //var seconds = TimeSpan.FromSeconds(1);

            //Device.StartTimer(seconds, () => {

            //    // call your method to check for notifications here

            //    // Returning true means you want to repeat this timer
            //    return true;
            //});

            var mainAnimation = new Animation
            {
                { 0, 1, new Animation(v => _activityIndicator.Value = v, 50.0, 0, Easing.Linear) }
            };
            mainAnimation.Commit(this, "ProgressCircularAnimation", 16, 500, Easing.Linear, (v, c) => StopAnimation()/*, () => true*/);
        }



        private void StopAnimation()
        {
            //this.AbortAnimation("ProgressCircularAnimation");
        }



        #endregion Methods
    }
}
