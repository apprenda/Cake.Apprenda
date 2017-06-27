using System;
using Cake.Apprenda.AMM.ConnectCloud;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.AMM.ConnectCloud
{
    public sealed class ConnectCloudSettingsTests : MaintenanceModeSettingsTestsBase<ConnectCloudSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenCloudAliasIsNullOrEmpty(string cloudAlias)
        {
            this.Constructor(() => new ConnectCloudSettings(cloudAlias, "user", "password")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("cloudAlias");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenUserIsNullOrEmpty(string user)
        {
            this.Constructor(() => new ConnectCloudSettings("cloud", user, "password")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("user");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenPasswordIsNullOrEmpty(string password)
        {
            this.Constructor(() => new ConnectCloudSettings("cloud", "user", password)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("password");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            this.Constructor(() => new ConnectCloudSettings("cloud", "user", "password")).ShouldNotThrow();
        }
    }
}
