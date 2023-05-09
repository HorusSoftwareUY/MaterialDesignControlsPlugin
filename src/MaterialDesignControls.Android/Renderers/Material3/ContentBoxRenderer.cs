using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Plugin.MaterialDesignControls.Material3.Implementations;
using Plugin.MaterialDesignControls.Material3.Android;
using Plugin.MaterialDesignControls.Implementations;

[assembly: ExportRenderer(typeof(ContentBox), typeof(ContentBoxRenderer))]
namespace Plugin.MaterialDesignControls.Material3.Android
{
    public class ContentBoxRenderer : Xamarin.Forms.Platform.Android.FastRenderers.FrameRenderer
    {
        private bool drawed = false;

        public ContentBoxRenderer(Context context)
            : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null && Control != null)
            {
                UpdateCornerRadius();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(CustomFrame.CornerRadius) ||
                e.PropertyName == nameof(CustomFrame))
            {
                UpdateCornerRadius();
            }
        }

        private void UpdateCornerRadius()
        {
            if (Control.Background is GradientDrawable backgroundGradient)
            {
                var cornerRadius = (Element as CustomFrame)?.CornerRadius;
                if (!cornerRadius.HasValue)
                {
                    return;
                }

                if (!(Element is ContentBox element))
                {
                    return;
                }

                double topLeft = element.CornerRadiusTopLeft ? cornerRadius.Value : 0;
                double topRight = element.CornerRadiusTopRight ? cornerRadius.Value : 0;
                double bottomLeft = element.CornerRadiusBottomLeft ? cornerRadius.Value : 0;
                double bottomRight = element.CornerRadiusBottomRight ? cornerRadius.Value : 0;

                var topLeftCorner = Context.ToPixels(topLeft);
                var topRightCorner = Context.ToPixels(topRight);
                var bottomLeftCorner = Context.ToPixels(bottomLeft);
                var bottomRightCorner = Context.ToPixels(bottomRight);

                var cornerRadii = new[]
                {
                    topLeftCorner,
                    topLeftCorner,

                    topRightCorner,
                    topRightCorner,

                    bottomRightCorner,
                    bottomRightCorner,

                    bottomLeftCorner,
                    bottomLeftCorner,
                };
                backgroundGradient.SetCornerRadii(cornerRadii);
            }
        }

        //public ContentBoxRenderer(Context context) : base(context) { }

        //protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        //{
        //    base.OnElementChanged(e);

        //    if (e.OldElement != null || e.NewElement == null)
        //        return;

        //    Draw();
        //}

        //protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    base.OnElementPropertyChanged(sender, e);

        //    if (new string[] { "BackgroundColor", "BorderColor", "BorderWidth", "CornerRadius", "CornerRadiusTopLeft", "CornerRadiusTopRight", "CornerRadiusBottomLeft", "CornerRadiusBottomRight" }.Contains(e.PropertyName))
        //    {
        //        Draw();
        //    }
        //}

        //public override void Draw(Canvas canvas)
        //{
        //    base.Draw(canvas);

        //    if (!drawed)
        //    {
        //        Draw();
        //        drawed = true;
        //    }
        //}

        //private void Draw()
        //{
        //    var element = (ContentBox)Element;
        //    DrawShape(element);
        //}

        //private void DrawShape(ContentBox element)
        //{
        //    var backgroundDrawable = new GradientDrawable();
        //    backgroundDrawable.SetColors(new int[] { element.BackgroundColor.ToAndroid(), element.BackgroundColor.ToAndroid() });
        //    backgroundDrawable.SetShape(ShapeType.Rectangle);
        //    float[] corners = SetCorners(element);
        //    backgroundDrawable.SetCornerRadii(corners);
        //    backgroundDrawable.SetStroke((int)element.BorderWidth, element.BorderColor.ToAndroid());

        //    this.SetBackground(backgroundDrawable);

        //    this.SetPadding(
        //        (int)((int)element.BorderWidth + element.Padding.Left),
        //        (int)((int)element.BorderWidth + element.Padding.Top),
        //        (int)((int)element.BorderWidth + element.Padding.Right),
        //        (int)((int)element.BorderWidth + element.Padding.Bottom)
        //    );
        //    //this.SetClipToPadding(true);
        //    //this.SetClipToOutline(false);

        //}

        //private static float[] SetCorners(ContentBox element)
        //{
        //    float[] corners = new float[8];

        //    if (element.CornerRadiusTopLeft)
        //    {
        //        corners[0] = element.CornerRadius;
        //        corners[1] = element.CornerRadius;
        //    }

        //    if (element.CornerRadiusTopRight)
        //    {
        //        corners[2] = element.CornerRadius;
        //        corners[3] = element.CornerRadius;
        //    }

        //    if (element.CornerRadiusBottomRight)
        //    {
        //        corners[4] = element.CornerRadius;
        //        corners[5] = element.CornerRadius;
        //    }

        //    if (element.CornerRadiusBottomLeft)
        //    {
        //        corners[6] = element.CornerRadius;
        //        corners[7] = element.CornerRadius;
        //    }

        //    return corners;
        //}
    }
}