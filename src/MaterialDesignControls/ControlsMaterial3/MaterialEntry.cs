using Plugin.MaterialDesignControls.Implementations;
using Plugin.MaterialDesignControls.Utils;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls.Material3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialEntry : BaseMaterialFieldControl
    {
        #region Constructors

        public MaterialEntry()
        {
            txtEntry = new Plugin.MaterialDesignControls.Material3.Implementations.CustomEntry()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            txtEntry.SetValue(Grid.ColumnProperty, 1);
            txtEntry.SetValue(Grid.RowProperty, 1);
            CustomContent = txtEntry;

            this.txtEntry.Focused += HandleFocusChange;
            this.txtEntry.Unfocused += HandleFocusChange;
            this.txtEntry.TextChanged += TxtEntry_TextChanged;

            TapGestureRecognizer frameTapGestureRecognizer = new TapGestureRecognizer();
            frameTapGestureRecognizer.Tapped +=  (s, e) =>
            {
                this.txtEntry.Focus();
            };
            this.FrameContainer.GestureRecognizers.Add(frameTapGestureRecognizer);
        }

        #endregion Constructors

        #region Attributes

        private Plugin.MaterialDesignControls.Material3.Implementations.CustomEntry txtEntry;

        #endregion Attributes

        #region Properties
        public static readonly BindableProperty IsPasswordProperty =
            BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(MaterialEntry), defaultValue: false);

        public bool IsPassword
        {
            get { return (bool)GetValue(IsPasswordProperty); }
            set { SetValue(IsPasswordProperty, value); }
        }

        public static readonly BindableProperty IsCodeProperty =
            BindableProperty.Create(nameof(IsCode), typeof(bool), typeof(MaterialEntry), defaultValue: false);

        public bool IsCode
        {
            get { return (bool)GetValue(IsCodeProperty); }
            set { SetValue(IsCodeProperty, value); }
        }

        public static readonly BindableProperty KeyboardProperty =
            BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(MaterialEntry), defaultValue: Keyboard.Text);

        public Keyboard Keyboard
        {
            get { return (Keyboard)GetValue(KeyboardProperty); }
            set { SetValue(KeyboardProperty, value); }
        }

        public static readonly BindableProperty KeyboardFlagsProperty =
            BindableProperty.Create(nameof(KeyboardFlags), typeof(string), typeof(MaterialEntry), defaultValue: null);

        public string KeyboardFlags
        {
            get { return (string)GetValue(KeyboardFlagsProperty); }
            set { SetValue(KeyboardFlagsProperty, value); }
        }

        public static readonly BindableProperty TextTransformProperty =
            BindableProperty.Create(nameof(TextTransform), typeof(TextTransforms), typeof(MaterialEntry), defaultValue: TextTransforms.Default);

        public TextTransforms TextTransform
        {
            get { return (TextTransforms)GetValue(TextTransformProperty); }
            set { SetValue(TextTransformProperty, value); }
        }

        public static readonly BindableProperty ReturnTypeProperty =
            BindableProperty.Create(nameof(ReturnType), typeof(ReturnType), typeof(MaterialEntry), defaultValue: ReturnType.Default);

        public ReturnType ReturnType
        {
            get { return (ReturnType)GetValue(ReturnTypeProperty); }
            set { SetValue(ReturnTypeProperty, value); }
        }

        public static readonly BindableProperty ReturnCommandProperty =
            BindableProperty.Create(nameof(ReturnCommand), typeof(ICommand), typeof(MaterialEntry), defaultValue: null);

        public ICommand ReturnCommand
        {
            get { return (ICommand)GetValue(ReturnCommandProperty); }
            set { SetValue(ReturnCommandProperty, value); }
        }

        public static readonly BindableProperty ReturnCommandParameterProperty =
            BindableProperty.Create(nameof(ReturnCommandParameter), typeof(object), typeof(MaterialEntry), defaultValue: null);

        public object ReturnCommandParameter
        {
            get { return (object)GetValue(ReturnCommandParameterProperty); }
            set { SetValue(ReturnCommandParameterProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialEntry), defaultValue: null, propertyChanged: OnTextChanged, defaultBindingMode: BindingMode.TwoWay);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public static readonly BindableProperty MaxLengthProperty =
            BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(MaterialEntry), defaultValue: Int32.MaxValue);

        public int MaxLength
        {
            get { return (int)GetValue(MaxLengthProperty); }
            set { SetValue(MaxLengthProperty, value); }
        }

        public static readonly BindableProperty CursorPositionProperty =
            BindableProperty.Create(nameof(CursorPosition), typeof(int), typeof(MaterialEntry), defaultValue: 0);

        public int CursorPosition
        {
            get { return (int)GetValue(CursorPositionProperty); }
            set { SetValue(CursorPositionProperty, value); }
        }

        #endregion Properties

        #region Events
        public event EventHandler TextChanged;

        public new event EventHandler<FocusEventArgs> Focused;

        public new event EventHandler<FocusEventArgs> Unfocused;

        public static readonly BindableProperty TextChangedCommandProperty =
            BindableProperty.Create(nameof(TextChangedCommand), typeof(ICommand), typeof(MaterialEntry), defaultValue: null);

        public ICommand TextChangedCommand
        {
            get { return (ICommand)GetValue(TextChangedCommandProperty); }
            set { SetValue(TextChangedCommandProperty, value); }
        }
        #endregion Events

        #region Methods

        private async static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialEntry)bindable;

            if (!control.txtEntry.IsFocused)
            {
                if (!string.IsNullOrEmpty((string)newValue))
                {
                    await control.TransitionToTitle();
                }
                else
                {
                    await control.TransitionToPlaceholder();
                }
            }

            control.txtEntry.Text = (string)newValue;
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
                    this.txtEntry.Keyboard = this.Keyboard;
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
                            txtEntry.Keyboard = Keyboard.Create(allFlags);
                        }
                        catch
                        {
                            throw new XamlParseException("The keyboard flags are invalid or have a wrong specification.");
                        }
                    }
                    break;
                case nameof(TextTransform):
                    ApplyTextTransform();
                    break;

                case nameof(this.MaxLength):
                    this.txtEntry.MaxLength = this.MaxLength;
                    break;

                case nameof(this.CursorPosition):
                    this.txtEntry.CursorPosition = this.CursorPosition;
                    break;

                case nameof(IsPassword):
                    this.txtEntry.IsPassword = IsPassword;
                    break;

                case nameof(this.TabIndex):
                    if (this.TabIndex != 0)
                    {
                        this.txtEntry.TabIndex = this.TabIndex;
                        this.TabIndex = 0;
                    }
                    break;
                case nameof(this.IsTabStop):
                    this.txtEntry.IsTabStop = this.IsTabStop;
                    break;
                case nameof(this.ReturnType):
                    this.txtEntry.ReturnType = this.ReturnType;

                    if (this.ReturnType.Equals(Xamarin.Forms.ReturnType.Next) && this.ReturnCommand == null)
                    {
                        this.txtEntry.ReturnCommand = new Command(() =>
                        {
                            var currentTabIndex = this.txtEntry.TabIndex;
                            this.FocusNextElement(currentTabIndex);
                        });
                    }
                    break;
                case nameof(this.ReturnCommand):
                    this.txtEntry.ReturnCommand = this.ReturnCommand;
                    break;
                case nameof(this.ReturnCommandParameter):
                    this.txtEntry.ReturnCommandParameter = this.ReturnCommandParameter;
                    break;
                case nameof(this.IsCode):
                    this.txtEntry.IsCode = this.IsCode;
                    break;
            }
        }

        public new bool Focus()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                txtEntry.Focus();
            });
            return true;
        }

        public new bool Unfocus()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                txtEntry.Unfocus();
            });
            return true;
        }

        private async void HandleFocusChange(object sender, FocusEventArgs e)
        {
            SetFocusChange();

            if (txtEntry.IsControlFocused())
            {
                Focused?.Invoke(this, e);
                FocusedCommand?.Execute(null);

                var textInsideInput = txtEntry.Text;
                txtEntry.CursorPosition = string.IsNullOrEmpty(textInsideInput) ? 0 : textInsideInput.Length;

                if (string.IsNullOrEmpty(textInsideInput))
                {
                    await TransitionToTitle();
                }
            }
            else
            {
                Unfocused?.Invoke(this, e);
                UnfocusedCommand?.Execute(null);

                if (string.IsNullOrEmpty(Text))
                {
                    await TransitionToPlaceholder();
                }
            }
        }

        private void TxtEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var changedByTextTransform = Text != null && txtEntry.Text != null && Text.ToLower() == txtEntry.Text.ToLower();

            this.Text = this.txtEntry.Text;

            if (!changedByTextTransform)
            {
                this.TextChangedCommand?.Execute(null);
                this.TextChanged?.Invoke(this, e);
            }

            ApplyTextTransform();
        }

        private void FocusNextElement(int currentTabIndex)
        {
            try
            {
                var tabIndexes = this.GetTabIndexesOnParentPage(out int count);

                if (tabIndexes != null)
                {
                    var nextElement = this.FindNextElement(true, tabIndexes, ref currentTabIndex);
                    if (nextElement != null)
                    {
                        if (nextElement is Plugin.MaterialDesignControls.Material3.Implementations.CustomEntry nextEntry && nextEntry.IsEnabled && !nextEntry.IsReadOnly)
                        {
                            nextEntry.Focus();
                            string textInsideInput = nextEntry.Text;
                            nextEntry.CursorPosition = string.IsNullOrEmpty(textInsideInput) ? 0 : textInsideInput.Length;
                        }
                        else if (nextElement is CustomEditor nextEditor && nextEditor.IsEnabled && !nextEditor.IsReadOnly)
                        {
                            nextEditor.Focus();
                        }
                        else
                        {
                            this.FocusNextElement(++currentTabIndex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LoggerHelper.Log(ex);
            }
        }

        private void ApplyTextTransform()
        {
            if (TextTransform == TextTransforms.Default || txtEntry.Text == null)
                return;
            else if (TextTransform == TextTransforms.Lowercase)
                txtEntry.Text = txtEntry.Text.ToLower();
            else if (TextTransform == TextTransforms.Uppercase)
                txtEntry.Text = txtEntry.Text.ToUpper();
        }

        private async Task TransitionToTitle()
        {
            if (AnimatePlaceholder)
            {
                AnimatedLabel.IsVisible = true;
                AnimatedLabel.TextColor = PlaceholderColor;
                txtEntry.Placeholder = "";

                var t1 = AnimatedLabel.TranslateTo(Label.X, Label.Y, 200);
                var t2 = SizeTo(LabelSize);
                await Task.WhenAll(t1, t2);

                AnimatedLabel.IsVisible = false;
                Label.IsVisible = true;
                Label.Text = AnimatedLabel.Text;

                txtEntry.SetValue(Grid.ColumnProperty, 1);
                txtEntry.SetValue(Grid.RowProperty, 1);
                txtEntry.SetValue(Grid.RowSpanProperty, 1);
            }
        }

        private async Task TransitionToPlaceholder()
        {
            if (AnimatePlaceholder)
            {
                AnimatedLabel.IsVisible = true;
                AnimatedLabel.TextColor = LabelTextColor;
                Label.IsVisible = false;

                var t1 = AnimatedLabel.TranslateTo(txtEntry.X, txtEntry.Y, 200);
                var t2 = SizeTo(txtEntry.FontSize);
                await Task.WhenAll(t1, t2);

                Label.IsVisible = false;
                AnimatedLabel.IsVisible = false;
                txtEntry.Placeholder = AnimatedLabel.Text;

                if (!IsFocused)
                {
                    txtEntry.SetValue(Grid.ColumnProperty, 1);
                    txtEntry.SetValue(Grid.RowProperty, 0);
                    txtEntry.SetValue(Grid.RowSpanProperty, 2);
                }
            }
        }

        private Task SizeTo(double fontSize)
        {
            var taskCompletionSource = new TaskCompletionSource<bool>();

            Action<double> callback = input => { Label.FontSize = input; };
            double startingHeight = AnimatedLabel.FontSize;
            double endingHeight = fontSize;
            uint rate = 5;
            uint length = 200;
            Easing easing = Easing.Linear;

            AnimatedLabel.Animate("AnimateLabel", callback, startingHeight, endingHeight, rate, length, easing, (v, c) => taskCompletionSource.SetResult(c));

            return taskCompletionSource.Task;
        }
        #endregion Methods
    }
}