using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Objects
{
    public class MaterialSegmentedItem
    {
        public string Text { get; set; }

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
            if (obj is not MaterialSegmentedItem toCompare)
            {
                return false;
            }


            return toCompare.Text.Equals(this.Text, System.StringComparison.InvariantCultureIgnoreCase);
        }

        public override string ToString() => !string.IsNullOrWhiteSpace(Text) ? Text : "Unavailable";
    }
}
