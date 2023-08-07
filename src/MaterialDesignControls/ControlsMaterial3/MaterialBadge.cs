using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Plugin.MaterialDesignControls.Styles;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3
{
    public enum MaterialBadgeType
    {
        Small, Large
    }

    public class MaterialBadge : ContentView
    {
        #region Attributes and Properties

        private bool _initialized = false;

        private Label _lblText;

        private MaterialCard _frmContainer;

        #endregion Attributes and Properties

        #region Bindable properties

        public static readonly BindableProperty TypeProperty =
            BindableProperty.Create(nameof(Type), typeof(MaterialBadgeType), typeof(MaterialBadge), defaultValue: MaterialBadgeType.Large);

        public MaterialBadgeType Type
        {
            get { return (MaterialBadgeType)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialBadge), defaultValue: null, propertyChanged: OnTextChanged, defaultBindingMode: BindingMode.TwoWay);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialBadge), defaultValue: DefaultStyles.OnPrimaryColor);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MaterialBadge), defaultValue: DefaultStyles.PhoneFontSizes.LabelSmall);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(MaterialBadge), defaultValue: DefaultStyles.FontFamily);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialBadge), defaultValue: DefaultStyles.ErrorColor);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        //public static readonly BindableProperty SizeProperty =
        //    BindableProperty.Create(nameof(Size), typeof(double), typeof(MaterialBadge), defaultValue: 6.0);

        //public double Size
        //{
        //    get { return (double)GetValue(SizeProperty); }
        //    set { SetValue(SizeProperty, value); }
        //}

        //public static readonly BindableProperty CornerRadiusProperty =
        //    BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(MaterialBadge), defaultValue: 3f);

        //public float CornerRadius
        //{
        //    get { return (float)GetValue(CornerRadiusProperty); }
        //    set { SetValue(CornerRadiusProperty, value); }
        //}

        #endregion Bindable properties

        #region Constructors

        public MaterialBadge()
        {
            if (!_initialized)
                Initialize();
        }

        #endregion Constructors

        #region Methods

        private void Initialize()
        {
            _initialized = true;

            this._frmContainer = new MaterialCard()
            {
                BackgroundColor = this.BackgroundColor,
                CornerRadiusBottomLeft = true,
                CornerRadiusBottomRight = true,
                CornerRadiusTopLeft = true,
                CornerRadiusTopRight = true,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };

            this._lblText = new Label()
            {
                Text = this.Text,
                TextColor = this.TextColor,
                FontSize = this.FontSize,
                FontFamily = this.FontFamily,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };

            this._frmContainer.Content = this._lblText;

            this.Content = this._frmContainer;

            SetMaterialBadgeType();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!_initialized)
                Initialize();

            switch (propertyName)
            {
                case nameof(Type):
                    SetMaterialBadgeType();
                    break;
                case nameof(TextColor):
                    this._lblText.TextColor = TextColor;
                    break;
                case nameof(FontSize):
                    this._lblText.FontSize = FontSize;
                    break;
                case nameof(FontFamily):
                    this._lblText.FontFamily = FontFamily;
                    break;

                //case nameof(CornerRadius):
                //    this._frmContainer.CornerRadius = CornerRadius;
                    //break;
                case nameof(BackgroundColor):
                    this._frmContainer.BackgroundColor = BackgroundColor;
                    break;
            }
        }

        private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialBadge)bindable;
            control._lblText.Text = (string)newValue;

            if (!string.IsNullOrEmpty(control._lblText.Text) && control._lblText.Text.Length >= 2)
                control._frmContainer.WidthRequest = -1;
            else
                control._frmContainer.WidthRequest = 16;
        }

        public void SetMaterialBadgeType()
        {
            switch (Type)
            {
                case MaterialBadgeType.Small:
                    this._frmContainer.Padding = new Thickness(0);
                    this._frmContainer.HeightRequest = 6;
                    this._frmContainer.WidthRequest = 6;
                    this._frmContainer.CornerRadius = 3;
                    this._frmContainer.MinimumWidthRequest = 6;
                    this._frmContainer.MinimumHeightRequest = 6;
                    this._lblText.IsVisible = false;
                    break;
                case MaterialBadgeType.Large:
                    this._frmContainer.Padding = new Thickness(4);
                    this._frmContainer.CornerRadius = 12;
                    this._frmContainer.HeightRequest = 16;
                    this._frmContainer.MinimumHeightRequest = 16;
                    this._frmContainer.MinimumWidthRequest = 16;
                    this._lblText.IsVisible = true;

                    if (!string.IsNullOrEmpty(this._lblText.Text) && this._lblText.Text.Length >= 2)
                        this._frmContainer.WidthRequest = -1;
                    else
                        this._frmContainer.WidthRequest = 16;
                    break;
            }
        }

        #endregion Methods
    }
}