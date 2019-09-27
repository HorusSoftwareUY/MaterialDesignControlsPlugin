using System;
using System.Runtime.CompilerServices;
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

        public static readonly BindableProperty ImageHeightRequestProperty = BindableProperty.Create(nameof(ImageHeightRequest), typeof(double), typeof(CustomImageButton), defaultValue: 24.0);

        public double ImageHeightRequest
        {
            get { return (double)GetValue(ImageHeightRequestProperty); }
            set { SetValue(ImageHeightRequestProperty, value); }
        }

        public static readonly BindableProperty ImageWidthRequestProperty = BindableProperty.Create(nameof(ImageWidthRequest), typeof(double), typeof(CustomImageButton), defaultValue: 24.0);

        public double ImageWidthRequest
        {
            get { return (double)GetValue(ImageWidthRequestProperty); }
            set { SetValue(ImageWidthRequestProperty, value); }
        }

        public CustomImageButton()
        {
            this.Padding = 6;
            this.VerticalOptions = LayoutOptions.Center;

            this.Image = new Image
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = this.ImageWidthRequest,
                HeightRequest = this.ImageHeightRequest,
            };

            this.Content = this.Image;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(this.ImageWidthRequest):
                    this.Image.WidthRequest = this.ImageWidthRequest;
                    break;
                case nameof(this.ImageHeightRequest):
                    this.Image.HeightRequest = this.ImageHeightRequest;
                    break;
            }
        }
    }
}
