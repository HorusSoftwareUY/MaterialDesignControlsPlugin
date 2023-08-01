using System.Runtime.CompilerServices;
using System.Windows.Input;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls.Material3
{

    public enum MaterialChipsType
    {
        Assist, Filter, Input, Suggestion
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialChips : ContentView
    {
        #region Constructors

        public MaterialChips()
        {
            if (!this.initialized)
            {
                this.initialized = true;
                this.InitializeComponent();
            }

            AddMainTapGesture();
        }

        private void AddMainTapGesture()
        {
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                if (this.IsEnabled)
                {
                    if (CommandProperty != null && this.Command != null)
                        this.Command.Execute(this.CommandParameter);
                    else
                        this.IsSelected = !this.IsSelected;
                }
            };
            this.frmContainer.GestureRecognizers.Add(tapGestureRecognizer);
        }

        #endregion Constructors

        #region Attributes

        private bool initialized = false;

        #endregion Attributes

        #region Properties

        public static readonly BindableProperty TypeProperty =
            BindableProperty.Create(nameof(Type), typeof(MaterialChipsType), typeof(MaterialChips), defaultValue: MaterialChipsType.Assist);

        public MaterialChipsType Type
        {
            get { return (MaterialChipsType)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

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
           BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(MaterialChips), defaultValue: Color.Transparent);

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
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialChips), defaultValue: Color.Gray);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty SelectedTextColorProperty =
            BindableProperty.Create(nameof(SelectedTextColor), typeof(Color), typeof(MaterialChips), defaultValue: Color.Black);

        public Color SelectedTextColor
        {
            get { return (Color)GetValue(SelectedTextColorProperty); }
            set { SetValue(SelectedTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledTextColorProperty =
            BindableProperty.Create(nameof(DisabledTextColor), typeof(Color), typeof(MaterialChips), defaultValue: Color.LightGray);

        public Color DisabledTextColor
        {
            get { return (Color)GetValue(DisabledTextColorProperty); }
            set { SetValue(DisabledTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledSelectedTextColorProperty =
            BindableProperty.Create(nameof(DisabledSelectedTextColor), typeof(Color), typeof(MaterialChips), defaultValue: Color.White);

        public Color DisabledSelectedTextColor
        {
            get { return (Color)GetValue(DisabledSelectedTextColorProperty); }
            set { SetValue(DisabledSelectedTextColorProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialChips), defaultValue: Color.LightGray);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty SelectedBackgroundColorProperty =
            BindableProperty.Create(nameof(SelectedBackgroundColor), typeof(Color), typeof(MaterialChips), defaultValue: Color.Gray);

        public Color SelectedBackgroundColor
        {
            get { return (Color)GetValue(SelectedBackgroundColorProperty); }
            set { SetValue(SelectedBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty DisabledBackgroundColorProperty =
            BindableProperty.Create(nameof(DisabledBackgroundColor), typeof(Color), typeof(MaterialChips), defaultValue: Color.White);

        public Color DisabledBackgroundColor
        {
            get { return (Color)GetValue(DisabledBackgroundColorProperty); }
            set { SetValue(DisabledBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty DisabledSelectedBackgroundColorProperty =
            BindableProperty.Create(nameof(DisabledSelectedBackgroundColor), typeof(Color), typeof(MaterialChips), defaultValue: Color.LightGray);

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
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(MaterialChips), defaultValue: null);

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

        #endregion Properties

        #region Events

        public event EventHandler IsSelectedChanged;

        #endregion Events

        #region Methods

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
                this.InitializeComponent();
            }

            switch (propertyName)
            {
                case nameof(this.Text):
                case nameof(this.ToUpper):
                    this.lblText.Text = this.ToUpper ? this.Text?.ToUpper() : this.Text;
                    break;
                case nameof(this.FontSize):
                    this.lblText.FontSize = this.FontSize;
                    break;
                case nameof(this.FontFamily):
                    this.lblText.FontFamily = this.FontFamily;
                    break;
                case nameof(this.Padding):
                    this.frmContainer.Padding = this.Padding;
                    break;
                case nameof(this.TextMargin):
                    this.lblText.Margin = this.TextMargin;
                    break;
                case nameof(this.CornerRadius):
                    this.frmContainer.CornerRadius = (float)this.CornerRadius;
                    break;
                case nameof(this.IsEnabled):
                case nameof(IsSelected):
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
                    imgTrailingIcon.SetImage(TrailingIcon);
                    imgTrailingIcon.IsVisible = TrailingIconIsVisible;
                    break;
                case nameof(CustomTrailingIcon):
                    imgTrailingIcon.SetCustomImage(CustomTrailingIcon);
                    imgTrailingIcon.IsVisible = TrailingIconIsVisible;
                    break;
                case nameof(LeadingIcon):
                    imgLeadingIcon.SetImage(LeadingIcon);
                    imgLeadingIcon.IsVisible = LeadingIconIsVisible;
                    break;
                case nameof(CustomLeadingIcon):
                    imgLeadingIcon.SetCustomImage(CustomLeadingIcon);
                    imgLeadingIcon.IsVisible = LeadingIconIsVisible;
                    break;

                case nameof(TrailingIconIsVisible):
                    imgTrailingIcon.IsVisible = TrailingIconIsVisible;
                    break;
                case nameof(LeadingIconIsVisible):
                    imgLeadingIcon.IsVisible = LeadingIconIsVisible;
                    break;

                case nameof(this.LeadingIconCommand):
                    AddIconTapGesture(false);
                    break;
                case nameof(this.TrailingIconCommand):
                    AddIconTapGesture(true);
                    break;

                case nameof(this.BorderColor):
                    this.frmContainer.BorderColor = this.BorderColor;
                    break;

                case nameof(this.Type):
                    Console.WriteLine("Enter set type");
                    SetMaterialChipsType();
                    break;
            }
        }

        private void SetMaterialChipsType()
        {
            Console.WriteLine("set aquí!!!!");

            switch (Type)
            {
                case MaterialChipsType.Assist:
                    TrailingIconIsVisible = false;
                    if (LeadingIconIsVisible)
                    {
                        this.Padding = new Thickness(0, 0, 16, 0);
                    }
                    else
                    {
                        this.Padding = new Thickness(16, 0);
                    }
                    Console.WriteLine("Entro aquí!!!!");
                    break;
                case MaterialChipsType.Filter:
                    if (LeadingIconIsVisible && TrailingIconIsVisible)
                    {
                        this.Padding = new Thickness(0);
                    }
                    else if (LeadingIconIsVisible && !TrailingIconIsVisible)
                    {
                        this.Padding = new Thickness(0, 0, 16, 0);
                    }
                    else if (!LeadingIconIsVisible && TrailingIconIsVisible)
                    {
                        this.Padding = new Thickness(16, 0, 0, 0);
                    }
                    else
                    {
                        this.Padding = new Thickness(16, 0);
                    }
                    break;
                case MaterialChipsType.Input:
                    if (LeadingIconIsVisible && TrailingIconIsVisible)
                    {
                        this.Padding = new Thickness(0);
                        imgLeadingIcon.WidthRequest = 24;
                        imgLeadingIcon.MinimumWidthRequest = 24;
                    }
                    else if (LeadingIconIsVisible && !TrailingIconIsVisible)
                    {
                        this.Padding = new Thickness(0, 0, 16, 0);
                        imgLeadingIcon.WidthRequest = 18;
                        imgLeadingIcon.MinimumWidthRequest = 18;
                    }
                    else if (!LeadingIconIsVisible && TrailingIconIsVisible)
                    {
                        this.Padding = new Thickness(16, 0, 0, 0);
                        imgLeadingIcon.WidthRequest = 18;
                        imgLeadingIcon.MinimumWidthRequest = 18;
                    }
                    else
                    {
                        this.Padding = new Thickness(16, 0);
                        imgLeadingIcon.WidthRequest = 18;
                        imgLeadingIcon.MinimumWidthRequest = 18;
                    }
                    break;
                case MaterialChipsType.Suggestion:
                    TrailingIconIsVisible = false;
                    if (LeadingIconIsVisible)
                    {
                        this.Padding = new Thickness(0, 0, 16, 0);
                    }
                    else
                    {
                        this.Padding = new Thickness(16, 0);
                    }
                    break;

            }
        }

        private void AddIconTapGesture(bool isTrailingIcon)
        {
            if (this.frmContainer.GestureRecognizers.Count > 0)
                this.frmContainer.GestureRecognizers.RemoveAt(0); //Remove main tap gesture

            if (isTrailingIcon)
            {
                this.imgTrailingIcon.Command = new Command(() =>
                {
                    if (this.IsEnabled && this.TrailingIconCommand != null)
                    {
                        this.TrailingIconCommand.Execute(this.TrailingIconCommandParameter);
                    }
                });
            }
            else
            {
                this.imgLeadingIcon.Command = new Command(() =>
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
                    this.lblText.TextColor = this.SelectedTextColor;
                    this.frmContainer.BackgroundColor = this.SelectedBackgroundColor;
                }
                else
                {
                    this.lblText.TextColor = this.TextColor;
                    this.frmContainer.BackgroundColor = this.BackgroundColor;
                }
            }
            else
            {
                if (this.IsSelected)
                {
                    this.lblText.TextColor = this.DisabledSelectedTextColor;
                    this.frmContainer.BackgroundColor = this.DisabledSelectedBackgroundColor;
                }
                else
                {
                    this.lblText.TextColor = this.DisabledTextColor;
                    this.frmContainer.BackgroundColor = this.DisabledBackgroundColor;
                }
            }
        }

        #endregion Methods
    }
}