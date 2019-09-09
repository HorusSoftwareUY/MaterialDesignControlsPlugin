using Android.Content;
using Plugin.MaterialDesignControls.Android;
using Plugin.MaterialDesignControls.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomButton), typeof(MaterialButtonRenderer))]

namespace Plugin.MaterialDesignControls.Android
{
    public class MaterialButtonRenderer : ButtonRenderer
    {
        public static void Init() { }

        public MaterialButtonRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                this.Control.SetAllCaps(false);
            }
        }
    }
}
