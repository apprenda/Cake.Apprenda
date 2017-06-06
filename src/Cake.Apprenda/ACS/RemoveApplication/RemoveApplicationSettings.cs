using System;

namespace Cake.Apprenda.ACS.RemoveApplication
{
    /// <summary>
    /// Contains settings used by <see cref="RemoveApplication"/>
    /// </summary>
    public sealed class RemoveApplicationSettings : CloudShellSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveApplicationSettings"/> class.
        /// </summary>
        public RemoveApplicationSettings()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveApplicationSettings"/> class.
        /// </summary>
        /// <param name="appAlias">The application alias.</param>
        public RemoveApplicationSettings(string appAlias)
        {
            if (string.IsNullOrEmpty(appAlias))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(appAlias));
            }

            this.AppAlias = appAlias;
        }

        /// <summary>
        /// Gets or sets the application alias.
        /// </summary>
        /// <value>
        /// The application alias.
        /// </value>
        public string AppAlias { get; set; }
    }
}