using System.Runtime.CompilerServices;
using Plugin.MaterialDesignControls.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialFloatingButton : CustomFrame
    {
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
            get { return (string)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public MaterialFloatingButton()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(Text):
                    if (!string.IsNullOrEmpty(Text))
                    { 
                        lblText.Text = Text;
                        lblText.IsVisible = true;
		            }
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
                case nameof(Icon):
                    if (Icon !=null)
                    {
                        imgLeft.SetImage(Icon);
                        imgLeft.IsVisible = true;
                    }
                    break;
            }
        }
    }
}
