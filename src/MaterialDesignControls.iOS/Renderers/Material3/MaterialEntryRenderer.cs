using Plugin.MaterialDesignControls.Material3.Implementations;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(Plugin.MaterialDesignControls.Material3.iOS.MaterialEntryRenderer))]

namespace Plugin.MaterialDesignControls.Material3.iOS
{
    public class MaterialEntryRenderer : EntryRenderer
    {
        public static void Init() { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                this.Control.BorderStyle = UITextBorderStyle.None;

                CustomEntry customEntry = (CustomEntry)(e.NewElement == null ? e.OldElement : e.NewElement);
                if (customEntry != null)
                {
                    if (customEntry.IsCode && UIDevice.CurrentDevice.CheckSystemVersion(12, 0))
                        this.Control.TextContentType = UITextContentType.OneTimeCode;

                    if (customEntry.IsPassword && UIDevice.CurrentDevice.CheckSystemVersion(12, 0))
                        this.Control.TextContentType = UITextContentType.NewPassword;
                }
            }
        }
    }
}