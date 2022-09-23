using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialDividerPage : ContentPage
    {
        public MaterialDividerPage()
        {
            InitializeComponent();

            BindingContext = new BaseViewModel { DisplayAlert = DisplayAlert, Navigation = Navigation };
        }
    }
}