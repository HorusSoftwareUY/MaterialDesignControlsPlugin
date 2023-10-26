﻿using Plugin.MaterialDesignControls.Material3;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class MaterialSegmentedViewModel : BaseViewModel
    {
        private MaterialSegmentedItem _selectedItem;
        public MaterialSegmentedItem SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        private MaterialSegmentedItem _selectedItem3;
        public MaterialSegmentedItem SelectedItem3
        {
            get => _selectedItem3;
            set => SetProperty(ref _selectedItem3, value);
        }

        private MaterialSegmentedItem _selectedItem5;
        public MaterialSegmentedItem SelectedItem5
        {
            get => _selectedItem5;
            set => SetProperty(ref _selectedItem5, value);
        }

        private ObservableCollection<MaterialSegmentedItem> _items0;

        public ObservableCollection<MaterialSegmentedItem> Items0
        {
            get { return _items0; }
            set { SetProperty(ref _items0, value); }
        }

        private ObservableCollection<MaterialSegmentedItem> _items1;

        public ObservableCollection<MaterialSegmentedItem> Items1
        {
            get { return _items1; }
            set { SetProperty(ref _items1, value); }
        }

        private ObservableCollection<MaterialSegmentedItem> _items;

        public ObservableCollection<MaterialSegmentedItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        private ObservableCollection<MaterialSegmentedItem> _items2;

        public ObservableCollection<MaterialSegmentedItem> Items2
        {
            get { return _items2; }
            set { SetProperty(ref _items2, value); }
        }


        private ObservableCollection<MaterialSegmentedItem> _items3;

        public ObservableCollection<MaterialSegmentedItem> Items3
        {
            get { return _items3; }
            set { SetProperty(ref _items3, value); }
        }

        private ObservableCollection<MaterialSegmentedItem> _items4;

        public ObservableCollection<MaterialSegmentedItem> Items4
        {
            get { return _items4; }
            set { SetProperty(ref _items4, value); }
        }

        private ObservableCollection<MaterialSegmentedItem> _sizes;

        public ObservableCollection<MaterialSegmentedItem> Sizes
        {
            get { return _sizes; }
            set { SetProperty(ref _sizes, value); }
        }

        private ObservableCollection<MaterialSegmentedItem> frecuently;
        public ObservableCollection<MaterialSegmentedItem> Frecuently
        {
            get { return frecuently; }
            set { SetProperty(ref frecuently, value); }
        }

        private ObservableCollection<MaterialSegmentedItem> _items5;

        public ObservableCollection<MaterialSegmentedItem> Items5
        {
            get { return _items5; }
            set { SetProperty(ref _items5, value); }
        }

        public MaterialSegmentedViewModel()
        {
            Items = new ObservableCollection<MaterialSegmentedItem> 
            {
                new MaterialSegmentedItem
                {
                    Text = "Opt1",
                    IsSelected = true,
                },
                new MaterialSegmentedItem
                {
                    Text = "Opt2",
                },
                new MaterialSegmentedItem
                {
                    Text = "Opt3",
                }
            };

            Items0 = new ObservableCollection<MaterialSegmentedItem>(Items.Take(1));
            Items1 = new ObservableCollection<MaterialSegmentedItem>(Items.Take(2));
            
            Items2 = new ObservableCollection<MaterialSegmentedItem>
            {
                new MaterialSegmentedItem
                {
                    Text = "Opt1",
                },
                new MaterialSegmentedItem
                {
                    Text = "Opt2",
                },
                new MaterialSegmentedItem
                {
                    Text = "Opt3",
                }
            };


            Items3 = new ObservableCollection<MaterialSegmentedItem>
            {
                new MaterialSegmentedItem
                {
                    Text = "Opt1",
                    SelectedIcon = "email.png",
                    UnselectedIcon = "Cross.png"
                },
                new MaterialSegmentedItem
                {
                    Text = "Opt2",
                    SelectedIcon = "checkbox_checked.png",
                },
                new MaterialSegmentedItem
                {
                    Text = "Opt3",
                    SelectedIcon = "Cross.png"
                }
            };

            Items4 = new ObservableCollection<MaterialSegmentedItem>
            {
                new MaterialSegmentedItem
                {
                    Text = "Opt1",
                    SelectedIcon = "checkbox_checked.png",
                    UnselectedIcon = "checkbox_disabledUnchecked.png"
                },
                new MaterialSegmentedItem
                {
                    Text = "Opt2",
                    SelectedIcon = "checkbox_checked.png",
                    UnselectedIcon = "checkbox_disabledUnchecked.png"
                },
                new MaterialSegmentedItem
                {
                    Text = "Opt3",
                    SelectedIcon = "checkbox_checked.png",
                    IsSelected = true,
                }
            };


            Sizes = new ObservableCollection<MaterialSegmentedItem> 
            {
                new MaterialSegmentedItem
                {
                    Text = "XS"
                },
                new MaterialSegmentedItem
                {
                    Text = "S"
                },
                new MaterialSegmentedItem
                {
                    Text = "M",
                    IsSelected = true,
                },
                new MaterialSegmentedItem
                {
                    Text = "L"
                },
                new MaterialSegmentedItem
                {
                    Text = "XL"
                }
            };

            Frecuently = new ObservableCollection<MaterialSegmentedItem>()
            {
                new MaterialSegmentedItem
                {
                    Text = "Daily"
                },
                new MaterialSegmentedItem
                {
                    Text = "Weekly"
                },
                new MaterialSegmentedItem
                {
                    Text = "Monthly",
                },
                new MaterialSegmentedItem
                {
                    Text = "Yearly"
                }
            };

            SelectedItem = Frecuently.First();


            Items5 = new ObservableCollection<MaterialSegmentedItem>
            {
                new MaterialSegmentedItem
                {
                    Text = "Opt1",
                    SelectedIcon = "checkbox_checked.png",
                    UnselectedIcon = "checkbox_disabledUnchecked.png"
                },
                new MaterialSegmentedItem
                {
                    Text = "Opt2",
                    SelectedIcon = "checkbox_checked.png",
                    UnselectedIcon = "checkbox_disabledUnchecked.png"
                },
                new MaterialSegmentedItem
                {
                    Text = "Opt3",
                    SelectedIcon = "checkbox_checked.png",
                    IsSelected = true,
                }
            };

            SelectedItem5 = Items5.Where(i => i.IsSelected).Last();
        }

        public ICommand SaveCommand => new Command(async () =>
        {
            await this.DisplayAlert.Invoke("Frecuently", $"Selected item: {SelectedItem}", "Ok");
        });

        public ICommand SelectCommand => new Command(async () =>
        {
            await this.DisplayAlert.Invoke("Size", $"Selected command: {SelectedItem3}", "Ok");
        });

        public ICommand SelectItem5Command => new Command(async () =>
        {
            await this.DisplayAlert.Invoke("Option", $"Selected command: {string.Join("; ", Items5.Where(i => i.IsSelected).Select(i => i.Text))}", "Ok");
        });
    }
}
