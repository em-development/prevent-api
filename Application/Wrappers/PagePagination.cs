using AutoMapper;

namespace Application.Wrappers
{
    public static class PagePagination
    {
        public static Task<PagedResponse<IEnumerable<D>>> Paginate<T, D>(
            this IQueryable<T> query,
            int current,
            int limit,
            IMapper mapper
        )
        {
            int length = query.Count();

            List<T>? list = query
                .Skip(current * limit)
                .Take(limit)
                .ToList();

            IEnumerable<D>? finalList = mapper.Map<IEnumerable<D>>(list);

            Task<PagedResponse<IEnumerable<D>>> task = new Task<PagedResponse<IEnumerable<D>>>(() =>
            {
                return new PagedResponse<IEnumerable<D>>(finalList, length);
            });

            task.RunSynchronously();

            return task;
        }

        public static Task<PagedResponse<IEnumerable<D>>> Paginate<D>(
            this IEnumerable<D> query,
            int current,
            int limit
        )
        {
            int length = query.Count();

            List<D>? list = query
                .Skip(current * limit)
                .Take(limit)
                .ToList();

            Task<PagedResponse<IEnumerable<D>>> task = new Task<PagedResponse<IEnumerable<D>>>(() =>
            {
                return new PagedResponse<IEnumerable<D>>(list, length);
            });

            task.RunSynchronously();

            return task;
        }
    }
}
