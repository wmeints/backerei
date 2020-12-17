using System.Collections.Generic;

namespace Backerei.Catalog.Domain.Common
{
    /// <summary>
    /// Defines a single page of results.
    /// </summary>
    /// <typeparam name="T">Type of item retrieved from storage.</typeparam>
    public class PagedResultSet<T>
    {
        /// <summary>
        /// Gets the items for the current page.
        /// </summary>
        public IEnumerable<T> Items { get; init; }
        
        /// <summary>
        /// Gets the current page index
        /// </summary>
        public int PageIndex { get; init; }
        
        /// <summary>
        /// Gets the total number of pages.
        /// </summary>
        public int TotalPages { get; init; }
    }
}