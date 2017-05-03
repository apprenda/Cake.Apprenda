using System;

namespace Cake.Apprenda.ACS.SetInstanceMinimum
{
    /// <summary>
    /// Contains settings used by <see cref="SetInstanceMinimum"/>
    /// </summary>
    public sealed class SetInstanceMinimumSettings : CloudShellSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetInstanceMinimumSettings" /> class.
        /// </summary>
        /// <param name="appAlias">The application alias.</param>
        /// <param name="versionAlias">The version alias.</param>
        /// <param name="componentAlias">The component alias.</param>
        /// <param name="minimumCount">The minimum count.</param>
        /// <exception cref="System.ArgumentException">Value cannot be null or empty. - appAlias
        /// or
        /// Value cannot be null or empty. - versionAlias
        /// or
        /// Value cannot be null or empty. - componentAlias</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">minimumCount - Minimum count must be at least 1 instance</exception>
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

            if (minimumCount < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(minimumCount), "Minimum count must be at least 1 instance");
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
        /// Gets the component alias to configure scaling for
        /// </summary>
        public string ComponentAlias { get; }
    }
}