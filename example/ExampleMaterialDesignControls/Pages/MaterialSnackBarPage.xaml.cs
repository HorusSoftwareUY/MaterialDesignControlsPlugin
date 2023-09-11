using System;
using System.Collections.Generic;
using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{	
	public partial class MaterialSnackBarPage : ContentPage
	{	
		public MaterialSnackBarPage ()
		{
			InitializeComponent ();
            BindingContext = new MaterialSnackBarViewModel { DisplayAlert = DisplayAlert, Navigation = Navigation };
        }
    }
}

