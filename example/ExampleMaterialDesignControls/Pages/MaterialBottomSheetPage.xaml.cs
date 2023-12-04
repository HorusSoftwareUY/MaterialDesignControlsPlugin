using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class MaterialBottomSheetPage : ContentPage
	{	
		public MaterialBottomSheetPage ()
		{
			InitializeComponent ();

			BindingContext = new MaterialBottomSheetViewModel
			{
				DisplayAlert = DisplayAlert,
				Navigation = Navigation,
				OpenBottomSheetControl = async () => await materialBottomSheet.Open(),
                CloseBottomSheetControl = async () => await materialBottomSheet.Close()
            };
        }
    }
}