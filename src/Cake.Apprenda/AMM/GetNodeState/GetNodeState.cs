using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.AMM.GetNodeState
{
    /// <summary>
    /// Gets the state of a node in the cloud
    /// </summary>
    /// <seealso cref="MaintenanceModeTool{TSettings}" />
    public sealed class GetNodeState : MaintenanceModeTool<GetNodeStateSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetNodeState"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public GetNodeState(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, IMaintenanceModeToolResolver resolver)
            : base(fileSystem, environment, processRunner, tools, resolver)
        {
        }

        /// <summary>
        /// Executes the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>Returns the <see cref="NodeState"/> of the specified host</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the settings are null</exception>
        /// <exception cref="CakeException">Required setting HostName not specified.</exception>
        public NodeState Execute(GetNodeStateSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (string.IsNullOrEmpty(settings.HostName))
            {
                throw new CakeException("Required setting HostName not specified.");
            }

            var builder = new ProcessArgumentBuilder();

            builder.Append("GetNodeState");
            builder.Append("--NonInteractive");

            builder.Append("-Hostname");
            builder.Append(settings.HostName);

            var processSettings = new ProcessSettings { RedirectStandardOutput = true };

            var result = NodeState.Unknown;
            Action<IProcess> postProcessor = process =>
            {
                var lines = process.GetStandardOutput()?.ToList();
                if (lines != null && lines.Any())
                {
                    result = ParseResults(lines);
                }
            };

            this.Run(settings, builder, processSettings, postProcessor);

            return result;
        }

        private static NodeState ParseResults(IEnumerable<string> standardOutput)
        {
            return new GetNodeStateResultParser().Parse(standardOutput);
        }
    }
}
