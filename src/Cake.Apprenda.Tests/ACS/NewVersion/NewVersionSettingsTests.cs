using System;
using Cake.Apprenda.ACS.NewVersion;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.NewVersion
{
    public sealed class NewVersionSettingsTests : CloudShellSettingsTestsBase<NewVersionSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenAppAliasIsNullOrEmpty(string appAlias)
        {
            Constructor(() => new NewVersionSettings(appAlias, "versionAlias")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("appAlias");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenVersionAliasIsNullOrEmpty(string versionAlias)
        {
            Constructor(() => new NewVersionSettings("appalias", versionAlias)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("versionAlias");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new NewVersionSettings("appalias", "v1")).ShouldNotThrow();
        }
        [Fact]
        public void BuildSettingsShouldNotBeNull()
        {
            var settings = new NewVersionSettings("appalias", "v1");
            settings.BuildSettings.Should().NotBeNull();
        }
    }
}
