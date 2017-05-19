using System;
using Cake.Core.IO;

namespace Cake.Apprenda.ACS.PatchVersion
{
    /// <summary>
    /// Contains settings used by <see cref="PatchVersion"/>
    /// </summary>
    public sealed class PatchVersionSettings : CloudShellSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PatchVersionSettings"/> class.
        /// </summary>
        public PatchVersionSettings()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PatchVersionSettings" /> class.
        /// </summary>
        /// <param name="appAlias">The application alias.</param>
        /// <param name="versionAlias">The version alias.</param>
        /// <exception cref="System.ArgumentException">Value cannot be null or empty. - appAlias
        /// or
        /// Value cannot be null or empty. - versionAlias</exception>
        public PatchVersionSettings(string appAlias, string versionAlias)
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
        /// <value>
        /// The application alias.
        /// </value>
        public string AppAlias { get; set; }

        /// <summary>
        /// Gets or sets the version alias.
        /// </summary>
        /// <value>
        /// The version alias.
        /// </value>
        public string VersionAlias { get; set; }

        /// <summary>
        /// Gets or sets the new version alias.
        /// </summary>
        /// <value>
        /// The new version alias.
        /// </value>
        public string NewVersionAlias { get; set; }

        /// <summary>
        /// Gets or sets the new name of the version.
        /// </summary>
        /// <value>
        /// The new name of the version.
        /// </value>
        public string NewVersionName { get; set; }

        /// <summary>
        /// Gets or sets the initial application stage.
        /// </summary>
        /// <value>
        /// The stage.
        /// </value>
        public ApplicationStage? Stage { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="FilePath"/> to an archive file.  Cannot be used in conjunction with <seealso cref="SolutionPath"/>
        /// </summary>
        /// <value>
        /// The package path.
        /// </value>
        public FilePath ArchivePath { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="FilePath"/> to the solution file.  Cannot be used in conjunction with <seealso cref="ArchivePath"/>
        /// </summary>
        /// <value>
        /// The solution path.
        /// </value>
        public FilePath SolutionPath { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the patch should be constructive or not.  The default is destructive patching.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is constructive; otherwise, <c>false</c>.
        /// </value>
        public bool IsConstructive { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="FilePath"/> for the archive file to be written.
        /// </summary>
        /// <value>
        /// The archive output.
        /// </value>
        public FilePath ArchiveOutput { get; set; }

        /// <summary>
        /// Gets or sets the build settings to use when creating the package
        /// </summary>
        public BuildSettings BuildSettings { get; set; } = new BuildSettings();
    }
}