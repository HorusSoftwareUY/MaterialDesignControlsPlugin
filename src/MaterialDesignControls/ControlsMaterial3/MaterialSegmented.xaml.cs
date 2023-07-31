using Plugin.MaterialDesignControls.Implementations;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.MaterialDesignControls.Material3.Implementations;
using System.Linq;
using Xamarin.Forms.Internals;
using Plugin.MaterialDesignControls.Objects;
using Plugin.MaterialDesignControls.Styles;

namespace Plugin.MaterialDesignControls.Material3
{
    public enum MaterialSegmentedType
    {
        Outlined, Filled
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialSegmented : ContentView
    {
        #region Attributes

        private bool initialized = false;

        Dictionary<string, ContainerForObjects> containersWithItems = new Dictionary<string, ContainerForObjects>();
        #endregion Attributes

        #region Constructors

        public MaterialSegmented()
        {
            if (!initialized)
            {
                initialized = true;
                InitializeComponent();
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
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialSegmented), defaultValue: DefaultStyles.PrimaryContainerColor);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty DisabledBackgroundColorProperty =
            BindableProperty.Create(nameof(DisabledBackgroundColor), typeof(Color), typeof(MaterialSegmented), defaultValue: DefaultStyles.DisableContainerColor);

        public Color DisabledBackgroundColor
        {
            get { return (Color)GetValue(DisabledBackgroundColorProperty); }
            set { SetValue(DisabledBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty SelectedColorProperty =
            BindableProperty.Create(nameof(SelectedColor), typeof(Color), typeof(MaterialSegmented), defaultValue: DefaultStyles.PrimaryColor);

        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        public static readonly BindableProperty DisabledSelectedColorProperty =
            BindableProperty.Create(nameof(DisabledSelectedColor), typeof(Color), typeof(MaterialSegmented), defaultValue: DefaultStyles.DisableColor);

        public Color DisabledSelectedColor
        {
            get { return (Color)GetValue(DisabledSelectedColorProperty); }
            set { SetValue(DisabledSelectedColorProperty, value); }
        }

        public static readonly BindableProperty UnselectedColorProperty =
            BindableProperty.Create(nameof(UnselectedColor), typeof(Color), typeof(MaterialSegmented), defaultValue: DefaultStyles.PrimaryContainerColor);

        public Color UnselectedColor
        {
            get { return (Color)GetValue(UnselectedColorProperty); }
            set { SetValue(UnselectedColorProperty, value); }
        }

        public static readonly BindableProperty DisabledUnselectedColorProperty =
            BindableProperty.Create(nameof(DisabledUnselectedColor), typeof(Color), typeof(MaterialSegmented), defaultValue: DefaultStyles.PrimaryContainerColor);

        public Color DisabledUnselectedColor
        {
            get { return (Color)GetValue(DisabledUnselectedColorProperty); }
            set { SetValue(DisabledUnselectedColorProperty, value); }
        }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<MaterialSegmentedObject>), typeof(MaterialSegmented), defaultValue: null, defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnItemsSourceChanged);

        public IEnumerable<MaterialSegmentedObject> ItemsSource
        {
            get { return (IEnumerable<MaterialSegmentedObject>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public IEnumerable<MaterialSegmentedObject> SelectedItems
        {
            get { return ItemsSource != null ? ItemsSource.Where(x => x.IsSelected) : Array.Empty<MaterialSegmentedObject>(); }
        }

        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(nameof(SelectedItem), typeof(MaterialSegmentedObject), typeof(MaterialSegmented), defaultValue: null, BindingMode.TwoWay, propertyChanged: OnSelectedItemChanged);

        public MaterialSegmentedObject SelectedItem
        {
            get { return (MaterialSegmentedObject)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(MaterialSegmented), defaultValue: 16.0);

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
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
            BindableProperty.Create(nameof(SegmentMargin), typeof(int), typeof(MaterialSegmented), defaultValue: 2);

        public int SegmentMargin
        {
            get { return (int)GetValue(SegmentMarginProperty); }
            set { SetValue(SegmentMarginProperty, value); }
        }

        public static readonly BindableProperty SelectedTextColorProperty =
            BindableProperty.Create(nameof(SelectedTextColor), typeof(Color), typeof(MaterialSegmented), defaultValue: DefaultStyles.BackgroundColor);

        public Color SelectedTextColor
        {
            get { return (Color)GetValue(SelectedTextColorProperty); }
            set { SetValue(SelectedTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledSelectedTextColorProperty =
            BindableProperty.Create(nameof(DisabledSelectedTextColor), typeof(Color), typeof(MaterialSegmented), defaultValue: DefaultStyles.BackgroundColor);

        public Color DisabledSelectedTextColor
        {
            get { return (Color)GetValue(DisabledSelectedTextColorProperty); }
            set { SetValue(DisabledSelectedTextColorProperty, value); }
        }

        public static readonly BindableProperty UnselectedTextColorProperty =
            BindableProperty.Create(nameof(UnselectedTextColor), typeof(Color), typeof(MaterialSegmented), defaultValue: DefaultStyles.PrimaryColor);

        public Color UnselectedTextColor
        {
            get { return (Color)GetValue(UnselectedTextColorProperty); }
            set { SetValue(UnselectedTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledUnselectedTextColorProperty =
            BindableProperty.Create(nameof(DisabledUnselectedTextColor), typeof(Color), typeof(MaterialSegmented), defaultValue: DefaultStyles.DisableColor);

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
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(MaterialSegmented), defaultValue: null);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public static readonly BindableProperty DisabledBorderColorProperty =
            BindableProperty.Create(nameof(DisabledBorderColor), typeof(Color), typeof(MaterialSegmented), defaultValue: DefaultStyles.DisableColor);

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
                BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(MaterialSegmented), defaultValue: DefaultStyles.PrimaryColor);

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
            mainFrame.CornerRadius = (float)CornerRadius;
            mainFrame.HeightRequest = HeightRequest;
            mainFrame.MinimumHeightRequest = 40;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!this.initialized)
            {
                this.initialized = true;
                this.InitializeComponent();
                Initialize();
            }

            switch (propertyName)
            {
                case nameof(CornerRadius):
                    if (Type == MaterialSegmentedType.Filled)
                    {
                        mainFrame.CornerRadius = (float)CornerRadius;
                        foreach (var item in ((Grid)mainFrame.Content).Children)
                            ((MaterialCard)item).CornerRadius = (float)CornerRadius;
                    }
                    break;
                case nameof(BackgroundColor):
                    if (Type == MaterialSegmentedType.Filled)
                    {
                        mainFrame.BackgroundColor = IsEnabled ? BackgroundColor : DisabledBackgroundColor;
                    }
                    break;
                case nameof(HeightRequest):
                    mainFrame.HeightRequest = HeightRequest;
                    break;
            }
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialSegmented)bindable;
            control.SetItemSource();
        }

        private void SetItemSource()
        {
            grid.ColumnDefinitions = new ColumnDefinitionCollection();
            grid.Children.Clear();

            int column = 0;
            if (ItemsSource != null)
            {
                int itemIdx = 0;
                ItemsSource.ForEach(x => grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ItemsSource.Count() / 100.0, GridUnitType.Star) }));

                foreach (var item in ItemsSource)
                {
                    var frame = new MaterialCard();
                    frame.HasShadow = false;
                    frame.BorderColor = Color.Transparent;
                    frame.Padding = new Thickness(12, 0);
                    frame.HorizontalOptions = LayoutOptions.Fill;
                    frame.VerticalOptions = LayoutOptions.Fill;
                    frame.BackgroundColor = IsEnabled ? UnselectedColor : DisabledUnselectedColor;

                    if (Type == MaterialSegmentedType.Outlined)
                    {
                        frame.CornerRadius = 16;

                        grid.ColumnSpacing = 0;
                        mainFrame.BorderColor = BorderColor;
                        mainFrame.BackgroundColor = BorderColor;
                        frame.Padding = new Thickness(12, 0);
                        frame.BorderColor = BorderColor;

                        if (itemIdx == 0)
                        {
                            frame.Margin = new Thickness(1, 1, 0, 1);
                            frame.CornerRadiusTopLeft = true;
                            frame.CornerRadiusBottomLeft = true;
                        }
                        else if (itemIdx == ItemsSource.Count() - 1)
                        {
                            frame.Margin = new Thickness(0, 1, 1, 1);
                            frame.CornerRadiusBottomRight = true;
                            frame.CornerRadiusTopRight = true;
                        }
                        else
                        {
                            frame.Margin = new Thickness(0, 1);
                            frame.CornerRadius = 0;
                        }
                    }
                    else
                    {
                        mainFrame.BackgroundColor = IsEnabled ? BackgroundColor : DisabledBackgroundColor;
                        grid.ColumnSpacing = 0;
                        mainFrame.BorderColor = Color.Transparent;
                        frame.CornerRadius = (CornerRadius - SegmentMargin) >= 0 ? ((float)CornerRadius - SegmentMargin) : 0;
                        frame.Margin = new Thickness(SegmentMargin);

                        frame.CornerRadiusTopLeft = true;
                        frame.CornerRadiusBottomLeft = true;
                        frame.CornerRadiusBottomRight = true;
                        frame.CornerRadiusTopRight = true;
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

                    var tapped = new TapGestureRecognizer();
                    tapped.Tapped += (s, e) =>
                    {
                        if (!IsEnabled)
                            return;

                        if (item.IsSelected && !AllowMultiselect)
                            return;

                        if (!AllowMultiselect)
                        {
                            var isThereSelection = ItemsSource.Where(x => x.IsSelected).Count() > 0;

                            if (isThereSelection)
                            {
                                foreach (var insideItem in ItemsSource)
                                {
                                    if (!insideItem.Equals(item))
                                    {
                                        insideItem.IsSelected = false;
                                        var container = containersWithItems[insideItem.Text];
                                        SetContentAndColors(container.Container, container.Label, insideItem);
                                    }
                                }
                            }
                            
                        }

                        if (!item.IsSelected && !AllowMultiselect) 
                        {
                            SelectedItem = item;
                        }
                        else
                        {
                            item.IsSelected = !item.IsSelected;
                            SetContentAndColors(frame, label, item);
                        }
                        
                        if (CommandProperty != null && Command != null)
                            Command.Execute(CommandParameter);

                        IsSelectedChanged?.Invoke(this, null);
                    };

                    SetContentAndColors(frame, label, item);

                    frame.GestureRecognizers.Add(tapped);
                    frame.SetValue(Grid.ColumnProperty, column);

                    grid.Children.Add(frame);
                    column++;
                    itemIdx++;
                }
            }
        }

        private void SetContentAndColors(MaterialCard frame, MaterialLabel label, MaterialSegmentedObject item)
        {
            if (item.IsSelected)
            {
                frame.BackgroundColor = IsEnabled ? SelectedColor : DisabledSelectedColor;
                label.TextColor = IsEnabled ? SelectedTextColor : DisabledSelectedTextColor;

                if (item.SelectedIconIsVisible)
                {
                    var container = new Grid()
                    {
                        BackgroundColor = Color.Transparent,
                        ColumnSpacing = 12,
                        HorizontalOptions = LayoutOptions.Center,
                    };
                    container.ColumnDefinitions.Add(new ColumnDefinition { Width = 18 });
                    container.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

                    var selectedIcon = new CustomImage()
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

                    if (item.CustomSelectedIcon != null)
                    {
                        selectedIcon.SetCustomImage(item.CustomSelectedIcon);
                    }
                    else if (!string.IsNullOrWhiteSpace(item.SelectedIcon))
                    {
                        selectedIcon.SetImage(item.SelectedIcon);
                    }

                    container.Children.Add(selectedIcon);

                    label.SetValue(Grid.ColumnProperty, 1);

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

                if(item.UnselectedIconIsVisible)
                {
                    var container = new Grid()
                    {
                        BackgroundColor = Color.Transparent,
                        ColumnSpacing = 12,
                        HorizontalOptions = LayoutOptions.Center
                    };
                    container.ColumnDefinitions.Add(new ColumnDefinition { Width = 18 });
                    container.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

                    var selectedIcon = new CustomImage()
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

                    if (item.CustomUnselectedIcon != null)
                    {
                        selectedIcon.SetCustomImage(item.CustomUnselectedIcon);
                    }
                    else if (!string.IsNullOrWhiteSpace(item.UnselectedIcon))
                    {
                        selectedIcon.SetImage(item.UnselectedIcon);
                    }

                    container.Children.Add(selectedIcon);

                    label.SetValue(Grid.ColumnProperty, 1);

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
            if (newValue is MaterialSegmentedObject selectedItem && control.ItemsSource.Contains(selectedItem))
            {
                if(!control.AllowMultiselect)
                {
                    var isThereSelection = control.ItemsSource.Where(x => x.IsSelected).Count() > 0;

                    if (isThereSelection)
                    {
                        foreach (var insideItem in control.ItemsSource)
                        {
                            if (!insideItem.Equals(selectedItem))
                            {
                                insideItem.IsSelected = false;
                                var containers = control.containersWithItems[insideItem.Text];
                                control.SetContentAndColors(containers.Container, containers.Label, insideItem);
                            }
                        }
                    }

                    selectedItem.IsSelected = !selectedItem.IsSelected;
                    var container = control.containersWithItems[selectedItem.Text];
                    control.SetContentAndColors(container.Container, container.Label, selectedItem);
                }
            }
        }

        #endregion Methods


        private class ContainerForObjects
        {
            public MaterialCard Container { get; set; }

            public MaterialLabel Label { get; set; }
        }    
    }
}