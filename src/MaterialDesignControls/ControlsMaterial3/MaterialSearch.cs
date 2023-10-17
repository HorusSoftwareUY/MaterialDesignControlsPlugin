using System;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3
{
    public partial class MaterialSearch : BaseMaterialFieldControl
    {
        #region Properties

        public static readonly BindableProperty SearchCommandProperty =
            BindableProperty.Create(nameof(SearchCommand), typeof(ICommand), typeof(MaterialSearch), defaultValue: null);

        public ICommand SearchCommand
        {
            get { return (ICommand)GetValue(SearchCommandProperty); }
            set { SetValue(SearchCommandProperty, value); }
        }

        public static readonly BindableProperty SearchOnEveryTextChangeProperty =
            BindableProperty.Create(nameof(SearchOnEveryTextChange), typeof(bool), typeof(MaterialSearch), defaultValue: false);

        public bool SearchOnEveryTextChange
        {
            get { return (bool)GetValue(SearchOnEveryTextChangeProperty); }
            set { SetValue(SearchOnEveryTextChangeProperty, value); }
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(MaterialSearch), defaultValue: null, propertyChanged: OnTextChanged, defaultBindingMode: BindingMode.TwoWay);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        #endregion Properties

        #region Events

        public event EventHandler TextChanged;

        public new event EventHandler<FocusEventArgs> Focused;

        public new event EventHandler<FocusEventArgs> Unfocused;

        #endregion Events

        #region Constructors

        public MaterialSearch()
        {
            txtEntry = new Plugin.MaterialDesignControls.Material3.Implementations.CustomEntry()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            txtEntry.SetValue(Grid.ColumnProperty, 1);
            txtEntry.SetValue(Grid.RowProperty, 0);
            txtEntry.SetValue(Grid.RowSpanProperty, 2);
            txtEntry.VerticalOptions = LayoutOptions.Center;
            txtEntry.ReturnType = ReturnType.Search;
            CustomContent = txtEntry;

            this.txtEntry.Focused += HandleFocusChange;
            this.txtEntry.Unfocused += HandleFocusChange;
            this.txtEntry.TextChanged += TxtEntry_TextChanged;
            SetDefaultStyle();

            TapGestureRecognizer frameTapGestureRecognizer = new TapGestureRecognizer();
            frameTapGestureRecognizer.Tapped += (s, e) =>
            {
                if (txtEntry.IsControlEnabled())
                    this.txtEntry.Focus();
            };

            this.Label.GestureRecognizers.Clear();
            this.Label.GestureRecognizers.Add(frameTapGestureRecognizer);
        }

        private void SetDefaultStyle()
        {
            this.HasBorder = true;
            this.CornerRadius = 25;
            this.BorderWidth = 1;
        }

        #endregion Constructor

        #region Attributes

        private Plugin.MaterialDesignControls.Material3.Implementations.CustomEntry txtEntry;

        private int focusNextElementAttempts;

        #endregion Attributes

        #region Methods

        private async static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialSearch)bindable;

            if (!control.txtEntry.IsFocused)
            {
                if (!string.IsNullOrEmpty((string)newValue))
                    await control.TransitionToTitle();
                else
                    await control.TransitionToPlaceholder();
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
                case nameof(this.SearchOnEveryTextChange):
                    if (!this.SearchOnEveryTextChange && SearchCommand != null)
                    {
                        this.txtEntry.ReturnType = ReturnType.Search;
                        this.txtEntry.ReturnCommand = SearchCommand;
                    }
                    else
                    {
                        this.txtEntry.ReturnType = ReturnType.Default;
                        this.txtEntry.ReturnCommand = null;
                    }
                    break;
                case nameof(this.SearchCommand):
                    if (!this.SearchOnEveryTextChange)
                        this.txtEntry.ReturnCommand = SearchCommand;
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
            await SetFocusChange();

            if (txtEntry.IsControlFocused())
            {
                Focused?.Invoke(this, e);

                var textInsideInput = txtEntry.Text;
                txtEntry.CursorPosition = string.IsNullOrEmpty(textInsideInput) ? 0 : textInsideInput.Length;
            }
            else
                Unfocused?.Invoke(this, e);
        }

        private async void TxtEntry_TextChanged(object sender, TextChangedEventArgs e)
        {
            var changedByTextTransform = Text != null && txtEntry.Text != null && Text.ToLower() == txtEntry.Text.ToLower();
            this.Text = this.txtEntry.Text;
            if (this.SearchOnEveryTextChange)
                this.SearchCommand?.Execute(this.Text);
        }

        #endregion Methods
    }
}