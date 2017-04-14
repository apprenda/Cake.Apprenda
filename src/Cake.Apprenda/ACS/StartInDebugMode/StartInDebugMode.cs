using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.ACS.StartInDebugMode
{
    /// <summary>
    /// Removes all currently running instances of the component and starts a new instance in debug mode.
    /// </summary>
    /// <seealso cref="Apprenda.ACSTool{StartInDebugModeSettings}" />
    public sealed class StartInDebugMode : ACSTool<StartInDebugModeSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StartInDebugMode" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public StartInDebugMode(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ACSToolResolver resolver)
            : base(fileSystem, environment, processRunner, tools, resolver)
        {
        }

        /// <summary>
        /// Executes the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Execute(StartInDebugModeSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var builder = new ProcessArgumentBuilder();

            builder.Append("StartInDebugMode");
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
