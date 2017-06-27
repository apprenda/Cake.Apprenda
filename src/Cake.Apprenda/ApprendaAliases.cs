using System;
using Cake.Apprenda.ACS;
using Cake.Apprenda.AMM;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Apprenda
{
    /// <summary>
    /// Contains functionality for Apprenda tools
    /// </summary>
    [CakeAliasCategory("Apprenda")]
    [CakeNamespaceImport("Cake.Apprenda.ACS")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.ConnectCloud")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.RegisterCloud")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.ReadRegisteredClouds")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.DisconnectCloud")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.NewUser")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.NewApplication")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.NewVersion")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.RemoveApplication")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.RemoveVersion")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.SetArchive")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.PatchVersion")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.NewPackage")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.PromoteVersion")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.DemoteVersion")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.CancelVersionPromotion")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.StartVersion")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.StopVersion")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.ExportManifest")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.ExportArchive")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.StartInDebugMode")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.StopDebugMode")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.SetInstanceMinimum")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.SetInstanceCount")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.ProvisionAddOn")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.DeProvisionAddOn")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.GetAddOns")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.GetDeployedAddOns")]
    [CakeNamespaceImport("Cake.Apprenda.AMM")]
    [CakeNamespaceImport("Cake.Apprenda.AMM.ConnectCloud")]
    [CakeNamespaceImport("Cake.Apprenda.AMM.DisconnectCloud")]
    [CakeNamespaceImport("Cake.Apprenda.AMM.GetNodeState")]
    [CakeNamespaceImport("Cake.Apprenda.AMM.ReadRegisteredClouds")]
    [CakeNamespaceImport("Cake.Apprenda.AMM.RegisterCloud")]
    [CakeNamespaceImport("Cake.Apprenda.AMM.SetNodeState")]
    public static class ApprendaAliases
    {
        /// <summary>
        /// Gets a <see cref="ApprendaToolProvider"/> instance that can be used to interoperate with Apprenda tools
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>A <see cref="ApprendaToolProvider"/> instance</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the context is null</exception>
        [CakePropertyAlias(Cache = true)]
        public static ApprendaToolProvider Apprenda(this ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return new ApprendaToolProvider(context);
        }

        /// <summary>
        /// Gets the <see cref="CloudShellContext"/> to interact with the ACS tool
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Returns a <see cref="CloudShellContext"/> instance</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the context is null</exception>
        [CakePropertyAlias(Cache = true)]
        public static CloudShellContext CloudShell(this ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var apprenda = context.Apprenda();
            return apprenda.CloudShell;
        }

        /// <summary>
        /// Gets the <see cref="MaintenanceModeContext"/> to interact with the AMM tool
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Returns a <see cref="MaintenanceModeContext"/> instance</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the context is null</exception>
        [CakePropertyAlias(Cache = true)]
        public static MaintenanceModeContext MaintenanceMode(this ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var apprenda = context.Apprenda();
            return apprenda.MaintenanceMode;
        }
    }
}
