using System;
using Plugin.MaterialDesignControls.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(DatePicker), typeof(MaterialDatePickerRenderer))]

namespace Plugin.MaterialDesignControls.Renderers
{
    public class MaterialDatePickerRenderer : DatePickerRenderer
    {
        public static void Init() { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                this.Control.BorderStyle = UITextBorderStyle.None;
            }
        }
    }
}
