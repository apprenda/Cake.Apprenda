using System;
using System.Collections.Generic;
using Cake.Apprenda.ACS;
using Cake.Apprenda.ACS.CancelVersionPromotion;
using Cake.Apprenda.ACS.ConnectCloud;
using Cake.Apprenda.ACS.DemoteVersion;
using Cake.Apprenda.ACS.DeProvisionAddOn;
using Cake.Apprenda.ACS.DisconnectCloud;
using Cake.Apprenda.ACS.ExportArchive;
using Cake.Apprenda.ACS.ExportManifest;
using Cake.Apprenda.ACS.GetAddOns;
using Cake.Apprenda.ACS.GetDeployedAddOns;
using Cake.Apprenda.ACS.NewApplication;
using Cake.Apprenda.ACS.NewPackage;
using Cake.Apprenda.ACS.NewUser;
using Cake.Apprenda.ACS.NewVersion;
using Cake.Apprenda.ACS.PatchVersion;
using Cake.Apprenda.ACS.PromoteVersion;
using Cake.Apprenda.ACS.ProvisionAddOn;
using Cake.Apprenda.ACS.ReadRegisteredClouds;
using Cake.Apprenda.ACS.RegisterCloud;
using Cake.Apprenda.ACS.RemoveApplication;
using Cake.Apprenda.ACS.RemoveVersion;
using Cake.Apprenda.ACS.SetArchive;
using Cake.Apprenda.ACS.SetInstanceCount;
using Cake.Apprenda.ACS.SetInstanceMinimum;
using Cake.Apprenda.ACS.StartInDebugMode;
using Cake.Apprenda.ACS.StartVersion;
using Cake.Apprenda.ACS.StopDebugMode;
using Cake.Apprenda.ACS.StopVersion;
using Cake.Core.Annotations;
//// ReSharper disable InconsistentNaming

namespace Cake.Apprenda
{
    /// <summary>
    /// Provides extension methods for working with <see cref="CloudShellContext"/>
    /// </summary>
    public static class CloudShellContextExtensions
    {
        private static CloudShellToolResolver BuildResolver(CloudShellContext context)
        {
            var resolver = new CloudShellToolResolver(context.FileSystem, context.Environment, context.Tools);
            return resolver;
        }

        /// <summary>
        /// Reads registered clouds
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Returns a list of registered <see cref="CloudInfo"/> items</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the context is null</exception>
        [CakeMethodAlias]
        public static IEnumerable<CloudInfo> ReadRegisteredClouds(this CloudShellContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var resolver = BuildResolver(context);
            var runner = new ReadRegisteredClouds(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            return runner.Execute(new ReadRegisteredCloudsSettings());
        }

        /// <summary>
        /// Registers the cloud.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="cloudAlias">The cloud alias.</param>
        /// <param name="cloudUrl">The cloud URL.</param>
        /// <exception cref="ArgumentNullException">Thrown when the context is null</exception>
        [CakeMethodAlias]
        public static void RegisterCloud(this CloudShellContext context, string cloudAlias, string cloudUrl)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var resolver = BuildResolver(context);
            var runner = new RegisterCloud(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(new RegisterCloudSettings(cloudUrl, cloudAlias));
        }

        /// <summary>
        /// Connects to a cloud
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <exception cref="ArgumentNullException">Thrown when the context is null</exception>
        [CakeMethodAlias]
        public static void ConnectCloud(this CloudShellContext context, ConnectCloudSettings settings)
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
            var runner = new ConnectCloud(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(settings);
        }

        /// <summary>
        /// Disconnects from the currently connected cloud
        /// </summary>
        /// <param name="context">The context.</param>
        /// <exception cref="ArgumentNullException">Thrown when the context is null</exception>
        [CakeMethodAlias]
        public static void DisconnectCloud(this CloudShellContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var resolver = BuildResolver(context);
            var runner = new DisconnectCloud(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(new DisconnectCloudSettings());
        }

        /// <summary>
        /// Creates a new user for the current dev team context
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <exception cref="ArgumentNullException">Thrown when the context is null</exception>
        [CakeMethodAlias]
        public static void NewUser(this CloudShellContext context, NewUserSettings settings)
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
        public static void NewApplication(this CloudShellContext context, NewApplicationSettings settings)
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
        public static void NewVersion(this CloudShellContext context, NewVersionSettings settings)
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
        public static void RemoveApplication(this CloudShellContext context, string appAlias)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (string.IsNullOrEmpty(appAlias))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(appAlias));
            }

