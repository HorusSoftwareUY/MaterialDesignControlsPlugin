using System;
using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Styles;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public abstract class BaseMaterialCheckboxes : ContentView
    {
        #region Text

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(BaseMaterialCheckboxes), defaultValue: string.Empty);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(BaseMaterialCheckboxes), defaultValue: Color.Gray);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledTextColorProperty =
            BindableProperty.Create(nameof(DisabledTextColor), typeof(Color), typeof(BaseMaterialCheckboxes), defaultValue: Color.LightGray);

        public Color DisabledTextColor
        {
            get { return (Color)GetValue(DisabledTextColorProperty); }
            set { SetValue(DisabledTextColorProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(BaseMaterialCheckboxes), defaultValue: Font.Default.FontSize);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(BaseMaterialCheckboxes), defaultValue: null);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        #endregion Text

        #region AssistiveText

        public static readonly BindableProperty AssistiveTextProperty =
            BindableProperty.Create(nameof(AssistiveText), typeof(string), typeof(BaseMaterialCheckboxes), defaultValue: null, validateValue: OnAssistiveTextValidate);

        public string AssistiveText
        {
            get { return (string)GetValue(AssistiveTextProperty); }
            set { SetValue(AssistiveTextProperty, value); }
        }

        public static readonly BindableProperty AssistiveTextColorProperty =
            BindableProperty.Create(nameof(AssistiveTextColor), typeof(Color), typeof(BaseMaterialCheckboxes), defaultValue: Color.Gray);

        public Color AssistiveTextColor
        {
            get { return (Color)GetValue(AssistiveTextColorProperty); }
            set { SetValue(AssistiveTextColorProperty, value); }
        }

        public static readonly BindableProperty AssistiveSizeProperty =
            BindableProperty.Create(nameof(AssistiveSize), typeof(double), typeof(BaseMaterialCheckboxes), defaultValue: Font.Default.FontSize);

        public double AssistiveSize
        {
            get { return (double)GetValue(AssistiveSizeProperty); }
            set { SetValue(AssistiveSizeProperty, value); }
        }

        public static readonly BindableProperty AssistiveFontFamilyProperty =
            BindableProperty.Create(nameof(AssistiveFontFamily), typeof(string), typeof(BaseMaterialCheckboxes), defaultValue: null);

        public string AssistiveFontFamily
        {
            get { return (string)GetValue(AssistiveFontFamilyProperty); }
            set { SetValue(AssistiveFontFamilyProperty, value); }
        }

        public static readonly BindableProperty AssistiveMarginProperty =
            BindableProperty.Create(nameof(AssistiveMargin), typeof(Thickness), typeof(BaseMaterialCheckboxes), defaultValue: new Thickness(14, 2, 14, 0));

        public Thickness AssistiveMargin
        {
            get { return (Thickness)GetValue(AssistiveMarginProperty); }
            set { SetValue(AssistiveMarginProperty, value); }
        }

        public static readonly BindableProperty AnimateErrorProperty =
            BindableProperty.Create(nameof(AnimateError), typeof(bool), typeof(BaseMaterialCheckboxes), defaultValue: false);

        public bool AnimateError
        {
            get { return (bool)GetValue(AnimateErrorProperty); }
            set { SetValue(AnimateErrorProperty, value); }
        }

        #endregion AssistiveText

        #region Icon

        public static readonly BindableProperty UnselectedIconProperty =
            BindableProperty.Create(nameof(UnselectedIcon), typeof(string), typeof(BaseMaterialCheckboxes), defaultValue: null);

        public string UnselectedIcon
        {
            get { return (string)GetValue(UnselectedIconProperty); }
            set { SetValue(UnselectedIconProperty, value); }
        }

        public static readonly BindableProperty SelectedIconProperty =
            BindableProperty.Create(nameof(SelectedIcon), typeof(string), typeof(BaseMaterialCheckboxes), defaultValue: null);

        public string SelectedIcon
        {
            get { return (string)GetValue(SelectedIconProperty); }
            set { SetValue(SelectedIconProperty, value); }
        }

        public static readonly BindableProperty DisabledUnselectedIconProperty =
            BindableProperty.Create(nameof(DisabledUnselectedIcon), typeof(string), typeof(BaseMaterialCheckboxes), defaultValue: null);

        public string DisabledUnselectedIcon
        {
            get { return (string)GetValue(DisabledUnselectedIconProperty); }
            set { SetValue(DisabledUnselectedIconProperty, value); }
        }

        public static readonly BindableProperty DisabledSelectedIconProperty =
            BindableProperty.Create(nameof(DisabledSelectedIcon), typeof(string), typeof(BaseMaterialCheckboxes), defaultValue: null);

        public string DisabledSelectedIcon
        {
            get { return (string)GetValue(DisabledSelectedIconProperty); }
            set { SetValue(DisabledSelectedIconProperty, value); }
        }

        public static readonly BindableProperty CustomUnselectedIconProperty =
            BindableProperty.Create(nameof(CustomUnselectedIcon), typeof(DataTemplate ), typeof(BaseMaterialCheckboxes), defaultValue: null);

        public DataTemplate CustomUnselectedIcon
        {
            get { return (DataTemplate )GetValue(CustomUnselectedIconProperty); }
            set { SetValue(CustomUnselectedIconProperty, value); }
        }

        public static readonly BindableProperty CustomSelectedIconProperty =
            BindableProperty.Create(nameof(CustomSelectedIcon), typeof(DataTemplate), typeof(BaseMaterialCheckboxes), defaultValue: null);

        public DataTemplate CustomSelectedIcon
        {
            get { return (DataTemplate)GetValue(CustomSelectedIconProperty); }
            set { SetValue(CustomSelectedIconProperty, value); }
        }

        public static readonly BindableProperty CustomDisabledUnselectedIconProperty =
            BindableProperty.Create(nameof(CustomDisabledUnselectedIcon), typeof(DataTemplate ), typeof(BaseMaterialCheckboxes), defaultValue: null);

        public DataTemplate CustomDisabledUnselectedIcon
        {
            get { return (DataTemplate )GetValue(CustomDisabledUnselectedIconProperty); }
            set { SetValue(CustomDisabledUnselectedIconProperty, value); }
        }

        public static readonly BindableProperty CustomDisabledSelectedIconProperty =
            BindableProperty.Create(nameof(CustomDisabledSelectedIcon), typeof(DataTemplate ), typeof(BaseMaterialCheckboxes), defaultValue: null);

        public DataTemplate CustomDisabledSelectedIcon
        {
            get { return (DataTemplate )GetValue(CustomDisabledSelectedIconProperty); }
            set { SetValue(CustomDisabledSelectedIconProperty, value); }
        }

        public static readonly BindableProperty IconHeightRequestProperty =
            BindableProperty.Create(nameof(IconHeightRequest), typeof(double), typeof(BaseMaterialCheckboxes), defaultValue: 24.0);

        public double IconHeightRequest
        {
            get { return (double)GetValue(IconHeightRequestProperty); }
            set { SetValue(IconHeightRequestProperty, value); }
        }

        public static readonly BindableProperty IconWidthRequestProperty =
            BindableProperty.Create(nameof(IconWidthRequest), typeof(double), typeof(BaseMaterialCheckboxes), defaultValue: 24.0);

        public double IconWidthRequest
        {
            get { return (double)GetValue(IconWidthRequestProperty); }
            set { SetValue(IconWidthRequestProperty, value); }
        }

        #endregion Icon

        public static readonly BindableProperty TextSideProperty =
            BindableProperty.Create(nameof(TextSide), typeof(TextSide), typeof(BaseMaterialCheckboxes), defaultValue: TextSide.Right);

        public TextSide TextSide
        {
            get { return (TextSide)GetValue(TextSideProperty); }
            set { SetValue(TextSideProperty, value); }
        }

        public static readonly BindableProperty TextHorizontalOptionsProperty =
            BindableProperty.Create(nameof(TextHorizontalOptions), typeof(LayoutOptions), typeof(BaseMaterialCheckboxes), defaultValue: LayoutOptions.Start);

        public LayoutOptions TextHorizontalOptions
        {
            get { return (LayoutOptions)GetValue(TextHorizontalOptionsProperty); }
            set { SetValue(TextHorizontalOptionsProperty, value); }
        }

        public static readonly BindableProperty SelectionHorizontalOptionsProperty =
            BindableProperty.Create(nameof(SelectionHorizontalOptions), typeof(LayoutOptions), typeof(BaseMaterialCheckboxes), defaultValue: LayoutOptions.Start);

        public LayoutOptions SelectionHorizontalOptions
        {
            get { return (LayoutOptions)GetValue(SelectionHorizontalOptionsProperty); }
            set { SetValue(SelectionHorizontalOptionsProperty, value); }
	    }

        public static readonly BindableProperty SpacingProperty =
            BindableProperty.Create(nameof(Spacing), typeof(double), typeof(BaseMaterialCheckboxes), defaultValue: 10.0);

        public double Spacing
        {
            get { return (double)GetValue(SpacingProperty); }
            set { SetValue(SpacingProperty, value); }
        }

        public static readonly BindableProperty IsCheckedProperty =
            BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(BaseMaterialCheckboxes), defaultValue: false, defaultBindingMode: BindingMode.TwoWay, propertyChanged: OnIsCheckedChanged);

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
        }

        public static new readonly BindableProperty IsEnabledProperty =
            BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(BaseMaterialCheckboxes), defaultValue: true);

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public static readonly BindableProperty AnimationProperty =
            BindableProperty.Create(nameof(Animation), typeof(AnimationTypes), typeof(BaseMaterialCheckboxes), defaultValue: AnimationTypes.None);

        public AnimationTypes Animation
        {
            get { return (AnimationTypes)GetValue(AnimationProperty); }
            set { SetValue(AnimationProperty, value); }
        }

        public static readonly BindableProperty AnimationParameterProperty =
            BindableProperty.Create(nameof(AnimationParameter), typeof(double?), typeof(BaseMaterialCheckboxes), defaultValue: null);

        public double? AnimationParameter
        {
            get { return (double?)GetValue(AnimationParameterProperty); }
            set { SetValue(AnimationParameterProperty, value); }
        }

        public static readonly BindableProperty CustomAnimationProperty =
            BindableProperty.Create(nameof(CustomAnimation), typeof(ICustomAnimation), typeof(BaseMaterialCheckboxes), defaultValue: null);

        public ICustomAnimation CustomAnimation
        {
            get { return (ICustomAnimation)GetValue(CustomAnimationProperty); }
            set { SetValue(CustomAnimationProperty, value); }
        }

        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create(nameof(Color), typeof(Color), typeof(BaseMaterialCheckboxes), defaultValue: DefaultStyles.PrimaryColor);

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly BindableProperty DisabledColorProperty =
            BindableProperty.Create(nameof(DisabledColor), typeof(Color), typeof(BaseMaterialCheckboxes), defaultValue: Color.LightGray);

        public Color DisabledColor
	    {
            get { return (Color)GetValue(DisabledColorProperty); }
            set { SetValue(DisabledColorProperty, value); }
        }

        #region Events

        public event EventHandler IsCheckedChanged;

        #endregion Events

        #region Methods

        protected void UpdateLayout(string propertyName, StackLayout container ,Label lblAssistive)
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
                case nameof(AssistiveText):
                    lblAssistive.Text = AssistiveText;
                    lblAssistive.IsVisible = !string.IsNullOrEmpty(AssistiveText);
                    if (AnimateError && !string.IsNullOrEmpty(AssistiveText))
                        Device.BeginInvokeOnMainThread( ()=> { ShakeAnimation.Animate(this); });
                    break;
                case nameof(AssistiveTextColor):
                    lblAssistive.TextColor = AssistiveTextColor;
                    break;
                case nameof(AssistiveSize):
                    lblAssistive.FontSize = AssistiveSize;
                    break;
                case nameof(AssistiveFontFamily):
                    lblAssistive.FontFamily = AssistiveFontFamily;
                    break;
                case nameof(AssistiveMargin):
                    lblAssistive.Margin = AssistiveMargin;
                    break;

            }
        }

        private static void OnIsCheckedChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (BaseMaterialCheckboxes)bindable;
            control.SetIsChecked();
            control.IsCheckedChanged?.Invoke(control, null);
        }

        private static bool OnAssistiveTextValidate(BindableObject bindable, object value)
        {
            var control = (BaseMaterialCheckboxes)bindable;

            // Used to animate the error when the assistive text doesn't change
            if (control.AnimateError && !string.IsNullOrEmpty(control.AssistiveText) && control.AssistiveText == (string)value)
                ShakeAnimation.Animate(control);

            return true;
        }
        protected abstract void SetIcon();

        protected abstract void SetIsChecked();
        
        protected abstract void SetIsEnabled();

        #endregion Methods

    }
}
