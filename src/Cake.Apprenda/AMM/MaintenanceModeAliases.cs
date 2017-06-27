using System;
using System.Collections.Generic;
using Cake.Apprenda.AMM.ConnectCloud;
using Cake.Apprenda.AMM.DisconnectCloud;
using Cake.Apprenda.AMM.GetNodeState;
using Cake.Apprenda.AMM.ReadRegisteredClouds;
using Cake.Apprenda.AMM.RegisterCloud;
using Cake.Apprenda.AMM.SetNodeState;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Apprenda.AMM
{
    /// <summary>
    /// Provides alias methods for working with AMM
    /// </summary>
    [CakeAliasCategory("MaintenceMode")]
    [CakeNamespaceImport("Cake.Apprenda.AMM")]
    [CakeNamespaceImport("Cake.Apprenda.AMM.ConnectCloud")]
    [CakeNamespaceImport("Cake.Apprenda.AMM.DisconnectCloud")]
    [CakeNamespaceImport("Cake.Apprenda.AMM.GetNodeState")]
    [CakeNamespaceImport("Cake.Apprenda.AMM.ReadRegisteredClouds")]
    [CakeNamespaceImport("Cake.Apprenda.AMM.RegisterCloud")]
    [CakeNamespaceImport("Cake.Apprenda.AMM.SetNodeState")]
    public static class MaintenanceModeAliases
    {
        private static IMaintenanceModeToolResolver BuildResolver(ICakeContext context)
        {
            var resolver = new MaintenanceModeToolResolver(context.FileSystem, context.Environment, context.Tools);
            return resolver;
        }

        /// <summary>
        /// Registers the cloud.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="cloudAlias">The cloud alias.</param>
        /// <param name="cloudUrl">The cloud URL.</param>
        /// <exception cref="ArgumentNullException">Thrown when the context is null</exception>
        [CakeMethodAlias]
        public static void RegisterCloud(this ICakeContext context, string cloudAlias, string cloudUrl)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var resolver = BuildResolver(context);
            var runner = new RegisterCloud.RegisterCloud(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(new RegisterCloudSettings(cloudUrl, cloudAlias));
        }

        /// <summary>
        /// Reads registered clouds
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Returns a list of registered <see cref="CloudInfo"/> items</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the context is null</exception>
        [CakeMethodAlias]
        public static IEnumerable<CloudInfo> ReadRegisteredClouds(this ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var resolver = BuildResolver(context);
            var runner = new ReadRegisteredClouds.ReadRegisteredClouds(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            return runner.Execute(new ReadRegisteredCloudsSettings());
        }

        /// <summary>
        /// Connects to a cloud
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <exception cref="ArgumentNullException">Thrown when the context is null</exception>
        [CakeMethodAlias]
        public static void ConnectCloud(this ICakeContext context, ConnectCloudSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var resolver = BuildResolver(context);
            var runner = new ConnectCloud.ConnectCloud(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(settings);
        }

        /// <summary>
        /// Disconnects from the currently connected cloud
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="ArgumentNullException">Thrown when the context is null</exception>
        [CakeMethodAlias]
        public static void DisconnectCloud(this ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var resolver = BuildResolver(context);
            var runner = new DisconnectCloud.DisconnectCloud(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(new DisconnectCloudSettings());
        }

        /// <summary>
        /// Gets the state of the node.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="hostName">Name of the host.</param>
        /// <returns>Returns the current state of the requested node</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the context is null</exception>
        [CakeMethodAlias]
        public static NodeState GetNodeState(this ICakeContext context, string hostName)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var resolver = BuildResolver(context);
            var runner = new GetNodeState.GetNodeState(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            return runner.Execute(new GetNodeStateSettings { HostName = hostName });
        }

        /// <summary>
        /// Sets the state of the node.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <exception cref="System.ArgumentNullException">
        /// context
        /// or
        /// settings
        /// </exception>
        [CakeMethodAlias]
        public static void SetNodeState(this ICakeContext context, SetNodeStateSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var resolver = BuildResolver(context);
            var runner = new SetNodeState.SetNodeState(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(settings);
        }
    }
}
