using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anthill.Common.Extensions.Models
{
    public class PagedList<T> : List<T>
    {
        public PagedList()
        {
        }

        public PagedList(IEnumerable<T> items, int totalItems, int totalPages, int currentPage)
            :base(items)
        {
            TotalItems = totalItems;
            TotalPages = totalPages;
            CurrentPage = currentPage;
        }

        public int TotalItems { get; set; }

        public int TotalPages { get; set; }

        public int CurrentPage { get; set; }
    }
}
