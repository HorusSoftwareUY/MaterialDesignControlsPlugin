using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialEditorPage : ContentPage
    {
        public MaterialEditorPage()
        {
            InitializeComponent();

            BindingContext = new MaterialEditorViewModel { DisplayAlert = DisplayAlert, Navigation = Navigation };
        }
    }
}