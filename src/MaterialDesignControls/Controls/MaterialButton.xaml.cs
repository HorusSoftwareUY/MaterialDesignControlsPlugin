using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls
{
    public partial class MaterialButton : ContentView
    {
        #region Constructors

        public MaterialButton()
        {
            if (!this.initialized)
            {
                this.InitializeComponent();
                this.initialized = true;
            }
        }

        #endregion Constructors

        #region Attributes

        private bool initialized = false;

        #endregion Attributes

        #region Properties

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(MaterialButton), defaultValue: null, propertyChanged: OnCommandChanged);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(MaterialButton), defaultValue: null, propertyChanged: OnPropertyChanged);

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }
    
        public static readonly new BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(MaterialButton), defaultValue: new Thickness(12, 0), propertyChanged: OnPropertyChanged);

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        public static readonly new BindableProperty IsEnabledProperty =
            BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(MaterialButton), defaultValue: true, propertyChanged: OnPropertyChanged);

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialButton), defaultValue: null, propertyChanged: OnPropertyChanged);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Black, propertyChanged: OnPropertyChanged);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledTextColorProperty =
            BindableProperty.Create(nameof(DisabledTextColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Gray, propertyChanged: OnPropertyChanged);

        public Color DisabledTextColor
        {
            get { return (Color)GetValue(DisabledTextColorProperty); }
            set { SetValue(DisabledTextColorProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Transparent, propertyChanged: OnPropertyChanged);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty DisabledBackgroundColorProperty =
            BindableProperty.Create(nameof(DisabledBackgroundColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Transparent, propertyChanged: OnPropertyChanged);

        public Color DisabledBackgroundColor
        {
            get { return (Color)GetValue(DisabledBackgroundColorProperty); }
            set { SetValue(DisabledBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty TextScaleProperty =
            BindableProperty.Create(nameof(TextScale), typeof(ScaleTypes), typeof(MaterialButton), defaultValue: ScaleTypes.BUTTON, propertyChanged: OnPropertyChanged);

        public ScaleTypes TextScale
        {
            get { return (ScaleTypes)GetValue(TextScaleProperty); }
            set { SetValue(TextScaleProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Transparent, propertyChanged: OnPropertyChanged);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty DisabledBorderColorProperty =
            BindableProperty.Create(nameof(DisabledBorderColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Transparent, propertyChanged: OnPropertyChanged);

        public Color DisabledBorderColor
        {
            get { return (Color)GetValue(DisabledBorderColorProperty); }
            set { SetValue(DisabledBorderColorProperty, value); }
        }

        public static readonly BindableProperty IconProperty =
            BindableProperty.Create(nameof(Icon), typeof(string), typeof(MaterialButton), defaultValue: null, propertyChanged: OnPropertyChanged);

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly BindableProperty DisabledIconProperty =
            BindableProperty.Create(nameof(DisabledIcon), typeof(string), typeof(MaterialButton), defaultValue: null, propertyChanged: OnPropertyChanged);

        public string DisabledIcon
        {
            get { return (string)GetValue(DisabledIconProperty); }
            set { SetValue(DisabledIconProperty, value); }
        }

        public bool IconIsVisible
        {
            get { return !string.IsNullOrEmpty(this.Icon); }
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(MaterialButton), defaultValue: 4.0, propertyChanged: OnPropertyChanged);

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        #endregion Properties

        #region Methods

        private static void OnCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialButton)bindable;

            TapGestureRecognizer selectionTapGestureRecognizer = new TapGestureRecognizer();
            selectionTapGestureRecognizer.Tapped += async (s, e) =>
            {
                if (control.IsEnabled && control.Command != null && control.Command.CanExecute(control.CommandParameter))
                {
                    control.Command.Execute(control.CommandParameter);
                }
            };
            control.frmContainer.GestureRecognizers.Clear();
            control.frmContainer.GestureRecognizers.Add(selectionTapGestureRecognizer);
        }

        private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialButton)bindable;
            control.ApplyControlProperties();
        }

        private void ApplyControlProperties()
        {
            if (!this.initialized)
            {
                this.InitializeComponent();
                this.initialized = true;
            }

            this.lblText.Text = this.Text;
            this.lblText.TextColor = this.IsEnabled ? this.TextColor : this.DisabledTextColor;
            this.lblText.TextScale = this.TextScale;

            this.frmContainer.Padding = this.Padding;
            this.frmContainer.CornerRadius = (float)this.CornerRadius;

            this.frmContainer.BackgroundColor = this.IsEnabled ? this.BackgroundColor : this.DisabledBackgroundColor;
            this.frmContainer.BorderColor = this.IsEnabled ? this.BorderColor : this.DisabledBorderColor;

            if (!string.IsNullOrEmpty(this.Icon) || !string.IsNullOrEmpty(this.DisabledIcon))
            {
                this.imgIcon.Source = this.IsEnabled ? this.Icon : this.DisabledIcon;
            }
            this.imgIcon.IsVisible = this.IconIsVisible;
        }

        #endregion Methods
    }
}
