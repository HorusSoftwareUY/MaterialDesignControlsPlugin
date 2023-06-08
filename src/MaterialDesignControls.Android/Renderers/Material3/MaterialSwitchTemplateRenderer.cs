using Android.Runtime;
using Android.Views.Accessibility;
using Android.Views;
using Java.Lang;
using Plugin.MaterialDesignControls.Material3;
using Plugin.MaterialDesignControls.Material3.Android;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using Switch = Android.Widget.Switch;

[assembly: ExportRenderer(typeof(MaterialSwitchTemplate), typeof(MaterialSwitchTemplateRenderer))]

namespace Plugin.MaterialDesignControls.Material3.Android
{
    public class MaterialSwitchTemplateRenderer : VisualElementRenderer<ContentView>
    {
        public static void Init() { }


        private readonly Switch _a11YSwitch;

        public MaterialSwitchTemplateRenderer(Context context) : base(context)
        {
            _a11YSwitch = new Switch(context);
        }

        /// <inheritdoc />
        protected override void OnElementChanged(ElementChangedEventArgs<ContentView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement == null)
            {
                return;
            }

            MaterialSwitchTemplate customSwitch = e.NewElement as MaterialSwitchTemplate;

            _a11YSwitch.Checked = customSwitch.IsToggled;

        }

        /// <inheritdoc />
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals(nameof(MaterialSwitchTemplate.IsToggled)))
            {
                MaterialSwitchTemplate customSwitch = sender as MaterialSwitchTemplate;

                if (_a11YSwitch.Checked != customSwitch.IsToggled)
                {
                    _a11YSwitch.Checked = customSwitch.IsToggled;
                    AnnounceForAccessibility(GetStateDescription());
                }
            }
        }

        /// <inheritdoc />
        public override ICharSequence? AccessibilityClassNameFormatted => new String(_a11YSwitch.Class.Name);

        /// <inheritdoc />
        public override void OnInitializeAccessibilityNodeInfo(AccessibilityNodeInfo? info)
        {
            if (info != null)
            {
                info.Checkable = true;
                info.Checked = _a11YSwitch.Checked;
                info.Text = GetStateDescription();
            }

            base.OnInitializeAccessibilityNodeInfo(info);
        }


        private string GetStateDescription()
        {
            return _a11YSwitch.Checked ? _a11YSwitch.TextOn : _a11YSwitch.TextOff;
        }

        public override bool OnKeyUp([GeneratedEnum] Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.Space || keyCode == Keycode.Enter)
            {
                MaterialSwitchTemplate customSwitch = Element as MaterialSwitchTemplate;
                customSwitch.IsToggled = !customSwitch.IsToggled;
            }

            return base.OnKeyUp(keyCode, e);
        }
    }
}