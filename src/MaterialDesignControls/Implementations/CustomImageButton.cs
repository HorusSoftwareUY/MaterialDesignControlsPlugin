using System;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Implementations
{
    public class CustomImageButton : ContentView
    {
        private Action tapped;

        public Action Tapped
        {
            get { return this.tapped; }
            set
            {
                if (this.tapped != null)
                {
                    this.GestureRecognizers.Clear();
                }

                this.tapped = value;

                var tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (s, e) =>
                {
                    if (this.Tapped != null)
                    {
                        this.Tapped.Invoke();
                    }
                };
                this.GestureRecognizers.Add(tapGestureRecognizer);
            }
        }

        public Image Image { get; set; }

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

            this.Content = this.Image;
        }
    }
}
