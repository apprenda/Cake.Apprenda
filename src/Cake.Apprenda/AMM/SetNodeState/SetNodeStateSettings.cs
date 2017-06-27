using System;
using System.ComponentModel;

namespace Cake.Apprenda.AMM.SetNodeState
{
    /// <summary>
    /// Contains settings used by <see cref="SetNodeStateSettings"/>
    /// </summary>
    public sealed class SetNodeStateSettings : CloudShellSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetNodeStateSettings"/> class.
        /// </summary>
        public SetNodeStateSettings()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetNodeStateSettings"/> class.
        /// </summary>
        /// <param name="hostName">Name of the host.</param>
        /// <param name="state">The state of the host</param>
        /// <param name="reason">The reason for the transition</param>
        /// <exception cref="System.ArgumentException">Value cannot be null or empty. - hostName</exception>
        public SetNodeStateSettings(string hostName, NodeState state, string reason)
        {
            if (string.IsNullOrEmpty(hostName))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(hostName));
            }
            if (!Enum.IsDefined(typeof(NodeState), state))
            {
                throw new InvalidEnumArgumentException(nameof(state), (int)state, typeof(NodeState));
            }
            if (state == NodeState.Unknown)
            {
                throw new ArgumentException($"Node state cannot be transitioned to {nameof(NodeState.Unknown)}", nameof(state));
            }
            if (string.IsNullOrEmpty(reason))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(reason));
            }

            this.HostName = hostName;
            this.State = state;
            this.Reason = reason;
        }

        /// <summary>
        /// Gets or sets the name of the host.
        /// </summary>
        /// <value>
        /// The name of the host.
        /// </value>
        public string HostName { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public NodeState State { get; set; }

        /// <summary>
        /// Gets or sets the reason for the state transition
        /// </summary>
        /// <value>
        /// The reason.
        /// </value>
        public string Reason { get; set; }
    }
}