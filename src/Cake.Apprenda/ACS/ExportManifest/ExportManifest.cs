using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.ACS.ExportManifest
{
    /// <summary>
    /// Exports the manifest file for a given application version.
    /// </summary>
    /// <seealso cref="CloudShellTool{TSettings}" />
    public sealed class ExportManifest : CloudShellTool<ExportManifestSettings>
    {
        private readonly IFileSystem _fileSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportManifest" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public ExportManifest(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ICloudShellToolResolver resolver)
            : base(fileSystem, environment, processRunner, tools, resolver)
        {
            _fileSystem = fileSystem;
        }

        /// <summary>
        /// Executes the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <exception cref="System.ArgumentNullException">Thrown if the settings is null</exception>
        /// <exception cref="CakeException">
        /// Required setting AppAlias not specified.
        /// or
        /// Required setting VersionAlias not specified.
        /// or
        /// Required setting ManifestFile not specified.
        /// </exception>
        public void Execute(ExportManifestSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (string.IsNullOrEmpty(settings.AppAlias))
            {
                throw new CakeException("Required setting AppAlias not specified.");
            }

            if (string.IsNullOrEmpty(settings.VersionAlias))
            {
                throw new CakeException("Required setting VersionAlias not specified.");
            }

            if (settings.ManifestFile == null)
            {
                throw new CakeException("Required setting ManifestFile not specified.");
            }

            var builder = new ProcessArgumentBuilder();

            builder.Append("ExportManifest");
            builder.Append("--NonInteractive");
            
            builder.Append("-AppAlias");
            builder.AppendQuoted(settings.AppAlias);

            builder.Append("-VersionAlias");
            builder.Append(settings.VersionAlias);

            var manifestFile = _fileSystem.GetFile(settings.ManifestFile);
            if (manifestFile.Exists && !settings.Overwrite)
            {
                throw new CakeException($"The manifest file specified at '{manifestFile.Path.FullPath}' exists and the Overwrite option has not been specified.");
            }

            builder.Append("-Manifest");
            builder.AppendQuoted(manifestFile.Path.FullPath);

            if (settings.Overwrite)
            {
                builder.Append("-Overwrite");
            }

            Run(settings, builder);
        }
    }
}
