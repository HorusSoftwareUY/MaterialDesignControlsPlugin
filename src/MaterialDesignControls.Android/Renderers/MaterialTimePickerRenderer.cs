using System;
using Android.Content;
using Android.Graphics.Drawables;
using AndroidGraphics = Android.Graphics;
using Plugin.MaterialDesignControls.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomTimePicker), typeof(Plugin.MaterialDesignControls.Android.MaterialTimePickerRenderer))]

namespace Plugin.MaterialDesignControls.Android
{
    public class MaterialTimePickerRenderer : TimePickerRenderer
    {
        public static void Init() { }

        public MaterialTimePickerRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.TimePicker> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                this.Control.Background = new ColorDrawable(AndroidGraphics.Color.Transparent);
            }
        }
    }
}
