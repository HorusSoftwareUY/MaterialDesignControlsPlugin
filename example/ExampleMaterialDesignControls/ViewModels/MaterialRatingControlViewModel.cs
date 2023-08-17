using Plugin.MaterialDesignControls.Objects;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class MaterialRatingControlViewModel : BaseViewModel
    {
        public int _value = 2;

        public int Value
        {
            get { return _value; }
            set
            {
                _value = value;
                OnPropertyChanged();
            }
        }

        public string error;
        public string Error
        {
            get { return error; }
            set
            {
                error = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _selectedIcons;

        public ObservableCollection<string> SelectedIcons
        {
            get { return _selectedIcons; }
            set { SetProperty(ref _selectedIcons, value); }
        }

        private ObservableCollection<DataTemplate> _unselectedIcons;

        public ObservableCollection<DataTemplate> UnselectedIcons
        {
            get { return _unselectedIcons; }
            set { SetProperty(ref _unselectedIcons, value); }
        }


        public MaterialRatingControlViewModel()
        {
            SelectedIcons = new ObservableCollection<string>
            {
                "checkbox_checked.png",
                "checkbox_checked.png",
                "starSelected.png",
            };

            UnselectedIcons = new ObservableCollection<DataTemplate>
            {
                new DataTemplate (() => new FFImageLoading.Svg.Forms.SvgCachedImage { Source = "resource://ExampleMaterialDesignControls.Resources.Svg.checkbox_unchecked.svg" }),
                new DataTemplate (() => new FFImageLoading.Svg.Forms.SvgCachedImage { Source = "resource://ExampleMaterialDesignControls.Resources.Svg.checkbox_unchecked.svg" }),
                new DataTemplate (() => new FFImageLoading.Svg.Forms.SvgCachedImage { Source = "resource://ExampleMaterialDesignControls.Resources.Svg.starUnselected.svg" }),
            };
        }

        public delegate Task DisplayAlertType(string title, string message, string cancel);

        public DisplayAlertType DisplayAlert { get; set; }

        public ICommand ClearCommand => new Command(() =>
        {
            Value = 0;
            Error = null;
        });

        public ICommand ShowCommand => new Command(async () =>
        {
            await DisplayAlert("Selected value", Value.ToString(), "Ok");

            Error = Value == 0 ? "Required field" : null;
        });
    }
}