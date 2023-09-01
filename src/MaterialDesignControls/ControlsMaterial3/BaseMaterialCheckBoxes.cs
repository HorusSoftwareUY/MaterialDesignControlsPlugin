using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Styles;
using System;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3
{
    public abstract class BaseMaterialCheckBoxes : ContentView
    {
        #region Text

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(BaseMaterialCheckBoxes), defaultValue: string.Empty);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(BaseMaterialCheckBoxes), defaultValue: DefaultStyles.TextColor);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledTextColorProperty =
            BindableProperty.Create(nameof(DisabledTextColor), typeof(Color), typeof(BaseMaterialCheckBoxes), defaultValue: DefaultStyles.DisableColor);

        public Color DisabledTextColor
        {
            get { return (Color)GetValue(DisabledTextColorProperty); }
            set { SetValue(DisabledTextColorProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(BaseMaterialCheckBoxes), defaultValue: DefaultStyles.PhoneFontSizes.BodyLarge);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(BaseMaterialCheckBoxes), defaultValue: DefaultStyles.FontFamily);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        #endregion Text

        #region SupportingText

        public static readonly BindableProperty SupportingTextProperty =
            BindableProperty.Create(nameof(SupportingText), typeof(string), typeof(BaseMaterialCheckBoxes), defaultValue: null, validateValue: OnAssistiveTextValidate);

        public string SupportingText
        {
            get { return (string)GetValue(SupportingTextProperty); }
            set { SetValue(SupportingTextProperty, value); }
        }

        public static readonly BindableProperty SupportingTextColorProperty =
            BindableProperty.Create(nameof(SupportingTextColor), typeof(Color), typeof(BaseMaterialCheckBoxes), defaultValue: DefaultStyles.ErrorColor);

        public Color SupportingTextColor
        {
            get { return (Color)GetValue(SupportingTextColorProperty); }
            set { SetValue(SupportingTextColorProperty, value); }
        }

        public static readonly BindableProperty SupportingSizeProperty =
            BindableProperty.Create(nameof(SupportingSize), typeof(double), typeof(BaseMaterialCheckBoxes), defaultValue: DefaultStyles.PhoneFontSizes.BodySmall);

        public double SupportingSize
        {
            get { return (double)GetValue(SupportingSizeProperty); }
            set { SetValue(SupportingSizeProperty, value); }
        }

        public static readonly BindableProperty SupportingFontFamilyProperty =
            BindableProperty.Create(nameof(SupportingFontFamily), typeof(string), typeof(BaseMaterialCheckBoxes), defaultValue: DefaultStyles.FontFamily);

        public string SupportingFontFamily
        {
            get { return (string)GetValue(SupportingFontFamilyProperty); }
            set { SetValue(SupportingFontFamilyProperty, value); }
        }

        public static readonly BindableProperty SupportingMarginProperty =
            BindableProperty.Create(nameof(SupportingMargin), typeof(Thickness), typeof(BaseMaterialCheckBoxes), defaultValue: new Thickness(16, 4, 16, 0));

        public Thickness SupportingMargin
        {
            get { return (Thickness)GetValue(SupportingMarginProperty); }
            set { SetValue(SupportingMarginProperty, value); }
        }

        public static readonly BindableProperty AnimateErrorProperty =
            BindableProperty.Create(nameof(AnimateError), typeof(bool), typeof(BaseMaterialCheckBoxes), defaultValue: DefaultStyles.AnimateError);

        public bool AnimateError
        {
            get { return (bool)GetValue(AnimateErrorProperty); }
            set { SetValue(AnimateErrorProperty, value); }
        }

        #endregion SupportingText

        #region Icon

        public static readonly BindableProperty UnselectedIconProperty =
            BindableProperty.Create(nameof(UnselectedIcon), typeof(string), typeof(BaseMaterialCheckBoxes), defaultValue: null);

        public string UnselectedIcon
        {
            get { return (string)GetValue(UnselectedIconProperty); }
            set { SetValue(UnselectedIconProperty, value); }
        }

        public static readonly BindableProperty SelectedIconProperty =
            BindableProperty.Create(nameof(SelectedIcon), typeof(string), typeof(BaseMaterialCheckBoxes), defaultValue: null);

        public string SelectedIcon
        {
            get { return (string)GetValue(SelectedIconProperty); }
            set { SetValue(SelectedIconProperty, value); }
        }

        public static readonly BindableProperty DisabledUnselectedIconProperty =
            BindableProperty.Create(nameof(DisabledUnselectedIcon), typeof(string), typeof(BaseMaterialCheckBoxes), defaultValue: null);

        public string DisabledUnselectedIcon
        {
            get { return (string)GetValue(DisabledUnselectedIconProperty); }
            set { SetValue(DisabledUnselectedIconProperty, value); }
        }

        public static readonly BindableProperty DisabledSelectedIconProperty =
            BindableProperty.Create(nameof(DisabledSelectedIcon), typeof(string), typeof(BaseMaterialCheckBoxes), defaultValue: null);

        public string DisabledSelectedIcon
        {
            get { return (string)GetValue(DisabledSelectedIconProperty); }
            set { SetValue(DisabledSelectedIconProperty, value); }
        }

        public static readonly BindableProperty CustomUnselectedIconProperty =
            BindableProperty.Create(nameof(CustomUnselectedIcon), typeof(DataTemplate), typeof(BaseMaterialCheckBoxes), defaultValue: null);

        public DataTemplate CustomUnselectedIcon
        {
            get { return (DataTemplate)GetValue(CustomUnselectedIconProperty); }
            set { SetValue(CustomUnselectedIconProperty, value); }
        }

        public static readonly BindableProperty CustomSelectedIconProperty =
            BindableProperty.Create(nameof(CustomSelectedIcon), typeof(DataTemplate), typeof(BaseMaterialCheckBoxes), defaultValue: null);

        public DataTemplate CustomSelectedIcon
        {
            get { return (DataTemplate)GetValue(CustomSelectedIconProperty); }
            set { SetValue(CustomSelectedIconProperty, value); }
        }

        public static readonly BindableProperty CustomDisabledUnselectedIconProperty =
            BindableProperty.Create(nameof(CustomDisabledUnselectedIcon), typeof(DataTemplate), typeof(BaseMaterialCheckBoxes), defaultValue: null);

        public DataTemplate CustomDisabledUnselectedIcon
        {
            get { return (DataTemplate)GetValue(CustomDisabledUnselectedIconProperty); }
            set { SetValue(CustomDisabledUnselectedIconProperty, value); }
        }

        public static readonly BindableProperty CustomDisabledSelectedIconProperty =
            BindableProperty.Create(nameof(CustomDisabledSelectedIcon), typeof(DataTemplate), typeof(BaseMaterialCheckBoxes), defaultValue: null);

        public DataTemplate CustomDisabledSelectedIcon
        {
            get { return (DataTemplate)GetValue(CustomDisabledSelectedIconProperty); }
            set { SetValue(CustomDisabledSelectedIconProperty, value); }
        }

        public static readonly BindableProperty IconHeightRequestProperty =
            BindableProperty.Create(nameof(IconHeightRequest), typeof(double), typeof(BaseMaterialCheckBoxes), defaultValue: 24.0);

        public double IconHeightRequest
        {
            get { return (double)GetValue(IconHeightRequestProperty); }
            set { SetValue(IconHeightRequestProperty, value); }
        }

        public static readonly BindableProperty IconWidthRequestProperty =
            BindableProperty.Create(nameof(IconWidthRequest), typeof(double), typeof(BaseMaterialCheckBoxes), defaultValue: 24.0);

        public double IconWidthRequest
        {
            get { return (double)GetValue(IconWidthRequestProperty); }
            set { SetValue(IconWidthRequestProperty, value); }
        }

        #endregion Icon

        public static readonly BindableProperty TextSideProperty =
            BindableProperty.Create(nameof(TextSide), typeof(TextSide), typeof(BaseMaterialCheckBoxes), defaultValue: TextSide.Right);

        public TextSide TextSide
        {
            get { return (TextSide)GetValue(TextSideProperty); }
            set { SetValue(TextSideProperty, value); }
        }

        public static readonly BindableProperty TextHorizontalOptionsProperty =
            BindableProperty.Create(nameof(TextHorizontalOptions), typeof(LayoutOptions), typeof(BaseMaterialCheckBoxes), defaultValue: LayoutOptions.Start);

        public LayoutOptions TextHorizontalOptions
        {
            get { return (LayoutOptions)GetValue(TextHorizontalOptionsProperty); }
            set { SetValue(TextHorizontalOptionsProperty, value); }
        }

        public static readonly BindableProperty SelectionHorizontalOptionsProperty =
            BindableProperty.Create(nameof(SelectionHorizontalOptions), typeof(LayoutOptions), typeof(BaseMaterialCheckBoxes), defaultValue: LayoutOptions.Start);

        public LayoutOptions SelectionHorizontalOptions
        {
            get { return (LayoutOptions)GetValue(SelectionHorizontalOptionsProperty); }
            set { SetValue(SelectionHorizontalOptionsProperty, value); }
        }

        public static readonly BindableProperty SpacingProperty =
            BindableProperty.Create(nameof(Spacing), typeof(double), typeof(BaseMaterialCheckBoxes), defaultValue: 10.0);

        public double Spacing
        {
            get { return (double)GetValue(SpacingProperty); }
            set { SetValue(SpacingProperty, value); }
        }

        public static readonly BindableProperty IsCheckedProperty =
            BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(BaseMaterialCheckBoxes), defaultValue: false, defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnIsCheckedChanged);

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        public static new readonly BindableProperty IsEnabledProperty =
            BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(BaseMaterialCheckBoxes), defaultValue: true);

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public static readonly BindableProperty AnimationProperty =
            BindableProperty.Create(nameof(Animation), typeof(AnimationTypes), typeof(BaseMaterialCheckBoxes), defaultValue: DefaultStyles.AnimationType);

        public AnimationTypes Animation
        {
            get { return (AnimationTypes)GetValue(AnimationProperty); }
            set { SetValue(AnimationProperty, value); }
        }

        public static readonly BindableProperty AnimationParameterProperty =
            BindableProperty.Create(nameof(AnimationParameter), typeof(double?), typeof(BaseMaterialCheckBoxes), defaultValue: DefaultStyles.AnimationParameter);

        public double? AnimationParameter
        {
            get { return (double?)GetValue(AnimationParameterProperty); }
            set { SetValue(AnimationParameterProperty, value); }
        }

        public static readonly BindableProperty CustomAnimationProperty =
            BindableProperty.Create(nameof(CustomAnimation), typeof(ICustomAnimation), typeof(BaseMaterialCheckBoxes), defaultValue: null);

        public ICustomAnimation CustomAnimation
        {
            get { return (ICustomAnimation)GetValue(CustomAnimationProperty); }
            set { SetValue(CustomAnimationProperty, value); }
        }

        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create(nameof(Color), typeof(Color), typeof(BaseMaterialCheckBoxes), defaultValue: DefaultStyles.PrimaryColor);

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly BindableProperty DisabledColorProperty =
            BindableProperty.Create(nameof(DisabledColor), typeof(Color), typeof(BaseMaterialCheckBoxes), defaultValue: DefaultStyles.DisableColor);

        public Color DisabledColor
        {
            get { return (Color)GetValue(DisabledColorProperty); }
            set { SetValue(DisabledColorProperty, value); }
        }

        #region Events

        public event EventHandler IsCheckedChanged;

        #endregion Events

        #region Methods

        protected void UpdateLayout(string propertyName, StackLayout container, Label lblSupporting)
        {
            switch (propertyName)
            {
                case nameof(Spacing):
                    container.Spacing = Spacing;
                    break;
                case nameof(UnselectedIcon):
                case nameof(SelectedIcon):
                case nameof(DisabledUnselectedIcon):
                case nameof(DisabledSelectedIcon):
                case nameof(CustomSelectedIcon):
                case nameof(CustomUnselectedIcon):
                case nameof(CustomDisabledSelectedIcon):
                case nameof(CustomDisabledUnselectedIcon):
                    SetIcon();
                    break;
                case nameof(IsChecked):
                    SetIsChecked();
                    break;
                case nameof(IsEnabled):
                    SetIsEnabled();
                    break;
                case nameof(SupportingText):
                    lblSupporting.Text = SupportingText;
                    lblSupporting.IsVisible = !string.IsNullOrEmpty(SupportingText);
                    if (AnimateError && !string.IsNullOrEmpty(SupportingText))
                        Device.BeginInvokeOnMainThread(() => { ShakeAnimation.Animate(this); });
                    break;
                case nameof(SupportingTextColor):
                    lblSupporting.TextColor = SupportingTextColor;
                    break;
                case nameof(SupportingSize):
                    lblSupporting.FontSize = SupportingSize;
                    break;
                case nameof(SupportingFontFamily):
                    lblSupporting.FontFamily = SupportingFontFamily;
                    break;
                case nameof(SupportingMargin):
                    lblSupporting.Margin = SupportingMargin;
                    break;

            }
        }

        private static void OnIsCheckedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (BaseMaterialCheckBoxes)bindable;
            control.SetIsChecked();
            control.IsCheckedChanged?.Invoke(control, null);
        }

        private static bool OnAssistiveTextValidate(BindableObject bindable, object value)
        {
            var control = (BaseMaterialCheckBoxes)bindable;

            // Used to animate the error when the assistive text doesn't change
            if (control.AnimateError && !string.IsNullOrEmpty(control.SupportingText) && control.SupportingText == (string)value)
                ShakeAnimation.Animate(control);

            return true;
        }
        protected abstract void SetIcon();

        protected abstract void SetIsChecked();

        protected abstract void SetIsEnabled();

        #endregion Methods
    }
}
