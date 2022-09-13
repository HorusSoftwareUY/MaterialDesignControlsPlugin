using System.Threading.Tasks;
using Plugin.MaterialDesignControls.Animations;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Animations
{
    public class CustomButtonAnimation : ICustomAnimation
    {
        public async Task RestoreAnimation(View view)
        {
            await view.ScaleTo(1, 600, Easing.BounceOut);
        }

        public async Task SetAnimation(View view)
        {
            await view.ScaleTo(0.9, 200);
        }
    }
}