using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.ACS.NewApplication
{
    /// <summary>
    /// Connects to a cloud instance
    /// </summary>
    /// <seealso cref="Apprenda.ACSTool{NewApplicationSettings}" />
    public sealed class NewApplication : ACSTool<NewApplicationSettings>
    {
        private readonly IFileSystem _fileSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewApplication" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public NewApplication(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ACSToolResolver resolver)
            : base(fileSystem, environment, processRunner, tools, resolver)
        {
            this._fileSystem = fileSystem;
        }

        /// <summary>
        /// Executes the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Execute(NewApplicationSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (settings.ArchivePath != null && settings.SolutionPath != null)
            {
                throw new CakeException("ArchivePath and SolutionPath cannot be used together in the same operation. Please specify one or the other.");
            }

            if (settings.Stage.HasValue && settings.ArchivePath == null && settings.SolutionPath == null)
            {
                throw new CakeException("Stage can only be used when ArchivePath or SolutionPath are specified");
            }

            var builder = new ProcessArgumentBuilder();

            builder.Append("NewApplication");
            builder.Append("--NonInteractive");

            builder.Append("-AppName");
            builder.AppendQuoted(settings.AppName);

            builder.Append("-AppAlias");
            builder.AppendQuoted(settings.AppAlias);

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

                new BuildSettingsArgumentBuilder().Build(settings.BuildSettings, builder);
            }

            Run(settings, builder);
        }
    }
}
