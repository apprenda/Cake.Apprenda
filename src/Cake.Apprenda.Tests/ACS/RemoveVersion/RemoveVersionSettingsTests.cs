using System;
using Cake.Apprenda.ACS.RemoveVersion;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.RemoveVersion
{
    public sealed class RemoveVersionSettingsTests : CloudShellSettingsTestsBase<RemoveVersionSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenAppAliasIsNullOrEmpty(string appAlias)
        {
            Constructor(() => new RemoveVersionSettings(appAlias, "versionAlias")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("appAlias");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenVersionAliasIsNullOrEmpty(string versionAlias)
        {
            Constructor(() => new RemoveVersionSettings("appalias", versionAlias)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("versionAlias");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new RemoveVersionSettings("appalias", "v1")).ShouldNotThrow();
        }
    }
}
