using System;
using System.Collections.Generic;
using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{	
	public partial class MaterialLabel : ContentPage
	{	
		public MaterialLabel ()
		{
			InitializeComponent ();
            BindingContext = new MaterialLabelViewModel { DisplayAlert = DisplayAlert, Navigation = Navigation };
        }
	}
}