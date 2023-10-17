using System;
using System.Runtime.CompilerServices;
using Plugin.MaterialDesignControls.Styles;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3
{
	public class MaterialDivider : BoxView
    {
        private bool _initialized = false;

        #region Constructor

        public MaterialDivider()
        {
            if (!_initialized)
            {
                _initialized = true;
                Initialize();
            }
            Xamarin.Forms.PlatformConfiguration.AndroidSpecific.VisualElement.SetElevation(this, 0);
        }

        #endregion Constructor

        #region Properties

        public static new readonly BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialDivider), defaultValue: MaterialColor.OutlineVariant);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public static new readonly BindableProperty ColorProperty =
            BindableProperty.Create(nameof(Color), typeof(Color), typeof(MaterialDivider), defaultValue: MaterialColor.OutlineVariant);

        public new Color Color
        {
            get { return (Color)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        public static new readonly BindableProperty HeightRequestProperty =
            BindableProperty.Create(nameof(HeightRequest), typeof(double), typeof(MaterialDivider), defaultValue: 1.0);

        public new double HeightRequest
        {
            get { return (double)GetValue(HeightRequestProperty); }
            set { SetValue(HeightRequestProperty, value); }
        }
        #endregion  Properties

        #region Methods

        private void Initialize()
        {
            base.BackgroundColor = this.BackgroundColor;
            base.Color = this.Color;
            base.HeightRequest = this.HeightRequest;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            switch (propertyName)
            {
                case nameof(this.BackgroundColor):
                    base.BackgroundColor = this.BackgroundColor;
                    break;
                case nameof(this.Color):
                    base.Color = this.Color;
                    break;
                case nameof(this.HeightRequest):
                    base.HeightRequest = this.HeightRequest;
                    break;
            }
        }

        #endregion  Methods
    }
}