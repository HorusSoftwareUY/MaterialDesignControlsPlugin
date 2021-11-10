using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public abstract class BaseMaterialCheckboxes: ContentView, ITouchAndPressEffectConsumer
    {

        #region Text

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(BaseMaterialCheckboxes), defaultValue: string.Empty);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextColorProperty, value); }
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
            BindableProperty.Create(nameof(AssistiveText), typeof(string), typeof(BaseMaterialCheckboxes), defaultValue: null);

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

        #endregion AssistiveText

        #region LabelText

        public static readonly BindableProperty LabelTextProperty =
            BindableProperty.Create(nameof(LabelText), typeof(string), typeof(BaseMaterialCheckboxes), defaultValue: null);

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public static readonly BindableProperty LabelTextColorProperty =
            BindableProperty.Create(nameof(LabelTextColor), typeof(Color), typeof(BaseMaterialCheckboxes), defaultValue: Color.Gray);

        public Color LabelTextColor
        {
            get { return (Color)GetValue(LabelTextColorProperty); }
            set { SetValue(LabelTextColorProperty, value); }
        }

        public static readonly BindableProperty FocusedLabelTextColorProperty =
            BindableProperty.Create(nameof(FocusedLabelTextColor), typeof(Color), typeof(BaseMaterialCheckboxes), defaultValue: Color.Transparent);

        public Color FocusedLabelTextColor
        {
            get { return (Color)GetValue(FocusedLabelTextColorProperty); }
            set { SetValue(FocusedLabelTextColorProperty, value); }
        }

        public static readonly BindableProperty DisabledLabelTextColorProperty =
            BindableProperty.Create(nameof(DisabledLabelTextColor), typeof(Color), typeof(BaseMaterialCheckboxes), defaultValue: Color.Gray);

        public Color DisabledLabelTextColor
        {
            get { return (Color)GetValue(DisabledLabelTextColorProperty); }
            set { SetValue(DisabledLabelTextColorProperty, value); }
        }

        public static readonly BindableProperty LabelSizeProperty =
            BindableProperty.Create(nameof(LabelSize), typeof(double), typeof(BaseMaterialCheckboxes), defaultValue: Font.Default.FontSize);

        public double LabelSize
        {
            get { return (double)GetValue(LabelSizeProperty); }
            set { SetValue(LabelSizeProperty, value); }
        }

        public static readonly BindableProperty LabelFontFamilyProperty =
            BindableProperty.Create(nameof(LabelFontFamily), typeof(string), typeof(BaseMaterialCheckboxes), defaultValue: null);

        public string LabelFontFamily
        {
            get { return (string)GetValue(LabelFontFamilyProperty); }
            set { SetValue(LabelFontFamilyProperty, value); }
        }

        public static readonly BindableProperty LabelMarginProperty =
            BindableProperty.Create(nameof(LabelMargin), typeof(Thickness), typeof(BaseMaterialCheckboxes), defaultValue: new Thickness(14, 0, 14, 2));

        public Thickness LabelMargin
        {
            get { return (Thickness)GetValue(LabelMarginProperty); }
            set { SetValue(LabelMarginProperty, value); }
        }

        #endregion LabelText

        #region Icon

        public static readonly BindableProperty UnselectedIconProperty =
            BindableProperty.Create(nameof(UnselectedIcon), typeof(string), typeof(BaseMaterialCheckboxes), defaultValue: null);

        public string UnselectedIcon
	    {
            get { return (string)GetValue(UnselectedIconProperty ); }
            set { SetValue(UnselectedIconProperty , value); }
	    }

        public static readonly BindableProperty SelectedIconProperty =
            BindableProperty.Create(nameof(SelectedIcon), typeof(string), typeof(BaseMaterialCheckboxes), defaultValue: null);

        public string SelectedIcon
        {
            get { return (string)GetValue(SelectedIconProperty ); }
            set { SetValue(SelectedIconProperty , value); }
	    }

        public static readonly BindableProperty CustomUnselectedIconProperty =
            BindableProperty.Create(nameof(CustomUnselectedIcon), typeof(View), typeof(BaseMaterialCheckboxes), defaultValue: null);

        public View CustomUnselectedIcon
        {
            get { return (View)GetValue(CustomUnselectedIconProperty); }
            set { SetValue(CustomUnselectedIconProperty, value); }
	    }

        public static readonly BindableProperty CustomSelectedIconProperty =
            BindableProperty.Create(nameof(CustomSelectedIcon), typeof(View), typeof(BaseMaterialCheckboxes), defaultValue: null);

        public View CustomSelectedIcon
        {
            get { return (View)GetValue(CustomSelectedIconProperty); }
            set { SetValue(CustomSelectedIconProperty, value); }
	    }

        public static readonly BindableProperty IconHeightRequestProperty =
            BindableProperty.Create(nameof(IconHeightRequest), typeof(double), typeof(BaseMaterialCheckboxes), defaultValue: 25.0);

        public double IconHeightRequest
        {
            get { return (double)GetValue(IconHeightRequestProperty); }
            set { SetValue(IconHeightRequestProperty, value); }
	    }

        public static readonly BindableProperty IconWidthRequestProperty =
            BindableProperty.Create(nameof(IconWidthRequest), typeof(double), typeof(BaseMaterialCheckboxes), defaultValue: 25.0);

        public double IconWidthRequest
        {
            get { return (double)GetValue(IconWidthRequestProperty ); }
            set { SetValue(IconWidthRequestProperty , value); }
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

        public static readonly BindableProperty SpacingProperty =
            BindableProperty.Create(nameof(Spacing), typeof(double), typeof(BaseMaterialCheckboxes), defaultValue: 10.0);

        public double Spacing
        {
            get { return (double)GetValue(SpacingProperty); }
            set { SetValue(SpacingProperty, value); }
	    }

        public static readonly BindableProperty IsCheckedProperty =
            BindableProperty.Create(nameof(IsChecked), typeof(bool), typeof(BaseMaterialCheckboxes), defaultValue: false);

        public bool IsChecked
        {
            get { return (bool)GetValue(IsCheckedProperty); }
            set { SetValue(IsCheckedProperty, value); }
	    }

        public static readonly BindableProperty AnimationProperty =
            BindableProperty.Create(nameof(Animation), typeof(AnimationTypes), typeof(MaterialButton), defaultValue: AnimationTypes.None);

        public AnimationTypes Animation
        {
            get { return (AnimationTypes)GetValue(AnimationProperty); }
            set { SetValue(AnimationProperty, value); }
        }

        public static readonly BindableProperty AnimationParameterProperty =
            BindableProperty.Create(nameof(AnimationParameter), typeof(double?), typeof(MaterialButton), defaultValue: null);

        public double? AnimationParameter
        {
            get { return (double?)GetValue(AnimationParameterProperty); }
            set { SetValue(AnimationParameterProperty, value); }
        }

        #region Methods

        protected void UpdateLayout(string propertyName, Label lblLeftText, Label lblRightText, StackLayout container, CustomImageButton customIcon)
        { 
            switch (propertyName)
            {
                case nameof(Text):
                    lblRightText.Text = Text;
                    break;
                case nameof(TextColor):
                    lblLeftText.TextColor = TextColor;
                    break;
                case nameof(DisabledTextColor):
                    lblLeftText.TextColor = TextColor;
                    break;
                case nameof(FontSize):
                    lblLeftText.FontSize = FontSize;
                    break;
                case nameof(FontFamily):
                    lblLeftText.FontFamily = FontFamily;
                    break;
                case nameof(TextSide):
                    if (TextSide == TextSide.Left)
                    { 
                        lblLeftText.Text = Text;
                        lblLeftText.IsVisible = true;
                        lblRightText.IsVisible = false;
                    }
                    break;
                case nameof(TextHorizontalOptions):
                    if (TextSide == TextSide.Left)
                        lblLeftText.HorizontalOptions = TextHorizontalOptions;
                    else
                        lblRightText.HorizontalOptions = TextHorizontalOptions;
                    break;
                case nameof(Spacing):
                    container.Spacing = Spacing;
                    break;
                case nameof(UnselectedIcon):
                case nameof(SelectedIcon):
                case nameof(CustomSelectedIcon):
                case nameof(CustomUnselectedIcon):
                    SetIcon();
                    break;
                //customIcon.IsVisible = true;
                ////checkbox is visible false
                //customIcon.SetImage(UnselectedIcon);
                case nameof(IconHeightRequest):
                    customIcon.HeightRequest = IconHeightRequest;
                    break;
                case nameof(IconWidthRequest):
                    customIcon.WidthRequest = IconWidthRequest;
                    break;
                case nameof(IsChecked):
                    SetIsChecked();
                    break;
	        }
	    }

        protected abstract void SetIcon();

        protected abstract void SetIsChecked();

        public void ConsumeEvent(EventType gestureType)
        {
            TouchAndPressAnimation.Animate(this, gestureType);
        }

        public void ExecuteAction() {}

        #endregion Methods

    }
}
