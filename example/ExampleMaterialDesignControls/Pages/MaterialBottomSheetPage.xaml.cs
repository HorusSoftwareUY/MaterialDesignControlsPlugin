using ExampleMaterialDesignControls.ViewModels;
using Plugin.MaterialDesignControls.Material3;
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
				OpenBottomSheetControl = async (controlName) => await this.FindByName<MaterialBottomSheet>(controlName).Open(),
                CloseBottomSheetControl = async (controlName) => await this.FindByName<MaterialBottomSheet>(controlName).Close()
            };
        }

        void materialBottomSheet4_Opened(System.Object sender, System.EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Opened!!!!!");
        }

        void materialBottomSheet4_Closed(System.Object sender, System.EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Closed!!!!!");
        }
    }
}