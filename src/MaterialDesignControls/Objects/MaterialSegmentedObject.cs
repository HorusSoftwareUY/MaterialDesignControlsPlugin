using Xamarin.Forms;

namespace Plugin.MaterialDesignControls.Objects
{
    public class MaterialSegmentedObject
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
            if (obj is not MaterialSegmentedObject toCompare)
            {
                return false;
            }


            return toCompare.Text.Equals(this.Text, System.StringComparison.InvariantCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            if (!string.IsNullOrWhiteSpace(Text))
            {
                hashCode += Text.GetHashCode();
            }

            if (!string.IsNullOrWhiteSpace(SelectedIcon))
            {
                hashCode += SelectedIcon.GetHashCode();
            }

            if (!string.IsNullOrWhiteSpace(UnselectedIcon))
            {
                hashCode += UnselectedIcon.GetHashCode();
            }

            if (CustomSelectedIcon != null)
            {
                hashCode += CustomSelectedIcon.GetHashCode();
            }

            if (CustomUnselectedIcon != null)
            {
                hashCode += CustomUnselectedIcon.GetHashCode();
            }

            return hashCode;
        }

        public override string ToString() => !string.IsNullOrWhiteSpace(Text) ? Text : "Unavailable";
    }
}
