using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls
{
    public class MaterialButton : ContentView
    {
        #region Constructors

        public MaterialButton()
        {
            if (!this.initialized)
            {
                this.Initialize();
            }
        }

        #endregion Constructors

        #region Attributes

        private bool initialized = false;

        protected Button button;

        private Grid grid;

        private ActivityIndicator actIndicator;

        #endregion Attributes

        #region Properties

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(MaterialButton), defaultValue: null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(MaterialButton), defaultValue: null);

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialButton), defaultValue: null);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(MaterialButton), defaultValue: 4.0);

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty IsBusyProperty =
            BindableProperty.Create(nameof(IsBusy), typeof(bool), typeof(MaterialButton), defaultValue: false);

        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { SetValue(IsBusyProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Black);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledTextColorProperty =
            BindableProperty.Create(nameof(DisabledTextColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Gray);

        public Color DisabledTextColor
        {
            get { return (Color)GetValue(DisabledTextColorProperty); }
            set { SetValue(DisabledTextColorProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Transparent);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty DisabledBackgroundColorProperty =
            BindableProperty.Create(nameof(DisabledBackgroundColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Transparent);

        public Color DisabledBackgroundColor
        {
            get { return (Color)GetValue(DisabledBackgroundColorProperty); }
            set { SetValue(DisabledBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty BusyColorProperty =
            BindableProperty.Create(nameof(BusyColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Black);

        public Color BusyColor
        {
            get { return (Color)GetValue(BusyColorProperty); }
            set { SetValue(BusyColorProperty, value); }
        }

        public static readonly BindableProperty TextSizeProperty =
            BindableProperty.Create(nameof(TextSize), typeof(double), typeof(MaterialButton), defaultValue: Font.Default.FontSize);

        public double TextSize
        {
            get { return (double)GetValue(TextSizeProperty); }
            set { SetValue(TextSizeProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(MaterialButton), defaultValue: null);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Transparent);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty DisabledBorderColorProperty =
            BindableProperty.Create(nameof(DisabledBorderColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Transparent);

        public Color DisabledBorderColor
        {
            get { return (Color)GetValue(DisabledBorderColorProperty); }
            set { SetValue(DisabledBorderColorProperty, value); }
        }

        public static readonly BindableProperty IconProperty =
            BindableProperty.Create(nameof(Icon), typeof(string), typeof(MaterialButton), defaultValue: null);

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly BindableProperty DisabledIconProperty =
            BindableProperty.Create(nameof(DisabledIcon), typeof(string), typeof(MaterialButton), defaultValue: null);

        public string DisabledIcon
        {
            get { return (string)GetValue(DisabledIconProperty); }
            set { SetValue(DisabledIconProperty, value); }
        }

        #endregion Properties

        #region Methods

        private void Initialize()
        {
            this.initialized = true;

            this.grid = new Grid
            {
                MinimumHeightRequest = 40,
                HeightRequest = 40,
            };
            this.Content = this.grid;

            this.actIndicator = new ActivityIndicator
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 24,
                HeightRequest = 24,
                IsRunning = false,
                IsVisible = false
            };
            this.grid.Children.Add(this.actIndicator, 0, 0);

            this.button = new Button
            {
                CornerRadius = 4,
                Padding = new Thickness(12, 0)
            };
            this.grid.Children.Add(this.button, 0, 0);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!this.initialized)
            {
                this.Initialize();
            }

            switch (propertyName)
            {
                case nameof(this.Text):
                    this.button.Text = this.Text;
                    break;
                case nameof(this.TextColor):
                case nameof(this.DisabledTextColor):
                    this.button.TextColor = this.IsEnabled ? this.TextColor : this.DisabledTextColor;
                    break;
                case nameof(this.TextSize):
                    this.button.FontSize = this.TextSize;
                    break;
                case nameof(this.FontFamily):
                    this.button.FontFamily = this.FontFamily;
                    break;
                case nameof(this.CornerRadius):
                    this.button.CornerRadius = Convert.ToInt32(this.CornerRadius);
                    break;
                case nameof(this.BackgroundColor):
                case nameof(this.DisabledBackgroundColor):
                    this.button.BackgroundColor = this.IsEnabled ? this.BackgroundColor : this.DisabledBackgroundColor;
                    break;
                case nameof(this.BorderColor):
                case nameof(this.DisabledBorderColor):
                    this.button.BorderColor = this.IsEnabled ? this.BorderColor : this.DisabledBorderColor;
                    break;
                case nameof(this.Icon):
                case nameof(this.DisabledIcon):
                    if (!string.IsNullOrEmpty(this.Icon) || !string.IsNullOrEmpty(this.DisabledIcon))
                    {
                        this.button.ImageSource = this.IsEnabled ? this.Icon : this.DisabledIcon;
                    }
                    break;
                case nameof(this.IsEnabled):
                    this.button.TextColor = this.IsEnabled ? this.TextColor : this.DisabledTextColor;
                    this.button.BackgroundColor = this.IsEnabled ? this.BackgroundColor : this.DisabledBackgroundColor;
                    this.button.BorderColor = this.IsEnabled ? this.BorderColor : this.DisabledBorderColor;
                    if (!string.IsNullOrEmpty(this.Icon) || !string.IsNullOrEmpty(this.DisabledIcon))
                    {
                        this.button.ImageSource = this.IsEnabled ? this.Icon : this.DisabledIcon;
                    }
                    break;
                case nameof(this.BusyColor):
                    this.actIndicator.Color = this.BusyColor;
                    break;
                case nameof(this.IsBusy):
                    if (this.IsBusy)
                    {
                        this.actIndicator.IsVisible = true;
                        this.actIndicator.IsRunning = true;
                        this.button.IsVisible = false;
                    }
                    else
                    {
                        this.actIndicator.IsVisible = false;
                        this.actIndicator.IsRunning = false;
                        this.button.IsVisible = true;
                    }
                    break;
                case nameof(this.Command):
                    this.button.Command = this.Command;
                    break;
                case nameof(this.CommandParameter):
                    this.button.CommandParameter = this.CommandParameter;
                    break;
            }
        }

        #endregion Methods
    }
}
