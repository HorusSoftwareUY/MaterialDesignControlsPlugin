using ExampleMaterialDesignControls.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ExampleMaterialDesignControls.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialRatingControlPage : ContentPage
    {
        public MaterialRatingControlPage()
        {
            InitializeComponent();
            this.BindingContext = new MaterialRatingControlViewModel { DisplayAlert = this.DisplayAlert };
        }
    }
}