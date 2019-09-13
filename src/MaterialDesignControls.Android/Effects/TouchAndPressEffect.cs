using System;
using Android.Views;
using Plugin.MaterialDesignControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;
using TouchAndPressEffect = Plugin.MaterialDesignControls.Android.TouchAndPressEffect;

[assembly: ResolutionGroupName(Plugin.MaterialDesignControls.TouchAndPressEffect.EffectIdPrefix)]
[assembly: ExportEffect(typeof(TouchAndPressEffect), nameof(TouchAndPressEffect))]

namespace Plugin.MaterialDesignControls.Android
{
    public class TouchAndPressEffect : PlatformEffect
    {
        private View _view;
        private ITouchAndPressEffectConsumer _touchAndPressEffectConsumer;

        protected override void OnAttached()
        {
            _view = Control ?? Container;

            if (_view != null && Element is ITouchAndPressEffectConsumer touchAndPressEffectConsumer)
            {
                _view.Touch += OnViewOnTouch;
                _touchAndPressEffectConsumer = touchAndPressEffectConsumer;
            }
        }

        protected override void OnDetached()
        {
            if (_view != null)
            {
                _view.Touch -= OnViewOnTouch;
            }
        }

        private void OnViewOnTouch(object sender, View.TouchEventArgs e)
        {
            switch (e.Event.ActionMasked)
            {
                case MotionEventActions.ButtonPress:
                    _touchAndPressEffectConsumer?.ConsumeEvent(EventType.Pressing);
                    break;
                case MotionEventActions.ButtonRelease:
                    _touchAndPressEffectConsumer?.ConsumeEvent(EventType.Released);
                    break;
                case MotionEventActions.Cancel:
                    _touchAndPressEffectConsumer?.ConsumeEvent(EventType.Cancelled);
                    break;
                case MotionEventActions.Down:
                    _touchAndPressEffectConsumer?.ConsumeEvent(EventType.Pressing);
                    break;
                case MotionEventActions.HoverEnter:
                    break;
                case MotionEventActions.HoverExit:
                    break;
                case MotionEventActions.HoverMove:
                    break;
                case MotionEventActions.Mask:
                    break;
                case MotionEventActions.Move:
                    break;
                case MotionEventActions.Outside:
                    break;
                case MotionEventActions.Pointer1Down:
                    _touchAndPressEffectConsumer?.ConsumeEvent(EventType.Pressing);
                    break;
                case MotionEventActions.Pointer1Up:
                    _touchAndPressEffectConsumer?.ConsumeEvent(EventType.Released);
                    break;
                case MotionEventActions.Pointer2Down:
                    break;
                case MotionEventActions.Pointer2Up:
                    break;
                case MotionEventActions.Pointer3Down:
                    break;
                case MotionEventActions.Pointer3Up:
                    break;
                case MotionEventActions.PointerIdMask:
                    break;
                case MotionEventActions.PointerIdShift:
                    break;
                case MotionEventActions.Up:
                    _touchAndPressEffectConsumer?.ConsumeEvent(EventType.Released);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
