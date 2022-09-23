using Xamarin.Essentials;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.Pages
{
    public partial class InfoPage : ContentPage
    {
        public InfoPage()
        {
            InitializeComponent();
        }

        public void ContactUsButton_Clicked(System.Object sender, System.EventArgs e)
        {
            _ = Browser.OpenAsync("https://horus.com.uy/contact", BrowserLaunchMode.SystemPreferred);
        }
    }
}