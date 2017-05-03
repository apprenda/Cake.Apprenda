using System;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda
{
    /// <summary>
    /// Provides a resolution mechanism for resolving the <see cref="FilePath"/> of the Apprenda ACS tool
    /// </summary>
    public interface ICloudShellToolResolver
    {
        /// <summary>
        /// Resolves the path for the ACS.exe tool
        /// </summary>
        /// <returns>Returns the file path for the ACS.exe tool</returns>
        FilePath ResolvePath();
    }

    /// <summary>
    /// Resolves the <see cref="FilePath"/> of the Apprenda ACS tool
    /// </summary>
    public sealed class CloudShellToolResolver : ICloudShellToolResolver
    {
        private const string AcsExe = "acs.exe";

        private readonly IFileSystem _fileSystem;
        private readonly ICakeEnvironment _environment;
        private readonly IToolLocator _tools;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudShellToolResolver"/> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="tools">The tool locator</param>
        /// <exception cref="System.ArgumentNullException">
        /// fileSystem
        /// or
        /// environment
        /// </exception>
        public CloudShellToolResolver(IFileSystem fileSystem, ICakeEnvironment environment, IToolLocator tools)
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
            var file = SafeResolvePath();
            return file.Path;
        }

        private IFile SafeResolvePath()
        {
            // this method should _only_ return if the file exists.
            const string executableFile = "acs.exe";

            // Try to resolve it with the regular tool resolver.
            var toolsExe = _tools.Resolve(AcsExe);
            if (toolsExe != null)
            {
                var toolsFile = _fileSystem.GetFile(toolsExe);
                if (toolsFile.Exists)
                {
                    return toolsFile;   
                }
            }

            // Check if path set to environment variable
            var acsFolder = _environment.GetEnvironmentVariable("ApprendaACSInstall");
            if (!string.IsNullOrWhiteSpace(acsFolder))
            {
                var envFile = _fileSystem.GetFile(System.IO.Path.Combine(acsFolder, executableFile));
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
                    .Select(path => path.Path.CombineWithFilePath(executableFile))
                    .Select(_fileSystem.GetFile)
                    .FirstOrDefault(file => file.Exists);

                if (pathFile != null)
                {
                    return pathFile;
                }
            }

            // last resort, try plain vanilla program files
            var exeFile = new[]
                {
                    "c:\\Program Files (x86)\\Apprenda\\Tools\\ACS",
                    "c:\\Program Files\\Apprenda\\Tools\\ACS"
                }
                .Select(path => _fileSystem.GetDirectory(path))
                .Where(path => path.Exists)
                .Select(path => path.Path.CombineWithFilePath(executableFile))
                .Select(_fileSystem.GetFile)
                .FirstOrDefault(file => file.Exists);

            if (exeFile != null)
            {
                return exeFile;
            }

            throw new CakeException($"Could not locate {executableFile}.");
        }
    }
}
