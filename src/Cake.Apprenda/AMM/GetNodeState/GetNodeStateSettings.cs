using System;

namespace Cake.Apprenda.AMM.GetNodeState
{
    /// <summary>
    /// Contains settings used by <see cref="GetNodeState"/>
    /// </summary>
    public sealed class GetNodeStateSettings : CloudShellSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetNodeStateSettings"/> class.
        /// </summary>
        public GetNodeStateSettings()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GetNodeStateSettings"/> class.
        /// </summary>
        /// <param name="hostName">Name of the host.</param>
        /// <exception cref="System.ArgumentException">Value cannot be null or empty. - hostName</exception>
        public GetNodeStateSettings(string hostName)
        {
            if (string.IsNullOrEmpty(hostName))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(hostName));
            }

            this.HostName = hostName;
        }

        /// <summary>
        /// Gets or sets the name of the host.
        /// </summary>
        /// <value>
        /// The name of the host.
        /// </value>
        public string HostName { get; set; }
    }
}