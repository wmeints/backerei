using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backerei.Catalog.Domain.Aggregates.CategoryAggregate
{
    public interface ICategoryRepository: IRepository<Category>
    {
        /// <summary>
        /// Retrieves a list of all existing categories in the database.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Category>> GetAllCategories();

        /// <summary>
        /// Checks whether the specified category exists.
        /// </summary>
        /// <param name="categoryId">ID of the category to check.</param>
        /// <returns>Returns true when the category exists; Otherwise false.</returns>
        Task<bool> CategoryExists(int categoryId);
    }
}