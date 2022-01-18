using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class ProductDetailsViewModel : BaseViewModel
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

        private ObservableCollection<string> colors;

        public ObservableCollection<string> Colors
        {
            get { return colors; }
            set { SetProperty(ref colors, value); }
        }

        private List<string> selectedColors;

        public List<string> SelectedColors
        {
            get { return selectedColors; }
            set { SetProperty(ref selectedColors, value); }
        }

        private bool isColorSelectionEnabled;

        public bool IsColorSelectionEnabled
        {
            get { return isColorSelectionEnabled; }
            set { SetProperty(ref isColorSelectionEnabled, value); }
        }

        private string error;

        public string Error
        {
            get { return error; }
            set
            {
                error = value;
                OnPropertyChanged();
            }
        }

        private bool isChipIconVisible;

        public bool IsChipIconVisible
        {
            get { return isChipIconVisible; }
            set { SetProperty(ref isChipIconVisible, value); }
        }

        public delegate Task DisplayAlertType(string title, string message, string cancel);

        public DisplayAlertType DisplayAlert { get; set; }

        public ICommand TapCommand => new Command(OnTapCommand);
        public ICommand IconTapCommand => new Command<string>(OnIconTapCommand);

        private void OnIconTapCommand(string obj)
        {
            this.DisplayAlert("Chip icon command", obj, "Ok");
        }

        public ProductDetailsViewModel()
        {
            Items = new ObservableCollection<Item>();
            Items.Add(new Item("Test 1", new Command(() => {
                Items.RemoveAt(0);
            })));
            Items.Add(new Item("Test 2", new Command(() => {
                Items.RemoveAt(0);
            })));

            this.Sizes = new ObservableCollection<string> { "6", "6.5", "7", "7.5", "8" };

            this.Colors = new ObservableCollection<string> { "Red", "White", "Green", "Sky blue", "Black", "Gray", "Light Gray" };
        }

        private async void OnTapCommand()
        {
            if (!string.IsNullOrEmpty(this.SelectedSizes))
            {
                this.Error = null;
                var colors = SelectedColors != null ? string.Join(", ", SelectedColors) : string.Empty;
                await this.DisplayAlert.Invoke("Saved", $"Size: {SelectedSizes} - Colors: {colors}", "Ok");
            }
            else
            {
                this.Error = "The size is required";
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