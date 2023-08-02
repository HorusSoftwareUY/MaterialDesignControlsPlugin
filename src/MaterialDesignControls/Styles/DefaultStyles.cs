using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Styles
{
    public static class DefaultStyles
    {
        public static Color PrimaryColor { get; set; } = Color.FromHex("#2e85cc");

        public static Color PrimaryContainerColor { get; set; } = Color.FromHex("#eaf3fa");

        public static Color BackgroundColor { get; set; } = Color.White;

        public static Color TextColor { get; set; } = Color.Black;

        public static Color DisableColor { get; set; } = Color.FromHex("#808080");

        public static Color DisableContainerColor { get; set; } = Color.FromHex("#f2f2f2");

        public static double ButtonAnimationParameter { get; set; } = 0.7;

        public static AnimationTypes ButtonAnimation { get; set; } = AnimationTypes.Fade;
    }
}