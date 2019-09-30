using System;
using Foundation;
using Plugin.MaterialDesignControls.Implementations;
using Plugin.MaterialDesignControls.iOS;
using Plugin.MaterialDesignControls.iOS.Utils;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(MaterialPickerRenderer))]

namespace Plugin.MaterialDesignControls.iOS
{
    public class MaterialPickerRenderer : PickerRenderer
    {
        public static void Init() { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Picker> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                this.Control.BorderStyle = UITextBorderStyle.None;

                if (this.Element is CustomPicker customPicker)
                {
                    this.Control.TextAlignment = TextAlignmentHelper.Convert(customPicker.HorizontalTextAlignment);

                    if (customPicker.SelectedItem == null && !string.IsNullOrEmpty(customPicker.Placeholder))
                    {
                        this.Control.Text = null;
                        this.Control.AttributedPlaceholder = new NSAttributedString(customPicker.Placeholder, foregroundColor: customPicker.PlaceholderColor.ToUIColor());
                    }
                }
            }
        }
    }
}
