namespace Cake.Apprenda
{
    /// <summary>
    /// Provides information about an add-on on the connected Apprenda Cloud.
    /// </summary>
    public sealed class DeployedAddOnInfo
    {
        /// <summary>
        /// Gets the add-on alias
        /// </summary>
        public string Alias { get; internal set; } = "";

        /// <summary>
        /// Gets the alias of the deployed add-on instance
        /// </summary>
        public string InstanceAlias { get; internal set; } = "";

        /// <summary>
        /// Gets the add-on author
        /// </summary>
        public string Author { get; internal set; } = "";

        /// <summary>
        /// Gets the add-on vendor.
        /// </summary>
        public string Vendor { get; internal set; } = "";

        /// <summary>
        /// Gets the connection data for the add-on
        /// </summary>
        public string ConnectionData { get; internal set; } = "";

        /// <summary>
        /// Gets the time at which the instance was deployed.
        /// </summary>
        public string DeploymentTime { get; internal set; } = "";
    }
}