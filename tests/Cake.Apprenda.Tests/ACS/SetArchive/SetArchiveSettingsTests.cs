using System;
using Cake.Apprenda.ACS.SetArchive;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.SetArchive
{
    public sealed class SetArchiveSettingsTests : ACSSettingsTestsBase<SetArchiveSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenAppAliasIsNullOrEmpty(string appAlias)
        {
            Constructor(() => new SetArchiveSettings(appAlias, "versionAlias")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("appAlias");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenVersionAliasIsNullOrEmpty(string versionAlias)
        {
            Constructor(() => new SetArchiveSettings("appalias", versionAlias)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("versionAlias");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new SetArchiveSettings("appalias", "v1")).ShouldNotThrow();
        }

        [Fact]
        public void BuildSettingsShouldNotBeNull()
        {
            var settings = new SetArchiveSettings("appalias", "versionalias");
            settings.BuildSettings.Should().NotBeNull();
        }
    }
}
