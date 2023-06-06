using System.Runtime.CompilerServices;
using System;
using Xamarin.Forms.Xaml;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3
{
    public class MaterialEditor : BaseMaterialFieldControl
    {
        #region Constructors

        public MaterialEditor()
        {
            txtEditor = new Plugin.MaterialDesignControls.Material3.Implementations.CustomEditor()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = -1
            };
            txtEditor.SetValue(Grid.ColumnProperty, 1);
            txtEditor.SetValue(Grid.RowProperty, 1);
            CustomContent = txtEditor;

            this.txtEditor.Focused += HandleFocusChange;
            this.txtEditor.Unfocused += HandleFocusChange;
            this.txtEditor.TextChanged += TxtEntry_TextChanged;

            TapGestureRecognizer frameTapGestureRecognizer = new TapGestureRecognizer();
            frameTapGestureRecognizer.Tapped += (s, e) =>
            {
                if (txtEditor.IsControlEnabled())
                {
                    this.txtEditor.Focus();
                }
            };
            this.Label.GestureRecognizers.Clear();
            this.Label.GestureRecognizers.Add(frameTapGestureRecognizer);
        }

        #endregion Constructors

        #region Attributes

        private Plugin.MaterialDesignControls.Material3.Implementations.CustomEditor txtEditor;

        #endregion Attributes

        #region Properties
        public static readonly BindableProperty KeyboardProperty =
            BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(MaterialEditor), defaultValue: Keyboard.Text);

        public Keyboard Keyboard
        {
            get { return (Keyboard)GetValue(KeyboardProperty); }
            set { SetValue(KeyboardProperty, value); }
        }

        public static readonly BindableProperty KeyboardFlagsProperty =
            BindableProperty.Create(nameof(KeyboardFlags), typeof(string), typeof(MaterialEditor), defaultValue: null);

        public string KeyboardFlags
        {
            get { return (string)GetValue(KeyboardFlagsProperty); }
            set { SetValue(KeyboardFlagsProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialEditor), defaultValue: null, propertyChanged: OnTextChanged, defaultBindingMode: BindingMode.TwoWay);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty MaxLengthProperty =
            BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(MaterialEditor), defaultValue: Int32.MaxValue);

        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }

        public static readonly BindableProperty AutoSizeProperty =
            BindableProperty.Create(nameof(AutoSize), typeof(EditorAutoSizeOption), typeof(MaterialEditor), defaultValue: EditorAutoSizeOption.TextChanges);

        public EditorAutoSizeOption AutoSize
        {
            get { return (EditorAutoSizeOption)GetValue(AutoSizeProperty); }
            set { SetValue(AutoSizeProperty, value); }
        }
        #endregion Properties

        #region Events

        public event EventHandler TextChanged;

        public new event EventHandler<FocusEventArgs> Focused;

        public new event EventHandler<FocusEventArgs> Unfocused;

        #endregion Events

        #region Methods

        private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialEditor)bindable;
            control.txtEditor.Text = (string)newValue;
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            UpdateLayout(propertyName);

            switch (propertyName)
            {
                case nameof(base.TranslationX):
                    base.OnPropertyChanged(propertyName);
                    break;

                case nameof(this.Keyboard):
                    this.txtEditor.Keyboard = this.Keyboard;
                    break;
                case nameof(KeyboardFlags):
                    if (KeyboardFlags != null)
                    {
                        try
                        {
                            string[] flagNames = ((string)KeyboardFlags).Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            KeyboardFlags allFlags = 0;
                            foreach (var flagName in flagNames)
                            {
                                KeyboardFlags flags = 0;
                                Enum.TryParse<KeyboardFlags>(flagName.Trim(), out flags);
                                if (flags != 0)
                                    allFlags |= flags;
                            }
                            txtEditor.Keyboard = Keyboard.Create(allFlags);
                        }
                        catch
                        {
                            throw new XamlParseException("The keyboard flags are invalid or have a wrong specification.");
                        }
                    }
                    break;

                case nameof(this.MaxLength):
                    this.txtEditor.MaxLength = this.MaxLength;
                    break;
                case nameof(this.TabIndex):
                    if (this.TabIndex != 0)
                    {
                        this.txtEditor.TabIndex = this.TabIndex;
                        this.TabIndex = 0;
                    }
                    break;
                case nameof(this.IsTabStop):
                    this.txtEditor.IsTabStop = this.IsTabStop;
                    break;

                case nameof(AutoSize):
                    this.txtEditor.AutoSize = AutoSize;
                    break;
            }
        }

        public new bool Focus()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                txtEditor.Focus();
            });
            return true;
        }

        public new bool Unfocus()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                txtEditor.Unfocus();
            });
            return true;
        }

        private async void HandleFocusChange(object sender, FocusEventArgs e)
        {
            await SetFocusChange();

            if (txtEditor.IsControlFocused())
                Focused?.Invoke(this, e);
            else
                Unfocused?.Invoke(this, e);
        }

        private void TxtEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            this.Text = this.txtEditor.Text;
            this.TextChanged?.Invoke(this, e);
        }

        #endregion Methods
    }
}
