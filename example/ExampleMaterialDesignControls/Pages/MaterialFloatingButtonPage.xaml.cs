using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialFloatingButtonPage : ContentPage
    {
        public MaterialFloatingButtonPage()
        {
            InitializeComponent();

            BindingContext = new MaterialFloatingButtonViewModel { DisplayAlert = DisplayAlert, Navigation = Navigation };
        }

        void MaterialFloatingButton_Clicked(System.Object sender, System.EventArgs e)
        {
            DisplayAlert("Message","Floating button clicked!","ok");
        }
    }
}