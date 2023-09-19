
using System;
using System.Collections.Generic;
using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{	
	public partial class MaterialIconButtonPage : ContentPage
	{	
		public MaterialIconButtonPage ()
		{
			InitializeComponent ();
            BindingContext = new MaterialIconButtonViewModel { DisplayAlert = DisplayAlert, Navigation = Navigation };
        }
    }
}

