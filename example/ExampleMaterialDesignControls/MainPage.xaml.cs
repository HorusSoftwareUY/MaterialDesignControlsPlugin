using ExampleMaterialDesignControls.Pages;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.Children.Add(new NavigationPage(new MaterialControlsPage()) { Title = "Controls", IconImageSource = "Home.png" });
            this.Children.Add(new ProductDetailsPage());
            this.Children.Add(new AddCardPage());
            this.Children.Add(new ShippingPage());
        }
    }
}