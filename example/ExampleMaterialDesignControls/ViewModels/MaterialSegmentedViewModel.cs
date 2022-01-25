using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class MaterialSegmentedViewModel : BaseViewModel
    { 
        private string selectedItem;
        public string SelectedItem
        { 
            get => selectedItem;
            set => SetProperty(ref selectedItem, value);
	    }

        private string selectedSize;
        public string SelectedSize
        { 
            get => selectedSize;
            set => SetProperty(ref selectedSize, value);
	    }

        private ObservableCollection<string> items;

        public ObservableCollection<string> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        private ObservableCollection<string> items2;

        public ObservableCollection<string> Items2
        {
            get { return items2; }
            set { SetProperty(ref items2, value); }
        }

        private ObservableCollection<string> sizes;

        public ObservableCollection<string> Sizes
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

        private ObservableCollection<string> frecuently;
        public ObservableCollection<string> Frecuently
        {
            get { return frecuently; }
            set { SetProperty(ref frecuently, value); }
        }

        public MaterialSegmentedViewModel()
        {
            Items = new ObservableCollection<string> { "Complete","Incomplete","Pending"};
            SelectedItem = "Complete";
            Items2 = new ObservableCollection<string> { "Music", "Photos", "Movies", "Apps" };
            Sizes = new ObservableCollection<string> { "XS","S","M","L","XL"};
            OnOff = new ObservableCollection<string> { "Off","On"};
            Backlight = new ObservableCollection<string> { "Backlight On","Backlight Off"};
            Frecuently = new ObservableCollection<string> { "Day","Week","Month"};
        }

        public ICommand SaveCommand => new Command( async()=>
        {
            await this.DisplayAlert.Invoke("Size", $"Selected item: {SelectedItem}", "Ok");
        });

        public ICommand SelectCommand => new Command( async ()=>
        {
            await this.DisplayAlert.Invoke("Size", $"Selected command: {SelectedSize}", "Ok");
        });
    }
}
