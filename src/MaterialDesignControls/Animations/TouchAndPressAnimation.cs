using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Animations
{
    public static class TouchAndPressAnimation
    {
        public static void Animate(View view, EventType gestureType)
        {
            var touchAndPressEffectConsumer = view as ITouchAndPressEffectConsumer;

            switch (gestureType)
            {
                case EventType.Pressing:
                    SetAnimation(view, touchAndPressEffectConsumer);
                    break;
                case EventType.Cancelled:
                case EventType.Released:
                    if (touchAndPressEffectConsumer.IsEnabled && touchAndPressEffectConsumer.Command != null && touchAndPressEffectConsumer.Command.CanExecute(touchAndPressEffectConsumer.CommandParameter))
                    {
                        touchAndPressEffectConsumer.Command.Execute(touchAndPressEffectConsumer.CommandParameter);
                    }
                    touchAndPressEffectConsumer.ExecuteClicked();
                    RestoreAnimation(view, touchAndPressEffectConsumer);
                    break;
                case EventType.Ignored:
                    RestoreAnimation(view, touchAndPressEffectConsumer);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gestureType), gestureType, null);
            }
        }

        private static void SetAnimation(View view, ITouchAndPressEffectConsumer touchAndPressEffectConsumer)
        {
            if (touchAndPressEffectConsumer.Animation != AnimationTypes.None && view.IsEnabled && (touchAndPressEffectConsumer.Command == null || touchAndPressEffectConsumer.Command.CanExecute(touchAndPressEffectConsumer.CommandParameter)))
            {
                Task.Run(async () =>
                {
                    if (touchAndPressEffectConsumer.Animation == AnimationTypes.Fade)
                    {
                        await view.FadeTo(touchAndPressEffectConsumer.AnimationParameter.HasValue ? touchAndPressEffectConsumer.AnimationParameter.Value : 0.6, 100);
                    }
                    else
                    {
                        await view.ScaleTo(touchAndPressEffectConsumer.AnimationParameter.HasValue ? touchAndPressEffectConsumer.AnimationParameter.Value : 0.95, 100);
                    }
                });
            }
        }

        private static void RestoreAnimation(View view, ITouchAndPressEffectConsumer touchAndPressEffectConsumer)
        {
            if (touchAndPressEffectConsumer.Animation != AnimationTypes.None)
            {
                Task.Run(async () =>
                {
                    if (touchAndPressEffectConsumer.Animation == AnimationTypes.Fade)
                    {
                        await view.FadeTo(1, 100);
                    }
                    else
                    {
                        await view.ScaleTo(1, 100);
                    }
                });
            }
        }
    }
}

