using System;
using System.Collections.Generic;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.AMM
{
    /// <summary>
    /// The Apprenda AMM tool used to manage Apprenda Cloud Platform
    /// </summary>
    /// <typeparam name="TSettings">The type of the settings.</typeparam>
    /// <seealso cref="Cake.Core.Tooling.Tool{TSettings}" />
    public abstract class MaintenanceModeTool<TSettings> : Tool<TSettings> where TSettings : ToolSettings
    {
        private readonly IMaintenanceModeToolResolver _resolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="MaintenanceModeTool{TSettings}" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when resolver is null</exception>
        protected MaintenanceModeTool(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, IMaintenanceModeToolResolver resolver)
            : base(fileSystem, environment, processRunner, tools)
        {
            if (resolver == null)
            {
                throw new ArgumentNullException(nameof(resolver));
            }
            _resolver = resolver;
        }

        /// <inheritdoc />
        protected override string GetToolName()
        {
            return "Apprenda AMM";
        }

        /// <inheritdoc />
        protected override IEnumerable<string> GetToolExecutableNames()
        {
            return new[] { "AMM.exe", "amm.exe" };
        }

        /// <summary>
        /// Gets alternative file paths which the tool may exist in
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <returns>The default tool path.</returns>
        protected sealed override IEnumerable<FilePath> GetAlternativeToolPaths(TSettings settings)
        {
            var path = _resolver.ResolvePath();
            return path != null ? new[] { path } : Enumerable.Empty<FilePath>();
        }
    }
}
