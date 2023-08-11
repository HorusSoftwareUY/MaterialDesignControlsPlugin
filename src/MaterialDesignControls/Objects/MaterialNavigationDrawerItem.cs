using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Objects
{
    public class MaterialNavigationDrawerItem
    {
        public string Text { get; set; }

        public string BadgeText { get; set; }

        public string Section { get; set; }

        public string SelectedIcon { get; set; }

        public View CustomSelectedIcon { get; set; }

        public string UnselectedIcon { get; set; }

        public View CustomUnselectedIcon { get; set; }

        public bool IsSelected { get; set; }

        public bool UnselectedIconIsVisible
        {
            get { return !string.IsNullOrEmpty(UnselectedIcon) || CustomUnselectedIcon != null; }
        }

        public bool SelectedIconIsVisible
        {
            get { return !string.IsNullOrEmpty(SelectedIcon) || CustomSelectedIcon != null; }
        }

        public override bool Equals(object obj)
        {
            if (obj is not MaterialNavigationDrawerItem toCompare)
            {
                return false;
            }

            var key = this.Section + "-" + this.Text;
            var keyToCompare = toCompare.Section + "-" + toCompare.Text;

            return key.Equals(keyToCompare, System.StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
