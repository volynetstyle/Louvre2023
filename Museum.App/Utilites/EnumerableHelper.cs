namespace Museum.App.Utilites
{
    public static class EnumerableHelper
    {
        public static IEnumerable<TSource> Pagination<TSource>(this IEnumerable<TSource> source, int page, int pageSize)
        {
            int startIndex = (page - 1) * pageSize;
            return source.Take(startIndex..(startIndex + pageSize));
        }

        public static async Task<IEnumerable<TSource>> PaginationAsync<TSource>(this IEnumerable<TSource> source, int page, int pageSize)
        {
            return await Task.Run(() =>
            {
                int startIndex = (page - 1) * pageSize;
                return source.Take(startIndex..(startIndex + pageSize));
            });
        }

    }
}
