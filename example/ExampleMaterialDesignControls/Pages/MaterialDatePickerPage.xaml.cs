using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialDatePickerPage : ContentPage
    {
        public MaterialDatePickerPage()
        {
            InitializeComponent();

            BindingContext = new MaterialDatePickerViewModel { DisplayAlert = DisplayAlert, Navigation = Navigation };
        }
    }
}