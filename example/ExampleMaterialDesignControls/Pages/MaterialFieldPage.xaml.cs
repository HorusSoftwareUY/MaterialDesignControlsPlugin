using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialFieldPage : ContentPage
    {
        public MaterialFieldPage()
        {
            InitializeComponent();

            BindingContext = new BaseViewModel { DisplayAlert = DisplayAlert, Navigation = Navigation };
        }
    }
}