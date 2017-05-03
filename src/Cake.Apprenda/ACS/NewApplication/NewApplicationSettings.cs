using System;
using Cake.Core.IO;

namespace Cake.Apprenda.ACS.NewApplication
{
    /// <summary>
    /// Contains settings used by <see cref="NewApplication"/>
    /// </summary>
    public sealed class NewApplicationSettings : CloudShellSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewApplicationSettings"/> class.
        /// </summary>
        /// <param name="appName">Name of the application.</param>
        /// <param name="appAlias">The application alias.</param>
        public NewApplicationSettings(string appName, string appAlias)
        {
            if (string.IsNullOrEmpty(appName))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(appName));
            }
            if (string.IsNullOrEmpty(appAlias))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(appAlias));
            }

            this.AppName = appName;
            this.AppAlias = appAlias;
        }

        /// <summary>
        /// Gets the name of the application.
        /// </summary>
        /// <value>
        /// The name of the application.
        /// </value>
        public string AppName { get; }

        /// <summary>
        /// Gets the application alias.
        /// </summary>
        /// <value>
        /// The application alias.
        /// </value>
        public string AppAlias { get; }

        /// <summary>
        /// Gets or sets the application description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

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
        /// Gets or sets the build settings to use when creating the package
        /// </summary>
        public BuildSettings BuildSettings { get; set; } = new BuildSettings();
    }
}