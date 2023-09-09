using System;
using Plugin.MaterialDesignControls.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomSlider), typeof(Plugin.MaterialDesignControls.iOS.MaterialSliderRenderer))]
namespace Plugin.MaterialDesignControls.iOS
{
    [Obsolete("MaterialSliderRenderer is deprecated, please use MaterialSliderRenderer of Material 3 instead.")]
    public class MaterialSliderRenderer : SliderRenderer
    {
        public static void Init() { }

        protected override void OnElementChanged(ElementChangedEventArgs<Slider> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                var customSlider = (CustomSlider)Element;

                Element.MinimumTrackColor = customSlider.ActiveTrackColor;
                Element.MaximumTrackColor = customSlider.InactiveTrackColor;

                Control.UserInteractionEnabled = customSlider.UserInteractionEnabled;

                if (customSlider.ThumbColor != Color.Transparent)
                    Control.ThumbTintColor = customSlider.ThumbColor.ToUIColor();
            }
        }
    }
}