using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.ACS.NewPackage
{
    /// <summary>
    /// Creates a new archive from a Visual Studio solution
    /// </summary>
    /// <seealso cref="CloudShellTool{TSettings}" />
    public sealed class NewPackage : CloudShellTool<NewPackageSettings>
    {
        private readonly IFileSystem _fileSystem;

        /// <summary>
        /// Initializes a new instance of the <see cref="NewPackage"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public NewPackage(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, CloudShellToolResolver resolver)
            : base(fileSystem, environment, processRunner, tools, resolver)
        {
            this._fileSystem = fileSystem;
        }

        /// <summary>
        /// Executes the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Execute(NewPackageSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var builder = new ProcessArgumentBuilder();

            builder.Append("NewPackage");
            builder.Append("--NonInteractive");
           
            this.PopulateSolutionFile(settings, builder);

            this.PopulateArchiveFile(settings, builder);

            new BuildSettingsArgumentBuilder().Build(settings.BuildSettings, builder);
            
            Run(settings, builder);
        }

        private void PopulateArchiveFile(NewPackageSettings settings, ProcessArgumentBuilder builder)
        {
            var archiveFile = this._fileSystem.GetFile(settings.ArchiveOutput);
            builder.Append("-O");
            builder.AppendQuoted(archiveFile.Path.FullPath);
        }

        private void PopulateSolutionFile(NewPackageSettings settings, ProcessArgumentBuilder builder)
        {
            var solutionFile = this._fileSystem.GetFile(settings.SolutionPath);
            if (!solutionFile.Exists)
            {
                throw new CakeException($"File {settings.SolutionPath} specified for SolutionPath argument does not exist");
            }

            builder.Append("-Sln");
            builder.AppendQuoted(solutionFile.Path.FullPath);
        }
    }
}
