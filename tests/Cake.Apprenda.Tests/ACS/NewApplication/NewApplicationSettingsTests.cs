using System;
using Cake.Apprenda.ACS.NewApplication;
using FluentAssertions;
using Xunit;
// ReSharper disable NotAccessedVariable

namespace Cake.Apprenda.Tests.ACS.NewApplication
{
    public sealed class NewApplicationSettingsTests : ACSSettingsTestsBase<NewApplicationSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenAppAliasIsNullOrEmpty(string appName)
        {
            Constructor(() => new NewApplicationSettings(appName, "appAlias")).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("appName");
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenVersionAliasIsNullOrEmpty(string appAlias)
        {
            Constructor(() => new NewApplicationSettings("appname", appAlias)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("appAlias");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new NewApplicationSettings("appname", "appalias")).ShouldNotThrow();
        }
    }
}
