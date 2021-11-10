using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialCheckbox : BaseMaterialCheckboxes
    {
        private bool Initialized = false;

        public MaterialCheckbox()
        {

            InitializeComponent();
            if (!Initialized)
            {
                Initialized = true;
                Initialize();
            }

            customIcon.Tapped = () => { IsChecked = !IsChecked; };

        }

        #region Properties

        public static readonly BindableProperty ColorProperty =
            BindableProperty.Create(nameof(Color), typeof(Color), typeof(BaseMaterialCheckboxes), defaultValue: Color.BlueViolet);

        public Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static readonly BindableProperty SelectionHorizontalOptionsProperty =
            BindableProperty.Create(nameof(SelectionHorizontalOptions), typeof(LayoutOptions), typeof(BaseMaterialCheckboxes), defaultValue: LayoutOptions.Start);

        public LayoutOptions SelectionHorizontalOptions
        {
            get { return (LayoutOptions)GetValue(SelectionHorizontalOptionsProperty); }
            set { SetValue(SelectionHorizontalOptionsProperty, value); }
	    }

        #endregion Properties

        #region Methods

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            UpdateLayout(propertyName,lblLeftText,lblRightText, container, customIcon);

            switch (propertyName)
            {
                case nameof(Color):
                    chk.Color = Color;
                    break;
                case nameof(SelectionHorizontalOptions):
                    chk.HorizontalOptions = SelectionHorizontalOptions;
                    customIcon.HorizontalOptions = SelectionHorizontalOptions;
                    break;
	        }

        }

        private void Initialize()
        {
            Spacing = Spacing;
            TextSide = TextSide;
            SelectionHorizontalOptions = SelectionHorizontalOptions;
            customIcon.HeightRequest = IconHeightRequest;
            customIcon.WidthRequest = IconWidthRequest;
	    }

        protected override void SetIcon()
        {
            chk.IsVisible = false;
            customIcon.IsVisible = true;
            SetIsChecked();
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

        public void ConsumeEvent(EventType gestureType)
        {
            throw new System.NotImplementedException();
        }

        public void ExecuteAction()
        {
            throw new System.NotImplementedException();
        }

        #endregion Methods
    }
}
