using System;
using System.Collections.Generic;
using Cake.Apprenda.ACS.ConnectCloud;
using Cake.Apprenda.ACS.DisconnectCloud;
using Cake.Apprenda.ACS.NewUser;
using Cake.Apprenda.ACS.ReadRegisteredClouds;
using Cake.Apprenda.ACS.RegisterCloud;
using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.Apprenda
{
    /// <summary>
    /// Provides alias methods for working with ACS
    /// </summary>
    [CakeAliasCategory("ACS")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.ConnectCloud")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.RegisterCloud")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.ReadRegisteredClouds")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.DisconnectCloud")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.NewUser")]
    public static class ACSAliases
    {
        /// <summary>
        /// Reads registered clouds
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [CakeMethodAlias]
        [CakeAliasCategory("ACS")]
        public static IEnumerable<CloudInfo> ReadRegisteredClouds(this ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var resolver = new ACSToolResolver(context.FileSystem, context.Environment);
            var runner = new ReadRegisteredClouds(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            return runner.Execute();
        }

        /// <summary>
        /// Registers the cloud.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="cloudAlias">The cloud alias.</param>
        /// <param name="cloudUrl">The cloud URL.</param>
        /// <exception cref="System.ArgumentNullException">context</exception>
        [CakeMethodAlias]
        [CakeAliasCategory("ACS")]
        public static void RegisterCloud(this ICakeContext context, string cloudAlias, string cloudUrl)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var resolver = new ACSToolResolver(context.FileSystem, context.Environment);
            var runner = new RegisterCloud(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(new RegisterCloudSettings(cloudUrl, cloudAlias));
        }

        /// <summary>
        /// Connects to a cloud
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings"></param>
        /// <exception cref="System.ArgumentNullException">context</exception>
        [CakeMethodAlias]
        [CakeAliasCategory("ACS")]
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

            var resolver = new ACSToolResolver(context.FileSystem, context.Environment);
            var runner = new ConnectCloud(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(settings);
        }

        /// <summary>
        /// Disconnects from the currently connected cloud
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="System.ArgumentNullException">context</exception>
        [CakeMethodAlias]
        [CakeAliasCategory("ACS")]
        public static void DisconnectCloud(this ICakeContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var resolver = new ACSToolResolver(context.FileSystem, context.Environment);
            var runner = new DisconnectCloud(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(new DisconnectCloudSettings());
        }

        /// <summary>
        /// Disconnects from the currently connected cloud
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings"></param>
        /// <exception cref="System.ArgumentNullException">context</exception>
        [CakeMethodAlias]
        [CakeAliasCategory("ACS")]
        public static void NewUser(this ICakeContext context, NewUserSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            var resolver = new ACSToolResolver(context.FileSystem, context.Environment);
            var runner = new NewUser(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(settings);
        }
    }
}
