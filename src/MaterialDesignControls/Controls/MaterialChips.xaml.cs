using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls
{
    public partial class MaterialChips : ContentView
    {
        #region Constructors

        public MaterialChips()
        {
            InitializeComponent();

            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) =>
            {
                if (CommandProperty != null && this.Command != null)
                {
                    Opacity = .5;
                    Opacity = 1;
                    this.Command.Execute(this.CommandParameter);
                }
                else
                {
                    this.IsSelected = !this.IsSelected;
                }
            };
            this.GestureRecognizers.Add(tapGestureRecognizer);
        }

        #endregion Constructors

        #region Attributes

        #endregion Attributes

        #region Properties

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(MaterialChips));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(MaterialChips), defaultValue: null);

        public object CommandParameter
        {
            get { return GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly BindableProperty IsSelectedProperty =
            BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(MaterialChips), defaultValue: null, propertyChanged: OnPropertyChanged);

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public static readonly new BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(MaterialChips), defaultValue: new Thickness(12, 0), propertyChanged: OnPaddingChanged);

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialChips), defaultValue: null, propertyChanged: OnTextChanged);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialChips), defaultValue: Color.Gray, propertyChanged: OnPropertyChanged);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty SelectedTextColorProperty =
            BindableProperty.Create(nameof(SelectedTextColor), typeof(Color), typeof(MaterialChips), defaultValue: Color.Black, propertyChanged: OnPropertyChanged);

        public Color SelectedTextColor
        {
            get { return (Color)GetValue(SelectedTextColorProperty); }
            set { SetValue(SelectedTextColorProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialChips), defaultValue: Color.LightGray, propertyChanged: OnPropertyChanged);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty SelectedBackgroundColorProperty =
            BindableProperty.Create(nameof(SelectedBackgroundColor), typeof(Color), typeof(MaterialChips), defaultValue: Color.Gray, propertyChanged: OnPropertyChanged);

        public Color SelectedBackgroundColor
        {
            get { return (Color)GetValue(SelectedBackgroundColorProperty); }
            set { SetValue(SelectedBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty = 
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MaterialChips), defaultValue: 14.0, propertyChanged: OnFontSizeChanged);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        #endregion Properties

        #region Methods

        private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialChips)bindable;
            control.lblText.Text = (string)newValue;
        }

        private static void OnPaddingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialChips)bindable;
            control.frmContainer.Padding = (Thickness)newValue;
        }

        private static void OnFontSizeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialChips)bindable;
            control.lblText.FontSize = (double)newValue;
        }

        private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialChips)bindable;
            control.ApplyControlProperties();
        }

        private void ApplyControlProperties()
        {
            if (this.IsSelected)
            {
                this.lblText.TextColor = this.SelectedTextColor;
                this.frmContainer.BackgroundColor = this.SelectedBackgroundColor;
            }
            else
            {
                this.lblText.TextColor = this.TextColor;
                this.frmContainer.BackgroundColor = this.BackgroundColor;
            }
        }

        #endregion Methods
    }
}
