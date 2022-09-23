using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialCustomControl : ContentPage
    {
        public MaterialCustomControl()
        {
            InitializeComponent();

            BindingContext = new MaterialCustomControlViewModel { DisplayAlert = DisplayAlert, Navigation = Navigation };
        }
    }
}