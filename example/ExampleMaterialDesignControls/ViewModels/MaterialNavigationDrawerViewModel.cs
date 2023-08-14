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
                    Text = "Outbox",
                    IsEnabled = false
                },
                new MaterialNavigationDrawerItem
                {
                    Text = "Favorites",
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
                    Section = "Personal folders",
                    SelectedIcon = "Payment.png",
                    UnselectedIcon = "Payment.png",
                    Text = "Family",
                },
                new MaterialNavigationDrawerItem
                {
                    Section = "Personal folders",
                    SelectedIcon = "Payment.png",
                    UnselectedIcon = "Payment.png",
                    Text = "Wedding",
                    ShowActivityIndicator = false
                }
            };
        }

        public ICommand TestCommand => new Command(async (obj) =>
        {
            await this.DisplayAlert.Invoke("Navigation Item", $"{obj}", "Ok");
        });

    }
}
