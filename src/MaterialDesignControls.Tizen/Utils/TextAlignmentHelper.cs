using Xamarin.Forms;
using NTextAlignment = Xamarin.Forms.Platform.Tizen.Native.TextAlignment;

namespace Plugin.MaterialDesignControls.Tizen.Utils
{
    public static class TextAlignmentHelper
    {
        public static NTextAlignment Convert(TextAlignment textAlignment)
        {
            switch (textAlignment)
            {
                case TextAlignment.Start:
                    return NTextAlignment.Start;
                case TextAlignment.Center:
                    return NTextAlignment.Center;
                case TextAlignment.End:
                    return NTextAlignment.End;
                default:
                    return NTextAlignment.None;
            }
        }
    }
}
