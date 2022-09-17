using System;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls
{
    [Obsolete("MaterialFlatButton is deprecated, please use MaterialButton of Material 3 instead with type Text.")]
    public class MaterialFlatButton : MaterialButton
    {
        public MaterialFlatButton()
        {
            this.frmLayout.BackgroundColor = Color.Transparent;
            this.frmLayout.BorderColor = Color.Transparent;
        }
    }
}