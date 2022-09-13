using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls
{
    public class MaterialLabel : Label
    {
        #region Properties

        public static new readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialEntry), defaultValue: null, propertyChanged: OnTextChanged);

        public new string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty ToUpperProperty =
            BindableProperty.Create(nameof(ToUpper), typeof(bool), typeof(MaterialLabel), defaultValue: false);

        public bool ToUpper
        {
            get { return (bool)GetValue(ToUpperProperty); }
            set { SetValue(ToUpperProperty, value); }
        }

        #endregion Properties

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

        #endregion Methods
    }
}
