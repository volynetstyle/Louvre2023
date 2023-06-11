namespace Museum.App.Utilites
{
    public static class EnumerableHelper
    {
        public static IEnumerable<TSource> 
            Pagination<TSource>(this IEnumerable<TSource> source, int page, int pageSize)
        {
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }

        public static async Task<IEnumerable<TSource>> PaginationAsync<TSource>(
        this IEnumerable<TSource> source, int page, int pageSize)
        {
            return await Task.Run(() =>
            {
                return source.Skip((page - 1) * pageSize).Take(pageSize);
            });
        }
    }
}
