using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Implementations
{
    public class CustomImage : ContentView
    {
        private Image image;

        private View customImage;

        public CustomImage()
        {
            this.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.VerticalOptions = LayoutOptions.FillAndExpand;
            Margin = new Thickness(0);
        }

        public void SetImage(string imageSource)
        {
            customImage = null;
            image = new Image
            {
                Aspect = Aspect.AspectFit,
                Source = imageSource
            };
            Content = image;
        }

        public void SetCustomImage(View view)
        {
            image = null;
            view.VerticalOptions = LayoutOptions.FillAndExpand;
            view.HorizontalOptions = LayoutOptions.FillAndExpand;
            Content = view;
        }
    }
}
