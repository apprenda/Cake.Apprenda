using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.ACS.GetDeployedAddOns
{
    /// <summary>
    /// Used to retrieve a list of the add-ons deployed to the connected Apprenda cloud.
    /// </summary>
    /// <seealso cref="CloudShellTool{TSettings}" />
    public sealed class GetDeployedAddOns : CloudShellTool<GetDeployedAddOnsSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetDeployedAddOns"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public GetDeployedAddOns(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ICloudShellToolResolver resolver)
            : base(fileSystem, environment, processRunner, tools, resolver)
        {
        }

        /// <summary>
        /// Executes the GetDeployedAddOn command
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>
        /// The collection of <see cref="DeployedAddOnInfo" /> items
        /// </returns>
        /// <exception cref="System.ArgumentNullException">Thrown if settings is null</exception>
        public IEnumerable<DeployedAddOnInfo> Execute(GetDeployedAddOnsSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            // TODO: most ideally, this would dump JSON output, but that functionality is currently broken in the tool itself.
            var builder = new ProcessArgumentBuilder();
            builder.Append("GetDeployedAddOns");

            var processSettings = new ProcessSettings { RedirectStandardOutput = true };

            var result = Enumerable.Empty<DeployedAddOnInfo>();
            Action<IProcess> postProcessor = process =>
            {
                result = new DeployedAddOnParser().ParseResults(process.GetStandardOutput());
            };

            Run(settings, builder, processSettings, postProcessor);

            return result;
        }
    }
}
