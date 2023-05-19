using System;
using System.Collections;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls.Material3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class MaterialPicker : BaseMaterialFieldControl
    {
        #region Constructors

        public MaterialPicker()
        {
            pckOptions = new Plugin.MaterialDesignControls.Material3.Implementations.CustomPicker()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            pckOptions.SetValue(Grid.ColumnProperty, 1);
            pckOptions.SetValue(Grid.RowProperty, 1);
            CustomContent = pckOptions;

            this.pckOptions.Focused += HandleFocusChange;
            this.pckOptions.Unfocused += HandleFocusChange;
            this.pckOptions.SelectedIndexChanged += PckOptions_SelectedIndexChanged;

            TapGestureRecognizer frameTapGestureRecognizer = new TapGestureRecognizer();
            frameTapGestureRecognizer.Tapped += (s, e) =>
            {
                if (pckOptions.IsControlEnabled())
                {
                    this.pckOptions.Focus();
                }
            };
            this.FrameContainer.GestureRecognizers.Add(frameTapGestureRecognizer);
        }

        #endregion Constructors

        #region Attributes

        private Plugin.MaterialDesignControls.Material3.Implementations.CustomPicker pckOptions;

        #endregion Attributes

        #region Events

        public event EventHandler SelectedIndexChanged;

        public new event EventHandler<FocusEventArgs> Focused;

        public new event EventHandler<FocusEventArgs> Unfocused;

        #endregion Events

        #region Properties

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(MaterialPicker), defaultValue: null, propertyChanged: OnItemsSourceChanged);

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(nameof(SelectedItem), typeof(string), typeof(MaterialPicker), defaultValue: null, propertyChanged: OnSelectedItemChanged, defaultBindingMode: BindingMode.TwoWay);

        public string SelectedItem
        {
            get { return (string)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly BindableProperty MultilineEnabledProperty =
            BindableProperty.Create(nameof(MultilineEnabled), typeof(bool), typeof(MaterialPicker), defaultValue: false);

        public bool MultilineEnabled
        {
            get { return (bool)GetValue(MultilineEnabledProperty); }
            set { SetValue(MultilineEnabledProperty, value); }
        }

        public static readonly BindableProperty PickerRowHeightProperty =
            BindableProperty.Create(nameof(PickerRowHeight), typeof(int), typeof(MaterialPicker), defaultValue: 50);

        public int PickerRowHeight
        {
            get { return (int)GetValue(PickerRowHeightProperty); }
            set { SetValue(PickerRowHeightProperty, value); }
        }

        public static readonly BindableProperty SelectedIndexProperty =
            BindableProperty.Create(nameof(SelectedIndex), typeof(int), typeof(MaterialPicker), defaultValue: 0);

        public int SelectedIndex
        {
            get
            {
                if (this.ItemsSource != null)
                {
                    var index = 0;
                    foreach (var item in this.ItemsSource)
                    {
                        if (index.Equals(this.pckOptions.SelectedIndex))
                        {
                            return index;
                        }
                        index++;
                    }
                }

                return -1;
            }
        }
        #endregion Properties

        #region Methods

        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialPicker)bindable;
            control.pckOptions.SelectedItem = (string)newValue;
            control.InternalUpdateSelectedIndex();
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialPicker)bindable;
            control.pckOptions.Items.Clear();
            if (!Equals(newValue, null) && newValue is IEnumerable)
            {
                foreach (var item in (IEnumerable)newValue)
                {
                    control.pckOptions.Items.Add(item.ToString());
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
                    if (item != null && item.Equals(this.SelectedItem))
                    {
                        selectedIndex = index;
                        break;
                    }
                    index++;
                }
            }
            this.pckOptions.SelectedIndex = selectedIndex;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            UpdateLayout(propertyName);

            switch (propertyName)
            {
                case nameof(base.TranslationX):
                    base.OnPropertyChanged(propertyName);
                    break;
                case nameof(this.MultilineEnabled):
                    this.pckOptions.MultilineEnabled = this.MultilineEnabled;
                    break;
                case nameof(this.PickerRowHeight):
                    this.pckOptions.PickerRowHeight = this.PickerRowHeight;
                    break;
                case nameof(ItemsSource):
                    if (ItemsSource != null && ItemsSource is INotifyCollectionChanged collection)
                    {
                        collection.CollectionChanged -= Collection_CollectionChanged;
                        collection.CollectionChanged += Collection_CollectionChanged;
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

        private void PckOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ItemsSource != null)
            {
                var index = 0;
                foreach (var item in this.ItemsSource)
                {
                    if (index.Equals(this.pckOptions.SelectedIndex))
                    {
                        this.SelectedItem = item.ToString();
                        if (this.SelectedIndexChanged != null)
                        {
                            this.SelectedIndexChanged.Invoke(this, e);
                        }
                        break;
                    }
                    index++;
                }
            }
        }

        public void ClearSelectedItem()
        {
            SelectedItem = null;
            pckOptions.SelectedIndex = -1;
            Task.Run(Animate).ConfigureAwait(false);
        }

        private void Collection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (this is MaterialPicker control)
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (var item in e.NewItems)
                    {
                        control.pckOptions.Items.Add(item.ToString());
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
        #endregion Methods
    }
}
