using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialChipsPage : ContentPage
    {
        public MaterialChipsPage()
        {
            InitializeComponent();
            this.BindingContext = new ProductDetailsViewModel() { DisplayAlert = this.DisplayAlert };
        }
    }
}