using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using EColor = ElmSharp.Color;

[assembly: ExportRenderer(typeof(Page), typeof(CustomPageRenderer))]
namespace Xamarin.Forms.Platform.Tizen
{
	public class CustomPageRenderer : PageRenderer
	{
		static readonly EColor s_DefaultBackgroundColor = new EColor(250,250,250);

		protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
		{
			base.OnElementChanged(e);
			NativeView.Color = s_DefaultBackgroundColor;
		}
	}
}
