using Plugin.MaterialDesignControls.Styles;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
[assembly: ExportFont("Roboto-Bold.ttf.ttf")]
namespace ExampleMaterialDesignControls
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }
    }
}