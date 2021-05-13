using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Implementations
{
    public class CustomSlider : Slider
    {
        public static readonly BindableProperty ActiveTrackColorProperty =
            BindableProperty.Create(nameof(ActiveTrackColor), typeof(Color), typeof(CustomSlider), defaultValue: Color.Black);

        public Color ActiveTrackColor
        {
            get { return (Color)GetValue(ActiveTrackColorProperty); }
            set { SetValue(ActiveTrackColorProperty, value); }
        }

        public static readonly BindableProperty InactiveTrackColorProperty =
            BindableProperty.Create(nameof(InactiveTrackColor), typeof(Color), typeof(CustomSlider), defaultValue: Color.Gray);

        public Color InactiveTrackColor
        {
            get { return (Color)GetValue(InactiveTrackColorProperty); }
            set { SetValue(InactiveTrackColorProperty, value); }
        }

        public static new readonly BindableProperty ThumbColorProperty =
            BindableProperty.Create(nameof(ThumbColor), typeof(Color), typeof(CustomSlider), defaultValue: Color.Black);

        public new Color ThumbColor
        {
            get { return (Color)GetValue(ThumbColorProperty); }
            set { SetValue(ThumbColorProperty, value); }
        }

        public static readonly BindableProperty TrackHeightProperty =
            BindableProperty.Create(nameof(TrackHeight), typeof(int), typeof(CustomSlider), defaultValue: 6);

        public int TrackHeight
        {
            get { return (int)GetValue(TrackHeightProperty); }
            set { SetValue(TrackHeightProperty, value); }
        }

        public static readonly BindableProperty TrackCornerRadiusProperty =
            BindableProperty.Create(nameof(TrackCornerRadius), typeof(int), typeof(CustomSlider), defaultValue: 3);

        public int TrackCornerRadius
        {
            get { return (int)GetValue(TrackCornerRadiusProperty); }
            set { SetValue(TrackCornerRadiusProperty, value); }
        }

        public static readonly BindableProperty UserInteractionEnabledProperty =
            BindableProperty.Create(nameof(UserInteractionEnabled), typeof(bool), typeof(CustomSlider), defaultValue: true);

        public bool UserInteractionEnabled
        {
            get { return (bool)GetValue(UserInteractionEnabledProperty); }
            set { SetValue(UserInteractionEnabledProperty, value); }
        }
    }
}
