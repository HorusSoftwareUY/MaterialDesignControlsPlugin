using System;
using Android.Content;
using Android.Widget;
using Plugin.MaterialDesignControls.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

using Android.App;
using Android.Util;
using Android.Views;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using AColor = Android.Graphics.Color;
using AViews = Android.Views;
using Android.Text;
using Android.Text.Style;
using Plugin.MaterialDesignControls.Android.Utils;
using Android.Graphics.Drawables;

[assembly: ExportRenderer(typeof(DoublePicker), typeof(Plugin.MaterialDesignControls.Android.MaterialDoublePickerRenderer))]

namespace Plugin.MaterialDesignControls.Android
{
    [Obsolete("MaterialDoublePickerRenderer is deprecated, please use MaterialDoublePickerRenderer of Material 3 instead.")]
    public class MaterialDoublePickerRenderer : DoublePickerRenderer
    {
        public static void Init() { }

        public MaterialDoublePickerRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Picker> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                this.Control.Background = new ColorDrawable(AColor.Transparent);
                this.Control.SetPadding(4, 0, 0, 0);

                if (this.Element is DoublePicker doublePicker)
                {
                    this.Control.Gravity = TextAlignmentHelper.ConvertToGravityFlags(doublePicker.HorizontalTextAlignment);

                    if (doublePicker.SelectedItem == null && !string.IsNullOrEmpty(doublePicker.Placeholder))
                    {
                        this.Control.Text = null;
                        this.Control.Hint = doublePicker.Placeholder;
                        this.Control.SetHintTextColor(doublePicker.PlaceholderColor.ToAndroid());
                    }
                }
            }
        }
    }

    [Obsolete("DoublePickerRenderer is deprecated, please use DoublePickerRenderer of Material 3 instead.")]

    public class DoublePickerRenderer : ViewRenderer<Picker, EditText>, IPickerRenderer
    {
        AlertDialog _dialog;
        bool _isDisposed;
        //TextColorSwitcher _textColorSwitcher;
        int _originalHintTextColor;
        //EntryAccessibilityDelegate _pickerAccessibilityDelegate;

        public DoublePickerRenderer(Context context) : base(context)
        {
            AutoPackage = false;
        }

        IElementController ElementController => Element as IElementController;

        protected override void Dispose(bool disposing)
        {
            if (disposing && !_isDisposed)
            {
                _isDisposed = true;
                ((INotifyCollectionChanged)Element.Items).CollectionChanged -= RowsCollectionChanged;

                //_pickerAccessibilityDelegate?.Dispose();
                //_pickerAccessibilityDelegate = null;
            }

            base.Dispose(disposing);
        }

        protected override EditText CreateNativeControl()
        {
            return new PickerEditText(Context);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            if (e.OldElement != null)
                ((INotifyCollectionChanged)e.OldElement.Items).CollectionChanged -= RowsCollectionChanged;

            if (e.NewElement != null)
            {
                ((INotifyCollectionChanged)e.NewElement.Items).CollectionChanged += RowsCollectionChanged;
                if (Control == null)
                {
                    var textField = CreateNativeControl();

                    //textField.SetAccessibilityDelegate(_pickerAccessibilityDelegate = new EntryAccessibilityDelegate(Element));

                    //var useLegacyColorManagement = e.NewElement.UseLegacyColorManagement();
                    //_textColorSwitcher = new TextColorSwitcher(textField.TextColors, useLegacyColorManagement);

                    SetNativeControl(textField);

                    _originalHintTextColor = Control.CurrentHintTextColor;
                }

                UpdateFont();
                UpdatePicker();
                UpdateTextColor();
                UpdateCharacterSpacing();
            }

            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Picker.TitleProperty.PropertyName || e.PropertyName == Picker.TitleColorProperty.PropertyName)
                UpdatePicker();
            else if (e.PropertyName == Picker.SelectedIndexProperty.PropertyName || e.PropertyName == DoublePicker.SelectedIndexesProperty.PropertyName)
                UpdatePicker();
            else if (e.PropertyName == nameof(DoublePicker.Separator))
                UpdatePicker();
            //else if (e.PropertyName == Picker.CharacterSpacingProperty.PropertyName)
            //    UpdateCharacterSpacing();
            else if (e.PropertyName == Picker.TextColorProperty.PropertyName)
                UpdateTextColor();
            else if (e.PropertyName == Picker.FontAttributesProperty.PropertyName || e.PropertyName == Picker.FontFamilyProperty.PropertyName || e.PropertyName == Picker.FontSizeProperty.PropertyName)
                UpdateFont();
        }

        protected override void OnFocusChangeRequested(object sender, VisualElement.FocusRequestArgs e)
        {
            base.OnFocusChangeRequested(sender, e);

            if (e.Focus)
            {
                if (Clickable)
                    CallOnClick();
                else
                    ((IPickerRenderer)this)?.OnClick();
            }
            else if (_dialog != null)
            {
                _dialog.Hide();
                ElementController.SetValueFromRenderer(VisualElement.IsFocusedPropertyKey, false);
                _dialog = null;
            }
        }

        void IPickerRenderer.OnClick()
        {
            DoublePicker model = (DoublePicker)Element;

            if (_dialog != null)
                return;

            var layout = new LinearLayout(Context) { Orientation = Orientation.Horizontal };

            var picker = new NumberPicker(Context);
            if (model.Items != null && model.Items.Any())
            {
                picker.MaxValue = model.Items.Count - 1;
                picker.MinValue = 0;
                picker.SetDisplayedValues(model.Items.ToArray());
                picker.WrapSelectorWheel = false;
                picker.DescendantFocusability = DescendantFocusability.BlockDescendants;
                picker.Value = model.SelectedIndexes[0];
                picker.TextAlignment = AViews.TextAlignment.Center;
            }
            picker.LayoutParameters = new TableLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.MatchParent, 0.5f);
            layout.AddView(picker);

            var picker2 = new NumberPicker(Context);
            if (model.SecondaryItems != null && model.SecondaryItems.Any())
            {
                picker2.MaxValue = model.SecondaryItems.Count - 1;
                picker2.MinValue = 0;
                picker2.SetDisplayedValues(model.SecondaryItems.ToArray());
                picker2.WrapSelectorWheel = false;
                picker2.DescendantFocusability = DescendantFocusability.BlockDescendants;
                picker2.Value = model.SelectedIndexes[1];
                picker2.TextAlignment = AViews.TextAlignment.Center;
            }
            picker2.LayoutParameters = new TableLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.MatchParent, 0.5f);
            layout.AddView(picker2);

            ElementController.SetValueFromRenderer(VisualElement.IsFocusedPropertyKey, true);

            var builder = new AlertDialog.Builder(Context);
            builder.SetView(layout);

            if (!Element.IsSet(Picker.TitleColorProperty))
            {
                builder.SetTitle(model.Title ?? "");
            }
            else
            {
                var title = new SpannableString(model.Title ?? "");
                title.SetSpan(new ForegroundColorSpan(model.TitleColor.ToAndroid()), 0, title.Length(), SpanTypes.ExclusiveExclusive);

                builder.SetTitle(title);
            }

            builder.SetNegativeButton(global::Android.Resource.String.Cancel, (s, a) =>
            {
                ElementController.SetValueFromRenderer(VisualElement.IsFocusedPropertyKey, false);
                _dialog = null;
            });
            builder.SetPositiveButton(global::Android.Resource.String.Ok, (s, a) =>
            {
                var doublePicker = Element as DoublePicker;
                if (doublePicker != null)
                {
                    var selectedIndexes = new int[] { picker.Value, picker2.Value };
                    ElementController.SetValueFromRenderer(DoublePicker.SelectedIndexesProperty, selectedIndexes);
                    model.RaiseSelectedIndexesChanged(selectedIndexes);

                    //ElementController.SetValueFromRenderer(Picker.SelectedIndexProperty, picker.Value);
                    // It is possible for the Content of the Page to be changed on SelectedIndexChanged. 
                    // In this case, the Element & Control will no longer exist.

                
                    string text = null;

                    if (doublePicker.Items.Count > 0 && selectedIndexes[0] >= 0)
                        text = doublePicker.Items[selectedIndexes[0]];

                    if (doublePicker.SecondaryItems.Count > 0 && selectedIndexes[1] >= 0)
                        text = $"{text}{doublePicker.Separator}{doublePicker.SecondaryItems[selectedIndexes[1]]}".Trim();

                    Control.Text = text;

                    ElementController.SetValueFromRenderer(VisualElement.IsFocusedPropertyKey, false);
                }
                _dialog = null;
            });

            _dialog = builder.Create();
            _dialog.DismissEvent += (sender, args) =>
            {
                ElementController?.SetValueFromRenderer(VisualElement.IsFocusedPropertyKey, false);
                _dialog?.Dispose();
                _dialog = null;
            };
            _dialog.Show();
        }

        void RowsCollectionChanged(object sender, EventArgs e)
        {
            UpdatePicker();
        }

        void UpdateCharacterSpacing()
        {
            //if (Forms.IsLollipopOrNewer)
            //{
            //    Control.LetterSpacing = Element.CharacterSpacing.ToEm();
            //}
        }

        void UpdateFont()
        {
            //Control.Typeface = Element.ToTypeface();
            Control.SetTextSize(ComplexUnitType.Sp, (float)Element.FontSize);
        }

        void UpdatePicker()
        {
            Control.Hint = Element.Title;

            if (Element.IsSet(Picker.TitleColorProperty))
                Control.SetHintTextColor(Element.TitleColor.ToAndroid());
            else
                Control.SetHintTextColor(new AColor(_originalHintTextColor));

            string oldText = Control.Text;

            var doublePicker = Element as DoublePicker;

            string text = null;

            if (doublePicker.Items.Count > 0 && doublePicker.SelectedIndexes[0] >= 0)
                text = doublePicker.Items[doublePicker.SelectedIndexes[0]];

            if (doublePicker.SecondaryItems.Count > 0 && doublePicker.SelectedIndexes[1] >= 0)
                text = $"{text}{doublePicker.Separator}{doublePicker.SecondaryItems[doublePicker.SelectedIndexes[1]]}".Trim();

            Control.Text = text;

            if (oldText != Control.Text)
                ((IVisualElementController)Element).NativeSizeChanged();

            //_pickerAccessibilityDelegate.ValueText = Control.Text;
        }

        void UpdateTextColor()
        {
            //_textColorSwitcher?.UpdateTextColor(Control, Element.TextColor);
        }
    }
}
