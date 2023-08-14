using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExampleMaterialDesignControls.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialNavigationDrawerPage : ContentPage
    {
        public MaterialNavigationDrawerPage()
        {
            InitializeComponent();
            BindingContext = new MaterialNavigationDrawerViewModel() { DisplayAlert = DisplayAlert, Navigation = Navigation };
        }
    }
}