using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialCodeEntryPage : ContentPage
    {
        public MaterialCodeEntryPage()
        {
            InitializeComponent();

            this.BindingContext = new MaterialCodeEntryViewModel { DisplayAlert = this.DisplayAlert };
        }
    }
}