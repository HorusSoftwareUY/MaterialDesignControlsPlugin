using Plugin.MaterialDesignControls.Objects;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class MaterialSegmentedViewModel : BaseViewModel
    {
        private MaterialSegmentedObject _selectedItem;
        public MaterialSegmentedObject SelectedItem
        {
            get => _selectedItem;
            set => SetProperty(ref _selectedItem, value);
        }

        private MaterialSegmentedObject _selectedItem3;
        public MaterialSegmentedObject SelectedItem3
        {
            get => _selectedItem3;
            set => SetProperty(ref _selectedItem3, value);
        }

        private ObservableCollection<MaterialSegmentedObject> _items;

        public ObservableCollection<MaterialSegmentedObject> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        private ObservableCollection<MaterialSegmentedObject> _items2;

        public ObservableCollection<MaterialSegmentedObject> Items2
        {
            get { return _items2; }
            set { SetProperty(ref _items2, value); }
        }


        private ObservableCollection<MaterialSegmentedObject> _items3;

        public ObservableCollection<MaterialSegmentedObject> Items3
        {
            get { return _items3; }
            set { SetProperty(ref _items3, value); }
        }

        private ObservableCollection<MaterialSegmentedObject> _items4;

        public ObservableCollection<MaterialSegmentedObject> Items4
        {
            get { return _items4; }
            set { SetProperty(ref _items4, value); }
        }

        private ObservableCollection<MaterialSegmentedObject> _sizes;

        public ObservableCollection<MaterialSegmentedObject> Sizes
        {
            get { return _sizes; }
            set { SetProperty(ref _sizes, value); }
        }

        private ObservableCollection<MaterialSegmentedObject> frecuently;
        public ObservableCollection<MaterialSegmentedObject> Frecuently
        {
            get { return frecuently; }
            set { SetProperty(ref frecuently, value); }
        }

        public MaterialSegmentedViewModel()
        {
            Items = new ObservableCollection<MaterialSegmentedObject> 
            {
                new MaterialSegmentedObject
                {
                    Text = "Opt1",
                    IsSelected = true,
                },
                new MaterialSegmentedObject
                {
                    Text = "Opt2",
                },
                new MaterialSegmentedObject
                {
                    Text = "Opt3",
                }
            };

            Items2 = new ObservableCollection<MaterialSegmentedObject>
            {
                new MaterialSegmentedObject
                {
                    Text = "Opt1",
                },
                new MaterialSegmentedObject
                {
                    Text = "Opt2",
                },
                new MaterialSegmentedObject
                {
                    Text = "Opt3",
                }
            };


            Items3 = new ObservableCollection<MaterialSegmentedObject>
            {
                new MaterialSegmentedObject
                {
                    Text = "Opt1",
                    SelectedIcon = "email.png",
                    UnselectedIcon = "Cross.png"
                },
                new MaterialSegmentedObject
                {
                    Text = "Opt2",
                    SelectedIcon = "checkbox_checked.png",
                },
                new MaterialSegmentedObject
                {
                    Text = "Opt3",
                    SelectedIcon = "Cross.png"
                }
            };

            Items4 = new ObservableCollection<MaterialSegmentedObject>
            {
                new MaterialSegmentedObject
                {
                    Text = "Opt1",
                    SelectedIcon = "checkbox_checked.png",
                    UnselectedIcon = "checkbox_disabledUnchecked.png"
                },
                new MaterialSegmentedObject
                {
                    Text = "Opt2",
                    SelectedIcon = "checkbox_checked.png",
                    UnselectedIcon = "checkbox_disabledUnchecked.png"
                },
                new MaterialSegmentedObject
                {
                    Text = "Opt3",
                    SelectedIcon = "checkbox_checked.png",
                    IsSelected = true,
                }
            };


            Sizes = new ObservableCollection<MaterialSegmentedObject> 
            {
                new MaterialSegmentedObject
                {
                    Text = "XS"
                },
                new MaterialSegmentedObject
                {
                    Text = "S"
                },
                new MaterialSegmentedObject
                {
                    Text = "M",
                    IsSelected = true,
                },
                new MaterialSegmentedObject
                {
                    Text = "L"
                },
                new MaterialSegmentedObject
                {
                    Text = "XL"
                }
            };

            Frecuently = new ObservableCollection<MaterialSegmentedObject>()
            {
                new MaterialSegmentedObject
                {
                    Text = "Daily"
                },
                new MaterialSegmentedObject
                {
                    Text = "Weekly"
                },
                new MaterialSegmentedObject
                {
                    Text = "Monthly",
                },
                new MaterialSegmentedObject
                {
                    Text = "Yearly"
                }
            };

            SelectedItem = Frecuently.First();

        }

        public ICommand SaveCommand => new Command(async () =>
        {
            Console.WriteLine(true);
            await this.DisplayAlert.Invoke("Frecuently", $"Selected item: {SelectedItem}", "Ok");
        });

        public ICommand SelectCommand => new Command(async () =>
        {
            await this.DisplayAlert.Invoke("Size", $"Selected command: {SelectedItem3}", "Ok");
        });
    }
}
