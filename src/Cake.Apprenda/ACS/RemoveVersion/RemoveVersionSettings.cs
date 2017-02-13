using System;

namespace Cake.Apprenda.ACS.RemoveVersion
{
    /// <summary>
    /// Contains settings used by <see cref="RemoveVersion"/>
    /// </summary>
    public sealed class RemoveVersionSettings : ACSSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveVersionSettings"/> class.
        /// </summary>
        /// <param name="appAlias">The application alias.</param>
        /// <param name="versionAlias">The application version alias.</param>
        public RemoveVersionSettings(string appAlias, string versionAlias)
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
        /// Gets or sets the version alias.
        /// </summary>
        /// <value>
        /// The version alias.
        /// </value>
        public string VersionAlias { get; }
    }
}