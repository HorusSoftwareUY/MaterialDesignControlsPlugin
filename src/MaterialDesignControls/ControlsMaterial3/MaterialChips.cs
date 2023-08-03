using System.Runtime.CompilerServices;
using System.Windows.Input;
using System;
using Xamarin.Forms;
using Plugin.MaterialDesignControls.Styles;
using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Implementations;

namespace Plugin.MaterialDesignControls.Material3
{
    public partial class MaterialChips : ContentView, ITouchAndPressEffectConsumer
    {
        #region Constructors

        public MaterialChips()
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

        private Frame _frmContainer;

        private CustomImageButton _imgLeadingIcon;

        private Label _lblText;

        private CustomImageButton _imgTrailingIcon;

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

        public static readonly BindableProperty LeadingIconCommandProperty =
            BindableProperty.Create(nameof(LeadingIconCommand), typeof(ICommand), typeof(MaterialChips));

        public ICommand LeadingIconCommand
        {
            get { return (ICommand)GetValue(LeadingIconCommandProperty); }
            set { SetValue(LeadingIconCommandProperty, value); }
        }

        public static readonly BindableProperty LeadingIconCommandParameterProperty =
            BindableProperty.Create(nameof(LeadingIconCommandParameter), typeof(object), typeof(MaterialChips), defaultValue: null);

        public object LeadingIconCommandParameter
        {
            get { return GetValue(LeadingIconCommandParameterProperty); }
            set { SetValue(LeadingIconCommandParameterProperty, value); }
        }

        public static readonly BindableProperty TrailingIconCommandProperty =
            BindableProperty.Create(nameof(TrailingIconCommand), typeof(ICommand), typeof(MaterialChips));

        public ICommand TrailingIconCommand
        {
            get { return (ICommand)GetValue(TrailingIconCommandProperty); }
            set { SetValue(TrailingIconCommandProperty, value); }
        }

        public static readonly BindableProperty TrailingIconCommandParameterProperty =
            BindableProperty.Create(nameof(TrailingIconCommandParameter), typeof(object), typeof(MaterialChips), defaultValue: null);

        public object TrailingIconCommandParameter
        {
            get { return GetValue(TrailingIconCommandParameterProperty); }
            set { SetValue(TrailingIconCommandParameterProperty, value); }
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
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MaterialChips), defaultValue: Font.Default.FontSize);

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

