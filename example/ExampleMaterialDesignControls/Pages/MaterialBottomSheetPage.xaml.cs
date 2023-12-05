using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialBottomSheetPage : ContentPage
	{	
		public MaterialBottomSheetPage(bool isModalPage = false)
		{
			InitializeComponent();

			BindingContext = new MaterialBottomSheetViewModel
			{
				IsModalPage = isModalPage,
                DisplayAlert = DisplayAlert,
				Navigation = Navigation,
				OpenBottomSheetControl = async () => await materialBottomSheet.Open(),
                CloseBottomSheetControl = async () => await materialBottomSheet.Close()
            };
        }
    }
}