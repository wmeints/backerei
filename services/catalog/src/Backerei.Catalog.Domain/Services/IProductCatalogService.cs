using System.Threading.Tasks;
using Backerei.Catalog.Domain.Aggregates.CakeAggregate;
using Backerei.Catalog.Domain.Aggregates.CakeAggregate.Commands;
using Backerei.Catalog.Domain.Commands;

namespace Backerei.Catalog.Domain.Services
{
    /// <summary>
    /// Provides access to the product catalog.
    /// </summary>
    public interface IProductCatalogService
    {
        /// <summary>
        /// Creates a new cake.
        /// </summary>
        /// <param name="cmd">The command data for the operation.</param>
        /// <returns>Returns the result of the operation.</returns>
        Task<CreateCakeResponse> CreateCake(CreateCakeCommand cmd);
        
        /// <summary>
        /// Updates a cake.
        /// </summary>
        /// <param name="cmd">The command data for the operation.</param>
        /// <returns>Returns the result of the operation.</returns>
        Task<UpdateCakeResponse> UpdateCake(UpdateCakeCommand cmd);
        
        /// <summary>
        /// Deletes a cake.
        /// </summary>
        /// <param name="cmd">The command data for the operation.</param>
        /// <returns>Returns the result of the operation.</returns>
        Task<DeleteCakeResponse> DeleteCake(DeleteCakeCommand cmd);
        
        /// <summary>
        /// Updates the ingredients in a cake.
        /// </summary>
        /// <param name="cmd">The command data for the operation.</param>
        /// <returns>Returns the result of the operation.</returns>
        Task<UpdateIngredientsResponse> UpdateIngredients(UpdateIngredientsCommand cmd);
    }
}