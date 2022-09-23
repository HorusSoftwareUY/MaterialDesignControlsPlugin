using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialChipsPage : ContentPage
    {
        public MaterialChipsPage()
        {
            InitializeComponent();
            BindingContext = new ProductDetailsViewModel() { DisplayAlert = DisplayAlert, Navigation = Navigation };
        }
    }
}