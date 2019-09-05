using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class MaterialChipViewModel : BaseViewModel
    {
        private ObservableCollection<Item> items;

        public ObservableCollection<Item> Items
        {
            get { return items; }
            set { SetProperty(ref items, value); }
        }

        private ObservableCollection<string> sizes;

        public ObservableCollection<string> Sizes
        {
            get { return sizes; }
            set { SetProperty(ref sizes, value); }
        }

        private string selectedSizes;

        public string SelectedSizes
        {
            get { return selectedSizes; }
            set { SetProperty(ref selectedSizes, value); }
        }

        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string nameError;

        public string NameError
        {
            get { return nameError; }
            set { SetProperty(ref nameError, value); }
        }

        public delegate Task DisplayAlertType(string title, string message, string cancel);

        public DisplayAlertType DisplayAlert { get; set; }

        public ICommand TapCommand => new Command(OnTapCommand);
        public ICommand IconTapCommand => new Command<string>(OnIconTapCommand);

        private void OnIconTapCommand(string obj)
        {
            this.DisplayAlert("Chip icon command", obj, "Ok");
        }

        public MaterialChipViewModel()
        {
            Items = new ObservableCollection<Item>();
            Items.Add(new Item("Test 1", new Command(() => {
                Items.RemoveAt(0);
            })));
            Items.Add(new Item("Test 2", new Command(() => {
                Items.RemoveAt(0);
            })));

            this.Sizes = new ObservableCollection<string> { "P", "M", "X", "XL" };
            this.SelectedSizes = "M";
        }

        private async void OnTapCommand()
        {
            if (!string.IsNullOrEmpty(this.Name))
            {
                this.NameError = null;
                await this.DisplayAlert.Invoke("", "Saved", "Ok");
            }
            else
            {
                this.NameError = "The message is required";
            }
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public ICommand TapCommand { get; set; }

        public Item(string name, ICommand cmd)
        {
            this.Name = name;
            this.TapCommand = cmd;
        }
    }
}
