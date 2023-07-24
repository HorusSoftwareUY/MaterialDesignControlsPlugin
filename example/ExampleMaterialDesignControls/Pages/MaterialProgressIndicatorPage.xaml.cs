using ExampleMaterialDesignControls.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExampleMaterialDesignControls.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialProgressIndicatorPage : ContentPage
    {
        public MaterialProgressIndicatorPage()
        {
            InitializeComponent();
            BindingContext = new MaterialProgressIndicatorViewModel { DisplayAlert = DisplayAlert, Navigation = Navigation };
        }
    }
}