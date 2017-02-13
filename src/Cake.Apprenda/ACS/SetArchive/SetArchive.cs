using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.ACS.SetArchive
{
    /// <summary>
    /// Connects to a cloud instance
    /// </summary>
    /// <seealso cref="Apprenda.ACSTool{NewPackageSettings}" />
    public sealed class SetArchive : ACSTool<SetArchiveSettings>
    {
        private readonly IFileSystem _fileSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterCloud"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public SetArchive(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ACSToolResolver resolver)
            : base(fileSystem, environment, processRunner, tools, resolver)
        {
            this._fileSystem = fileSystem;
        }

        /// <summary>
        /// Executes the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Execute(SetArchiveSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (settings.ArchivePath != null && settings.SolutionPath != null)
            {
                throw new CakeException("ArchivePath and SolutionPath cannot be used together in the same operation. Please specify one or the other.");
            }

            if (settings.ArchivePath == null && settings.SolutionPath == null)
            {
                throw new CakeException("You must specify either ArchivePath or SolutionPath.");
            }

            var builder = new ProcessArgumentBuilder();

            builder.Append("SetArchive");
            builder.Append("--NonInteractive");
            
            builder.Append("-AppAlias");
            builder.AppendQuoted(settings.AppAlias);

            builder.Append("-VersionAlias");
            builder.Append(settings.VersionAlias);
            
            if (settings.ArchivePath != null)
            {
                var file = this._fileSystem.GetFile(settings.ArchivePath);
                if (!file.Exists)
                {
                    throw new CakeException($"File {settings.ArchivePath} specified for ArchivePath argument does not exist");
                }

                builder.Append("-Package");
                builder.AppendQuoted(file.Path.FullPath);
            }

            if (settings.SolutionPath != null)
            {
                var file = this._fileSystem.GetFile(settings.SolutionPath);
                if (!file.Exists)
                {
                    throw new CakeException($"File {settings.SolutionPath} specified for SolutionPath argument does not exist");
                }

                builder.Append("-Path");
                builder.AppendQuoted(file.Path.FullPath);
            }

            if (settings.IsConstructive)
            {
                builder.Append("-Constructive");
            }

            if (settings.ArchiveOutput != null)
            {
                var file = this._fileSystem.GetFile(settings.ArchiveOutput);

                builder.Append("-O");
                builder.AppendQuoted(file.Path.FullPath);
            }

            Run(settings, builder);
        }
    }
}
