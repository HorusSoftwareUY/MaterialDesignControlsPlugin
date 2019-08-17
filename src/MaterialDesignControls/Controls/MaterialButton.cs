using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls
{
    public class MaterialButton : Frame
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

        private StackLayout stcLayout;

        private Image imgIcon;

        private MaterialLabel lblText;

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

        public static readonly new BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Transparent);

        public new Color BorderColor
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

            this.HasShadow = false;
            this.CornerRadius = 4;
            this.MinimumHeightRequest = 40;
            this.HeightRequest = 40;
            this.Padding = new Thickness(12, 0);

            this.stcLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 12,
                HorizontalOptions = LayoutOptions.Center,
            };
            CompressedLayout.SetIsHeadless(this.stcLayout, true);
            this.Content = this.stcLayout;

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
                case nameof(this.BackgroundColor):
                case nameof(this.DisabledBackgroundColor):
                    base.BackgroundColor = this.IsEnabled ? this.BackgroundColor : this.DisabledBackgroundColor;
                    break;
                case nameof(this.BorderColor):
                case nameof(this.DisabledBorderColor):
                    base.BorderColor = this.IsEnabled ? this.BorderColor : this.DisabledBorderColor;
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
                    base.BackgroundColor = this.IsEnabled ? this.BackgroundColor : this.DisabledBackgroundColor;
                    base.BorderColor = this.IsEnabled ? this.BorderColor : this.DisabledBorderColor;
                    if (!string.IsNullOrEmpty(this.Icon) || !string.IsNullOrEmpty(this.DisabledIcon))
                    {
                        this.imgIcon.Source = this.IsEnabled ? this.Icon : this.DisabledIcon;
                        this.imgIcon.IsVisible = true;
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
