using System;
using Cake.Apprenda.ACS.PromoteVersion;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.PromoteVersion
{
    public sealed class PromoteVersionSettingsTests : CloudShellSettingsTestsBase<PromoteVersionSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenAppAliasIsNullOrEmpty(string appAlias)
        {
            Constructor(() => new PromoteVersionSettings(appAlias, "versionAlias")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("appAlias");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenVersionAliasIsNullOrEmpty(string versionAlias)
        {
            Constructor(() => new PromoteVersionSettings("appalias", versionAlias)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("versionAlias");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new PromoteVersionSettings("appalias", "v1")).ShouldNotThrow();
        }
    }
}
