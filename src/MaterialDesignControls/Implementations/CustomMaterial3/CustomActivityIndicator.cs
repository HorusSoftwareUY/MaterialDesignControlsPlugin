using System;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3.Implementations
{
    public class CustomActivityIndicator : View
    {
        public const int MinimumValue = 0;
        public const int MaximumValue = 999;

        private int SensibilityToTurnsChanges = 10;
        private int turnsIndex = 0;
        private bool internalValueUpdate = false;

        public event EventHandler InternalValueRefreshed;

        public static readonly BindableProperty TrackColorProperty =
            BindableProperty.Create(nameof(TrackColor), typeof(Color), typeof(CustomActivityIndicator), defaultValue: Color.DarkGray);

        public Color TrackColor
        {
            get { return (Color)GetValue(TrackColorProperty); }
            set { SetValue(TrackColorProperty, value); }
        }

        public static readonly BindableProperty IsIndeterminatedProperty =
           BindableProperty.Create(nameof(IsIndeterminated), typeof(bool), typeof(CustomActivityIndicator), defaultValue: true);

        public bool IsIndeterminated
        {
            get { return (bool)GetValue(IsIndeterminatedProperty); }
            set { SetValue(IsIndeterminatedProperty, value); }
        }

        public static readonly BindableProperty IndicatorColorProperty =
            BindableProperty.Create(nameof(IndicatorColor), typeof(Color), typeof(CustomActivityIndicator), defaultValue: Color.Purple);

        public Color IndicatorColor
        {
            get { return (Color)GetValue(IndicatorColorProperty); }
            set { SetValue(IndicatorColorProperty, value); }
        }

        public static readonly BindableProperty ValueProperty =
            BindableProperty.Create(nameof(Value), typeof(double), typeof(CustomActivityIndicator), defaultValue: 0.0, defaultBindingMode: BindingMode.TwoWay, propertyChanged: ValueChanged);

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly BindableProperty ValuesPerTurnProperty =
           BindableProperty.Create(nameof(ValuesPerTurn), typeof(int), typeof(CustomActivityIndicator), defaultValue: 50, propertyChanged: ValuesPerTurnChanged);

        public int ValuesPerTurn
        {
            get { return (int)GetValue(ValuesPerTurnProperty); }
            set { SetValue(ValuesPerTurnProperty, value); }
        }

        private double internalValue;

        public double InternalValue
        {
            get { return this.internalValue; }
            set
            {
                this.internalValueUpdate = true;

                if (this.internalValue > (this.ValuesPerTurn - SensibilityToTurnsChanges)
                    && value < (0 + SensibilityToTurnsChanges))
                {
                    ++this.turnsIndex;
                }
                else if (this.internalValue < (MinimumValue + SensibilityToTurnsChanges)
                    && value > (this.ValuesPerTurn - SensibilityToTurnsChanges))
                {
                    --this.turnsIndex;
                }

                this.internalValue = value;

                var newValue = this.InternalValue + (this.turnsIndex * this.ValuesPerTurn);
                if (newValue < MinimumValue)
                {
                    this.Value = MinimumValue;
                }
                else if (newValue > MaximumValue)
                {
                    this.Value = MaximumValue;
                }
                else
                {
                    this.Value = newValue;
                }

                this.internalValueUpdate = false;
            }
        }

        private static void ValueChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomActivityIndicator)bindable;
            if (!control.internalValueUpdate)
            {
                var newInternalValue = ((double)newValue % control.ValuesPerTurn);
                var newTurnsIndex = Convert.ToInt32(newValue) / control.ValuesPerTurn;
                control.turnsIndex = newTurnsIndex;
                control.InternalValue = newInternalValue;
            }
        }

        private static void ValuesPerTurnChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (CustomActivityIndicator)bindable;
            control.SensibilityToTurnsChanges = Convert.ToInt32(control.ValuesPerTurn * 0.20);
        }
    }
}
