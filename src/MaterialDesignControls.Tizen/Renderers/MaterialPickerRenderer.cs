using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms.Platform.Tizen.Native;
using Xamarin.Forms.Platform.Tizen.Native.Watch;
using Plugin.MaterialDesignControls.Implementations;
using Plugin.MaterialDesignControls.Tizen;
using Plugin.MaterialDesignControls.Tizen.Utils;
using NLabel = Xamarin.Forms.Platform.Tizen.Native.Label;
using ElmSharp;
using Size = Xamarin.Forms.Size;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(MaterialPickerRenderer))]

namespace Plugin.MaterialDesignControls.Tizen
{
	public class MaterialPickerRenderer : ViewRenderer<Picker, NLabel>
	{
		List _list;
		Dialog _dialog;
		bool _isDialogOpened;
		bool _isDialogClosed;
		Dictionary<ListItem, int> _itemToItemNumber = new Dictionary<ListItem, int>();

		CustomPicker CustomPickerElement => Element as CustomPicker;

		public static void Init() { }

		public MaterialPickerRenderer()
		{
			RegisterPropertyHandler(Picker.SelectedIndexProperty, UpdateSelectedIndex);
			RegisterPropertyHandler(Picker.TextColorProperty, UpdateTextColor);
			RegisterPropertyHandler(Picker.FontSizeProperty, UpdateFontSize);
			RegisterPropertyHandler(Picker.FontFamilyProperty, UpdateFontFamily);
			RegisterPropertyHandler(Picker.FontAttributesProperty, UpdateFontAttributes);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (Control != null)
				{
					CleanView();
				}
			}
			base.Dispose(disposing);
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
		{
			if (Control == null)
			{
				var label = CreateNativeControl();
				label.SetVerticalTextAlignment("elm.text", 0.5);
				label.HorizontalTextAlignment = TextAlignmentHelper.Convert(CustomPickerElement.HorizontalTextAlignment);
				SetNativeControl(label);
			}
			base.OnElementChanged(e);
		}

		protected virtual Dialog CreateDialog()
		{
			if (Device.Idiom == TargetIdiom.Watch)
			{
				return new WatchDialog(Forms.NativeParent, false);
			}
			else
			{
				return new Dialog(Forms.NativeParent);
			}
		}

		protected override void OnFocused(object sender, EventArgs e)
		{
			base.OnFocused(sender, e);
			if (Element.IsEnabled && ((!_isDialogOpened & !_isDialogClosed) || (_isDialogOpened & _isDialogClosed)))
			{
				int i = 0;
				_dialog = CreateDialog();
				_dialog.AlignmentX = -1;
				_dialog.AlignmentY = -1;
				_dialog.Dismissed += OnDialogDismissed;
				_dialog.ShowAnimationFinished += (s1, e1) =>
				{
					_isDialogOpened = true;
					Control.SetFocus(true);
				};
				_dialog.BackButtonPressed += (s2, e2) =>
				{
					_dialog.Dismiss();
				};
				_dialog.Title = Element.Title;
				_dialog.TitleColor = Element.TitleColor.ToNative();

				_list = new List(_dialog);
				foreach (var s in Element.Items)
				{
					ListItem item = _list.Append(s);
					_itemToItemNumber[item] = i;
					i++;
				}
				_list.ItemSelected += OnItemSelected;
				_dialog.Content = _list;

				// You need to call Show() after ui thread occupation because of EFL problem.
				// Otherwise, the content of the popup will not receive focus.
				Device.BeginInvokeOnMainThread(() =>
				{
					_dialog?.Show();
					_list?.Show();
				});
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

		protected virtual NLabel CreateNativeControl()
		{
			var control = new NLabel(Forms.NativeParent);
			control.AllowFocus(true);
			return control;
		}

		protected virtual void UpdateSelectedIndex()
		{
			if ((Element.SelectedIndex == -1 || Element.Items == null))
			{
				if (!string.IsNullOrEmpty(CustomPickerElement.Placeholder))
				{
					Control.Text = CustomPickerElement.Placeholder;
					Control.TextColor = CustomPickerElement.PlaceholderColor.ToNative();
				}
				else
				{
					Control.Text = "";
				}
			}
			else
			{
				Control.Text = Element.Items[Element.SelectedIndex];
				Control.TextColor = Element.TextColor.ToNative();
			}
		}

		protected virtual void UpdateTextColor()
		{
			Control.TextColor = Element.TextColor.ToNative();
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

		void OnItemSelected(object senderObject, EventArgs ev)
		{
			Element.SetValueFromRenderer(Picker.SelectedIndexProperty, _itemToItemNumber[(senderObject as List)?.SelectedItem]);
			_dialog.Dismiss();
		}

		void OnDialogDismissed(object sender, EventArgs e)
		{
			_isDialogClosed = true;
			Control.SetFocus(false);
			CleanView();
		}

		void CleanView()
		{
			if (null != _list)
			{
				_list.Unrealize();
				_itemToItemNumber.Clear();
				_list = null;
			}
			if (null != _dialog)
			{
				_dialog.Unrealize();
				_dialog = null;
			}
		}
	}
}
