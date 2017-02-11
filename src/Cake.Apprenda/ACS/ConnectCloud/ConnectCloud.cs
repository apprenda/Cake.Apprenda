using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.ACS.ConnectCloud
{
    /// <summary>
    /// Connects to a cloud instance
    /// </summary>
    /// <seealso cref="Apprenda.ACSTool{ConnectCloudSettings}" />
    public sealed class ConnectCloud : ACSTool<ConnectCloudSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterCloud"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public ConnectCloud(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ACSToolResolver resolver)
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

            var builder = new ProcessArgumentBuilder();

            builder.Append("ConnectCloud");
            builder.Append("--NonInteractive");

            builder.Append("-CloudAlias");
            builder.Append(settings.CloudAlias);

            builder.Append("-User");
            builder.Append(settings.User);

            builder.Append("-Password");
            builder.Append(settings.Password);

            if (!string.IsNullOrEmpty(settings.DevTeamAlias))
            {
                builder.Append("-DevTeamAlias");
                builder.Append(settings.DevTeamAlias);
            }

            Run(settings, builder);
        }
    }
}
