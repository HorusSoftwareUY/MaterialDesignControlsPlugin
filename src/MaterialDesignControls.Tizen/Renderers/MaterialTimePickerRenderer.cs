using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms.Platform.Tizen.Native;
using Xamarin.Forms.Platform.Tizen.Native.Watch;
using Plugin.MaterialDesignControls.Implementations;
using Plugin.MaterialDesignControls.Tizen;
using Plugin.MaterialDesignControls.Tizen.Utils;
using NLabel = Xamarin.Forms.Platform.Tizen.Native.Label;
using NDateChangedEventArgs = Xamarin.Forms.Platform.Tizen.Native.DateChangedEventArgs;

[assembly: ExportRenderer(typeof(CustomTimePicker), typeof(MaterialTimePickerRenderer))]

namespace Plugin.MaterialDesignControls.Tizen
{
    public class MaterialTimePickerRenderer : ViewRenderer<TimePicker, NLabel>
    {
        const string DialogTitle = "Choose Time";
        static readonly string s_defaultFormat = "h:mm tt";

        Lazy<IDateTimeDialog> _lazyDialog;
        bool _isDialogOpened;
        bool _isDialogClosed;

        CustomTimePicker CustomTimePickerElement => Element as CustomTimePicker;

        public static void Init() { }

        protected TimeSpan Time = DateTime.Now.TimeOfDay;

        public MaterialTimePickerRenderer()
        {
            RegisterPropertyHandler(TimePicker.TimeProperty, UpdateTime);
            RegisterPropertyHandler(TimePicker.FormatProperty, UpdateTime);
            RegisterPropertyHandler(TimePicker.TextColorProperty, UpdateTime);
            RegisterPropertyHandler(TimePicker.FontAttributesProperty, UpdateFontAttributes);
            RegisterPropertyHandler(TimePicker.FontFamilyProperty, UpdateFontFamily);
            RegisterPropertyHandler(TimePicker.FontSizeProperty, UpdateFontSize);
        }

        protected virtual IDateTimeDialog CreateDialog()
        {
            if (Device.Idiom == TargetIdiom.Watch)
            {
                return new WatchDateTimePickerDialog(Forms.NativeParent);
            }
            else
            {
                return new DateTimePickerDialog(Forms.NativeParent);
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            if (Control == null)
            {
                var label = CreateNativeControl();
                label.SetVerticalTextAlignment("elm.text", 0.5);
                label.HorizontalTextAlignment = TextAlignmentHelper.Convert(CustomTimePickerElement.HorizontalTextAlignment);
                SetNativeControl(label);

                _lazyDialog = new Lazy<IDateTimeDialog>(() =>
                {
                    var dialog = CreateDialog();
                    dialog.Mode = DateTimePickerMode.Time;
                    dialog.Title = DialogTitle;
                    dialog.DateTimeChanged += OnDateTimeChanged;
                    dialog.PickerOpened += OnPickerOpened;
                    dialog.PickerClosed += OnPickerClosed;
                    return dialog;
                });
            }
            base.OnElementChanged(e);
        }

        protected virtual NLabel CreateNativeControl()
        {
            var control = new NLabel(Forms.NativeParent);
            control.AllowFocus(true);
            return control;
        }

        protected override void OnFocused(object sender, EventArgs e)
        {
            base.OnFocused(sender, e);
            if (Element.IsEnabled && ((!_isDialogOpened & !_isDialogClosed) || (_isDialogOpened & _isDialogClosed)))
            {
                var dialog = _lazyDialog.Value;
                dialog.DateTime -= dialog.DateTime.TimeOfDay;
                dialog.DateTime += Element.Time;

                // You need to call Show() after ui thread occupation because of EFL problem.
                // Otherwise, the content of the popup will not receive focus.
                Device.BeginInvokeOnMainThread(() => dialog.Show());
            }
        }

        protected override void OnUnfocused(object sender, EventArgs e)
        {
            base.OnUnfocused(sender, e);
            if (_isDialogOpened && _isDialogClosed)
            {
                _isDialogClosed = false;
                _isDialogOpened = false;
            }
        }

        protected override Size MinimumSize()
        {
            if (Control is IMeasurable im)
            {
                return im.Measure(Control.MinimumWidth, Control.MinimumHeight).ToDP();
            }
            else
            {
                return base.MinimumSize();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_lazyDialog.IsValueCreated)
                {
                    _lazyDialog.Value.DateTimeChanged -= OnDateTimeChanged;
                    _lazyDialog.Value.PickerOpened -= OnPickerOpened;
                    _lazyDialog.Value.PickerClosed -= OnPickerClosed;
                    _lazyDialog.Value.Unrealize();
                }
            }
            base.Dispose(disposing);
        }

        protected virtual void OnDateTimeChanged(object sender, NDateChangedEventArgs dcea)
        {
            Element.SetValueFromRenderer(TimePicker.TimeProperty, dcea.NewDate.TimeOfDay);
            UpdateTime();
        }

        protected virtual void UpdateTime()
        {
            if (!CustomTimePickerElement.Time.HasValue && !string.IsNullOrEmpty(CustomTimePickerElement.Placeholder))
            {
                Control.Text = CustomTimePickerElement.Placeholder;
                Control.TextColor = CustomTimePickerElement.PlaceholderColor.ToNative();
            }
            else
            {
                Time = Element.Time;
                var format = s_defaultFormat;
                if (!string.IsNullOrEmpty(CustomTimePickerElement.Format) && CustomTimePickerElement.Format != "t")
                    format = CustomTimePickerElement.Format;

                Control.Text = new DateTime(Time.Ticks).ToString(format);
                Control.TextColor = Element.TextColor.ToNative();
            }
        }

        protected virtual void OnPickerOpened(object sender, EventArgs args)
        {
            _isDialogOpened = true;
            Control.SetFocus(true);
        }

        protected virtual void OnPickerClosed(object sender, EventArgs args)
        {
            _isDialogClosed = true;
            Control.SetFocus(false);
        }

        void UpdateFontSize()
        {
            Control.FontSize = Element.FontSize;
        }

        void UpdateFontFamily()
        {
            Control.FontFamily = Element.FontFamily;
        }

        void UpdateFontAttributes()
        {
            Control.FontAttributes = Element.FontAttributes;
        }
    }
}
