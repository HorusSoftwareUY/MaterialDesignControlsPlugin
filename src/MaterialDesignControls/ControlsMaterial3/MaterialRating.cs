using System;
using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Implementations;
using Plugin.MaterialDesignControls.Material3;
using Plugin.MaterialDesignControls.Styles;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Linq;

namespace Plugin.MaterialDesignControls.Material3
{
	public class MaterialRating : MaterialCustomControl
    {
        #region Attributes

        private bool initialized = false;

        private Grid _gridMain;

        private Grid _grid;

        #endregion Attributes

        #region Properties

        public static readonly BindableProperty UseSameIconProperty =
            BindableProperty.Create(nameof(UseSameIcon), typeof(bool), typeof(MaterialRating), defaultValue: true);

        public bool UseSameIcon
        {
            get { return (bool)GetValue(UseSameIconProperty); }
            set { SetValue(UseSameIconProperty, value); }
        }

        public static readonly BindableProperty SelectedIconProperty =
            BindableProperty.Create(nameof(SelectedIcon), typeof(string), typeof(MaterialRating), defaultValue: null);

        public string SelectedIcon
        {
            get { return (string)GetValue(SelectedIconProperty); }
            set { SetValue(SelectedIconProperty, value); }
        }

        public static readonly BindableProperty CustomSelectedIconProperty =
            BindableProperty.Create(nameof(CustomSelectedIcon), typeof(DataTemplate), typeof(MaterialRating), defaultValue: null);

        public DataTemplate CustomSelectedIcon
        {
            get { return (DataTemplate)GetValue(CustomSelectedIconProperty); }
            set { SetValue(CustomSelectedIconProperty, value); }
        }

        public static readonly BindableProperty UnSelectedIconProperty =
            BindableProperty.Create(nameof(UnSelectedIcon), typeof(string), typeof(MaterialRating), defaultValue: null);

        public string UnSelectedIcon
        {
            get { return (string)GetValue(UnSelectedIconProperty); }
            set { SetValue(UnSelectedIconProperty, value); }
        }

        public static readonly BindableProperty CustomUnselectedIconProperty =
            BindableProperty.Create(nameof(CustomUnselectedIcon), typeof(DataTemplate), typeof(MaterialRating), defaultValue: null);

        public DataTemplate CustomUnselectedIcon
        {
            get { return (DataTemplate)GetValue(CustomUnselectedIconProperty); }
            set { SetValue(CustomUnselectedIconProperty, value); }
        }

        public static readonly BindableProperty CustomSelectedIconsSourceProperty =
            BindableProperty.Create(nameof(CustomSelectedIconsSource), typeof(IEnumerable<DataTemplate>), typeof(MaterialRating), defaultValue: null);

        public IEnumerable<DataTemplate> CustomSelectedIconsSource
        {
            get { return (IEnumerable<DataTemplate>)GetValue(CustomSelectedIconsSourceProperty); }
            set { SetValue(CustomSelectedIconsSourceProperty, value); }
        }

        public static readonly BindableProperty SelectedIconsSourceProperty =
            BindableProperty.Create(nameof(SelectedIconsSource), typeof(IEnumerable<string>), typeof(MaterialRating), defaultValue: null);

        public IEnumerable<string> SelectedIconsSource
        {
            get { return (IEnumerable<string>)GetValue(SelectedIconsSourceProperty); }
            set { SetValue(SelectedIconsSourceProperty, value); }
        }

        public static readonly BindableProperty CustomUnselectedIconsSourceProperty =
            BindableProperty.Create(nameof(CustomUnselectedIconsSource), typeof(IEnumerable<DataTemplate>), typeof(MaterialRating), defaultValue: null);

        public IEnumerable<DataTemplate> CustomUnselectedIconsSource
        {
            get { return (IEnumerable<DataTemplate>)GetValue(CustomUnselectedIconsSourceProperty); }
            set { SetValue(CustomUnselectedIconsSourceProperty, value); }
        }

        public static readonly BindableProperty UnselectedIconsSourceProperty =
            BindableProperty.Create(nameof(UnselectedIconsSource), typeof(IEnumerable<string>), typeof(MaterialRating), defaultValue: null);

