using System.ComponentModel;
using System.Linq;
using CoreAnimation;
using CoreGraphics;
using Plugin.MaterialDesignControls.Material3;
using Plugin.MaterialDesignControls.Material3.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MaterialCard), typeof(MaterialCardRenderer))]
namespace Plugin.MaterialDesignControls.Material3.iOS
{
    public class MaterialCardRenderer : ViewRenderer<MaterialCard, UIView>
    {
        public static new void Init() { }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var properties = new string[] {
                MaterialCard.BackgroundColorProperty.PropertyName,
                MaterialCard.HasBorderProperty.PropertyName,
                MaterialCard.BorderColorProperty.PropertyName,
                MaterialCard.BorderWidthProperty.PropertyName,
                MaterialCard.CornerRadiusProperty.PropertyName,
                MaterialCard.HasShadowProperty.PropertyName,
                MaterialCard.ShadowColorProperty.PropertyName,
                MaterialCard.iOSShadowOffsetProperty.PropertyName,
                MaterialCard.iOSShadowOpacityProperty.PropertyName,
                MaterialCard.iOSShadowRadiusProperty.PropertyName,
                MaterialCard.TypeProperty.PropertyName,
                "OutlineColor"
            };

            if (properties.Contains(e.PropertyName))
            {
                Draw();
                SetNeedsDisplay();
            }
            else if (Element != null
                && Element.Width > 0 && Element.Height > 0
                && (e.PropertyName == MaterialCard.WidthProperty.PropertyName || e.PropertyName == MaterialCard.HeightProperty.PropertyName))
            {
                SetNeedsDisplay();
            }
        }

        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            Draw();
        }

        private void Draw()
        {
            DrawBackground();
            DrawBorder();
            DrawShadow();
        }

        private void DrawBackground()
        {
            try
            {
                var layerName = "backgroundLayer";

                // Remove previous background layer if any
                var prevBackgroundLayer = Layer.Sublayers?.FirstOrDefault(x => x.Name == layerName);
                prevBackgroundLayer?.RemoveFromSuperLayer();

                var backgroundColor = Element.Type == MaterialCardType.Outlined ? Color.Transparent : Element.BackgroundColor;

                var backgroundLayer = new CAShapeLayer
                {
                    Bounds = new CGRect(Bounds.X, Bounds.Y, Bounds.Width, Bounds.Height),
                    FillColor = null,
                    Name = layerName
                };

                backgroundLayer.Bounds.CreateRoundedRect(GetCornerRadius(), backgroundColor.ToUIColor());
                Layer.InsertSublayer(backgroundLayer, 0);
            }
            catch
            {
            }
        }

        private void DrawBorder()
        {
            try
            {
                var layerName = "borderLayer";

                // Remove previous border layer if any
                var prevBorderLayer = Layer.Sublayers?.FirstOrDefault(x => x.Name == layerName);
                prevBorderLayer?.RemoveFromSuperLayer();

                var hasBorder = Element.Type == MaterialCardType.Outlined || (Element.Type == MaterialCardType.Custom && Element.HasBorder);
                var borderWidth = hasBorder ? (Element.Type == MaterialCardType.Custom ? Element.BorderWidth : (Element.Type == MaterialCardType.Outlined ? 1 : 0)) : 0;
                var borderColor = hasBorder ? Element.BorderColor : Element.BackgroundColor;

                if (borderWidth > 0)
                {
                    var borderOffset = borderWidth * .8;
                    var borderLayer = new CAShapeLayer
                    {
                        Bounds = new CGRect(Bounds.X + borderOffset / 2, Bounds.Y + borderOffset / 2, Bounds.Width - borderOffset, Bounds.Height - borderOffset),
                        FillColor = null,
                        Name = layerName
                    };

                    borderLayer.Bounds.CreateRoundedRect(GetCornerRadius(), null, borderColor.ToUIColor(), borderWidth);
                    Layer.InsertSublayer(borderLayer, 0);
                }
            }
            catch
            {
            }
        }

        private void DrawShadow()
        {
            try
            {
                var hasShadow = Element.Type == MaterialCardType.Elevated || (Element.Type == MaterialCardType.Custom && Element.HasShadow);
                if (hasShadow)
                {
                    Layer.ShadowColor = Element.ShadowColor.ToCGColor();
                    Layer.ShadowRadius = (float)Element.iOSShadowRadius;
                    Layer.ShadowOpacity = (float)Element.iOSShadowOpacity;
                    Layer.ShadowOffset = new CGSize((float)Element.iOSShadowOffset.Width, (float)Element.iOSShadowOffset.Height);
                    Layer.MasksToBounds = false;
                }
                else
                {
                    Layer.ShadowOpacity = 0f;
                }
            }
            catch
            {
            }
        }

        private double[] GetCornerRadius()
        {
            if (Element.CornerRadius == null) return new double[] { 0, 0, 0, 0 };

            return new double[]
            {
                Element.CornerRadius.TopLeft,
                Element.CornerRadius.TopRight,
                Element.CornerRadius.BottomRight,
                Element.CornerRadius.BottomLeft
            };
        }
    }
}