using System;

namespace Backerei.Catalog.Domain.Aggregates.CakeAggregate
{
    /// <summary>
    /// Defines the serving size of the cake in a range between the minimum number of
    /// people and maximum number of people being served.
    /// </summary>
    public class ServingPortions
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ServingPortions"/>
        /// </summary>
        private ServingPortions()
        {
            
        }
        
        /// <summary>
        /// Initializes a new instance of <see cref="ServingPortions"/>.
        /// </summary>
        /// <param name="minimum">Minimum number of people to serve.</param>
        /// <param name="maximum">Maximum number of people to serve.</param>
        private ServingPortions(int minimum, int maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }

        /// <summary>
        /// Gets the minimum number of people you can serve.
        /// </summary>
        public int Minimum { get; }
        
        /// <summary>
        /// Gets the maximum number of people you can serve.
        /// </summary>
        public int Maximum { get; }

        /// <summary>
        /// Creates a new serving size from a range.
        /// </summary>
        /// <param name="min">Minimum value.</param>
        /// <param name="max">Maximum value.</param>
        /// <returns>Returns the new serving size.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static ServingPortions FromRange(int min, int max)
        {
            if (min <= 0) throw new ArgumentException("Minimum must be above zero", nameof(min));
            if (min >= max) throw new ArgumentException("Maximum must be above minimum.", nameof(max));

            return new ServingPortions(min, max);
        }

        /// <inheritdoc />
        protected bool Equals(ServingPortions other)
        {
            return Minimum == other.Minimum && Maximum == other.Maximum;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ServingPortions) obj);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return HashCode.Combine(Minimum, Maximum);
        }
    }
}