using System;
using Cake.Apprenda.ACS.StopVersion;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.StopVersion
{
    public sealed class StopVersionSettingsTests : ACSSettingsTestsBase<StopVersionSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenAppAliasIsNullOrEmpty(string appAlias)
        {
            Constructor(() => new StopVersionSettings(appAlias, "versionAlias")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("appAlias");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenVersionAliasIsNullOrEmpty(string versionAlias)
        {
            Constructor(() => new StopVersionSettings("appalias", versionAlias)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("versionAlias");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new StopVersionSettings("appalias", "v1")).ShouldNotThrow();
        }
    }
}
