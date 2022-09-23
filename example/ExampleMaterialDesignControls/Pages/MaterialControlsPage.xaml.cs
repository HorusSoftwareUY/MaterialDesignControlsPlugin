using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialControlsPage : ContentPage
    {
        public MaterialControlsPage()
        {
            InitializeComponent();

            BindingContext = new MaterialControlsPageViewModel { DisplayAlert = DisplayAlert, Navigation = Navigation };
        }
    }
}