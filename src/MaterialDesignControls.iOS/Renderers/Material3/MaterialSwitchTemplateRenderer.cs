using Plugin.MaterialDesignControls.Material3;
using Plugin.MaterialDesignControls.Material3.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MaterialSwitchTemplate), typeof(MaterialSwitchTemplateRenderer))]


namespace Plugin.MaterialDesignControls.Material3.iOS
{
    internal class MaterialSwitchTemplateRenderer : VisualElementRenderer<ContentView>
    {
        public new static void Init()
        {
        }

        private readonly UISwitch _a11YSwitch = new UISwitch();

        /// <inheritdoc />
        protected override void OnElementChanged(ElementChangedEventArgs<ContentView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                _a11YSwitch.On = ((MaterialSwitchTemplate)e.NewElement).IsToggled;
            }

        }

        /// <inheritdoc />
        public override string AccessibilityValue
        {
            get => _a11YSwitch.On ? "1" : "0";
            set { }
        }

        /// <inheritdoc />
        public override UIAccessibilityTrait AccessibilityTraits
        {
            get => _a11YSwitch.AccessibilityTraits;
            set { }
        }

        /// <inheritdoc />
        public override bool AccessibilityActivate()
        {
            _a11YSwitch.SetState(!_a11YSwitch.On, false);
            return base.AccessibilityActivate();
        }
    }
}