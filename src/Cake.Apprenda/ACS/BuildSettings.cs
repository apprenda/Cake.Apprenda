using System.Collections.Generic;
using System.Linq;

namespace Cake.Apprenda.ACS
{
    /// <summary>
    /// Represents optional, common build settings for commands that can act on a Visual Studio solution
    /// </summary>
    public sealed class BuildSettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether the solution should be rebuilt before packaging
        /// </summary>
        public bool RebuildSolution { get; set; }

        /// <summary>
        /// Gets or sets the configuration for which to build the solution
        /// </summary>
        public string Configuration { get; set; }

        /// <summary>
        /// Gets or sets the collection of file extensions that should be excluded from the final package. ex) -filters ".sln .obj .foo" - Will exclude files with the extensions .sln, .obj, and .foo
        /// </summary>
        public IEnumerable<string> IgnoreFilters { get; set; } = Enumerable.Empty<string>();

        /// <summary>
        /// Gets or sets the collection of project names that should be treated as UI projects.  ex) -i "SubApp1 PrimaryApp SubApp2" - Specifies PrimaryApp, SubApp1, and SubApp2 as the UI projects.
        /// </summary>
        public IEnumerable<string> UserInterfaceProjects { get; set; } = Enumerable.Empty<string>();

        /// <summary>
        /// Specifies the primary user interface project.  ex) -i "SubApp1 PrimaryApp SubApp2" -PrivateRoot PrimaryApp 
        /// Specifies PrimaryApp, SubApp1, and SubApp2 as the user interface projects with PrimaryApp as the root UI.
        /// When published on Apprenda, the root UI will be accessible at the application's url with virtual applications SubApp1 and SubApp2 underneath it.
        /// </summary>
        public string UserInterfaceRoot { get; set; }

        /// <summary>
        /// Gets or sets the collection of project names that should be treated as WCF service projects. ex) -s "Service1 Service2" - Specifies Service1 and Service2 as the WCF service projects.
        /// </summary>
        public IEnumerable<string> WcfProjects { get; set; } = Enumerable.Empty<string>();

        /// <summary>
        /// Gets or sets the collection of project names that should be treated as Windows service projects.  ex) -ws "Service1 Service2" - Specifies Service1 and Service2 as the Windows service projects.
        /// </summary>
        public IEnumerable<string> WindowsServiceProjects { get; set; } = Enumerable.Empty<string>();

        /// <summary>
        /// Gets or sets the collection of project names that should be treated as CLR stored procedure projects. ex) -StoredProcs "Project1 Project2" - Specifies Project1 and Project 2 as CLR stored procedure projects.
        /// </summary>
        public IEnumerable<string> StoredProcedureProjects { get; set; } = Enumerable.Empty<string>();

    }
}
