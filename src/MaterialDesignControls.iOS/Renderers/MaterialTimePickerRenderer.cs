using System;
using Foundation;
using Plugin.MaterialDesignControls.Implementations;
using Plugin.MaterialDesignControls.iOS;
using Plugin.MaterialDesignControls.iOS.Utils;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomTimePicker), typeof(MaterialTimePickerRenderer))]

namespace Plugin.MaterialDesignControls.iOS
{
    public class MaterialTimePickerRenderer : TimePickerRenderer
    {
        public static void Init() { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.TimePicker> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                this.Control.BorderStyle = UITextBorderStyle.None;

                if (this.Element is CustomTimePicker customTimePicker)
                {
                    this.Control.TextAlignment = TextAlignmentHelper.Convert(customTimePicker.HorizontalTextAlignment);

                    if (!customTimePicker.Time.HasValue && !string.IsNullOrEmpty(customTimePicker.Placeholder))
                    {
                        this.Control.Text = null;
                        this.Control.AttributedPlaceholder = new NSAttributedString(customTimePicker.Placeholder, foregroundColor: customTimePicker.PlaceholderColor.ToUIColor());
                    }

                    if (UIDevice.CurrentDevice.CheckSystemVersion(13, 2))
                    {
                        try
                        {
                            UIDatePicker picker = (UIDatePicker)Control.InputView;
                            picker.PreferredDatePickerStyle = UIDatePickerStyle.Wheels;
                        }
                        catch (Exception)
                        { }
                    }
                }
            }
        }
    }
}