        public IEnumerable<string> UnselectedIconsSource
        {
            get { return (IEnumerable<string>)GetValue(UnselectedIconsSourceProperty); }
            set { SetValue(UnselectedIconsSourceProperty, value); }
        }

        public static readonly BindableProperty ItemSizeProperty =
           BindableProperty.Create(nameof(ItemSize), typeof(int), typeof(MaterialRating), defaultValue: 5);

        public int ItemSize
        {
            get { return (int)GetValue(ItemSizeProperty); }
            set { SetValue(ItemSizeProperty, value); }
        }

        public static readonly BindableProperty ItemsByRowProperty =
           BindableProperty.Create(nameof(ItemsByRow), typeof(int), typeof(MaterialRating), defaultValue: 5);

        public int ItemsByRow
        {
            get { return (int)GetValue(ItemsByRowProperty); }
            set { SetValue(ItemsByRowProperty, value); }
        }

        public static readonly new BindableProperty IsEnabledProperty =
            BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(MaterialRating), defaultValue: true);

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public static readonly BindableProperty ValueProperty =
           BindableProperty.Create(nameof(Value), typeof(int), typeof(MaterialRating), defaultBindingMode: BindingMode.TwoWay, defaultValue: -1, propertyChanged: OnValuePropertyChanged);

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly BindableProperty AnimationProperty =
            BindableProperty.Create(nameof(Animation), typeof(AnimationTypes), typeof(MaterialRating), defaultValue: DefaultStyles.AnimationType);

        public AnimationTypes Animation
        {
            get { return (AnimationTypes)GetValue(AnimationProperty); }
            set { SetValue(AnimationProperty, value); }
        }

        public static readonly BindableProperty AnimationParameterProperty =
            BindableProperty.Create(nameof(AnimationParameter), typeof(double?), typeof(MaterialRating), defaultValue: DefaultStyles.AnimationParameter);

        public double? AnimationParameter
        {
            get { return (double?)GetValue(AnimationParameterProperty); }
            set { SetValue(AnimationParameterProperty, value); }
        }

        #endregion Properties

        #region Constructors

        public MaterialRating() : base()
        {
            _grid = new Grid()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(10, 0)
            };

