using System;
using Foundation;
using Plugin.MaterialDesignControls.Implementations;
using Plugin.MaterialDesignControls.iOS;
using Plugin.MaterialDesignControls.iOS.Utils;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(MaterialDatePickerRenderer))]

namespace Plugin.MaterialDesignControls.iOS
{
    public class MaterialDatePickerRenderer : DatePickerRenderer
    {
        public static void Init() { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                this.Control.BorderStyle = UITextBorderStyle.None;
                
                if (this.Element is CustomDatePicker customDatePicker)
                {
                    this.Control.TextAlignment = TextAlignmentHelper.Convert(customDatePicker.HorizontalTextAlignment);

                    if (!customDatePicker.Date.HasValue && !string.IsNullOrEmpty(customDatePicker.Placeholder))
                    {
                        this.Control.Text = null;
                        this.Control.AttributedPlaceholder = new NSAttributedString(customDatePicker.Placeholder, foregroundColor: customDatePicker.PlaceholderColor.ToUIColor());
                    }
                }
            }
        }
    }
}
