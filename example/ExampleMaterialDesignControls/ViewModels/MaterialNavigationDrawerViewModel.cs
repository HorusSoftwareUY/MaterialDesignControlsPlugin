using FFImageLoading.Svg.Forms;
using Plugin.MaterialDesignControls.Objects;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class MaterialNavigationDrawerViewModel : BaseViewModel
    {
        private ObservableCollection<MaterialNavigationDrawerItem> _items;

        public ObservableCollection<MaterialNavigationDrawerItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public MaterialNavigationDrawerViewModel()
        {
            Items = new ObservableCollection<MaterialNavigationDrawerItem>
            {
                new MaterialNavigationDrawerItem
                {
                    SelectedIcon = "email.png",
                    UnselectedIcon = "email.png",
                    Text = "Inbox",
                    BadgeText = "24"
                },
                new MaterialNavigationDrawerItem
                {
                    SelectedIcon = "email.png",
                    UnselectedIcon = "email.png",
                    Text = "Outbox",
                    BadgeText = "100+"
                },
                new MaterialNavigationDrawerItem
                {
                    Text = "Favorites (Different icons)",
                    SelectedIcon = "starSelected.png",
                    UnselectedIcon = "starUnselected.png",
                },
                new MaterialNavigationDrawerItem
                {
                    SelectedIcon = "delete.png",
                    UnselectedIcon = "delete.png",
                    Text = "Trash",
                },
                new MaterialNavigationDrawerItem
                {
                    Section = "Other samples",
                    SelectedIcon = "Payment.png",
                    UnselectedIcon = "Payment.png",
                    Text = "Selected by default",
                    IsSelected = true
                },
                new MaterialNavigationDrawerItem
                {
                    Section = "Other samples",
                    SelectedIcon = "Payment.png",
                    UnselectedIcon = "Payment.png",
                    Text = "Disabled",
                    IsEnabled = false
                },
                new MaterialNavigationDrawerItem
                {
                    Section = "Other samples",
                    SelectedIcon = "Payment.png",
                    UnselectedIcon = "Payment.png",
                    Text = "Don't show active indicator",
                    ShowActiveIndicator = false
                },
                new MaterialNavigationDrawerItem
                {
                    Section = "Other samples",
                    CustomSelectedIcon = new FFImageLoading.Svg.Forms.SvgCachedImage { Source = "resource://ExampleMaterialDesignControls.Resources.Svg.volume_blue.svg" },
                    CustomUnselectedIcon = new FFImageLoading.Svg.Forms.SvgCachedImage { Source = "resource://ExampleMaterialDesignControls.Resources.Svg.volume.svg" },
                    Text = "Custom icon",
                },
                new MaterialNavigationDrawerItem
                {
                    Section = "Other samples",
                    Text = "Without icon",
                }
            };
        }

        public ICommand TestCommand => new Command(async (obj) =>
        {
            await this.DisplayAlert.Invoke("Navigation Item", $"{obj}", "Ok");
        });
    }
}