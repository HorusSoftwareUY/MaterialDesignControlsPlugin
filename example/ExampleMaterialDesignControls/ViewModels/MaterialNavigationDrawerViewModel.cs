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
                    SelectedIcon = "checkbox_checked.png",
                    Text = "Opt1",
                    BadgeText = "999+",
                    UnselectedIcon = "checkbox_disabledUnchecked.png"
                },
                new MaterialNavigationDrawerItem
                {
                    SelectedIcon = "checkbox_checked.png",
                    Text = "Opt2",
                },
                new MaterialNavigationDrawerItem
                {
                    SelectedIcon = "checkbox_checked.png",
                    Text = "Opt3",
                },
                 new MaterialNavigationDrawerItem
                {
                    SelectedIcon = "checkbox_checked.png",
                    Text = "Opt4",
                    Section = "Second",
                    BadgeText = "999+",
                    UnselectedIcon = "checkbox_disabledUnchecked.png"
                },
                new MaterialNavigationDrawerItem
                {
                    SelectedIcon = "checkbox_checked.png",
                    Section = "Second",
                    Text = "Opt5",
                },
                new MaterialNavigationDrawerItem
                {
                    SelectedIcon = "checkbox_checked.png",
                    Section = "Third",
                    Text = "Opt6",
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
