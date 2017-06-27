namespace Cake.Apprenda.AMM
{
    /// <summary>
    /// Represents the status of a host on a cloud
    /// </summary>
    public enum NodeState
    {
        /// <summary>
        /// The node state is unknown or cannot be resolved
        /// </summary>
        Unknown,

        /// <summary>
        /// The node is Online
        /// </summary>
        Online,

        /// <summary>
        /// The node is in Reserved mode
        /// </summary>
        Reserved,

        /// <summary>
        /// The node is in maintenance mode
        /// </summary>
        Maintenance
    }
}
