using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class AddCardPage : ContentPage
    {
        public AddCardPage()
        {
            InitializeComponent();
            BindingContext = new AddCardViewModel() { DisplayAlert = DisplayAlert, Navigation = Navigation };
        }
    }
}