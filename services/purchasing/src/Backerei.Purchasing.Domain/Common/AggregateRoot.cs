namespace Backerei.Purchasing.Domain.Common
{
    public abstract class AggregateRoot<T> : Entity<T>
    {
        protected AggregateRoot()
        {

        }

        protected AggregateRoot(T id) : base(id)
        {
        }
    }
}