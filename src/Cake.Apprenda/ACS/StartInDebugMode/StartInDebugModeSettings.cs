using System;

namespace Cake.Apprenda.ACS.StartInDebugMode
{
    /// <summary>
    /// Contains settings used by <see cref="StartInDebugMode"/>
    /// </summary>
    public sealed class StartInDebugModeSettings : CloudShellSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StartInDebugModeSettings"/> class.
        /// </summary>
        public StartInDebugModeSettings()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StartInDebugModeSettings" /> class.
        /// </summary>
        /// <param name="appAlias">The application alias.</param>
        /// <param name="versionAlias">The version alias.</param>
        /// <exception cref="System.ArgumentException">
        /// Value cannot be null or empty. - appAlias
        /// or
        /// Value cannot be null or empty. - versionAlias
        /// </exception>
        public StartInDebugModeSettings(string appAlias, string versionAlias)
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
        /// Gets or sets the application alias.
        /// </summary>
        public string AppAlias { get; set; }

        /// <summary>
        /// Gets or sets the version alias.
        /// </summary>
        public string VersionAlias { get; set; }

        /// <summary>
        /// Gets or sets the component alias.
        /// </summary>
        public string ComponentAlias { get; set; }
    }
}