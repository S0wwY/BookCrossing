using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookCrossing.Models.Pagination
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public PagedList()
        {
            
        }

        public PagedList(List<T> items, int count, int pageNumber = 1, int pageSize = 20)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }

        //public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        //{
        //    MetaData = new MetaData
        //    {
        //        TotalCount = count,
        //        PageSize = pageSize,
        //        CurrentPage = pageNumber,
        //        TotalPages = (int)Math.Ceiling(count / (double)pageSize)
        //    };

        //    Items = items;
        //}
        //public MetaData MetaData { get; set; }
        //public List<T> Items { get; set; }

        //public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
        //{
        //    var count = source.Count();

        //    var items = source
        //        .Skip((pageNumber - 1) * pageSize)
        //        .Take(pageSize).ToList();

        //    return new PagedList<T>(items, count, pageNumber, pageSize);
        //}
    }
}
