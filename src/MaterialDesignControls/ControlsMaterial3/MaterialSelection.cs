using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3
{
    public class MaterialSelection : BaseMaterialFieldControl
    {
        #region Constructors

        public MaterialSelection()
        {
            lblCustom = new Plugin.MaterialDesignControls.Material3.Implementations.CustomLabel()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            lblCustom.SetValue(Grid.ColumnProperty, 1);
            lblCustom.SetValue(Grid.RowProperty, 1);
            CustomContent = lblCustom;
        }

        #endregion Constructors

        #region Attributes

        private Plugin.MaterialDesignControls.Material3.Implementations.CustomLabel lblCustom;

        #endregion Attributes

        #region Properties


        public new static readonly BindableProperty AnimatePlaceholderProperty =
            BindableProperty.Create(nameof(AnimatePlaceholder), typeof(bool), typeof(BaseMaterialFieldControl), defaultValue: false);

        public new bool AnimatePlaceholder => false;

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(MaterialSelection), defaultValue: null, propertyChanged: OnCommandChanged);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(MaterialSelection), defaultValue: null);

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialSelection), defaultValue: null, propertyChanged: OnTextChanged);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        #endregion Properties

        #region Methods

        private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialSelection)bindable;
            if (string.IsNullOrEmpty((string)newValue))
            {
                control.lblCustom.Text = control.Placeholder;
                control.lblCustom.TextColor = control.PlaceholderColor;
            }
            else
            {
                control.lblCustom.Text = (string)newValue;
                control.lblCustom.TextColor = control.TextColor;
            }
        }

        private static void OnCommandChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialSelection)bindable;

            TapGestureRecognizer selectionTapGestureRecognizer = new TapGestureRecognizer();
            selectionTapGestureRecognizer.Tapped += (s, e) =>
            {
                if (control.IsEnabled && control.Command != null && control.Command.CanExecute(control.CommandParameter))
                {
                    control.Command.Execute(control.CommandParameter);
                }
            };
            var customLabel = (Plugin.MaterialDesignControls.Material3.Implementations.CustomLabel)control.CustomContent;

            control.Label.GestureRecognizers.Clear();
            control.Label.GestureRecognizers.Add(selectionTapGestureRecognizer); 
            customLabel.GestureRecognizers.Clear();
            customLabel.GestureRecognizers.Add(selectionTapGestureRecognizer);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            UpdateLayout(propertyName);

            switch (propertyName)
            {
                case nameof(base.TranslationX):
                    base.OnPropertyChanged(propertyName);
                    break;
                case nameof(this.Text):
                    SetPlaceHolderInTextControl();
                    break;
            }
        }

        private void SetPlaceHolderInTextControl()
        {
            if (string.IsNullOrEmpty(this.Text))
            {
                this.lblCustom.Text = this.Placeholder;
                this.lblCustom.TextColor = this.PlaceholderColor;
            }
        }
        #endregion Methods
    }
}
