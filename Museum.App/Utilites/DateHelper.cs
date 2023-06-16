namespace Museum.App.Utilites
{
    using System;

    public static class DateHelper
    {
        public static string FormatDate(DateTime date) 
            => date.Year < 0 ? $"{Math.Abs(date.Year)} BC" : $"{date.Year} AD";
    }

}
