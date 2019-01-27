using System;
using Plugin.MaterialDesignControls.Implementations;
using Plugin.MaterialDesignControls.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(MaterialEntryRenderer))]

namespace Plugin.MaterialDesignControls.Renderers
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
            }
        }
    }
}
