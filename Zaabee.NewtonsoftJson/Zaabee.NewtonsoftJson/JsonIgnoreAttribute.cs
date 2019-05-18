using System;

namespace Zaabee.NewtonsoftJson
{
    /// <inheritdoc />
    /// <summary>
    /// Json ignore attribute
    /// </summary>
    public abstract class JsonIgnoreAttribute : Attribute
    {
        /// <summary>
        /// is ignore
        /// </summary>
        public bool Ignore { get; }

        /// <inheritdoc />
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ignore"></param>
        public JsonIgnoreAttribute(bool ignore)
        {
            Ignore = ignore;
        }
    }
}