            base.CustomControl = _grid;
        }

        #endregion Constructors

        #region Methods

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            switch (propertyName)
            {
                case nameof(ItemSize):
                case nameof(ItemsByRow):
                case nameof(UnSelectedIcon):
                case nameof(CustomSelectedIcon):
                case nameof(SelectedIcon):
                case nameof(CustomUnselectedIcon):
                case nameof(AnimationParameter):
                case nameof(Animation):
                case nameof(UseSameIcon):
                case nameof(CustomSelectedIconsSource):
                case nameof(SelectedIconsSource):
                case nameof(CustomUnselectedIconsSource):
                case nameof(UnselectedIconsSource):
                    SetGridContent();
                    break;
                default:
                    base.OnPropertyChanged(propertyName);
                    break;
            }
        }

        public static void OnValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is MaterialRating control && newValue != null && int.TryParse(newValue.ToString(), out int value))
            {
                int idxPosition = 0;
                foreach (CustomImageButton item in control._grid.Children)
                    SetIconsRatingControl(item, value, control, idxPosition++);
            }
        }

        private void SetGridContent()
        {
            if ((UseSameIcon && String.IsNullOrEmpty(SelectedIcon) && CustomSelectedIcon == null)
                                || (UseSameIcon && String.IsNullOrEmpty(UnSelectedIcon) && CustomUnselectedIcon == null)
                                 || (!UseSameIcon && SelectedIconsSource is null && CustomSelectedIconsSource is null)
                                 || (!UseSameIcon && CustomUnselectedIconsSource is null && UnselectedIconsSource is null))
                return;

            // Populate grid
            int rows = (int)Math.Ceiling(ItemSize * 1.0 / ItemsByRow * 1.0);
            int populatedObjects = 0;
            double valuePerItem = 100.0 / (ItemSize * 1.0);

            _grid.RowDefinitions = new RowDefinitionCollection();
            _grid.ColumnDefinitions = new ColumnDefinitionCollection();
            _grid.Children.Clear();

            // Set definitions of grid
            for (int i = 0; i < rows; i++)
                _grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            for (int i = 0; i < ItemsByRow; i++)
                _grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ItemsByRow / 100.0, GridUnitType.Star) });


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < ItemsByRow; j++)
                {
                    if (populatedObjects == ItemSize)
                        break;

                    int value = populatedObjects;

                    ++populatedObjects;

                    // Add element at i,j position on grid
                    CustomImageButton customImageButton = new CustomImageButton()
                    {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        ImageHeightRequest = 34,
                        ImageWidthRequest = 34,
                        Padding = 6,
                        BackgroundColor = Color.Transparent,
                        IsVisible = true,
                        Command = new Command((e) => OnTapped((int)(e))),
                        CommandParameter = value + 1,
                        Animation = Animation,
                    };

                    if (AnimationParameter.HasValue)
                        customImageButton.AnimationParameter = AnimationParameter;

                    customImageButton.SetValue(Grid.RowProperty, i);
                    customImageButton.SetValue(Grid.ColumnProperty, j);

                    SetIconsRatingControl(customImageButton, Value, this, populatedObjects - 1);

                    _grid.Children.Add(customImageButton);
                }
            }
        }

        private void OnTapped(int value)
        {
            if (IsEnabled)
            {
                if (Value == 1 && value == 1)
                    Value = 0;
                else
                    Value = value;
            }
        }

        public static void SetIconsRatingControl(CustomImageButton item, int value, MaterialRating control, int position)
        {
            if (item.CommandParameter != null && (int)item.CommandParameter <= value)
            {
                if (control.UseSameIcon)
                {
                    if (!string.IsNullOrEmpty(control.SelectedIcon))
                        item.SetImage(control.SelectedIcon);
                    else if (control.CustomSelectedIcon != null)
                        item.SetCustomImage(control.CustomSelectedIcon.CreateContent() as View);
                }
                else
                {
                    if (control.SelectedIconsSource != null && position >= 0 && position < control.SelectedIconsSource.Count())
                    {
                        var selectedIcon = control.SelectedIconsSource.ElementAtOrDefault(position);

                        if (!string.IsNullOrWhiteSpace(selectedIcon))
                        {
                            item.SetImage(selectedIcon);
                            return;
                        }
                    }

                    if (control.CustomSelectedIconsSource != null && position >= 0 && position < control.CustomSelectedIconsSource.Count())
                    {
                        var customSelectedIcon = control.CustomSelectedIconsSource.ElementAtOrDefault(position);
                        if (customSelectedIcon is not null)
                        {
                            item.SetCustomImage(customSelectedIcon.CreateContent() as View);
                            return;
                        }
                    }
                }
            }
            else
            {
                if (control.UseSameIcon)
                {
                    if (!string.IsNullOrEmpty(control.UnSelectedIcon))
                        item.SetImage(control.UnSelectedIcon);
                    else if (control.CustomUnselectedIcon != null)
                        item.SetCustomImage(control.CustomUnselectedIcon.CreateContent() as View);
                }
                else
                {
                    if (control.UnselectedIconsSource != null && position >= 0 && position < control.UnselectedIconsSource.Count())
                    {
                        var unselectedIcon = control.UnselectedIconsSource.ElementAtOrDefault(position);
                        if (!string.IsNullOrWhiteSpace(unselectedIcon))
                        {
                            item.SetImage(unselectedIcon);
                            return;
                        }
                    }

                    if (control.CustomUnselectedIconsSource != null && position >= 0 && position < control.CustomUnselectedIconsSource.Count())
                    {
                        var customUnselectedIcon = control.CustomUnselectedIconsSource.ElementAtOrDefault(position);
                        if (customUnselectedIcon is not null)
                        {
                            item.SetCustomImage(customUnselectedIcon.CreateContent() as View);
                            return;
                        }
                    }
                }

            }
        }

        #endregion Methods
    }
}