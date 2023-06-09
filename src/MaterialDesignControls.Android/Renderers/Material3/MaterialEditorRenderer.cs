using Android.Content;
using Android.Graphics.Drawables;
using AndroidGraphics = Android.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Views.InputMethods;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Plugin.MaterialDesignControls.Material3.Android;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(MaterialEditorRenderer))]
namespace Plugin.MaterialDesignControls.Material3.Android
{
    public class MaterialEditorRenderer : EditorRenderer
    {
        public static void Init() { }

        public MaterialEditorRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Background = new ColorDrawable(AndroidGraphics.Color.Transparent);
                Control.SetPadding(0, 0, 0, 0);
                Control.ImeOptions = (ImeAction)ImeFlags.NoExtractUi;
            }

            if (e.NewElement != null)
            {
                var element = e.NewElement as CustomEditor;
                Control.Hint = element.Placeholder;
                Control.SetHintTextColor(element.PlaceholderColor.ToAndroid());
            }
        }
    }
}