using Backerei.Catalog.Domain.Aggregates.CakeAggregate;
using Backerei.Catalog.Domain.Common;

namespace Backerei.Catalog.Domain.Commands
{
    public class UpdateIngredientsResponse : Response<UpdateIngredientsResponse>
    {
        public Cake Cake { get; init; }

        public static UpdateIngredientsResponse Valid(Cake cake)
        {
            return new UpdateIngredientsResponse {Cake = cake};
        }
    }
}