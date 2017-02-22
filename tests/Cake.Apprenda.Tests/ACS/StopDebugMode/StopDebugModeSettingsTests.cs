using System;
using Cake.Apprenda.ACS.StopDebugMode;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.StopDebugMode
{
    public sealed class StopDebugModeSettingsTests : ACSSettingsTestsBase<StopDebugModeSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenAppAliasIsNullOrEmpty(string appAlias)
        {
            Constructor(() => new StopDebugModeSettings(appAlias, "versionAlias")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("appAlias");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenVersionAliasIsNullOrEmpty(string versionAlias)
        {
            Constructor(() => new StopDebugModeSettings("appalias", versionAlias)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("versionAlias");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new StopDebugModeSettings("appalias", "v1")).ShouldNotThrow();
        }
    }
}
