using System;
using Cake.Apprenda.ACS.ConnectCloud;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.ConnectCloud
{
    public sealed class ConnectCloudSettingsTests : ACSSettingsTestsBase<ConnectCloudSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenCloudAliasIsNullOrEmpty(string cloudAlias)
        {
            Constructor(() => new ConnectCloudSettings(cloudAlias, "user", "password")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("cloudAlias");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenUserIsNullOrEmpty(string user)
        {
            Constructor(() => new ConnectCloudSettings("cloud", user, "password")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("user");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenPasswordIsNullOrEmpty(string password)
        {
            Constructor(() => new ConnectCloudSettings("cloud", "user", password)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("password");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new ConnectCloudSettings("cloud", "user", "password")).ShouldNotThrow();
        }
    }
}
