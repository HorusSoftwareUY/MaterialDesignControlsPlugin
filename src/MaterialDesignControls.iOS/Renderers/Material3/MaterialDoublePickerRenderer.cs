using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using Plugin.MaterialDesignControls.iOS.Utils;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Plugin.MaterialDesignControls.Material3.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

[assembly: ExportRenderer(typeof(DoublePicker), typeof(MaterialDoublePickerRenderer))]

namespace Plugin.MaterialDesignControls.Material3.iOS
{
    public class MaterialDoublePickerRenderer : DoublePickerRenderer<UITextField>
    {
        public static void Init() { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Picker> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                this.Control.BorderStyle = UITextBorderStyle.None;

                if (this.Element is DoublePicker doublePicker)
                {
                    this.Control.TextAlignment = TextAlignmentHelper.Convert(doublePicker.HorizontalTextAlignment);

                    if (doublePicker.SelectedIndexes.Length > 0 && doublePicker.SelectedIndexes[0] < 0 && doublePicker.SelectedIndexes[1] < 0 && !string.IsNullOrEmpty(doublePicker.Placeholder))
                    {
                        this.Control.Text = null;
                        this.Control.AttributedPlaceholder = new NSAttributedString(doublePicker.Placeholder, foregroundColor: doublePicker.PlaceholderColor.ToUIColor());
                    }
                }
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var doublePicker = (DoublePicker)Element;
            if (e.PropertyName == nameof(doublePicker.SelectedIndexes))
            {
                if (doublePicker.SelectedIndexes.Length > 0 && doublePicker.SelectedIndexes[0] < 0 && doublePicker.SelectedIndexes[1] < 0 && !string.IsNullOrEmpty(doublePicker.Placeholder))
                {
                    this.Control.Text = null;
                    this.Control.AttributedPlaceholder = new NSAttributedString(doublePicker.Placeholder, foregroundColor: doublePicker.PlaceholderColor.ToUIColor());
                }
            }
        }

        protected override UITextField CreateNativeControl()
        {
            return new ReadOnlyField { BorderStyle = UITextBorderStyle.RoundedRect };
        }
    }

    internal class ReadOnlyField : NoCaretField
    {
        readonly HashSet<string> enableActions;

        public ReadOnlyField()
        {
            string[] actions = { "copy:", "select:", "selectAll:" };
            enableActions = new HashSet<string>(actions);
        }

        public override bool CanPerform(Selector action, NSObject withSender)
            => enableActions.Contains(action.Name);
    }

    internal class NoCaretField : UITextField
    {
        public NoCaretField() : base(new RectangleF())
        {
            SpellCheckingType = UITextSpellCheckingType.No;
            AutocorrectionType = UITextAutocorrectionType.No;
            AutocapitalizationType = UITextAutocapitalizationType.None;
        }

        public override CGRect GetCaretRectForPosition(UITextPosition position)
        {
            return CGRect.Empty;
        }
    }

    public abstract class DoublePickerRenderer<TControl> : ViewRenderer<Xamarin.Forms.Picker, TControl>
            where TControl : UITextField
    {
        UIPickerView _picker;
        UIColor _defaultTextColor;
        bool _disposed;
        bool _useLegacyColorManagement;

        IElementController ElementController => Element as IElementController;


        protected abstract override TControl CreateNativeControl();
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Picker> e)
        {
            if (e.OldElement != null)
                ((INotifyCollectionChanged)e.OldElement.Items).CollectionChanged -= RowsCollectionChanged;

            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    // disabled cut, delete, and toggle actions because they can throw an unhandled native exception
                    var entry = CreateNativeControl();

                    entry.EditingDidBegin += OnStarted;
                    entry.EditingDidEnd += OnEnded;
                    entry.EditingChanged += OnEditing;

                    _picker = new UIPickerView();

                    var width = UIScreen.MainScreen.Bounds.Width;
                    var toolbar = new UIToolbar(new RectangleF(0, 0, (float)width, 44)) { BarStyle = UIBarStyle.Default, Translucent = true };
                    var spacer = new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace);
                    var doneButton = new UIBarButtonItem(UIBarButtonSystemItem.Done, (o, a) =>
                    {
                        var s = (PickerSource)_picker.Model;

                        var doublePicker = Element as DoublePicker;
                        if (doublePicker != null)
                        {
                            if (s.SelectedIndex == -1 && doublePicker.Items != null && doublePicker.Items.Count > 0)
                                UpdatePickerSelectedIndex(0, 0);

                            if (s.SecondSelectedIndex == -1 && doublePicker.SecondaryItems != null && doublePicker.SecondaryItems.Count > 0)
                                UpdatePickerSelectedIndex(0, 1);
                        }

                        UpdatePickerFromModel(s);
                        entry.ResignFirstResponder();
                        UpdateCharacterSpacing();
                    });

