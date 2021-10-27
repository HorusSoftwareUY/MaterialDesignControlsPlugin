using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls
{
    public class MaterialDivider : BoxView
    {
        #region Properties

        public static new readonly BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialDivider), defaultValue: Color.LightGray);

        public new Color BackgroundColor 
	    {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
	    }

        public static new readonly BindableProperty HeightRequestProperty =
            BindableProperty.Create(nameof(HeightRequest), typeof(double), typeof(MaterialDivider), defaultValue: 0.5);

        public new double HeightRequest 
	    {
            get { return (double)GetValue(HeightRequestProperty); }
            set { SetValue(HeightRequestProperty, value); }
	    }
        #endregion  Properties

        #region Methods

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
