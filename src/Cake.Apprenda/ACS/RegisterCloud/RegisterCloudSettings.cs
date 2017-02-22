﻿using System;

namespace Cake.Apprenda.ACS.RegisterCloud
{
    /// <summary>
    /// Contains settings used by <see cref="RegisterCloud"/>
    /// </summary>
    public sealed class RegisterCloudSettings : ACSSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterCloudSettings"/> class.
        /// </summary>
        /// <param name="cloudUrl">The cloud URL.</param>
        /// <param name="cloudAlias">The cloud alias.</param>
        public RegisterCloudSettings(string cloudUrl, string cloudAlias)
        {
            if (string.IsNullOrEmpty(cloudUrl))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(cloudUrl));
            }
            if (string.IsNullOrEmpty(cloudAlias))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(cloudAlias));
            }

            this.CloudUrl = cloudUrl;
            this.CloudAlias = cloudAlias;
        }

        /// <summary>
        /// Gets the cloud URL.
        /// </summary>
        public string CloudUrl { get; }

        /// <summary>
        /// Gets the cloud alias.
        /// </summary>
        public string CloudAlias { get; }
    }
}