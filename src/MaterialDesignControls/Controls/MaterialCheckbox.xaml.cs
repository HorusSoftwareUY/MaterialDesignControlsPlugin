using System;
using System.Runtime.CompilerServices;
using Plugin.MaterialDesignControls.Animations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialCheckbox : BaseMaterialCheckboxes, ITouchAndPressEffectConsumer
    {
        private bool Initialized = false;

        public MaterialCheckbox()
        {
            InitializeComponent();
            if (!Initialized)
            {
                Initialized = true;
                Initialize();
                AddTapGesture();
            };
        }

        #region Properties

        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create(nameof(Color), typeof(Color), typeof(MaterialCheckbox), defaultValue: Color.Blue);

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly BindableProperty DisabledColorProperty =
            BindableProperty.Create(nameof(DisabledColor), typeof(Color), typeof(MaterialCheckbox), defaultValue: Color.LightGray);

        public Color DisabledColor
	    {
            get { return (Color)GetValue(DisabledColorProperty); }
            set { SetValue(DisabledColorProperty, value); }
        }

        public static readonly BindableProperty SelectionHorizontalOptionsProperty =
            BindableProperty.Create(nameof(SelectionHorizontalOptions), typeof(LayoutOptions), typeof(MaterialCheckbox), defaultValue: LayoutOptions.Start);

        public LayoutOptions SelectionHorizontalOptions
        {
            get { return (LayoutOptions)GetValue(SelectionHorizontalOptionsProperty); }
            set { SetValue(SelectionHorizontalOptionsProperty, value); }
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

        #endregion Properties

        #region Methods

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            UpdateLayout(propertyName,lblLeftText,lblRightText, container, customIcon, lblAssistive);

            switch (propertyName)
            {
                case nameof(Color):
                case nameof(DisabledColor):
                    chk.Color = IsEnabled ? Color : DisabledColor;
                    break;
                case nameof(SelectionHorizontalOptions):
                    chk.HorizontalOptions = SelectionHorizontalOptions;
                    customIcon.HorizontalOptions = SelectionHorizontalOptions;
                    break;
                case nameof(IsEnabled):
                    SetIsEnabled();
                    break;
	        }
        }

        private void Initialize()
        {
            Spacing = Spacing;
            TextSide = TextSide;
            SelectionHorizontalOptions = SelectionHorizontalOptions;
            chk.IsEnabled = IsEnabled;
            chk.Color = Color;
            customIcon.ImageHeightRequest = IconHeightRequest;
            customIcon.ImageWidthRequest = IconWidthRequest;
            customIcon.Padding = 0;
            Effects.Add(new TouchAndPressEffect());
	    }

        protected override void SetIcon()
        {
            chkContainer.IsVisible = false;
            customIcon.IsVisible = true;
            SetIsChecked();
            SetIsEnabled();
        }

        protected override void SetIsChecked()
        {
            chk.IsChecked = IsChecked;
            if (IsChecked)
                if (CustomSelectedIcon != null)
                    customIcon.SetCustomImage(CustomSelectedIcon);
                else
                    customIcon.SetImage(SelectedIcon);
            else
                if (CustomUnselectedIcon != null)
                    customIcon.SetCustomImage(CustomUnselectedIcon);
                else
                    customIcon.SetImage(UnselectedIcon);
        }

        protected override void SetIsEnabled()
        {
            chk.IsEnabled = IsEnabled;
            chk.Color = IsEnabled ? Color : DisabledColor;
            lblLeftText.TextColor = IsEnabled ? TextColor : DisabledTextColor;
            lblRightText.TextColor = IsEnabled ? TextColor : DisabledTextColor;

            if (!IsEnabled)
            { 
                if (IsChecked)
                {
                    if (CustomDisabledSelectedIcon != null)
                        customIcon.SetCustomImage(CustomDisabledSelectedIcon);
                    else if (CustomSelectedIcon != null)
                        customIcon.SetCustomImage(CustomSelectedIcon);
                    else
                        customIcon.SetImage(DisabledSelectedIcon);
		        }
                else 
		        {
                    if (CustomDisabledUnselectedIcon != null)
                        customIcon.SetCustomImage(CustomDisabledUnselectedIcon);
                    else if (CustomUnselectedIcon != null)
                        customIcon.SetCustomImage(CustomUnselectedIcon);
                    else
                        customIcon.SetImage(DisabledUnselectedIcon);
		        }
	        }
        }

        private void AddTapGesture()
        {
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            //   ClickGestureRecognizer clickGestureRecognizer = new ClickGestureRecognizer();
            //   clickGestureRecognizer.Clicked += (s, e) => 
            //{ 
            //       if (IsEnabled)
            //           IsChecked = !IsChecked;
            //};
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                if (IsEnabled)
                    IsChecked = !IsChecked;
            };
            //lblRightText.GestureRecognizers.Add(tapGestureRecognizer);
            //container.GestureRecognizers.Add(tapGestureRecognizer);
            this.GestureRecognizers.Add(tapGestureRecognizer);
	    }

        public void ConsumeEvent(EventType gestureType)
        {
            TouchAndPressAnimation.Animate(this, gestureType);
        }

        public void ExecuteAction(){}

        #endregion Methods
    }
}
