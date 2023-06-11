using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.ViewModels.FilterViewModels
{
    public class FilterSectionViewModel
    {
        public int OBJECT_ID { get; set; }
        public string? ImageUrl { get; set; }
        public string? Tags { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public int LikeCount { get; set; }
        public int DislikeCount { get; set; }
        public int CommentsCount { get; set; }

        
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            FilterSectionViewModel other = (FilterSectionViewModel)obj;

            return OBJECT_ID == other.OBJECT_ID
                && ImageUrl == other.ImageUrl
                && Tags == other.Tags
                && Title == other.Title
                && Description == other.Description;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + OBJECT_ID.GetHashCode();
                hash = hash * 23 + (ImageUrl != null ? ImageUrl.GetHashCode() : 0);
                hash = hash * 23 + (Tags != null ? Tags.GetHashCode() : 0);
                hash = hash * 23 + (Title != null ? Title.GetHashCode() : 0);
                hash = hash * 23 + (Description != null ? Description.GetHashCode() : 0);
                return hash;
            }
        }
    }
}
