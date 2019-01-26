using System;
using Plugin.MaterialDesignControls;
using Plugin.MaterialDesignControls.Renderers;

namespace Plugin.MaterialDesignControls.iOS
{
    public static class Renderers
    {
        public static void Init()
        {
            MaterialDatePickerRenderer.Init();
            MaterialEntryRenderer.Init();
            MaterialPickerRenderer.Init();
        }
    }
}
