using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Material3
{
    public class MaterialNavigationDrawerItem
    {
        public string Text { get; set; }

        public string BadgeText { get; set; }

        public string Section { get; set; }

        public string SelectedLeadingIcon { get; set; }

        public View CustomSelectedLeadingIcon { get; set; }

        public string UnselectedLeadingIcon { get; set; }

        public View CustomUnselectedLeadingIcon { get; set; }

        public string SelectedTrailingIcon { get; set; }

        public View CustomSelectedTrailingIcon { get; set; }

        public string UnselectedTrailingIcon { get; set; }

        public View CustomUnselectedTrailingIcon { get; set; }

        public bool IsSelected { get; set; }

        public bool ShowActiveIndicator { get; set; } = true;

        public bool IsEnabled { get; set; } = true;

        internal bool UnselectedLeadingIconIsVisible
        {
            get { return !string.IsNullOrEmpty(UnselectedLeadingIcon) || CustomUnselectedLeadingIcon != null; }
        }

        internal bool SelectedLeadingIconIsVisible
        {
            get { return !string.IsNullOrEmpty(SelectedLeadingIcon) || CustomSelectedLeadingIcon != null; }
        }

        internal bool UnselectedTrailingIconIsVisible
        {
            get { return !string.IsNullOrEmpty(UnselectedTrailingIcon) || CustomUnselectedTrailingIcon != null; }
        }

        internal bool SelectedTrailingIconIsVisible
        {
            get { return !string.IsNullOrEmpty(SelectedTrailingIcon) || CustomSelectedTrailingIcon != null; }
        }

        public override bool Equals(object obj)
        {
            if (obj is not MaterialNavigationDrawerItem toCompare)
                return false;
            else
            {
                var key = this.Section + "-" + this.Text;
                var keyToCompare = toCompare.Section + "-" + toCompare.Text;
                return key.Equals(keyToCompare, System.StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public override string ToString() =>
            string.IsNullOrWhiteSpace(Text) ? "No defined text" : Text;
    }
}