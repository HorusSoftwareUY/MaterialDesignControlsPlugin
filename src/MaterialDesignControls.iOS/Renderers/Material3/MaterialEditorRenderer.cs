using System;
using System.Linq;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Plugin.MaterialDesignControls.Material3.iOS;
using Plugin.MaterialDesignControls.Utils;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

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

            if (Control == null) return;

            if (lblPlaceholder != null) return;

            var element = Element as CustomEditor;
            Control.ScrollEnabled = true;

            lblPlaceholder = Control.Subviews.FirstOrDefault(s => s is UILabel placeholder && placeholder.Text == Element.Placeholder) as UILabel;
            SetFontAndColor();

            if (element.CursorColor.HasValue)
                Control.TintColor = element.CursorColor.Value.ToUIColor();
            
            Control.LayoutManager.UsesDefaultHyphenation = false;
            Control.LayoutManager.AllowsNonContiguousLayout = false;            
        }

        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == MaterialEditor.FontSizeProperty.PropertyName
                || e.PropertyName == MaterialEditor.FontFamilyProperty.PropertyName
                || e.PropertyName == MaterialEditor.PlaceholderColorProperty.PropertyName)
                SetFontAndColor();
        }

        private void SetFontAndColor()
        {
            try
            {
                if (!string.IsNullOrEmpty(Element.FontFamily))
                {
                    lblPlaceholder.Font = UIFont.FromName(Element.FontFamily, (nfloat)Element.FontSize);
                }

                lblPlaceholder.TextColor = Element.PlaceholderColor.ToUIColor();
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(ex);
            }
        }
    }
}