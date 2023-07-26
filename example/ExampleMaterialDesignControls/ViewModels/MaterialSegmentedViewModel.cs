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
        private MaterialSegmentedObject selectedItem;
        public MaterialSegmentedObject SelectedItem
        {
            get => selectedItem;
            set => SetProperty(ref selectedItem, value);
        }

        //   private string selectedSize;
        //   public string SelectedSize
        //   { 
        //       get => selectedSize;
        //       set => SetProperty(ref selectedSize, value);
        //}

        private ObservableCollection<MaterialSegmentedObject> items;

        public ObservableCollection<MaterialSegmentedObject> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        private ObservableCollection<MaterialSegmentedObject> items2;

        public ObservableCollection<MaterialSegmentedObject> Items2
        {
            get { return items2; }
            set { SetProperty(ref items2, value); }
        }


        private ObservableCollection<MaterialSegmentedObject> items3;

        public ObservableCollection<MaterialSegmentedObject> Items3
        {
            get { return items3; }
            set { SetProperty(ref items3, value); }
        }

        private ObservableCollection<MaterialSegmentedObject> items4;

        public ObservableCollection<MaterialSegmentedObject> Items4
        {
            get { return items4; }
            set { SetProperty(ref items4, value); }
        }

        private ObservableCollection<MaterialSegmentedObject> sizes;

        public ObservableCollection<MaterialSegmentedObject> Sizes
        {
            get { return sizes; }
            set { SetProperty(ref sizes, value); }
        }

        private ObservableCollection<string> onOff;
        public ObservableCollection<string> OnOff
        {
            get { return onOff; }
            set { SetProperty(ref onOff, value); }
        }

        private ObservableCollection<string> backlight;
        public ObservableCollection<string> Backlight
        {
            get { return backlight; }
            set { SetProperty(ref backlight, value); }
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
            //await this.DisplayAlert.Invoke("Size", $"Selected command: {SelectedSize}", "Ok");
        });
    }
}
