using Android.Content;
using Android.OS;
using Plugin.MaterialDesignControls.Android.Renderers;
using Plugin.MaterialDesignControls.Implementations;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;

[assembly: Xamarin.Forms.ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace Plugin.MaterialDesignControls.Android.Renderers
{
    public class CustomFrameRenderer : Xamarin.Forms.Platform.Android.FastRenderers.FrameRenderer
    {
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
        //protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Frame> e)
        //{
        //    base.OnElementChanged(e);
        //    //var customFrame = (CustomFrame)Element;
        //    if (e.NewElement.HasShadow)
        //    {
        //        if (Build.VERSION.SdkInt >= BuildVersionCodes.P)
        //        {
        //            SetOutlineSpotShadowColor(Color.Blue);
        //            Elevation =10.0f;
        //            TranslationZ = 30.0f;
        //            //CardElevation = 0.0f;
        //            SetZ(30f);
        //            SetOutlineAmbientShadowColor(Color.Red);
        //        }
        //    }
        //}
    }
}
