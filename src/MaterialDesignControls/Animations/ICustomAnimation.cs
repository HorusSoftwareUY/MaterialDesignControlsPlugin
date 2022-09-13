using System.Threading.Tasks;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Animations
{
    public interface ICustomAnimation
    {
        Task SetAnimation(View view);

        Task RestoreAnimation(View view);
    }
}