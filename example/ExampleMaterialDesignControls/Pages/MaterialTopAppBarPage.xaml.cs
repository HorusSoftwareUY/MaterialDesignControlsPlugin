using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialTopAppBarPage : ContentPage
    {
        public MaterialTopAppBarPage()
        {
            InitializeComponent();

            BindingContext = new MaterialTopAppBarViewModel { DisplayAlert = DisplayAlert, Navigation = Navigation };
        }
    }
}