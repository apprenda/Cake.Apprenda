using System;

namespace Cake.Apprenda.ACS.SetInstanceCount
{
    /// <summary>
    /// Represents an expression used in instance count operations.  
    /// </summary>
    /// <seealso cref="Scale" />
    public sealed class ScalingExpression
    {
        internal ScalingExpression(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));
            }

            this.Value = value;
        }

        /// <summary>
        /// Gets the expression to be used in the ACS command.
        /// </summary>
        internal string Value { get; }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.Value;
        }
    }
}