using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.AMM.SetNodeState
{
    /// <summary>
    /// Sets the state of a node in the cloud
    /// </summary>
    /// <seealso cref="MaintenanceModeTool{TSettings}" />
    public sealed class SetNodeState : MaintenanceModeTool<SetNodeStateSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetNodeState"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public SetNodeState(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, IMaintenanceModeToolResolver resolver)
            : base(fileSystem, environment, processRunner, tools, resolver)
        {
        }

        /// <summary>
        /// Executes the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <exception cref="System.ArgumentNullException">Thrown if the settings are null</exception>
        /// <exception cref="CakeException">
        /// Required setting HostName not specified.
        /// or
        /// Required setting Reason not specified.
        /// or
        /// Node state cannot be transitioned to 'Unknown'.
        /// or
        /// Invalid node state value specified.
        /// </exception>
        public void Execute(SetNodeStateSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (string.IsNullOrEmpty(settings.HostName))
            {
                throw new CakeException("Required setting HostName not specified.");
            }

            if (string.IsNullOrEmpty(settings.Reason))
            {
                throw new CakeException("Required setting Reason not specified.");
            }

            if (settings.State == NodeState.Unknown)
            {
                throw new CakeException("Node state cannot be transitioned to 'Unknown'.");
            }

            if (!Enum.IsDefined(typeof(NodeState), settings.State))
            {
                throw new CakeException("Invalid node state value specified.");
            }

            var builder = new ProcessArgumentBuilder();

            builder.Append("SetNodeState");
            builder.Append("--NonInteractive");

            builder.Append("-Hostname");
            builder.Append(settings.HostName);

            builder.Append("-State");
            builder.Append(Enum.GetName(typeof(NodeState), settings.State));

            builder.Append("-Reason");
            builder.AppendQuoted(settings.Reason);
            
            this.Run(settings, builder);
        }
    }
}
