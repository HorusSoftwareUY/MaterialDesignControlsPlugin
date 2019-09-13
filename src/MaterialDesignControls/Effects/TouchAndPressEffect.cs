using System;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Effects
{
    public interface ITouchAndPressEffectConsumer
    {
        void ConsumeEvent(EventType gestureType);
    }

    public enum EventType
    {
        Pressing,
        Released,
        Cancelled
    }

    public class TouchAndPressEffect : RoutingEffect
    {
        public const string EffectIdPrefix = "TouchAndPressEffect";

        public TouchAndPressEffect() : base($"{EffectIdPrefix}.{nameof(TouchAndPressEffect)}")
        {
        }
    }
}
