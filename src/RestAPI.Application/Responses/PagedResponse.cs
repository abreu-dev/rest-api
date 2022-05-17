using System.Collections.Generic;

namespace RestAPI.Application.Responses
{
    public class PagedResponse<T>
    {
        public IEnumerable<T> Data { get; set; }
        public int CurrentPage { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }

        public PagedResponse(IEnumerable<T> items, int currentPage, int totalItems, int totalPages)
        {
            Data = items;
            CurrentPage = currentPage;
            TotalItems = totalItems;
            TotalPages = totalPages;
        }
    }
}
