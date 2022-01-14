using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls
{
    public class MaterialDivider : BoxView
    {
        private bool Initialized = false;

        #region Constructor

        public MaterialDivider()
        {
            if (!Initialized)
            {
                Initialized = true;
                Initialize();
	        }
            
        }

        #endregion Constructor

        #region Properties

        public static new readonly BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialDivider), defaultValue: Color.Gray);

        public new Color BackgroundColor 
	    {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
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
            base.HeightRequest = this.HeightRequest;
	    }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            switch (propertyName)
            {
                case nameof(this.BackgroundColor):
                    base.BackgroundColor = this.BackgroundColor;
                    break;
                case nameof(this.HeightRequest):
                    base.HeightRequest = this.HeightRequest;
                    break;
            }
        }

        #endregion  Methods
    }
}
