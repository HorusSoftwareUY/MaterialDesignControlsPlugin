using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms.Platform.Tizen.Native;
using Xamarin.Forms.Platform.Tizen.Native.Watch;
using Plugin.MaterialDesignControls.Implementations;
using Plugin.MaterialDesignControls.Tizen;
using Plugin.MaterialDesignControls.Tizen.Utils;
using ElmSharp;
using EBox = ElmSharp.Box;
using XSize = Xamarin.Forms.Size;
using NLabel = Xamarin.Forms.Platform.Tizen.Native.Label;

[assembly: ExportRenderer(typeof(DoublePicker), typeof(MaterialDoublePickerRenderer))]

namespace Plugin.MaterialDesignControls.Tizen
{
	public class MaterialDoublePickerRenderer : ViewRenderer<Picker, NLabel>
	{
		List _list;
		List _secondaryList;
		Dialog _dialog;
		bool _isDialogOpened;
		bool _isDialogClosed;
		bool _isItemSelected;
		bool _isSecondaryItemSelected;
		Dictionary<ListItem, int> _itemToItemNumber = new Dictionary<ListItem, int>();
		Dictionary<ListItem, int> _secondaryItemToItemNumber = new Dictionary<ListItem, int>();

		DoublePicker DoublePickerElement => Element as DoublePicker;

		public static void Init() { }

		public MaterialDoublePickerRenderer()
		{
			RegisterPropertyHandler(Picker.TextColorProperty, UpdateTextColor);
			RegisterPropertyHandler(Picker.FontSizeProperty, UpdateFontSize);
			RegisterPropertyHandler(Picker.FontFamilyProperty, UpdateFontFamily);
			RegisterPropertyHandler(Picker.FontAttributesProperty, UpdateFontAttributes);
			RegisterPropertyHandler(DoublePicker.SelectedIndexesProperty, UpdateSelectedIndex);
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
				label.HorizontalTextAlignment = TextAlignmentHelper.Convert(DoublePickerElement.HorizontalTextAlignment);
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

				_list = new List(_dialog)
				{
					AlignmentX = -1,
					AlignmentY = -1,
					WeightX = .5,
					WeightY = 1
				};

				foreach (var s in Element.Items)
				{
					ListItem item = _list.Append(s);
					_itemToItemNumber[item] = i;
					i++;
				}
				_list.ItemSelected += OnItemSelected;

				i = 0;
				_secondaryList = new List(_dialog)
				{
					AlignmentX = -1,
					AlignmentY = -1,
					WeightX = .5,
					WeightY = 1
				};

				foreach (var s in DoublePickerElement.SecondaryItems)
				{
					ListItem item = _secondaryList.Append(s);
					_secondaryItemToItemNumber[item] = i;
					i++;
				}
				_secondaryList.ItemSelected += OnSecondaryItemSelected;

				var box = new EBox(_dialog)
				{
					AlignmentX = -1,
					AlignmentY = -1,
					WeightX = 1,
					WeightY = 1,
					IsHorizontal = true
				};
				box.Show();
				box.PackEnd(_list);
				box.PackEnd(_secondaryList);

				_dialog.Content = box;

				// You need to call Show() after ui thread occupation because of EFL problem.
				// Otherwise, the content of the popup will not receive focus.
				Device.BeginInvokeOnMainThread(() =>
				{
					_dialog?.Show();
					_list?.Show();
					_secondaryList?.Show();
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

		protected override XSize MinimumSize()
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
				if (!string.IsNullOrEmpty(DoublePickerElement.Placeholder))
				{
					Control.Text = DoublePickerElement.Placeholder;
					Control.TextColor = DoublePickerElement.PlaceholderColor.ToNative();
				}
				else
				{
					Control.Text = "";
				}
			}
			else
			{
				string text = "";
				var selectedIndexes = new int[] { _itemToItemNumber[_list?.SelectedItem], _secondaryItemToItemNumber[_secondaryList?.SelectedItem] };

				if (Element.Items.Count > 0 && selectedIndexes[0] >= 0)
					text = Element.Items[selectedIndexes[0]];

				if (DoublePickerElement.SecondaryItems.Count > 0 && selectedIndexes[1] >= 0)
					text = $"{text}{DoublePickerElement.Separator}{DoublePickerElement.SecondaryItems[selectedIndexes[1]]}".Trim();

				Control.Text = text;
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
			_isItemSelected = true;
			Element.SetValueFromRenderer(Picker.SelectedIndexProperty, _itemToItemNumber[(senderObject as List)?.SelectedItem]);

			if (_isSecondaryItemSelected)
			{
				var selectedIndexes = new int[] { _itemToItemNumber[_list?.SelectedItem], _secondaryItemToItemNumber[_secondaryList?.SelectedItem] };
				Element.SetValueFromRenderer(DoublePicker.SelectedIndexesProperty, selectedIndexes);
				DoublePickerElement.RaiseSelectedIndexesChanged(selectedIndexes);
				_dialog.Dismiss();
			}
		}

		void OnSecondaryItemSelected(object senderObject, EventArgs ev)
		{
			_isSecondaryItemSelected = true;
			if (_isItemSelected)
			{
				var selectedIndexes = new int[] { _itemToItemNumber[_list?.SelectedItem], _secondaryItemToItemNumber[_secondaryList?.SelectedItem] };
				Element.SetValueFromRenderer(DoublePicker.SelectedIndexesProperty, selectedIndexes);
				DoublePickerElement.RaiseSelectedIndexesChanged(selectedIndexes);
				_dialog.Dismiss();
			}
		}

		void OnDialogDismissed(object sender, EventArgs e)
		{
			_isDialogClosed = true;
			_isItemSelected = false;
			_isSecondaryItemSelected = false;
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
			if (null != _secondaryList)
			{
				_secondaryList.Unrealize();
				_secondaryItemToItemNumber.Clear();
				_secondaryList = null;
			}
			if (null != _dialog)
			{
				_dialog.Unrealize();
				_dialog = null;
			}
		}
	}
}
