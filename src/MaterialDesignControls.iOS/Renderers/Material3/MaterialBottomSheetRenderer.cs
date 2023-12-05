using System;
using Plugin.MaterialDesignControls.Material3;
using Plugin.MaterialDesignControls.Material3.iOS;
using Plugin.MaterialDesignControls.Utils;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MaterialBottomSheet), typeof(MaterialBottomSheetRenderer))]
namespace Plugin.MaterialDesignControls.Material3.iOS
{
    public class MaterialBottomSheetRenderer : ViewRenderer<MaterialBottomSheet, UIView>
    {
        public static new void Init() { }

        protected override void OnElementChanged(ElementChangedEventArgs<MaterialBottomSheet> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                try
                {
                    if (UIDevice.CurrentDevice.CheckSystemVersion(11, 0))
                    {
                        var insets = UIApplication.SharedApplication.Windows[0].SafeAreaInsets;
                        if (insets != null && insets.Bottom > 0)
                            Element.SetBottomSafeArea(insets.Bottom);
                    }
                }
                catch (Exception ex)
                {
                    LoggerHelper.Log(ex);
                }
            }
        }
    }
}