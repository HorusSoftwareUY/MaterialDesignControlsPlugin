using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls
{
    public class MaterialLabel : Label
    {
        public static new readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialEntry), defaultValue: null, propertyChanged: OnTextChanged);

        public new string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty TextScaleProperty =
            BindableProperty.Create(nameof(TextScale), typeof(ScaleTypes), typeof(MaterialLabel), defaultValue: ScaleTypes.Caption, propertyChanged: OnPropertyChanged);

        public ScaleTypes TextScale
        {
            get { return (ScaleTypes)GetValue(TextScaleProperty); }
            set { SetValue(TextScaleProperty, value); }
        }

        public static readonly BindableProperty LetterSpacingProperty =
            BindableProperty.Create(nameof(LetterSpacing), typeof(double), typeof(MaterialLabel), defaultValue: 0.4);

        public double LetterSpacing
        {
            get { return (double)GetValue(LetterSpacingProperty); }
            set { SetValue(LetterSpacingProperty, value); }
        }

        private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialLabel)bindable;
            control.ApplyTextProperty();
        }

        private void ApplyTextProperty()
        {
            switch (this.TextScale)
            {
                case ScaleTypes.BUTTON:
                case ScaleTypes.OVERLINE:
                    base.Text = this.Text?.ToUpper();
                    break;
                default:
                    base.Text = this.Text;
                    break;
            }
        }

        private static void OnPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialLabel)bindable;
            control.ApplyControlProperties();
        }

        private void ApplyControlProperties()
        {
            switch (this.TextScale)
            {
                case ScaleTypes.H1:
                    this.FontSize = 96;
                    this.LetterSpacing = 0;
                    break;
                case ScaleTypes.H2:
                    this.FontSize = 60;
                    this.LetterSpacing = 0;
                    break;
                case ScaleTypes.H3:
                    this.FontSize = 48;
                    this.LetterSpacing = 0;
                    break;
                case ScaleTypes.H4:
                    this.FontSize = 34;
                    this.LetterSpacing = 0.25;
                    break;
                case ScaleTypes.H5:
                    this.FontSize = 24;
                    this.LetterSpacing = 0;
                    break;
                case ScaleTypes.H6:
                    this.FontSize = 20;
                    this.LetterSpacing = 0.15;
                    break;
                case ScaleTypes.Subtitle1:
                    this.FontSize = 16;
                    this.LetterSpacing = 0.15;
                    break;
                case ScaleTypes.Subtitle2:
                    this.FontSize = 14;
                    this.LetterSpacing = 0.1;
                    break;
                case ScaleTypes.Body1:
                    this.FontSize = 16;
                    this.LetterSpacing = 0.2;
                    break;
                case ScaleTypes.Body2:
                    this.FontSize = 14;
                    this.LetterSpacing = 0.1;
                    break;
                case ScaleTypes.Body3:
                    this.FontSize = 12;
                    this.LetterSpacing = 0;
                    break;
                case ScaleTypes.Body4:
                    this.FontSize = 10;
                    this.LetterSpacing = 0;
                    break;
                case ScaleTypes.BUTTON:
                    this.FontSize = 14;
                    this.LetterSpacing = 0.2;
                    base.Text = this.Text?.ToUpper();
                    break;
                case ScaleTypes.Button:
                    this.FontSize = 14;
                    this.LetterSpacing = 0.2;
                    break;
                case ScaleTypes.Caption:
                    this.FontSize = 12;
                    this.LetterSpacing = 0.2;
                    break;
                case ScaleTypes.OVERLINE:
                    this.FontSize = 10;
                    this.LetterSpacing = 0.75;
                    base.Text = this.Text?.ToUpper();
                    break;
                case ScaleTypes.Overline:
                    this.FontSize = 10;
                    this.LetterSpacing = 0.75;
                    break;
            }
        }
    }
}
