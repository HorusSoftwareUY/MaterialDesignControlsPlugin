using Android.Content;
using Android.Graphics.Drawables;
using AndroidGraphics = Android.Graphics;
using Plugin.MaterialDesignControls.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(Plugin.MaterialDesignControls.Android.MaterialEditorRenderer))]

namespace Plugin.MaterialDesignControls.Android
{
    public class MaterialEditorRenderer : EditorRenderer
    {
        public static void Init() { }

        public MaterialEditorRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                this.Control.Background = new ColorDrawable(AndroidGraphics.Color.Transparent);
                this.Control.SetPadding(4, 0, 0, 0);
            }

            if (e.NewElement != null)
            {
                var element = e.NewElement as CustomEditor;
                this.Control.Hint = element.Placeholder;
                this.Control.SetHintTextColor(element.PlaceholderColor.ToAndroid());
            }
        }
    }
}
