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

        private Frame frmLayout;

        private StackLayout stcLayout;

        private Image imgIcon;

        private MaterialLabel lblText;

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

        public static readonly BindableProperty BusyBackgroundColorProperty =
            BindableProperty.Create(nameof(BusyBackgroundColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Transparent);

        public Color BusyBackgroundColor
        {
            get { return (Color)GetValue(BusyBackgroundColorProperty); }
            set { SetValue(BusyBackgroundColorProperty, value); }
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

        public static readonly BindableProperty BusyBorderColorProperty =
            BindableProperty.Create(nameof(BusyBorderColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Transparent);

        public Color BusyBorderColor
        {
            get { return (Color)GetValue(BusyBorderColorProperty); }
            set { SetValue(BusyBorderColorProperty, value); }
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

            this.frmLayout = new Frame
            {
                HasShadow = false,
                CornerRadius = 4,
                MinimumHeightRequest = 40,
                HeightRequest = 40,
                Padding = new Thickness(12, 0)
            };
            this.Content = this.frmLayout;

            this.stcLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 12,
                HorizontalOptions = LayoutOptions.Center,
            };
            this.frmLayout.Content = this.stcLayout;

            this.imgIcon = new Image
            {
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 24,
                HeightRequest = 24,
                IsVisible = false
            };
            this.stcLayout.Children.Add(this.imgIcon);

            this.lblText = new MaterialLabel
            {
                LineBreakMode = LineBreakMode.NoWrap,
                VerticalOptions = LayoutOptions.Center
            };
            this.stcLayout.Children.Add(this.lblText);

            this.actIndicator = new ActivityIndicator
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = 24,
                HeightRequest = 24,
                IsVisible = false
            };
            this.stcLayout.Children.Add(this.actIndicator);
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
                    this.lblText.Text = this.Text;
                    break;
                case nameof(this.TextColor):
                case nameof(this.DisabledTextColor):
                    this.lblText.TextColor = this.IsEnabled ? this.TextColor : this.DisabledTextColor;
                    break;
                case nameof(this.TextSize):
                    this.lblText.FontSize = this.TextSize;
                    break;
                case nameof(this.FontFamily):
                    this.lblText.FontFamily = this.FontFamily;
                    break;
                case nameof(this.CornerRadius):
                    this.frmLayout.CornerRadius = (float)this.CornerRadius;
                    break;
                case nameof(this.BackgroundColor):
                case nameof(this.DisabledBackgroundColor):
                    this.frmLayout.BackgroundColor = this.IsEnabled ? this.BackgroundColor : this.DisabledBackgroundColor;
                    break;
                case nameof(this.BorderColor):
                case nameof(this.DisabledBorderColor):
                    this.frmLayout.BorderColor = this.IsEnabled ? this.BorderColor : this.DisabledBorderColor;
                    break;
                case nameof(this.Icon):
                case nameof(this.DisabledIcon):
                    if (!string.IsNullOrEmpty(this.Icon) || !string.IsNullOrEmpty(this.DisabledIcon))
                    {
                        this.imgIcon.Source = this.IsEnabled ? this.Icon : this.DisabledIcon;
                        this.imgIcon.IsVisible = true;
                    }
                    break;
                case nameof(this.IsEnabled):
                    this.lblText.TextColor = this.IsEnabled ? this.TextColor : this.DisabledTextColor;
                    this.frmLayout.BackgroundColor = this.IsEnabled ? this.BackgroundColor : this.DisabledBackgroundColor;
                    this.frmLayout.BorderColor = this.IsEnabled ? this.BorderColor : this.DisabledBorderColor;
                    if (!string.IsNullOrEmpty(this.Icon) || !string.IsNullOrEmpty(this.DisabledIcon))
                    {
                        this.imgIcon.Source = this.IsEnabled ? this.Icon : this.DisabledIcon;
                        this.imgIcon.IsVisible = true;
                    }
                    break;
                case nameof(this.BusyColor):
                    this.actIndicator.Color = this.BusyColor;
                    break;
                case nameof(this.IsBusy):
                    if (this.IsBusy)
                    {
                        this.lblText.IsVisible = false;
                        this.imgIcon.IsVisible = false;
                        this.actIndicator.IsVisible = true;
                        this.actIndicator.IsRunning = true;
                        this.frmLayout.BackgroundColor = this.BusyBackgroundColor;
                        this.frmLayout.BorderColor = this.BusyBorderColor;
                    }
                    else
                    {
                        this.lblText.IsVisible = true;
                        this.imgIcon.IsVisible = !string.IsNullOrEmpty(this.Icon) || !string.IsNullOrEmpty(this.DisabledIcon);
                        this.actIndicator.IsVisible = false;
                        this.actIndicator.IsRunning = false;
                        this.frmLayout.BackgroundColor = this.IsEnabled ? this.BackgroundColor : this.DisabledBackgroundColor;
                        this.frmLayout.BorderColor = this.IsEnabled ? this.BorderColor : this.DisabledBorderColor;
                    }
                    break;
                case nameof(this.Command):
                    var selectionTapGestureRecognizer = new TapGestureRecognizer();
                    selectionTapGestureRecognizer.Tapped += (s, e) =>
                    {
                        if (this.IsEnabled && this.Command != null && this.Command.CanExecute(this.CommandParameter))
                        {
                            this.Command.Execute(this.CommandParameter);
                        }
                    };
                    this.GestureRecognizers.Clear();
                    this.GestureRecognizers.Add(selectionTapGestureRecognizer);
                    break;
            }
        }

        #endregion Methods
    }
}
