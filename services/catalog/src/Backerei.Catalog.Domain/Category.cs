using System;

namespace Backerei.Catalog.Domain
{
    /// <summary>
    /// Represents a category of cakes sold on the website. For example: birthday, wedding, christmas
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Category"/>
        /// </summary>
        private Category()
        {
            
        }
        
        /// <summary>
        /// Gets the ID of the category.
        /// </summary>
        public int Id { get; private set; }
        
        /// <summary>
        /// Gets the name of the category.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Creates a new category.
        /// </summary>
        /// <param name="name">Name of the new category.</param>
        /// <returns>Returns the new category.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Category Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            
            return new Category {Name = name};
        }

        /// <summary>
        /// Updates the details of the category.
        /// </summary>
        /// <param name="name">Name of the new category.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Update(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            Name = name;
        }
    }
}