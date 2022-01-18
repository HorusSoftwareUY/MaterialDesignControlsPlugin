using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialSegmentedPage : ContentPage
    {
        public MaterialSegmentedPage()
        {
            InitializeComponent();
            this.BindingContext = new MaterialSegmentedViewModel() { DisplayAlert = this.DisplayAlert };
        }

        void MaterialSegmented_IsSelectedChanged(System.Object sender, System.EventArgs e)
        {
            DisplayAlert("Message","Segment Is Selected Changed","OK");
        }
    }
}
