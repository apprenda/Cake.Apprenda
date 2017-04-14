using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.ACS.ExportManifest
{
    /// <summary>
    /// Demotes a version of an application to the specified stage
    /// </summary>
    /// <seealso cref="Apprenda.ACSTool{ExportManifestSettings}" />
    public sealed class ExportManifest : ACSTool<ExportManifestSettings>
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
        public ExportManifest(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ACSToolResolver resolver)
            : base(fileSystem, environment, processRunner, tools, resolver)
        {
            _fileSystem = fileSystem;
        }

        /// <summary>
        /// Executes the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Execute(ExportManifestSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
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
                throw new CakeException($"The manifest file specified at {manifestFile.Path.FullPath} exists and the Overwrite option has not been specified");
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
