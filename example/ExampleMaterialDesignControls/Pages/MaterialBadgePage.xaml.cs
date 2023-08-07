using ExampleMaterialDesignControls.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExampleMaterialDesignControls.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialBadgePage : ContentPage
    {
        public MaterialBadgePage()
        {
            InitializeComponent();
            BindingContext = new MaterialBadgeViewModel() { DisplayAlert = DisplayAlert, Navigation = Navigation };
        }
    }
}