using System;
using Cake.Apprenda.ACS.PatchVersion;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.PatchVersion
{
    public sealed class PatchVersionSettingsTests : ACSSettingsTestsBase<PatchVersionSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenAppAliasIsNullOrEmpty(string appAlias)
        {
            Constructor(() => new PatchVersionSettings(appAlias, "versionAlias")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("appAlias");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenVersionAliasIsNullOrEmpty(string versionAlias)
        {
            Constructor(() => new PatchVersionSettings("appalias", versionAlias)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("versionAlias");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new PatchVersionSettings("appalias", "v1")).ShouldNotThrow();
        }

        [Fact]
        public void BuildSettingsShouldNotBeNull()
        {
            var settings = new PatchVersionSettings("appalias", "versionalias");
            settings.BuildSettings.Should().NotBeNull();
        }
    }
}

