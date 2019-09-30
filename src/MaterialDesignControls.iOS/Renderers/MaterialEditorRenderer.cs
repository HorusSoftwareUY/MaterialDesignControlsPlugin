using System;
using Foundation;
using Plugin.MaterialDesignControls.Implementations;
using Plugin.MaterialDesignControls.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(MaterialEditorRenderer))]

namespace Plugin.MaterialDesignControls.iOS
{
    public class MaterialEditorRenderer : EditorRenderer
    {
        public static void Init() { }

        private UILabel lblPlaceholder { get; set; }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null) return;

            if (this.lblPlaceholder != null) return;

            var element = Element as CustomEditor;
            this.Control.ScrollEnabled = true;

            // TODO: fix small padding on the left.

            this.lblPlaceholder = new UILabel
            {
                Text = element?.Placeholder,
                TextColor = element.PlaceholderColor.ToUIColor(),
                BackgroundColor = UIColor.Clear
            };

            if (!string.IsNullOrEmpty(element.FontFamily))
            {
                this.lblPlaceholder.Font = UIFont.FromName(element.FontFamily, (nfloat)element.FontSize);
            }

            var edgeInsets = this.Control.TextContainerInset;
            var lineFragmentPadding = this.Control.TextContainer.LineFragmentPadding;

            this.Control.AddSubview(this.lblPlaceholder);

            var vConstraints = NSLayoutConstraint.FromVisualFormat(
                "V:|-" + edgeInsets.Top + "-[PlaceholderLabel]-" + edgeInsets.Bottom + "-|", 0, new NSDictionary(),
                NSDictionary.FromObjectsAndKeys(
                    new NSObject[] { this.lblPlaceholder }, new NSObject[] { new NSString("PlaceholderLabel") })
            );

            var hConstraints = NSLayoutConstraint.FromVisualFormat(
                "H:|-" + lineFragmentPadding + "-[PlaceholderLabel]-" + lineFragmentPadding + "-|",
                0, new NSDictionary(),
                NSDictionary.FromObjectsAndKeys(
                    new NSObject[] { this.lblPlaceholder }, new NSObject[] { new NSString("PlaceholderLabel") })
            );

            this.lblPlaceholder.TranslatesAutoresizingMaskIntoConstraints = false;

            this.Control.AddConstraints(hConstraints);
            this.Control.AddConstraints(vConstraints);
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == "Text")
            {
                lblPlaceholder.Hidden = !string.IsNullOrEmpty(Control.Text);
            }
        }
    }
}
