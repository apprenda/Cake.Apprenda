using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.ACS.DisconnectCloud
{
    /// <summary>
    /// Disconnects from a cloud instance
    /// </summary>
    /// <seealso cref="Apprenda.ACSTool{DisconnectCloudSettings}" />
    public sealed class DisconnectCloud : ACSTool<DisconnectCloudSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterCloud"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public DisconnectCloud(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ACSToolResolver resolver)
            : base(fileSystem, environment, processRunner, tools, resolver)
        {
        }

        /// <summary>
        /// Executes the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Execute(DisconnectCloudSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var builder = new ProcessArgumentBuilder();

            builder.Append("DisconnectCloud");
            builder.Append("--NonInteractive");

            builder.Append("-Y");

            Run(settings, builder);
        }
    }
}
