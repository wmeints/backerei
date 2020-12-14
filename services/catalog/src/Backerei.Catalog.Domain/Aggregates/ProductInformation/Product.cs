using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Backerei.Catalog.Domain.Common;
using Backerei.Catalog.Domain.DomainEvents;

namespace Backerei.Catalog.Domain.Aggregates.ProductInformation
{
    /// <summary>
    /// A product identifies a cake or pie that you can order from the online backerei.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Product"/>
        /// </summary>
        private Product()
        {
        }

        /// <summary>
        /// Initializes a new intance of <see cref="Product"/>
        /// </summary>
        /// <param name="id">ID of the product.</param>
        public Product(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets the ID of the product.
        /// </summary>
        public Guid Id { get; private set; }

        /// <summary>
        /// Gets the name of the product.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the description of the product.
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the price of the product.
        /// </summary>
        public double Price { get; private set; }

        /// <summary>
        /// Gets the allergens in the product.
        /// </summary>
        public ICollection<Allergen> Allergens { get; private set; } = new Collection<Allergen>();
        
        /// <summary>
        /// Creates a new product.
        /// </summary>
        /// <param name="name">Name of the product.</param>
        /// <param name="description">Description of the product.</param>
        /// <param name="price">Price of the product.</param>
        /// <returns>Returns the result of the operation including the created product.</returns>
        public static OperationResult<Product> Create(string name, string description, double price)
        {
            var result = new OperationResult<Product>();

            if (string.IsNullOrWhiteSpace(name))
            {
                result.AddValidationError("name", "Name is required.");
            }
            
            if (string.IsNullOrWhiteSpace(description))
            {
                result.AddValidationError("description", "Description is required.");
            }
            
            if (price <= 0.0)
            {
                result.AddValidationError("price", "The price must be above zero.");
            }

            if (result.IsValid)
            {
                var product = new Product(Guid.NewGuid())
                {
                    Name = name,
                    Description = description,
                    Price = price
                };

                result.SetOutput(product);

                result.AddDomainEvent(new ProductRegisteredEvent
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price
                });
            }

            return result;
        }

        /// <summary>
        /// Updates the details of the product in the catalog.
        /// </summary>
        /// <param name="name">Name of the product to update.</param>
        /// <param name="description">Updated description of the product.</param>
        /// <param name="price">Updated price of the product.</param>
        /// <returns>Returns the outcome of the operation.</returns>
        public OperationResult UpdateDetails(string name, string description, double price)
        {
            var result = new OperationResult();

            if (string.IsNullOrWhiteSpace(name))
            {
                result.AddValidationError("name", "Name is required.");
            }
            
            if (string.IsNullOrWhiteSpace(description))
            {
                result.AddValidationError("description", "Description is required.");
            }
            
            if (price <= 0.0)
            {
                result.AddValidationError("price", "The price must be above zero.");
            }

            Name = name;
            Description = description;
            Price = price;

            result.AddDomainEvent(new ProductInformationUpdatedEvent
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Price = Price
            });

            return result;
        }

        /// <summary>
        /// Adds an allergen to the product.
        /// </summary>
        /// <param name="name">Name of the allergen.</param>
        /// <returns>Returns the outcome of the operation.</returns>
        public OperationResult AddAllergen(string name)
        {
            var result = new OperationResult();

            if (string.IsNullOrWhiteSpace(name))
            {
                result.AddValidationError("name", "Name is required.");
            }

            if (result.IsValid)
            {
                Allergens.Add(new Allergen(Guid.NewGuid(), name));
            }
            
            return result;
        }

        /// <summary>
        /// Updates an allergen in the product.
        /// </summary>
        /// <param name="id">ID of the allergen to update.</param>
        /// <param name="name">New name of the allergen.</param>
        /// <returns>Returns the outcome of the operation.</returns>
        public OperationResult UpdateAllergen(Guid id, string name)
        {
            var result = new OperationResult();
            var allergen = Allergens.SingleOrDefault(x => x.Id == id);
            
            if (string.IsNullOrWhiteSpace(name))
            {
                result.AddValidationError("name", "Name is required.");
            }

            if (allergen == null)
            {
                result.AddValidationError("id", "The specified allergen doesn't exist.");
            }

            if (result.IsValid)
            {
                allergen.UpdateInformation(name);
            }

            return result;
        }

        /// <summary>
        /// Remove an allergen from the application.
        /// </summary>
        /// <param name="id">ID of the allergen.</param>
        /// <returns>Returns the outcome of the operation.</returns>
        public OperationResult RemoveAllergen(Guid id)
        {
            var result = new OperationResult();
            var allergen = Allergens.SingleOrDefault(x => x.Id == id);

            if (allergen == null)
            {
                result.AddValidationError("", "The specified allergen doesn't exist.");
            }
            
            if (result.IsValid)
            {
                Allergens.Remove(allergen);
            }

            return result;
        }
    }
}