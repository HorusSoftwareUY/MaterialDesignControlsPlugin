using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls.Material3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class MaterialDatePicker : BaseMaterialFieldControl
    {
        #region Constructors

        public MaterialDatePicker()
        {
            pckDate = new Plugin.MaterialDesignControls.Material3.Implementations.CustomDatePicker()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            pckDate.SetValue(Grid.ColumnProperty, 1);
            pckDate.SetValue(Grid.RowProperty, 1);
            CustomContent = pckDate;

            pckDate.Focused += HandleFocusChange;
            pckDate.Unfocused += HandleFocusChange;
            pckDate.SetBinding(DatePicker.DateProperty, new Binding() { Source = this, Path = DateProperty.PropertyName });

            TapGestureRecognizer frameTapGestureRecognizer = new TapGestureRecognizer();
            frameTapGestureRecognizer.Tapped += (s, e) =>
            {
                if (this.pckDate.IsControlEnabled())
                    this.pckDate.Focus();
            };
            this.Label.GestureRecognizers.Add(frameTapGestureRecognizer);
        }

        #endregion Constructors

        #region Attributes

        private Plugin.MaterialDesignControls.Material3.Implementations.CustomDatePicker pckDate;

        #endregion Attributes

        #region Properties
        public new static readonly BindableProperty AnimatePlaceholderProperty =
            BindableProperty.Create(nameof(AnimatePlaceholder), typeof(bool), typeof(MaterialDatePicker), defaultValue: false);

        public new bool AnimatePlaceholder => false;

        public static readonly BindableProperty DateProperty =
            BindableProperty.Create(nameof(Date), typeof(DateTime?), typeof(MaterialDatePicker), defaultValue: null, propertyChanged: OnDateChanged, defaultBindingMode: BindingMode.TwoWay);

        public DateTime? Date
        {
            get { return (DateTime?)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        public static readonly BindableProperty MinimumDateProperty =
            BindableProperty.Create(nameof(MinimumDate), typeof(DateTime), typeof(MaterialDatePicker), defaultValue: DateTime.MinValue);

        public DateTime MinimumDate
        {
            get { return (DateTime)GetValue(MinimumDateProperty); }
            set { SetValue(MinimumDateProperty, value); }
        }

        public static readonly BindableProperty MaximumDateProperty =
            BindableProperty.Create(nameof(MaximumDate), typeof(DateTime), typeof(MaterialDatePicker), defaultValue: DateTime.MaxValue);

        public DateTime MaximumDate
        {
            get { return (DateTime)GetValue(MaximumDateProperty); }
            set { SetValue(MaximumDateProperty, value); }
        }

        public static readonly BindableProperty FormatProperty =
            BindableProperty.Create(nameof(Format), typeof(string), typeof(MaterialDatePicker), defaultValue: null);

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

        private static void OnDateChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialDatePicker)bindable;
            control.pckDate.CustomDate = (DateTime?)newValue;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            UpdateLayout(propertyName);

            switch (propertyName)
            {
                case nameof(base.TranslationX):
                    base.OnPropertyChanged(propertyName);
                    break;
                case nameof(this.MinimumDate):
                    this.pckDate.MinimumDate = this.MinimumDate;
                    break;
                case nameof(this.MaximumDate):
                    this.pckDate.MaximumDate = this.MaximumDate;
                    break;
                case nameof(this.Format):
                    this.pckDate.Format = this.Format;
                    break;
            }
        }

        public new bool Focus()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                pckDate.Focus();
            });
            return true;
        }

        public new bool Unfocus()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                pckDate.Unfocus();
            });
            return true;
        }

        private async void HandleFocusChange(object sender, FocusEventArgs e)
        {
            await SetFocusChange();

            // Set the default date if the user doesn't select anything
            if (!this.pckDate.IsControlFocused() && !this.pckDate.CustomDate.HasValue)
                Date = this.pckDate.InternalDateTime;

            if (this.pckDate.IsControlFocused())
                Focused?.Invoke(this, e);
            else
                Unfocused?.Invoke(this, e);
        }

        #endregion Methods
    }
}
