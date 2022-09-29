using Plugin.MaterialDesignControls.Animations;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls
{
    public interface ITouchAndPressEffectConsumer
    {
        void ConsumeEvent(EventType gestureType);
        bool IsEnabled { get; set; }
        AnimationTypes Animation { get; set; }
        ICustomAnimation CustomAnimation { get; set; }
        double? AnimationParameter { get; set; }
        void ExecuteAction();
    }

    public enum EventType
    {
        Pressing,
        Released,
        Cancelled,
        Ignored
    }

    public class TouchAndPressEffect : RoutingEffect
    {
        public TouchAndPressEffect() : base($"{Effects.EffectIdPrefix}.{nameof(TouchAndPressEffect)}")
        {
        }
    }
}