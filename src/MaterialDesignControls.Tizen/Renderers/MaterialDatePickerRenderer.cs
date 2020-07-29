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

[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(MaterialDatePickerRenderer))]

namespace Plugin.MaterialDesignControls.Tizen
{
    public class MaterialDatePickerRenderer : ViewRenderer<DatePicker, NLabel>
    {
        const string DialogTitle = "Choose Date";
        Lazy<IDateTimeDialog> _lazyDialog;
        bool _isDialogOpened;
        bool _isDialogClosed;

        CustomDatePicker CustomDatePickerElement => Element as CustomDatePicker;

        public static void Init() { }

        public MaterialDatePickerRenderer()
        {
            RegisterPropertyHandler(DatePicker.DateProperty, UpdateDate);
            RegisterPropertyHandler(DatePicker.FormatProperty, UpdateDate);
            RegisterPropertyHandler(DatePicker.TextColorProperty, UpdateDate);
            RegisterPropertyHandler(DatePicker.FontAttributesProperty, UpdateFontAttributes);
            RegisterPropertyHandler(DatePicker.FontFamilyProperty, UpdateFontFamily);
            RegisterPropertyHandler(DatePicker.FontSizeProperty, UpdateFontSize);
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

        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            if (Control == null)
            {
                var label = CreateNativeControl();
                label.SetVerticalTextAlignment("elm.text", 0.5);
                label.HorizontalTextAlignment = TextAlignmentHelper.Convert(CustomDatePickerElement.HorizontalTextAlignment);
                SetNativeControl(label);

                _lazyDialog = new Lazy<IDateTimeDialog>(() =>
                {
                    var dialog = CreateDialog();
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
            if (Element.IsEnabled && CustomDatePickerElement.IsFocused && ((!_isDialogOpened & !_isDialogClosed) || (_isDialogOpened & _isDialogClosed)))
            {
                var dialog = _lazyDialog.Value;
                dialog.DateTime = Element.Date;
                dialog.MaximumDateTime = Element.MaximumDate;
                dialog.MinimumDateTime = Element.MinimumDate;
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
            CustomDatePickerElement.Date = dcea.NewDate;
            UpdateDate();
        }

        protected virtual void UpdateDate()
        {
            if (!CustomDatePickerElement.Date.HasValue && !string.IsNullOrEmpty(CustomDatePickerElement.Placeholder))
            {
                Control.Text = CustomDatePickerElement.Placeholder;
                Control.TextColor = CustomDatePickerElement.PlaceholderColor.ToNative();
            }
            else
            {
                Control.Text = Element.Date.ToString(Element.Format);
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
