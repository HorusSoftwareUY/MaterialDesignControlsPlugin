using Plugin.MaterialDesignControls;
using Plugin.MaterialDesignControls.Tizen;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;

[assembly: ExportRenderer(typeof(MaterialLabel), typeof(MaterialLabelRenderer))]

namespace Plugin.MaterialDesignControls.Tizen
{
    public class MaterialLabelRenderer : LabelRenderer
    {
        public static void Init() { }
    }
}
