using System;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls
{
    public class MaterialOutlineButton : MaterialButton
    {
        public MaterialOutlineButton()
        {
            this.button.BackgroundColor = Color.Transparent;
            this.button.BorderWidth = 1;
        }
    }
}
