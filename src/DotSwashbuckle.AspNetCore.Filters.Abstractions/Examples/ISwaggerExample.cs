namespace DotSwashbuckle.AspNetCore.Filters
{
    /// <summary>
    /// A single example out of multiple.
    /// </summary>
    /// <remarks>
    /// It's important that the interface is co-variant.  That allows instances
    /// of the interface to be found with "x as ISwaggerExample{object}" instead
    /// of having to go through reflection gymnastics.
    /// </remarks>
    public interface ISwaggerExample<out T>
    {
        /// <summary>
        /// Name of the example.  Required.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Optional summary of the example.
        /// </summary>
        string Summary { get; }

        /// <summary>
        /// Optional description of the example.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// The example value.  Required.
        /// </summary>
        T Value { get; }
    }
}
