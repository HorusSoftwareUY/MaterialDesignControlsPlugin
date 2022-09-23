using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialSelectionPage : ContentPage
    {
        public MaterialSelectionPage()
        {
            InitializeComponent();

            BindingContext = new MaterialSelectionViewModel { DisplayAlert = DisplayAlert, Navigation = Navigation };
        }
    }
}