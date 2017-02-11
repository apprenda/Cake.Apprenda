namespace Cake.Apprenda
{
    /// <summary>
    /// Represents a cloud registration
    /// </summary>
    public sealed class CloudInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudInfo"/> class.
        /// </summary>
        /// <param name="cloudAlias">The cloud alias.</param>
        /// <param name="cloudUrl">The cloud URL.</param>
        public CloudInfo(string cloudAlias, string cloudUrl)
        {
            this.Alias = cloudAlias;
            this.Url = cloudUrl;
        }

        /// <summary>
        /// Gets the Cloud alias.
        /// </summary>
        public string Alias { get; }
        
        /// <summary>
        /// Gets the Cloud URL.
        /// </summary>
        public string Url { get; }
    }
}
