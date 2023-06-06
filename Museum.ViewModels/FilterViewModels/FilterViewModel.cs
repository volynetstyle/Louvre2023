using Museum.App.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.ViewModels.Filter
{
    public class FilterViewModel
    {
        public FilterViewModel() { }

        public FilterViewModel(string? searchPattern, 
                               IEnumerable<DepartmentSection>? departmentSections,
                               IEnumerable<CheckboxViewModel>? departmentCollection, 
                               IEnumerable<CheckboxViewModel>? categoryCollection, 
                               IEnumerable<CheckboxViewModel>? artistCollection, 
                               IEnumerable<string>? tags) : this(departmentCollection, categoryCollection, artistCollection)
        {
            SearchPattern = searchPattern;
            DepartmentSections = departmentSections;
            Tags = tags;
        }

        public FilterViewModel(IEnumerable<CheckboxViewModel>? departmentCollection,
                               IEnumerable<CheckboxViewModel>? categoryCollection, 
                               IEnumerable<CheckboxViewModel>? artistCollection)
        {
            DepartmentCollection = departmentCollection;
            CategoryCollection = categoryCollection;
            ArtistCollection = artistCollection;
        }

        public string? SearchPattern { get; set; }
        public IEnumerable<DepartmentSection>? DepartmentSections { get; set; }
        public IEnumerable<CheckboxViewModel>? DepartmentCollection { get; set; }
        public IEnumerable<CheckboxViewModel>? CategoryCollection { get; set; }
        public IEnumerable<CheckboxViewModel>? ArtistCollection { get; set; }
        public IEnumerable<string>? Tags { get; set; }
    }
}