                    toolbar.SetItems(new[] { spacer, doneButton }, false);

                    entry.InputView = _picker;
                    entry.InputAccessoryView = toolbar;

                    entry.InputView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;
                    entry.InputAccessoryView.AutoresizingMask = UIViewAutoresizing.FlexibleHeight;

                    //if (Forms.IsiOS9OrNewer)
                    //{
                    //    entry.InputAssistantItem.LeadingBarButtonGroups = null;
                    //    entry.InputAssistantItem.TrailingBarButtonGroups = null;
                    //}

                    _defaultTextColor = entry.TextColor;

                    //_useLegacyColorManagement = e.NewElement.UseLegacyColorManagement();

                    entry.AccessibilityTraits = UIAccessibilityTrait.Button;

                    SetNativeControl(entry);
                }

                _picker.Model = new PickerSource(this);

                UpdateFont();
                UpdatePicker();
                UpdateTextColor();
                UpdateCharacterSpacing();

                ((INotifyCollectionChanged)e.NewElement.Items).CollectionChanged += RowsCollectionChanged;
            }

            base.OnElementChanged(e);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == Xamarin.Forms.Picker.TitleProperty.PropertyName || e.PropertyName == Xamarin.Forms.Picker.TitleColorProperty.PropertyName)
            {
                UpdatePicker();
                UpdateCharacterSpacing();
            }
            else if (e.PropertyName == Xamarin.Forms.Picker.SelectedIndexProperty.PropertyName || e.PropertyName == DoublePicker.SelectedIndexesProperty.PropertyName)
            {
                UpdatePicker();
                UpdateCharacterSpacing();
            }
            //else if (e.PropertyName == Xamarin.Forms.Picker.CharacterSpacingProperty.PropertyName)
            //    UpdateCharacterSpacing();
            else if (e.PropertyName == Xamarin.Forms.Picker.TextColorProperty.PropertyName || e.PropertyName == Xamarin.Forms.VisualElement.IsEnabledProperty.PropertyName)
                UpdateTextColor();
            else if (e.PropertyName == Xamarin.Forms.Picker.FontAttributesProperty.PropertyName || e.PropertyName == Xamarin.Forms.Picker.FontFamilyProperty.PropertyName ||
                     e.PropertyName == Xamarin.Forms.Picker.FontSizeProperty.PropertyName)
            {
                UpdateFont();
            }
        }

        void OnEditing(object sender, EventArgs eventArgs)
        {
            // Reset the TextField's Text so it appears as if typing with a keyboard does not work.
            //var selectedIndex = Element.SelectedIndex;
            //var items = Element.Items;
            //Control.Text = selectedIndex == -1 || items == null ? "" : items[selectedIndex];
            UpdateControlText();
            // Also clears the undo stack (undo/redo possible on iPads)
            Control.UndoManager.RemoveAllActions();
        }

        void OnEnded(object sender, EventArgs eventArgs)
        {
            var s = (PickerSource)_picker.Model;

            if (s.SelectedIndex != -1 && s.SelectedIndex != _picker.SelectedRowInComponent(0))
            {
                _picker.Select(s.SelectedIndex, 0, false);
            }

            if (s.SecondSelectedIndex != -1 && s.SecondSelectedIndex != _picker.SelectedRowInComponent(1))
            {
                _picker.Select(s.SecondSelectedIndex, 1, false);
            }

            ElementController.SetValueFromRenderer(Xamarin.Forms.VisualElement.IsFocusedPropertyKey, false);
        }

        void OnStarted(object sender, EventArgs eventArgs)
        {
            ElementController.SetValueFromRenderer(Xamarin.Forms.VisualElement.IsFocusedPropertyKey, true);
        }

        void RowsCollectionChanged(object sender, EventArgs e)
        {
            UpdatePicker();
            UpdateCharacterSpacing();
        }

        protected void UpdateCharacterSpacing()
        {
            //var textAttr = Control.AttributedText.AddCharacterSpacing(Control.Text, Element.CharacterSpacing);

            //if (textAttr != null)
            //    Control.AttributedText = textAttr;

            //var placeHolder = Control.AttributedPlaceholder.AddCharacterSpacing(Element.Title, Element.CharacterSpacing);

            //if (placeHolder != null)
            //    UpdateAttributedPlaceholder(placeHolder);
        }

        protected internal virtual void UpdateFont()
        {
            //Control.Font = Element.ToUIFont();
            if (!string.IsNullOrEmpty(Element.FontFamily))
                Control.Font = UIFont.FromName(Element.FontFamily, (nfloat)Element.FontSize);
            else
                Control.Font = Control.Font.WithSize((nfloat)Element.FontSize);
        }

        //readonly Xamarin.Forms.Color _defaultPlaceholderColor = ColorExtensions.SeventyPercentGrey.ToColor();
        protected internal virtual void UpdatePlaceholder()
        {
            //var formatted = (FormattedString)Element.Title;

            //if (formatted == null)
            //    return;

            //var targetColor = Element.TitleColor;

            //if (_useLegacyColorManagement)
            //{
            //    var color = targetColor.IsDefault || !Element.IsEnabled ? _defaultPlaceholderColor : targetColor;
            //    UpdateAttributedPlaceholder(formatted.ToAttributed(Element, color));
            //}
            //else
            //{
            //    // Using VSM color management; take whatever is in Element.PlaceholderColor
            //    var color = targetColor.IsDefault ? _defaultPlaceholderColor : targetColor;
            //    UpdateAttributedPlaceholder(formatted.ToAttributed(Element, color));
            //}

            //UpdateAttributedPlaceholder(Control.AttributedPlaceholder.AddCharacterSpacing(Element.Title, Element.CharacterSpacing));
        }

        protected virtual void UpdateAttributedPlaceholder(NSAttributedString nsAttributedString) =>
            Control.AttributedPlaceholder = nsAttributedString;

        void UpdatePicker()
        {
            var doublePicker = Element as DoublePicker;
            if (doublePicker != null)
            {
                var selectedIndex = doublePicker.SelectedIndexes[0];
                var secondSelectedIndex = doublePicker.SelectedIndexes[1];
                var items = doublePicker.Items;
                var secondItems = doublePicker.SecondaryItems;

                UpdatePlaceholder();

                var oldText = Control.Text;
                //Control.Text = selectedIndex == -1 || items == null || selectedIndex >= items.Count ? "" : items[selectedIndex];
                UpdateControlText();
                UpdatePickerNativeSize(oldText);
                _picker.ReloadAllComponents();
                if (items == null || items.Count == 0 || secondItems == null || secondItems.Count == 0)
                    return;

                UpdatePickerSelectedIndex(selectedIndex, 0);
                UpdatePickerSelectedIndex(secondSelectedIndex, 1);
                UpdateCharacterSpacing();
            }
        }

        void UpdatePickerFromModel(PickerSource s)
        {
            if (Element != null)
            {
                var doublePicker = Element as DoublePicker;
                if (doublePicker != null)
                {
                    var oldText = Control.Text;
                    //Control.Text = s.SelectedItem;
                    UpdateControlText();
                    UpdatePickerNativeSize(oldText);

                    var selectedIndexes = new int[] { s.SelectedIndex, s.SecondSelectedIndex };
                    ElementController.SetValueFromRenderer(DoublePicker.SelectedIndexesProperty, selectedIndexes);

                    doublePicker.RaiseSelectedIndexesChanged(selectedIndexes);

                    //ElementController.SetValueFromRenderer(Xamarin.Forms.Picker.SelectedIndexProperty, s.SelectedIndex);
                }
            }
        }

        void UpdateControlText()
        {
            //Control.Text = selectedIndex == -1 || items == null || selectedIndex >= items.Count ? "" : items[selectedIndex];

            var doublePicker = Element as DoublePicker;
            if (doublePicker != null)
            {
                string text = null;

                if (doublePicker.Items.Count > 0 && doublePicker.SelectedIndexes[0] >= 0)
                    text = doublePicker.Items[doublePicker.SelectedIndexes[0]];

                if (doublePicker.SecondaryItems.Count > 0 && doublePicker.SelectedIndexes[1] >= 0)
                    text = $"{text}{doublePicker.Separator}{doublePicker.SecondaryItems[doublePicker.SelectedIndexes[1]]}".Trim();

                Control.Text = text;
            }
        }

        void UpdatePickerNativeSize(string oldText)
        {
            if (oldText != Control.Text)
                ((IVisualElementController)Element).NativeSizeChanged();
        }

        void UpdatePickerSelectedIndex(int formsIndex, int component)
        {
            var source = (PickerSource)_picker.Model;

            var doublePicker = Element as DoublePicker;
            if (doublePicker != null)
            {
                if (component == 0)
                {
                    source.SelectedIndex = formsIndex;
                    source.SelectedItem = formsIndex >= 0 ? doublePicker.Items[formsIndex] : null;
                }
                else
                {
                    source.SecondSelectedIndex = formsIndex;
                    source.SecondSelectedItem = formsIndex >= 0 ? doublePicker.SecondaryItems[formsIndex] : null;
                }
            }

            _picker.Select(Math.Max(formsIndex, 0), component, true);
        }

        protected internal virtual void UpdateTextColor()
        {
            var textColor = Element.TextColor;

            if (textColor.IsDefault || (!Element.IsEnabled && _useLegacyColorManagement))
                Control.TextColor = _defaultTextColor;
            else
                Control.TextColor = textColor.ToUIColor();

            // HACK This forces the color to update; there's probably a more elegant way to make this happen
            Control.Text = Control.Text;
        }

        protected override void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            _disposed = true;

            if (disposing)
            {
                _defaultTextColor = null;

                if (_picker != null)
                {
                    if (_picker.Model != null)
                    {
                        _picker.Model.Dispose();
                        _picker.Model = null;
                    }

                    _picker.RemoveFromSuperview();
                    _picker.Dispose();
                    _picker = null;
                }

                if (Control != null)
                {
                    Control.EditingDidBegin -= OnStarted;
                    Control.EditingDidEnd -= OnEnded;
                    Control.EditingChanged -= OnEditing;
                }

                if (Element != null)
                    ((INotifyCollectionChanged)Element.Items).CollectionChanged -= RowsCollectionChanged;
            }

            base.Dispose(disposing);
        }

        class PickerSource : UIPickerViewModel
        {
            DoublePickerRenderer<TControl> _renderer;
            bool _disposed;

            public PickerSource(DoublePickerRenderer<TControl> renderer)
            {
                _renderer = renderer;
            }

            public int SelectedIndex { get; internal set; }

            public string SelectedItem { get; internal set; }

            public int SecondSelectedIndex { get; internal set; }

            public string SecondSelectedItem { get; internal set; }

            public override nint GetComponentCount(UIPickerView picker)
            {
                return 2;
            }

            public override nint GetRowsInComponent(UIPickerView pickerView, nint component)
            {
                var doublePicker = _renderer.Element as DoublePicker;

                if (component == 0)
                    return doublePicker.Items != null ? doublePicker.Items.Count : 0;
                else
                    return doublePicker.SecondaryItems != null ? doublePicker.SecondaryItems.Count : 0;
            }

            public override string GetTitle(UIPickerView picker, nint row, nint component)
            {
                var doublePicker = _renderer.Element as DoublePicker;

                if (component == 0)
                    return doublePicker.Items[(int)row];
                else
                    return doublePicker.SecondaryItems[(int)row];
            }

            public override void Selected(UIPickerView picker, nint row, nint component)
            {
                var doublePicker = _renderer.Element as DoublePicker;

                if (component == 0)
                {
                    if (doublePicker.Items.Count == 0)
                    {
                        SelectedItem = null;
                        SelectedIndex = -1;
                    }
                    else
                    {
                        SelectedItem = doublePicker.Items[(int)row];
                        SelectedIndex = (int)row;
                    }
                }
                else
                {
                    if (doublePicker.SecondaryItems.Count == 0)
                    {
                        SecondSelectedItem = null;
                        SecondSelectedIndex = -1;
                    }
                    else
                    {
                        SecondSelectedItem = doublePicker.SecondaryItems[(int)row];
                        SecondSelectedIndex = (int)row;
                    }
                }

                if (_renderer.Element.On<Xamarin.Forms.PlatformConfiguration.iOS>().UpdateMode() == UpdateMode.Immediately)
                    _renderer.UpdatePickerFromModel(this);
            }

            protected override void Dispose(bool disposing)
            {
                if (_disposed)
                    return;

                _disposed = true;

                if (disposing)
                    _renderer = null;

                base.Dispose(disposing);
            }
        }
    }
}