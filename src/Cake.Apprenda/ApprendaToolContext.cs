using System;
using Cake.Apprenda.ACS;
using Cake.Apprenda.AMM;
using Cake.Core;

namespace Cake.Apprenda
{
    /// <summary>
    /// Provides functionality for interfacing with Apprenda tools
    /// </summary>
    public sealed class ApprendaToolProvider
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ApprendaToolProvider"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when the context is null</exception>
        public ApprendaToolProvider(ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            this.CloudShell = new CloudShellContext(context);
            this.MaintenanceMode = new MaintenanceModeContext(context);
        }

        /// <summary>
        /// Gets the <see cref="MaintenanceModeContext"/>
        /// </summary>
        /// <value>
        /// The maintenance mode.
        /// </value>
        public MaintenanceModeContext MaintenanceMode { get; }

        /// <summary>
        /// Gets the <see cref="CloudShellContext"/>
        /// </summary>
        /// <value>
        /// The cloud shell.
        /// </value>
        public CloudShellContext CloudShell { get; }
    }
}