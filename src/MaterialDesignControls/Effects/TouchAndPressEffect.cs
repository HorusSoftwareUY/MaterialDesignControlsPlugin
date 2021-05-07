using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls
{
    public interface ITouchAndPressEffectConsumer
    {
        void ConsumeEvent(EventType gestureType);
        ICommand Command { get; set; }
        object CommandParameter { get; set; }
        bool IsEnabled { get; set; }
        AnimationTypes Animation { get; set; }
        double? AnimationParameter { get; set; }
        void ExecuteClicked();

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
        public const string EffectIdPrefix = "TouchAndPressEffect";

        public TouchAndPressEffect() : base($"{EffectIdPrefix}.{nameof(TouchAndPressEffect)}")
        {
        }
    }
}
