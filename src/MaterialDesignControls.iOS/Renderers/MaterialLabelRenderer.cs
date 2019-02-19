using System;
using Foundation;
using Plugin.MaterialDesignControls;
using Plugin.MaterialDesignControls.iOS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MaterialLabel), typeof(MaterialLabelRenderer))]

namespace Plugin.MaterialDesignControls.iOS
{
    public class MaterialLabelRenderer : LabelRenderer
    {
        public static void Init() { }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (this.Control != null)
            {
                var text = this.Control.Text;
                var attributedString = new NSMutableAttributedString(text);

                var nsKern = new NSString("NSKern");
                var spacing = NSObject.FromObject((float)((MaterialLabel)this.Element).LetterSpacing * 10);
                var range = new NSRange(0, text.Length);

                attributedString.AddAttribute(nsKern, spacing, range);
                Control.AttributedText = attributedString;
            }
        }
    }
}
