using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Plugin.MaterialDesignControls.Implementations;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls
{
    public partial class MaterialSegmented : ContentView
    {
        #region Attributes

        private bool initialized = false;

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

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialSegmented), defaultValue: Color.White);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty DisabledBackgroundColorProperty =
            BindableProperty.Create(nameof(DisabledBackgroundColor), typeof(Color), typeof(MaterialSegmented), defaultValue: Color.White);

        public Color DisabledBackgroundColor
        {
            get { return (Color)GetValue(DisabledBackgroundColorProperty); }
            set { SetValue(DisabledBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty SelectedColorProperty =
            BindableProperty.Create(nameof(SelectedColor), typeof(Color), typeof(MaterialSegmented), defaultValue: Color.FromHex("#2e85cc"));

        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        public static readonly BindableProperty DisabledSelectedColorProperty =
            BindableProperty.Create(nameof(DisabledSelectedColor), typeof(Color), typeof(MaterialSegmented), defaultValue: Color.LightGray);

        public Color DisabledSelectedColor
        {
            get { return (Color)GetValue(DisabledSelectedColorProperty); }
            set { SetValue(DisabledSelectedColorProperty, value); }
        }

        public static readonly BindableProperty UnselectedColorProperty =
            BindableProperty.Create(nameof(UnselectedColor), typeof(Color), typeof(MaterialSegmented), defaultValue: Color.White);

        public Color UnselectedColor
        {
            get { return (Color)GetValue(UnselectedColorProperty); }
            set { SetValue(UnselectedColorProperty, value); }
        }

        public static readonly BindableProperty DisabledUnselectedColorProperty =
            BindableProperty.Create(nameof(DisabledUnselectedColor), typeof(Color), typeof(MaterialSegmented), defaultValue: Color.White);

        public Color DisabledUnselectedColor
	    {
            get { return (Color)GetValue(DisabledUnselectedColorProperty); }
            set { SetValue(DisabledUnselectedColorProperty, value); }
        }


        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<string>), typeof(MaterialSegmented), defaultValue: null, propertyChanged: OnItemsSourceChanged);

        public IEnumerable<string> ItemsSource
        {
            get { return (IEnumerable<string>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(nameof(SelectedItem), typeof(string), typeof(MaterialSegmented), defaultValue: null, BindingMode.TwoWay);

        public string SelectedItem
        {
            get { return (string)GetValue(SelectedItemProperty); }
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
            BindableProperty.Create(nameof(HeightRequest), typeof(double), typeof(MaterialSegmented), defaultValue: 32.0);

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
            BindableProperty.Create(nameof(SelectedTextColor), typeof(Color), typeof(MaterialSegmented), defaultValue: Color.White);

        public Color SelectedTextColor
        {
            get { return (Color)GetValue(SelectedTextColorProperty); }
            set { SetValue(SelectedTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledSelectedTextColorProperty =
            BindableProperty.Create(nameof(DisabledSelectedTextColor), typeof(Color), typeof(MaterialSegmented), defaultValue: Color.White);

        public Color DisabledSelectedTextColor
        {
            get { return (Color)GetValue(DisabledSelectedTextColorProperty); }
            set { SetValue(DisabledSelectedTextColorProperty, value); }
        }

        public static readonly BindableProperty UnselectedTextColorProperty =
            BindableProperty.Create(nameof(UnselectedTextColor), typeof(Color), typeof(MaterialSegmented), defaultValue: Color.Gray);

        public Color UnselectedTextColor
        {
            get { return (Color)GetValue(UnselectedTextColorProperty); }
            set { SetValue(UnselectedTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledUnselectedTextColorProperty =
            BindableProperty.Create(nameof(DisabledUnselectedTextColor), typeof(Color), typeof(MaterialSegmented), defaultValue: Color.LightGray);

        public Color DisabledUnselectedTextColor
        {
            get { return (Color)GetValue(DisabledUnselectedTextColorProperty ); }
            set { SetValue(DisabledUnselectedTextColorProperty , value); }
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
            BindableProperty.Create(nameof(DisabledBorderColor), typeof(Color), typeof(MaterialSegmented), defaultValue: Color.LightGray);

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

        #endregion Properties

        #region Methods

        private void Initialize()
        {
            mainFrame.CornerRadius = (float)CornerRadius;
            mainFrame.BackgroundColor = BackgroundColor;
            mainFrame.HeightRequest = HeightRequest;
            mainFrame.MinimumHeightRequest = 32;
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
                    mainFrame.CornerRadius = (float)CornerRadius;
                    foreach (var item in ((Grid)mainFrame.Content).Children)
                        ((CustomFrame)item).CornerRadius = (float)CornerRadius;
                    break;
                case nameof(BackgroundColor):
                    mainFrame.BackgroundColor = IsEnabled ? BackgroundColor : DisabledBackgroundColor;
                    break;
                case nameof(HeightRequest):
                    mainFrame.HeightRequest = HeightRequest;
                    break;
            }
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialSegmented)bindable;
            control.grid.ColumnDefinitions = new ColumnDefinitionCollection();
            control.grid.Children.Clear();

            int column = 0;
            if (!Equals(newValue, null) && newValue is IEnumerable)
            {
                foreach (var item in (IEnumerable)newValue)
                {
                    control.mainFrame.BackgroundColor = 
			            control.IsEnabled ? control.BackgroundColor : control.DisabledBackgroundColor;
                    control.grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                    var frame = new CustomFrame();
                    frame.HasShadow = false;
                    frame.Padding = new Thickness(10,0);
                    frame.HorizontalOptions = LayoutOptions.Fill;
                    frame.Margin = new Thickness(control.SegmentMargin);
                    frame.BackgroundColor =
                        control.IsEnabled ? control.UnselectedColor : control.DisabledUnselectedColor;
                    frame.CornerRadius =
                        (control.CornerRadius - control.SegmentMargin) >= 0 ? ((float)control.CornerRadius - control.SegmentMargin) : 0;

                    var label = new MaterialLabel();
                    label.Text = item.ToString().Trim();
                    label.HorizontalOptions = LayoutOptions.Center;
                    label.VerticalOptions = LayoutOptions.Center;
                    label.FontSize = control.FontSize;
                    label.FontFamily = control.FontFamily;
                    label.TextColor =
                        control.IsEnabled ? control.UnselectedTextColor : control.DisabledUnselectedTextColor;

                    var tapped = new TapGestureRecognizer();
                    tapped.Tapped += (s, e) =>
                    {
                        if (!control.IsEnabled)
                            return;


                        if (control is MaterialSegmented)
                        {
                            foreach (var item in control.grid.Children)
                            {
                                ((CustomFrame)item).BackgroundColor = control.UnselectedColor;
                                ((MaterialLabel)(((CustomFrame)item).Content)).TextColor = control.UnselectedTextColor;
                            }

                            frame.BackgroundColor = control.SelectedColor;
                            label.TextColor = control.SelectedTextColor;
                            control.SelectedItem = label.Text.Trim();
                        }

                        if (CommandProperty != null && control.Command != null)
                            control.Command.Execute(control.CommandParameter);

                        control.IsSelectedChanged?.Invoke(control, null);
                    };

                    if (control.SelectedItem != null)
                    { 
                        if (label.Text.Equals(control.SelectedItem))
                        {
                            frame.BackgroundColor =
                                control.IsEnabled ? control.SelectedColor : control.DisabledSelectedColor;
                            label.TextColor =
                                control.IsEnabled ? control.SelectedTextColor : control.DisabledSelectedTextColor;
			            }
		            }
                    else 
		            { 
                        if (column < 1)
                        {
                            frame.BackgroundColor = control.IsEnabled ? control.SelectedColor : control.DisabledSelectedColor;
                            label.TextColor =
                                control.IsEnabled ? control.SelectedTextColor : control.DisabledSelectedTextColor;
                            control.SelectedItem = item.ToString().Trim();
			            }
		            }

                    frame.Content = label;
                    frame.GestureRecognizers.Add(tapped);
                    control.grid.Children.Add(frame, column, 0);
                    column++;
                }
            }
        }
        #endregion Methods
    }
}
