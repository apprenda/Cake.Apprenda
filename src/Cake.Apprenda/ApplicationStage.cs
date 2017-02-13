namespace Cake.Apprenda
{
    /// <summary>
    /// Represents the promotion stage of a given application
    /// </summary>
    public enum ApplicationStage
    {
        /// <summary>
        /// The definition stage of an app lifecycle
        /// </summary>
        Definition,
        
        /// <summary>
        /// The sandbox stage of an app lifecycle
        /// </summary>
        Sandbox,

        /// <summary>
        /// The published stage of an app lifecycle
        /// </summary>
        Published
    }
}