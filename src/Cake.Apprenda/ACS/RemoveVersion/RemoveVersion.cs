using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.ACS.RemoveVersion
{
    /// <summary>
    /// Connects to a cloud instance
    /// </summary>
    /// <seealso cref="CloudShellTool{TSettings}" />
    public sealed class RemoveVersion : CloudShellTool<RemoveVersionSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveVersion" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public RemoveVersion(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ICloudShellToolResolver resolver)
            : base(fileSystem, environment, processRunner, tools, resolver)
        {
        }

        /// <summary>
        /// Executes the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Execute(RemoveVersionSettings settings)
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

            builder.Append("RemoveVersion");
            builder.Append("--NonInteractive");

            builder.Append("-AppAlias");
            builder.Append(settings.AppAlias);

            builder.Append("-VersionAlias");
            builder.Append(settings.VersionAlias);

            Run(settings, builder);
        }
    }
}
