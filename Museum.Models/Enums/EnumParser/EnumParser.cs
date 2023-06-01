using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models.Enums.EnumParser
{
    public static class EnumParser
    {
        public static bool TryParseEnumType<TEnum>(string input, out TEnum enumType) 
            where TEnum : struct
        {
            if (!Enum.TryParse(input, true, out enumType))
            {
                enumType = default;
                return false;
            }

            return Enum.IsDefined(typeof(RatingType), enumType);
        }

        public static bool TryParseEnumTypeBack<TEnum>(this TEnum enumType, out string input)
            where TEnum : struct
        {
            input = enumType
                .GetType()
                .ToString()
                .Trim()
                .ToLower();
            return !string.IsNullOrWhiteSpace(input);
        }
    }
}
