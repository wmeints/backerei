using System.Collections.Generic;
using FluentValidation.Results;

namespace Backerei.Catalog.Domain.Common
{
    public class OperationResult
    {
        private readonly List<DomainError> _errors = new List<DomainError>();
        private readonly List<DomainEvent> _events = new List<DomainEvent>();

        /// <summary>
        /// Gets errors raised by the operation result.
        /// </summary>
        public IEnumerable<DomainError> Errors => _errors;

        /// <summary>
        /// Gets whether the operation result is valid.
        /// </summary>
        public bool IsValid => _errors.Count == 0;

        /// <summary>
        /// Gets whether the operation result is invalid.
        /// </summary>
        public bool IsInvalid => _errors.Count > 0;

        /// <summary>
        /// Includes a domain event in the operation result.
        /// </summary>
        /// <param name="evt">Domain event to include in the operation result.</param>
        /// <returns>Returns the operation result instance.</returns>
        public OperationResult WithDomainEvent(DomainEvent evt)
        {
            _events.Add(evt);
            return this;
        }

        /// <summary>
        /// Includes a domain error in the operation result.
        /// </summary>
        /// <param name="property">Property that was involved in the domain error.</param>
        /// <param name="message">Error message to display.</param>
        /// <returns>Returns the operation result instance.</returns>
        public OperationResult WithError(string property, string message)
        {
            _errors.Add(new DomainError
            {
                Property = property,
                Message = message
            });

            return this;
        }

        /// <summary>
        /// Includes a validation result in the operation result.
        /// </summary>
        /// <param name="validationResult">Validation result to include.</param>
        /// <returns>Returns the operation result instance.</returns>
        public OperationResult WithValidationResult(ValidationResult validationResults)
        {
            foreach (var error in validationResults.Errors)
            {
                _errors.Add(new DomainError
                {
                    Property = error.PropertyName,
                    Message = error.ErrorMessage
                });
            }

            return this;
        }
    }

    /// <summary>
    /// Models the output of an operation that includes a value to be returned by the operation.
    /// </summary>
    /// <typeparam name="T">Type of value produced by the operation.</typeparam>
    public class OperationResult<T>
    {
        private readonly List<DomainError> _errors = new List<DomainError>();
        private readonly List<DomainEvent> _events = new List<DomainEvent>();
        
        /// <summary>
        /// Gets errors raised by the operation result.
        /// </summary>
        public IEnumerable<DomainError> Errors => _errors;

        /// <summary>
        /// Gets the domain events raised by the operation.
        /// </summary>
        public IEnumerable<DomainEvent> Events => _events;

        /// <summary>
        /// Gets whether the operation result is valid.
        /// </summary>
        public bool IsValid => _errors.Count == 0;

        /// <summary>
        /// Gets whether the operation result is invalid.
        /// </summary>
        public bool IsInvalid => _errors.Count > 0;

        /// <summary>
        /// Gets the output produced by the operation.
        /// </summary>
        public T Output { get; private set; }

        /// <summary>
        /// Includes output in the operation result.
        /// </summary>
        /// <param name="output">Output to include.</param>
        /// <returns>Returns the operation result instance.</returns>
        public OperationResult<T> WithOutput(T output)
        {
            Output = output;
            return this;
        }
        
        /// <summary>
        /// Includes a domain error in the operation result.
        /// </summary>
        /// <param name="property">Property that was involved in the domain error.</param>
        /// <param name="message">Error message to display.</param>
        /// <returns>Returns the operation result instance.</returns>
        public OperationResult<T> WithError(string property, string message)
        {
            _errors.Add(new DomainError
            {
                Property = property,
                Message = message
            });

            return this;
        }

        /// <summary>
        /// Includes a domain event in the operation result.
        /// </summary>
        /// <param name="evt">Domain event to include in the operation result.</param>
        /// <returns>Returns the operation result instance.</returns>
        public OperationResult<T> WithDomainEvent(DomainEvent evt)
        {
            _events.Add(evt);
            return this;
        }

        /// <summary>
        /// Includes a validation result in the operation result.
        /// </summary>
        /// <param name="validationResult">Validation result to include.</param>
        /// <returns>Returns the operation result instance.</returns>
        public OperationResult<T> WithValidationResult(ValidationResult validationResults)
        {
            foreach (var error in validationResults.Errors)
            {
                _errors.Add(new DomainError
                {
                    Property = error.PropertyName,
                    Message = error.ErrorMessage
                });
            }

            return this;
        }
    }
}