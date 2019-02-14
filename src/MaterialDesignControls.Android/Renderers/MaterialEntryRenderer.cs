using System;
using Android.Content;
using Android.Graphics.Drawables;
using AndroidGraphics = Android.Graphics;
using Plugin.MaterialDesignControls.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(Plugin.MaterialDesignControls.Android.MaterialEntryRenderer))]

namespace Plugin.MaterialDesignControls.Android
{
    public class MaterialEntryRenderer : EntryRenderer
    {
        public static void Init() { }

        public MaterialEntryRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                this.Control.Background = new ColorDrawable(AndroidGraphics.Color.Transparent);
            }
        }
    }
}
