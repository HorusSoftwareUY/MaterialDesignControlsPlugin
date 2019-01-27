using System;
using Plugin.MaterialDesignControls;
using Plugin.MaterialDesignControls.Renderers;

namespace Plugin.MaterialDesignControls.iOS
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
