using System.Collections.Generic;

namespace Backerei.Catalog.Domain.Common
{
    /// <summary>
    /// Defines the result of an operation.
    /// </summary>
    public class OperationResult
    {
        private Dictionary<string, List<string>> _validationErrors = new();
        private List<DomainEvent> _domainEvents = new();

        /// <summary>
        /// Gets whether the operation is valid.
        /// </summary>
        public bool IsValid => _validationErrors.Count == 0;
        
        /// <summary>
        /// Gets whether the operation is invalid.
        /// </summary>
        public bool IsInvalid => _validationErrors.Count > 0;
        
        /// <summary>
        /// Gets the domain events that were emitted during the operation.
        /// </summary>
        public IEnumerable<DomainEvent> DomainEvents => _domainEvents;
        
        /// <summary>
        /// Gets all validation errors that happened while performing the operation.
        /// </summary>
        public IReadOnlyDictionary<string, List<string>> ValidationErrors => _validationErrors;

        /// <summary>
        /// Adds a validation error to the outcome of the operation.
        /// </summary>
        /// <param name="key">Key of the message.</param>
        /// <param name="message">Message to register.</param>
        public void AddValidationError(string key, string message)
        {
            if (_validationErrors.TryGetValue(key, out var messages))
            {
                messages.Add(message);
            }
            else
            {
                _validationErrors.Add(key, new List<string>() { message });
            }
        }

        /// <summary>
        /// Registers a domain event that should be emitted at the end of the operation.
        /// </summary>
        /// <param name="evt">Domain event to register for emission.</param>
        public void AddDomainEvent(DomainEvent evt)
        {
            _domainEvents.Add(evt);
        }
    }

    /// <summary>
    /// Use this kind of operation result to return an output with the operation.
    /// </summary>
    /// <typeparam name="T">Type of data produced by the operation.</typeparam>
    public class OperationResult<T> : OperationResult
    {
        /// <summary>
        /// Gets the result of the operation.
        /// </summary>
        public T Output { get; private set; }

        /// <summary>
        /// Sets the result for the operation.
        /// </summary>
        /// <param name="outcome"></param>
        public void SetOutput(T outcome)
        {
            Output = outcome;
        }
    }
}