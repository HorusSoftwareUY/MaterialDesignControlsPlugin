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
            if (!this.initialized)
            {
                this.InitializeComponent();
                this.initialized = true;
            }

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

        private bool initialized = false;

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
            BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(MaterialChips), defaultValue: null, propertyChanged: OnIsSelectedChanged);

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public static readonly new BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(MaterialChips), defaultValue: new Thickness(12, 0), propertyChanged: OnPropertyChanged);

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialChips), defaultValue: null, propertyChanged: OnPropertyChanged);

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

        public static readonly BindableProperty DisabledTextColorProperty =
            BindableProperty.Create(nameof(DisabledTextColor), typeof(Color), typeof(MaterialChips), defaultValue: Color.LightGray, propertyChanged: OnPropertyChanged);

        public Color DisabledTextColor
        {
            get { return (Color)GetValue(DisabledTextColorProperty); }
            set { SetValue(DisabledTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledSelectedTextColorProperty =
            BindableProperty.Create(nameof(DisabledSelectedTextColor), typeof(Color), typeof(MaterialChips), defaultValue: Color.White, propertyChanged: OnPropertyChanged);

        public Color DisabledSelectedTextColor
        {
            get { return (Color)GetValue(DisabledSelectedTextColorProperty); }
            set { SetValue(DisabledSelectedTextColorProperty, value); }
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

        public static readonly BindableProperty DisabledBackgroundColorProperty =
            BindableProperty.Create(nameof(DisabledBackgroundColor), typeof(Color), typeof(MaterialChips), defaultValue: Color.White, propertyChanged: OnPropertyChanged);

        public Color DisabledBackgroundColor
        {
            get { return (Color)GetValue(DisabledBackgroundColorProperty); }
            set { SetValue(DisabledBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty DisabledSelectedBackgroundColorProperty =
            BindableProperty.Create(nameof(DisabledSelectedBackgroundColor), typeof(Color), typeof(MaterialChips), defaultValue: Color.LightGray, propertyChanged: OnPropertyChanged);

        public Color DisabledSelectedBackgroundColor
        {
            get { return (Color)GetValue(DisabledSelectedBackgroundColorProperty); }
            set { SetValue(DisabledSelectedBackgroundColorProperty, value); }
        }

        public static readonly BindableProperty TextScaleProperty =
            BindableProperty.Create(nameof(TextScale), typeof(ScaleTypes), typeof(MaterialChips), defaultValue: ScaleTypes.Body2, propertyChanged: OnPropertyChanged);

        public ScaleTypes TextScale
        {
            get { return (ScaleTypes)GetValue(TextScaleProperty); }
            set { SetValue(TextScaleProperty, value); }
        }

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(MaterialChips), defaultValue: 16.0, propertyChanged: OnPropertyChanged);

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
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

        private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialChips)bindable;
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
            this.lblText.TextScale = this.TextScale;

            this.frmContainer.Padding = this.Padding;
            this.frmContainer.CornerRadius = (float)this.CornerRadius;

            this.ApplyIsSelected();
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
