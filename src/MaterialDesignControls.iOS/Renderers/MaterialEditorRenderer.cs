using System;
using Foundation;
using Plugin.MaterialDesignControls.Implementations;
using Plugin.MaterialDesignControls.iOS;
using Plugin.MaterialDesignControls.Utils;
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

            SetFont();

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

            if (e.PropertyName == MaterialEditor.TextProperty.PropertyName)
                lblPlaceholder.Hidden = !string.IsNullOrEmpty(Control.Text);
            else if (e.PropertyName == MaterialEditor.FontSizeProperty.PropertyName
                || e.PropertyName == MaterialEditor.FontFamilyProperty.PropertyName)
                SetFont();
        }

        private void SetFont()
        {
            if (!string.IsNullOrEmpty(Element.FontFamily))
            {
                try
                {
                    lblPlaceholder.Font = UIFont.FromName(Element.FontFamily, (nfloat)Element.FontSize);
                }
                catch (Exception ex)
                {
                    LoggerHelper.Log(ex);
                }
            }
        }
    }
}
