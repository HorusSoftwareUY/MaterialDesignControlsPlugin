namespace Plugin.MaterialDesignControls.iOS
{
    public static class Renderer
    {
        public static void Init()
        {
            Effects.Init();
            MaterialDatePickerRenderer.Init();
            MaterialEntryRenderer.Init();
            MaterialPickerRenderer.Init();
            MaterialDoublePickerRenderer.Init();
            MaterialTimePickerRenderer.Init();
            MaterialEditorRenderer.Init();
            MaterialSliderRenderer.Init();
            Plugin.MaterialDesignControls.Material3.iOS.MaterialEntryRenderer.Init();
            Plugin.MaterialDesignControls.Material3.iOS.MaterialPickerRenderer.Init();
            Plugin.MaterialDesignControls.Material3.iOS.MaterialDoublePickerRenderer.Init();
            Plugin.MaterialDesignControls.Material3.iOS.MaterialDatePickerRenderer.Init();
            Plugin.MaterialDesignControls.Material3.iOS.MaterialTimePickerRenderer.Init();
            Plugin.MaterialDesignControls.Material3.iOS.MaterialEditorRenderer.Init();
            Plugin.MaterialDesignControls.Material3.iOS.MaterialActivityIndicatorRenderer.Init();
        }
    }
}
