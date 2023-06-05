using System;
using System.Collections;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls.Material3
{
    public class MaterialDoublePicker : BaseMaterialFieldControl
    {
        #region Constructors

        public MaterialDoublePicker()
        {
            pckOptions = new Plugin.MaterialDesignControls.Material3.Implementations.DoublePicker()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            pckOptions.SetValue(Grid.ColumnProperty, 1);
            pckOptions.SetValue(Grid.RowProperty, 1);
            CustomContent = pckOptions;

            pckOptions.Focused += HandleFocusChange;
            pckOptions.Unfocused += HandleFocusChange;
            pckOptions.SelectedIndexesChanged += PckOptions_SelectedIndexesChanged;

            TapGestureRecognizer frameTapGestureRecognizer = new TapGestureRecognizer();
            frameTapGestureRecognizer.Tapped += (s, e) =>
            {
                if (pckOptions.IsControlEnabled())
                    this.pckOptions.Focus();
            };
            this.Label.GestureRecognizers.Add(frameTapGestureRecognizer);
        }

        #endregion Constructors

        #region Attributes

        private Plugin.MaterialDesignControls.Material3.Implementations.DoublePicker pckOptions;

        #endregion Attributes

        #region Events

        public event EventHandler<SelectedIndexesEventArgs> SelectedIndexesChanged;

        #endregion Events

        #region Properties
        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(MaterialDoublePicker), defaultValue: null, propertyChanged: OnItemsSourceChanged);

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty SecondaryItemsSourceProperty =
            BindableProperty.Create(nameof(SecondaryItemsSource), typeof(IEnumerable), typeof(MaterialDoublePicker), defaultValue: null, propertyChanged: OnSecondaryItemsSourceChanged);

        public IEnumerable SecondaryItemsSource
        {
            get { return (IEnumerable)GetValue(SecondaryItemsSourceProperty); }
            set { SetValue(SecondaryItemsSourceProperty, value); }
        }

        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(nameof(SelectedItem), typeof(object), typeof(MaterialDoublePicker), defaultValue: null, propertyChanged: OnSelectedItemChanged, defaultBindingMode: BindingMode.TwoWay);

        public object SelectedItem
        {
            get { return GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly BindableProperty SecondarySelectedItemProperty =
            BindableProperty.Create(nameof(SecondarySelectedItem), typeof(object), typeof(MaterialDoublePicker), defaultValue: null, propertyChanged: OnSecondarySelectedItemChanged, defaultBindingMode: BindingMode.TwoWay);

        public object SecondarySelectedItem
        {
            get { return GetValue(SecondarySelectedItemProperty); }
            set { SetValue(SecondarySelectedItemProperty, value); }
        }

        public static readonly BindableProperty SeparatorProperty =
            BindableProperty.Create(nameof(Separator), typeof(string), typeof(MaterialDoublePicker), defaultValue: " ");

        public string Separator
        {
            get { return (string)GetValue(SeparatorProperty); }
            set { SetValue(SeparatorProperty, value); }
        }

        public int SelectedIndex
        {
            get
            {
                if (this.ItemsSource != null)
                {
                    var index = 0;
                    foreach (var item in this.ItemsSource)
                    {
                        if (index.Equals(this.pckOptions.SelectedIndexes[0]))
                        {
                            return index;
                        }
                        index++;
                    }
                }

                return -1;
            }
        }

        public int SecondarySelectedIndex
        {
            get
            {
                if (this.SecondaryItemsSource != null)
                {
                    var index = 0;
                    foreach (var item in this.SecondaryItemsSource)
                    {
                        if (index.Equals(this.pckOptions.SelectedIndexes[1]))
                        {
                            return index;
                        }
                        index++;
                    }
                }

                return -1;
            }
        }

        public static readonly BindableProperty PropertyPathProperty =
            BindableProperty.Create(nameof(PropertyPath), typeof(string), typeof(MaterialDoublePicker), defaultValue: null);

        public string PropertyPath
        {
            get { return (string)GetValue(PropertyPathProperty); }
            set { SetValue(PropertyPathProperty, value); }
        }

        public static readonly BindableProperty SecondaryPropertyPathProperty =
            BindableProperty.Create(nameof(SecondaryPropertyPath), typeof(string), typeof(MaterialDoublePicker), defaultValue: null);

        public string SecondaryPropertyPath
        {
            get { return (string)GetValue(SecondaryPropertyPathProperty); }
            set { SetValue(SecondaryPropertyPathProperty, value); }
        }

        #endregion Properties

        #region Events

        public new event EventHandler<FocusEventArgs> Focused;

        public new event EventHandler<FocusEventArgs> Unfocused;

        #endregion Events

        #region Methods

        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialDoublePicker)bindable;
            control.InternalUpdateSelectedIndex();
        }

        private static void OnSecondarySelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialDoublePicker)bindable;
            control.InternalUpdateSelectedIndex();
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialDoublePicker)bindable;
            control.pckOptions.Items.Clear();
            if (!Equals(newValue, null) && newValue is IEnumerable)
            {
                foreach (var item in (IEnumerable)newValue)
                {
                    var newItem = string.IsNullOrWhiteSpace(control.PropertyPath) ? item.ToString() : GetPropertyValue(item, control.PropertyPath);
                    control.pckOptions.Items.Add(newItem);
                }
            }
            control.InternalUpdateSelectedIndex();
        }

        private static void OnSecondaryItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialDoublePicker)bindable;
            control.pckOptions.SecondaryItems.Clear();
            if (!Equals(newValue, null) && newValue is IEnumerable)
            {
                foreach (var item in (IEnumerable)newValue)
                {
                    var newItem = string.IsNullOrWhiteSpace(control.SecondaryPropertyPath) ? item.ToString() : GetPropertyValue(item, control.SecondaryPropertyPath);
                    control.pckOptions.SecondaryItems.Add(newItem);
                }
            }
            control.InternalUpdateSelectedIndex();
        }

        private void InternalUpdateSelectedIndex()
        {
            var selectedIndex = -1;
            if (this.ItemsSource != null)
            {
                var index = 0;
                foreach (var item in this.ItemsSource)
                {
                    if (item != null && this.SelectedItem != null && string.IsNullOrWhiteSpace(this.PropertyPath) && item.ToString().Equals(this.SelectedItem.ToString()))
                    {
                        selectedIndex = index;
                        break;
                    }
                    else if (item != null && this.SelectedItem != null && !string.IsNullOrWhiteSpace(this.PropertyPath))
                    {
                        var itemValue = GetPropertyValue(item, this.PropertyPath);
                        var selectedItemValue = GetPropertyValue(this.SelectedItem, this.PropertyPath);
                        if (itemValue.Equals(selectedItemValue))
                        {
                            selectedIndex = index;
                            break;
                        }
                    }
                    index++;
                }
            }

            var secondarySelectedIndex = -1;
            if (this.SecondaryItemsSource != null)
            {
                var index = 0;
                foreach (var item in this.SecondaryItemsSource)
                {
                    if (item != null && this.SecondarySelectedItem != null && string.IsNullOrWhiteSpace(this.SecondaryPropertyPath) && item.ToString().Equals(this.SecondarySelectedItem.ToString()))
                    {
                        secondarySelectedIndex = index;
                        break;
                    }
                    else if (item != null && this.SecondarySelectedItem != null && !string.IsNullOrWhiteSpace(this.SecondaryPropertyPath))
                    {
                        var itemValue = GetPropertyValue(item, this.SecondaryPropertyPath);
                        var secondarySelectedItemValue = GetPropertyValue(this.SecondarySelectedItem, this.SecondaryPropertyPath);
                        if (itemValue.Equals(secondarySelectedItemValue))
                        {
                            secondarySelectedIndex = index;
                            break;
                        }
                    }
                    index++;
                }
            }

            this.pckOptions.SelectedIndexes = new int[] { selectedIndex, secondarySelectedIndex };
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {

            UpdateLayout(propertyName);

            switch (propertyName)
            {
                case nameof(base.TranslationX):
                    base.OnPropertyChanged(propertyName);
                    break;
                case nameof(this.Separator):
                    this.pckOptions.Separator = this.Separator;
                    break;
                case nameof(ItemsSource):
                    if (ItemsSource != null && ItemsSource is INotifyCollectionChanged itemsSource)
                    {
                        itemsSource.CollectionChanged -= PckOptions_ItemsSourceChanged;
                        itemsSource.CollectionChanged += PckOptions_ItemsSourceChanged;
                    }
                    break;
                case nameof(SecondaryItemsSource):
                    if (SecondaryItemsSource != null && SecondaryItemsSource is INotifyCollectionChanged secondaryItemsSource)
                    {
                        secondaryItemsSource.CollectionChanged -= PckOptions_SecondaryItemsSourceChanged;
                        secondaryItemsSource.CollectionChanged += PckOptions_SecondaryItemsSourceChanged;
                    }
                    break;
            }
        }

        public new bool Focus()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                pckOptions.Focus();
            });
            return true;
        }

        public new bool Unfocus()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                pckOptions.Unfocus();
            });
            return true;
        }

        private async void HandleFocusChange(object sender, FocusEventArgs e)
        {
            await SetFocusChange();

            if (pckOptions.IsControlFocused())
            {
                Focused?.Invoke(this, e);
            }
            else
            {
                Unfocused?.Invoke(this, e);
            }
        }

        private void PckOptions_SelectedIndexesChanged(object sender, SelectedIndexesEventArgs e)
        {
            if (this.ItemsSource != null)
            {
                var index = 0;
                foreach (var item in this.ItemsSource)
                {
                    if (index.Equals(e.SelectedIndexes[0]))
                    {
                        this.SelectedItem = item;
                        break;
                    }
                    index++;
                }
            }

            if (this.SecondaryItemsSource != null)
            {
                var index = 0;
                foreach (var item in this.SecondaryItemsSource)
                {
                    if (index.Equals(e.SelectedIndexes[1]))
                    {
                        this.SecondarySelectedItem = item;
                        break;
                    }
                    index++;
                }
            }

            if (this.SelectedIndexesChanged != null)
            {
                this.SelectedIndexesChanged.Invoke(this, e);
            }
        }

        public void ClearSelectedItem()
        {
            SelectedItem = null;
            pckOptions.SelectedItem = null;
            SecondarySelectedItem = null;
            pckOptions.SelectedIndexes = new int[] { -1, -1 };
            Task.Run(AnimatePlaceholderAction).ConfigureAwait(false);
        }

        private void PckOptions_ItemsSourceChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (this is MaterialDoublePicker control)
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (var item in e.NewItems)
                    {
                        var newItem = string.IsNullOrWhiteSpace(control.PropertyPath) ? item.ToString() : GetPropertyValue(item, control.PropertyPath);
                        control.pckOptions.Items.Add(newItem);
                    }
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    if (control.pckOptions.Items.Count > 0)
                    {
                        control.pckOptions.Items.RemoveAt(e.OldStartingIndex);
                    }
                }

                control.InternalUpdateSelectedIndex();
            }
        }

        private void PckOptions_SecondaryItemsSourceChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (this is MaterialDoublePicker control)
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (var item in e.NewItems)
                    {
                        var newItem = string.IsNullOrWhiteSpace(control.SecondaryPropertyPath) ? item.ToString() : GetPropertyValue(item, control.SecondaryPropertyPath);
                        control.pckOptions.SecondaryItems.Add(newItem);
                    }
                }
                else if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    if (control.pckOptions.SecondaryItems.Count > 0)
                    {
                        control.pckOptions.SecondaryItems.RemoveAt(e.OldStartingIndex);
                    }
                }

                control.InternalUpdateSelectedIndex();
            }
        }


        #endregion Methods
    }

    public class SelectedIndexesEventArgs : EventArgs
    {
        public int[] SelectedIndexes { get; set; }
    }
}
