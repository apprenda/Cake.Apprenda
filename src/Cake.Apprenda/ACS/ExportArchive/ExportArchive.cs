using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.ACS.ExportArchive
{
    /// <summary>
    /// Exports the application archive file for a given application version.
    /// </summary>
    /// <seealso cref="CloudShellTool{TSettings}" />
    public sealed class ExportArchive : CloudShellTool<ExportArchiveSettings>
    {
        private readonly IFileSystem _fileSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportArchive"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public ExportArchive(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ICloudShellToolResolver resolver)
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
        /// Required setting ArchiveFile not specified.
        /// </exception>
        public void Execute(ExportArchiveSettings settings)
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

            if (settings.ArchiveFile == null)
            {
                throw new CakeException("Required setting ArchiveFile not specified.");
            }

            var builder = new ProcessArgumentBuilder();

            builder.Append("ExportArchive");
            builder.Append("--NonInteractive");
            
            builder.Append("-AppAlias");
            builder.AppendQuoted(settings.AppAlias);

            builder.Append("-VersionAlias");
            builder.Append(settings.VersionAlias);

            var archiveFile = _fileSystem.GetFile(settings.ArchiveFile);
            if (archiveFile.Exists && !settings.Overwrite)
            {
                throw new CakeException($"The archive file specified at '{archiveFile.Path.FullPath}' exists and the Overwrite option has not been specified.");
            }

            if (!string.Equals(".zip", archiveFile.Path.GetExtension(), StringComparison.OrdinalIgnoreCase))
            {
                throw new CakeException($"The archive file specified at '{archiveFile.Path.FullPath}' does not appear to be a valid zip file name.");
            }

            builder.Append("-Package");
            builder.AppendQuoted(archiveFile.Path.FullPath);

            if (settings.Overwrite)
            {
                builder.Append("-Overwrite");
            }

            if (settings.ExcludeManifest)
            {
                builder.Append("-ExcludeManifest");
            }

            Run(settings, builder);
        }
    }
}
