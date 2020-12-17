using System.Threading.Tasks;

namespace Backerei.Catalog.Domain
{
    /// <summary>
    /// Standardized interface for domain object repositories.
    /// </summary>
    /// <typeparam name="T">Type of entity processed by the repository.</typeparam>
    public interface IRepository<T>
    {
        /// <summary>
        /// Inserts a new instance of the entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> Insert(T entity);
        
        /// <summary>
        /// Updates an existing instance of the entity.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<T> Update(T entity);
        
        /// <summary>
        /// Deletes an existing instance of the entity.
        /// </summary>
        /// <param name="entityId"></param>
        /// <returns></returns>
        Task Delete(int entityId);
    }
}