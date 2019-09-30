using System;
using Android.Views;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Android.Utils
{
    public static class TextAlignmentHelper
    {
        public static GravityFlags Convert(Xamarin.Forms.TextAlignment textAlignment)
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
    }
}
