using System;
using System.Collections.Generic;
using Museum.App.ViewModels.FilterViewModels;

namespace Museum.App.ViewModels.Filter
{
    public class FilterViewModel
    {
        public FilterViewModel() { }
        public int pageSize { get; set; }
        public IEnumerable<FilterSectionViewModel>? FilterSections { get; set; }
        public IEnumerable<SideBarCollection>? FilterSideBarCollection { get; set; }
        public VoteViewModel? VoteViewModel { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            FilterViewModel other = (FilterViewModel)obj;

            return pageSize == other.pageSize
                && AreFilterSectionsEqual(FilterSections, other.FilterSections)
                && AreFilterSideBarCollectionsEqual(FilterSideBarCollection, other.FilterSideBarCollection);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + pageSize.GetHashCode();
                hash = hash * 23 + (FilterSections != null ? GetEnumerableHashCode(FilterSections) : 0);
                hash = hash * 23 + (FilterSideBarCollection != null ? GetEnumerableHashCode(FilterSideBarCollection) : 0);
                return hash;
            }
        }

        private bool AreFilterSectionsEqual(IEnumerable<FilterSectionViewModel>? sections1, IEnumerable<FilterSectionViewModel>? sections2)
        {
            if (sections1 == null && sections2 == null)
            {
                return true;
            }

            if (sections1 == null || sections2 == null || sections1.Count() != sections2.Count())
            {
                return false;
            }

            var enumerator1 = sections1.GetEnumerator();
            var enumerator2 = sections2.GetEnumerator();

            while (enumerator1.MoveNext() && enumerator2.MoveNext())
            {
                if (!enumerator1.Current.Equals(enumerator2.Current))
                {
                    return false;
                }
            }

            return true;
        }

        private bool AreFilterSideBarCollectionsEqual(IEnumerable<SideBarCollection>? collections1, IEnumerable<SideBarCollection>? collections2)
        {
            if (collections1 == null && collections2 == null)
            {
                return true;
            }

            if (collections1 == null || collections2 == null || collections1.Count() != collections2.Count())
            {
                return false;
            }

            var enumerator1 = collections1.GetEnumerator();
            var enumerator2 = collections2.GetEnumerator();

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