            var resolver = BuildResolver(context);
            var runner = new RemoveApplication(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(new RemoveApplicationSettings(appAlias));
        }

        /// <summary>
        /// Removes the application version.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="appAlias">The application alias.</param>
        /// <param name="versionAlias">The version alias.</param>
        /// <exception cref="ArgumentNullException">Thrown when the context is null</exception>
        /// <exception cref="System.ArgumentException">
        /// Value cannot be null or empty. - appAlias
        /// or
        /// Value cannot be null or empty. - versionAlias
        /// </exception>
        [CakeMethodAlias]
        public static void RemoveVersion(this CloudShellContext context, string appAlias, string versionAlias)
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

            var resolver = BuildResolver(context);
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
        public static void SetArchive(this CloudShellContext context, SetArchiveSettings settings)
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
        public static void PatchVersion(this CloudShellContext context, PatchVersionSettings settings)
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
        public static void NewPackage(this CloudShellContext context, NewPackageSettings settings)
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
        public static void PromoteVersion(this CloudShellContext context, PromoteVersionSettings settings)
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
            var runner = new PromoteVersion(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(settings);
        }

        /// <summary>
        /// Demotes the given version of an application
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="appAlias">The application alias.</param>
        /// <param name="versionAlias">The version alias.</param>
        /// <exception cref="ArgumentNullException">Thrown when the context is null</exception>
        /// <exception cref="System.ArgumentException">
        /// Value cannot be null or empty. - appAlias
        /// or
        /// Value cannot be null or empty. - versionAlias
        /// </exception>
        [CakeMethodAlias]
        public static void PromoteVersion(this CloudShellContext context, string appAlias, string versionAlias)
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

            var resolver = BuildResolver(context);
            var runner = new DemoteVersion(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(new DemoteVersionSettings(appAlias, versionAlias));
        }

        /// <summary>
        /// Cancels the version promotion.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="appAlias">The application alias.</param>
        /// <param name="versionAlias">The version alias.</param>
        /// <exception cref="ArgumentNullException">Thrown when the context is null</exception>
        /// <exception cref="System.ArgumentException">
        /// Value cannot be null or empty. - appAlias
        /// or
        /// Value cannot be null or empty. - versionAlias
        /// </exception>
        [CakeMethodAlias]
        public static void CancelVersionPromotion(this CloudShellContext context, string appAlias, string versionAlias)
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

            var resolver = BuildResolver(context);
            var runner = new CancelVersionPromotion(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(new CancelVersionPromotionSettings(appAlias, versionAlias));
        }

        /// <summary>
        /// Starts the components for the version of the application
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="appAlias">The application alias.</param>
        /// <param name="versionAlias">The version alias.</param>
        /// <exception cref="ArgumentNullException">Thrown when the context is null</exception>
        /// <exception cref="System.ArgumentException">
        /// Value cannot be null or empty. - appAlias
        /// or
        /// Value cannot be null or empty. - versionAlias
        /// </exception>
        [CakeMethodAlias]
        public static void StartVersion(this CloudShellContext context, string appAlias, string versionAlias)
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

            var resolver = BuildResolver(context);
            var runner = new StartVersion(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(new StartVersionSettings(appAlias, versionAlias));
        }

        /// <summary>
        /// Stops the version.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="appAlias">The application alias.</param>
        /// <param name="versionAlias">The version alias.</param>
        /// <exception cref="ArgumentNullException">Thrown when the context is null</exception>
        /// <exception cref="System.ArgumentException">
        /// Value cannot be null or empty. - appAlias
        /// or
        /// Value cannot be null or empty. - versionAlias
        /// </exception>
        [CakeMethodAlias]
        public static void StopVersion(this CloudShellContext context, string appAlias, string versionAlias)
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

