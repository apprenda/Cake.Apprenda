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
    /// <seealso cref="Apprenda.ACSTool{GetAddOnsSettings}" />
    public sealed class GetAddOns : ACSTool<GetAddOnsSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAddOns"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public GetAddOns(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, ACSToolResolver resolver)
            : base(fileSystem, environment, processRunner, tools, resolver)
        {
        }

        /// <summary>
        /// Executes the GetDeployedAddOns command
        /// </summary>
        /// <returns></returns>
        public IEnumerable<AddOnInfo> Execute()
        {
            // TODO: most ideally, this would dump JSON output, but that functionality is currently broken in the tool itself.

            var builder = new ProcessArgumentBuilder();
            builder.Append("GetAddOns");

            var settings = new ProcessSettings { RedirectStandardOutput = true };

            var result = Enumerable.Empty<AddOnInfo>();
            Action<IProcess> postProcessor = process =>
            {
                result = new AddOnParser().ParseResults(process.GetStandardOutput());
            };

            Run(new GetAddOnsSettings(), builder, settings, postProcessor);

            return result;
        }
    }
}
