using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [Obsolete("MaterialDoublePicker is deprecated, please use MaterialDoublePicker of Material 3 instead.")]

    public partial class MaterialDoublePicker : BaseMaterialFieldControl
    {
        #region Constructors

        public MaterialDoublePicker()
        {
            if (!this.initialized)
            {
                this.initialized = true;
                this.InitializeComponent();
            }

            pckOptions.Focused += HandleFocusChange;
            pckOptions.Unfocused += HandleFocusChange;
            pckOptions.SelectedIndexesChanged += PckOptions_SelectedIndexesChanged;

            TapGestureRecognizer frameTapGestureRecognizer = new TapGestureRecognizer();
            frameTapGestureRecognizer.Tapped += (s, e) =>
            {
                if (IsControlEnabled)
                    this.pckOptions.Focus();
            };
            this.frmContainer.GestureRecognizers.Add(frameTapGestureRecognizer);
        }

        #endregion Constructors

        #region Attributes

        private bool initialized = false;

        #endregion Attributes

        #region Events

        public event EventHandler<SelectedIndexesEventArgs> SelectedIndexesChanged;

        #endregion Events

        #region Properties

        public static readonly new BindableProperty PaddingProperty =
            BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(MaterialDoublePicker), defaultValue: new Thickness(12, 0));

        public new Thickness Padding
        {
            get { return (Thickness)GetValue(PaddingProperty); }
            set { SetValue(PaddingProperty, value); }
        }

        public static readonly new BindableProperty IsEnabledProperty =
            BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(MaterialDoublePicker), defaultValue: true);

        public new bool IsEnabled
        {
            get { return (bool)GetValue(IsEnabledProperty); }
            set { SetValue(IsEnabledProperty, value); }
        }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable), typeof(MaterialDoublePicker), defaultValue: null, propertyChanged: OnItemsSourceChanged);

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty SecondaryItemsSourceProperty =
            BindableProperty.Create(nameof(SecondaryItemsSource), typeof(IEnumerable), typeof(MaterialDoublePicker), defaultValue: null, propertyChanged: OnSecondaryItemsSourceChanged);

        public IEnumerable SecondaryItemsSource
        {
            get { return (IEnumerable)GetValue(SecondaryItemsSourceProperty); }
            set { SetValue(SecondaryItemsSourceProperty, value); }
        }

        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(nameof(SelectedItem), typeof(string), typeof(MaterialDoublePicker), defaultValue: null, propertyChanged: OnSelectedItemChanged, defaultBindingMode: BindingMode.TwoWay);

        public string SelectedItem
        {
            get { return (string)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly BindableProperty SecondarySelectedItemProperty =
            BindableProperty.Create(nameof(SecondarySelectedItem), typeof(string), typeof(MaterialDoublePicker), defaultValue: null, propertyChanged: OnSecondarySelectedItemChanged, defaultBindingMode: BindingMode.TwoWay);

        public string SecondarySelectedItem
        {
            get { return (string)GetValue(SecondarySelectedItemProperty); }
            set { SetValue(SecondarySelectedItemProperty, value); }
        }

        public static readonly BindableProperty SeparatorProperty =
            BindableProperty.Create(nameof(Separator), typeof(string), typeof(MaterialDoublePicker), defaultValue: " ");

        public string Separator
        {
            get { return (string)GetValue(SeparatorProperty); }
            set { SetValue(SeparatorProperty, value); }
        }

        public static readonly new BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MaterialDoublePicker), defaultValue: Color.LightGray);

        public new Color BackgroundColor
        {
            get { return (Color)GetValue(BackgroundColorProperty); }
            set { SetValue(BackgroundColorProperty, value); }
        }

        public int SelectedIndex
        {
            get
            {
                if (this.ItemsSource != null)
                {
                    var index = 0;
                    foreach (var item in this.ItemsSource)
                    {
                        if (index.Equals(this.pckOptions.SelectedIndexes[0]))
                        {
                            return index;
                        }
                        index++;
                    }
                }

                return -1;
            }
        }

        public int SecondarySelectedIndex
        {
            get
            {
                if (this.SecondaryItemsSource != null)
                {
                    var index = 0;
                    foreach (var item in this.SecondaryItemsSource)
                    {
                        if (index.Equals(this.pckOptions.SelectedIndexes[1]))
                        {
                            return index;
                        }
                        index++;
                    }
                }

                return -1;
            }
        }

        public override bool IsControlFocused
        {
            get { return pckOptions.IsFocused; }
        }

        public override bool IsControlEnabled
        {
            get { return this.IsEnabled; }
        }

        public override Color BackgroundColorControl
        {
            get { return this.BackgroundColor; }
        }

        #endregion Properties

        #region Events

        public new event EventHandler<FocusEventArgs> Focused;

        public new event EventHandler<FocusEventArgs> Unfocused;

        #endregion Events

        #region Methods

        private static void OnSelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialDoublePicker)bindable;
            //control.pckOptions.SelectedItem = (string)newValue;
            //control.pckOptions.SelectedIndexes = new int[] { control.SelectedIndex, control.SecondarySelectedIndex };

            control.InternalUpdateSelectedIndex();
        }

        private static void OnSecondarySelectedItemChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialDoublePicker)bindable;
            //control.pckOptions.SelectedItem = (string)newValue;
            //control.pckOptions.SelectedIndexes = new int[] { control.SelectedIndex, control.SecondarySelectedIndex };

            control.InternalUpdateSelectedIndex();
        }

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialDoublePicker)bindable;
            control.pckOptions.Items.Clear();
            if (!Equals(newValue, null) && newValue is IEnumerable)
            {
                foreach (var item in (IEnumerable)newValue)
                {
                    control.pckOptions.Items.Add(item.ToString());
                }
            }
            control.InternalUpdateSelectedIndex();
        }

        private static void OnSecondaryItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (MaterialDoublePicker)bindable;
            control.pckOptions.SecondaryItems.Clear();
            if (!Equals(newValue, null) && newValue is IEnumerable)
            {
                foreach (var item in (IEnumerable)newValue)
                {
                    control.pckOptions.SecondaryItems.Add(item.ToString());
                }
            }
            control.InternalUpdateSelectedIndex();
        }

        private void InternalUpdateSelectedIndex()
        {
            var selectedIndex = -1;
            if (this.ItemsSource != null)
            {
                var index = 0;
                foreach (var item in this.ItemsSource)
                {
                    if (item != null && item.Equals(this.SelectedItem))
                    {
                        selectedIndex = index;
                        break;
                    }
                    index++;
                }
            }

            var secondarySelectedIndex = -1;
            if (this.SecondaryItemsSource != null)
            {
                var index = 0;
                foreach (var item in this.SecondaryItemsSource)
                {
                    if (item != null && item.Equals(this.SecondarySelectedItem))
                    {
                        secondarySelectedIndex = index;
                        break;
                    }
                    index++;
                }
            }

            this.pckOptions.SelectedIndexes = new int[] { selectedIndex, secondarySelectedIndex };
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (!this.initialized)
            {
                this.initialized = true;
                this.InitializeComponent();
            }

            UpdateLayout(propertyName, lblLabel, lblAssistive, frmContainer, bxvLine, imgLeadingIcon, imgTrailingIcon);

            switch (propertyName)
            {
                case nameof(base.TranslationX):
                    base.OnPropertyChanged(propertyName);
                    break;
                case nameof(this.Separator):
                    this.pckOptions.Separator = this.Separator;
                    break;
            }
        }

        protected override void SetIsEnabled()
        {
            pckOptions.IsEnabled = IsEnabled;
        }

        protected override void SetPadding()
        {
            frmContainer.Padding = Padding;
        }

        protected override void SetTextColor()
        {
            if (IsControlEnabled)
                pckOptions.TextColor = IsControlFocused && FocusedTextColor != Color.Transparent ? FocusedTextColor : TextColor;
            else
                pckOptions.TextColor = DisabledTextColor;
        }

        protected override void SetFontSize()
        {
            pckOptions.FontSize = FontSize;
        }

        protected override void SetFontFamily()
        {
            pckOptions.FontFamily = FontFamily;
        }

        protected override void SetPlaceholder()
        {
            pckOptions.Placeholder = Placeholder;
        }

        protected override void SetPlaceholderColor()
        {
            pckOptions.PlaceholderColor = PlaceholderColor;
        }

        protected override void SetHorizontalTextAlignment()
        {
            pckOptions.HorizontalTextAlignment = HorizontalTextAlignment;
        }

        public new bool Focus()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                pckOptions.Focus();
            });
            return true;
        }

        public new bool Unfocus()
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                pckOptions.Unfocus();
            });
            return true;
        }

        private void HandleFocusChange(object sender, FocusEventArgs e)
        {
            base.SetFocusChange(lblLabel, frmContainer, bxvLine);

            if (IsControlFocused)
                Focused?.Invoke(this, e);
            else
                Unfocused?.Invoke(this, e);
        }

        private void PckOptions_SelectedIndexesChanged(object sender, SelectedIndexesEventArgs e)
        {
            if (this.ItemsSource != null)
            {
                var index = 0;
                foreach (var item in this.ItemsSource)
                {
                    if (index.Equals(e.SelectedIndexes[0]))
                    {
                        this.SelectedItem = item.ToString();
                        break;
                    }
                    index++;
                }
            }

            if (this.SecondaryItemsSource != null)
            {
                var index = 0;
                foreach (var item in this.SecondaryItemsSource)
                {
                    if (index.Equals(e.SelectedIndexes[1]))
                    {
                        this.SecondarySelectedItem = item.ToString();
                        break;
                    }
                    index++;
                }
            }

            if (this.SelectedIndexesChanged != null)
            {
                this.SelectedIndexesChanged.Invoke(this, e);
            }
        }

        #endregion Methods
    }

    [Obsolete("SelectedIndexesEventArgs is deprecated, please use SelectedIndexesEventArgs of Material 3 instead.")]
    public class SelectedIndexesEventArgs : EventArgs
    {
        public int[] SelectedIndexes { get; set; }
    }
}
