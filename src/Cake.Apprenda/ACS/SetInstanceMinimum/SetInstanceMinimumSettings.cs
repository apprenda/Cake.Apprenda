using System;

namespace Cake.Apprenda.ACS.SetInstanceMinimum
{
    /// <summary>
    /// Contains settings used by <see cref="SetInstanceMinimum"/>
    /// </summary>
    public sealed class SetInstanceMinimumSettings : ACSSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetInstanceMinimumSettings"/> class.
        /// </summary>
        /// <param name="appAlias">The application alias.</param>
        /// <param name="versionAlias"></param>
        /// <param name="componentAlias"></param>
        /// <param name="minimumCount"></param>
        public SetInstanceMinimumSettings(string appAlias, string versionAlias, string componentAlias, int minimumCount)
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

            this.AppAlias = appAlias;
            this.VersionAlias = versionAlias;
            this.ComponentAlias = componentAlias;
            this.MinimumCount = minimumCount;
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
        /// Gets the minimum instance count
        /// </summary>
        public int MinimumCount { get; }

        /// <summary>
        /// Gets or sets the component alias to configure scaling for
        /// </summary>
        public string ComponentAlias { get; }

    }
}