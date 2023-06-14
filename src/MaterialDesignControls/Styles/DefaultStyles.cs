using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Styles
{
    public static class DefaultStyles
    {
        public static Color PrimaryColor { get; set; } = Color.FromHex("#2e85cc");

        public static Color BackgroundColor { get; set; } = Color.White;

        public static Color TextColor { get; set; } = Color.Black;

        public static double ButtonAnimationParameter { get; set; } = 0.7;

        public static AnimationTypes ButtonAnimation { get; set; } = AnimationTypes.Fade;


        public static double MaterialCardAnimationParameter { get; set; } = 0.7;

        public static AnimationTypes MaterialCardAnimation { get; set; } = AnimationTypes.Fade;
    }
}