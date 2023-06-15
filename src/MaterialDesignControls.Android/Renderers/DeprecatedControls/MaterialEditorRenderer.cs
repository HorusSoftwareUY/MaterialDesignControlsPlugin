using Android.Content;
using Android.Graphics.Drawables;
using AndroidGraphics = Android.Graphics;
using Plugin.MaterialDesignControls.Implementations;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Views.InputMethods;
using System;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(Plugin.MaterialDesignControls.Android.MaterialEditorRenderer))]

namespace Plugin.MaterialDesignControls.Android
{
    [Obsolete("MaterialEditorRenderer is deprecated, please use MaterialEditorRenderer of Material 3 instead.")]

    public class MaterialEditorRenderer : EditorRenderer
    {
        public static void Init() { }

        public MaterialEditorRenderer(Context context) : base(context)
        { }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                Control.Background = new ColorDrawable(AndroidGraphics.Color.Transparent);
                Control.SetPadding(4, 0, 0, 0);
                Control.ImeOptions = (ImeAction)ImeFlags.NoExtractUi;
            }

            if (e.NewElement != null)
            {
                var element = e.NewElement as CustomEditor;
                Control.Hint = element.Placeholder;
                Control.SetHintTextColor(element.PlaceholderColor.ToAndroid());
            }
        }
    }
}