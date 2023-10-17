using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Plugin.MaterialDesignControls.Styles;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Plugin.MaterialDesignControls.Material3
{
    public enum MaterialSegmentedType
    {
        Outlined, Filled
    }

    public class MaterialSegmented : ContentView
    {
        #region Attributes

        private bool initialized = false;

        private Frame _mainFrame;

        private Grid _grid;

        Dictionary<string, ContainerForObjects> containersWithItems = new Dictionary<string, ContainerForObjects>();

        #endregion Attributes

        #region Constructors

        public MaterialSegmented()
        {
            if (!initialized)
            {
                initialized = true;
                Initialize();
            }
        }

        #endregion Constructors

        #region Events

        public event EventHandler IsSelectedChanged;

        #endregion Events

        #region Properties

        public static readonly BindableProperty TypeProperty =
            BindableProperty.Create(nameof(Type), typeof(MaterialSegmentedType), typeof(MaterialSegmented), defaultValue: MaterialSegmentedType.Outlined, propertyChanged: OnTypeChanged);

        public MaterialSegmentedType Type
        {
            get { return (MaterialSegmentedType)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialSegmented), defaultValue: MaterialColor.PrimaryContainer);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty DisabledBackgroundColorProperty =
            BindableProperty.Create(nameof(DisabledBackgroundColor), typeof(Color), typeof(MaterialSegmented), defaultValue: MaterialColor.DisableContainer);

        public Color DisabledBackgroundColor
        {
            get { return (Color)GetValue(DisabledBackgroundColorProperty); }
            set { SetValue(DisabledBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty SelectedColorProperty =
            BindableProperty.Create(nameof(SelectedColor), typeof(Color), typeof(MaterialSegmented), defaultValue: MaterialColor.Primary);

        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        public static readonly BindableProperty DisabledSelectedColorProperty =
            BindableProperty.Create(nameof(DisabledSelectedColor), typeof(Color), typeof(MaterialSegmented), defaultValue: MaterialColor.Disable);

        public Color DisabledSelectedColor
        {
            get { return (Color)GetValue(DisabledSelectedColorProperty); }
            set { SetValue(DisabledSelectedColorProperty, value); }
        }

        public static readonly BindableProperty UnselectedColorProperty =
            BindableProperty.Create(nameof(UnselectedColor), typeof(Color), typeof(MaterialSegmented), defaultValue: MaterialColor.PrimaryContainer);

        public Color UnselectedColor
        {
            get { return (Color)GetValue(UnselectedColorProperty); }
            set { SetValue(UnselectedColorProperty, value); }
        }

        public static readonly BindableProperty DisabledUnselectedColorProperty =
            BindableProperty.Create(nameof(DisabledUnselectedColor), typeof(Color), typeof(MaterialSegmented), defaultValue: MaterialColor.OnPrimary);

        public Color DisabledUnselectedColor
        {
            get { return (Color)GetValue(DisabledUnselectedColorProperty); }
            set { SetValue(DisabledUnselectedColorProperty, value); }
        }


        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<MaterialSegmentedItem>), typeof(MaterialSegmented), defaultValue: null, defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnItemsSourceChanged);

        public IEnumerable<MaterialSegmentedItem> ItemsSource
        {
            get { return (IEnumerable<MaterialSegmentedItem>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public IEnumerable<MaterialSegmentedItem> SelectedItems
        {
            get { return ItemsSource != null ? ItemsSource.Where(x => x.IsSelected) : Array.Empty<MaterialSegmentedItem>(); }
        }

        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(nameof(SelectedItem), typeof(MaterialSegmentedItem), typeof(MaterialSegmented), defaultValue: null, BindingMode.TwoWay, propertyChanged: OnSelectedItemChanged);

        public MaterialSegmentedItem SelectedItem
        {
            get { return (MaterialSegmentedItem)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(MaterialSegmented), defaultValue: 16.0f);

        public float CornerRadius
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly new BindableProperty HeightRequestProperty =
            BindableProperty.Create(nameof(HeightRequest), typeof(double), typeof(MaterialSegmented), defaultValue: 42.0);

        public new double HeightRequest
        {
            get { return (double)GetValue(HeightRequestProperty); }
            set { SetValue(HeightRequestProperty, value); }
        }

        public static readonly BindableProperty SegmentMarginProperty =
            BindableProperty.Create(nameof(SegmentMargin), typeof(int), typeof(MaterialSegmented), defaultValue: 0);

        public int SegmentMargin
        {
            get { return (int)GetValue(SegmentMarginProperty); }
            set { SetValue(SegmentMarginProperty, value); }
        }

        public static readonly BindableProperty SelectedTextColorProperty =
            BindableProperty.Create(nameof(SelectedTextColor), typeof(Color), typeof(MaterialSegmented), defaultValue: MaterialColor.OnPrimary);

        public Color SelectedTextColor
        {
            get { return (Color)GetValue(SelectedTextColorProperty); }
            set { SetValue(SelectedTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledSelectedTextColorProperty =
            BindableProperty.Create(nameof(DisabledSelectedTextColor), typeof(Color), typeof(MaterialSegmented), defaultValue: MaterialColor.OnPrimary);

        public Color DisabledSelectedTextColor
        {
            get { return (Color)GetValue(DisabledSelectedTextColorProperty); }
            set { SetValue(DisabledSelectedTextColorProperty, value); }
        }

        public static readonly BindableProperty UnselectedTextColorProperty =
            BindableProperty.Create(nameof(UnselectedTextColor), typeof(Color), typeof(MaterialSegmented), defaultValue: MaterialColor.Primary);

        public Color UnselectedTextColor
        {
            get { return (Color)GetValue(UnselectedTextColorProperty); }
            set { SetValue(UnselectedTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledUnselectedTextColorProperty =
            BindableProperty.Create(nameof(DisabledUnselectedTextColor), typeof(Color), typeof(MaterialSegmented), defaultValue: MaterialColor.Disable);

        public Color DisabledUnselectedTextColor
        {
            get { return (Color)GetValue(DisabledUnselectedTextColorProperty); }
            set { SetValue(DisabledUnselectedTextColorProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MaterialSegmented), defaultValue: 14.0);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(MaterialSegmented), defaultValue: MaterialFontFamily.Default);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public static readonly BindableProperty DisabledBorderColorProperty =
            BindableProperty.Create(nameof(DisabledBorderColor), typeof(Color), typeof(MaterialSegmented), defaultValue: MaterialColor.Disable);

        public Color DisabledBorderColor
        {
            get { return (Color)GetValue(DisabledBorderColorProperty); }
            set { SetValue(DisabledBorderColorProperty, value); }
        }

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(MaterialSegmented));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(MaterialSegmented), defaultValue: null);

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty =
                BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(MaterialSegmented), defaultValue: MaterialColor.Primary);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty AllowMultiselectProperty =
            BindableProperty.Create(nameof(AllowMultiselect), typeof(bool), typeof(MaterialSegmented), defaultValue: false);

        public bool AllowMultiselect
        {
            get { return (bool)GetValue(AllowMultiselectProperty); }
            set { SetValue(AllowMultiselectProperty, value); }
        }

        #endregion Properties

        #region Methods

        private void Initialize()
        {
            _mainFrame = new Frame()
            {
                CornerRadius = this.CornerRadius,
                HeightRequest = this.HeightRequest,
                MinimumHeightRequest = this.HeightRequest,
                HasShadow = false,
                Padding = new Thickness(0)
            };

            _grid = new Grid()
            {
                ColumnSpacing = 0,
                Padding = new Thickness(0)
            };

            _mainFrame.Content = _grid;
            this.Content = _mainFrame;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!this.initialized)
            {
                this.initialized = true;
                Initialize();
            }

            switch (propertyName)
            {
                case nameof(CornerRadius):
                    if (Type == MaterialSegmentedType.Filled)
                    {
                        _mainFrame.CornerRadius = CornerRadius;
                        foreach (var item in _grid.Children)
                            ((MaterialCard)item).CornerRadius = CornerRadius;
                    }
                    break;

                case nameof(BackgroundColor):
                    SetBackgroundAndBorder();
                    break;

                case nameof(HeightRequest):
                    _mainFrame.HeightRequest = HeightRequest;
                    break;

                default:
                    base.OnPropertyChanged(propertyName);
                    break;
            }            
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialSegmented)bindable;
            control.SetItemSource();
        }

        private void SetBackgroundAndBorder()
        {
            _mainFrame.BackgroundColor = IsEnabled ? BackgroundColor : DisabledBackgroundColor;
            if (Type == MaterialSegmentedType.Filled)
            {
                _mainFrame.BorderColor = _mainFrame.BackgroundColor;
            }
            else
            {
                _mainFrame.BorderColor = IsEnabled ? BorderColor : DisabledBorderColor;
            }
        }

        private void SetItemSource()
        {
            SetBackgroundAndBorder();

            _grid.ColumnDefinitions = new ColumnDefinitionCollection();
            _grid.Children.Clear();
            _grid.ColumnSpacing = 0;
            
            if (ItemsSource != null)
            {
                int itemIdx = 0;
                ItemsSource.ForEach(x => _grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ItemsSource.Count() / 100.0, GridUnitType.Star) }));

                foreach (var item in ItemsSource)
                {
                    var frame = CreateVisualItem(item, itemIdx);
                    frame.SetValue(Grid.ColumnProperty, itemIdx);
                    _grid.Children.Add(frame);

                    itemIdx++;
                }
            }
        }

        private View CreateVisualItem(MaterialSegmentedItem item, int index)
        {
            var frame = new MaterialCard();
            frame.HasShadow = false;
            frame.Padding = new Thickness(12, 0);
            frame.HorizontalOptions = LayoutOptions.Fill;
            frame.VerticalOptions = LayoutOptions.Fill;
            frame.BackgroundColor = IsEnabled ? UnselectedColor : DisabledUnselectedColor;
            frame.BorderColor = frame.BackgroundColor;
            frame.BorderWidth = 1;
            frame.Margin = new Thickness(0);

            if (Type == MaterialSegmentedType.Outlined)
            {
                frame.BorderColor = IsEnabled ? BorderColor : DisabledBorderColor;
                frame.CornerRadius = _mainFrame.CornerRadius;

                if (index == 0)
                {
                    frame.CornerRadius = new CornerRadius(CornerRadius, 0, CornerRadius, 0);
                }
                else if (index == ItemsSource.Count() - 1)
                {
                    frame.CornerRadius = new CornerRadius(0, CornerRadius, 0, CornerRadius);
                }
                else
                {
                    frame.CornerRadius = 0;
                    frame.Margin = new Thickness(-1, 0);
                }
            }
            else
            {
                frame.CornerRadius = (CornerRadius - SegmentMargin) >= 0 ? ((float)CornerRadius - SegmentMargin) : 0;
                frame.Margin = new Thickness(SegmentMargin);
            }

            var label = new MaterialLabel();
            label.Text = item.Text.Trim();
            label.HorizontalOptions = LayoutOptions.Center;
            label.VerticalOptions = LayoutOptions.Center;
            label.FontSize = FontSize;
            label.FontFamily = FontFamily;
            label.TextColor = IsEnabled ? UnselectedTextColor : DisabledUnselectedTextColor;

            containersWithItems.Add(item.Text, new ContainerForObjects()
            {
                Container = frame,
                Label = label
            });

            SetItemContentAndColors(frame, label, item);

            frame.Command = new Command<MaterialSegmentedItem>(it =>
            {
                if (!AllowMultiselect)
                {
                    SelectedItem = it;
                }
                else
                {
                    SelectedItemChanged(it);
                }

                if (CommandProperty != null && Command != null)
                    Command.Execute(CommandParameter);

                IsSelectedChanged?.Invoke(this, null);
            },
            it => IsEnabled && (!it.IsSelected || AllowMultiselect));
            frame.CommandParameter = item;

            return frame;
        }

        private void SetItemContentAndColors(MaterialCard frame, MaterialLabel label, MaterialSegmentedItem item)
        {
            Grid container = null;
            CustomImage selectedIcon = null;

            if ((item.IsSelected && item.SelectedIconIsVisible) || (!item.IsSelected && item.UnselectedIconIsVisible))
            {
                container = new Grid()
                {
                    BackgroundColor = Color.Transparent,
                    ColumnSpacing = 12,
                    HorizontalOptions = LayoutOptions.Center,
                };
                container.ColumnDefinitions.Add(new ColumnDefinition { Width = 18 });
                container.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

                selectedIcon = new CustomImage()
                {
                    WidthRequest = 18,
                    MinimumHeightRequest = 18,
                    MinimumWidthRequest = 18,
                    HeightRequest = 18,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    IsVisible = true
                };

                selectedIcon.SetValue(Grid.ColumnProperty, 0);
            }

            if (item.IsSelected)
            {
                frame.BackgroundColor = IsEnabled ? SelectedColor : DisabledSelectedColor;
                label.TextColor = IsEnabled ? SelectedTextColor : DisabledSelectedTextColor;

                if (item.SelectedIconIsVisible)
                {
                    if (item.CustomSelectedIcon != null)
                    {
                        selectedIcon.SetCustomImage(item.CustomSelectedIcon);
                    }
                    else if (!string.IsNullOrWhiteSpace(item.SelectedIcon))
                    {
                        selectedIcon.SetImage(item.SelectedIcon);
                    }

                    label.SetValue(Grid.ColumnProperty, 1);
                    container.Children.Add(selectedIcon);
                    container.Children.Add(label);

                    frame.Content = container;
                }
                else
                {
                    frame.Content = label;
                }
            }
            else
            {
                frame.BackgroundColor = IsEnabled ? UnselectedColor : DisabledUnselectedColor;
                label.TextColor = IsEnabled ? UnselectedTextColor : DisabledUnselectedTextColor;

                if (item.UnselectedIconIsVisible)
                {
                    if (item.CustomUnselectedIcon != null)
                    {
                        selectedIcon.SetCustomImage(item.CustomUnselectedIcon);
                    }
                    else if (!string.IsNullOrWhiteSpace(item.UnselectedIcon))
                    {
                        selectedIcon.SetImage(item.UnselectedIcon);
                    }

                    label.SetValue(Grid.ColumnProperty, 1);
                    container.Children.Add(selectedIcon);
                    container.Children.Add(label);

                    frame.Content = container;
                }
                else
                {
                    frame.Content = label;
                }
            }
        }

        private static void OnTypeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialSegmented)bindable;
            control.SetItemSource();
        }

        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialSegmented)bindable;
            if (newValue is MaterialSegmentedItem selectedItem && control.ItemsSource.Contains(selectedItem))
            {
                control.SelectedItemChanged(selectedItem);
            }
        }

        private void SelectedItemChanged(MaterialSegmentedItem selectedItem)
        {
            if (!AllowMultiselect)
            {
                var isThereSelection = ItemsSource.Any(x => x.IsSelected);
                if (isThereSelection)
                {
                    foreach (var insideItem in ItemsSource)
                    {
                        if (!insideItem.Equals(selectedItem))
                        {
                            SetItemStatus(insideItem, false);
                        }
                    }
                }
            }

            SetItemStatus(selectedItem, !selectedItem.IsSelected);
        }

        private void SetItemStatus(MaterialSegmentedItem item, bool selected)
        {
            item.IsSelected = selected;
            var container = containersWithItems[item.Text];
            SetItemContentAndColors(container.Container, container.Label, item);
        }

        #endregion Methods


        private class ContainerForObjects
        {
            public MaterialCard Container { get; set; }
            public MaterialLabel Label { get; set; }
        }
    }
}