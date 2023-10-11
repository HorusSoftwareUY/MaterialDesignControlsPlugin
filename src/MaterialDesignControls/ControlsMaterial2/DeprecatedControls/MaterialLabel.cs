using System.Runtime.CompilerServices;
using Plugin.MaterialDesignControls.Material3;
using Plugin.MaterialDesignControls.Styles;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls
{
    public class MaterialLabel : Label
    {
        #region Properties

        public static new readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialLabel), defaultValue: null, propertyChanged: OnTextChanged);

        public new string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static new readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialLabel), defaultValue: DefaultStyles.TextColor);

        public new Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        public static readonly BindableProperty ToUpperProperty =
            BindableProperty.Create(nameof(ToUpper), typeof(bool), typeof(MaterialLabel), defaultValue: false);

        public bool ToUpper
        {
            get { return (bool)GetValue(ToUpperProperty); }
            set { SetValue(ToUpperProperty, value); }
        }

        #endregion Properties

        #region Constructors

        public MaterialLabel()
        {
            base.TextColor = this.TextColor;
        }

        #endregion Constructors

        #region Methods

        private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialLabel)bindable;
            control.ApplyTextProperty();
        }

        private void ApplyTextProperty()
        {
            base.Text = this.ToUpper ? this.Text?.ToUpper() : this.Text;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            switch (propertyName)
            {
                case nameof(TextColor):
                    base.TextColor = this.TextColor;
                    break;
                default:
                    base.OnPropertyChanged(propertyName);
                    break;
            }
        }

        #endregion Methods
    }
}
