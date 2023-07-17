using Plugin.MaterialDesignControls.iOS.Renderers;
using Plugin.MaterialDesignControls.Material3.Implementations;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomProgressBar), typeof(CustomProgressBarRenderer))]

namespace Plugin.MaterialDesignControls.iOS.Renderers
{
    public class CustomProgressBarRenderer : ProgressBarRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e)
        {
            base.OnElementChanged(e);

            if (this.Control != null)
            {
                CustomProgressBar customProgressBar = (CustomProgressBar)(e.NewElement == null ? e.OldElement : e.NewElement);
                if (customProgressBar != null)
                {
                    Control.TrackTintColor = customProgressBar.TrackColor.ToUIColor();
                    Control.ProgressTintColor = customProgressBar.IndicatorColor.ToUIColor();
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var customProgressBar = (CustomProgressBar)Element;

            if (e.PropertyName == nameof(customProgressBar.TrackColor) || e.PropertyName == nameof(customProgressBar.IndicatorColor))
            {
                Control.TrackTintColor = customProgressBar.TrackColor.ToUIColor();
                Control.ProgressTintColor = customProgressBar.IndicatorColor.ToUIColor();
            }
        }
    }
}