using System;
using Plugin.MaterialDesignControls.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Picker), typeof(MaterialPickerRenderer))]

namespace Plugin.MaterialDesignControls.Renderers
{
    public class MaterialPickerRenderer : PickerRenderer
    {
        public static void Init() { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Picker> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                this.Control.BorderStyle = UITextBorderStyle.None;
            }
        }
    }
}
