using ElmSharp;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using TouchAndPressEffect = Plugin.MaterialDesignControls.Tizen.TouchAndPressEffect;

[assembly: ResolutionGroupName(Plugin.MaterialDesignControls.TouchAndPressEffect.EffectIdPrefix)]
[assembly: ExportEffect(typeof(TouchAndPressEffect), nameof(TouchAndPressEffect))]

namespace Plugin.MaterialDesignControls.Tizen
{
    public class TouchAndPressEffect : PlatformEffect
    {
        private TouchAndPressGestureLayer _touchAndPressGestureLayer;

        protected override void OnAttached()
        {
            if (Element is ITouchAndPressEffectConsumer touchAndPressEffectConsumer)
            {
                _touchAndPressGestureLayer = new TouchAndPressGestureLayer(Control, touchAndPressEffectConsumer);
                _touchAndPressGestureLayer.Attach(Control);
            }
        }

        protected override void OnDetached()
        {
            if (_touchAndPressGestureLayer != null)
            {
                _touchAndPressGestureLayer.ClearCallbacks();
                _touchAndPressGestureLayer.Unrealize();
                _touchAndPressGestureLayer = null;
            }
        }

        private class TouchAndPressGestureLayer : GestureLayer
        {
            private readonly ITouchAndPressEffectConsumer _touchAndPressEffectConsumer;

            internal TouchAndPressGestureLayer(EvasObject parent) : base (parent)
            {
                SetTapCallback(GestureType.LongTap, GestureLayer.GestureState.Start, (data) => { TapStarted(); });
                SetTapCallback(GestureType.LongTap, GestureLayer.GestureState.End, (data) => { TapEnded(); });
                SetTapCallback(GestureType.LongTap, GestureLayer.GestureState.Abort, (data) => { TapAborted(); });
            }

            public TouchAndPressGestureLayer(EvasObject parent, ITouchAndPressEffectConsumer touchAndPressEffectConsumer) : this(parent)
            {
                _touchAndPressEffectConsumer = touchAndPressEffectConsumer;
            }

            private void TapStarted()
            {
                _touchAndPressEffectConsumer.ConsumeEvent(EventType.Pressing);
            }

            private void TapEnded()
            {
                _touchAndPressEffectConsumer.ConsumeEvent(EventType.Released);
            }

            private void TapAborted()
            {
                _touchAndPressEffectConsumer.ConsumeEvent(EventType.Cancelled);
            }
        }
    }
}
