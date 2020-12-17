using Backerei.Catalog.Domain.Common;

namespace Backerei.Catalog.Domain.Aggregates.CakeAggregate.Commands
{
    public class UpdateCakeResponse: Response<UpdateCakeResponse>
    {
        public Cake Cake { get; init; }
        
        public static UpdateCakeResponse Valid(Cake cake)
        {
            return new UpdateCakeResponse {Cake = cake};
        }
    }
}