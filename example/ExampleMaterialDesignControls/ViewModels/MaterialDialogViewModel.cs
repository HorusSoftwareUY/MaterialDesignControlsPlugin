using System.Collections.ObjectModel;

namespace ExampleMaterialDesignControls.ViewModels
{
    public class MaterialDialogViewModel : BaseViewModel
    {
        private ObservableCollection<string> rigtones;
        public ObservableCollection<string> Rigtones
        {
            get { return rigtones; }
            set { SetProperty(ref rigtones, value); }
        }

        public MaterialDialogViewModel()
        {
            this.Rigtones = new ObservableCollection<string> { "Callisto", "Ganymede", "Luna" };
        }
    }
}
