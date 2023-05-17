using Plugin.MaterialDesignControls.Animations;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Implementations
{
    public class CustomImageButton : ContentView, ITouchAndPressEffectConsumer
    {
        #region Constructors

        public CustomImageButton()
        {
            this.Padding = 6;
            this.VerticalOptions = LayoutOptions.Center;

            Effects.Add(new TouchAndPressEffect());
        }

        #endregion Constructors

        #region Attributes
        private Image image;

        private View customImage;

        #endregion Attributes

        #region Properties

        public static readonly BindableProperty ImageHeightRequestProperty =
            BindableProperty.Create(nameof(ImageHeightRequest), typeof(double), typeof(CustomImageButton), defaultValue: 24.0);

        public double ImageHeightRequest
        {
            get { return (double)GetValue(ImageHeightRequestProperty); }
            set { SetValue(ImageHeightRequestProperty, value); }
        }

        public static readonly BindableProperty ImageWidthRequestProperty =
            BindableProperty.Create(nameof(ImageWidthRequest), typeof(double), typeof(CustomImageButton), defaultValue: 24.0);

        public double ImageWidthRequest
        {
            get { return (double)GetValue(ImageWidthRequestProperty); }
            set { SetValue(ImageWidthRequestProperty, value); }
        }

        public static readonly BindableProperty CommandProperty =
           BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(CustomImageButton), defaultValue: null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(CustomImageButton), defaultValue: null);

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly BindableProperty AnimationProperty =
            BindableProperty.Create(nameof(Animation), typeof(AnimationTypes), typeof(CustomImageButton), defaultValue: AnimationTypes.None);

        public AnimationTypes Animation
        {
            get { return (AnimationTypes)GetValue(AnimationProperty); }
            set { SetValue(AnimationProperty, value); }
        }

        public static readonly BindableProperty AnimationParameterProperty =
            BindableProperty.Create(nameof(AnimationParameter), typeof(double?), typeof(CustomImageButton), defaultValue: null);

        public double? AnimationParameter
        {
            get { return (double?)GetValue(AnimationParameterProperty); }
            set { SetValue(AnimationParameterProperty, value); }
        }

        public static readonly BindableProperty CustomAnimationProperty =
            BindableProperty.Create(nameof(CustomAnimation), typeof(ICustomAnimation), typeof(CustomImageButton), defaultValue: null);

        public ICustomAnimation CustomAnimation
        {
            get { return (ICustomAnimation)GetValue(CustomAnimationProperty); }
            set { SetValue(CustomAnimationProperty, value); }
        }

        #endregion Properties

        #region Methods

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

        public void ConsumeEvent(EventType gestureType)
        {
            TouchAndPressAnimation.Animate(this, gestureType);
        }

        public void ExecuteAction()
        {
            if (IsEnabled && Command != null && Command.CanExecute(CommandParameter))
                Command.Execute(CommandParameter);
        }

        #endregion Methods
    }
}