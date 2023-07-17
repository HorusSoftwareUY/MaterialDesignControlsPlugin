using CoreGraphics;
using Plugin.MaterialDesignControls.iOS.Controls;
using Plugin.MaterialDesignControls.iOS.Renderers;
using Plugin.MaterialDesignControls.Material3;
using Plugin.MaterialDesignControls.Material3.Implementations;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomActivityIndicator), typeof(CustomActivityIndicatorRenderer))]

namespace Plugin.MaterialDesignControls.iOS.Renderers
{
    public class CustomActivityIndicatorRenderer : ViewRenderer
    {
        private Controls.CircularSlider circularSlider;

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null && this.Element is CustomActivityIndicator formsControl)
            {
                this.circularSlider = new Controls.CircularSlider(new CGRect(0, 0, 240, 240));
                this.circularSlider.SetHandleType(Controls.CircularSlider.CircularSliderHandleType.CircularSliderHandleTypeBigCircle);
                this.circularSlider.SetLineWidth(5);
                this.circularSlider.SetMinimumValue(0);
                //this.circularSlider.SetMaximumValue(formsControl.ValuesPerTurn);
                this.circularSlider.SetFilledColor(formsControl.IndicatorColor.ToUIColor());
                this.circularSlider.SetUnfilledColor(formsControl.TrackColor.ToUIColor());
                this.circularSlider.HandleColor = Color.Transparent.ToUIColor();
                //this.circularSlider.ValueChanged += CircularSlider_ValueChanged;
                this.circularSlider.SetCurrentValue(Convert.ToSingle(10));
                this.SetNativeControl(this.circularSlider);

                //formsControl.InternalValueRefreshed += (sender, args) =>
                //{
                //    this.circularSlider.SetCurrentValue(Convert.ToSingle(formsControl.InternalValue));
                //};
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (this.Control != null && this.Element is CustomActivityIndicator formsControl)
            {
                if (e.PropertyName.Equals("HandleColor"))
                {
                    this.circularSlider.HandleColor = Color.Transparent.ToUIColor();
                }
                else if (e.PropertyName.Equals("FilledColor"))
                {
                    this.circularSlider.SetFilledColor(formsControl.IndicatorColor.ToUIColor());
                }
                else if (e.PropertyName.Equals("UnfilledColor"))
                {
                    this.circularSlider.SetUnfilledColor(formsControl.TrackColor.ToUIColor());
                }
                //else if (e.PropertyName.Equals("ValuesPerTurn"))
                //{
                //    this.circularSlider.SetMaximumValue(formsControl.ValuesPerTurn);
                //}
            }
        }

        private void CircularSlider_ValueChanged(object sender, EventArgs e)
        {
            if (this.Element is MaterialProgressIndicator formsControl)
            {
                //formsControl.InternalValue = this.circularSlider.CurrentValue;
            }
        }
    }
}