using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.ACS.DeProvisionAddOn
{
    /// <summary>
    /// De-Provisions an instance of the given add-on for your organization.
    /// </summary>
    /// <seealso cref="CloudShellTool{TSettings}" />
    public sealed class DeProvisionAddOn : CloudShellTool<DeProvisionAddOnSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeProvisionAddOn"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public DeProvisionAddOn(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ICloudShellToolResolver resolver)
            : base(fileSystem, environment, processRunner, tools, resolver)
        {
        }

        /// <summary>
        /// Executes the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Execute(DeProvisionAddOnSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (string.IsNullOrEmpty(settings.Alias))
            {
                throw new CakeException("Required setting Alias not specified.");
            }

            if (string.IsNullOrEmpty(settings.InstanceAlias))
            {
                throw new CakeException("Required setting InstanceAlias not specified.");
            }

            var builder = new ProcessArgumentBuilder();

            builder.Append("DeProvisionAddOn");
            builder.Append("--NonInteractive");
            builder.Append("-Y");

            builder.Append("-Alias");
            builder.AppendQuoted(settings.Alias);

            builder.Append("-InstanceAlias");
            builder.Append(settings.InstanceAlias);

            this.Run(settings, builder);
        }
    }
}