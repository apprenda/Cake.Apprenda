using System;

namespace Cake.Apprenda.ACS.SetInstanceCount
{
    /// <summary>
    /// Contains settings used by <see cref="SetInstanceCount"/>
    /// </summary>
    public sealed class SetInstanceCountSettings : CloudShellSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetInstanceCountSettings" /> class.
        /// </summary>
        /// <param name="appAlias">The application alias.</param>
        /// <param name="versionAlias">The version alias.</param>
        /// <param name="componentAlias">The component alias.</param>
        /// <param name="expression">The expression.</param>
        /// <exception cref="System.ArgumentException">Value cannot be null or empty. - appAlias
        /// or
        /// Value cannot be null or empty. - versionAlias
        /// or
        /// Value cannot be null or empty. - componentAlias</exception>
        /// <exception cref="System.ArgumentNullException">Thrown if the scaling expression is null</exception>
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
        /// Gets the component alias to configure scaling for
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