using Android.Content;
using Android.Util;

namespace System
{
	public static class DimensionsHelper
	{
        public static float DpToPixels(this float valueInDp, Context context)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }

        public static int DpToPixels(this int valueInDp, Context context)
        {
            return Convert.ToInt32(((float)valueInDp).DpToPixels(context));
        }
    }
}

