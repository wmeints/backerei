using System.Runtime.CompilerServices;
using Backerei.Catalog.Domain.Common;

namespace Backerei.Catalog.Domain.Aggregates.CakeAggregate.Commands
{
    /// <summary>
    /// A response object for the <see cref="CreateCakeCommand"/>.
    /// </summary>
    public class CreateCakeResponse : Response<CreateCakeResponse>
    {
        /// <summary>
        /// Initializes a new instance of <see cref="CreateCakeResponse"/>
        /// </summary>
        public CreateCakeResponse()
        {
        }

        /// <summary>
        /// Gets the cake that was created.
        /// </summary>
        public Cake Cake { get; init; }

        /// <summary>
        /// Creates a valid response with the response data.
        /// </summary>
        /// <param name="cake">The cake that was created.</param>
        /// <returns>Returns the new response.</returns>
        public static CreateCakeResponse Valid(Cake cake)
        {
            return new CreateCakeResponse {Cake = cake};
        }
    }
}