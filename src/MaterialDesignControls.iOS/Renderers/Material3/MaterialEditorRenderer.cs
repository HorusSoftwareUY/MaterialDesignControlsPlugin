using Foundation;
using Plugin.MaterialDesignControls.Utils;
using System;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Plugin.MaterialDesignControls.Material3.iOS;
using CoreGraphics;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(MaterialEditorRenderer))]

namespace Plugin.MaterialDesignControls.Material3.iOS
{
    public class MaterialEditorRenderer : EditorRenderer
    {
        public static void Init() { }

        private UILabel lblPlaceholder { get; set; }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (this.Control == null) return;

            if (lblPlaceholder != null) return;

            var element = Element as CustomEditor;
            this.Control.ScrollEnabled = true;

            // TODO: fix small padding on the left.

            lblPlaceholder = new UILabel
            {
                Text = element?.Placeholder,
                TextColor = element.PlaceholderColor.ToUIColor(),
                BackgroundColor = UIColor.Clear,
            };

            lblPlaceholder.Hidden = !string.IsNullOrEmpty(element.Text);

            SetFont();

            var edgeInsets = this.Control.TextContainerInset;
            var lineFragmentPadding = this.Control.TextContainer.LineFragmentPadding;

            this.Control.AddSubview(lblPlaceholder);

            var vConstraints = NSLayoutConstraint.FromVisualFormat(
                "V:|-" + edgeInsets.Top + "-[PlaceholderLabel]-" + edgeInsets.Bottom + "-|", 0, new NSDictionary(),
                NSDictionary.FromObjectsAndKeys(
                    new NSObject[] { lblPlaceholder }, new NSObject[] { new NSString("PlaceholderLabel") })
            );

            var hConstraints = NSLayoutConstraint.FromVisualFormat(
                "H:|-" + lineFragmentPadding + "-[PlaceholderLabel]-" + lineFragmentPadding + "-|",
                0, new NSDictionary(),
                NSDictionary.FromObjectsAndKeys(
                    new NSObject[] { lblPlaceholder }, new NSObject[] { new NSString("PlaceholderLabel") })
            );

            lblPlaceholder.TranslatesAutoresizingMaskIntoConstraints = false;

            this.Control.AddConstraints(hConstraints);
            this.Control.AddConstraints(vConstraints);

            if (element.CursorColor.HasValue)
                this.Control.TintColor = element.CursorColor.Value.ToUIColor();

            Control.LayoutManager.UsesDefaultHyphenation = false;
            Control.LayoutManager.AllowsNonContiguousLayout = false;
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