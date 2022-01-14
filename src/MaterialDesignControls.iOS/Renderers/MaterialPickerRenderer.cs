using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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

                    if (customPicker.MultilineEnabled)
                    {
                        var nativePicker = Control.InputView as UIPickerView;
                        nativePicker.Delegate = new MyPickerDelegate(
                            () => Element.Items.ToList(),
                            () => customPicker.PickerRowHeight,
                            (selectedIndex) => this.Element.SelectedIndex = selectedIndex);
                    }
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var customPicker = (CustomPicker)Element;
            if (e.PropertyName == nameof(customPicker.SelectedIndex))
            {
                if (customPicker.SelectedItem == null && string.IsNullOrEmpty(Control.Text) && !string.IsNullOrEmpty(customPicker.Placeholder))
                {
                    this.Control.Text = null;
                    this.Control.AttributedPlaceholder = new NSAttributedString(customPicker.Placeholder, foregroundColor: customPicker.PlaceholderColor.ToUIColor());
                }
            }
        }
    }

    public class MyPickerDelegate : UIPickerViewDelegate
    {
        private Func<List<string>> items;
        private Func<int> rowHeight;
        private Action<int> onSelectedItem;

        public MyPickerDelegate(Func<List<string>> items, Func<int> rowHeight, Action<int> onSelectedItem)
        {
            this.items = items;
            this.rowHeight = rowHeight;
            this.onSelectedItem = onSelectedItem;
        }

        public override UIView GetView(UIPickerView pickerView, nint row, nint component, UIView view)
        {
            var label = view as UILabel;
            if (label == null)
            {
                label = new UILabel();
                label.Lines = 0;
            }

            label.LineBreakMode = UILineBreakMode.TailTruncation;

            var sourceList = items.Invoke();
            label.Text = sourceList[(int)row];
            label.TextAlignment = UITextAlignment.Center;

            return label;
        }

        public override nfloat GetRowHeight(UIPickerView pickerView, nint component)
        {
            return rowHeight.Invoke();
        }

        public override void Selected(UIPickerView pickerView, nint row, nint component)
        {
            onSelectedItem.Invoke((int)row);
        }
    }
}
