using System;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using View = Android.Views.View;
using TouchReleaseEffect = Plugin.MaterialDesignControls.Android.TouchReleaseEffect;
using System.Linq;

[assembly: ExportEffect(typeof(TouchReleaseEffect), nameof(TouchReleaseEffect))]

namespace Plugin.MaterialDesignControls.Android
{
    public class TouchReleaseEffect : PlatformEffect
    {
        private View _view;

        private Action _onRelease;

        protected override void OnAttached()
        {
            _view = Control ?? Container;

            if (_view != null)
            {
                var touchReleaseEffect = (MaterialDesignControls.TouchReleaseEffect)Element.Effects.FirstOrDefault(x => x is MaterialDesignControls.TouchReleaseEffect);
                if (touchReleaseEffect != null && touchReleaseEffect.OnRelease != null)
                {
                    _onRelease = touchReleaseEffect.OnRelease;
                    _view.Touch += OnViewOnTouch;
                }
            }
        }

        protected override void OnDetached()
        {
            if (_view != null)
                _view.Touch -= OnViewOnTouch;
        }

        private void OnViewOnTouch(object sender, View.TouchEventArgs e)
        {
            e.Handled = false;

            if (e.Event.ActionMasked == MotionEventActions.Up)
            {
                System.Diagnostics.Debug.WriteLine(e.Event.ActionMasked);
                _onRelease.Invoke();
            }
        }
    }
}