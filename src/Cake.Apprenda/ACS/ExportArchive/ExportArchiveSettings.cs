using System;
using Cake.Core.IO;

namespace Cake.Apprenda.ACS.ExportArchive
{
    /// <summary>
    /// Contains settings used by <see cref="ExportArchive"/>
    /// </summary>
    public sealed class ExportArchiveSettings : ACSSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExportArchiveSettings" /> class.
        /// </summary>
        /// <param name="appAlias">The application alias.</param>
        /// <param name="versionAlias">The version alias.</param>
        /// <param name="archiveFile">The archive file.</param>
        /// <exception cref="System.ArgumentException">Value cannot be null or empty. - appAlias
        /// or
        /// Value cannot be null or empty. - versionAlias</exception>
        public ExportArchiveSettings(string appAlias, string versionAlias, FilePath archiveFile)
        {
            if (string.IsNullOrEmpty(appAlias))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(appAlias));
            }

            if (string.IsNullOrEmpty(versionAlias))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(versionAlias));
            }

            if (archiveFile == null)
            {
                throw new ArgumentNullException(nameof(archiveFile));
            }

            this.AppAlias = appAlias;
            this.VersionAlias = versionAlias;
            this.ArchiveFile = archiveFile;
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
        public FilePath ArchiveFile { get;  }

        /// <summary>
        /// Gets or sets a value indicating whether or not to overwrite the <seealso cref="ArchiveFile"/> if it already exists.
        /// </summary>
        public bool Overwrite { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to exclude the application manifest from the archive.
        /// </summary>
        public bool ExcludeManifest { get; set; }
    }
}