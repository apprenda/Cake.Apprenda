using System;
using Cake.Apprenda.AMM.GetNodeState;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.AMM.GetNodeState
{
    public sealed class GetNodeStateSettingsTests : MaintenanceModeSettingsTestsBase<GetNodeStateSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenHostNameIsNullOrEmpty(string hostName)
        {
            this.Constructor(() => new GetNodeStateSettings(hostName)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("hostName");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            this.Constructor(() => new GetNodeStateSettings("cerberus")).ShouldNotThrow();
        }
    }
}
