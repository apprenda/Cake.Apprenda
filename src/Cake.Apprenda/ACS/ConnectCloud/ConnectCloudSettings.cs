using System;

namespace Cake.Apprenda.ACS.ConnectCloud
{
    /// <summary>
    /// Contains settings used by <see cref="ConnectCloud"/>
    /// </summary>
    public sealed class ConnectCloudSettings : CloudShellSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectCloudSettings"/> class.
        /// </summary>
        /// <param name="cloudAlias">The cloud alias.</param>
        /// <param name="user">The user name</param>
        /// <param name="password">The password</param>
        public ConnectCloudSettings(string cloudAlias, string user, string password)
        {
            if (string.IsNullOrEmpty(cloudAlias))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(cloudAlias));
            }
            if (string.IsNullOrEmpty(user))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(user));
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(password));
            }

            this.CloudAlias = cloudAlias;
            this.User = user;
            this.Password = password;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectCloudSettings"/> class.
        /// </summary>
        public ConnectCloudSettings()
        {
        }

        /// <summary>
        /// Gets or sets the cloud alias.
        /// </summary>
        public string CloudAlias { get; set;  }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        public string User { get; set; }

        /// <summary>
        /// Gets or sets the password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the dev team alias to connect as
        /// </summary>
        public string DevTeamAlias { get; set; }
    }
}