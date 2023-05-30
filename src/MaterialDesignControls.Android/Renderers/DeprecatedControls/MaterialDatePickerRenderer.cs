using Android.Content;
using Android.Graphics.Drawables;
using Plugin.MaterialDesignControls.Material3.Android;
using Plugin.MaterialDesignControls.Material3.Implementations;
using AndroidGraphics = Android.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Plugin.MaterialDesignControls.Android.Utils;
using System.ComponentModel;
using System;

[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(MaterialDatePickerRenderer))]

namespace Plugin.MaterialDesignControls.Material3.Android
{
    public class MaterialDatePickerRenderer : DatePickerRenderer
    {
        public static void Init() { }

        public MaterialDatePickerRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                this.Control.Background = new ColorDrawable(AndroidGraphics.Color.Transparent);
                this.Control.SetPadding(4, 0, 0, 0);

                if (this.Element is CustomDatePicker customDatePicker)
                {
                    this.Control.Gravity = TextAlignmentHelper.ConvertToGravityFlags(customDatePicker.HorizontalTextAlignment);

                    if (!customDatePicker.CustomDate.HasValue && !string.IsNullOrEmpty(customDatePicker.Placeholder))
                    {
                        this.Control.Text = null;
                        this.Control.Hint = customDatePicker.Placeholder;
                        this.Control.SetHintTextColor(customDatePicker.PlaceholderColor.ToAndroid());
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
                    this.Control.Text = null;
                    this.Control.Hint = customDatePicker.Placeholder;
                    this.Control.SetHintTextColor(customDatePicker.PlaceholderColor.ToAndroid());
                }
            }
        }
    }
}