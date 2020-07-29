using ElmSharp;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms.Platform.Tizen.Native;
using EColor = ElmSharp.Color;

[assembly: ExportRenderer(typeof(Frame), typeof(CustomFrameRenderer))]
namespace Xamarin.Forms.Platform.Tizen
{
	public class CustomFrameRenderer : LayoutRenderer
	{
		static readonly EColor s_DefaultColor = new EColor(255, 255, 255, 0);

		Frame FrameElement => (Element as Frame);

		RoundRectangle _frame = null;
		RoundRectangle _frameBorder = null;

		public CustomFrameRenderer()
		{
			RegisterPropertyHandler(Frame.BorderColorProperty, UpdateBorderColor);
			RegisterPropertyHandler(Frame.CornerRadiusProperty, UpdateCornerRadius);
		}

		protected override void OnElementChanged(ElementChangedEventArgs<Layout> e)
		{
			if (Control == null)
			{
				SetNativeControl(new Canvas(Forms.NativeParent));
				_frameBorder = new RoundRectangle(NativeView);
				_frameBorder.Show();
				_frame = new RoundRectangle(NativeView);
				_frame.Show();
				Control.Children.Add(_frameBorder);
				Control.Children.Add(_frame);
				Control.LayoutUpdated += OnLayoutUpdated;
			}
			base.OnElementChanged(e);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (Control != null)
				{
					Control.LayoutUpdated -= OnLayoutUpdated;
				}
			}
			base.Dispose(disposing);
		}

		protected override void UpdateBackgroundColor(bool initialize)
		{
			if (initialize && Element.BackgroundColor == Color.Default)
				return;

			UpdateAllColors();
		}

		void UpdateBorderColor(bool initialize)
		{
			if (initialize && FrameElement.BorderColor == Color.Default)
				return;

			UpdateAllColors();
		}

		void UpdateAllColors()
		{
			var bgColor = FrameElement.BackgroundColor.ToNative();
			var borderColor = FrameElement.BorderColor.ToNative();

			if (bgColor == EColor.Default || bgColor == s_DefaultColor)
			{
				if (borderColor != EColor.Default && borderColor != s_DefaultColor)
				{
					// Set Frame.BackgroundColor to White, if the Frmae.BackgroundColor is the Default/Transparent and there is a Frame.BorderColor.
					_frameBorder.Color = borderColor;
					_frame.Color = EColor.White;
					return;
				}
			}
			_frameBorder.Color = borderColor;
			_frame.Color = bgColor;
		}

		void UpdateCornerRadius(bool initialize)
		{
			if (initialize && FrameElement.CornerRadius == -1f)
				return;

			int radius = 0;
			if (FrameElement.CornerRadius != -1f)
			{
				radius = Forms.ConvertToScaledPixel(FrameElement.CornerRadius);
			}
			_frameBorder.SetRadius(radius);
			_frame.SetRadius(radius);
		}

		void OnLayoutUpdated(object sender, Native.LayoutEventArgs e)
		{
			UpdateGeometry();
		}

		void UpdateGeometry()
		{
			var geometry = NativeView.Geometry;
			_frameBorder.Draw(geometry);
			_frame.Draw(new Rect(geometry.X + 1, geometry.Y + 1, geometry.Width - 2, geometry.Height - 2));
		}
	}
}
