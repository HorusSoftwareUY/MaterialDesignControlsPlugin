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
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MaterialBadge), defaultValue: DefaultStyles.FontSizes.LabelSmall);

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

        public static readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(MaterialBadge), defaultValue: 8.0);

        public double CornerRadius
        {
            get { return (double)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly new BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(MaterialBadge), defaultValue: new Thickness(16, 0));

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

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

            HorizontalOptions = LayoutOptions.Center;
            VerticalOptions = LayoutOptions.Center;

            this._frmContainer = new MaterialCard()
            {
                BackgroundColor = this.BackgroundColor,
                CornerRadiusBottomLeft = true,
                CornerRadiusBottomRight = true,
                CornerRadiusTopLeft = true,
                CornerRadiusTopRight = true,
                CornerRadius = (float)CornerRadius,
                Padding = 0
            };

            this._lblText = new Label()
            {
                Text = this.Text,
                TextColor = this.TextColor,
                FontSize = this.FontSize,
                FontFamily = this.FontFamily,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
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
                case nameof(BackgroundColor):
                    this._frmContainer.BackgroundColor = BackgroundColor;
                    break;
                case nameof(CornerRadius):
                    this._frmContainer.CornerRadius = (float)CornerRadius;
                    break;
                case nameof(Padding):
                    this._frmContainer.Padding = Padding;
                    break;
                default:
                    base.OnPropertyChanged(propertyName);
                    break;
            }
        }

        private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialBadge)bindable;
            control._lblText.Text = (string)newValue;

            control.SetPropertiesReleatedToText();
        }

        private void SetPropertiesReleatedToText()
        {
            if (!string.IsNullOrEmpty(this._lblText.Text) && this._lblText.Text.Length >= 2)
            {
                this._frmContainer.Padding = new Thickness(4, 0);
                this._frmContainer.WidthRequest = -1;
            }
            else
            {
                this._frmContainer.Padding = new Thickness(0);
                this._frmContainer.WidthRequest = 16;
            }
        }

        public void SetMaterialBadgeType()
        {
            switch (Type)
            {
                case MaterialBadgeType.Small:
                    this._frmContainer.Padding = new Thickness(0);
                    HeightRequest = 6;
                    WidthRequest = 6;
                    CornerRadius = 3;
                    MinimumWidthRequest = 6;
                    MinimumHeightRequest = 6;
                    this._lblText.IsVisible = false;
                    break;
                case MaterialBadgeType.Large:
                    CornerRadius = 8;
                    HeightRequest = 16;
                    MinimumHeightRequest = 16;
                    MinimumWidthRequest = 16;
                    this._lblText.IsVisible = true;

                    SetPropertiesReleatedToText();
                    break;
            }
        }

        #endregion Methods
    }
}