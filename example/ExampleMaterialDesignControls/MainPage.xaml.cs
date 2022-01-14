using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
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

            //masterPage.ListView.ItemSelected += OnItemSelected;
        }

        //void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        //{
        //    var item = e.SelectedItem as MasterPageItem;
        //    if (item != null)
        //    {
        //        Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
        //        masterPage.ListView.SelectedItem = null;
        //        IsPresented = false;
        //    }
        //}
    }
}
