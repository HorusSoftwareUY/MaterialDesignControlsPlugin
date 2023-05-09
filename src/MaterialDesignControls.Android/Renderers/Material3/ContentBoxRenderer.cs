using System.ComponentModel;
using System.Linq;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Plugin.MaterialDesignControls.Material3.Android;
using Xamarin.Forms.Platform.Android.FastRenderers;
using static Java.Util.ResourceBundle;
using Android.Widget;

[assembly: ExportRenderer(typeof(ContentBox), typeof(ContentBoxRenderer))]
namespace Plugin.MaterialDesignControls.Material3.Android
{
    public class ContentBoxRenderer : ViewRenderer
    {
        private bool drawed = false;

        public ContentBoxRenderer(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || e.NewElement == null)
                return;

            Draw();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (new string[] { "BackgroundColor", "BorderColor", "BorderWidth", "CornerRadius", "CornerRadiusTopLeft", "CornerRadiusTopRight", "CornerRadiusBottomLeft", "CornerRadiusBottomRight" }.Contains(e.PropertyName))
            {
                Draw();
            }
        }

        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);

            if (!drawed)
            {
                Draw();
                drawed = true;
            }
        }

        private void Draw()
        {
            var element = (ContentBox)Element;
            DrawShape(element);
        }

        private void DrawShape(ContentBox element)
        {
            var backgroundDrawable = new GradientDrawable();
            backgroundDrawable.SetColors(new int[] { element.BackgroundColor.ToAndroid(), element.BackgroundColor.ToAndroid() });
            backgroundDrawable.SetShape(ShapeType.Rectangle);
            float[] corners = SetCorners(element);
            backgroundDrawable.SetCornerRadii(corners);
            backgroundDrawable.SetStroke((int)element.BorderWidth * -1, element.BorderColor.ToAndroid());
            this.SetBackground(backgroundDrawable);
        }

        private static float[] SetCorners(ContentBox element)
        {
            float[] corners = new float[8];

            if (element.CornerRadiusTopLeft)
            {
                corners[0] = element.CornerRadius;
                corners[1] = element.CornerRadius;
            }

            if (element.CornerRadiusTopRight)
            {
                corners[2] = element.CornerRadius;
                corners[3] = element.CornerRadius;
            }

            if (element.CornerRadiusBottomRight)
            {
                corners[4] = element.CornerRadius;
                corners[5] = element.CornerRadius;
            }

            if (element.CornerRadiusBottomLeft)
            {
                corners[6] = element.CornerRadius;
                corners[7] = element.CornerRadius;
            }

            return corners;
        }
    }
}