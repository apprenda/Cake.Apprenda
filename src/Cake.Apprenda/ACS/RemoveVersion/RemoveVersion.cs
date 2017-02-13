using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.ACS.RemoveVersion
{
    /// <summary>
    /// Connects to a cloud instance
    /// </summary>
    /// <seealso cref="Apprenda.ACSTool{RemoveVersionSettings}" />
    public sealed class RemoveVersion : ACSTool<RemoveVersionSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterCloud"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public RemoveVersion(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ACSToolResolver resolver)
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
