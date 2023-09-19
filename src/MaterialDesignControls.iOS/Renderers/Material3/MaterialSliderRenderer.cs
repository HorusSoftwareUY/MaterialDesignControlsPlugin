﻿using System;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomSlider), typeof(Plugin.MaterialDesignControls.Material3.iOS.MaterialSliderRenderer))]
namespace Plugin.MaterialDesignControls.Material3.iOS
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

                if (customSlider.ThumbColor != Color.Transparent)
                    Control.ThumbTintColor = customSlider.ThumbColor.ToUIColor();
            }
        }
    }
}