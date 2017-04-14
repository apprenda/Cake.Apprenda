using System;
using Cake.Core.IO;

namespace Cake.Apprenda.ACS.ExportManifest
{
    /// <summary>
    /// Contains settings used by <see cref="ExportManifest"/>
    /// </summary>
    public sealed class ExportManifestSettings : ACSSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExportManifestSettings" /> class.
        /// </summary>
        /// <param name="appAlias">The application alias.</param>
        /// <param name="versionAlias">The version alias.</param>
        /// <param name="manifestFile">The manifest file.</param>
        /// <exception cref="System.ArgumentException">Value cannot be null or empty. - appAlias
        /// or
        /// Value cannot be null or empty. - versionAlias</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when the manifest file is null</exception>
        public ExportManifestSettings(string appAlias, string versionAlias, FilePath manifestFile)
        {
            if (string.IsNullOrEmpty(appAlias))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(appAlias));
            }

            if (string.IsNullOrEmpty(versionAlias))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(versionAlias));
            }

            if (manifestFile == null)
            {
                throw new ArgumentNullException(nameof(manifestFile));
            }

            this.AppAlias = appAlias;
            this.VersionAlias = versionAlias;
            this.ManifestFile = manifestFile;
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
        /// Gets the destination <see cref="FilePath"/> to write the manifest file.
        /// </summary>
        public FilePath ManifestFile { get;  }

        /// <summary>
        /// Gets or sets a value indicating whether or not to overwrite the <seealso cref="ManifestFile"/> if it already exists.
        /// </summary>
        public bool Overwrite { get; set; }
    }
}