using Microsoft.Toolkit.Mvvm.Input;
using Plugin.MaterialDesignControls.Material3;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace ExampleMaterialDesignControls.ViewModels
{
    public partial class MaterialNavigationDrawerViewModel : BaseViewModel
    {
        private bool _includeAllItems = true;

        private ObservableCollection<MaterialNavigationDrawerItem> _items;

        public ObservableCollection<MaterialNavigationDrawerItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        public MaterialNavigationDrawerViewModel()
        {
            LoadItems(_includeAllItems);
        }

        private void LoadItems(bool includeAllItems)
        {
            var list = new List<MaterialNavigationDrawerItem>
            {
                new MaterialNavigationDrawerItem
                {
                    SelectedLeadingIcon = "email.png",
                    UnselectedLeadingIcon = "email.png",
                    SelectedTrailingIcon = "arrow_drop_down.png",
                    UnselectedTrailingIcon = "arrow_drop_down.png",
                    Text = "Inbox",
                    BadgeText = "24"
                },
                new MaterialNavigationDrawerItem
                {
                    SelectedLeadingIcon = "email.png",
                    UnselectedLeadingIcon = "email.png",
                    Text = "Outbox",
                    BadgeText = "100+"
                },
                new MaterialNavigationDrawerItem
                {
                    Text = "Favorites (Different icons)",
                    SelectedLeadingIcon = "starSelected.png",
                    UnselectedLeadingIcon = "starUnselected.png",
                },
                new MaterialNavigationDrawerItem
                {
                    SelectedLeadingIcon = "delete.png",
                    UnselectedLeadingIcon = "delete.png",
                    Text = "Trash",
                },
                new MaterialNavigationDrawerItem
                {
                    Section = "Other samples",
                    SelectedLeadingIcon = "Payment.png",
                    UnselectedLeadingIcon = "Payment.png",
                    Text = "Selected by default",
                    IsSelected = true
                },
                
            };

            if (includeAllItems)
            {
                list.AddRange(new List<MaterialNavigationDrawerItem>
                {
                    new MaterialNavigationDrawerItem
                    {
                        Section = "Other samples",
                        SelectedLeadingIcon = "Payment.png",
                        UnselectedLeadingIcon = "Payment.png",
                        Text = "Disabled",
                        IsEnabled = false
                    },
                    new MaterialNavigationDrawerItem
                    {
                        Section = "Other samples",
                        SelectedLeadingIcon = "Payment.png",
                        UnselectedLeadingIcon = "Payment.png",
                        Text = "Don't show active indicator",
                        ShowActiveIndicator = false
                    },
                    new MaterialNavigationDrawerItem
                    {
                        Section = "Other samples",
                        CustomSelectedLeadingIcon = new FFImageLoading.Svg.Forms.SvgCachedImage { Source = "resource://ExampleMaterialDesignControls.Resources.Svg.volume_blue.svg" },
                        CustomUnselectedLeadingIcon = new FFImageLoading.Svg.Forms.SvgCachedImage { Source = "resource://ExampleMaterialDesignControls.Resources.Svg.volume.svg" },
                        CustomSelectedTrailingIcon = new FFImageLoading.Svg.Forms.SvgCachedImage { Source = "resource://ExampleMaterialDesignControls.Resources.Svg.volume_blue.svg" },
                        CustomUnselectedTrailingIcon = new FFImageLoading.Svg.Forms.SvgCachedImage { Source = "resource://ExampleMaterialDesignControls.Resources.Svg.volume.svg" },
                        Text = "Custom icon",
                    },
                    new MaterialNavigationDrawerItem
                    {
                        Section = "Other samples",
                        Text = "Without icon",
                    }
                });
            }

            Items = new ObservableCollection<MaterialNavigationDrawerItem>(list);
        }

        [ICommand]
        private async Task Test(MaterialNavigationDrawerItem selectedItem)
        {
            await this.DisplayAlert.Invoke("Navigation Item", $"{selectedItem}", "Ok");
        }

        [ICommand]
        private async Task ChangeItemsSource()
        {
            _includeAllItems = !_includeAllItems;
            LoadItems(_includeAllItems);
        }
    }
}