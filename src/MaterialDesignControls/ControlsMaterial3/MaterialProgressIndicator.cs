using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Plugin.MaterialDesignControls.Styles;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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

        public static readonly new BindableProperty IsEnabledProperty =
            BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(MaterialProgressIndicator), defaultValue: true);

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        //public static readonly BindableProperty CustomActivityIndicatorProperty =
        //    BindableProperty.Create(nameof(CustomActivityIndicator), typeof(View), typeof(MaterialProgressIndicator), defaultValue: null);

        //public View CustomActivityIndicator
        //{
        //    get { return (View)GetValue(CustomActivityIndicatorProperty); }
        //    set { SetValue(CustomActivityIndicatorProperty, value); }
        //}

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

        public static readonly BindableProperty IsIndeterminatedProperty =
            BindableProperty.Create(nameof(IsIndeterminated), typeof(bool), typeof(MaterialProgressIndicator), defaultValue: true);

        public bool IsIndeterminated
        {
            get { return (bool)GetValue(IsIndeterminatedProperty); }
            set { SetValue(IsIndeterminatedProperty, value); }
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
                case nameof(base.Opacity):
                case nameof(base.IsVisible):
                case nameof(BackgroundColor):
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
                    StartProgressIndicatorLinearAnimation();
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
                            IsIndeterminated = this.IsIndeterminated,
                            IsEnabled = this.IsEnabled
                        };
                        this.Content = _activityIndicator;
                    }
                    else
                    {
                        var _activityIndicator = new ActivityIndicator()
                        {
                            Color = IndicatorColor,
                            IsRunning = IsIndeterminated,
                            IsEnabled = this.IsEnabled
                        };
                        this.Content = _activityIndicator;
                    }
                    
                    this.BackgroundColor = Color.Transparent;
                    break;
            }
        }

        private void StartProgressIndicatorLinearAnimation()
        {
            var animation = new Animation(v => _progressBar.Scale = v, 0.5, 1);
            animation.Commit(this, "SimpleAnimation", 16, 1000, Easing.Linear, (v, c) => _progressBar.Scale = 1, () => true);


            //initialTranslationX = _progressBar.X;

            //var parentAnimation = new Animation();
            //var scaleAnimation = new Animation(v => _progressBar.Scale = v, 0.1, 1, Easing.BounceIn);
            ////var scaleUpAnimation = new Animation(v => _progressBar.Scale = v, 0.3, 1, Easing.BounceIn);
            ////var translateAnimation = new Animation(AnimateToEnd, 0.1, 1, null, () => _progressBar.TranslateTo(initialTranslationX, 0));
            ////var translateAnimation1 = new Animation(AnimateToEnd, 0.1, 0.9);
            ////var translateAnimation2 = new Animation(AnimateToEnd, 0.5, 0.7);
            ////var translateAnimation3 = new Animation(AnimateToEnd, 0, 0.1);
            ////var restoreAnimation = new Animation(Restore, 0.5, 1);
            ////var rotateAnimation = new Animation(v => _progressBar.TranslateTo(_progressBar.TranslationX + 100, 0));
            ////var scaleDownAnimation = new Animation(v => image.Scale = v, 2, 1, Easing.SpringOut);

            //parentAnimation.Add(0, 0.1, scaleAnimation);

            ////parentAnimation.Add(0.1, 1, scaleUpAnimation);
            ////parentAnimation.Add(0, 0.5, translateAnimation);
            ////parentAnimation.Add(0.1, 0.2, translateAnimation1);
            ////parentAnimation.Add(0.2, 0.3, translateAnimation2);
            ////parentAnimation.Add(0.4, 0.5, translateAnimation);
            ////parentAnimation.Add(0.5, 0.6, translateAnimation);
            ////parentAnimation.Add(0.7, 0.8, translateAnimation);
            ////parentAnimation.Add(0.8, 0.9, translateAnimation);
            ////parentAnimation.Add(0.3, 0.6, scaleUpAnimation);
            ////parentAnimation.Add(0, 1, rotateAnimation);
            ////parentAnimation.Add(0.6, 1, scaleDownAnimation);
            ////parentAnimation.Add(0.5, 1, restoreAnimation);
            ////parentAnimation.Add(0.9, 1, scaleDownAnimation);
            //parentAnimation.Commit(this, "ProgressLinearAnimation", 1, 1000, null, null, () => true);
        }

        private void Restore(double obj)
        {
            //_progressBar.Scale = 0.2;
            _progressBar.TranslateTo(0, 0);
        }
        private double initialTranslationX = 0;

        private void AnimateToEnd(double v)
        {
            _progressBar.TranslateTo(_progressBar.TranslationX + 100, 0);
        }





        #endregion Methods
    }
}
