using System;
using System.Collections.Generic;
using Cake.Apprenda.AMM.ConnectCloud;
using Cake.Apprenda.AMM.DisconnectCloud;
using Cake.Apprenda.AMM.GetNodeState;
using Cake.Apprenda.AMM.ReadRegisteredClouds;
using Cake.Apprenda.AMM.RegisterCloud;
using Cake.Apprenda.AMM.SetNodeState;
using Cake.Core.Annotations;

namespace Cake.Apprenda.AMM
{
    /// <summary>
    /// Provides extension methods for working with <see cref="MaintenanceModeContext"/>
    /// </summary>
    public static class MaintenanceModeContextExtensions
    {
        private static IMaintenanceModeToolResolver BuildResolver(MaintenanceModeContext context)
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
        public static void RegisterCloud(this MaintenanceModeContext context, string cloudAlias, string cloudUrl)
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
        public static IEnumerable<CloudInfo> ReadRegisteredClouds(this MaintenanceModeContext context)
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
        public static void ConnectCloud(this MaintenanceModeContext context, ConnectCloudSettings settings)
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
        public static void DisconnectCloud(this MaintenanceModeContext context)
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
        public static NodeState GetNodeState(this MaintenanceModeContext context, string hostName)
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
        public static void SetNodeState(this MaintenanceModeContext context, SetNodeStateSettings settings)
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
