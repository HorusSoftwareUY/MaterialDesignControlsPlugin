using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialEditorPage : ContentPage
    {
        public MaterialEditorPage()
        {
            InitializeComponent();

            this.BindingContext = new MaterialEditorViewModel { DisplayAlert = this.DisplayAlert };
        }
    }
}