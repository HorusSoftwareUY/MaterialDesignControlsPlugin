﻿using Plugin.MaterialDesignControls.Implementations;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Plugin.MaterialDesignControls.Objects;
using Plugin.MaterialDesignControls.Styles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

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

        private Label _lblHeadline;

        private StackLayout _itemsContainer;

        Dictionary<string, NavigationDrawerContainerForObjects> containersWithItems = new Dictionary<string, NavigationDrawerContainerForObjects>();

        #endregion Attributes

        #region Properties
        public static readonly BindableProperty HeadlineProperty =
            BindableProperty.Create(nameof(Headline), typeof(string), typeof(MaterialNavigationDrawer), defaultValue: null);

        public string Headline
        {
            get { return (string)GetValue(HeadlineProperty); }
            set { SetValue(HeadlineProperty, value); }
        }

        public static readonly BindableProperty HeadlineColorProperty =
            BindableProperty.Create(nameof(HeadlineColor), typeof(Color), typeof(MaterialNavigationDrawer), defaultValue: DefaultStyles.PrimaryColor);

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

        public static readonly BindableProperty ActiveIndicatorLabelColorProperty =
            BindableProperty.Create(nameof(ActiveIndicatorLabelColor), typeof(Color), typeof(MaterialNavigationDrawer), defaultValue: DefaultStyles.OnPrimaryContainerColor);

        public Color ActiveIndicatorLabelColor
        {
            get { return (Color)GetValue(ActiveIndicatorLabelColorProperty); }
            set { SetValue(ActiveIndicatorLabelColorProperty, value); }
        }

        public static readonly BindableProperty ActiveIndicatorCornerRadiusProperty =
            BindableProperty.Create(nameof(ActiveIndicatorCornerRadius), typeof(float), typeof(MaterialNavigationDrawer), defaultValue: 16.0f);

        public float ActiveIndicatorCornerRadius
        {
            get { return (float)GetValue(ActiveIndicatorCornerRadiusProperty); }
            set { SetValue(ActiveIndicatorCornerRadiusProperty, value); }
        }

        public static readonly BindableProperty LabelColorProperty =
            BindableProperty.Create(nameof(LabelColor), typeof(Color), typeof(MaterialNavigationDrawer), defaultValue: Color.Blue);

        public Color LabelColor
        {
            get { return (Color)GetValue(LabelColorProperty); }
            set { SetValue(LabelColorProperty, value); }
        }

        public static readonly BindableProperty LabelFontSizeProperty =
            BindableProperty.Create(nameof(LabelFontSize), typeof(double), typeof(MaterialNavigationDrawer), defaultValue: DefaultStyles.PhoneFontSizes.LabelLarge);

        public double LabelFontSize
        {
            get { return (double)GetValue(LabelFontSizeProperty); }
            set { SetValue(LabelFontSizeProperty, value); }
        }

        public static readonly BindableProperty LabelFontFamilyProperty =
            BindableProperty.Create(nameof(LabelFontFamily), typeof(string), typeof(MaterialNavigationDrawer), defaultValue: DefaultStyles.FontFamily);

        public string LabelFontFamily
        {
            get { return (string)GetValue(LabelFontFamilyProperty); }
            set { SetValue(LabelFontFamilyProperty, value); }
        }

        public static readonly BindableProperty SectionLabelColorProperty =
            BindableProperty.Create(nameof(SectionLabelColor), typeof(Color), typeof(MaterialNavigationDrawer), defaultValue: Color.Red);

        public Color SectionLabelColor
        {
            get { return (Color)GetValue(SectionLabelColorProperty); }
            set { SetValue(SectionLabelColorProperty, value); }
        }

        public static readonly BindableProperty SectionLabelFontSizeProperty =
            BindableProperty.Create(nameof(SectionLabelFontSize), typeof(double), typeof(MaterialNavigationDrawer), defaultValue: DefaultStyles.PhoneFontSizes.TitleSmall);

        public double SectionLabelFontSize
        {
            get { return (double)GetValue(SectionLabelFontSizeProperty); }
            set { SetValue(SectionLabelFontSizeProperty, value); }
        }

        public static readonly BindableProperty SectionLabelFontFamilyProperty =
            BindableProperty.Create(nameof(SectionLabelFontFamily), typeof(string), typeof(MaterialNavigationDrawer), defaultValue: DefaultStyles.FontFamily);

        public string SectionLabelFontFamily
        {
            get { return (string)GetValue(SectionLabelFontFamilyProperty); }
            set { SetValue(SectionLabelFontFamilyProperty, value); }
        }

        public static readonly BindableProperty DividerColorProperty =
            BindableProperty.Create(nameof(DividerColor), typeof(Color), typeof(MaterialNavigationDrawer), defaultValue: DefaultStyles.OnPrimaryColor);

        public Color DividerColor
        {
            get { return (Color)GetValue(DividerColorProperty); }
            set { SetValue(DividerColorProperty, value); }
        }

        public static readonly BindableProperty BadgeTypeProperty =
            BindableProperty.Create(nameof(BadgeType), typeof(MaterialBadgeType), typeof(MaterialNavigationDrawer), defaultValue: MaterialBadgeType.Large);

        public MaterialBadgeType BadgeType
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

        public IEnumerable<MaterialNavigationDrawerItem> ItemsSource
        {
            get { return (IEnumerable<MaterialNavigationDrawerItem>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        #endregion Properties

        #region Methods

        private void Initialize()
        {
            StackLayout container = new StackLayout()
            {
                Spacing = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
            };

            _itemsContainer = new StackLayout()
            {
                Spacing = 0,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            this._lblHeadline = new Label()
            {
                LineBreakMode = LineBreakMode.NoWrap,
                Margin = new Thickness(0, 16, 0, 16),
                VerticalOptions = LayoutOptions.Center,
                TextColor = this.HeadlineColor,
                IsVisible = !string.IsNullOrWhiteSpace(Headline),
                Text = Headline,
                FontSize = HeadlineFontSize,
                FontFamily = HeadlineFontFamily,
                Padding = new Thickness(12, 0)
            };

            container.Children.Add(this._lblHeadline);
            container.Children.Add(this._itemsContainer);

            this.Content = container;
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
                case nameof(this.Headline):
                    this._lblHeadline.Text = this.Headline;
                    this._lblHeadline.IsVisible = true;
                    break;

                case nameof(this.HeadlineColor):
                    this._lblHeadline.TextColor = this.HeadlineColor;
                    break;

                case nameof(this.HeadlineFontFamily):
                    this._lblHeadline.FontFamily = this.HeadlineFontFamily;
                    break;

                case nameof(this.HeadlineFontSize):
                    this._lblHeadline.FontSize = this.HeadlineFontSize;
                    break;

                case nameof(base.Opacity):
                case nameof(base.Scale):
                case nameof(base.IsVisible):
                case nameof(this.BackgroundColor):
                case nameof(this.Padding):
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
            _itemsContainer.Children.Clear();

            if (ItemsSource != null)
            {
                int itemIdx = 0;

                var groupedItems = ItemsSource.GroupBy(x => x.Section);

                foreach (var group in groupedItems)
                {
                    if (!string.IsNullOrWhiteSpace(group.Key))
                    {
                        var label = new Label();
                        label.Text = group.Key.Trim();
                        label.VerticalTextAlignment = TextAlignment.Center;
                        label.FontSize = SectionLabelFontSize;
                        label.FontFamily = SectionLabelFontFamily;
                        label.TextColor = SectionLabelColor;
                        label.Padding = new Thickness(12, 0);
                        label.Margin = new Thickness(0, 0, 0, 16);

                        _itemsContainer.Children.Add(label);
                    }

                    foreach (var item in group)
                    {
                        string key = item.Section + "-" + item.Text;

                        if (containersWithItems.ContainsKey(key))
                        {
                            continue;
                        }

                        var frame = new MaterialCard();
                        frame.HasShadow = false;
                        frame.BorderColor = Color.Transparent;
                        frame.Padding = new Thickness(16, 0);
                        frame.HeightRequest = 56;
                        frame.MinimumHeightRequest = 56;
                        frame.HorizontalOptions = LayoutOptions.FillAndExpand;
                        frame.VerticalOptions = LayoutOptions.Fill;
                        frame.BackgroundColor = item.IsSelected ? ActiveIndicatorBackgroundColor : Color.Transparent;
                        frame.CornerRadius = ActiveIndicatorCornerRadius;
                        frame.CornerRadiusBottomLeft = true;
                        frame.CornerRadiusBottomRight = true;
                        frame.CornerRadiusTopLeft = true;
                        frame.CornerRadiusTopRight = true;

                        var contentContainer = new Grid()
                        {
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            ColumnSpacing = 0,
                        };

                        contentContainer.ColumnDefinitions = new ColumnDefinitionCollection()
                        {
                            new ColumnDefinition { Width = 24 },
                            new ColumnDefinition { Width = GridLength.Star },
                            new ColumnDefinition { Width = GridLength.Auto }
                        };


                        var icon = new CustomImage()
                        {
                            HeightRequest = 24,
                            MinimumHeightRequest = 24,
                            WidthRequest = 24,
                            MinimumWidthRequest = 24,
                            HorizontalOptions = LayoutOptions.Start,
                            VerticalOptions = LayoutOptions.Center,
                            Margin = new Thickness(0),
                            Padding = new Thickness(0)
                        };

                        icon.SetValue(Grid.ColumnProperty, 0);

                        var label = new Label();
                        label.Text = item.Text.Trim();
                        label.VerticalTextAlignment = TextAlignment.Center;
                        label.FontSize = LabelFontSize;
                        label.FontFamily = LabelFontFamily;
                        label.TextColor = item.IsSelected ? ActiveIndicatorLabelColor : LabelColor;
                        label.Padding = new Thickness(12, 0);

                        label.SetValue(Grid.ColumnProperty, 1);

                        var badge = new MaterialBadge()
                        {
                            Type = BadgeType,
                            TextColor = BadgeTextColor,
                            FontSize = BadgeFontSize,
                            FontFamily = BadgeFontFamily,
                            BackgroundColor = BadgeBackgroundColor,
                            Text = item.BadgeText,
                            IsVisible = !string.IsNullOrWhiteSpace(item.BadgeText)
                        };

                        badge.SetValue(Grid.ColumnProperty, 2);

                        contentContainer.Children.Add(icon);
                        contentContainer.Children.Add(label);
                        contentContainer.Children.Add(badge);

                        frame.Content = contentContainer;

                        containersWithItems.Add(key, new NavigationDrawerContainerForObjects()
                        {
                            Container = frame,
                            Icon = icon,
                            Label = label
                        });

                        var tapped = new TapGestureRecognizer();
                        tapped.Tapped += (s, e) =>
                        {
                            if (item.IsSelected)
                            {
                                return;
                            }

                            var isThereSelection = ItemsSource.Where(x => x.IsSelected).Count() > 0;

                            if (isThereSelection)
                            {
                                foreach (var insideItem in ItemsSource)
                                {
                                    if (!insideItem.Equals(item))
                                    {
                                        insideItem.IsSelected = false;
                                        string insideKey = insideItem.Section + "-" + insideItem.Text;
                                        var container = containersWithItems[insideKey];
                                        SetContentAndColors(container.Container, container.Icon, container.Label, insideItem);
                                    }
                                }
                            }

                            item.IsSelected = !item.IsSelected;
                            SetContentAndColors(frame, icon, label, item);
                        };

                        SetContentAndColors(frame, icon, label,  item);

                        frame.GestureRecognizers.Add(tapped);

                        _itemsContainer.Children.Add(frame);
                    }


                    MaterialDivider divider = new MaterialDivider()
                    {
                        Color = DividerColor,
                        Margin = new Thickness(0, 16)
                    };

                    if (itemIdx++ != groupedItems.Count() - 1)
                        _itemsContainer.Children.Add(divider);
                }
            }
        }

        private void SetContentAndColors(MaterialCard frame, CustomImage icon, Label label, MaterialNavigationDrawerItem item)
        {
            frame.BackgroundColor = item.IsSelected ? ActiveIndicatorBackgroundColor : Color.Transparent;
            label.TextColor = item.IsSelected ? ActiveIndicatorLabelColor : LabelColor;

            if (item.IsSelected)
            {
                if (item.SelectedIconIsVisible)
                {
                    icon.IsVisible = true;

                    if (item.CustomSelectedIcon != null)
                    {
                        icon.SetCustomImage(item.CustomSelectedIcon);
                    }
                    else if (!string.IsNullOrWhiteSpace(item.SelectedIcon))
                    {
                        icon.SetImage(item.SelectedIcon);
                    }
                }
                else if(item.UnselectedIconIsVisible)
                {
                    icon.IsVisible = false;
                }
            }
            else
            {
                if (item.UnselectedIconIsVisible)
                {
                    icon.IsVisible = true;

                    if (item.CustomUnselectedIcon != null)
                    {
                        icon.SetCustomImage(item.CustomUnselectedIcon);
                    }
                    else if (!string.IsNullOrWhiteSpace(item.UnselectedIcon))
                    {
                        icon.SetImage(item.UnselectedIcon);
                    }
                }
                else if (item.SelectedIconIsVisible)
                {
                    icon.IsVisible = false;
                }
            }
        }


        #endregion Methods

        private class NavigationDrawerContainerForObjects
        {
            public MaterialCard Container { get; set; }

            public CustomImage Icon { get; set; }

            public Label Label { get; set; }
        }
    }
}
