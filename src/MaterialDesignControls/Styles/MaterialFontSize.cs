using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Styles
{
	public static class MaterialFontSize
	{
        public static double DisplayLarge { get; set; } = Device.Idiom == TargetIdiom.Tablet ? 80 : 57;

        public static double DisplayMedium { get; set; } = Device.Idiom == TargetIdiom.Tablet ? 62 : 45;

        public static double DisplaySmall { get; set; } = Device.Idiom == TargetIdiom.Tablet ? 50 : 36;

        public static double HeadlineLarge { get; set; } = Device.Idiom == TargetIdiom.Tablet ? 44 : 32;

        public static double HeadlineMedium { get; set; } = Device.Idiom == TargetIdiom.Tablet ? 38 : 28;

        public static double HeadlineSmall { get; set; } = Device.Idiom == TargetIdiom.Tablet ? 32 : 24;

        public static double TitleLarge { get; set; } = Device.Idiom == TargetIdiom.Tablet ? 26 : 22;

        public static double TitleMedium { get; set; } = Device.Idiom == TargetIdiom.Tablet ? 19 : 16;

        public static double TitleSmall { get; set; } = Device.Idiom == TargetIdiom.Tablet ? 17 : 14;

        public static double LabelLarge { get; set; } = Device.Idiom == TargetIdiom.Tablet ? 17 : 14;

        public static double LabelMedium { get; set; } = Device.Idiom == TargetIdiom.Tablet ? 15 : 12;

        public static double LabelSmall { get; set; } = Device.Idiom == TargetIdiom.Tablet ? 14 : 11;

        public static double BodyLarge { get; set; } = Device.Idiom == TargetIdiom.Tablet ? 19 : 16;

        public static double BodyMedium { get; set; } = Device.Idiom == TargetIdiom.Tablet ? 17 : 14;

        public static double BodySmall { get; set; } = Device.Idiom == TargetIdiom.Tablet ? 15 : 12;
    }
}