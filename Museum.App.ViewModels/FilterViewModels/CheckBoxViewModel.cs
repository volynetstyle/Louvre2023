using System;

namespace Museum.App.ViewModels.FilterViewModels
{
    public class CheckboxViewModel
    {
        public int Box_ID { get; set; }
        public string? Label { get; set; }
        public int Count { get; set; }
        public bool IsChecked { get; set; } = false;

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            CheckboxViewModel other = (CheckboxViewModel)obj;

            return Box_ID == other.Box_ID
                && Label == other.Label
                && Count == other.Count
                && IsChecked == other.IsChecked;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Box_ID.GetHashCode();
                hash = hash * 23 + (Label != null ? Label.GetHashCode() : 0);
                hash = hash * 23 + Count.GetHashCode();
                hash = hash * 23 + IsChecked.GetHashCode();
                return hash;
            }
        }
    }
}
