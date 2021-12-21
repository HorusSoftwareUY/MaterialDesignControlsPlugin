using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls
{
    public partial class MaterialSegmented : ContentView
    {
        public MaterialSegmented()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<string>), typeof(MaterialSegmented), defaultValue: null, propertyChanged: OnItemsSourceChanged);

        public IEnumerable<string> ItemsSource
        {
            get { return (IEnumerable<string>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialSegmented)bindable;
            control.grid.Children.Clear();
            if (!Equals(newValue, null) && newValue is IEnumerable)
            {
                //foreach (var item in (IEnumerable)newValue)
                //{
                //    var frame = new CustomFrame();

                //    if (control.ChipsHeightRequest != (double)ChipsHeightRequestProperty.DefaultValue)
                //        materialChips.HeightRequest = control.ChipsHeightRequest;

                //    if (control.IsMultipleSelection)
                //    {
                //        if (control.SelectedItems != null && control.SelectedItems.Any())
                //            materialChips.IsSelected = control.SelectedItems.Contains(materialChips.Text);
                //    }
                //    else
                //    {
                //        if (control.SelectedItem != null)
                //            materialChips.IsSelected = materialChips.Text.Equals(control.SelectedItem);
                //    }

                //    materialChips.Command = new Command(() => SelectionCommand(control, materialChips));

                //    control.flexContainer.Children.Add(materialChips);

                //    if (control.ChipsFlexLayoutPercentageBasis > 0 && control.ChipsFlexLayoutPercentageBasis <= 1)
                //        FlexLayout.SetBasis(materialChips, new FlexBasis((float)control.ChipsFlexLayoutPercentageBasis, true));
                //}
            }
        }
    }
}
