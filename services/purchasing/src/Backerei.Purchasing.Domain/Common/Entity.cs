namespace Backerei.Purchasing.Domain.Common
{
    public abstract class Entity<T>
    {
        protected Entity()
        {

        }

        protected Entity(T id)
        {
            Id = id;
        }

        public T Id { get; }
    }
}