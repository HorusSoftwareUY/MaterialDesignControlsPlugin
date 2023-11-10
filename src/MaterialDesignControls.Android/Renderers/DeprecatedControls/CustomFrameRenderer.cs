using Android.Content;
using Android.OS;
using Plugin.MaterialDesignControls.Android;
using Plugin.MaterialDesignControls.Implementations;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using System;

[assembly: Xamarin.Forms.ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace Plugin.MaterialDesignControls.Android
{
    [Obsolete("CustomFrameRenderer is deprecated, please use MaterialCardRenderer of Material 3 instead.")]
    public class CustomFrameRenderer : Xamarin.Forms.Platform.Android.FastRenderers.FrameRenderer
    {
        public static void Init() { }

        public CustomFrameRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            var customFrame = (CustomFrame)Element;
            if (customFrame != null)
            {
                if (customFrame.HasShadow)
                {
                    if (Build.VERSION.SdkInt >= BuildVersionCodes.P)
                    {
                        SetOutlineSpotShadowColor(customFrame.ShadowColor.ToAndroid());
                        SetOutlineAmbientShadowColor(customFrame.ShadowColor.ToAndroid());
                        CardElevation = (float)customFrame.AndroidElevation;
                    }
                    else
                    {
                        var borderColor = customFrame.ShadowColor.MultiplyAlpha(customFrame.AndroidBorderAlpha);
                        Element.BorderColor = borderColor;
                    }
                }
            }
        }
    }
}
