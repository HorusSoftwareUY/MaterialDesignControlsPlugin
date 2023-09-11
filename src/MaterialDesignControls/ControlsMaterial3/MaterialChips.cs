using System.Runtime.CompilerServices;
using System.Windows.Input;
using System;
using Xamarin.Forms;
using Plugin.MaterialDesignControls.Styles;
using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Material3.Implementations;

namespace Plugin.MaterialDesignControls.Material3
{
    public partial class MaterialChips : ContentView, ITouchAndPressEffectConsumer
    {
        #region Constructors

        public MaterialChips()
        {
            if (!initialized)
            {
                initialized = true;
                Initialize();
            }
        }

        #endregion Constructors

        #region Attributes

        private bool initialized = false;

        private Frame _frmContainer;

        private CustomImage _imgLeadingIcon;

        private Label _lblText;

        private CustomImage _imgTrailingIcon;

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

        public static readonly new BindableProperty IsEnabledProperty =
            BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(MaterialChips), defaultValue: true);

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public static readonly BindableProperty IsSelectedProperty =
            BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(MaterialChips), defaultValue: null, defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnIsSelectedChanged);

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public static readonly new BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(MaterialChips), defaultValue: new Thickness(16, 0));

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        public static readonly BindableProperty TextMarginProperty =
            BindableProperty.Create(nameof(TextMargin), typeof(Thickness), typeof(MaterialChips), defaultValue: new Thickness(0, 0));

        public Thickness TextMargin
        {
            get { return (Thickness)GetValue(TextMarginProperty); }
            set { SetValue(TextMarginProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty =
           BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(MaterialChips), defaultValue: DefaultStyles.PrimaryColor);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty LeadingIconProperty =
           BindableProperty.Create(nameof(LeadingIcon), typeof(string), typeof(MaterialChips), defaultValue: null);

        public string LeadingIcon
        {
            get { return (string)GetValue(LeadingIconProperty); }
            set { SetValue(LeadingIconProperty, value); }
        }

        public static readonly BindableProperty CustomLeadingIconProperty =
           BindableProperty.Create(nameof(CustomLeadingIcon), typeof(View), typeof(MaterialChips), defaultValue: null);

        public View CustomLeadingIcon
        {
            get { return (View)GetValue(CustomLeadingIconProperty); }
            set { SetValue(CustomLeadingIconProperty, value); }
        }

        public static readonly BindableProperty LeadingIconIsVisibleProperty =
           BindableProperty.Create(nameof(LeadingIconIsVisible), typeof(bool), typeof(MaterialChips), defaultValue: true);

        public bool LeadingIconIsVisible
        {
            get { return (bool)GetValue(LeadingIconIsVisibleProperty); }
            set { SetValue(LeadingIconIsVisibleProperty, value); }
        }

        public static readonly BindableProperty TrailingIconProperty =
            BindableProperty.Create(nameof(TrailingIcon), typeof(string), typeof(MaterialChips), defaultValue: null);

        public string TrailingIcon
        {
            get { return (string)GetValue(TrailingIconProperty); }
            set { SetValue(TrailingIconProperty, value); }
        }

        public static readonly BindableProperty CustomTrailingIconProperty =
            BindableProperty.Create(nameof(CustomTrailingIcon), typeof(View), typeof(MaterialChips), defaultValue: null);

        public View CustomTrailingIcon
        {
            get { return (View)GetValue(CustomTrailingIconProperty); }
            set { SetValue(CustomTrailingIconProperty, value); }
        }

        public static readonly BindableProperty TrailingIconIsVisibleProperty =
           BindableProperty.Create(nameof(TrailingIconIsVisible), typeof(bool), typeof(MaterialChips), defaultValue: true);

        public bool TrailingIconIsVisible
        {
            get { return (bool)GetValue(TrailingIconIsVisibleProperty); }
            set { SetValue(TrailingIconIsVisibleProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialChips), defaultValue: null);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialChips), defaultValue: DefaultStyles.PrimaryColor);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty SelectedTextColorProperty =
            BindableProperty.Create(nameof(SelectedTextColor), typeof(Color), typeof(MaterialChips), defaultValue: DefaultStyles.OnPrimaryColor);

        public Color SelectedTextColor
        {
            get { return (Color)GetValue(SelectedTextColorProperty); }
            set { SetValue(SelectedTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledTextColorProperty =
            BindableProperty.Create(nameof(DisabledTextColor), typeof(Color), typeof(MaterialChips), defaultValue: DefaultStyles.OnPrimaryColor);

        public Color DisabledTextColor
        {
            get { return (Color)GetValue(DisabledTextColorProperty); }
            set { SetValue(DisabledTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledSelectedTextColorProperty =
            BindableProperty.Create(nameof(DisabledSelectedTextColor), typeof(Color), typeof(MaterialChips), defaultValue: DefaultStyles.DisableColor);

        public Color DisabledSelectedTextColor
        {
            get { return (Color)GetValue(DisabledSelectedTextColorProperty); }
            set { SetValue(DisabledSelectedTextColorProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialChips), defaultValue: DefaultStyles.PrimaryContainerColor);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty SelectedBackgroundColorProperty =
            BindableProperty.Create(nameof(SelectedBackgroundColor), typeof(Color), typeof(MaterialChips), defaultValue: DefaultStyles.PrimaryColor);

        public Color SelectedBackgroundColor
        {
            get { return (Color)GetValue(SelectedBackgroundColorProperty); }
            set { SetValue(SelectedBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty DisabledBackgroundColorProperty =
            BindableProperty.Create(nameof(DisabledBackgroundColor), typeof(Color), typeof(MaterialChips), defaultValue: DefaultStyles.DisableContainerColor);

        public Color DisabledBackgroundColor
        {
            get { return (Color)GetValue(DisabledBackgroundColorProperty); }
            set { SetValue(DisabledBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty DisabledSelectedBackgroundColorProperty =
            BindableProperty.Create(nameof(DisabledSelectedBackgroundColor), typeof(Color), typeof(MaterialChips), defaultValue: DefaultStyles.DisableContainerColor);

        public Color DisabledSelectedBackgroundColor
        {
            get { return (Color)GetValue(DisabledSelectedBackgroundColorProperty); }
            set { SetValue(DisabledSelectedBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MaterialChips), defaultValue: DefaultStyles.PhoneFontSizes.LabelLarge);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(MaterialChips), defaultValue: DefaultStyles.FontFamily);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(MaterialChips), defaultValue: 16.0);

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty ToUpperProperty =
            BindableProperty.Create(nameof(ToUpper), typeof(bool), typeof(MaterialChips), defaultValue: false);

        public bool ToUpper
        {
            get { return (bool)GetValue(ToUpperProperty); }
            set { SetValue(ToUpperProperty, value); }
        }

        public static readonly BindableProperty AnimationProperty =
            BindableProperty.Create(nameof(Animation), typeof(AnimationTypes), typeof(MaterialChips), defaultValue: DefaultStyles.AnimationType);

        public AnimationTypes Animation
        {
            get { return (AnimationTypes)GetValue(AnimationProperty); }
            set { SetValue(AnimationProperty, value); }
        }

        public static readonly BindableProperty AnimationParameterProperty =
            BindableProperty.Create(nameof(AnimationParameter), typeof(double?), typeof(MaterialChips), defaultValue: DefaultStyles.AnimationParameter);

        public double? AnimationParameter
        {
            get { return (double?)GetValue(AnimationParameterProperty); }
            set { SetValue(AnimationParameterProperty, value); }
        }

        public static readonly BindableProperty CustomAnimationProperty =
            BindableProperty.Create(nameof(CustomAnimation), typeof(ICustomAnimation), typeof(MaterialChips), defaultValue: null);

        public ICustomAnimation CustomAnimation
        {
            get { return (ICustomAnimation)GetValue(CustomAnimationProperty); }
            set { SetValue(CustomAnimationProperty, value); }
        }

        #endregion Properties

        #region Events

        public event EventHandler IsSelectedChanged;

        #endregion Events

        #region Methods

        private void Initialize()
        {
            _frmContainer = new Frame()
            {
                HasShadow = false,
                CornerRadius = 16,
                Padding = Padding,
                MinimumHeightRequest = 32,
                HeightRequest = 32,
                BorderColor = BorderColor
            };

            var stackLayout = new StackLayout()
            {
                Spacing = 0,
                HorizontalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Horizontal
            };

            _imgLeadingIcon = new CustomImage()
            {
                IsVisible = false,
                Padding = new Thickness(8, 0, 8, 0),
                HeightRequest = 18,
                WidthRequest = 18,
                VerticalOptions = LayoutOptions.Center
            };

            _lblText = new Label()
            {
                LineBreakMode = LineBreakMode.NoWrap,
                Margin = new Thickness(1),
                VerticalOptions = LayoutOptions.Center,
                TextColor = TextColor
            };

            _imgTrailingIcon = new CustomImage()
            {
                IsVisible = false,
                Padding = new Thickness(8, 0, 8, 0),
                HeightRequest = 18,
                WidthRequest = 18,
                VerticalOptions = LayoutOptions.Center
            };

            stackLayout.Children.Add(_imgLeadingIcon);
            stackLayout.Children.Add(_lblText);
            stackLayout.Children.Add(_imgTrailingIcon);

            _frmContainer.Content = stackLayout;
            Content = _frmContainer;
            Effects.Add(new TouchAndPressEffect());
            ApplyIsSelected();
        }

        private static void OnIsSelectedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialChips)bindable;
            control.ApplyIsSelected();
            control.IsSelectedChanged?.Invoke(control, null);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!initialized)
            {
                initialized = true;
                Initialize();
            }

            switch (propertyName)
            {
                case nameof(Text):
                case nameof(ToUpper):
                    _lblText.Text = ToUpper ? Text?.ToUpper() : Text;
                    break;
                case nameof(FontSize):
                    _lblText.FontSize = FontSize;
                    break;
                case nameof(FontFamily):
                    _lblText.FontFamily = FontFamily;
                    break;
                case nameof(Padding):
                    _frmContainer.Padding = Padding;
                    break;
                case nameof(TextMargin):
                    _lblText.Margin = TextMargin;
                    break;
                case nameof(CornerRadius):
                    _frmContainer.CornerRadius = (float)CornerRadius;
                    break;
                case nameof(IsEnabled):
                case nameof(IsSelected):
                case nameof(SelectedTextColor):
                case nameof(SelectedBackgroundColor):
                case nameof(TextColor):
                case nameof(BackgroundColor):
                case nameof(DisabledSelectedTextColor):
                case nameof(DisabledSelectedBackgroundColor):
                case nameof(DisabledTextColor):
                case nameof(DisabledBackgroundColor):
                    ApplyIsSelected();
                    break;

                case nameof(TrailingIcon):
                    _imgTrailingIcon.SetImage(TrailingIcon);
                    _imgTrailingIcon.IsVisible = TrailingIconIsVisible;
                    break;
                case nameof(CustomTrailingIcon):
                    _imgTrailingIcon.SetCustomImage(CustomTrailingIcon);
                    _imgTrailingIcon.IsVisible = TrailingIconIsVisible;
                    break;
                case nameof(LeadingIcon):
                    _imgLeadingIcon.SetImage(LeadingIcon);
                    _imgLeadingIcon.IsVisible = LeadingIconIsVisible;
                    break;
                case nameof(CustomLeadingIcon):
                    _imgLeadingIcon.SetCustomImage(CustomLeadingIcon);
                    _imgLeadingIcon.IsVisible = LeadingIconIsVisible;
                    break;

                case nameof(TrailingIconIsVisible):
                    _imgTrailingIcon.IsVisible = TrailingIconIsVisible;
                    break;
                case nameof(LeadingIconIsVisible):
                    _imgLeadingIcon.IsVisible = LeadingIconIsVisible;
                    break;

                case nameof(BorderColor):
                    _frmContainer.BorderColor = BorderColor;
                    break;

                case nameof(base.Opacity):
                case nameof(base.Scale):
                case nameof(base.IsVisible):
                    base.OnPropertyChanged(propertyName);
                    break;
            }
        }

        private void ApplyIsSelected()
        {
            if (IsEnabled)
            {
                if (IsSelected)
                {
                    _lblText.TextColor = SelectedTextColor;
                    _frmContainer.BackgroundColor = SelectedBackgroundColor;
                }
                else
                {
                    _lblText.TextColor = TextColor;
                    _frmContainer.BackgroundColor = BackgroundColor;
                }
            }
            else
            {
                if (IsSelected)
                {
                    _lblText.TextColor = DisabledSelectedTextColor;
                    _frmContainer.BackgroundColor = DisabledSelectedBackgroundColor;
                }
                else
                {
                    _lblText.TextColor = DisabledTextColor;
                    _frmContainer.BackgroundColor = DisabledBackgroundColor;
                }
            }
        }

        public void ConsumeEvent(EventType gestureType)
        {
            TouchAndPressAnimation.Animate(this, gestureType);
        }

        public void ExecuteAction()
        {
            if (IsEnabled)
            {
                if (IsEnabled && Command != null && Command.CanExecute(CommandParameter))
                    Command.Execute(CommandParameter);
                else
                    IsSelected = !IsSelected;
            }
        }

        #endregion Methods
    }
}