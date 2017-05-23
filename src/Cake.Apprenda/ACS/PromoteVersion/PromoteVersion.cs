using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.ACS.PromoteVersion
{
    /// <summary>
    /// Promotes a version of an application to the specified stage
    /// </summary>
    /// <seealso cref="CloudShellTool{TSettings}" />
    public sealed class PromoteVersion : CloudShellTool<PromoteVersionSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PromoteVersion" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public PromoteVersion(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ICloudShellToolResolver resolver)
            : base(fileSystem, environment, processRunner, tools, resolver)
        {
        }

        /// <summary>
        /// Executes the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Execute(PromoteVersionSettings settings)
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

            var builder = new ProcessArgumentBuilder();

            builder.Append("PromoteVersion");
            builder.Append("--NonInteractive");
            builder.Append("-Y");

            builder.Append("-AppAlias");
            builder.AppendQuoted(settings.AppAlias);

            builder.Append("-VersionAlias");
            builder.Append(settings.VersionAlias);

            if (settings.Stage.HasValue)
            {
                builder.Append("-Stage");
                builder.Append(Enum.GetName(typeof(ApplicationStage), settings.Stage));
            }

            Run(settings, builder);
        }
    }
}