        public ICustomAnimation CustomAnimation { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #endregion Properties

        #region Events

        public event EventHandler IsSelectedChanged;

        #endregion Events

        #region Methods

        private void Initialize()
        {
            this._frmContainer = new Frame()
            {
                HasShadow = false,
                CornerRadius = 16,
                Padding = this.Padding,
                MinimumHeightRequest = 32,
                HeightRequest = 32,
                BorderColor = this.BorderColor
            };

            StackLayout stackLayout = new StackLayout()
            {
                Spacing = 0,
                HorizontalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Horizontal
            };

            this._imgLeadingIcon = new CustomImageButton()
            {
                IsVisible = false,
                Padding = new Thickness(8, 0, 8, 0),
                ImageHeightRequest = 18,
                ImageWidthRequest = 18,
                VerticalOptions = LayoutOptions.Center
            };

            this._lblText = new Label()
            {
                LineBreakMode = LineBreakMode.NoWrap,
                Margin = new Thickness(1),
                VerticalOptions = LayoutOptions.Center,
                TextColor = this.TextColor
            };

            this._imgTrailingIcon = new CustomImageButton()
            {
                IsVisible = false,
                Padding = new Thickness(8, 0, 8, 0),
                ImageHeightRequest = 18,
                ImageWidthRequest = 18,
                VerticalOptions = LayoutOptions.Center
            };

            stackLayout.Children.Add(this._imgLeadingIcon);
            stackLayout.Children.Add(this._lblText);
            stackLayout.Children.Add(this._imgTrailingIcon);

            this._frmContainer.Content = stackLayout;
            this.Content = this._frmContainer;
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
            if (!this.initialized)
            {
                this.initialized = true;
                this.Initialize();
            }

            switch (propertyName)
            {
                case nameof(this.Text):
                case nameof(this.ToUpper):
                    this._lblText.Text = this.ToUpper ? this.Text?.ToUpper() : this.Text;
                    break;
                case nameof(this.FontSize):
                    this._lblText.FontSize = this.FontSize;
                    break;
                case nameof(this.FontFamily):
                    this._lblText.FontFamily = this.FontFamily;
                    break;
                case nameof(this.Padding):
                    this._frmContainer.Padding = this.Padding;
                    break;
                case nameof(this.TextMargin):
                    this._lblText.Margin = this.TextMargin;
                    break;
                case nameof(this.CornerRadius):
                    this._frmContainer.CornerRadius = (float)this.CornerRadius;
                    break;
                case nameof(this.IsEnabled):
                case nameof(this.IsSelected):
                case nameof(this.SelectedTextColor):
                case nameof(this.SelectedBackgroundColor):
                case nameof(this.TextColor):
                case nameof(this.BackgroundColor):
                case nameof(this.DisabledSelectedTextColor):
                case nameof(this.DisabledSelectedBackgroundColor):
                case nameof(this.DisabledTextColor):
                case nameof(this.DisabledBackgroundColor):
                    this.ApplyIsSelected();
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

                case nameof(this.LeadingIconCommand):
                    AddIconTapGesture(false);
                    break;
                case nameof(this.TrailingIconCommand):
                    AddIconTapGesture(true);
                    break;

                case nameof(this.BorderColor):
                    this._frmContainer.BorderColor = this.BorderColor;
                    break;
            }
        }

        private void AddIconTapGesture(bool isTrailingIcon)
        {
            if (this._frmContainer.GestureRecognizers.Count > 0)
                this._frmContainer.GestureRecognizers.RemoveAt(0); //Remove main tap gesture

            if (isTrailingIcon)
            {
                this._imgTrailingIcon.Command = new Command(() =>
                {
                    if (this.IsEnabled && this.TrailingIconCommand != null)
                    {
                        this.TrailingIconCommand.Execute(this.TrailingIconCommandParameter);
                    }
                });
            }
            else
            {
                this._imgLeadingIcon.Command = new Command(() =>
                {
                    if (this.IsEnabled && this.LeadingIconCommand != null)
                    {
                        this.LeadingIconCommand.Execute(this.LeadingIconCommandParameter);
                    }
                });
            }
        }

        private void ApplyIsSelected()
        {
            if (this.IsEnabled)
            {
                if (this.IsSelected)
                {
                    this._lblText.TextColor = this.SelectedTextColor;
                    this._frmContainer.BackgroundColor = this.SelectedBackgroundColor;
                }
                else
                {
                    this._lblText.TextColor = this.TextColor;
                    this._frmContainer.BackgroundColor = this.BackgroundColor;
                }
            }
            else
            {
                if (this.IsSelected)
                {
                    this._lblText.TextColor = this.DisabledSelectedTextColor;
                    this._frmContainer.BackgroundColor = this.DisabledSelectedBackgroundColor;
                }
                else
                {
                    this._lblText.TextColor = this.DisabledTextColor;
                    this._frmContainer.BackgroundColor = this.DisabledBackgroundColor;
                }
            }
        }

        public void ConsumeEvent(EventType gestureType)
        {
            TouchAndPressAnimation.Animate(this, gestureType);
        }

        public void ExecuteAction()
        {
            if (this.IsEnabled)
            {
                if (IsEnabled && Command != null && Command.CanExecute(CommandParameter))
                    Command.Execute(CommandParameter);
                else
                    this.IsSelected = !this.IsSelected;
            }
        }

        #endregion Methods
    }
}