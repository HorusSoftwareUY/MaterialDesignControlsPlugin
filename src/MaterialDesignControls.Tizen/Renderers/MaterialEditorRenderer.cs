using Plugin.MaterialDesignControls.Implementations;
using Plugin.MaterialDesignControls.Tizen;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;


[assembly: ExportRenderer(typeof(CustomEditor), typeof(MaterialEditorRenderer))]

namespace Plugin.MaterialDesignControls.Tizen
{
    public class MaterialEditorRenderer : EditorRenderer
    {
        public static void Init() { }
    }
}
