using System;
using System.Globalization;

namespace Cake.Apprenda.ACS.SetInstanceCount
{
    /// <summary>
    /// Provides an API for scaling expressions
    /// </summary>
    public static class Scale
    {
        /// <summary>
        /// Creates a <see cref="ScalingExpression"/> defining a fixed scaling point
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public static ScalingExpression To(int count)
        {
            return new ScalingExpression(count.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// Creates a <see cref="ScalingExpression"/> defining a a positive delta
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public static ScalingExpression Up(int count)
        {
            if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count should represent a magnitude and must be a positive number.");
            }

            return new ScalingExpression($"+{count}");
        }

        /// <summary>
        /// Creates a <see cref="ScalingExpression"/> defining a negative delta
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public static ScalingExpression Down(int count)
        {
            if (count < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(count), "Count should represent a magnitude and must be a positive number.");
            }

            return new ScalingExpression($"-{count}");
        }

        /// <summary>
        /// Creates a <see cref="ScalingExpression"/> defining either a positive or negative delta
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public static ScalingExpression ByDelta(int count)
        {
            if (count == 0)
            {
                throw new ArgumentException("Zero value for ScalingExpression is equivalent to a no-op and is not supported", nameof(count));
            }

            return count < 0 ? Down(Math.Abs(count)) : Up(count);
        }
    }
}