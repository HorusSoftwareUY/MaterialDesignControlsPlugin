
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugin.MaterialDesignControls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaterialSlider : ContentView
    {
        #region constructors
        public MaterialSlider()
        {
            InitializeComponent();
        }
        #endregion constructors

        #region attributes
        #endregion attributes

        #region properties
        public event EventHandler OnChangeSlider;
        #endregion properties

        #region methods
        public void ExecuteChanged()
        {
            OnChangeSlider?.Invoke(this, null);
        }
        #endregion methods
    }
}