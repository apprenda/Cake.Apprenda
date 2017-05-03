using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.ACS.ReadRegisteredClouds
{
    /// <summary>
    /// Reads the clouds registered with ACS
    /// </summary>
    /// <seealso cref="CloudShellTool{TSettings}" />
    public sealed class ReadRegisteredClouds : CloudShellTool<ReadRegisteredCloudsSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReadRegisteredClouds"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public ReadRegisteredClouds(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, CloudShellToolResolver resolver)
            : base(fileSystem, environment, processRunner, tools, resolver)
        {
        }

        /// <summary>
        /// Executes the ReadRegisteredCloud command
        /// </summary>
        /// <returns>Returns the list of <see cref="CloudInfo"/> registered clouds</returns>
        public IEnumerable<CloudInfo> Execute()
        {
            var builder = new ProcessArgumentBuilder();
            builder.Append("ReadRegisteredClouds");

            var settings = new ProcessSettings { RedirectStandardOutput = true };

            var result = Enumerable.Empty<CloudInfo>();
            Action<IProcess> postProcessor = process =>
            {
                result = ParseResults(process.GetStandardOutput());
            };

            Run(new ReadRegisteredCloudsSettings(), builder, settings, postProcessor);

            return result;
        }

        /// <summary>
        /// Parses results from standard output
        /// </summary>
        /// <param name="standardOutput">The standard output.</param>
        /// <returns>Returns the parsed <see cref="CloudInfo"/> results</returns>
        public IEnumerable<CloudInfo> ParseResults(IEnumerable<string> standardOutput)
        {
            foreach (var line in standardOutput.Skip(1))
            {
                var tokens = line.Split(new[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries);
                yield return new CloudInfo(tokens[0], tokens[1]);
            }
        }
    }
}
