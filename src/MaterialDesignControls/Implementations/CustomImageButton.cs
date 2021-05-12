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

        private Image image;

        private View customImage;

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
        }

        public int? Value = null;

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(ImageWidthRequest):
                    if (image != null)
                        image.WidthRequest = ImageWidthRequest;
                    else if (customImage != null)
                        customImage.WidthRequest = ImageWidthRequest;
                    break;
                case nameof(ImageHeightRequest):
                    if (image != null)
                        image.HeightRequest = ImageHeightRequest;
                    else if (customImage != null)
                        customImage.HeightRequest = ImageHeightRequest;
                    break;
            }
        }

        public void SetImage(string imageSource)
        {
            customImage = null;
            image = new Image
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                WidthRequest = ImageWidthRequest,
                HeightRequest = ImageHeightRequest,
                Source = imageSource
            };
            Content = image;
        }

        public void SetCustomImage(View view)
        {
            image = null;
            view.VerticalOptions = LayoutOptions.Center;
            view.HorizontalOptions = LayoutOptions.Center;
            view.WidthRequest = ImageWidthRequest;
            view.HeightRequest = ImageHeightRequest;
            Content = view;
        }
    }
}