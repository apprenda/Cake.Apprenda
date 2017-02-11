using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.ACS.RegisterCloud
{
    /// <summary>
    /// Registers a cloud instance
    /// </summary>
    /// <seealso cref="Apprenda.ACSTool{RegisterCloudSettings}" />
    public sealed class RegisterCloud : ACSTool<RegisterCloudSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterCloud"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public RegisterCloud(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ACSToolResolver resolver)
            : base(fileSystem, environment, processRunner, tools, resolver)
        {
        }

        /// <summary>
        /// Executes the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Execute(RegisterCloudSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var builder = new ProcessArgumentBuilder();

            builder.Append("RegisterCloud");
            builder.Append("--NonInteractive");

            builder.Append("-Alias");
            builder.Append(settings.CloudAlias);

            builder.Append("-Url");
            builder.Append(settings.CloudUrl);

            Run(settings, builder);
        }
    }
}
