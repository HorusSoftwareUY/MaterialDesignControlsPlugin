﻿using Plugin.MaterialDesignControls.Animations;
using Plugin.MaterialDesignControls.Implementations;
using Plugin.MaterialDesignControls.Styles;
using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3
{
    public enum MaterialIconButtonType
    {
        Filled, Tonal, Outlined, Standard
    }

    public class MaterialIconButton : ContentView, ITouchAndPressEffectConsumer
    {
        #region Properties

        public static readonly BindableProperty ButtonTypeProperty =
        BindableProperty.Create(nameof(ButtonType), typeof(MaterialIconButtonType), typeof(MaterialButton), defaultValue: MaterialIconButtonType.Standard);

        public MaterialIconButtonType ButtonType
        {
            get { return (MaterialIconButtonType)GetValue(ButtonTypeProperty); }
            set { SetValue(ButtonTypeProperty, value); }
        }

        public static readonly BindableProperty CommandProperty =
           BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(MaterialIconButton), defaultValue: null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(MaterialIconButton), defaultValue: null);

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly BindableProperty AnimationProperty =
            BindableProperty.Create(nameof(Animation), typeof(AnimationTypes), typeof(MaterialIconButton), defaultValue: AnimationTypes.None);

        public AnimationTypes Animation
        {
            get { return (AnimationTypes)GetValue(AnimationProperty); }
            set { SetValue(AnimationProperty, value); }
        }

        public static readonly BindableProperty AnimationParameterProperty =
            BindableProperty.Create(nameof(AnimationParameter), typeof(double?), typeof(MaterialIconButton), defaultValue: null);

        public double? AnimationParameter
        {
            get { return (double?)GetValue(AnimationParameterProperty); }
            set { SetValue(AnimationParameterProperty, value); }
        }

        public static readonly BindableProperty CustomAnimationProperty =
            BindableProperty.Create(nameof(CustomAnimation), typeof(ICustomAnimation), typeof(MaterialIconButton), defaultValue: null);

        public ICustomAnimation CustomAnimation
        {
            get { return (ICustomAnimation)GetValue(CustomAnimationProperty); }
            set { SetValue(CustomAnimationProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
        BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialButton), defaultValue: Color.Default);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static readonly BindableProperty IconProperty =
       BindableProperty.Create(nameof(Icon), typeof(string), typeof(MaterialIconButton), defaultValue: null);

        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public static readonly BindableProperty CustomIconProperty =
            BindableProperty.Create(nameof(CustomIcon), typeof(View), typeof(MaterialIconButton), defaultValue: null);

        public View CustomIcon
        {
            get { return (View)GetValue(CustomIconProperty); }
            set { SetValue(CustomIconProperty, value); }
        }

        public static readonly BindableProperty PaddingIconProperty =
        BindableProperty.Create(nameof(PaddingIcon), typeof(Thickness), typeof(MaterialIconButton), new Thickness(0));

        public Thickness PaddingIcon
        {
            get { return (Thickness)GetValue(PaddingIconProperty); }
            set { SetValue(PaddingIconProperty, value); }
        }

        private int minHeight = 48;
        private int minWidth = 48;
        private int shapeCircleMargin = 4;

        #endregion Properties

        #region Constructors

        public MaterialIconButton()
        {
            MinimumHeightRequest = minHeight;
            MinimumWidthRequest = minWidth;
            HorizontalOptions = LayoutOptions.Center;

            SetSettings();

            HeightRequest = minHeight;
            WidthRequest = minHeight;

            Content = Container;
            Effects.Add(new TouchAndPressEffect());
        }

        private void SetSettings()
        {
            Container = new Grid();
            Container.Padding = shapeCircleMargin;
            customImage = new CustomImage           
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.Fill,
                IsVisible = true,
            };
            PaddingIcon = 8;
            circle = new Frame();
            circle.HasShadow = false;
            circle.HorizontalOptions = LayoutOptions.Center;
            circle.VerticalOptions = LayoutOptions.Center;

            Container.Children.Add(circle);
            Container.Children.Add(customImage);
        }

        #endregion Constructors

        #region Attributes

        private CustomImage customImage;

        private Grid Container;

        private Frame circle;

        #endregion Attributes

        #region Methods

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            switch (propertyName)
            {
                case nameof(Icon):
                    this.customImage.SetImage(Icon);
                    this.customImage.VerticalOptions = LayoutOptions.Fill;
                    break;
                case nameof(CustomIcon):
                    this.customImage.SetCustomImage(CustomIcon);
                    this.customImage.VerticalOptions = LayoutOptions.Fill;
                    break;
                case nameof(HeightRequest):
                    if (HeightRequest >= minHeight)
                    {
                        SetHeigthRequest();
                    }
                    break;

                case nameof(WidthRequest):
                    if (WidthRequest >= minWidth)
                    {
                        SetWidthRequest();
                    }
                    break;

                case nameof(BackgroundColor):
                case nameof(ButtonType):
                    SetButtonStyle();
                    break;
                case nameof(PaddingIcon):
                    this.customImage.Margin = PaddingIcon;
                    break;
            }
        }

        private void SetWidthRequest()
        {
            var widthWhitoutMargin = WidthRequest - (shapeCircleMargin * 2);
            this.Container.WidthRequest = WidthRequest;
            this.circle.WidthRequest = widthWhitoutMargin;
            this.circle.CornerRadius = (float)circle.WidthRequest / 2;
            this.circle.VerticalOptions = LayoutOptions.Center;
        }

        private void SetHeigthRequest()
        {
            var heightWhitoutMargin = HeightRequest - (shapeCircleMargin*2);
            this.Container.HeightRequest = WidthRequest;
            this.circle.HeightRequest = heightWhitoutMargin;
            this.circle.CornerRadius = (float)circle.HeightRequest / 2;
            this.circle.VerticalOptions = LayoutOptions.Center;
        }

        public void SetButtonStyle()
        {

            switch (ButtonType)
            {
                case MaterialIconButtonType.Standard:
                    this.customImage.Margin = this.PaddingIcon;
     
                    this.circle.IsVisible = false;
                    break;
                case MaterialIconButtonType.Filled:
                    this.circle.BackgroundColor = BackgroundColor;
                    this.circle.BackgroundColor = BackgroundColor != Color.Default ? BackgroundColor : DefaultStyles.OnPrimaryColor;
                    this.circle.IsVisible = true;
                    break;
                case MaterialIconButtonType.Outlined:
                    this.circle.BorderColor = BackgroundColor;
                    this.circle.BorderColor = BackgroundColor != Color.Default ? BackgroundColor : DefaultStyles.OnPrimaryColor;
                    this.circle.IsVisible = true;
                    break;
                case MaterialIconButtonType.Tonal:
                    var defaultBackgroundColor = BackgroundColor != Color.Default ? Color.FromRgba(BackgroundColor.R, BackgroundColor.G, BackgroundColor.B, 0.4) : Color.FromRgba(Color.Default.R, Color.Default.G, Color.Default.B, 0.4);
                    this.circle.BackgroundColor = defaultBackgroundColor;
                    this.circle.IsVisible = true;
                    break;
            }
        }
        public void SetImage(string imageSource)
        {
            this.customImage.SetImage(imageSource);
        }

        public void SetCustomImage(View view)
        {
            this.customImage.SetCustomImage(view);
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
