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

        public static Color OutlineVariantColor { get; set; } = Color.FromHex("#CAC4D0");

        public static double ButtonAnimationParameter { get; set; } = 0.7;

        public static AnimationTypes ButtonAnimation { get; set; } = AnimationTypes.Fade;

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
        public int DisplayLarge { get; set; }

        public int DisplayMedium { get; set; }

        public int DisplaySmall { get; set; }

        public int HeadlineLarge { get; set; }

        public int HeadlineMedium { get; set; }

        public int HeadlineSmall { get; set; }

        public int TitleLarge { get; set; }

        public int TitleMedium { get; set; }

        public int TitleSmall { get; set; }

        public int LabelLarge { get; set; }

        public int LabelMedium { get; set; }

        public int LabelSmall { get; set; }

        public int BodyLarge { get; set; }

        public int BodyMedium { get; set; }

        public int BodySmall { get; set; }
    }
}