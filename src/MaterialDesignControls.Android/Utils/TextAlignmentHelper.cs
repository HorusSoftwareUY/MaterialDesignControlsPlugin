using System;
using Android.Views;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Android.Utils
{
    public static class TextAlignmentHelper
    {
        public static GravityFlags ConvertToGravityFlags(Xamarin.Forms.TextAlignment textAlignment)
        {
            switch (textAlignment)
            {
                case Xamarin.Forms.TextAlignment.Start:
                    return GravityFlags.Left;
                case Xamarin.Forms.TextAlignment.Center:
                    return GravityFlags.Center;
                default:
                    return GravityFlags.Right;
            }
        }

        public static global::Android.Views.TextAlignment ConvertToAndroid(Xamarin.Forms.TextAlignment textAlignment)
        {
            switch (textAlignment)
            {
                case Xamarin.Forms.TextAlignment.Start:
                    return global::Android.Views.TextAlignment.TextStart;
                case Xamarin.Forms.TextAlignment.Center:
                    return global::Android.Views.TextAlignment.Center;
                default:
                    return global::Android.Views.TextAlignment.TextEnd;
            }
        }
    }
}
