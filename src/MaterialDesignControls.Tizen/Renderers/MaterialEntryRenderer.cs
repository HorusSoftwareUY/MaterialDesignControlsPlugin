using Plugin.MaterialDesignControls.Implementations;
using Plugin.MaterialDesignControls.Tizen;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Tizen;
using Xamarin.Forms.Platform.Tizen.Native;
using EEntry = ElmSharp.Entry;
using XEntry = Xamarin.Forms.Entry;
using EColor = ElmSharp.Color;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(MaterialEntryRenderer))]

namespace Plugin.MaterialDesignControls.Tizen
{
	public class MaterialEntryRenderer : EntryRenderer
	{
		public static void Init() { }

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);
			if (e.PropertyName == nameof(Element.IsPassword))
			{
				Control.SetPartText("elm.guide", "<span font_size=" + Forms.ConvertToEflFontPoint(Element.FontSize) + " color=" + ToHex(Element.PlaceholderColor.ToNative()) + ">" + Element.Placeholder + "</span>");
			}
		}

		string ToHex(EColor c)
		{
			if (c.IsDefault)
			{
				Log.Warn("Trying to convert the default color to hexagonal notation, it does not works as expected.");
			}
			return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", c.R, c.G, c.B, c.A);
		}
	}
}
