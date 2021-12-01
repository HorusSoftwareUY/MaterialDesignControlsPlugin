using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class MaterialRadioButtonsViewModel: BaseViewModel
    {
        private ObservableCollection<string> sizes;
        public ObservableCollection<string> Sizes
        {
            get { return sizes; }
            set { SetProperty(ref sizes, value); }
        }

        private ObservableCollection<string> rigtones;
        public ObservableCollection<string> Rigtones
        {
            get { return rigtones; }
            set { SetProperty(ref rigtones, value); }
        }

        private ObservableCollection<string> places;
        public ObservableCollection<string> Places
        {
            get { return places; }
            set { SetProperty(ref places, value); }
        }

        public MaterialRadioButtonsViewModel()
        {
            this.Sizes = new ObservableCollection<string> { "6", "6.5", "7", "7.5", "8" };
            this.Rigtones = new ObservableCollection<string> {"Callisto","Ganymede","Luna"};
            this.Places = new ObservableCollection<string> {"Home","Work","House"};
        }

        private string selectedSize;
        public string SelectedSize
        {
            get { return selectedSize; }
            set { SetProperty(ref selectedSize, value); }
	    }

        private string selectedRigtone;
        public string SelectedRigtone
        {
            get { return selectedRigtone; }
            set { SetProperty(ref selectedRigtone, value); }
	    }

        private string selectedPlace;
        public string SelectedPlace
        {
            get { return selectedPlace; }
            set { SetProperty(ref selectedPlace, value); }
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

        public ICommand SaveSizeCommand => new Command(OnSaveCommand);
        private async void OnSaveCommand()
        {
            if (!string.IsNullOrEmpty(this.SelectedSize))
            {
                this.Error = null;
                await this.DisplayAlert.Invoke("Saved", $"Size: {SelectedSize}", "Ok");
            }
            else
            {
                this.Error = "The size is required";
            }
        }

    }
}
