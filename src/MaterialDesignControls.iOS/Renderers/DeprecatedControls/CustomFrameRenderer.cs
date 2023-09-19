using System;
using System.Drawing;
using Plugin.MaterialDesignControls.Implementations;
using Plugin.MaterialDesignControls.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(CustomFrameRenderer))]
namespace Plugin.MaterialDesignControls.iOS
{
    [Obsolete("CustomFrameRenderer is deprecated, please use MaterialCardRenderer of Material 3 instead.")]
    public class CustomFrameRenderer : FrameRenderer
    {
        public static void Init() { }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            var customFrame = (CustomFrame)Element;
            if(customFrame != null)
            { 
                if (customFrame.HasShadow)
                {
                    Layer.ShadowColor = customFrame.ShadowColor.ToCGColor();
                    Layer.ShadowRadius = (float)customFrame.iOSShadowRadius;
                    Layer.ShadowOpacity = (float)customFrame.iOSShadowOpacity;
                    Layer.ShadowOffset = new SizeF((float)customFrame.iOSShadowOffset.Width, (float)customFrame.iOSShadowOffset.Height);
		        }
	        }
        }
    }
}
