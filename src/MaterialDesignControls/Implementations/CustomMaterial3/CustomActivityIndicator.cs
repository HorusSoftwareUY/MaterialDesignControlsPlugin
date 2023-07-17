using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3.Implementations
{
    public class CustomActivityIndicator : View
    {
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
    }
}
