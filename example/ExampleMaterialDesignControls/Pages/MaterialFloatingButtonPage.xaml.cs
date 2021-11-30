using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialFloatingButtonPage : ContentPage
    {
        public MaterialFloatingButtonPage()
        {
            InitializeComponent();
            this.BindingContext = new MaterialFloatingButtonViewModel { DisplayAlert = this.DisplayAlert };
        }

        void MaterialFloatingButton_Clicked(System.Object sender, System.EventArgs e)
        {
            DisplayAlert("Message","Floating button clicked!","ok");
        }
    }
}
