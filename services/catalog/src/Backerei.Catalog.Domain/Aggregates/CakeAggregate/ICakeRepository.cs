using System.Threading.Tasks;
using Backerei.Catalog.Domain.Common;

namespace Backerei.Catalog.Domain.Aggregates.CakeAggregate
{
    /// <summary>
    /// Persistence interface for cakes.
    /// </summary>
    public interface ICakeRepository: IRepository<Cake>
    {
        /// <summary>
        /// Retrieves a list of all existing cakes.
        /// </summary>
        /// <param name="pageIndex">Page index to retrieve.</param>
        /// <returns>Returns the paged result set containing the requested cakes.</returns>
        Task<PagedResultSet<Cake>> GetAllCakes(int pageIndex);
        
        /// <summary>
        /// Retrieves a paged list of cakes from a particular category.
        /// </summary>
        /// <param name="categoryId">ID of the category.</param>
        /// <param name="pageIndex">Page index to retrieve.</param>
        /// <returns>Returns the paged result set containing the requested cakes.</returns>
        Task<PagedResultSet<Cake>> GetCakesByCategory(int categoryId, int pageIndex);

        /// <summary>
        /// Checks if a cake exists with the specified ID.
        /// </summary>
        /// <param name="cakeId">ID of the cake to find.</param>
        /// <returns>Returns true when a cake exists with the specified ID; Otherwise false.</returns>
        Task<bool> CakeExists(in int cakeId);

        /// <summary>
        /// Retrieves a single cake based on its ID.
        /// </summary>
        /// <param name="cakeId">ID of the cake.</param>
        /// <returns>Returns the found cake.</returns>
        Task<Cake> GetCakeById(int cakeId);
    }
}