using System.Threading.Tasks;
using Backerei.Catalog.Domain.Aggregates.CakeAggregate;
using Backerei.Catalog.Domain.Aggregates.CakeAggregate.Commands;
using Backerei.Catalog.Domain.Aggregates.CakeAggregate.Validators;
using Backerei.Catalog.Domain.Aggregates.CategoryAggregate;
using Backerei.Catalog.Domain.Commands;

namespace Backerei.Catalog.Domain.Services
{
    /// <summary>
    /// Implementation of the product catalog service.
    /// </summary>
    public class ProductCatalogService: IProductCatalogService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICakeRepository _cakeRepository;
        
        /// <summary>
        /// Initializes a new instance of <see cref="ProductCatalogService"/>
        /// </summary>
        /// <param name="categoryRepository"></param>
        /// <param name="cakeRepository"></param>
        public ProductCatalogService(ICategoryRepository categoryRepository, ICakeRepository cakeRepository)
        {
            _categoryRepository = categoryRepository;
            _cakeRepository = cakeRepository;
        }

        /// <summary>
        /// Creates a new cake in the catalog.
        /// </summary>
        /// <param name="cmd">Command data to process.</param>
        /// <returns>Returns the response for the operation.</returns>
        public async Task<CreateCakeResponse> CreateCake(CreateCakeCommand cmd)
        {
            var validator = new CreateCakeCommandValidator(_categoryRepository);
            var validationResults = await validator.ValidateAsync(cmd);

            if (!validationResults.IsValid)
            {
                return CreateCakeResponse.Invalid(validationResults.Errors);
            }

            var cake = await _cakeRepository.Insert(Cake.Create(cmd));
            
            return CreateCakeResponse.Valid(cake);
        }
        
        /// <summary>
        /// Updates the product details of a cake in the catalog.
        /// </summary>
        /// <param name="cmd">Command data for the operation.</param>
        /// <returns>Returns the result of the operation.</returns>
        public async Task<UpdateCakeResponse> UpdateCake(UpdateCakeCommand cmd)
        {
            var validator = new UpdateCakeCommandValidator(_cakeRepository, _categoryRepository);
            var validationResults = await validator.ValidateAsync(cmd);

            if (!validationResults.IsValid)
            {
                return UpdateCakeResponse.Invalid(validationResults.Errors);
            }

            var cake = await _cakeRepository.GetCakeById(cmd.CakeId);
            
            cake.Update(cmd);
            await _cakeRepository.Update(cake);
            
            return UpdateCakeResponse.Valid(cake);
        }

        /// <summary>
        /// Deletes an existing cake.
        /// </summary>
        /// <param name="cmd">Command data for the operation.</param>
        /// <returns>Returns the result of the operation.</returns>
        public async Task<DeleteCakeResponse> DeleteCake(DeleteCakeCommand cmd)
        {
            var validator = new DeleteCakeCommandValidator(_cakeRepository);
            var validationResults = await validator.ValidateAsync(cmd);

            if (!validationResults.IsValid)
            {
                return DeleteCakeResponse.Invalid(validationResults.Errors);
            }

            await _cakeRepository.Delete(cmd.CakeId);
            
            return DeleteCakeResponse.Valid();
        }

        /// <summary>
        /// Updates the ingredients for a cake.
        /// </summary>
        /// <param name="cmd">Command data for the operation.</param>
        /// <returns>Returns the result of the operation.</returns>
        public async Task<UpdateIngredientsResponse> UpdateIngredients(UpdateIngredientsCommand cmd)
        {
            var validator = new UpdateIngredientsCommandValidator(_cakeRepository);
            var validationResults = await validator.ValidateAsync(cmd);

            if (!validationResults.IsValid)
            {
                return UpdateIngredientsResponse.Invalid(validationResults.Errors);
            }

            var cake = await _cakeRepository.GetCakeById(cmd.CakeId);
            
            cake.UpdateIngredients(cmd);
            var results = await _cakeRepository.Update(cake);
            
            return UpdateIngredientsResponse.Valid(results);
        }
    }
}