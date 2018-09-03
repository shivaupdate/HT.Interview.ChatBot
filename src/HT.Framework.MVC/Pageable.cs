using System;
using System.Collections.Generic;
using System.Linq;

namespace HT.Framework.MVC
{
    /// <summary>
    /// Pageable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Pageable<T>
    {
        /// <summary>
        /// Get Current Page
        /// </summary>
        /// <value>
        /// The CurrentPage
        /// </value>
        public int CurrentPage { get; }

        /// <summary>
        /// Total Pages
        /// </summary>
        /// <value>
        /// The TotalPages
        /// </value>
        public int TotalPages { get; }

        /// <summary>
        /// Total Count
        /// </summary>
        /// <value>
        /// The TotalCount
        /// </value>
        public int TotalCount { get; }

        /// <summary>
        /// Page Size
        /// </summary>
        /// <value>
        /// The PageSize
        /// </value>
        public int PageSize { get; }

        /// <summary>
        /// Has Previous Page
        /// </summary>
        /// <value>
        /// The HasPreviousPage
        /// </value>
        public bool HasPreviousPage => (CurrentPage > 1);

        /// <summary>
        /// Has Next Page
        /// </summary>
        /// <value>
        /// The HasNextPage
        /// </value>
        public bool HasNextPage => (CurrentPage < TotalPages);

        /// <summary>
        /// Items
        /// </summary>
        /// <value>
        /// The Items
        /// </value>
        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Pageable(IQueryable<T> items, int currentPage, int pageSize)
        {
            Items = items;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalCount = items.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            if (pageSize > 0)
            {
                Items = items.Skip((currentPage - 1) * pageSize).Take(pageSize);
            }
        }

        /// <summary>
        /// Pageable
        /// </summary>
        /// <param name="items"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        public Pageable(IEnumerable<T> items, int currentPage, int pageSize)
        {
            Items = items;
            CurrentPage = currentPage;
            PageSize = pageSize;
            TotalCount = items.Count();
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            if (pageSize > 0)
            {
                Items = items.Skip((currentPage - 1) * pageSize).Take(pageSize);
            }
        }

        /// <summary>
        /// Paginate collection
        /// </summary>
        /// <param name="items"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static Pageable<T> Paginate(IQueryable<T> items, int currentPage, int pageSize)
        {
            return new Pageable<T>(items, currentPage, pageSize);
        }

        /// <summary>
        /// Paginate collection
        /// </summary>
        /// <param name="items"></param>
        /// <param name="currentPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static Pageable<T> Paginate(IEnumerable<T> items, int currentPage, int pageSize)
        {
            return new Pageable<T>(items, currentPage, pageSize);
        }
    }
}