using System.Collections.Generic;
using Backerei.Catalog.Domain.Common;
using FluentValidation.Results;

namespace Backerei.Catalog.Domain.Aggregates.CakeAggregate.Commands
{
    public class DeleteCakeResponse: Response<DeleteCakeResponse>
    {
        public static DeleteCakeResponse Valid()
        {
            return new DeleteCakeResponse();
        }
    }
}