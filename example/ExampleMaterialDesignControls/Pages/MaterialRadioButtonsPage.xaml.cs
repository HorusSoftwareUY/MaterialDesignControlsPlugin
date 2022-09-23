using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialRadioButtonsPage : ContentPage
    {
        public MaterialRadioButtonsPage()
        {
            InitializeComponent();
            BindingContext = new MaterialRadioButtonsViewModel { DisplayAlert = DisplayAlert, Navigation = Navigation };
        }
    }
}