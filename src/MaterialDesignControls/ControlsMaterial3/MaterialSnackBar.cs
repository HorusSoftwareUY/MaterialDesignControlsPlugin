using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Plugin.MaterialDesignControls.Implementations;
using Plugin.MaterialDesignControls.Styles;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3
{
	public class MaterialSnackBar : ContentView
	{
		public CustomFrame mainContainer { get; set; }

		public StackLayout stackContainer { get; set; }

		public MaterialLabel lblText { get; set; }

        private CustomImageButton _leadingIconCustomImageButton;

        private CustomImageButton _trailingIconCustomImageButton;

		public Plugin.MaterialDesignControls.Material3.MaterialButton actionButton { get; set; }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialSnackBar), defaultValue: Color.LightGray);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty ShadowColorProperty =
            BindableProperty.Create(nameof(ShadowColor), typeof(Color), typeof(MaterialSnackBar), defaultValue: Color.LightGray);

        public Color ShadowColor
        {
            get { return (Color)GetValue(ShadowColorProperty); }
            set { SetValue(ShadowColorProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(MaterialSnackBar), defaultValue: 10);

        public int CornerRadius
        {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialButton), defaultValue: null);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Default);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MaterialButton), defaultValue: DefaultStyles.PhoneFontSizes.LabelLarge);

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
            BindableProperty.Create(nameof(ActionTextColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Default);

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
            BindableProperty.Create(nameof(IconSize), typeof(int), typeof(MaterialSnackBar), defaultValue: 24);

        public int IconSize
        {
            get { return (int)GetValue(IconSizeProperty); }
            set { SetValue(IconSizeProperty, value); }
        }

        public MaterialSnackBar()	
		{
			stackContainer = new StackLayout();
			stackContainer.VerticalOptions = LayoutOptions.Start;
            stackContainer.BackgroundColor = Color.Red;
			stackContainer.HorizontalOptions = LayoutOptions.Fill;
            stackContainer.Padding = new Thickness(16, 12, 8, 12);
			lblText = new MaterialLabel() {VerticalOptions = LayoutOptions.Center};
			actionButton = new MaterialButton() { ButtonType = MaterialButtonType.Text, HorizontalOptions = LayoutOptions.EndAndExpand, Padding = 0};
			stackContainer.Orientation = StackOrientation.Horizontal;

			mainContainer = new CustomFrame();
            mainContainer.Margin = new Thickness(24, 0);
            mainContainer.Padding = 0;
            mainContainer.CornerRadius = 10;
			mainContainer.IsClippedToBounds = true;

            _leadingIconCustomImageButton = new CustomImageButton
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Green,
                HeightRequest = IconSize,
                WidthRequest = IconSize,
                Padding = 0,
                IsVisible = false
            };

            _trailingIconCustomImageButton = new CustomImageButton
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.Green,
                HeightRequest = IconSize,
                WidthRequest = IconSize,
                Padding = new Thickness(12,0,4,0),
                IsVisible = false
            };

            stackContainer.Children.Add(_leadingIconCustomImageButton);
            stackContainer.Children.Add(lblText);
            stackContainer.Children.Add(actionButton);
            stackContainer.Children.Add(_trailingIconCustomImageButton);
            mainContainer.Content = stackContainer;

            Content = mainContainer;	
        }
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (Children == null)
                return;

            switch (propertyName)
            {
                case nameof(BackgroundColor):
                    stackContainer.BackgroundColor = BackgroundColor;
                    break;
                case nameof(ShadowColor):
                    mainContainer.ShadowColor = ShadowColor;
                    break;
                case nameof(CornerRadius):
                    mainContainer.CornerRadius = CornerRadius;
                    break;
                case nameof(Text):
                    lblText.Text = Text;
                    break;
                case nameof(TextColor):
                    lblText.TextColor = TextColor;
                    break;
                case nameof(FontSize):
                    lblText.FontSize = FontSize;
                    break;
                case nameof(FontFamily):
                    lblText.FontFamily = FontFamily;
                    break;
                case nameof(ActionText):
                    actionButton.Text = ActionText;
                    break;
                case nameof(ActionTextColor):
                    actionButton.TextColor = ActionTextColor;
                    break;
                case nameof(ActionFontSize):
                    actionButton.FontSize = ActionFontSize;
                    break;
                case nameof(ActionFontFamily):
                    actionButton.FontFamily = ActionFontFamily;
                    break;
                case nameof(ActionCommand):
                    actionButton.Command = ActionCommand;
                    break;
                case nameof(ActionCommandParameter):
                    actionButton.CommandParameter = ActionCommandParameter;
                    break;
                case nameof(LeadingIcon):
                    if (!string.IsNullOrEmpty(LeadingIcon))
                        this._leadingIconCustomImageButton.SetImage(LeadingIcon);

                    this._leadingIconCustomImageButton.IsVisible = LeadingIconIsVisible;
                    break;
                case nameof(CustomLeadingIcon):
                    if (CustomLeadingIcon != null)
                        this._leadingIconCustomImageButton.SetCustomImage(CustomLeadingIcon);

                    this._leadingIconCustomImageButton.IsVisible = LeadingIconIsVisible;
                    break;
                case nameof(TrailingIcon):
                    if (!string.IsNullOrEmpty(TrailingIcon))
                        this._trailingIconCustomImageButton.SetImage(TrailingIcon);

                    this._trailingIconCustomImageButton.IsVisible = TrailingIconIsVisible;
                    break;
                case nameof(CustomTrailingIcon):
                    if (CustomTrailingIcon != null)
                        this._trailingIconCustomImageButton.SetCustomImage(CustomTrailingIcon);

                    this._trailingIconCustomImageButton.IsVisible = TrailingIconIsVisible;
                    break;
                case nameof(LeadingIconCommand):
                    _leadingIconCustomImageButton.Command = LeadingIconCommand;
                    _leadingIconCustomImageButton.IsVisible = LeadingIconIsVisible;
                    break;
                case nameof(TrailingIconCommand):
                    _trailingIconCustomImageButton.Command = TrailingIconCommand;
                    _trailingIconCustomImageButton.IsVisible = TrailingIconIsVisible;
                    break;
            }
        }


    }
}

