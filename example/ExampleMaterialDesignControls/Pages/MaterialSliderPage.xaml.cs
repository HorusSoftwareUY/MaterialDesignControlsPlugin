using ExampleMaterialDesignControls.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExampleMaterialDesignControls.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialSliderPage : ContentPage
    {
        public MaterialSliderPage()
        {
            InitializeComponent();


            this.BindingContext = new MaterialSliderViewModel { DisplayAlert = this.DisplayAlert };
        }
    }
}