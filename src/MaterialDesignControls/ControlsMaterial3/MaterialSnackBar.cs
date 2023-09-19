using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Plugin.MaterialDesignControls.Implementations;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Plugin.MaterialDesignControls.Styles;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3
{
    public class MaterialSnackBar : ContentView
    {
        public CustomFrame _mainContainer;

        public Grid _gridContainer;

        public Grid _superGridContainer;

        private MaterialLabel _lblText;

        private MaterialIconButton _leadingIconButton;

        private MaterialIconButton _trailingIconButton;

        private Plugin.MaterialDesignControls.Material3.MaterialButton _actionButton;

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialSnackBar), defaultValue: DefaultStyles.InverseSurfaceColor);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty ShadowColorProperty =
            BindableProperty.Create(nameof(ShadowColor), typeof(Color), typeof(MaterialSnackBar), defaultValue: DefaultStyles.ShadowColor);

        public Color ShadowColor
        {
            get { return (Color)GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }

        public static readonly BindableProperty HasShadowProperty =
            BindableProperty.Create(nameof(HasShadow), typeof(bool), typeof(MaterialSnackBar), defaultValue: true);

        public bool HasShadow
        {
            get { return (bool)GetValue(HasShadowProperty); }
            set { SetValue(HasShadowProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(MaterialSnackBar), defaultValue: 4);

        public int CornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialButton), defaultValue: "Text");

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialButton), defaultValue: DefaultStyles.OnPrimaryColor);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MaterialButton), defaultValue: DefaultStyles.PhoneFontSizes.BodyMedium);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(MaterialButton), defaultValue: DefaultStyles.FontFamily);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public static readonly BindableProperty ActionTextProperty =
            BindableProperty.Create(nameof(ActionText), typeof(string), typeof(MaterialButton), defaultValue: null);

        public string ActionText
        {
            get { return (string)GetValue(ActionTextProperty); }
            set { SetValue(ActionTextProperty, value); }
        }

        public static readonly BindableProperty ActionTextColorProperty =
            BindableProperty.Create(nameof(ActionTextColor), typeof(Color), typeof(MaterialButton), defaultValue: DefaultStyles.PrimaryContainerColor);

        public Color ActionTextColor
        {
            get { return (Color)GetValue(ActionTextColorProperty); }
            set { SetValue(ActionTextColorProperty, value); }
        }

        public static readonly BindableProperty ActionFontSizeProperty =
            BindableProperty.Create(nameof(ActionFontSize), typeof(double), typeof(MaterialButton), defaultValue: DefaultStyles.PhoneFontSizes.LabelLarge);

        public double ActionFontSize
        {
            get { return (double)GetValue(ActionFontSizeProperty); }
            set { SetValue(ActionFontSizeProperty, value); }
        }

        public static readonly BindableProperty ActionFontFamilyProperty =
            BindableProperty.Create(nameof(ActionFontFamily), typeof(string), typeof(MaterialButton), defaultValue: DefaultStyles.FontFamily);

        public string ActionFontFamily
        {
            get { return (string)GetValue(ActionFontFamilyProperty); }
            set { SetValue(ActionFontFamilyProperty, value); }
        }

        public static readonly BindableProperty ActionCommandProperty =
            BindableProperty.Create(nameof(ActionCommand), typeof(ICommand), typeof(MaterialButton), defaultValue: null);

        public ICommand ActionCommand
        {
            get { return (ICommand)GetValue(ActionCommandProperty); }
            set { SetValue(ActionCommandProperty, value); }
        }

        public static readonly BindableProperty ActionCommandParameterProperty =
            BindableProperty.Create(nameof(ActionCommandParameter), typeof(object), typeof(MaterialButton), defaultValue: null);

        public object ActionCommandParameter
        {
            get { return (object)GetValue(ActionCommandParameterProperty); }
            set { SetValue(ActionCommandParameterProperty, value); }
        }

        public static readonly BindableProperty LeadingIconProperty =
            BindableProperty.Create(nameof(LeadingIcon), typeof(string), typeof(MaterialButton), defaultValue: null);

        public string LeadingIcon
        {
            get { return (string)GetValue(LeadingIconProperty); }
            set { SetValue(LeadingIconProperty, value); }
        }

        public static readonly BindableProperty CustomLeadingIconProperty =
            BindableProperty.Create(nameof(CustomLeadingIcon), typeof(View), typeof(MaterialButton), defaultValue: null);

        public View CustomLeadingIcon
        {
            get { return (View)GetValue(CustomLeadingIconProperty); }
            set { SetValue(CustomLeadingIconProperty, value); }
        }

        private bool LeadingIconIsVisible
        {
            get { return !string.IsNullOrEmpty(LeadingIcon) || CustomLeadingIcon != null; }
        }

        private bool TrailingIconIsVisible
        {
            get { return !string.IsNullOrEmpty(TrailingIcon) || CustomTrailingIcon != null; }
        }

        public static readonly BindableProperty TrailingIconProperty =
            BindableProperty.Create(nameof(TrailingIcon), typeof(string), typeof(MaterialButton), defaultValue: null);

        public string TrailingIcon
        {
            get { return (string)GetValue(TrailingIconProperty); }
            set { SetValue(TrailingIconProperty, value); }
        }

        public static readonly BindableProperty CustomTrailingIconProperty =
            BindableProperty.Create(nameof(CustomTrailingIcon), typeof(View), typeof(MaterialButton), defaultValue: null);

        public View CustomTrailingIcon
        {
            get { return (View)GetValue(CustomTrailingIconProperty); }
            set { SetValue(CustomTrailingIconProperty, value); }
        }

        public static readonly BindableProperty LeadingIconCommandProperty =
           BindableProperty.Create(nameof(LeadingIconCommand), typeof(ICommand), typeof(MaterialTopAppBar), null, BindingMode.OneTime);

        public ICommand LeadingIconCommand
        {
            get => (ICommand)GetValue(LeadingIconCommandProperty);
            set => SetValue(LeadingIconCommandProperty, value);
        }

        public static readonly BindableProperty TrailingIconCommandProperty =
           BindableProperty.Create(nameof(TrailingIconCommand), typeof(ICommand), typeof(MaterialTopAppBar), null, BindingMode.OneTime);

        public ICommand TrailingIconCommand
        {
            get => (ICommand)GetValue(TrailingIconCommandProperty);
            set => SetValue(TrailingIconCommandProperty, value);
        }

        public static readonly BindableProperty IconSizeProperty =
            BindableProperty.Create(nameof(IconSize), typeof(int), typeof(MaterialSnackBar), defaultValue: 48);

        public int IconSize
        {
            get { return (int)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }

        public MaterialSnackBar()
        {
            _gridContainer = new Grid
            {
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
                BackgroundColor = BackgroundColor,
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Auto }
                },
                RowDefinitions =
                {
                    new RowDefinition { Height = GridLength.Auto }
                },
            };

            _lblText = new MaterialLabel()
            {
                VerticalOptions = LayoutOptions.Center,
                Margin = new Thickness(16, 6),
                TextColor = TextColor,
                FontFamily = FontFamily,
                FontSize = FontSize,
                Text = Text
            };

            _actionButton = new MaterialButton()
            {
                ButtonType = MaterialButtonType.Text,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0, 4, 8, 4),
                TextColor = ActionTextColor,
                FontFamily = ActionFontFamily,
                FontSize = ActionFontSize,
                Padding = 0,
            };

            _leadingIconButton = new MaterialIconButton()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,
                Margin = new Thickness(12, 0, 0, 0),
                HeightRequest = IconSize,
                WidthRequest = IconSize,
                ButtonType = MaterialIconButtonType.Standard,
                IsVisible = false
            };

            _trailingIconButton = new MaterialIconButton()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.End,
                Margin = new Thickness(0, 0, 12, 0),
                HeightRequest = IconSize,
                WidthRequest = IconSize,
                ButtonType = MaterialIconButtonType.Standard,
                IsVisible = false
            };

            _gridContainer.Children.Add(_leadingIconButton, 0, 0);
            _gridContainer.Children.Add(_lblText, 1, 0);
            _gridContainer.Children.Add(_actionButton, 2, 0);
            _gridContainer.Children.Add(_trailingIconButton, 3, 0);

            _mainContainer = new CustomFrame()
            {
                Padding = 0,
                CornerRadius = CornerRadius,
                IsClippedToBounds = true,
                Content = _gridContainer,
                HasShadow = HasShadow,
                ShadowColor = ShadowColor
            };
            Content = _mainContainer;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (Children == null)
                return;

            switch (propertyName)
            {
                case nameof(BackgroundColor):
                    _gridContainer.BackgroundColor = BackgroundColor;
                    break;
                case nameof(ShadowColor):
                    _mainContainer.ShadowColor = ShadowColor;
                    break;
                case nameof(HasShadow):
                    _mainContainer.HasShadow = HasShadow;
                    break;
                case nameof(CornerRadius):
                    _mainContainer.CornerRadius = CornerRadius;
                    break;
                case nameof(Text):
                    _lblText.Text = Text;
                    break;
                case nameof(TextColor):
                    _lblText.TextColor = TextColor;
                    break;
                case nameof(FontSize):
                    _lblText.FontSize = FontSize;
                    break;
                case nameof(FontFamily):
                    _lblText.FontFamily = FontFamily;
                    break;
                case nameof(ActionText):
                    _actionButton.Text = ActionText;
                    break;
                case nameof(ActionTextColor):
                    _actionButton.TextColor = ActionTextColor;
                    break;
                case nameof(ActionFontSize):
                    _actionButton.FontSize = ActionFontSize;
                    break;
                case nameof(ActionFontFamily):
                    _actionButton.FontFamily = ActionFontFamily;
                    break;
                case nameof(ActionCommand):
                    _actionButton.Command = ActionCommand;
                    break;
                case nameof(ActionCommandParameter):
                    _actionButton.CommandParameter = ActionCommandParameter;
                    break;
                case nameof(LeadingIconCommand):
                    _leadingIconButton.Command = LeadingIconCommand;
                    _leadingIconButton.IsVisible = LeadingIconIsVisible;
                    break;
                case nameof(TrailingIconCommand):
                    _trailingIconButton.Command = TrailingIconCommand;
                    _trailingIconButton.IsVisible = TrailingIconIsVisible;
                    break;
                case nameof(IconSize):
                    _leadingIconButton.HeightRequest = IconSize;
                    _leadingIconButton.WidthRequest = IconSize;
                    _trailingIconButton.HeightRequest = IconSize;
                    _trailingIconButton.WidthRequest = IconSize;
                    break;
                case nameof(LeadingIcon):
                    if (!string.IsNullOrEmpty(LeadingIcon))
                    {
                        this._leadingIconButton.SetImage(LeadingIcon);
                        _lblText.Margin = new Thickness(8, 6);
                    }

                    this._leadingIconButton.IsVisible = LeadingIconIsVisible;
                    break;
                case nameof(CustomLeadingIcon):
                    if (CustomLeadingIcon != null)
                    {
                        this._leadingIconButton.SetCustomImage(CustomLeadingIcon);
                        _lblText.Margin = new Thickness(8, 6);
                    }
                    this._leadingIconButton.IsVisible = LeadingIconIsVisible;
                    break;
                case nameof(TrailingIcon):
                    if (!string.IsNullOrEmpty(TrailingIcon))
                        this._trailingIconButton.SetImage(TrailingIcon);

                    this._trailingIconButton.IsVisible = TrailingIconIsVisible;
                    break;
                case nameof(CustomTrailingIcon):
                    if (CustomTrailingIcon != null)
                        this._trailingIconButton.SetCustomImage(CustomTrailingIcon);

                    this._trailingIconButton.IsVisible = TrailingIconIsVisible;
                    break;
            }
        }
    }
}