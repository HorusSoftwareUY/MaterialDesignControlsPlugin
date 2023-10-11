using System;
using System.Collections.Generic;
using System.Text;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class MaterialProgressIndicatorViewModel : BaseViewModel
    {
        private bool isVisible = true;

        public bool IsVisible
        {
            get { return isVisible; }
            set { SetProperty(ref isVisible, value); }
        }
    }
}