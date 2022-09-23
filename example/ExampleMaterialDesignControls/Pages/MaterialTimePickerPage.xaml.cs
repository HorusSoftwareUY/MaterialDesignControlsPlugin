using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialTimePickerPage : ContentPage
    {
        public MaterialTimePickerPage()
        {
            InitializeComponent();

            BindingContext = new MaterialTimePickerViewModel { DisplayAlert = DisplayAlert, Navigation = Navigation };
        }
    }
}