            var resolver = BuildResolver(context);
            var runner = new StopVersion(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(new StopVersionSettings(appAlias, versionAlias));
        }

        /// <summary>
        /// Exports the manifest for a given application and version
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <exception cref="ArgumentNullException">Thrown when the context is null</exception>
        [CakeMethodAlias]
        public static void ExportManifest(this CloudShellContext context, ExportManifestSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var resolver = BuildResolver(context);
            var runner = new ExportManifest(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(settings);
        }

        /// <summary>
        /// Exports the archive.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <exception cref="ArgumentNullException">Thrown when the context is null</exception>
        [CakeMethodAlias]
        public static void ExportArchive(this CloudShellContext context, ExportArchiveSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var resolver = BuildResolver(context);
            var runner = new ExportArchive(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(settings);
        }

        /// <summary>
        /// Starts the application or component in debug mode
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <exception cref="ArgumentNullException">Thrown when the context is null</exception>
        [CakeMethodAlias]
        public static void StartInDebugMode(this CloudShellContext context, StartInDebugModeSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var resolver = BuildResolver(context);
            var runner = new StartInDebugMode(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(settings);
        }

        /// <summary>
        /// Takes the component out of debug mode and returns it to the original state, as defined by minimum instance counts.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <exception cref="ArgumentNullException">Thrown when the context is null</exception>
        [CakeMethodAlias]
        public static void StopDebugMode(this CloudShellContext context, StopDebugModeSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var resolver = BuildResolver(context);
            var runner = new StopDebugMode(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(settings);
        }

        /// <summary>
        /// Configures the minimum number of instances a component will be maintained at.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <exception cref="ArgumentNullException">Thrown when the context is null</exception>
        [CakeMethodAlias]
        public static void SetInstanceMinimum(this CloudShellContext context, SetInstanceMinimumSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var resolver = BuildResolver(context);
            var runner = new SetInstanceMinimum(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(settings);
        }

        /// <summary>
        /// Scales the specified application component to the desired number of instances.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <exception cref="ArgumentNullException">Thrown when the context is null</exception>
        [CakeMethodAlias]
        public static void SetInstanceCount(this CloudShellContext context, SetInstanceCountSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var resolver = BuildResolver(context);
            var runner = new SetInstanceCount(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(settings);
        }

        /// <summary>
        /// Provisions a new instance of the given add-on for your organization.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <exception cref="ArgumentNullException">Thrown when the context is null</exception>
        [CakeMethodAlias]
        public static void ProvisionAddOn(this CloudShellContext context, ProvisionAddOnSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var resolver = BuildResolver(context);
            var runner = new ProvisionAddOn(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(settings);
        }

        /// <summary>
        /// De-Provisions an instance of the given add-on for your organization.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="settings">The settings.</param>
        /// <exception cref="ArgumentNullException">Thrown when the context is null</exception>
        [CakeMethodAlias]
        public static void DeProvisionAddOn(this CloudShellContext context, DeProvisionAddOnSettings settings)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var resolver = BuildResolver(context);
            var runner = new DeProvisionAddOn(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            runner.Execute(settings);
        }

        /// <summary>
        /// Used to retrieve a list of add-ons on the connected Apprenda Cloud.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Returns the list of addons available on the cloud</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the context is null</exception>
        [CakeMethodAlias]
        public static IEnumerable<AddOnInfo> GetAddOns(this CloudShellContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var resolver = BuildResolver(context);
            var runner = new GetAddOns(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            return runner.Execute(new GetAddOnsSettings());
        }

        /// <summary>
        /// Used to retrieve a list of the add-ons deployed to the connected Apprenda cloud.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>Returns the list of addons that are currently deployed</returns>
        /// <exception cref="System.ArgumentNullException">Thrown when the context is null</exception>
        [CakeMethodAlias]
        public static IEnumerable<DeployedAddOnInfo> GetDeployedAddOns(this CloudShellContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var resolver = BuildResolver(context);
            var runner = new GetDeployedAddOns(context.FileSystem, context.Environment, context.ProcessRunner, context.Tools, resolver);

            return runner.Execute(new GetDeployedAddOnsSettings());
        }
    }
}
