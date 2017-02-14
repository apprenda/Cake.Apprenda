using System;
using System.Linq;
using Cake.Core;
using Cake.Core.IO;

namespace Cake.Apprenda.ACS
{
    /// <summary>
    /// Provides common support for building command arguments for common build settings
    /// </summary>
    public sealed class BuildSettingsArgumentBuilder
    {
        /// <summary>
        /// Builds the specified command arguments for the given <see cref="BuildSettings"/>
        /// </summary>
        /// <param name="settings">The settings.</param>
        /// <param name="builder">The argument builder.</param>
        /// <exception cref="System.ArgumentNullException">
        /// settings
        /// or
        /// builder
        /// </exception>
        public void Build(BuildSettings settings, ProcessArgumentBuilder builder)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (settings.RebuildSolution)
            {
                builder.Append("-B");
            }

            if (!string.IsNullOrEmpty(settings.Configuration))
            {
                builder.Append("-Configuration");
                builder.AppendQuoted(settings.Configuration);
            }

            if (settings.IgnoreFilters != null && settings.IgnoreFilters.Any())
            {
                builder.Append("-Filters");
                builder.AppendQuoted(string.Join(" ", settings.IgnoreFilters));
            }

            if (settings.WcfProjects != null && settings.WcfProjects.Any())
            {
                builder.Append("-S");
                builder.AppendQuoted(string.Join(" ", settings.WcfProjects));
            }

            if (settings.WindowsServiceProjects != null && settings.WindowsServiceProjects.Any())
            {
                builder.Append("-WS");
                builder.AppendQuoted(string.Join(" ", settings.WindowsServiceProjects));
            }

            if (settings.StoredProcedureProjects != null && settings.StoredProcedureProjects.Any())
            {
                builder.Append("-StoredProcs");
                builder.AppendQuoted(string.Join(" ", settings.StoredProcedureProjects));
            }

            if (settings.UserInterfaceProjects != null && settings.UserInterfaceProjects.Any())
            {
                builder.Append("-I");
                builder.AppendQuoted(string.Join(" ", settings.UserInterfaceProjects));
            }

            if (!string.IsNullOrEmpty(settings.UserInterfaceRoot))
            {
                builder.Append("-PrivateRoot");
                builder.AppendQuoted(settings.UserInterfaceRoot);
            }
        }
    }
}