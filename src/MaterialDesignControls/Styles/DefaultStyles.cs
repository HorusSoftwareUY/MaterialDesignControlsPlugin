using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Styles
{
    public static class DefaultStyles
    {
        public static Color PrimaryColor { get; set; } = Color.FromHex("#6750A4");

        public static Color OnPrimaryColor { get; set; } = Color.FromHex("#FFFFFF");

        public static Color PrimaryContainerColor { get; set; } = Color.FromHex("#EADDFF");

        public static Color OnPrimaryContainerColor { get; set; } = Color.FromHex("#21005D");

        public static Color TextColor { get; set; } = Color.FromHex("#1D1B20");

        public static Color ErrorColor { get; set; } = Color.FromHex("B3261E");

        public static Color DisableColor { get; set; } = Color.FromHex("#9791A1");

        public static Color DisableContainerColor { get; set; } = Color.FromHex("#E5E3E8");

        public static double AnimationParameter { get; set; } = 0.7;

        public static AnimationTypes AnimationType { get; set; } = AnimationTypes.Fade;

        public static bool AnimateError { get; set; } = true;

        public static string FontFamily { get; set; } = null;
    }
}