namespace PrAnalyzer.Contracts.Enum
{
    /// <summary>
    /// Status of a handler call.
    /// </summary>
    public enum HandlerCallStatus
    {
        /// <summary>
        /// The call completed successfully.
        /// </summary>
        Ok,
        /// <summary>
        /// The call created successfully.
        /// </summary>
        Created,
        /// <summary>
        /// One or more needed entities were not found.
        /// </summary>
        EntityNotFound,
        /// <summary>
        /// The client does not have sufficient rights.
        /// </summary>
        UnauthorizedAccess,
        /// <summary>
        /// The client calls the service in a non-defined way.
        /// </summary>
        InvalidOperation,
        /// <summary>
        /// A validation of an entity failed.
        /// </summary>
        InvalidEntity
    }
}
