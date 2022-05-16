using System;
using System.Collections.Generic;
using System.Linq;

namespace RestAPI.Application.Parameters
{
    public class PagedList<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }

        public PagedList(IEnumerable<T> items, int totalItems, int currentPage, int totalPages)
        {
            Data = items;
            CurrentPage = currentPage;
            TotalItems = totalItems;
            TotalPages = totalPages;
        }

        public static PagedList<T> ToPagedList(IQueryable<T> source, int currentPage, int pageSize)
        {
            var totalItems = source.Count();
            var items = source
                .Skip(currentPage * pageSize)
                .Take(pageSize)
                .ToList();
            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            return new PagedList<T>(items, totalItems, currentPage, totalPages);
        }
    }
}
