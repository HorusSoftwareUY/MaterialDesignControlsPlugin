using Plugin.MaterialDesignControls.Utils;
using System;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls.Material3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialSwitch : ContentView
    {
        #region Constructors
        public MaterialSwitch()
        {
            InitializeComponent();

            SwitchPanUpdate += (sender, e) =>
            {
                //Color Animation
                Color fromColor = IsToggled ? Color.FromHex("#4ACC64") : Color.FromHex("#EBECEC");
                Color toColor = IsToggled ? Color.FromHex("#EBECEC") : Color.FromHex("#4ACC64");

                double t = e.Percentage * 0.01;

                BackgroundColor = ColorAnimationUtil.ColorAnimation(fromColor, toColor, t);
            };

            //Flex.TranslationX = -(e.TranslateX + e.XRef);
        }
        #endregion Constructors

        #region Attributes

        private SwitchStateEnum CurrentState { get; set; }
        private double _xRef;
        private double _tmpTotalX;

        #endregion Attributes

        #region Properties



        public new static readonly BindableProperty HeightRequestProperty = BindableProperty.Create(nameof(HeightRequest), typeof(double), typeof(MaterialSwitch), 0d, propertyChanged: SizeRequestChanged);

        public new double HeightRequest
        {
            get => (double)GetValue(HeightRequestProperty);
            set => SetValue(HeightRequestProperty, value);
        }

        public new static readonly BindableProperty WidthRequestProperty = BindableProperty.Create(nameof(WidthRequest), typeof(double), typeof(MaterialSwitch), 0d, propertyChanged: SizeRequestChanged);

        public new double WidthRequest
        {
            get => (double)GetValue(WidthRequestProperty);
            set => SetValue(WidthRequestProperty, value);
        }

        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(MaterialSwitch), default(float));

        public float CornerRadius
        {
            get => (float)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public new static readonly BindableProperty BackgroundProperty = BindableProperty.Create(nameof(Background), typeof(Brush), typeof(MaterialSwitch), Brush.Default);
        [TypeConverter(typeof(BrushTypeConverter))]
        public new Brush Background
        {
            get => (Brush)GetValue(BackgroundProperty);
            set => SetValue(BackgroundProperty, value);
        }

        public new static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialSwitch), Color.Default);

        public new Color BackgroundColor
        {
            get => (Color)GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }

        #region Toggled

        public static readonly BindableProperty IsToggledProperty
            = BindableProperty.Create(nameof(IsToggled), typeof(bool), typeof(MaterialSwitch), false, BindingMode.TwoWay, propertyChanged: IsToggledChanged);

        public bool IsToggled
        {
            get => (bool)GetValue(IsToggledProperty);
            set => SetValue(IsToggledProperty, value);
        }


        public static readonly BindableProperty ToggledCommandProperty = BindableProperty.Create(nameof(ToggledCommand), typeof(ICommand), typeof(MaterialSwitch));

        public ICommand ToggledCommand
        {
            get => (ICommand)GetValue(ToggledCommandProperty);
            set => SetValue(ToggledCommandProperty, value);
        }

        public static readonly BindableProperty ToggleAnimationDurationProperty = BindableProperty.Create(nameof(ToggleAnimationDuration), typeof(int), typeof(MaterialSwitch), 100);

        public int ToggleAnimationDuration
        {
            get => (int)GetValue(ToggleAnimationDurationProperty);
            set => SetValue(ToggleAnimationDurationProperty, value);
        }
        #endregion Toggled

        #region Thumb
        public static readonly BindableProperty KnobHeightProperty = BindableProperty.Create(nameof(KnobHeight), typeof(double), typeof(MaterialSwitch), 0d, propertyChanged: SizeRequestChanged);

        public double KnobHeight
        {
            get => (double)GetValue(KnobHeightProperty);
            set => SetValue(KnobHeightProperty, value);
        }

        public static readonly BindableProperty KnobWidthProperty = BindableProperty.Create(nameof(KnobWidth), typeof(double), typeof(MaterialSwitch), 0d, propertyChanged: SizeRequestChanged);

        public double KnobWidth
        {
            get => (double)GetValue(KnobWidthProperty);
            set => SetValue(KnobWidthProperty, value);
        }

        public static readonly BindableProperty KnobBackgroundProperty = BindableProperty.Create(nameof(KnobBackground), typeof(Brush), typeof(MaterialSwitch), Brush.Default);
        [TypeConverter(typeof(BrushTypeConverter))]
        public Brush KnobBackground
        {
            get => (Brush)GetValue(KnobBackgroundProperty);
            set => SetValue(KnobBackgroundProperty, value);
        }

        public static readonly BindableProperty KnobColorProperty = BindableProperty.Create(nameof(KnobColor), typeof(Color), typeof(MaterialSwitch), Color.Default);

        public Color KnobColor
        {
            get => (Color)GetValue(KnobColorProperty);
            set => SetValue(KnobColorProperty, value);
        }

        public static readonly BindableProperty KnobCornerRadiusProperty = BindableProperty.Create(nameof(KnobCornerRadius), typeof(float), typeof(MaterialSwitch), default(float));

        public float KnobCornerRadius
        {
            get => (float)GetValue(KnobCornerRadiusProperty);
            set => SetValue(KnobCornerRadiusProperty, value);
        }

        public static readonly BindableProperty HorizontalKnobMarginProperty = BindableProperty.Create(nameof(HorizontalKnobMargin), typeof(double), typeof(MaterialSwitch), 0d, propertyChanged: SizeRequestChanged);

        public double HorizontalKnobMargin
        {
            get => (double)GetValue(HorizontalKnobMarginProperty);
            set => SetValue(HorizontalKnobMarginProperty, value);
        }

        public static readonly BindableProperty KnobLimitProperty = BindableProperty.Create(nameof(KnobLimit), typeof(KnobLimitEnum), typeof(MaterialSwitch), KnobLimitEnum.Boundary, propertyChanged: SizeRequestChanged);

        public KnobLimitEnum KnobLimit
        {
            get => (KnobLimitEnum)GetValue(KnobLimitProperty);
            set => SetValue(KnobLimitProperty, value);
        }

        public static readonly BindableProperty TrailingIconProperty =
            BindableProperty.Create(nameof(TrailingIcon), typeof(string), typeof(MaterialSwitch), defaultValue: null);

        public string TrailingIcon
        {
            get { return (string)GetValue(TrailingIconProperty); }
            set { SetValue(TrailingIconProperty, value); }
        }

        public static readonly BindableProperty CustomTrailingIconProperty =
            BindableProperty.Create(nameof(CustomTrailingIcon), typeof(View), typeof(BaseMaterialFieldControl), defaultValue: null);

        public View CustomTrailingIcon
        {
            get { return (View)GetValue(CustomTrailingIconProperty); }
            set { SetValue(CustomTrailingIconProperty, value); }
        }
        #endregion Thumb

        #endregion Properties

        #region Events

        public event EventHandler<ToggledEventArgs> Toggled;

        private event EventHandler<SwitchPanUpdatedEventArgs> SwitchPanUpdate;

        #endregion Events


        #region Methods
        private void Loaded(object sender, EventArgs e)
        {
            if (IsToggled)
            {
                GoToRight(100);
            }
            else
            {
                GoToLeft(100);
            }
        }

        private static void IsToggledChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is MaterialSwitch view))
            {
                return;
            }

            if ((bool)newValue && view.CurrentState != SwitchStateEnum.Right)
            {
                view.GoToRight();
            }
            else if (!(bool)newValue && view.CurrentState != SwitchStateEnum.Left)
            {
                view.GoToLeft();
            }

            view.Toggled?.Invoke(view, new ToggledEventArgs((bool)newValue));
            view.ToggledCommand?.Execute((bool)newValue);
        }

        private void GoToLeft(double percentage = 0.0)
        {
            if (Math.Abs(KnobFrame.TranslationX + _xRef) > 0.0)
            {
                this.AbortAnimation("SwitchAnimation");
                new Animation
                {
                    {0, 1, new Animation(v => KnobFrame.TranslationX = v, KnobFrame.TranslationX, -_xRef)},
                    {0, 1, new Animation(_ => SendSwitchPanUpdatedEventArgs(PanStatusEnum.Running))}
                }.Commit(this, "SwitchAnimation", 16, Convert.ToUInt32(ToggleAnimationDuration - (ToggleAnimationDuration * percentage / 100)), null, (_, __) =>
                {
                    this.AbortAnimation("SwitchAnimation");
                    CurrentState = SwitchStateEnum.Left;
                    IsToggled = false;
                    SendSwitchPanUpdatedEventArgs(PanStatusEnum.Completed);
                });
            }
            else
            {
                this.AbortAnimation("SwitchAnimation");
                CurrentState = SwitchStateEnum.Left;
                IsToggled = false;
                SendSwitchPanUpdatedEventArgs(PanStatusEnum.Completed);
            }

            this.imgTrailingIcon.IsVisible = false;
        }

        private void GoToRight(double percentage = 0.0)
        {
            if (Math.Abs(KnobFrame.TranslationX - _xRef) > 0.0)
            {
                this.AbortAnimation("SwitchAnimation");

                IsToggled = true;
                new Animation
                {
                    {0, 1, new Animation(v => KnobFrame.TranslationX = v, KnobFrame.TranslationX, _xRef)},
                    {0, 1, new Animation(_ => SendSwitchPanUpdatedEventArgs(PanStatusEnum.Running))}
                }.Commit(this, "SwitchAnimation", 16, Convert.ToUInt32(ToggleAnimationDuration - (ToggleAnimationDuration * percentage / 100)), null, (_, __) =>
                {
                    this.AbortAnimation("SwitchAnimation");
                    CurrentState = SwitchStateEnum.Right;
                    SendSwitchPanUpdatedEventArgs(PanStatusEnum.Completed);
                });
            }
            else
            {
                this.AbortAnimation("SwitchAnimation");
                CurrentState = SwitchStateEnum.Right;
                IsToggled = true;
                SendSwitchPanUpdatedEventArgs(PanStatusEnum.Completed);
            }

            this.imgTrailingIcon.IsVisible = TrailingIconIsVisible;
        }

        private void SendSwitchPanUpdatedEventArgs(PanStatusEnum status)
        {
            SwitchPanUpdatedEventArgs ev = new SwitchPanUpdatedEventArgs
            {
                XRef = _xRef,
                IsToggled = IsToggled,
                TranslateX = KnobFrame.TranslationX,
                Status = status,
                Percentage = IsToggled
                    ? Math.Abs(KnobFrame.TranslationX - _xRef) / (2 * _xRef) * 100
                    : Math.Abs(KnobFrame.TranslationX + _xRef) / (2 * _xRef) * 100
            };

            if (!double.IsNaN(ev.Percentage))
            {
                SwitchPanUpdate?.Invoke(this, ev);
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            SendSwitchPanUpdatedEventArgs(PanStatusEnum.Started);
            if (CurrentState == SwitchStateEnum.Right)
            {
                GoToLeft();
            }
            else
            {
                GoToRight();
            }
        }

        private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            this.AbortAnimation("SwitchAnimation");
            double dragX = e.TotalX - _tmpTotalX;

            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    SendSwitchPanUpdatedEventArgs(PanStatusEnum.Started);
                    break;

                case GestureStatus.Running:
                    KnobFrame.TranslationX = Math.Min(_xRef, Math.Max(-_xRef, KnobFrame.TranslationX + dragX));
                    _tmpTotalX = e.TotalX;
                    SendSwitchPanUpdatedEventArgs(PanStatusEnum.Running);
                    break;

                case GestureStatus.Completed:
                    double percentage = IsToggled
                        ? Math.Abs(KnobFrame.TranslationX - _xRef) / (2 * _xRef) * 100
                        : Math.Abs(KnobFrame.TranslationX + _xRef) / (2 * _xRef) * 100;

                    if (KnobFrame.TranslationX > 0)
                    {
                        GoToRight(percentage);
                    }
                    else
                    {
                        GoToLeft(percentage);
                    }

                    _tmpTotalX = 0;
                    break;

                case GestureStatus.Canceled:
                    SendSwitchPanUpdatedEventArgs(PanStatusEnum.Canceled);
                    break;
            }
        }

        private static void SizeRequestChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is MaterialSwitch view))
            {
                return;
            }

            // Knob
            view.KnobFrame.WidthRequest = view.KnobWidth < 0.0 ? view.Width / 2 : view.KnobWidth;
            view.KnobFrame.HeightRequest = view.KnobHeight < 0.0 ? view.Height : view.KnobHeight;

            // Background
            view.BackgroundFrame.WidthRequest = view.WidthRequest < 0.0 ? view.Width : view.WidthRequest;
            view.BackgroundFrame.HeightRequest = view.HeightRequest < 0.0 ? view.Height : view.HeightRequest;

            // View
            view.SetBaseWidthRequest(Math.Max(view.BackgroundFrame.WidthRequest, view.KnobFrame.WidthRequest * 2));

            // Calculate knob position
            switch (view.KnobLimit)
            {
                case KnobLimitEnum.Boundary:
                    view._xRef = ((view.BackgroundFrame.WidthRequest - view.KnobFrame.WidthRequest) / 2) - view.HorizontalKnobMargin;
                    break;

                case KnobLimitEnum.Centered:
                    view._xRef = ((view.BackgroundFrame.WidthRequest - view.KnobFrame.WidthRequest) / 2) - (((view.BackgroundFrame.WidthRequest / 2) - view.KnobFrame.WidthRequest) / 2);
                    break;

                case KnobLimitEnum.Max:
                    view._xRef = Math.Max(view.BackgroundFrame.WidthRequest, view.KnobFrame.WidthRequest * 2) / 4;
                    break;
            }
            view.KnobFrame.TranslationX = view.CurrentState == SwitchStateEnum.Left ? -view._xRef : view._xRef;
        }

        private void SetBaseWidthRequest(double widthRequest)
        {
            base.WidthRequest = widthRequest;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            switch (propertyName)
            {
                case nameof(TrailingIcon):
                    if (!string.IsNullOrEmpty(TrailingIcon))
                        this.imgTrailingIcon.SetImage(TrailingIcon);

                    this.imgTrailingIcon.IsVisible = TrailingIconIsVisible;
                break;
                case nameof(CustomTrailingIcon):
                    if (CustomTrailingIcon != null)
                        this.imgTrailingIcon.SetCustomImage(CustomTrailingIcon);

                    this.imgTrailingIcon.IsVisible = TrailingIconIsVisible;
                break;
            }
        }

        private bool TrailingIconIsVisible 
            => CurrentState != SwitchStateEnum.Left && !string.IsNullOrEmpty(TrailingIcon) || CustomTrailingIcon != null;
        #endregion Methods
    }

    public enum SwitchStateEnum
    {
        Left,
        Right
    }

    public class SwitchPanUpdatedEventArgs : EventArgs
    {
        public double XRef { get; set; }
        public bool IsToggled { get; set; }
        public double TranslateX { get; set; }
        public double Percentage { get; set; }
        public PanStatusEnum Status { get; set; }
    }

    public enum PanStatusEnum
    {
        Started,
        Running,
        Completed,
        Canceled
    }

    public enum KnobLimitEnum
    {
        Boundary,
        Centered,
        Max
    }
}