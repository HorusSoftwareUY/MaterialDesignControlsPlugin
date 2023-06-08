using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Utils
{
    public static class ColorAnimationUtil
    {
        public static Color ColorAnimation(Color fromColor, Color toColor, double t)
        {
            return Color.FromRgba(fromColor.R + (t * (toColor.R - fromColor.R)),
                fromColor.G + (t * (toColor.G - fromColor.G)),
                fromColor.B + (t * (toColor.B - fromColor.B)),
                fromColor.A + (t * (toColor.A - fromColor.A)));
        }
    }
}
