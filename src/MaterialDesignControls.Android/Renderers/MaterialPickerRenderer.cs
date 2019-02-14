using System;
using Android.Content;
using Android.Graphics.Drawables;
using AndroidGraphics = Android.Graphics;
using Plugin.MaterialDesignControls.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(Plugin.MaterialDesignControls.Android.MaterialPickerRenderer))]

namespace Plugin.MaterialDesignControls.Android
{
    public class MaterialPickerRenderer : PickerRenderer
    {
        public static void Init() { }

        public MaterialPickerRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Picker> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                this.Control.Background = new ColorDrawable(AndroidGraphics.Color.Transparent);
            }
        }
    }
}
