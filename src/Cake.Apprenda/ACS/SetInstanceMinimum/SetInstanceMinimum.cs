using System;
using System.Globalization;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.ACS.SetInstanceMinimum
{
    /// <summary>
    /// Sets the minimum instance count for the specified application component to the desired number of instances.
    /// </summary>
    /// <seealso cref="CloudShellTool{TSettings}" />
    public sealed class SetInstanceMinimum : CloudShellTool<SetInstanceMinimumSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetInstanceMinimum" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public SetInstanceMinimum(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ICloudShellToolResolver resolver)
            : base(fileSystem, environment, processRunner, tools, resolver)
        {
        }

        /// <summary>
        /// Executes the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Execute(SetInstanceMinimumSettings settings)
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

            if (string.IsNullOrEmpty(settings.ComponentAlias))
            {
                throw new CakeException("Required setting ComponentAlias not specified.");
            }

            if (settings.MinimumCount < 1)
            {
                throw new CakeException("Minimum count must be at least 1 instance.");
            }

            var builder = new ProcessArgumentBuilder();

            builder.Append("SetInstanceMinimum");
            builder.Append("--NonInteractive");
            
            builder.Append("-AppAlias");
            builder.AppendQuoted(settings.AppAlias);

            builder.Append("-VersionAlias");
            builder.Append(settings.VersionAlias);
            
            builder.Append("-Component");
            builder.AppendQuoted(settings.ComponentAlias);

            builder.Append("-MinCount");
            builder.Append(settings.MinimumCount.ToString(CultureInfo.InvariantCulture));

            Run(settings, builder);
        }
    }
}
