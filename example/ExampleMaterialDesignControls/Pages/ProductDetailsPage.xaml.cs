using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class ProductDetailsPage : ContentPage
    {
        public ProductDetailsPage()
        {
            InitializeComponent();

            BindingContext = new ProductDetailsViewModel() { DisplayAlert = DisplayAlert, Navigation = Navigation };
        }
    }
}