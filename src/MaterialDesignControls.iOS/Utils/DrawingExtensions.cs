using UIKit;

namespace CoreGraphics
{
    public static class DrawingExtensions
	{
        public static UIBezierPath CreateRoundedRect(this CGRect rect, double[] cornerRadius, UIColor backgroundColor = null, UIColor borderColor = null, float borderWidth = 0f)
        {
            var path = new UIBezierPath();

            path.MoveTo(new CGPoint(x: rect.GetMinX(), y: rect.GetMinY() + cornerRadius[0]));

            // upper left corner
            path.AddQuadCurveToPoint(new CGPoint(x: rect.GetMinX() + cornerRadius[0], y: rect.GetMinY()),
                        controlPoint: new CGPoint(x: rect.GetMinX(), y: rect.GetMinY()));

            // top
            path.AddLineTo(new CGPoint(x: rect.GetMaxX() - cornerRadius[1], y: rect.GetMinY()));

            // upper right corner
            path.AddQuadCurveToPoint(new CGPoint(x: rect.GetMaxX(), y: rect.GetMinY() + cornerRadius[1]),
                        controlPoint: new CGPoint(x: rect.GetMaxX(), y: rect.GetMinY()));

            // right
            path.AddLineTo(new CGPoint(x: rect.GetMaxX(), y: rect.GetMaxY() - cornerRadius[2]));

            // lower right corner
            path.AddQuadCurveToPoint(new CGPoint(x: rect.GetMaxX() - cornerRadius[2], y: rect.GetMaxY()),
                        controlPoint: new CGPoint(x: rect.GetMaxX(), y: rect.GetMaxY()));

            // bottom
            path.AddLineTo(new CGPoint(x: rect.GetMinX() + cornerRadius[3], y: rect.GetMaxY()));

            // lower left corner
            path.AddQuadCurveToPoint(new CGPoint(x: rect.GetMinX(), y: rect.GetMaxY() - cornerRadius[3]),
                        controlPoint: new CGPoint(x: rect.GetMinX(), y: rect.GetMaxY()));

            path.ClosePath();

            if (borderWidth > 0 && borderColor != null)
            {
                borderColor.SetStroke();
                path.LineWidth = borderWidth;
                path.Stroke();
            }

            if (backgroundColor != null)
            {
                backgroundColor.SetFill();
                path.Fill();
            }

            return path;
        }
    }
}