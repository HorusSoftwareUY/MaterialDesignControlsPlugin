using Plugin.MaterialDesignControls.Implementations;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomSlider), typeof(Plugin.MaterialDesignControls.iOS.MaterialSliderRenderer))]
namespace Plugin.MaterialDesignControls.iOS
{
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

                if (customSlider.UserInteractionEnabled)
                    Control.SetThumbImage(UIImage.FromBundle(((FileImageSource)customSlider.ThumbImageSource).File), UIControlState.Normal);
                else
                    Control.SetThumbImage(new UIImage(), UIControlState.Normal);
            }
        }
    }
}