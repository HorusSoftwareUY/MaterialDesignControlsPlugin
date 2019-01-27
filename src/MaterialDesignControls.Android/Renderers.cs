using System;
using Plugin.MaterialDesignControls;
using Plugin.MaterialDesignControls.Android.Renderers;

namespace Plugin.MaterialDesignControls.Android
{
    public static class Renderer
    {
        public static void Init()
        {
            MaterialDatePickerRenderer.Init();
            MaterialEntryRenderer.Init();
            MaterialPickerRenderer.Init();
        }
    }
}
