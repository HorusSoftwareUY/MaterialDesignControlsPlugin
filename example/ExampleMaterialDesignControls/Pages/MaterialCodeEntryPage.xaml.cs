using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialCodeEntryPage : ContentPage
    {
        public MaterialCodeEntryPage()
        {
            InitializeComponent();

            BindingContext = new MaterialCodeEntryViewModel { DisplayAlert = DisplayAlert, Navigation = Navigation };
        }
    }
}