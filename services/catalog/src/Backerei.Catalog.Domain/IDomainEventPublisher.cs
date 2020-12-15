using System.Threading.Tasks;

namespace Backerei.Catalog.Domain
{
    /// <summary>
    /// Provides an interface to publish domain events in the application.
    /// </summary>
    public interface IDomainEventPublisher
    {
        /// <summary>
        /// Publishes a domain event.
        /// </summary>
        /// <param name="evt">Domain event to publish.</param>
        /// <returns>Returns an awaitable task.</returns>
        Task PublishAsync(DomainEvent evt);
    }
}