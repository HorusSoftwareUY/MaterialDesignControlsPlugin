using System;
using Android.Content;
using Android.Graphics.Drawables;
using AndroidGraphics = Android.Graphics;
using Plugin.MaterialDesignControls.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Plugin.MaterialDesignControls.Android.Utils;

[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(Plugin.MaterialDesignControls.Android.MaterialDatePickerRenderer))]

namespace Plugin.MaterialDesignControls.Android
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
                    this.Control.Gravity = TextAlignmentHelper.Convert(customDatePicker.HorizontalTextAlignment);

                    if (!customDatePicker.Date.HasValue && !string.IsNullOrEmpty(customDatePicker.Placeholder))
                    {
                        this.Control.Text = null;
                        this.Control.Hint = customDatePicker.Placeholder;
                        this.Control.SetHintTextColor(customDatePicker.PlaceholderColor.ToAndroid());
                    }
                }
            }
        }
    }
}
