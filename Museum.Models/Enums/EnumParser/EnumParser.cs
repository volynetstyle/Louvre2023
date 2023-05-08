using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models.Enums.EnumParser
{
    public static class EnumParser
    {
        public static bool TryParseRatingType(string input, out RatingType ratingType)
        {
            input = input.Trim().ToLower();

            ratingType = input switch
            {
                "norecommendation" => RatingType.NoRecommendation,
                "dislike" => RatingType.Dislike,
                "liked" => RatingType.Liked,
                "veryliked" => RatingType.VeryLiked,
                _ => default,
            };

            return ratingType != default;
        }
    }
}
