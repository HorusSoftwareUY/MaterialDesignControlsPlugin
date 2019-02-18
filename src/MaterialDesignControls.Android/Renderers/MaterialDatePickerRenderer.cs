using System;
using Android.Content;
using Android.Graphics.Drawables;
using AndroidGraphics = Android.Graphics;
using Plugin.MaterialDesignControls.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(Plugin.MaterialDesignControls.Android.MaterialDatePickerRenderer))]

namespace Plugin.MaterialDesignControls.Android
{
    public class MaterialDatePickerRenderer : DatePickerRenderer
    {
        public static void Init() { }

        public MaterialDatePickerRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                this.Control.Background = new ColorDrawable(AndroidGraphics.Color.Transparent);
                this.Control.SetPadding(1, 0, 0, 0);
            }
        }
    }
}
