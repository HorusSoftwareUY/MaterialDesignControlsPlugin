using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ContentViews
{
    public partial class InfoIndicatorView : Frame
    {
        public static readonly BindableProperty MessageProperty =
            BindableProperty.Create(nameof(Message), typeof(string), typeof(InfoIndicatorView), defaultValue: null);

        public string Message
        {
            get => (string)GetValue(MessageProperty);
            set => SetValue(MessageProperty, value);
        }

        public InfoIndicatorView()
        {
            InitializeComponent();
        }

        protected override void OnPropertyChanged(string propertyName)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == MessageProperty.PropertyName)
                lblMessage.Text = Message;
        }
    }
}