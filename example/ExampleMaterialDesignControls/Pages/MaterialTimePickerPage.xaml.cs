using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialTimePickerPage : ContentPage
    {
        public MaterialTimePickerPage()
        {
            InitializeComponent();

            this.BindingContext = new MaterialTimePickerViewModel { DisplayAlert = this.DisplayAlert };
        }
    }
}