using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3.Implementations
{
    public class DoublePicker : Picker, IBaseMaterialFieldControl
    {
        public TextAlignment HorizontalTextAlignment { get; set; }

        public string Placeholder { get; set; }

        public Color PlaceholderColor { get; set; }

        public string Separator { get; set; } = " ";

        public static readonly BindableProperty SelectedIndexesProperty =
            BindableProperty.Create(nameof(SelectedIndexes), typeof(int[]), typeof(DoublePicker), defaultValue: new int[] { -1, -1 }, defaultBindingMode: BindingMode.TwoWay);

        public int[] SelectedIndexes
        {
            get { return (int[])GetValue(SelectedIndexesProperty); }
            set { SetValue(SelectedIndexesProperty, value); }
        }

        public static readonly BindableProperty SecondaryItemsProperty =
            BindableProperty.Create(nameof(SecondaryItems), typeof(List<string>), typeof(DoublePicker), defaultValue: Array.Empty<string>().ToList());

        public List<string> SecondaryItems
        {
            get { return (List<string>)GetValue(SecondaryItemsProperty); }
            set { SetValue(SecondaryItemsProperty, value); }
        }

        public event EventHandler<SelectedIndexesEventArgs> SelectedIndexesChanged;

        public void RaiseSelectedIndexesChanged(int[] selectedIndexes)
        {
            if (this.SelectedIndexesChanged != null)
            {
                this.SelectedIndexesChanged.Invoke(this, new SelectedIndexesEventArgs { SelectedIndexes = selectedIndexes });
            }
        }

        public bool IsControlEnabled() => this.IsEnabled;

        public bool IsControlFocused() => this.IsFocused;

        public void SetFontFamily(string fontFamily)
        {
            this.FontFamily = fontFamily;
        }

        public void SetFontSize(double fontSize)
        {
            this.FontSize = fontSize;
        }

        public void SetHorizontalTextAlignment(TextAlignment horizontalTextAlignment)
        {
            this.HorizontalTextAlignment = horizontalTextAlignment;
        }

        public void SetIsEnabled(bool isEnabled)
        {
            this.IsEnabled = isEnabled;
        }

        public void SetPlaceholder(string placeHolder)
        {
            this.Placeholder = placeHolder;
        }

        public void SetPlaceholderColor(Color placeHolderColor)
        {
            this.PlaceholderColor = placeHolderColor;
        }

        public void SetTextColor(Color textColor)
        {
            this.TextColor = textColor;
        }
        public bool ValidateIfAnimate()
        {
            return this.IsEnabled && (this.SelectedIndexes.Length > 1 && SelectedIndexes[0] < 0 && SelectedIndexes[1] < 0);
        }
    }
}
