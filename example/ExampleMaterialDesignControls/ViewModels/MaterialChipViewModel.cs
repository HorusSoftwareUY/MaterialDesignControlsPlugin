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

        private string error;

        public string Error
        {
            get { return error; }
            set { SetProperty(ref error, value); }
        }

        public delegate Task DisplayAlertType(string title, string message, string cancel);

        public DisplayAlertType DisplayAlert { get; set; }

        public ICommand TapCommand => new Command(OnTapCommand);

        public ICommand UnselectedCommand => new Command(OnUnselectedCommand);
        public ICommand IconTapCommand => new Command<string>(OnIconTapCommand);

        private void OnIconTapCommand(string obj)
        {
            this.DisplayAlert("Chip icon command", obj, "Ok");
        }


        public MaterialChipViewModel()
        {
            this.Sizes = new ObservableCollection<string> { "P", "M", "X", "XL" };
        }

        private async void OnTapCommand()
        {
            if (!string.IsNullOrEmpty(this.SelectedSizes))
            {
                this.Error = null;
                await this.DisplayAlert.Invoke("", "Saved", "Ok");
            }
            else
            {
                this.Error = "The size is required";
            }
        }

        private async void OnUnselectedCommand()
        {
            await this.DisplayAlert.Invoke("", "Unselected", "Ok");
        }
    }

    public class Item
    {
        public string Name { get; set; }
        public ICommand TapCommand { get; set; }
        public ICommand UnselectedCommand { get; set; }

        public Item(string name, ICommand cmd, ICommand unselectedCmd)
        {
            this.Name = name;
            this.TapCommand = cmd;
            this.UnselectedCommand = unselectedCmd;
        }
    }
}
