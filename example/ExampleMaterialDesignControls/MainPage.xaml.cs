using ExampleMaterialDesignControls.Pages;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            Children.Add(new NavigationPage(new MaterialControlsPage()) { Title = "Controls", IconImageSource = "Home.png" });
            Children.Add(new ProductDetailsPage());
            Children.Add(new AddCardPage());
            Children.Add(new ShippingPage());
            Children.Add(new InfoPage());
        }
    }
}