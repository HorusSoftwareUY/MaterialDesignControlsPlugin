using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialSelectionPage : ContentPage
    {
        public MaterialSelectionPage()
        {
            InitializeComponent();

            this.BindingContext = new MaterialSelectionViewModel { DisplayAlert = this.DisplayAlert };
        }
    }
}
