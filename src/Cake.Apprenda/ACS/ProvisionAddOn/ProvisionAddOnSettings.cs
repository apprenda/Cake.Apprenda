using System;
using System.Collections.Generic;

namespace Cake.Apprenda.ACS.ProvisionAddOn
{
    /// <summary>
    /// Contains settings used by <see cref="ProvisionAddOn"/>
    /// </summary>
    public sealed class ProvisionAddOnSettings : ACSSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProvisionAddOnSettings"/> class.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <param name="instanceAlias">The instance alias.</param>
        public ProvisionAddOnSettings(string alias, string instanceAlias)
        {
            if (string.IsNullOrEmpty(alias))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(alias));
            }
            if (string.IsNullOrEmpty(instanceAlias))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(instanceAlias));
            }

            this.Alias = alias;
            this.InstanceAlias = instanceAlias;
        }

        /// <summary>
        /// Gets the alias of the add-on to provision
        /// </summary>
        public string Alias { get; }

        /// <summary>
        /// Gets the key given to the add-on instance to be provisioned. 
        /// It can then be used as a token in your application's configuration files that will be replaced at deploy time 
        /// with the connection data for this add-on instance.It is also the key used to de-provision the add-on instance.
        /// </summary>
        public string InstanceAlias { get; }

        /// <summary>
        /// Gets or sets a string of optional arguments to be passed into the add-on's provision method.
        /// </summary>
        public string Options { get; set; }

        /// <summary>
        /// Gets or sets a concretely defined set of parameters.This argument should be the last argument of the ProvisionAddOn command since it will assume that the remaining information is
        /// part of this argument. The way to specify each parameter is as follows: -param1 "value1" -param2 "value2"...
        /// </summary>
        public Dictionary<string, string> Parameters { get; set; } = new Dictionary<string, string>();

    }
}
