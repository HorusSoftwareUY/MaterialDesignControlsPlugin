using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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
        }
        #endregion Constructors

        #region Attributes
        private SwitchStateEnum CurrentState { get; set; }
        private double _xRef;
        private double _tmpTotalX;
        #endregion Attributes

        #region Properties
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

        #endregion Properties

        #region Events

        public event EventHandler<ToggledEventArgs> Toggled;

        public event EventHandler<SwitchPanUpdatedEventArgs> SwitchPanUpdate;

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