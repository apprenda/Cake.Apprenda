using System;
using Cake.Apprenda.AMM.RegisterCloud;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.AMM.RegisterCloud
{
    public sealed class RegisterCloudSettingsTests : MaintenanceModeSettingsTestsBase<RegisterCloudSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenAppAliasIsNullOrEmpty(string cloudUrl)
        {
            this.Constructor(() => new RegisterCloudSettings(cloudUrl, "cloudAlias")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("cloudUrl");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenVersionAliasIsNullOrEmpty(string cloudAlias)
        {
            this.Constructor(() => new RegisterCloudSettings("http://cloud.url", cloudAlias)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("cloudAlias");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            this.Constructor(() => new RegisterCloudSettings("http://cloud.url", "CloudAlias")).ShouldNotThrow();
        }
    }
}
