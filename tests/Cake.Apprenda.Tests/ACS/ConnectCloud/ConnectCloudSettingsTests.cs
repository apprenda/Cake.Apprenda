using System;
using Cake.Apprenda.ACS.ConnectCloud;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.ConnectCloud
{
    public sealed class ConnectCloudSettingsTests
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenCloudAliasIsNullOrEmpty(string cloudAlias)
        {
            ConnectCloudSettings settings;
            Action action = () => settings = new ConnectCloudSettings(cloudAlias, "user", "password");
            action.ShouldThrow<ArgumentException>().And.ParamName.Should().Be("cloudAlias");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenUserIsNullOrEmpty(string user)
        {
            ConnectCloudSettings settings;
            Action action = () => settings = new ConnectCloudSettings("cloud", user, "password");
            action.ShouldThrow<ArgumentException>().And.ParamName.Should().Be("user");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenPasswordIsNullOrEmpty(string password)
        {
            ConnectCloudSettings settings;
            Action action = () => settings = new ConnectCloudSettings("cloud", "user", password);
            action.ShouldThrow<ArgumentException>().And.ParamName.Should().Be("password");
        }
    }
}
