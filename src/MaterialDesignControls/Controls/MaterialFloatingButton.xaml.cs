using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialFloatingButton : CustomFrame, ITouchAndPressEffectConsumer
    {

        #region Attributes

        private bool initilized = false;

        public event EventHandler Clicked;

        #endregion Attributes

        #region Properties

        public static readonly BindableProperty CustomIconProperty =
            BindableProperty.Create(nameof(CustomIcon), typeof(DataTemplate), typeof(MaterialFloatingButton), defaultValue: null);

        public DataTemplate CustomIcon
        {
            get { return (DataTemplate)GetValue(CustomIconProperty); }
            set { SetValue(CustomIconProperty, value); }
        }

        public static new readonly BindableProperty HasShadowProperty =
            BindableProperty.Create(nameof(HasShadow), typeof(bool), typeof(MaterialFloatingButton), defaultValue: true);

        public new bool HasShadow
        {
            get { return (bool)GetValue(HasShadowProperty); }
            set { SetValue(HasShadowProperty, value); }
        }

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(MaterialFloatingButton), defaultValue: null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(MaterialFloatingButton), defaultValue: null);

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialFloatingButton), defaultValue: string.Empty);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty FontSizeProperty =
            BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MaterialFloatingButton), defaultValue: Font.Default.FontSize);

        public double FontSize
        {
            get { return (double)GetValue(FontSizeProperty); }
            set { SetValue(FontSizeProperty, value); }
        }

        public static readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(MaterialFloatingButton), defaultValue: null);

        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public static readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialFloatingButton), defaultValue: Color.Gray);

        public Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty IconProperty =
            BindableProperty.Create(nameof(Icon), typeof(string), typeof(MaterialFloatingButton), defaultValue: null);

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly BindableProperty IconHeightRequestProperty =
            BindableProperty.Create(nameof(IconHeightRequest), typeof(double), typeof(MaterialFloatingButton), defaultValue: 24.0);

        public double IconHeightRequest
        {
            get { return (double)GetValue(IconHeightRequestProperty); }
            set { SetValue(IconHeightRequestProperty, value); }
        }

        public static readonly BindableProperty IconWidthRequestProperty =
            BindableProperty.Create(nameof(IconWidthRequest), typeof(double), typeof(MaterialFloatingButton), defaultValue: 24.0);

        public double IconWidthRequest
        {
            get { return (double)GetValue(IconWidthRequestProperty ); }
            set { SetValue(IconWidthRequestProperty , value); }
        }

        public static new readonly BindableProperty HeightRequestProperty =
            BindableProperty.Create(nameof(HeightRequest), typeof(double), typeof(MaterialFloatingButton), defaultValue: 56.0);

        public new double HeightRequest
        {
            get { return (double)GetValue(HeightRequestProperty); }
            set { SetValue(HeightRequestProperty, value); }
        }

        public static new readonly BindableProperty WidthRequestProperty =
            BindableProperty.Create(nameof(WidthRequest), typeof(double), typeof(MaterialFloatingButton), defaultValue: 56.0);

        public new double WidthRequest
        {
            get { return (double)GetValue(WidthRequestProperty); }
            set { SetValue(WidthRequestProperty, value); }
        }

        public static new readonly BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(MaterialFloatingButton), defaultValue: new Thickness(0));

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
	    }

        public static readonly BindableProperty ButtonSizeProperty =
            BindableProperty.Create(nameof(ButtonSize), typeof(FloatingButtonSize), typeof(MaterialFloatingButton), defaultValue: FloatingButtonSize.Regular);

        public FloatingButtonSize ButtonSize
        {
            get { return (FloatingButtonSize)GetValue(ButtonSizeProperty ); }
            set { SetValue(ButtonSizeProperty , value); }
        }

        public static new readonly BindableProperty CornerRadiusProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(float), defaultValue: 28.0F);

        public new float CornerRadius
        {
            get { return (float)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly BindableProperty IconSideProperty =
            BindableProperty.Create(nameof(IconSide), typeof(IconSide), typeof(MaterialFloatingButton), defaultValue: IconSide.Left);

        public IconSide IconSide
        {
            get { return (IconSide)GetValue(IconSideProperty); }
            set { SetValue(IconSideProperty, value); }
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

        #region Constructors

        public MaterialFloatingButton()
        {
            InitializeComponent();

            if (!this.initilized)
                Initialize();
        }

        #endregion Constructors

        #region Methods

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(HasShadow):
                    base.HasShadow = HasShadow;
                    break;
                case nameof(Padding):
                    base.Padding = Padding;
                    break;
                case nameof(HeightRequest):
                    base.HeightRequest = HeightRequest;
                    break;
                case nameof(WidthRequest):
                    base.WidthRequest = WidthRequest;
                    break;
                case nameof(FontSize):
                    lblText.FontSize = FontSize;
                    break;
                case nameof(FontFamily):
                    lblText.FontFamily = FontFamily;
                    break;
                case nameof(TextColor):
                    lblText.TextColor = TextColor;
                    break;
                case nameof(ButtonSize):
                    SetButtonSize();
                    break;
                case nameof(Icon):
                    if (Icon == null)
                        break;
                    imgLeft.SetImage(Icon);
                    imgLeft.IsVisible = true;
                    break;
                case nameof(CustomIcon):
                    if (CustomIcon == null)
                        break;
                    if (IconSide == IconSide.Left)
                    {
                        imgLeft.SetCustomImage(this.CustomIcon.CreateContent() as View);
                        imgLeft.IsVisible = true;
                    }
                    else 
		            { 
                        imgRight.SetCustomImage(this.CustomIcon.CreateContent() as View);
                        imgRight.IsVisible = true;
		            }
                    break;
                case nameof(IconSide):
                    if (IconSide == IconSide.Left)
                    {
                        imgLeft.IsVisible = true;
                        imgLeft.SetImage(Icon);
                    }
                    else
                    {
                        imgLeft.IsVisible = false;
                        imgRight.IsVisible = true;
                        imgRight.SetImage(Icon);
                        lblText.Margin = new Thickness(0, 0, 6, 0);
                        Padding = new Thickness(16, 0, 16, 0);
                    }
                    break;
                case nameof(CornerRadius):
                    base.CornerRadius = CornerRadius;
                    break;
                case nameof(IconHeightRequest):
                    imgLeft.HeightRequest = IconHeightRequest;
                    imgRight.HeightRequest = IconHeightRequest;
                    break;
                case nameof(IconWidthRequest):
                    imgLeft.WidthRequest = IconWidthRequest;
                    imgRight.WidthRequest = IconWidthRequest;
                    break;
            }
        }


        private void SetButtonSize()
        {
            imgLeft.HeightRequest = IconHeightRequest;
            imgLeft.WidthRequest = IconWidthRequest;
            imgLeft.SetImage(Icon);
            imgLeft.IsVisible = true;
            if (ButtonSize == FloatingButtonSize.Mini)
            {
                HeightRequest = 40;
                WidthRequest = 40;
                CornerRadius = 20;
	        }
            else if (ButtonSize == FloatingButtonSize.Extended)
            {
                if (!string.IsNullOrEmpty(Text))
                    lblText.IsVisible = true;
                if (string.IsNullOrEmpty(Icon))
                    imgLeft.IsVisible = false;

                lblText.Text = Text.ToUpper();
                HeightRequest = 48;
                WidthRequest = -1;
                CornerRadius = 24;
                lblText.FontAttributes = FontAttributes.Bold;
                lblText.HorizontalTextAlignment = TextAlignment.Center;
                lblText.Margin = new Thickness(6, 0, 0, 0);
                Padding = new Thickness(12, 0, 20, 0);
            }
        }

        private void Initialize()
        {
            base.HasShadow = HasShadow;
            base.Padding = Padding;
            base.HeightRequest = HeightRequest;
            base.WidthRequest = WidthRequest;
            base.CornerRadius = CornerRadius;
            imgLeft.HeightRequest = IconHeightRequest;
            imgLeft.WidthRequest = IconWidthRequest;
            Effects.Add(new TouchAndPressEffect());
	    }

        public void ConsumeEvent(EventType gestureType)
        {
            TouchAndPressAnimation.Animate(this, gestureType);
        }

        public void ExecuteAction()
        {
            if (IsEnabled && Command != null && Command.CanExecute(CommandParameter))
                Command.Execute(CommandParameter);

            if (IsEnabled && Clicked != null)
                Clicked.Invoke(this, null);
        }

        #endregion Methods
    }
}
