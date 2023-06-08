using Plugin.MaterialDesignControls.Utils;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls.Material3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialSwitch : MaterialSwitchTemplate
    {
        public MaterialSwitch()
        {
            InitializeComponent();

            SwitchPanUpdate += (sender, e) =>
            {
                //Color Animation
                Color fromColor = IsToggled ? Color.FromHex("#4ACC64") : Color.FromHex("#EBECEC");
                Color toColor = IsToggled ? Color.FromHex("#EBECEC") : Color.FromHex("#4ACC64");

                double t = e.Percentage * 0.01;

                BackgroundColor = ColorAnimationUtil.ColorAnimation(fromColor, toColor, t);
            };
        }
    }
}