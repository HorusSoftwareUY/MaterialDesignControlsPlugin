using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3.Implementations
{
    public class CustomProgressBar : ProgressBar
    {
        public static readonly BindableProperty TrackColorProperty =
            BindableProperty.Create(nameof(TrackColor), typeof(Color), typeof(CustomProgressBar), defaultValue: Color.Green);

        public Color TrackColor
        {
            get { return (Color)GetValue(TrackColorProperty); }
            set { SetValue(TrackColorProperty, value); }
        }


        public static readonly BindableProperty IsIndeterminatedProperty =
           BindableProperty.Create(nameof(IsIndeterminated), typeof(bool), typeof(CustomProgressBar), defaultValue: true);

        public bool IsIndeterminated
        {
            get { return (bool)GetValue(IsIndeterminatedProperty); }
            set { SetValue(IsIndeterminatedProperty, value); }
        }

        public static readonly BindableProperty IndicatorColorProperty =
            BindableProperty.Create(nameof(IndicatorColor), typeof(Color), typeof(CustomProgressBar), defaultValue: Color.Purple);

        public Color IndicatorColor
        {
            get { return (Color)GetValue(IndicatorColorProperty); }
            set { SetValue(IndicatorColorProperty, value); }
        }
    }
}
