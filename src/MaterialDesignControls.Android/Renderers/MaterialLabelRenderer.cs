using System;
using Android.Content;
using Plugin.MaterialDesignControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MaterialLabel), typeof(Plugin.MaterialDesignControls.Android.MaterialLabelRenderer))]

namespace Plugin.MaterialDesignControls.Android
{
    public class MaterialLabelRenderer : LabelRenderer
    {
        public static void Init() { }

        public MaterialLabelRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (this.Control != null)
            {
                this.Control.LetterSpacing = (float)((MaterialLabel)this.Element).LetterSpacing;
                this.UpdateLayout();
            }
        }
    }
}
