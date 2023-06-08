using System;
using System.Collections.Generic;

namespace Museum.App.ViewModels.FilterViewModels
{
    public class SideBarCollection
    {
        public string? Title { get; set; }
        public IEnumerable<CheckboxViewModel>? Collection { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            SideBarCollection other = (SideBarCollection)obj;

            return Title == other.Title
                && AreCollectionsEqual(Collection, other.Collection);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + (Title != null ? Title.GetHashCode() : 0);
                hash = hash * 23 + (Collection != null ? GetEnumerableHashCode(Collection) : 0);
                return hash;
            }
        }

        private bool AreCollectionsEqual(IEnumerable<CheckboxViewModel>? collection1, 
                                         IEnumerable<CheckboxViewModel>? collection2)
        {
            if (collection1 == null && collection2 == null)
            {
                return true;
            }

            if (collection1 == null || collection2 == null || collection1.Count() != collection2.Count())
            {
                return false;
            }

            var enumerator1 = collection1.GetEnumerator();
            var enumerator2 = collection2.GetEnumerator();

            while (enumerator1.MoveNext() && enumerator2.MoveNext())
            {
                if (!enumerator1.Current.Equals(enumerator2.Current))
                {
                    return false;
                }
            }

            return true;
        }

        private int GetEnumerableHashCode<T>(IEnumerable<T> enumerable)
        {
            unchecked
            {
                int hash = 17;
                foreach (var item in enumerable)
                {
                    hash = hash * 23 + (item != null ? item.GetHashCode() : 0);
                }
                return hash;
            }
        }
    }
}
