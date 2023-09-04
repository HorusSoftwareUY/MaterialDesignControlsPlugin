using System;
using System.Collections.Generic;
using ExampleMaterialDesignControls.ViewModels;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{	
	public partial class MaterialSearchPage : ContentPage
	{	
		public MaterialSearchPage ()
		{
			InitializeComponent ();
            BindingContext = new MaterialSearchViewModel() { DisplayAlert = DisplayAlert, Navigation = Navigation };

        }
    }
}

