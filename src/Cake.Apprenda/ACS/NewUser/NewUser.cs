using System;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.ACS.NewUser
{
    /// <summary>
    /// Connects to a cloud instance
    /// </summary>
    /// <seealso cref="CloudShellTool{TSettings}" />
    public sealed class NewUser : CloudShellTool<NewUserSettings>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NewUser" /> class.
        /// </summary>
        /// <param name="fileSystem">The file system.</param>
        /// <param name="environment">The environment.</param>
        /// <param name="processRunner">The process runner.</param>
        /// <param name="tools">The tools.</param>
        /// <param name="resolver">The resolver.</param>
        public NewUser(IFileSystem fileSystem, ICakeEnvironment environment, IProcessRunner processRunner, IToolLocator tools, CloudShellToolResolver resolver)
            : base(fileSystem, environment, processRunner, tools, resolver)
        {
        }

        /// <summary>
        /// Executes the specified settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public void Execute(NewUserSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var builder = new ProcessArgumentBuilder();

            builder.Append("NewUser");
            builder.Append("--NonInteractive");

            builder.Append("-EmailAddress");
            builder.Append(settings.EmailAddress);

            builder.Append("-FirstName");
            builder.Append(settings.FirstName);

            builder.Append("-LastName");
            builder.Append(settings.LastName);

            builder.Append("-Password");
            builder.Append(settings.Password);

            if (settings.Roles.Any())
            {
                builder.Append("-Roles");
                builder.Append(string.Join(",", settings.Roles));
            }

            Run(settings, builder);
        }
    }
}
