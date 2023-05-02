using Android.Content;
using Android.Graphics.Drawables;
using Android.Views.InputMethods;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using AndroidGraphics = Android.Graphics;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(Plugin.MaterialDesignControls.Material3.Android.MaterialEntryRenderer))]

namespace Plugin.MaterialDesignControls.Material3.Android
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

                if (Element.ReturnType == ReturnType.Default || Element.ReturnType == ReturnType.Next)
                    Control.ImeOptions = (ImeAction)ImeFlags.NoExtractUi;
            }
        }
    }
}