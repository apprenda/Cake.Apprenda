using System;

namespace Cake.Apprenda.ACS.SetInstanceCount
{
    /// <summary>
    /// Contains settings used by <see cref="SetInstanceCount"/>
    /// </summary>
    public sealed class SetInstanceCountSettings : ACSSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetInstanceCountSettings"/> class.
        /// </summary>
        /// <param name="appAlias">The application alias.</param>
        /// <param name="versionAlias"></param>
        /// <param name="componentAlias"></param>
        /// <param name="expression"></param>
        public SetInstanceCountSettings(string appAlias, string versionAlias, string componentAlias, ScalingExpression expression)
        {
            if (string.IsNullOrEmpty(appAlias))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(appAlias));
            }

            if (string.IsNullOrEmpty(versionAlias))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(versionAlias));
            }

            if (string.IsNullOrEmpty(componentAlias))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(componentAlias));
            }

            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            this.AppAlias = appAlias;
            this.VersionAlias = versionAlias;
            this.ComponentAlias = componentAlias;
            this.ScalingExpression = expression;
        }

        /// <summary>
        /// Gets the application alias.
        /// </summary>
        public string AppAlias { get; }

        /// <summary>
        /// Gets the version alias.
        /// </summary>
        public string VersionAlias { get; }

        /// <summary>
        /// Gets or sets the component alias to configure scaling for
        /// </summary>
        public string ComponentAlias { get; }

        /// <summary>
        /// Gets the expression to use in the scaling operation
        /// </summary>
        /// <value>
        /// The expression.
        /// </value>
        public ScalingExpression ScalingExpression { get; }
    }
}