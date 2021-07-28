namespace lcms2dotnet.Icc
{
    /// <summary>
    /// Validation Status values
    /// </summary>
    public enum ValidateStatus
    {
        /// <summary>
        /// Profile is valid and conforms to specification
        /// </summary>
        Ok,
        /// <summary>
        /// Profile conforms to specification with concerns
        /// </summary>
        Warning,
        /// <summary>
        /// Profile does not conform to specification, but may still be useable
        /// </summary>
        NonCompliant,
        /// <summary>
        /// Profile does not conform to specification and is not usable
        /// </summary>
        CriticalError,
    }
}
