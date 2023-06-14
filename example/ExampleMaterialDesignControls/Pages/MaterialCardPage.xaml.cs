using ExampleMaterialDesignControls.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExampleMaterialDesignControls.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialCardPage : ContentPage
    {
        public MaterialCardPage()
        {
            InitializeComponent();

            BindingContext = new MaterialCardViewModel { DisplayAlert = DisplayAlert, Navigation = Navigation };

        }
    }
}