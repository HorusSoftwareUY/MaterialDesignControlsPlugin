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

        public static Color SurfaceContainerHighestColor { get; set; } = Color.FromHex("#E6E0E9");

        public static Color OnSurfaceColor { get; set; } = Color.FromHex("#1D1B20");

        public static Color OnSurfaceVariantColor { get; set; } = Color.FromHex("#49454F");

        public static Color ErrorColor { get; set; } = Color.FromHex("#B3261E");

        public static Color DisableColor { get; set; } = Color.FromHex("#9791A1");

        public static Color DisableContainerColor { get; set; } = Color.FromHex("#E5E3E8");

        public static Color OutlineColor { get; set; } = Color.FromHex("#79747E");

        public static Color OutlineVariantColor { get; set; } = Color.FromHex("#CAC4D0");

        public static Color ShadowColor { get; set; } = Color.FromHex("#000000");

        public static Color InverseSurfaceColor { get; set; } = Color.FromHex("#322F35");

        public static double AnimationParameter { get; set; } = 0.7;

        public static AnimationTypes AnimationType { get; set; } = AnimationTypes.Fade;

        public static bool AnimateError { get; set; } = true;

        public static string FontFamily { get; set; } = null;

        public static string FontFamilyRegular { get; set; } = null;

        public static string FontFamilyMedium { get; set; } = null;

        public static FontSizes FontSizes { get; set; } = new FontSizes
        {
            DisplayLarge = Device.Idiom == TargetIdiom.Tablet ? 80 : 57,
            DisplayMedium = Device.Idiom == TargetIdiom.Tablet ? 62 : 45,
            DisplaySmall = Device.Idiom == TargetIdiom.Tablet ? 50 : 36,
            HeadlineLarge = Device.Idiom == TargetIdiom.Tablet ? 44 : 32,
            HeadlineMedium = Device.Idiom == TargetIdiom.Tablet ? 38 : 28,
            HeadlineSmall = Device.Idiom == TargetIdiom.Tablet ? 32 : 24,
            TitleLarge = Device.Idiom == TargetIdiom.Tablet ? 26 : 22,
            TitleMedium = Device.Idiom == TargetIdiom.Tablet ? 19 : 16,
            TitleSmall = Device.Idiom == TargetIdiom.Tablet ? 17 : 14,
            LabelLarge = Device.Idiom == TargetIdiom.Tablet ? 17 : 14,
            LabelMedium = Device.Idiom == TargetIdiom.Tablet ? 15 : 12,
            LabelSmall = Device.Idiom == TargetIdiom.Tablet ? 14 : 11,
            BodyLarge = Device.Idiom == TargetIdiom.Tablet ? 19 : 16,
            BodyMedium = Device.Idiom == TargetIdiom.Tablet ? 17 : 14,
            BodySmall = Device.Idiom == TargetIdiom.Tablet ? 15 : 12
        };
    }

    public class FontSizes
    {
        public double DisplayLarge { get; set; }

        public double DisplayMedium { get; set; }

        public double DisplaySmall { get; set; }

        public double HeadlineLarge { get; set; }

        public double HeadlineMedium { get; set; }

        public double HeadlineSmall { get; set; }

        public double TitleLarge { get; set; }

        public double TitleMedium { get; set; }

        public double TitleSmall { get; set; }

        public double LabelLarge { get; set; }

        public double LabelMedium { get; set; }

        public double LabelSmall { get; set; }

        public double BodyLarge { get; set; }

        public double BodyMedium { get; set; }

        public double BodySmall { get; set; }
    }
}