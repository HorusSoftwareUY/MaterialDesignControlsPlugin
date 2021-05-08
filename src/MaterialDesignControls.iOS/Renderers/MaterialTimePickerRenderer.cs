using System;
using System.ComponentModel;
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

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            // Set the default date if the user doesn't select anything
            var customTimePicker = (CustomTimePicker)Element;
            if (e.PropertyName == "IsFocused" && !customTimePicker.IsFocused && !customTimePicker.Time.HasValue)
            {
                var auxDateTime = new DateTime(DateTime.MinValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day,
                    customTimePicker.InternalTime.Hours, customTimePicker.InternalTime.Minutes, customTimePicker.InternalTime.Seconds);
                Control.Text = auxDateTime.ToString(customTimePicker.Format);
            }

            if (e.PropertyName == "Width")
            {
                if (!customTimePicker.Time.HasValue)
                {
                    Control.Text = String.Empty;
                }
                else
                {
                    var auxDateTime = new DateTime(DateTime.MinValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day,
                    customTimePicker.InternalTime.Hours, customTimePicker.InternalTime.Minutes, customTimePicker.InternalTime.Seconds);
                    Control.Text = auxDateTime.ToString(customTimePicker.Format);

                }
            }
        }
    }
}