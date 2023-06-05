using System;
using Android.Content;
using Android.Graphics.Drawables;
using AndroidGraphics = Android.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Plugin.MaterialDesignControls.Android.Utils;
using System.ComponentModel;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Plugin.MaterialDesignControls.Material3.Android;

[assembly: ExportRenderer(typeof(CustomTimePicker), typeof(MaterialTimePickerRenderer))]


namespace Plugin.MaterialDesignControls.Material3.Android
{
    public class MaterialTimePickerRenderer : TimePickerRenderer
    {
        public static void Init() { }

        public MaterialTimePickerRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.TimePicker> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                this.Control.Background = new ColorDrawable(AndroidGraphics.Color.Transparent);
                this.Control.SetPadding(0, 0, 0, 0);

                if (this.Element is CustomTimePicker customTimePicker)
                {
                    this.Control.Gravity = TextAlignmentHelper.ConvertToGravityFlags(customTimePicker.HorizontalTextAlignment);

                    if (!customTimePicker.CustomTime.HasValue && !string.IsNullOrEmpty(customTimePicker.Placeholder))
                    {
                        this.Control.Text = null;
                        this.Control.Hint = customTimePicker.Placeholder;
                        this.Control.SetHintTextColor(customTimePicker.PlaceholderColor.ToAndroid());
                    }
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            // Set the default date if the user doesn't select anything
            var customTimePicker = (CustomTimePicker)Element;
            if (e.PropertyName == "IsFocused" && !customTimePicker.IsFocused && !customTimePicker.CustomTime.HasValue)
            {
                var auxDateTime = new DateTime(DateTime.MinValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day,
                    customTimePicker.InternalTime.Hours, customTimePicker.InternalTime.Minutes, customTimePicker.InternalTime.Seconds);
                Control.Text = auxDateTime.ToString(customTimePicker.Format);
            }
            else if (e.PropertyName == nameof(customTimePicker.CustomTime) || e.PropertyName == nameof(customTimePicker.EmptyTime))
            {
                if (!customTimePicker.CustomTime.HasValue && !string.IsNullOrEmpty(customTimePicker.Placeholder))
                {
                    this.Control.Text = null;
                    this.Control.Hint = customTimePicker.Placeholder;
                    this.Control.SetHintTextColor(customTimePicker.PlaceholderColor.ToAndroid());
                }
            }
        }
    }
}