using System;

namespace Cake.Apprenda.ACS.DeProvisionAddOn
{
    /// <summary>
    /// Contains settings used by <see cref="DeProvisionAddOn"/>
    /// </summary>
    public sealed class DeProvisionAddOnSettings : ACSSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeProvisionAddOnSettings"/> class.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <param name="instanceAlias">The instance alias.</param>
        public DeProvisionAddOnSettings(string alias, string instanceAlias)
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
    }
}
