using System;
using Cake.Apprenda.ACS.StartInDebugMode;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.StartInDebugMode
{
    public sealed class StartInDebugModeSettingsTests : ACSSettingsTestsBase<StartInDebugModeSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenAppAliasIsNullOrEmpty(string appAlias)
        {
            Constructor(() => new StartInDebugModeSettings(appAlias, "versionAlias")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("appAlias");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenVersionAliasIsNullOrEmpty(string versionAlias)
        {
            Constructor(() => new StartInDebugModeSettings("appalias", versionAlias)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("versionAlias");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new StartInDebugModeSettings("appalias", "v1")).ShouldNotThrow();
        }
    }
}
