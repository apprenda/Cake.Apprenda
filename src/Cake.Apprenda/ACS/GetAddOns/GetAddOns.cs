using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.ACS.GetAddOns
{
    /// <summary>
    /// Used to retrieve a list of add-ons on the connected Apprenda Cloud.
    /// </summary>
    /// <seealso cref="CloudShellTool{TSettings}" />
    public sealed class GetAddOns : CloudShellTool<GetAddOnsSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAddOns"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public GetAddOns(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ICloudShellToolResolver resolver)
            : base(fileSystem, environment, processRunner, tools, resolver)
        {
        }

        /// <summary>
        /// Executes the GetDeployedAddOns command
        /// </summary>
        /// <param name="settings">The settings to use to retrieve the add-ons</param>
        /// <returns>Returns the list of <see cref="AddOnInfo"/> items</returns>
        public IEnumerable<AddOnInfo> Execute(GetAddOnsSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            // TODO: most ideally, this would dump JSON output, but that functionality is currently broken in the tool itself.
            var builder = new ProcessArgumentBuilder();
            builder.Append("GetAddOns");

            var processSettings = new ProcessSettings { RedirectStandardOutput = true };

            var result = Enumerable.Empty<AddOnInfo>();
            Action<IProcess> postProcessor = process =>
            {
                result = new AddOnParser().ParseResults(process.GetStandardOutput());
            };

            Run(settings, builder, processSettings, postProcessor);

            return result;
        }
    }
}
