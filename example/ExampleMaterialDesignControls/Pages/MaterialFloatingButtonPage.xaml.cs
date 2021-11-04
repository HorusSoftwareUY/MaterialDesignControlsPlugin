using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialFloatingButtonPage : ContentPage
    {
        public MaterialFloatingButtonPage()
        {
            InitializeComponent();
        }

        void MaterialFloatingButton_Clicked(System.Object sender, System.EventArgs e)
        {
            DisplayAlert("Mensaje","este es un mensaje del boton","ok");
        }
    }
}
