using System;

namespace Cake.Apprenda.ACS.DemoteVersion
{
    /// <summary>
    /// Contains settings used by <see cref="DemoteVersion"/>
    /// </summary>
    public sealed class DemoteVersionSettings : CloudShellSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DemoteVersionSettings" /> class.
        /// </summary>
        /// <param name="appAlias">The application alias.</param>
        /// <param name="versionAlias">The version alias.</param>
        /// <exception cref="System.ArgumentException">Value cannot be null or empty. - appAlias
        /// or
        /// Value cannot be null or empty. - versionAlias</exception>
        public DemoteVersionSettings(string appAlias, string versionAlias)
        {
            if (string.IsNullOrEmpty(appAlias))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(appAlias));
            }

            if (string.IsNullOrEmpty(versionAlias))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(versionAlias));
            }

            this.AppAlias = appAlias;
            this.VersionAlias = versionAlias;
        }

        /// <summary>
        /// Gets the application alias.
        /// </summary>
        /// <value>
        /// The application alias.
        /// </value>
        public string AppAlias { get; }

        /// <summary>
        /// Gets the version alias.
        /// </summary>
        /// <value>
        /// The version alias.
        /// </value>
        public string VersionAlias { get; }
    }
}