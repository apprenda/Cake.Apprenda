namespace Cake.Apprenda
{
    /// <summary>
    /// Provides information about an add-on on the connected Apprenda Cloud.
    /// </summary>
    public sealed class AddOnInfo
    {
        /// <summary>
        /// Gets the add-on name
        /// </summary>
        public string Name { get; internal set; } = "";

        /// <summary>
        /// Gets the add-on alias
        /// </summary>
        public string Alias { get; internal set; } = "";

        /// <summary>
        /// Gets the add-on author
        /// </summary>
        public string Author { get; internal set; } = "";

        /// <summary>
        /// Gets the add-on vendor.
        /// </summary>
        public string Vendor { get; internal set; } = "";

        /// <summary>
        /// Gets the description of the add-on.
        /// </summary>
        public string Description { get; internal set; } = "";

        /// <summary>
        /// Gets whether or not the add-on instance allows arbitrary parameters
        /// </summary>
        public bool AllowsArbitraryParameters { get; internal set; }

        /// <summary>
        /// Gets the help text for the add-on
        /// </summary>
        public string HelpText { get; internal set; } = "";
    }
}