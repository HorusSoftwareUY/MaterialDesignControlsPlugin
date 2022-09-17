using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Xamarin.Forms;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        public delegate Task DisplayAlertType(string title, string message, string cancel);

        public DisplayAlertType DisplayAlert { get; set; }

        public INavigation Navigation { get; set; }
    }
}