﻿using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Implementations;
using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3
{
    public class MaterialRating : ContentView
    {
        #region Constructors

        public MaterialRating()
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

        private Grid _gridMain;

        private MaterialLabel _lblLabel;

        private Grid _grid;

        private MaterialLabel _lblSupporting;
        #endregion Attributes

        #region Properties

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

        public static readonly BindableProperty CustomUnSelectedIconProperty =
            BindableProperty.Create(nameof(CustomUnSelectedIcon), typeof(DataTemplate), typeof(MaterialRating), defaultValue: null);

        public DataTemplate CustomUnSelectedIcon
        {
            get { return (DataTemplate)GetValue(CustomUnSelectedIconProperty); }
            set { SetValue(CustomUnSelectedIconProperty, value); }
        }

        public static readonly BindableProperty ItemSizeProperty =
           BindableProperty.Create(nameof(ItemSize), typeof(int?), typeof(MaterialRating), defaultValue: null);

        public int? ItemSize
        {
            get { return (int?)GetValue(ItemSizeProperty); }
            set { SetValue(ItemSizeProperty, value); }
        }

        public static readonly BindableProperty ItemsByRowProperty =
           BindableProperty.Create(nameof(ItemsByRow), typeof(int?), typeof(MaterialRating), defaultValue: null);

        public int? ItemsByRow
        {
            get { return (int?)GetValue(ItemsByRowProperty); }
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
            BindableProperty.Create(nameof(Animation), typeof(AnimationTypes), typeof(MaterialRating), defaultValue: AnimationTypes.None);

        public AnimationTypes Animation
        {
            get { return (AnimationTypes)GetValue(AnimationProperty); }
            set { SetValue(AnimationProperty, value); }
        }

        public static readonly BindableProperty AnimationParameterProperty =
            BindableProperty.Create(nameof(AnimationParameter), typeof(double?), typeof(MaterialRating), defaultValue: null);

        public double? AnimationParameter
        {
            get { return (double?)GetValue(AnimationParameterProperty); }
            set { SetValue(AnimationParameterProperty, value); }
        }

        #region LabelText

        public static readonly BindableProperty LabelTextProperty =
            BindableProperty.Create(nameof(LabelText), typeof(string), typeof(MaterialRating), defaultValue: null);

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public static readonly BindableProperty LabelTextColorProperty =
            BindableProperty.Create(nameof(LabelTextColor), typeof(Color), typeof(MaterialRating), defaultValue: Color.Gray);

        public Color LabelTextColor
        {
            get { return (Color)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public static readonly BindableProperty LabelSizeProperty =
            BindableProperty.Create(nameof(LabelSize), typeof(double), typeof(MaterialRating), defaultValue: Font.Default.FontSize);

        public double LabelSize
        {
            get { return (double)GetValue(LabelSizeProperty); }
            set { SetValue(LabelSizeProperty, value); }
        }

        #endregion LabelText

        #region SupportingText

        public static readonly BindableProperty SupportingTextProperty =
            BindableProperty.Create(nameof(SupportingText), typeof(string), typeof(MaterialRating), defaultValue: null, validateValue: OnSupportingTextValidate);

        public string SupportingText
        {
            get { return (string)GetValue(SupportingTextProperty); }
            set { SetValue(SupportingTextProperty, value); }
        }

        public static readonly BindableProperty SupportingTextColorProperty =
            BindableProperty.Create(nameof(SupportingTextColor), typeof(Color), typeof(MaterialRating), defaultValue: Color.Gray);

        public Color SupportingTextColor
        {
            get { return (Color)GetValue(SupportingTextColorProperty); }
            set { SetValue(SupportingTextColorProperty, value); }
        }

        public static readonly BindableProperty SupportingSizeProperty =
            BindableProperty.Create(nameof(SupportingSize), typeof(double), typeof(MaterialRating), defaultValue: Font.Default.FontSize);

        public double SupportingSize
        {
            get { return (double)GetValue(SupportingSizeProperty); }
            set { SetValue(SupportingSizeProperty, value); }
        }

        public static readonly BindableProperty AnimateErrorProperty =
           BindableProperty.Create(nameof(AnimateError), typeof(bool), typeof(MaterialRating), defaultValue: false);

        public bool AnimateError
        {
            get { return (bool)GetValue(AnimateErrorProperty); }
            set { SetValue(AnimateErrorProperty, value); }
        }

        #endregion SupportingText

        #endregion Properties

        #region Methods

        private void Initialize()
        {
            _gridMain = new Grid() 
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(0),
                ColumnDefinitions = new ColumnDefinitionCollection()
                {
                    new ColumnDefinition()
                    {
                        Width = GridLength.Star
                    }
                },
                RowDefinitions = new RowDefinitionCollection() 
                {
                    new RowDefinition()
                    {
                        Height = GridLength.Star
                    },
                    new RowDefinition()
                    {
                        Height = GridLength.Auto
                    },
                    new RowDefinition()
                    {
                        Height = GridLength.Star
                    }
                }
            };

            _lblLabel = new MaterialLabel()
            {
                IsVisible = false,
                LineBreakMode = LineBreakMode.NoWrap,
                Margin = new Thickness(14, 0, 14, 2),
                HorizontalTextAlignment = TextAlignment.Center
            };

            _lblLabel.SetValue(Grid.RowProperty, 0);

            _grid = new Grid()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(10, 0)
            };

            _grid.SetValue(Grid.RowProperty, 1);

            _lblSupporting = new MaterialLabel()
            {
                IsVisible = false,
                LineBreakMode = LineBreakMode.NoWrap,
                Margin = new Thickness(14, 2, 14, 0),
                HorizontalTextAlignment = TextAlignment.Start
            };

            _lblSupporting.SetValue(Grid.RowProperty, 2);

            _gridMain.Children.Add(_lblLabel);
            _gridMain.Children.Add(_grid);
            _gridMain.Children.Add(_lblSupporting);

            this.Content = _gridMain;
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
                case nameof(this.ItemSize):
                case nameof(this.ItemsByRow):
                case nameof(UnSelectedIcon):
                case nameof(CustomSelectedIcon):
                case nameof(SelectedIcon):
                case nameof(CustomUnSelectedIcon):
                case nameof(AnimationParameter):
                case nameof(Animation):
                    SetGridContent();
                    break;
                case nameof(LabelText):
                    _lblLabel.Text = LabelText;
                    _lblLabel.IsVisible = !string.IsNullOrEmpty(LabelText);
                    break;
                case nameof(LabelTextColor):
                    SetLabelTextColor();
                    break;
                case nameof(LabelSize):
                    _lblLabel.FontSize = LabelSize;
                    break;
                case nameof(SupportingText):
                    _lblSupporting.Text = SupportingText;
                    _lblSupporting.IsVisible = !string.IsNullOrEmpty(SupportingText);
                    if (AnimateError && !string.IsNullOrEmpty(SupportingText))
                        ShakeAnimation.Animate(this);
                    break;
                case nameof(SupportingTextColor):
                    _lblSupporting.TextColor = SupportingTextColor;
                    break;
                case nameof(SupportingSize):
                    _lblSupporting.FontSize = SupportingSize;
                    break;
            }

            base.OnPropertyChanged(propertyName);
        }

        private void SetGridContent()
        {
            if (!ItemSize.HasValue || (String.IsNullOrEmpty(SelectedIcon) && CustomSelectedIcon == null)
                                || (String.IsNullOrEmpty(UnSelectedIcon) && CustomUnSelectedIcon == null)
                                || !ItemsByRow.HasValue)
                return;

            // Populate grid
            int rows = (int)Math.Ceiling(ItemSize.Value * 1.0 / ItemsByRow.Value * 1.0);
            int populatedObjects = 0;
            double valuePerItem = 100.0 / (ItemSize.Value * 1.0);

            _grid.RowDefinitions = new RowDefinitionCollection();
            _grid.ColumnDefinitions = new ColumnDefinitionCollection();
            _grid.Children.Clear();

            // Set definitions of grid
            for (int i = 0; i < rows; i++)
                _grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

            for (int i = 0; i < ItemsByRow; i++)
                _grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ItemsByRow.Value / 100.0, GridUnitType.Star) });


            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < ItemsByRow.Value; j++)
                {
                    if (populatedObjects == ItemSize.Value)
                    {
                        break;
                    }

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

                    SetIconsRatingControl(customImageButton, Value, this);

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

        private void SetLabelTextColor()
        {
            _lblLabel.TextColor = LabelTextColor;
        }

        private static bool OnSupportingTextValidate(BindableObject bindable, object value)
        {
            var control = (MaterialRating)bindable;

            // Used to animate the error when the assistive text doesn't change
            if (control.AnimateError && !string.IsNullOrEmpty(control.SupportingText) && control.SupportingText == (string)value)
                ShakeAnimation.Animate(control);

            return true;
        }

        public static void OnValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is MaterialRating control && newValue != null && int.TryParse(newValue.ToString(), out int value))
            {
                foreach (CustomImageButton item in control._grid.Children)
                {
                    SetIconsRatingControl(item, value, control);
                }
            }
        }

        public static void SetIconsRatingControl(CustomImageButton item, int value, MaterialRating control)
        {
            if (item.CommandParameter != null && (int)item.CommandParameter <= value)
            {
                if (!string.IsNullOrEmpty(control.SelectedIcon))
                    item.SetImage(control.SelectedIcon);
                else if (control.CustomSelectedIcon != null)
                    item.SetCustomImage(control.CustomSelectedIcon.CreateContent() as View);
            }
            else
            {
                if (!string.IsNullOrEmpty(control.UnSelectedIcon))
                    item.SetImage(control.UnSelectedIcon);
                else if (control.CustomUnSelectedIcon != null)
                    item.SetCustomImage(control.CustomUnSelectedIcon.CreateContent() as View);
            }
        }

        #endregion Methods
    }
}
