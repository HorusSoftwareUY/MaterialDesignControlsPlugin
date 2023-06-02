namespace Plugin.MaterialDesignControls.Android
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
            Plugin.MaterialDesignControls.Material3.Android.MaterialEntryRenderer.Init();
            Plugin.MaterialDesignControls.Material3.Android.MaterialPickerRenderer.Init();
            Plugin.MaterialDesignControls.Material3.Android.MaterialDoublePickerRenderer.Init();
            Plugin.MaterialDesignControls.Material3.Android.MaterialTimePickerRenderer.Init();
        }
    }
}
