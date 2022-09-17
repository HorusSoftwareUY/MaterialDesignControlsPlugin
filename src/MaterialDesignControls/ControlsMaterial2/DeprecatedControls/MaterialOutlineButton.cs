using System;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls
{
    [Obsolete("MaterialOutlineButton is deprecated, please use MaterialButton of Material 3 instead with type Outlined.")]
    public class MaterialOutlineButton : MaterialButton
    {
        public MaterialOutlineButton()
        {
            this.frmLayout.BackgroundColor = Color.Transparent;
        }
    }
}