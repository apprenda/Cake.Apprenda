using System;
using System.Collections.Generic;
using Cake.Apprenda.ACS.ConnectCloud;
using Cake.Apprenda.ACS.DisconnectCloud;
using Cake.Apprenda.ACS.NewApplication;
using Cake.Apprenda.ACS.NewPackage;
using Cake.Apprenda.ACS.NewUser;
using Cake.Apprenda.ACS.NewVersion;
using Cake.Apprenda.ACS.PatchVersion;
using Cake.Apprenda.ACS.PromoteVersion;
using Cake.Apprenda.ACS.ReadRegisteredClouds;
using Cake.Apprenda.ACS.RegisterCloud;
using Cake.Apprenda.ACS.RemoveApplication;
using Cake.Apprenda.ACS.RemoveVersion;
using Cake.Apprenda.ACS.SetArchive;
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
    [CakeNamespaceImport("Cake.Apprenda.ACS.NewApplication")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.NewVersion")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.RemoveApplication")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.RemoveVersion")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.SetArchive")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.PatchVersion")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.NewPackage")]
    [CakeNamespaceImport("Cake.Apprenda.ACS.PromoteVersion")]
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
        /// Creates a new user for the current dev team context
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

        /// <summary>
        /// Creates a new application
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <exception cref="System.ArgumentNullException">
        /// context
        /// or
        /// settings
        /// </exception>
        [CakeMethodAlias]
        [CakeAliasCategory("ACS")]
        public static void NewApplication(this ICakeContext context, NewApplicationSettings settings)
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
            var runner = new NewApplication(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(settings);
        }


        /// <summary>
        /// Creates a new version of a given application
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <exception cref="System.ArgumentNullException">
        /// context
        /// or
        /// settings
        /// </exception>
        [CakeMethodAlias]
        [CakeAliasCategory("ACS")]
        public static void NewVersion(this ICakeContext context, NewVersionSettings settings)
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
            var runner = new NewVersion(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(settings);
        }

        /// <summary>
        /// Removes the application.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="appAlias">The application alias.</param>
        /// <exception cref="System.ArgumentNullException">
        /// context
        /// or
        /// settings
        /// </exception>
        [CakeMethodAlias]
        [CakeAliasCategory("ACS")]
        public static void RemoveApplication(this ICakeContext context, string appAlias)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (string.IsNullOrEmpty(appAlias))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(appAlias));
            }

            var resolver = new ACSToolResolver(context.FileSystem, context.Environment);
            var runner = new RemoveApplication(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(new RemoveApplicationSettings(appAlias));
        }

        /// <summary>
        /// Removes the application version.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="appAlias">The application alias.</param>
        /// <param name="versionAlias">The version alias.</param>
        /// <exception cref="System.ArgumentNullException">context</exception>
        /// <exception cref="System.ArgumentException">
        /// Value cannot be null or empty. - appAlias
        /// or
        /// Value cannot be null or empty. - versionAlias
        /// </exception>
        [CakeMethodAlias]
        [CakeAliasCategory("ACS")]
        public static void RemoveVersion(this ICakeContext context, string appAlias, string versionAlias)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (string.IsNullOrEmpty(appAlias))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(appAlias));
            }

            if (string.IsNullOrEmpty(versionAlias))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(versionAlias));
            }

            var resolver = new ACSToolResolver(context.FileSystem, context.Environment);
            var runner = new RemoveVersion(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(new RemoveVersionSettings(appAlias, versionAlias));
        }

        /// <summary>
        /// Sets the archive for a given application version.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <exception cref="System.ArgumentNullException">
        /// context
        /// or
        /// settings
        /// </exception>
        [CakeMethodAlias]
        [CakeAliasCategory("ACS")]
        public static void SetArchive(this ICakeContext context, SetArchiveSettings settings)
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
            var runner = new SetArchive(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(settings);
        }

        /// <summary>
        /// Uploads a new archive to an application in any stage and promotes the app to the desired stage.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <exception cref="System.ArgumentNullException">
        /// context
        /// or
        /// settings
        /// </exception>
        [CakeMethodAlias]
        [CakeAliasCategory("ACS")]
        public static void PatchVersion(this ICakeContext context, PatchVersionSettings settings)
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
            var runner = new PatchVersion(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(settings);
        }

        /// <summary>
        /// Creates a new Apprenda archive package using the specified <see cref="NewPackageSettings"/>
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <exception cref="System.ArgumentNullException">
        /// context
        /// or
        /// settings
        /// </exception>
        [CakeMethodAlias]
        [CakeAliasCategory("ACS")]
        public static void NewPackage(this ICakeContext context, NewPackageSettings settings)
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
            var runner = new NewPackage(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(settings);
        }

        /// <summary>
        /// Promotes the given version of an application
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <exception cref="System.ArgumentNullException">
        /// context
        /// or
        /// settings
        /// </exception>
        [CakeMethodAlias]
        [CakeAliasCategory("ACS")]
        public static void PromoteVersion(this ICakeContext context, PromoteVersionSettings settings)
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
            var runner = new PromoteVersion(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(settings);
        }
    }
}
