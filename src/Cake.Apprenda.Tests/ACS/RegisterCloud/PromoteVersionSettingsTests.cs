using System;
using Cake.Apprenda.ACS.RegisterCloud;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.RegisterCloud
{
    public sealed class RegisterCloudSettingsTests : ACSSettingsTestsBase<RegisterCloudSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenAppAliasIsNullOrEmpty(string cloudUrl)
        {
            Constructor(() => new RegisterCloudSettings(cloudUrl, "cloudAlias")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("cloudUrl");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenVersionAliasIsNullOrEmpty(string cloudAlias)
        {
            Constructor(() => new RegisterCloudSettings("http://cloud.url", cloudAlias)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("cloudAlias");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new RegisterCloudSettings("http://cloud.url", "CloudAlias")).ShouldNotThrow();
        }
    }
}
