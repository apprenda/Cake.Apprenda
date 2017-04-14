using System;
using Cake.Apprenda.ACS.StartVersion;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.StartVersion
{
    public sealed class StartVersionSettingsTests : ACSSettingsTestsBase<StartVersionSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenAppAliasIsNullOrEmpty(string appAlias)
        {
            Constructor(() => new StartVersionSettings(appAlias, "versionAlias")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("appAlias");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenVersionAliasIsNullOrEmpty(string versionAlias)
        {
            Constructor(() => new StartVersionSettings("appalias", versionAlias)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("versionAlias");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new StartVersionSettings("appalias", "v1")).ShouldNotThrow();
        }
    }
}
