using Android.Content;
using Android.Graphics.Drawables;
using AndroidGraphics = Android.Graphics;
using Plugin.MaterialDesignControls.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Views.InputMethods;

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

            if (Control != null)
            {
                Control.Background = new ColorDrawable(AndroidGraphics.Color.Transparent);
                Control.SetPadding(4, 0, 0, 0);
                Control.ImeOptions = (ImeAction)ImeFlags.NoExtractUi;
            }
        }
    }
}