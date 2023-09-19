using ExampleMaterialDesignControls.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExampleMaterialDesignControls.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialDialogPage : ContentPage
    {
        public MaterialDialogPage()
        {
            InitializeComponent();
            BindingContext = new MaterialDialogViewModel { DisplayAlert = DisplayAlert, Navigation = Navigation };

        }
    }
}