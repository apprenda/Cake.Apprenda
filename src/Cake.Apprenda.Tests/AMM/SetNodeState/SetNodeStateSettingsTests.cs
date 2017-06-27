using System;
using System.ComponentModel;
using Cake.Apprenda.AMM;
using Cake.Apprenda.AMM.SetNodeState;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.AMM.SetNodeState
{
    public sealed class SetNodeStateSettingsTests : MaintenanceModeSettingsTestsBase<SetNodeStateSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenHostNameIsNullOrEmpty(string hostName)
        {
            this.Constructor(() => new SetNodeStateSettings(hostName, NodeState.Reserved, "reason")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("hostName");
        }

        [Fact]
        public void TheCtorShouldThrowWhenStateIsUnknown()
        {
            this.Constructor(() => new SetNodeStateSettings("cerberus", NodeState.Unknown, "reason")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("state");
        }

        [Fact]
        public void TheCtorShouldThrowWhenStateIsInvalid()
        {
            this.Constructor(() => new SetNodeStateSettings("cerberus", (NodeState)23, "reason")).ShouldThrow<InvalidEnumArgumentException>().And.ParamName.Should().Be("state");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenReasonIsNullOrEmpty(string reason)
        {
            this.Constructor(() => new SetNodeStateSettings("cerberus", NodeState.Reserved, reason)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("reason");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            this.Constructor(() => new SetNodeStateSettings("cerberus", NodeState.Maintenance, "reason")).ShouldNotThrow();
        }
    }
}
