using System;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.AMM
{
    /// <summary>
    /// Provides a resolution mechanism for resolving the <see cref="FilePath"/> of the Apprenda AMM tool
    /// </summary>
    public interface IMaintenanceModeToolResolver
    {
        /// <summary>
        /// Resolves the path for the ACS.exe tool
        /// </summary>
        /// <returns>Returns the file path for the ACS.exe tool</returns>
        FilePath ResolvePath();
    }

    /// <summary>
    /// Resolves the <see cref="FilePath"/> of the Apprenda AMM tool
    /// </summary>
    /// <seealso cref="Cake.Apprenda.AMM.IMaintenanceModeToolResolver" />
    public sealed class MaintenanceModeToolResolver : IMaintenanceModeToolResolver
    {
        private const string AmmExe = "amm.exe";

        private readonly IFileSystem _fileSystem;
        private readonly ICakeEnvironment _environment;
        private readonly IToolLocator _tools;

        /// <summary>
        /// Initializes a new instance of the <see cref="MaintenanceModeToolResolver"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="tools">The tool locator</param>
        /// <exception cref="System.ArgumentNullException">
        /// fileSystem
        /// or
        /// environment
        /// </exception>
        public MaintenanceModeToolResolver(IFileSystem fileSystem, ICakeEnvironment environment, IToolLocator tools)
        {
            if (fileSystem == null)
            {
                throw new ArgumentNullException(nameof(fileSystem));
            }
            if (environment == null)
            {
                throw new ArgumentNullException(nameof(environment));
            }
            if (tools == null)
            {
                throw new ArgumentNullException(nameof(tools));
            }

            _fileSystem = fileSystem;
            _environment = environment;
            _tools = tools;
        }

        /// <inheritdoc />
        public FilePath ResolvePath()
        {
            var file = this.SafeResolvePath();
            return file.Path;
        }

        private IFile SafeResolvePath()
        {
            // Try to resolve it with the regular tool resolver.
            var toolsExe = _tools.Resolve(AmmExe);
            if (toolsExe != null)
            {
                var toolsFile = _fileSystem.GetFile(toolsExe);
                if (toolsFile.Exists)
                {
                    return toolsFile;
                }
            }

            // Check if path set to environment variable
            var acsFolder = _environment.GetEnvironmentVariable("ApprendaAMMInstall");
            if (!string.IsNullOrWhiteSpace(acsFolder))
            {
                var envFile = _fileSystem.GetFile(System.IO.Path.Combine(acsFolder, AmmExe));
                if (envFile.Exists)
                {
                    return envFile;
                }
            }

            // try looking in locationes defined in PATH
            var envPath = _environment.GetEnvironmentVariable("path");
            if (!string.IsNullOrWhiteSpace(envPath))
            {
                var pathFile = envPath
                    .Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(path => _fileSystem.GetDirectory(path))
                    .Where(path => path.Exists)
                    .Select(path => path.Path.CombineWithFilePath(AmmExe))
                    .Select(_fileSystem.GetFile)
                    .FirstOrDefault(file => file.Exists);

                if (pathFile != null)
                {
                    return pathFile;
                }
            }

            throw new CakeException($"Could not locate {AmmExe}.");
        }
    }
}