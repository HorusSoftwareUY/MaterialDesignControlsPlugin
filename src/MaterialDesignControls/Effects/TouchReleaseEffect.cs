using System;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls
{
    public class TouchReleaseEffect : RoutingEffect
    {
        public Action OnRelease { get; set; }

        public TouchReleaseEffect(Action onRelease) : base($"{Effects.EffectIdPrefix}.{nameof(TouchReleaseEffect)}")
        {
            OnRelease = onRelease;
        }
    }
}