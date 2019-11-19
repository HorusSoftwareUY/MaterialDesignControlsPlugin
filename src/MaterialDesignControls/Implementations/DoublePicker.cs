using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Implementations
{
    public class DoublePicker : Picker
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
            BindableProperty.Create(nameof(SecondaryItems), typeof(List<string>), typeof(DoublePicker), defaultValue: null);

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

        public DoublePicker()
        {
            this.SecondaryItems = new List<string>();
        }
    }
}
