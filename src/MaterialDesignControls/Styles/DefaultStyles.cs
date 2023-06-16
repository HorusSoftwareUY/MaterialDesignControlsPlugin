using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Styles
{
    public static class DefaultStyles
    {
        public static Color PrimaryColor { get; set; } = Color.FromHex("#2e85cc");

        public static Color LightPrimaryColor { get; set; } = Color.FromHex("#d5e7f6");

        public static Color BackgroundColor { get; set; } = Color.White;

        public static Color ShadowColor { get; set; } = Color.Black; //Color.FromHex("#80000000");

        public static Color TextColor { get; set; } = Color.Black;

        public static double TapAnimationParameter { get; set; } = 0.7;

        public static AnimationTypes TapAnimation { get; set; } = AnimationTypes.Fade;
    }
}