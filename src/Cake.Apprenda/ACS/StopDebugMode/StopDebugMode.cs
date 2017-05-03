using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.ACS.StopDebugMode
{
    /// <summary>
    /// Removes all currently running instances of the component and starts a new instance in debug mode.
    /// </summary>
    /// <seealso cref="CloudShellTool{TSettings}" />
    public sealed class StopDebugMode : CloudShellTool<StopDebugModeSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StopDebugMode" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public StopDebugMode(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, CloudShellToolResolver resolver)
            : base(fileSystem, environment, processRunner, tools, resolver)
        {
        }

        /// <summary>
        /// Executes the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Execute(StopDebugModeSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var builder = new ProcessArgumentBuilder();

            builder.Append("StopDebugMode");
            builder.Append("--NonInteractive");
            
            builder.Append("-AppAlias");
            builder.AppendQuoted(settings.AppAlias);

            builder.Append("-VersionAlias");
            builder.Append(settings.VersionAlias);

            if (!string.IsNullOrEmpty(settings.ComponentAlias))
            {
                builder.Append("-ComponentAlias");
                builder.AppendQuoted(settings.ComponentAlias);
            }

            Run(settings, builder);
        }
    }
}
