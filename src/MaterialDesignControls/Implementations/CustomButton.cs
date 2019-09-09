using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Implementations
{
    public class CustomButton : Button
    {
        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName.Equals(IsEnabledProperty.PropertyName) && !this.IsEnabled)
            {
                this.IsEnabled = true;
            }
        }
    }
}
