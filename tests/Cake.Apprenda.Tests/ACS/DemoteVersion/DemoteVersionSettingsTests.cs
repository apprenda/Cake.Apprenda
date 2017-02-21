using System;
using Cake.Apprenda.ACS.DemoteVersion;
using FluentAssertions;
using Xunit;
// ReSharper disable NotAccessedVariable

namespace Cake.Apprenda.Tests.ACS.DemoteVersion
{
    public sealed class DemoteVersionSettingsTests : ACSSettingsTestsBase<DemoteVersionSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenAppAliasIsNullOrEmpty(string appAlias)
        {
            Constructor(() => new DemoteVersionSettings(appAlias, "versionAlias")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("appAlias");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenVersionAliasIsNullOrEmpty(string versionAlias)
        {
            Constructor(() => new DemoteVersionSettings("appalias", versionAlias)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("versionAlias");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new DemoteVersionSettings("appalias", "v1")).ShouldNotThrow();
        }
    }
}
