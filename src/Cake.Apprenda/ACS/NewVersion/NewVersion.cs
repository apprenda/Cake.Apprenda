using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.ACS.NewVersion
{
    /// <summary>
    /// Connects to a cloud instance
    /// </summary>
    /// <seealso cref="CloudShellTool{TSettings}" />
    public sealed class NewVersion : CloudShellTool<NewVersionSettings>
    {
        private readonly IFileSystem _fileSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewVersion" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public NewVersion(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ICloudShellToolResolver resolver)
            : base(fileSystem, environment, processRunner, tools, resolver)
        {
            this._fileSystem = fileSystem;
        }

        /// <summary>
        /// Executes the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Execute(NewVersionSettings settings)
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

            if (settings.ArchivePath != null && settings.SolutionPath != null)
            {
                throw new CakeException("ArchivePath and SolutionPath cannot be used together in the same operation. Please specify one or the other.");
            }

            if (settings.Stage.HasValue && settings.ArchivePath == null && settings.SolutionPath == null)
            {
                throw new CakeException("Stage can only be used when ArchivePath or SolutionPath are specified.");
            }

            var builder = new ProcessArgumentBuilder();

            builder.Append("NewVersion");
            builder.Append("--NonInteractive");
            
            builder.Append("-AppAlias");
            builder.AppendQuoted(settings.AppAlias);

            builder.Append("-VersionAlias");
            builder.Append(settings.VersionAlias);

            if (!string.IsNullOrEmpty(settings.VersionName))
            {
                builder.Append("-VersionName");
                builder.AppendQuoted(settings.VersionName);
            }

            if (!string.IsNullOrEmpty(settings.Description))
            {
                builder.Append("-Description");
                builder.AppendQuoted(settings.Description);
            }
            
            // The initial stage this version should be promoted to.Valid values are 'Definition'(default), 'Sandbox' or 'Published'.
            // Only valid when - Package or - Path are used.
            if (settings.Stage.HasValue && settings.Stage.Value != ApplicationStage.Definition && (settings.ArchivePath != null || settings.SolutionPath != null))
            {
                builder.Append("-Stage");
                builder.Append(Enum.GetName(typeof(ApplicationStage), settings.Stage));
            }

            if (settings.ArchivePath != null)
            {
                var file = this._fileSystem.GetFile(settings.ArchivePath);
                if (!file.Exists)
                {
                    throw new CakeException($"File '{settings.ArchivePath}' specified for ArchivePath argument does not exist.");
                }

                builder.Append("-Package");
                builder.AppendQuoted(file.Path.FullPath);
            }

            if (settings.SolutionPath != null)
            {
                var file = this._fileSystem.GetFile(settings.SolutionPath);
                if (!file.Exists)
                {
                    throw new CakeException($"File '{settings.SolutionPath}' specified for SolutionPath argument does not exist.");
                }

                builder.Append("-Path");
                builder.AppendQuoted(file.Path.FullPath);

                new BuildSettingsArgumentBuilder().Build(settings.BuildSettings, builder);
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
