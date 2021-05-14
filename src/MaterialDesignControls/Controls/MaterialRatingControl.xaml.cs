using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Implementations;
using System;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialRatingControl : ContentView
    {
        #region Constructors
        public MaterialRatingControl()
        {
            if (!this.initialized)
            {
                this.initialized = true;
                this.InitializeComponent();
            }
        }
        #endregion

        #region attributes
        private bool initialized = false;
        #endregion

        #region properties
        

        public static readonly BindableProperty SelectedIconProperty =
            BindableProperty.Create(nameof(SelectedIcon), typeof(string), typeof(MaterialRatingControl), defaultValue: null);

        public string SelectedIcon
        {
            get { return (string)GetValue(SelectedIconProperty); }
            set { SetValue(SelectedIconProperty, value); }
        }

        public static readonly BindableProperty CustomSelectedIconProperty =
            BindableProperty.Create(nameof(CustomSelectedIcon), typeof(DataTemplate), typeof(MaterialRatingControl), defaultValue: null);

        public DataTemplate CustomSelectedIcon
        {
            get { return (DataTemplate)GetValue(CustomSelectedIconProperty); }
            set { SetValue(CustomSelectedIconProperty, value); }
        }

        public static readonly BindableProperty UnSelectedIconProperty =
            BindableProperty.Create(nameof(UnSelectedIcon), typeof(string), typeof(MaterialRatingControl), defaultValue: null);

        public string UnSelectedIcon
        {
            get { return (string)GetValue(UnSelectedIconProperty); }
            set { SetValue(UnSelectedIconProperty, value); }
        }

        public static readonly BindableProperty CustomUnSelectedIconProperty =
            BindableProperty.Create(nameof(CustomUnSelectedIcon), typeof(DataTemplate), typeof(MaterialRatingControl), defaultValue: null);

        public DataTemplate CustomUnSelectedIcon
        {
            get { return (DataTemplate)GetValue(CustomUnSelectedIconProperty); }
            set { SetValue(CustomUnSelectedIconProperty, value); }
        }

        public static readonly BindableProperty ItemSizeProperty =
           BindableProperty.Create(nameof(ItemSize), typeof(int?), typeof(MaterialRatingControl), defaultValue: null);

        public int? ItemSize
        {
            get { return (int?)GetValue(ItemSizeProperty); }
            set { SetValue(ItemSizeProperty, value); }
        }

        public static readonly BindableProperty ItemsByRowProperty =
           BindableProperty.Create(nameof(ItemsByRow), typeof(int?), typeof(MaterialRatingControl), defaultValue: null);

        public int? ItemsByRow
        {
            get { return (int?)GetValue(ItemsByRowProperty); }
            set { SetValue(ItemsByRowProperty, value); }
        }

        public static readonly new BindableProperty IsEnabledProperty =
            BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(MaterialRatingControl), defaultValue: true);

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public static readonly BindableProperty ValueProperty =
           BindableProperty.Create(nameof(Value), typeof(int), typeof(MaterialRatingControl)
               , defaultBindingMode: BindingMode.TwoWay, defaultValue: -1, propertyChanged: OnValuePropertyChanged);

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly BindableProperty AnimationProperty =
                    BindableProperty.Create(nameof(Animation), typeof(AnimationTypes), typeof(MaterialButton), defaultValue: AnimationTypes.None);

        public AnimationTypes Animation
        {
            get { return (AnimationTypes)GetValue(AnimationProperty); }
            set { SetValue(AnimationProperty, value); }
        }

        public static readonly BindableProperty AnimationParameterProperty =
            BindableProperty.Create(nameof(AnimationParameter), typeof(double?), typeof(MaterialButton), defaultValue: null);

        public double? AnimationParameter
        {
            get { return (double?)GetValue(AnimationParameterProperty); }
            set { SetValue(AnimationParameterProperty, value); }
        }

        #region LabelText
        public static readonly BindableProperty LabelTextProperty =
            BindableProperty.Create(nameof(LabelText), typeof(string), typeof(MaterialRatingControl), defaultValue: null);

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public static readonly BindableProperty LabelTextColorProperty =
            BindableProperty.Create(nameof(LabelTextColor), typeof(Color), typeof(MaterialRatingControl), defaultValue: Color.Gray);

        public Color LabelTextColor
        {
            get { return (Color)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public static readonly BindableProperty LabelSizeProperty =
            BindableProperty.Create(nameof(LabelSize), typeof(double), typeof(MaterialRatingControl), defaultValue: Font.Default.FontSize);

        public double LabelSize
        {
            get { return (double)GetValue(LabelSizeProperty); }
            set { SetValue(LabelSizeProperty, value); }
        }
        #endregion

        #region AssistiveText

        public static readonly BindableProperty AssistiveTextProperty =
            BindableProperty.Create(nameof(AssistiveText), typeof(string), typeof(MaterialRatingControl), defaultValue: null, validateValue: OnAssistiveTextValidate);

        public string AssistiveText
        {
            get { return (string)GetValue(AssistiveTextProperty); }
            set { SetValue(AssistiveTextProperty, value); }
        }

        public static readonly BindableProperty AssistiveTextColorProperty =
            BindableProperty.Create(nameof(AssistiveTextColor), typeof(Color), typeof(MaterialRatingControl), defaultValue: Color.Gray);

        public Color AssistiveTextColor
        {
            get { return (Color)GetValue(AssistiveTextColorProperty); }
            set { SetValue(AssistiveTextColorProperty, value); }
        }

        public static readonly BindableProperty AssistiveSizeProperty =
            BindableProperty.Create(nameof(AssistiveSize), typeof(double), typeof(MaterialRatingControl), defaultValue: Font.Default.FontSize);

        public double AssistiveSize
        {
            get { return (double)GetValue(AssistiveSizeProperty); }
            set { SetValue(AssistiveSizeProperty, value); }
        }


        public static readonly BindableProperty AnimateErrorProperty =
           BindableProperty.Create(nameof(AnimateError), typeof(bool), typeof(MaterialRatingControl), defaultValue: false);

        public bool AnimateError
        {
            get { return (bool)GetValue(AnimateErrorProperty); }
            set { SetValue(AnimateErrorProperty, value); }
        }

        #endregion AssistiveText
        #endregion

        #region methods
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!this.initialized)
            {
                this.initialized = true;
                this.InitializeComponent();
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
                    lblLabel.Text = LabelText;
                    lblLabel.IsVisible = !string.IsNullOrEmpty(LabelText);
                    break;
                case nameof(LabelTextColor):
                    SetLabelTextColor();
                    break;
                case nameof(LabelSize):
                    lblLabel.FontSize = LabelSize;
                    break;
                case nameof(AssistiveText):
                    lblAssistive.Text = AssistiveText;
                    lblAssistive.IsVisible = !string.IsNullOrEmpty(AssistiveText);
                    if (AnimateError && !string.IsNullOrEmpty(AssistiveText))
                        ShakeAnimation.Animate(this);
                    break;
                case nameof(AssistiveTextColor):
                    lblAssistive.TextColor = AssistiveTextColor;
                    break;
                case nameof(AssistiveSize):
                    lblAssistive.FontSize = AssistiveSize;
                    break;
            }

            base.OnPropertyChanged(propertyName);

        }

        private void SetGridContent()
        {
            try
            {
                if (!ItemSize.HasValue || (String.IsNullOrEmpty(SelectedIcon) && CustomSelectedIcon == null)
                    || (String.IsNullOrEmpty(UnSelectedIcon) && CustomUnSelectedIcon == null)
                    || !ItemsByRow.HasValue)
                    return;

                //populate grid
                int rows = (int)Math.Ceiling(ItemSize.Value * 1.0 / ItemsByRow.Value * 1.0);
                int populatedObjects = 0;
                double valuePerItem = 100.0 / (ItemSize.Value * 1.0);

                grid.RowDefinitions = new RowDefinitionCollection();
                grid.ColumnDefinitions = new ColumnDefinitionCollection();
                grid.Children.Clear();

                // set definitions of grid
                for (int i = 0; i < rows; i++)
                    grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                for(int i = 0; i < ItemsByRow; i++)
                    grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(ItemsByRow.Value / 100.0, GridUnitType.Star) });


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

                        // add element at i,j position on grid
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
                            CommandParameter = value,
                            Animation = Animation,
                        };

                        if (AnimationParameter.HasValue)
                            customImageButton.AnimationParameter = AnimationParameter;

                        customImageButton.SetValue(Grid.RowProperty, i);
                        customImageButton.SetValue(Grid.ColumnProperty, j);

                        SetIconsRatingControl(customImageButton, Value, this);
                            
                        grid.Children.Add(customImageButton);
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        private void OnTapped(int value)
        {
            if(IsEnabled)
            {
                if (Value == value)
                {
                    Value = -1;
                }
                else
                {
                    Value = value;
                }
            }
            
        }

        private void SetLabelTextColor()
        {
            lblLabel.TextColor = LabelTextColor;
        }

        private static bool OnAssistiveTextValidate(BindableObject bindable, object value)
        {
            var control = (MaterialRatingControl)bindable;

            // Used to animate the error when the assistive text doesn't change
            if (control.AnimateError && !string.IsNullOrEmpty(control.AssistiveText) && control.AssistiveText == (string)value)
                ShakeAnimation.Animate(control);

            return true;
        }


        public static void OnValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is MaterialRatingControl control && newValue != null && int.TryParse(newValue.ToString(), out int value))
            {
                foreach (CustomImageButton item in control.grid.Children)
                {
                    SetIconsRatingControl(item, value, control);
                }
            }
        }

        public static void SetIconsRatingControl(CustomImageButton item, int value, MaterialRatingControl control)
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

        #endregion
    }
}