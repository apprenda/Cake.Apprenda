using System;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.ACS.ProvisionAddOn
{
    /// <summary>
    /// Provisions a new instance of the given add-on for your organization.
    /// </summary>
    /// <seealso cref="Apprenda.ACSTool{ProvisionAddOnSettings}" />
    public sealed class ProvisionAddOn : ACSTool<ProvisionAddOnSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProvisionAddOn"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public ProvisionAddOn(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ACSToolResolver resolver)
            : base(fileSystem, environment, processRunner, tools, resolver)
        {
        }

        /// <summary>
        /// Executes the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Execute(ProvisionAddOnSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var builder = new ProcessArgumentBuilder();

            builder.Append("ProvisionAddOn");
            builder.Append("--NonInteractive");

            builder.Append("-Alias");
            builder.AppendQuoted(settings.Alias);

            builder.Append("-InstanceAlias");
            builder.Append(settings.InstanceAlias);

            if (!string.IsNullOrWhiteSpace(settings.Options))
            {
                builder.Append("-Options");
                builder.AppendQuoted(settings.Options);
            }

            if (settings.Parameters != null && settings.Parameters.Any())
            {
                builder.Append("-Params");
                foreach (var kvp in settings.Parameters)
                {
                    builder.Append($"-{kvp.Key}");
                    builder.AppendQuoted(kvp.Value);
                }
            }

            this.Run(settings, builder);
        }
    }
}