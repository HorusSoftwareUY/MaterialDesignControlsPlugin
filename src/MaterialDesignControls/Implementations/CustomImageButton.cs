using System;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Implementations
{
    public class CustomImageButton : ContentView
    {
        public Image Image { get; set; }

        public Action Tapped { get; set; }

        public CustomImageButton()
        {
            this.Padding = 6;
            this.VerticalOptions = LayoutOptions.Center;

            this.Image = new Image
            {
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 24,
                HeightRequest = 24,
            };

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (s, e) =>
            {
                if (this.Tapped != null)
                {
                    this.Tapped.Invoke();
                }
            };
            this.GestureRecognizers.Add(tapGestureRecognizer);
            
            this.Content = this.Image;
        }
    }
}
