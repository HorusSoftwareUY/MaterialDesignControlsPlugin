using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialRadioButtonsPage : ContentPage
    {
        public MaterialRadioButtonsPage()
        {
            InitializeComponent();
            this.BindingContext = new MaterialRadioButtonsViewModel { DisplayAlert = this.DisplayAlert };
        }
    }
}
