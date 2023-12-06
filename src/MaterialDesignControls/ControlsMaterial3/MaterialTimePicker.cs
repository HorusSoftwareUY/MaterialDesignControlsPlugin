using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3
{
    public class MaterialTimePicker : BaseMaterialFieldControl
    {
        #region Constructors

        public MaterialTimePicker()
        {
            pckTime = new Plugin.MaterialDesignControls.Material3.Implementations.CustomTimePicker()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            pckTime.SetValue(Grid.ColumnProperty, 1);
            pckTime.SetValue(Grid.RowProperty, 1);
            CustomContent = pckTime;

            pckTime.Focused += HandleFocusChange;
            pckTime.Unfocused += HandleFocusChange;
            pckTime.SetBinding(TimePicker.TimeProperty, new Binding() { Source = this, Path = TimeProperty.PropertyName });
        }

        #endregion Constructors

        #region Attributes

        private Plugin.MaterialDesignControls.Material3.Implementations.CustomTimePicker pckTime;


        #endregion Attributes

        #region Properties

        public new static readonly BindableProperty AnimatePlaceholderProperty =
                BindableProperty.Create(nameof(AnimatePlaceholder), typeof(bool), typeof(MaterialTimePicker), defaultValue: false);

        public new bool AnimatePlaceholder => false;

        public static readonly BindableProperty TimeProperty =
            BindableProperty.Create(nameof(Time), typeof(TimeSpan?), typeof(MaterialTimePicker), defaultValue: null, propertyChanged: OnTimeChanged, defaultBindingMode: BindingMode.TwoWay);

        public TimeSpan? Time
        {
            get { return (TimeSpan?)GetValue(TimeProperty); }
            set { SetValue(TimeProperty, value); }
        }

        public static readonly BindableProperty FormatProperty =
            BindableProperty.Create(nameof(Format), typeof(string), typeof(MaterialTimePicker), defaultValue: null);

        public string Format
        {
            get { return (string)GetValue(FormatProperty); }
            set { SetValue(FormatProperty, value); }
        }

        #endregion Properties

        #region Events

        public new event EventHandler<FocusEventArgs> Focused;

        public new event EventHandler<FocusEventArgs> Unfocused;

        #endregion Events

        #region Methods

        private static void OnTimeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialTimePicker)bindable;
            control.pckTime.CustomTime = (TimeSpan?)newValue;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            UpdateLayout(propertyName);

            switch (propertyName)
            {
                case nameof(base.TranslationX):
                    base.OnPropertyChanged(propertyName);
                    break;
                case nameof(this.Format):
                    this.pckTime.Format = this.Format;
                    break;
            }
        }

        public new bool Focus()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                pckTime.Focus();
            });
            return true;
        }

        public new bool Unfocus()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                pckTime.Unfocus();
            });
            return true;
        }

        private async void HandleFocusChange(object sender, FocusEventArgs e)
        {
            await SetFocusChange();

            // Set the default date if the user doesn't select anything
            if (!pckTime.IsControlFocused() && !pckTime.CustomTime.HasValue)
                Time = pckTime.InternalTime;

            if (pckTime.IsControlFocused())
                Focused?.Invoke(this, e);
            else
                Unfocused?.Invoke(this, e);
        }

        internal override void OnControlTappedEvent()
        {
            if (pckTime.IsControlEnabled())
                this.Focus();
        }

        #endregion Methods
    }
}