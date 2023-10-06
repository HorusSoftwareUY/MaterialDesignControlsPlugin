using System;
using Plugin.MaterialDesignControls.Styles;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3
{
    public enum LabelTypes
    {
        DisplayLarge,
        DisplayMedium,
        DisplaySmall,
        HeadlineLarge,
        HeadlineMedium,
        HeadlineSmall,
        TitleLarge,
        TitleMedium,
        TitleSmall,
        LabelLarge,
        LabelMedium,
        LabelSmall,
        BodyLarge,
        BodyMedium,
        BodySmall
    }

    public class MaterialLabel : Label
    {
        #region Properties

        public static readonly BindableProperty TypeProperty =
            BindableProperty.Create(nameof(Type), typeof(LabelTypes), typeof(MaterialLabel), defaultValue: LabelTypes.BodyMedium, propertyChanged: OnTypeChanged);

        public LabelTypes Type
        {
            get { return (LabelTypes)GetValue(TypeProperty); }
            set { SetValue(TypeProperty, value); }
        }

        public static new readonly BindableProperty FontFamilyProperty =
            BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(MaterialLabel), defaultValue: DefaultStyles.FontFamily);

        public new string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        public static readonly BindableProperty FontFamilyRegularProperty =
            BindableProperty.Create(nameof(FontFamilyRegular), typeof(string), typeof(MaterialLabel), defaultValue: DefaultStyles.FontFamilyRegular);

        public string FontFamilyRegular
        {
            get { return (string)GetValue(FontFamilyRegularProperty); }
            set { SetValue(FontFamilyRegularProperty, value); }
        }

        public static readonly BindableProperty FontFamilyMediumProperty =
            BindableProperty.Create(nameof(FontFamilyMedium), typeof(string), typeof(MaterialLabel), defaultValue: DefaultStyles.FontFamilyMedium);

        public string FontFamilyMedium
        {
            get { return (string)GetValue(FontFamilyMediumProperty); }
            set { SetValue(FontFamilyMediumProperty, value); }
        }

        public static new readonly BindableProperty TextColorProperty =
            BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MaterialLabel), defaultValue: DefaultStyles.TextColor);

        public new Color TextColor
        {
            get { return (Color)GetValue(TextColorProperty); }
            set { SetValue(TextColorProperty, value); }
        }

        #endregion Properties

        #region Constructors

        public MaterialLabel()
        {
            base.FontFamily = this.FontFamily;
            base.TextColor = this.TextColor;
            base.FontSize = DefaultStyles.FontSizes.BodyMedium;
        }

        #endregion Constructors

        #region Methods

        private static void OnTypeChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialLabel)bindable;
            control.ApplyTypeProperty((LabelTypes)newValue);
        }

        private void ApplyTypeProperty(LabelTypes labelType)
        {
            switch (labelType)
            {
                case LabelTypes.DisplayLarge:
                    base.FontFamily = this.FontFamily;
                    base.CharacterSpacing = -0.25;
                    base.FontSize = DefaultStyles.FontSizes.DisplayLarge;
                    break;
                case LabelTypes.DisplayMedium:
                    base.FontFamily = this.FontFamily;
                    base.CharacterSpacing = 0;
                    base.FontSize = DefaultStyles.FontSizes.DisplayMedium;
                    break;
                case LabelTypes.DisplaySmall:
                    base.FontFamily = this.FontFamily;
                    base.CharacterSpacing = 0;
                    base.FontSize = DefaultStyles.FontSizes.DisplaySmall;
                    break;
                case LabelTypes.HeadlineLarge:
                    base.FontFamily = this.FontFamily;
                    base.CharacterSpacing = 0;
                    base.FontSize = DefaultStyles.FontSizes.HeadlineLarge;
                    break;
                case LabelTypes.HeadlineMedium:
                    base.FontFamily = this.FontFamily;
                    base.CharacterSpacing = 0;
                    base.FontSize = DefaultStyles.FontSizes.HeadlineMedium;
                    break;
                case LabelTypes.HeadlineSmall:
                    base.FontFamily = this.FontFamily;
                    base.CharacterSpacing = 0;
                    base.FontSize = DefaultStyles.FontSizes.HeadlineSmall;
                    break;
                case LabelTypes.TitleLarge:
                    base.FontFamily = this.FontFamilyRegular;
                    base.CharacterSpacing = 0;
                    base.FontSize = DefaultStyles.FontSizes.TitleLarge;
                    break;
                case LabelTypes.TitleMedium:
                    base.FontFamily = this.FontFamilyMedium;
                    base.CharacterSpacing = 0.15;
                    base.FontSize = DefaultStyles.FontSizes.TitleMedium;
                    break;
                case LabelTypes.TitleSmall:
                    base.FontFamily = this.FontFamilyMedium;
                    base.CharacterSpacing = 0.1;
                    base.FontSize = DefaultStyles.FontSizes.TitleSmall;
                    break;
                case LabelTypes.LabelLarge:
                    base.FontFamily = this.FontFamilyMedium;
                    base.CharacterSpacing = 0.1;
                    base.FontSize = DefaultStyles.FontSizes.LabelLarge;
                    break;
                case LabelTypes.LabelMedium:
                    base.FontFamily = this.FontFamilyMedium;
                    base.CharacterSpacing = 0.5;
                    base.FontSize = DefaultStyles.FontSizes.LabelMedium;
                    break;
                case LabelTypes.LabelSmall:
                    base.FontFamily = this.FontFamilyMedium;
                    base.CharacterSpacing = 0.5;
                    base.FontSize = DefaultStyles.FontSizes.LabelSmall;
                    break;
                case LabelTypes.BodyLarge:
                    base.FontFamily = this.FontFamily;
                    base.CharacterSpacing = 0.5;
                    base.FontSize = DefaultStyles.FontSizes.BodyLarge;
                    break;
                case LabelTypes.BodyMedium:
                    base.FontFamily = this.FontFamily;
                    base.CharacterSpacing = 0.25;
                    base.FontSize = DefaultStyles.FontSizes.BodyMedium;
                    break;
                case LabelTypes.BodySmall:
                    base.FontFamily = this.FontFamily;
                    base.CharacterSpacing = 0.4;
                    base.FontSize = DefaultStyles.FontSizes.BodySmall;
                    break;
            }
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            switch (propertyName)
            {
                case nameof(FontFamily):
                    base.FontFamily = this.FontFamily;
                    break;
                case nameof(FontFamilyRegular):
                    base.FontFamily = this.FontFamilyRegular;
                    break;
                case nameof(FontFamilyMedium):
                    base.FontFamily = this.FontFamilyMedium;
                    break;
                case nameof(TextColor):
                    base.TextColor = this.TextColor;
                    break;
            }
            base.OnPropertyChanged(propertyName);
        }

        #endregion Methods
    }
}