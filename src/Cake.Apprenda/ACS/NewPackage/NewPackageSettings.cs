using System;
using Cake.Core.IO;

namespace Cake.Apprenda.ACS.NewPackage
{
    /// <summary>
    /// Contains settings used by <see cref="NewPackage"/>
    /// </summary>
    public sealed class NewPackageSettings : ACSSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewPackageSettings"/> class.
        /// </summary>
        /// <param name="solutionPath">The solution path.</param>
        /// <param name="archiveOutput">The archive output.</param>
        public NewPackageSettings(FilePath solutionPath, FilePath archiveOutput)
        {
            if (solutionPath == null)
            {
                throw new ArgumentNullException(nameof(solutionPath));
            }

            if (archiveOutput == null)
            {
                throw new ArgumentNullException(nameof(archiveOutput));
            }

            this.SolutionPath = solutionPath;
            this.ArchiveOutput = archiveOutput;
        }

        /// <summary>
        /// Gets or sets the <see cref="FilePath"/> to the solution file.
        /// </summary>
        /// <value>
        /// The solution path.
        /// </value>
        public FilePath SolutionPath { get; }

        /// <summary>
        /// Gets or sets the <see cref="FilePath"/> for the archive file to be written.
        /// </summary>
        /// <value>
        /// The archive output.
        /// </value>
        public FilePath ArchiveOutput { get; }

        /// <summary>
        /// Gets or sets the build settings to use when creating the package
        /// </summary>
        public BuildSettings BuildSettings { get; set; } = new BuildSettings();

    }
    
}