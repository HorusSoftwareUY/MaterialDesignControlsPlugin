using Plugin.MaterialDesignControls.Implementations;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Plugin.MaterialDesignControls.Objects;
using Plugin.MaterialDesignControls.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Plugin.MaterialDesignControls.Material3
{
    public class MaterialNavigationDrawer : ContentView
    {
        #region Constructors

        public MaterialNavigationDrawer()
        {
            if (!this.initialized)
            {
                this.initialized = true;
                this.Initialize();
            }
        }

        #endregion Constructors

        #region Attributes

        private bool initialized = false;

        private MaterialCard _frmContainer;

        private Label _lblHeadline;

        private StackLayout _itemsContainer;
        #endregion Attributes

        #region Properties

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialNavigationDrawer), defaultValue: DefaultStyles.PrimaryContainerColor);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly new BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(MaterialNavigationDrawer), defaultValue: new Thickness(28, 0));

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        public static readonly BindableProperty HeadlineProperty =
            BindableProperty.Create(nameof(Headline), typeof(string), typeof(MaterialNavigationDrawer), defaultValue: null);

        public string Headline
        {
            get { return (string)GetValue(HeadlineProperty); }
            set { SetValue(HeadlineProperty, value); }
        }

        public static readonly BindableProperty HeadlineColorProperty =
            BindableProperty.Create(nameof(HeadlineColor), typeof(Color), typeof(MaterialNavigationDrawer), defaultValue: DefaultStyles.OnPrimaryColor);

        public Color HeadlineColor
        {
            get { return (Color)GetValue(HeadlineColorProperty); }
            set { SetValue(HeadlineColorProperty, value); }
        }


        public static readonly BindableProperty HeadlineFontSizeProperty =
            BindableProperty.Create(nameof(HeadlineFontSize), typeof(double), typeof(MaterialNavigationDrawer), defaultValue: 14.0);

        public double HeadlineFontSize
        {
            get { return (double)GetValue(HeadlineFontSizeProperty); }
            set { SetValue(HeadlineFontSizeProperty, value); }
        }

        public static readonly BindableProperty HeadlineFontFamilyProperty =
            BindableProperty.Create(nameof(HeadlineFontFamily), typeof(string), typeof(MaterialNavigationDrawer), defaultValue: null);

        public string HeadlineFontFamily
        {
            get { return (string)GetValue(HeadlineFontFamilyProperty); }
            set { SetValue(HeadlineFontFamilyProperty, value); }
        }

        public static readonly BindableProperty ActiveIndicatorBackgroundColorProperty =
            BindableProperty.Create(nameof(ActiveIndicatorBackgroundColor), typeof(Color), typeof(MaterialNavigationDrawer), defaultValue: DefaultStyles.PrimaryContainerColor);

        public Color ActiveIndicatorBackgroundColor
        {
            get { return (Color)GetValue(ActiveIndicatorBackgroundColorProperty); }
            set { SetValue(ActiveIndicatorBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty ActiveIndicatorCornerRadiusProperty =
            BindableProperty.Create(nameof(ActiveIndicatorCornerRadius), typeof(float), typeof(MaterialNavigationDrawer), defaultValue: 16.0f);

        public float ActiveIndicatorCornerRadius
        {
            get { return (float)GetValue(ActiveIndicatorCornerRadiusProperty); }
            set { SetValue(ActiveIndicatorCornerRadiusProperty, value); }
        }

        public static readonly BindableProperty LabelColorProperty =
            BindableProperty.Create(nameof(LabelColor), typeof(Color), typeof(MaterialNavigationDrawer), defaultValue: Color.Gray);

        public Color LabelColor
        {
            get { return (Color)GetValue(LabelColorProperty); }
            set { SetValue(LabelColorProperty, value); }
        }

        public static readonly BindableProperty LabelFontSizeProperty =
            BindableProperty.Create(nameof(LabelFontSize), typeof(double), typeof(MaterialNavigationDrawer), defaultValue: Font.Default.FontSize);

        public double LabelFontSize
        {
            get { return (double)GetValue(LabelFontSizeProperty); }
            set { SetValue(LabelFontSizeProperty, value); }
        }

        public static readonly BindableProperty LabelFontFamilyProperty =
            BindableProperty.Create(nameof(LabelFontFamily), typeof(string), typeof(MaterialNavigationDrawer), defaultValue: null);

        public string LabelFontFamily
        {
            get { return (string)GetValue(LabelFontFamilyProperty); }
            set { SetValue(LabelFontFamilyProperty, value); }
        }

        public static readonly BindableProperty SelectionLabelColorProperty =
            BindableProperty.Create(nameof(SelectionLabelColor), typeof(Color), typeof(MaterialNavigationDrawer), defaultValue: Color.Gray);

        public Color SelectionLabelColor
        {
            get { return (Color)GetValue(SelectionLabelColorProperty); }
            set { SetValue(SelectionLabelColorProperty, value); }
        }

        public static readonly BindableProperty SelectionLabelFontSizeProperty =
            BindableProperty.Create(nameof(SelectionLabelFontSize), typeof(double), typeof(MaterialNavigationDrawer), defaultValue: Font.Default.FontSize);

        public double SelectionLabelFontSize
        {
            get { return (double)GetValue(SelectionLabelFontSizeProperty); }
            set { SetValue(SelectionLabelFontSizeProperty, value); }
        }

        public static readonly BindableProperty SelectionLabelFontFamilyProperty =
            BindableProperty.Create(nameof(SelectionLabelFontFamily), typeof(string), typeof(MaterialNavigationDrawer), defaultValue: null);

        public string SelectionLabelFontFamily
        {
            get { return (string)GetValue(SelectionLabelFontFamilyProperty); }
            set { SetValue(SelectionLabelFontFamilyProperty, value); }
        }

        public static readonly BindableProperty DividerColorProperty =
            BindableProperty.Create(nameof(DividerColor), typeof(Color), typeof(MaterialNavigationDrawer), defaultValue: DefaultStyles.OnPrimaryColor);

        public Color DividerColor
        {
            get { return (Color)GetValue(DividerColorProperty); }
            set { SetValue(DividerColorProperty, value); }
        }

        public static readonly BindableProperty BadgeTypeProperty =
            BindableProperty.Create(nameof(Type), typeof(MaterialBadgeType), typeof(MaterialNavigationDrawer), defaultValue: MaterialBadgeType.Large);

        public MaterialBadgeType Type
        {
            get { return (MaterialBadgeType)GetValue(BadgeTypeProperty); }
            set { SetValue(BadgeTypeProperty, value); }
        }


        public static readonly BindableProperty BadgeTextColorProperty =
            BindableProperty.Create(nameof(BadgeTextColor), typeof(Color), typeof(MaterialNavigationDrawer), defaultValue: DefaultStyles.OnPrimaryColor);

        public Color BadgeTextColor
        {
            get { return (Color)GetValue(BadgeTextColorProperty); }
            set { SetValue(BadgeTextColorProperty, value); }
        }

        public static readonly BindableProperty BadgeFontSizeProperty =
            BindableProperty.Create(nameof(BadgeFontSize), typeof(double), typeof(MaterialNavigationDrawer), defaultValue: DefaultStyles.PhoneFontSizes.LabelSmall);

        public double BadgeFontSize
        {
            get { return (double)GetValue(BadgeFontSizeProperty); }
            set { SetValue(BadgeFontSizeProperty, value); }
        }

        public static readonly BindableProperty BadgeFontFamilyProperty =
            BindableProperty.Create(nameof(BadgeFontFamily), typeof(string), typeof(MaterialNavigationDrawer), defaultValue: DefaultStyles.FontFamily);

        public string BadgeFontFamily
        {
            get { return (string)GetValue(BadgeFontFamilyProperty); }
            set { SetValue(BadgeFontFamilyProperty, value); }
        }

        public static readonly BindableProperty BadgeBackgroundColorProperty =
            BindableProperty.Create(nameof(BadgeBackgroundColor), typeof(Color), typeof(MaterialNavigationDrawer), defaultValue: DefaultStyles.ErrorColor);

        public Color BadgeBackgroundColor
        {
            get { return (Color)GetValue(BadgeBackgroundColorProperty); }
            set { SetValue(BadgeBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<MaterialNavigationDrawerItem>), typeof(MaterialNavigationDrawer), defaultValue: null, defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnItemsSourceChanged);

        public IEnumerable<MaterialNavigationDrawer> ItemsSource
        {
            get { return (IEnumerable<MaterialNavigationDrawer>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        #endregion Properties

        #region Events

        public event EventHandler IsSelectedChanged;

        #endregion Events

        #region Methods

        private void Initialize()
        {
            this._frmContainer = new MaterialCard()
            {
                HasShadow = false,
                CornerRadius = 16,
                Padding = this.Padding,
                BorderColor = Color.Transparent
            };

            StackLayout container = new StackLayout()
            {
                Spacing = 0,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };

            _itemsContainer = new StackLayout()
            {
                Spacing = 0,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand
            };


            this._lblHeadline = new Label()
            {
                LineBreakMode = LineBreakMode.NoWrap,
                Margin = new Thickness(1),
                VerticalOptions = LayoutOptions.Center,
                TextColor = this.HeadlineColor,
                IsVisible = !string.IsNullOrWhiteSpace(Headline),
                Text = Headline
            };

            _itemsContainer.Children.Add(this._lblHeadline);

            container.Children.Add(this._itemsContainer);

            this._frmContainer.Content = container;
            this.Content = this._frmContainer;
            Effects.Add(new TouchAndPressEffect());
        }


        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!this.initialized)
            {
                this.initialized = true;
                this.Initialize();
            }

            switch (propertyName)
            {
                //case nameof(this.Text):
                //case nameof(this.ToUpper):
                //    this._lblText.Text = this.ToUpper ? this.Text?.ToUpper() : this.Text;
                //    break;
                //case nameof(this.FontSize):
                //    this._lblText.FontSize = this.FontSize;
                //    break;
                //case nameof(this.FontFamily):
                //    this._lblText.FontFamily = this.FontFamily;
                //    break;
                //case nameof(this.Padding):
                //    this._frmContainer.Padding = this.Padding;
                //    break;
                //case nameof(this.TextMargin):
                //    this._lblText.Margin = this.TextMargin;
                //    break;
                //case nameof(this.CornerRadius):
                //    this._frmContainer.CornerRadius = (float)this.CornerRadius;
                //    break;
                //case nameof(this.IsEnabled):
                //case nameof(this.SelectedTextColor):
                //case nameof(this.SelectedBackgroundColor):
                //case nameof(this.TextColor):
                //case nameof(this.BackgroundColor):
                //case nameof(this.DisabledSelectedTextColor):
                //case nameof(this.DisabledSelectedBackgroundColor):
                //case nameof(this.DisabledTextColor):
                //case nameof(this.DisabledBackgroundColor):
                //    //this.ApplyIsSelected();
                //    break;

                //case nameof(TrailingIcon):
                //    _imgTrailingIcon.SetImage(TrailingIcon);
                //    _imgTrailingIcon.IsVisible = TrailingIconIsVisible;
                //    break;
                //case nameof(CustomTrailingIcon):
                //    _imgTrailingIcon.SetCustomImage(CustomTrailingIcon);
                //    _imgTrailingIcon.IsVisible = TrailingIconIsVisible;
                //    break;
                //case nameof(LeadingIcon):
                //    _imgLeadingIcon.SetImage(LeadingIcon);
                //    _imgLeadingIcon.IsVisible = LeadingIconIsVisible;
                //    break;
                //case nameof(CustomLeadingIcon):
                //    _imgLeadingIcon.SetCustomImage(CustomLeadingIcon);
                //    _imgLeadingIcon.IsVisible = LeadingIconIsVisible;
                //    break;

                //case nameof(TrailingIconIsVisible):
                //    _imgTrailingIcon.IsVisible = TrailingIconIsVisible;
                //    break;
                //case nameof(LeadingIconIsVisible):
                //    _imgLeadingIcon.IsVisible = LeadingIconIsVisible;
                //    break;

                //case nameof(this.LeadingIconCommand):
                //    AddIconTapGesture(false);
                //    break;
                //case nameof(this.TrailingIconCommand):
                //    AddIconTapGesture(true);
                //    break;

                //case nameof(this.BorderColor):
                //    this._frmContainer.BorderColor = this.BorderColor;
                //    break;

                case nameof(base.Opacity):
                case nameof(base.Scale):
                case nameof(base.IsVisible):
                    base.OnPropertyChanged(propertyName);
                    break;
            }
        }


        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialNavigationDrawer)bindable;
            control.SetItemSource();
        }

        private void SetItemSource()
        {
            //_grid.ColumnDefinitions = new ColumnDefinitionCollection();
            //_grid.Children.Clear();

            int column = 0;
            if (ItemsSource != null)
            {
                int itemIdx = 0;
                //ItemsSource.ForEach(x => _grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ItemsSource.Count() / 100.0, GridUnitType.Star) }));

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

                        _grid.ColumnSpacing = 0;
                        _mainFrame.BorderColor = IsEnabled ? BorderColor : DisabledBorderColor;
                        _mainFrame.BackgroundColor = IsEnabled ? BorderColor : DisabledBorderColor;
                        frame.BorderColor = IsEnabled ? BorderColor : DisabledBorderColor;

                        if (itemIdx == 0)
                        {
                            frame.Margin = new Thickness(1, 1, 1, 1);
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
                            if (Device.RuntimePlatform == Device.iOS)
                                frame.Margin = new Thickness(0, 1, 1, 1);
                            else
                                frame.Margin = new Thickness(0, 1);

                            frame.CornerRadius = 0;
                        }
                    }
                    else
                    {
                        _mainFrame.BackgroundColor = IsEnabled ? BackgroundColor : DisabledBackgroundColor;
                        _grid.ColumnSpacing = 0;
                        _mainFrame.BorderColor = Color.Transparent;
                        frame.CornerRadius = (CornerRadius - SegmentMargin) >= 0 ? ((float)CornerRadius - SegmentMargin) : 0;
                        frame.Margin = new Thickness(SegmentMargin);

                        frame.CornerRadiusTopLeft = true;
                        frame.CornerRadiusBottomLeft = true;
                        frame.CornerRadiusBottomRight = true;
                        frame.CornerRadiusTopRight = true;
                    }

                    var label = new Plugin.MaterialDesignControls.MaterialLabel();
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

                    _grid.Children.Add(frame);
                    column++;
                    itemIdx++;
                }
            }
        }

        private void SetContentAndColors(MaterialCard frame, Plugin.MaterialDesignControls.MaterialLabel label, MaterialSegmentedItem item)
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

                if (item.UnselectedIconIsVisible)
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


        #endregion Methods
    }
}
