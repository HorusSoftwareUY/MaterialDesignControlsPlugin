using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3.Implementations
{
    public class CustomFrame : Frame
    {
        #region Properties
        public static new readonly BindableProperty CornerRadiusProperty = 
            BindableProperty.Create(nameof(CustomFrame), typeof(CornerRadius), typeof(CustomFrame));

        public new CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        #endregion Properties

        #region Constructor
        public CustomFrame()
        {
            base.CornerRadius = 0;
        }
        #endregion Constructor
    }
}
