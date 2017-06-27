using System;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.Apprenda.AMM
{
    /// <summary>
    /// Provides functionality for the AMM tool
    /// </summary>
    public sealed class MaintenanceModeContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MaintenanceModeContext"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when the context is null</exception>
        public MaintenanceModeContext(ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            this.CakeContext = context;
        }

        internal ICakeContext CakeContext { get; }

        internal IFileSystem FileSystem => CakeContext.FileSystem;

        internal ICakeEnvironment Environment => CakeContext.Environment;

        internal IProcessRunner ProcessRunner => CakeContext.ProcessRunner;

        internal IToolLocator Tools => CakeContext.Tools;
    }
}