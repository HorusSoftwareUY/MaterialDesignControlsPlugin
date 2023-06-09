using Plugin.MaterialDesignControls.Utils;
using System;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
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
                Color fromColor = IsToggled ? BackgroundOnSelectedColor : BackgroundOnUnselectedColor;
                Color toColor = IsToggled ? BackgroundOnUnselectedColor : BackgroundOnSelectedColor;

                double t = e.Percentage * 0.01;

                BackgroundColor = ColorAnimationUtil.ColorAnimation(fromColor, toColor, t);
            };
        }
        #endregion Constructors

        #region Attributes

        private SwitchStateEnum CurrentState { get; set; }
        private double _xRef;
        private double _tmpTotalX;

        private readonly int _toggleAnimationDuration = 100;
        private readonly double _reduceTo = 0.85;
        private readonly double _increazeTo = 1.15;

        public bool ReduceThumbSize => CustomUnselectedIcon == null && string.IsNullOrWhiteSpace(UnselectedIcon);

        #endregion Attributes

        #region Properties

        #region Background

        public new static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialSwitch), Color.Default);

        public new Color BackgroundColor
        {
            get => (Color)GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }

        public static readonly BindableProperty BackgroundOnUnselectedColorProperty = BindableProperty.Create(nameof(BackgroundOnUnselectedColor), typeof(Color), typeof(MaterialSwitch), Color.LightGray);

        public Color BackgroundOnUnselectedColor
        {
            get => (Color)GetValue(BackgroundOnUnselectedColorProperty);
            set => SetValue(BackgroundOnUnselectedColorProperty, value);
        }

        public static readonly BindableProperty BackgroundOnSelectedColorProperty = BindableProperty.Create(nameof(BackgroundOnSelectedColor), typeof(Color), typeof(MaterialSwitch), Color.FromHex("#aca3db"));

        public Color BackgroundOnSelectedColor
        {
            get => (Color)GetValue(BackgroundOnSelectedColorProperty);
            set => SetValue(BackgroundOnSelectedColorProperty, value);
        }
        #endregion BackgroundColor

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
        #endregion Toggled

        #region Thumb

        //TODO: to remove and check a better way 
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

        public static readonly BindableProperty ThumbUnselectedColorProperty = BindableProperty.Create(nameof(ThumbUnselectedColor), typeof(Color), typeof(MaterialSwitch), Color.DarkGray);

        public Color ThumbUnselectedColor
        {
            get => (Color)GetValue(ThumbUnselectedColorProperty);
            set => SetValue(ThumbUnselectedColorProperty, value);
        }

        public static readonly BindableProperty ThumbSelectedColorProperty = BindableProperty.Create(nameof(ThumbSelectedColor), typeof(Color), typeof(MaterialSwitch), Color.FromHex("#7364c3"));

        public Color ThumbSelectedColor
        {
            get => (Color)GetValue(ThumbSelectedColorProperty);
            set => SetValue(ThumbSelectedColorProperty, value);
        }

        public static readonly BindableProperty SelectedIconProperty =
            BindableProperty.Create(nameof(SelectedIcon), typeof(string), typeof(MaterialSwitch), defaultValue: null);

        public string SelectedIcon
        {
            get { return (string)GetValue(SelectedIconProperty); }
            set { SetValue(SelectedIconProperty, value); }
        }

        public static readonly BindableProperty CustomSelectedIconProperty =
            BindableProperty.Create(nameof(CustomSelectedIcon), typeof(View), typeof(BaseMaterialFieldControl), defaultValue: null);

        public View CustomSelectedIcon
        {
            get { return (View)GetValue(CustomSelectedIconProperty); }
            set { SetValue(CustomSelectedIconProperty, value); }
        }

        public static readonly BindableProperty UnselectedIconProperty =
            BindableProperty.Create(nameof(UnselectedIcon), typeof(string), typeof(BaseMaterialFieldControl), defaultValue: null);

        public string UnselectedIcon
        {
            get { return (string)GetValue(UnselectedIconProperty); }
            set { SetValue(UnselectedIconProperty, value); }
        }

        public static readonly BindableProperty CustomUnselectedIconProperty =
            BindableProperty.Create(nameof(CustomUnselectedIcon), typeof(View), typeof(BaseMaterialFieldControl), defaultValue: null);

        public View CustomUnselectedIcon
        {
            get { return (View)GetValue(CustomUnselectedIconProperty); }
            set { SetValue(CustomUnselectedIconProperty, value); }
        }

        #endregion Thumb

        #endregion Properties

        #region Events

        public event EventHandler<ToggledEventArgs> Toggled;

        private event EventHandler<SwitchPanUpdatedEventArgs> SwitchPanUpdate;

        #endregion Events

        #region Methods
        private async void Loaded(object sender, EventArgs e)
        {
            if (IsToggled)
            {
                await GoToRight(100);
            }
            else
            {
                await GoToLeft(100);
            }
        }

        private async static void IsToggledChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is MaterialSwitch view))
            {
                return;
            }

            if ((bool)newValue && view.CurrentState != SwitchStateEnum.Right)
            {
                await view.GoToRight();
            }
            else if (!(bool)newValue && view.CurrentState != SwitchStateEnum.Left)
            {
                await view.GoToLeft();
            }

            view.Toggled?.Invoke(view, new ToggledEventArgs((bool)newValue));
            view.ToggledCommand?.Execute((bool)newValue);
        }

        private async Task GoToLeft(double percentage = 0.0)
        {
            if (Math.Abs(ThumbFrame.TranslationX + _xRef) > 0.0)
            {
                this.AbortAnimation("SwitchAnimation");
                new Animation
                {
                    {0, 1, new Animation(v => ThumbFrame.TranslationX = v, ThumbFrame.TranslationX, -_xRef)},
                    {0, 1, new Animation(_ => SendSwitchPanUpdatedEventArgs(PanStatusEnum.Running))}
                }.Commit(this, "SwitchAnimation", 16, Convert.ToUInt32(_toggleAnimationDuration - (_toggleAnimationDuration * percentage / 100)), null, (_, __) =>
                {
                    this.AbortAnimation("SwitchAnimation");
                    CurrentState = SwitchStateEnum.Left;
                    IsToggled = false;
                    ThumbFrame.BackgroundColor = ThumbUnselectedColor;
                    SendSwitchPanUpdatedEventArgs(PanStatusEnum.Completed);
                });
            }
            else
            {
                this.AbortAnimation("SwitchAnimation");
                CurrentState = SwitchStateEnum.Left;
                IsToggled = false;
                ThumbFrame.BackgroundColor = ThumbUnselectedColor;
                SendSwitchPanUpdatedEventArgs(PanStatusEnum.Completed);
            }

            if (ReduceThumbSize)
            {
                await SizeTo(_reduceTo);
                this.imgIcon.IsVisible = false;
            }
            else
            {
                SetUnselectedIconSource();
            }
        }

        private void SetUnselectedIconSource()
        {
            if (CustomUnselectedIcon != null)
            {
                this.imgIcon.SetCustomImage(CustomUnselectedIcon);
            }
            else if (!string.IsNullOrWhiteSpace(UnselectedIcon))
            {
                this.imgIcon.SetImage(UnselectedIcon);
            }
        }

        private async Task GoToRight(double percentage = 0.0)
        {
            if (Math.Abs(ThumbFrame.TranslationX - _xRef) > 0.0)
            {
                this.AbortAnimation("SwitchAnimation");

                IsToggled = true;
                new Animation
                {
                    {0, 1, new Animation(v => ThumbFrame.TranslationX = v, ThumbFrame.TranslationX, _xRef)},
                    {0, 1, new Animation(_ => SendSwitchPanUpdatedEventArgs(PanStatusEnum.Running))}
                }.Commit(this, "SwitchAnimation", 16, Convert.ToUInt32(_toggleAnimationDuration - (_toggleAnimationDuration * percentage / 100)), null, (_, __) =>
                {
                    this.AbortAnimation("SwitchAnimation");
                    CurrentState = SwitchStateEnum.Right;
                    IsToggled = true;
                    ThumbFrame.BackgroundColor = ThumbSelectedColor;
                    SendSwitchPanUpdatedEventArgs(PanStatusEnum.Completed);
                });
            }
            else
            {
                this.AbortAnimation("SwitchAnimation");
                CurrentState = SwitchStateEnum.Right;
                IsToggled = true;
                ThumbFrame.BackgroundColor = ThumbSelectedColor;
                SendSwitchPanUpdatedEventArgs(PanStatusEnum.Completed);
            }

            if (ReduceThumbSize)
            {
                await SizeTo(_increazeTo);
                this.imgIcon.IsVisible = true;
                SetSelectedIconSource();
            }
            else
            {
                SetSelectedIconSource();
            }
        }

        private void SetSelectedIconSource()
        {
            if (CustomSelectedIcon != null)
            {
                this.imgIcon.SetCustomImage(CustomSelectedIcon);
            }
            else if (!string.IsNullOrWhiteSpace(SelectedIcon))
            {
                this.imgIcon.SetImage(SelectedIcon);
            }
        }

        private void SendSwitchPanUpdatedEventArgs(PanStatusEnum status)
        {
            SwitchPanUpdatedEventArgs ev = new SwitchPanUpdatedEventArgs
            {
                XRef = _xRef,
                IsToggled = IsToggled,
                TranslateX = ThumbFrame.TranslationX,
                Status = status,
                Percentage = IsToggled
                    ? Math.Abs(ThumbFrame.TranslationX - _xRef) / (2 * _xRef) * 100
                    : Math.Abs(ThumbFrame.TranslationX + _xRef) / (2 * _xRef) * 100
            };

            if (!double.IsNaN(ev.Percentage))
            {
                SwitchPanUpdate?.Invoke(this, ev);
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            SendSwitchPanUpdatedEventArgs(PanStatusEnum.Started);
            if (CurrentState == SwitchStateEnum.Right)
            {
                await GoToLeft();
            }
            else
            {
                await GoToRight();
            }
        }

        private async void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            this.AbortAnimation("SwitchAnimation");
            double dragX = e.TotalX - _tmpTotalX;

            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    SendSwitchPanUpdatedEventArgs(PanStatusEnum.Started);
                    break;

                case GestureStatus.Running:
                    ThumbFrame.TranslationX = Math.Min(_xRef, Math.Max(-_xRef, ThumbFrame.TranslationX + dragX));
                    _tmpTotalX = e.TotalX;
                    SendSwitchPanUpdatedEventArgs(PanStatusEnum.Running);
                    break;

                case GestureStatus.Completed:
                    double percentage = IsToggled
                        ? Math.Abs(ThumbFrame.TranslationX - _xRef) / (2 * _xRef) * 100
                        : Math.Abs(ThumbFrame.TranslationX + _xRef) / (2 * _xRef) * 100;

                    if (ThumbFrame.TranslationX > 0)
                    {
                        await GoToRight(percentage);
                    }
                    else
                    {
                        await GoToLeft(percentage);
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

            // View
            view.SetBaseWidthRequest(Math.Max(view.BackgroundFrame.WidthRequest, view.ThumbFrame.WidthRequest * 2));
            view._xRef = ((view.BackgroundFrame.WidthRequest - view.ThumbFrame.WidthRequest) / 2) - 5;
            view.ThumbFrame.TranslationX = view.CurrentState == SwitchStateEnum.Left ? -view._xRef : view._xRef;
        }

        private void SetBaseWidthRequest(double widthRequest)
        {
            base.WidthRequest = widthRequest;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            switch (propertyName)
            {
                case nameof(BackgroundOnSelectedColor):
                    InitializeSwitchPanUpdate();
                    break;

                case nameof(BackgroundOnUnselectedColor):
                    InitializeSwitchPanUpdate();
                    break;
            }

            base.OnPropertyChanged(propertyName);
        }

        private async Task SizeTo(double scale)
        {
            uint length = 200;
            Easing easing = Easing.Linear;

            await ThumbFrame.ScaleTo(scale, length, easing);
        }

        private void InitializeSwitchPanUpdate()
        {
            SwitchPanUpdate += (sender, e) =>
            {
                //Color Animation
                Color fromColor = IsToggled ? BackgroundOnSelectedColor : BackgroundOnUnselectedColor;
                Color toColor = IsToggled ? BackgroundOnUnselectedColor : BackgroundOnSelectedColor;

                double t = e.Percentage * 0.01;

                BackgroundColor = ColorAnimationUtil.ColorAnimation(fromColor, toColor, t);
            };
        }
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
}