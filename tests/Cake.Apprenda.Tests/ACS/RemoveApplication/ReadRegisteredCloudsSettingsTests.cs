using System;
using Cake.Apprenda.ACS.RemoveApplication;
using FluentAssertions;
using Xunit;

namespace Cake.Apprenda.Tests.ACS.RemoveApplication
{
    public sealed class RemoveApplicationSettingsTests : ACSSettingsTestsBase<RemoveApplicationSettings>
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void TheCtorShouldThrowWhenAppAliasIsNullOrEmpty(string appAlias)
        {
            Constructor(() => new RemoveApplicationSettings(appAlias)).ShouldThrow<ArgumentException>().And.ParamName.Should().Be("appAlias");
        }

        [Fact]
        public void TheCtorShouldNotThrowWhenValidArgumentsAreSpecified()
        {
            Constructor(() => new RemoveApplicationSettings("appAlias")).ShouldNotThrow();
        }
    }
}
