using System;
using System.Globalization;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.ACS.SetInstanceCount
{
    /// <summary>
    /// Scales the specified application component to the desired number of instances.
    /// </summary>
    /// <seealso cref="Apprenda.ACSTool{SetInstanceCountSettings}" />
    public sealed class SetInstanceCount : ACSTool<SetInstanceCountSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetInstanceCount"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public SetInstanceCount(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ACSToolResolver resolver)
            : base(fileSystem, environment, processRunner, tools, resolver) { }

        /// <summary>
        /// Executes the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Execute(SetInstanceCountSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var builder = new ProcessArgumentBuilder();

            builder.Append("SetInstanceCount");
            builder.Append("--NonInteractive");
            
            builder.Append("-AppAlias");
            builder.AppendQuoted(settings.AppAlias);

            builder.Append("-VersionAlias");
            builder.Append(settings.VersionAlias);
            
            builder.Append("-Component");
            builder.Append(settings.ComponentAlias);
            builder.Append(settings.ScalingExpression.Value);

            Run(settings, builder);
        }
    }
}
