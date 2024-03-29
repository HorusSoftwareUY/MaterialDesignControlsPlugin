﻿using System;
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

        private bool _initialized = false;

        private MaterialCard _mainContainer;

        private Grid _itemsContainer;

        Dictionary<string, ContainerForObjects> _containersWithItems = new Dictionary<string, ContainerForObjects>();

        #endregion Attributes

        #region Constructors

        public MaterialSegmented()
        {
            Initialize();
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
            BindableProperty.Create(nameof(HeightRequest), typeof(double), typeof(MaterialSegmented), defaultValue: 40.0);

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
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MaterialSegmented), defaultValue: MaterialFontSize.LabelLarge);

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

        public static readonly BindableProperty SelectedFontSizeProperty =
            BindableProperty.Create(nameof(SelectedFontSize), typeof(double), typeof(MaterialSegmented), defaultValue: MaterialFontSize.LabelLarge);

        public double SelectedFontSize
        {
            get { return (double)GetValue(SelectedFontSizeProperty); }
            set { SetValue(SelectedFontSizeProperty, value); }
        }

        public static readonly BindableProperty SelectedFontFamilyProperty =
            BindableProperty.Create(nameof(SelectedFontFamily), typeof(string), typeof(MaterialSegmented), defaultValue: MaterialFontFamily.Default);

        public string SelectedFontFamily
        {
            get { return (string)GetValue(SelectedFontFamilyProperty); }
            set { SetValue(SelectedFontFamilyProperty, value); }
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
            if (!_initialized)
            {
                _itemsContainer = new Grid
                {
                    ColumnSpacing = 0,
                    Padding = 0
                };

                _mainContainer = new MaterialCard
                {
                    Type = MaterialCardType.Custom,
                    CornerRadius = this.CornerRadius,
                    HeightRequest = this.HeightRequest,
                    MinimumHeightRequest = this.HeightRequest,
                    HasShadow = false,
                    Padding = 0,
                    BorderWidth = 1,
                    Content = _itemsContainer
                };

                Content = _mainContainer;
                _initialized = true;
            }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            switch (propertyName)
            {
                case nameof(CornerRadius):
                case nameof(SegmentMargin):
                    _mainContainer.CornerRadius = CornerRadius;
                    _itemsContainer.ColumnSpacing = SegmentMargin;

                    if (Type == MaterialSegmentedType.Filled)
                    {
                        _mainContainer.Padding = SegmentMargin;

                        foreach (var card in _containersWithItems.Values.Select(c => c.Container))
                        {
                            card.CornerRadius = Math.Abs(CornerRadius - SegmentMargin);
                        }
                    }
                    else
                    {
                        var cornerRadius = CornerRadius;
                        if (_containersWithItems.Values.FirstOrDefault() is ContainerForObjects first)
                        {
                            first.Container.CornerRadius = new CornerRadius(cornerRadius, 0, cornerRadius, 0);
                        }
                        if (_containersWithItems.Values.LastOrDefault() is ContainerForObjects last)
                        {
                            last.Container.CornerRadius = new CornerRadius(0, cornerRadius, 0, cornerRadius);
                        }
                    }
                    break;

                case nameof(BackgroundColor):
                case nameof(BorderColor):
                    SetBackgroundAndBorder();
                    break;

                case nameof(HeightRequest):
                    _mainContainer.HeightRequest = HeightRequest;
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
            _mainContainer.BackgroundColor = IsEnabled ? BackgroundColor : DisabledBackgroundColor;
            if (Type == MaterialSegmentedType.Filled)
            {
                _mainContainer.HasBorder = false;
                _mainContainer.Padding = SegmentMargin;
            }
            else
            {
                _mainContainer.HasBorder = true;
                _mainContainer.BorderColor = IsEnabled ? BorderColor : DisabledBorderColor;
            }
        }

        private void SetItemSource()
        {
            SetBackgroundAndBorder();

            _itemsContainer.Children.Clear();
            _itemsContainer.ColumnDefinitions = new ColumnDefinitionCollection();
            _itemsContainer.ColumnSpacing = Type == MaterialSegmentedType.Outlined ? 0 : SegmentMargin;
            
            if (ItemsSource != null)
            {
                int itemIdx = 0;
                ItemsSource.ForEach(x => _itemsContainer.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ItemsSource.Count() / 100.0, GridUnitType.Star) }));

                foreach (var item in ItemsSource)
                {
                    var visualItem = CreateVisualItem(item, itemIdx);
                    visualItem.SetValue(Grid.ColumnProperty, itemIdx);
                    _itemsContainer.Children.Add(visualItem);

                    itemIdx++;
                }
            }
        }

        private View CreateVisualItem(MaterialSegmentedItem item, int index)
        {
            var card = new MaterialCard
            {
                Type = MaterialCardType.Custom,
                Padding = new Thickness(12, 0),
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                BackgroundColor = IsEnabled ? UnselectedColor : DisabledUnselectedColor,
                Margin = new Thickness(0),
                HasBorder = false,
                HasShadow = false,
                BorderWidth = _mainContainer.BorderWidth
            };
            
            if (Type == MaterialSegmentedType.Outlined)
            {
                var cornerRadius = CornerRadius;
                card.HasBorder = true;
                card.BorderColor = IsEnabled ? BorderColor : DisabledBorderColor;

                if (ItemsSource.Count() > 1)
                {
                    if (index == 0)
                    {
                        card.CornerRadius = new CornerRadius(cornerRadius, 0, cornerRadius, 0);
                    }
                    else if (index == ItemsSource.Count() - 1)
                    {
                        card.CornerRadius = new CornerRadius(0, cornerRadius, 0, cornerRadius);
                    }
                    else
                    {
                        card.CornerRadius = 0;
                        card.Margin = new Thickness(-1, 0);
                    }
                }
                else
                {
                    card.CornerRadius = cornerRadius;
                }
            }
            else
            {
                card.CornerRadius = Math.Abs(CornerRadius - SegmentMargin);
            }

            var label = new MaterialLabel
            {
                Text = item.Text.Trim(),
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                FontSize = FontSize,
                FontFamily = FontFamily,
                TextColor = IsEnabled ? UnselectedTextColor : DisabledUnselectedTextColor
            };            

            _containersWithItems.Add(item.Text, new ContainerForObjects()
            {
                Container = card,
                Label = label
            });

            SetItemContentAndColors(card, label, item);

            card.Command = new Command<MaterialSegmentedItem>(it =>
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
            card.CommandParameter = item;

            return card;
        }

        private void SetItemContentAndColors(MaterialCard card, MaterialLabel label, MaterialSegmentedItem item)
        {
            Grid container = null;
            CustomImage selectedIcon = null;

            if ((item.IsSelected && item.SelectedIconIsVisible) || (!item.IsSelected && item.UnselectedIconIsVisible))
            {
                double iconSize = 18; 

                container = new Grid
                {
                    ColumnSpacing = 8,
                    HorizontalOptions = LayoutOptions.Center
                };
                container.ColumnDefinitions.Add(new ColumnDefinition { Width = iconSize });
                container.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

                selectedIcon = new CustomImage
                {
                    WidthRequest = iconSize,
                    MinimumHeightRequest = iconSize,
                    MinimumWidthRequest = iconSize,
                    HeightRequest = iconSize,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    IsVisible = true
                };

                selectedIcon.SetValue(Grid.ColumnProperty, 0);
            }

            if (item.IsSelected)
            {
                card.BackgroundColor = IsEnabled ? SelectedColor : DisabledSelectedColor;
                label.TextColor = IsEnabled ? SelectedTextColor : DisabledSelectedTextColor;
                label.FontSize = SelectedFontSize;
                label.FontFamily = SelectedFontFamily;

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

                    card.Content = container;
                }
                else
                {
                    card.Content = label;
                }
            }
            else
            {
                card.BackgroundColor = IsEnabled ? UnselectedColor : DisabledUnselectedColor;
                label.TextColor = IsEnabled ? UnselectedTextColor : DisabledUnselectedTextColor;
                label.FontSize = FontSize;
                label.FontFamily = FontFamily;

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

                    card.Content = container;
                }
                else
                {
                    card.Content = label;
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
            var container = _containersWithItems[item.Text];
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