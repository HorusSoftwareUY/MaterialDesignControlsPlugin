using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.Input;

namespace ExampleMaterialDesignControls.ViewModels
{
	public partial class MaterialSearchViewModel : BaseViewModel
	{
        private ObservableCollection<ItemSearchSample> listStrings;

        public ObservableCollection<ItemSearchSample> ListStrings
        {
            get { return listStrings; }
            set
            {
                listStrings = value;
                OnPropertyChanged();
            }
        }

        private bool searchOnEveryTextChange;

        public bool SearchOnEveryTextChange
        {
            get { return searchOnEveryTextChange; }
            set { SetProperty(ref searchOnEveryTextChange, value); }
        }

        private string textSearch;

        public string TextSearch
        {
            get { return textSearch; }
            set { SetProperty(ref textSearch, value); }
        }

        public List<ItemSearchSample> listStringFull { get; set; }

        public MaterialSearchViewModel()
		{
            FillList();
		}

        private void FillList()
        {
            listStringFull = new List<ItemSearchSample>()
            {
                new ItemSearchSample(){ ValueString = "First" },
                new ItemSearchSample(){ ValueString = "Second" },
                new ItemSearchSample(){ ValueString = "Third" },
                new ItemSearchSample(){ ValueString = "Fourth" },
                new ItemSearchSample(){ ValueString = "Fifth" },
                new ItemSearchSample(){ ValueString = "Sixth" },
                new ItemSearchSample(){ ValueString = "Seventh" },
                new ItemSearchSample(){ ValueString = "Eighth" },
                new ItemSearchSample(){ ValueString = "Ninth" },
                new ItemSearchSample(){ ValueString = "Tenth" },
                new ItemSearchSample(){ ValueString = "Eleventh" },
                new ItemSearchSample(){ ValueString = "Twelfth" },
                new ItemSearchSample(){ ValueString = "Thirteenth" },
                new ItemSearchSample(){ ValueString = "Fourteenth" },
                new ItemSearchSample(){ ValueString = "Fifteenth" },
                new ItemSearchSample(){ ValueString = "Sixteenth" },
                new ItemSearchSample(){ ValueString = "Seventeenth" },
                new ItemSearchSample(){ ValueString = "Eighteenth" },
                new ItemSearchSample(){ ValueString = "Nineteenth" },
                new ItemSearchSample(){ ValueString = "Twentieth" },
            };
            ListStrings = new ObservableCollection<ItemSearchSample>(listStringFull);
        }

        // This could have a string parameter, or it might not have any parameter
        // Search(string param)
        // The string param is the TextProperty, taken directly from the control

        [ICommand]
        private async Task Search(object param)
        {
            ListStrings = new ObservableCollection<ItemSearchSample>(listStringFull.Where(x => x.ValueString.Contains(TextSearch)));
        }
    }
    public class ItemSearchSample
    {
        public string ValueString { get; set; }
    }
}

