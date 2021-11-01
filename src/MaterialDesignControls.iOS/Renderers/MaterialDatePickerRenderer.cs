using System;
using System.ComponentModel;
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

                    if (!customDatePicker.CustomDate.HasValue && !string.IsNullOrEmpty(customDatePicker.Placeholder))
                    {
                        this.Control.Text = null;
                        this.Control.AttributedPlaceholder = new NSAttributedString(customDatePicker.Placeholder, foregroundColor: customDatePicker.PlaceholderColor.ToUIColor());
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
            var customDatePicker = (CustomDatePicker)Element;
            if (e.PropertyName == "IsFocused" && !customDatePicker.IsFocused && !customDatePicker.CustomDate.HasValue)
                Control.Text = customDatePicker.InternalDateTime.ToString(customDatePicker.Format);
            else if (e.PropertyName == nameof(customDatePicker.CustomDate) || e.PropertyName == nameof(customDatePicker.EmptyDate))
            {
                if (!customDatePicker.CustomDate.HasValue && !string.IsNullOrEmpty(customDatePicker.Placeholder))
                {
                    Control.Text = null;
                    Control.AttributedPlaceholder = new NSAttributedString(customDatePicker.Placeholder, foregroundColor: customDatePicker.PlaceholderColor.ToUIColor());
                }
            }
        }
    }
}