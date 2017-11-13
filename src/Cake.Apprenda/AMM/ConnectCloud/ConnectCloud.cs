using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.AMM.ConnectCloud
{
    /// <summary>
    /// Connects to a cloud instance
    /// </summary>
    /// <seealso cref="MaintenanceModeTool{TSettings}" />
    public sealed class ConnectCloud : MaintenanceModeTool<ConnectCloudSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectCloud" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public ConnectCloud(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, IMaintenanceModeToolResolver resolver)
            : base(fileSystem, environment, processRunner, tools, resolver)
        {
        }

        /// <summary>
        /// Executes the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Execute(ConnectCloudSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (string.IsNullOrEmpty(settings.CloudAlias))
            {
                throw new CakeException("Required setting CloudAlias not specified.");
            }

            if (string.IsNullOrEmpty(settings.User))
            {
                throw new CakeException("Required setting User not specified.");
            }

            if (string.IsNullOrEmpty(settings.Password))
            {
                throw new CakeException("Required setting Password not specified.");
            }

            var builder = new ProcessArgumentBuilder();

            builder.Append("ConnectCloud");
            builder.Append("--NonInteractive");

            builder.Append("-CloudAlias");
            builder.Append(settings.CloudAlias);

            builder.Append("-User");
            builder.Append(settings.User);

            builder.Append("-Password");
            builder.AppendSecret(settings.Password);

            this.Run(settings, builder);
        }
    }
}
