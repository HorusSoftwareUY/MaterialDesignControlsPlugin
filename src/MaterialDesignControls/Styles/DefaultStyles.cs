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

        public static Color ErrorColor { get; set; } = Color.FromHex("B3261E");

        public static Color DisableColor { get; set; } = Color.FromHex("#9791A1");

        public static Color DisableContainerColor { get; set; } = Color.FromHex("#E5E3E8");

        public static Color OutlineColor { get; set; } = Color.FromHex("#79747E");

        public static Color OutlineVariantColor { get; set; } = Color.FromHex("#CAC4D0");

        public static Color ShadowColor { get; set; } = Color.FromHex("#000000");

        public static Color SecondaryColor { get; set; } = Color.FromHex("#625B71");

        public static double AnimationParameter { get; set; } = 0.7;

        public static AnimationTypes AnimationType { get; set; } = AnimationTypes.Fade;

        public static bool AnimateError { get; set; } = true;

        public static string FontFamily { get; set; } = null;

        public static string FontFamilyRegular { get; set; } = null;

        public static string FontFamilyMedium { get; set; } = null;

        public static FontSizes PhoneFontSizes { get; set; } = new FontSizes
        {
            DisplayLarge = 57,
            DisplayMedium = 45,
            DisplaySmall = 36,
            HeadlineLarge = 32,
            HeadlineMedium = 28,
            HeadlineSmall = 24,
            TitleLarge = 22,
            TitleMedium = 16,
            TitleSmall = 14,
            LabelLarge = 14,
            LabelMedium = 12,
            LabelSmall = 11,
            BodyLarge = 16,
            BodyMedium = 14,
            BodySmall = 12
        };

        public static FontSizes TabletFontSizes { get; set; } = new FontSizes
        {
            DisplayLarge = 80,
            DisplayMedium = 64,
            DisplaySmall = 48,
            HeadlineLarge = 40,
            HeadlineMedium = 34,
            HeadlineSmall = 28,
            TitleLarge = 26,
            TitleMedium = 18,
            TitleSmall = 16,
            LabelLarge = 16,
            LabelMedium = 13,
            LabelSmall = 12,
            BodyLarge = 18,
            BodyMedium = 16,
            BodySmall = 13
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